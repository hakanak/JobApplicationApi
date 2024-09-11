using Dapper;
using JobApplicationApi.Model;
using System.Data.SqlClient;
using System.Reflection;

namespace JobApplicationApi.Reporsitory
{
    public class UserRepository
    {
        private SqlConnection connection = new SqlConnection("Data Source=intranetdb.tirsan.com;Initial Catalog=HRJOBPOOL;Integrated Security=false;User ID=PYO;Password=Rapor2015");

        public ResultData<string> UserAktif(int id)
        {
            try
            {
                int deger = connection.Query<int>("select top 1 isactive from [User] where email='hesapcaglak@gmail.com'").FirstOrDefault();
                if (deger == 1)
                {
                    ResultData<string> resultData = new ResultData<string>
                    {
                        Data = "Şuan Aktif",
                        message = "Sorgu başarılı",
                        successful = true,
                        number_result=deger,
                        Id = id
                    };
                    return resultData;
                }
                else if (deger == 0)
                {
                    ResultData<string> resultData = new ResultData<string>
                    {
                        Data = "Şuan Pasif",
                        message = "Sorgu başarılı",
                        successful = true,
                        number_result = deger,
                        Id = id
                    };
                    return resultData;
                }
                else
                {
                    ResultData<string> resultData = new ResultData<string>
                    {
                        Data = "Kullanıcı Bulunamadı",
                        message = "Sorgu başarılı",
                        number_result = deger,
                        successful = true,
                        Id = id
                    };
                    return resultData;
                }
            }
            catch(Exception ex) {
                ResultData<string> resultData = new ResultData<string>
                {
                    Data = "Kullanıcı Bulunamadı",
                    message = "Sorgu Hatalı :"+ex.Message.ToString(),
                    successful = true,
                    Id = id,
                    number_result = 10
                };
                return resultData;
            }
        }


        public ResultData<string> UpdateIsActive(int id, int deger)
        {
            try
            {
                connection.Execute("  update [User] set isactive=@key where id=@id", new {id=id,key=deger});
                return UserAktif(id);
            }
            catch(Exception ex)
            {
                ResultData<string> resultData = new ResultData<string>
                {
                    Data = "Kullanıcı Bulunamadı",
                    message = "Sorgu Hatalı :" + ex.Message.ToString(),
                    successful = true,
                    Id = id,
                    number_result = 10
                };
                return resultData;
            }
        }

        public ResultData<UserKisiselBilgiler> GetUserKisiselBilgiler(int id)
        {
            try
            {
                 string query = @"
            SELECT [id]
                ,[username]
                ,[usersurname]
                ,CONVERT(NVARCHAR(150), [dateofbirth], 23) AS [dateofbirth]
                ,[gender]
                ,[height]
                ,[weight]
                ,[nationality]
                ,[maritalstatus]
                ,[address]
                ,[homephone]
                ,[phonenumber]
                ,[email]
                ,[tc]
                ,CONVERT(NVARCHAR(150), [insurancestartdate], 23) AS [insurancestartdate]
                ,[isactive]
                ,[guid]
            FROM [HRJOBPOOL].[dbo].[User]
            WHERE [id] = @id";
                UserKisiselBilgiler deger = connection.Query<UserKisiselBilgiler>(query, new {id=id}).FirstOrDefault();
                if (deger !=null)
                {
                    ResultData<UserKisiselBilgiler> resultData = new ResultData<UserKisiselBilgiler>
                    {
                        Data = deger,
                        message = "Sorgu başarılı",
                        successful = true,
                        number_result = 0,
                        Id = id
                    };
                    return resultData;
                }
                else
                {
                    ResultData<UserKisiselBilgiler> resultData = new ResultData<UserKisiselBilgiler>
                    {
                        Data = deger,
                        message = "Kullanıcı Bulunamadı",
                        successful = true,
                        number_result = 0,
                        Id = id
                    };
                    return resultData;
                }               
                
            }
            catch (Exception ex)
            {
                UserKisiselBilgiler emptydata=new UserKisiselBilgiler();
                ResultData<UserKisiselBilgiler> resultData = new ResultData<UserKisiselBilgiler>
                {
                    Data = emptydata,
                    message = "Sorgu Hatalı :" + ex.Message.ToString(),
                    successful = false,
                    Id = id,
                    number_result = 10
                };
                return resultData;
            }
        }
        public ResultData<KisiselBilgilerDto> UpdateUserKisiselBilgiler(KisiselBilgilerDto mdl)
        {
            try
            {
                string query = @"
            SELECT [id]
                ,[username]
                ,[usersurname]
                ,CONVERT(NVARCHAR(50), [dateofbirth], 23) AS [dateofbirth]
                ,[gender]
                ,[height]
                ,[weight]
                ,[nationality]
                ,[maritalstatus]
                ,[address]
                ,[homephone]
                ,[phonenumber]
                ,[email]
                ,[tc]
                ,[insurancestartdate]
                ,[isactive]
                ,[guid]
            FROM [HRJOBPOOL].[dbo].[User]
            WHERE [id] = @id";
                KisiselBilgilerDto deger = connection.Query<KisiselBilgilerDto>(query, new { id = mdl.Id }).FirstOrDefault();
                if (deger != null)
                {

                    connection.Execute(@"UPDATE [HRJOBPOOL].[dbo].[User]
                    SET
                        [username] = @username,
                        [usersurname] = @usersurname,
                        [dateofbirth] = CONVERT(DATE, @dateofbirth, 23),
                        [gender] = @gender,
                        [height] = @height,
                        [weight] = @weight,
                        [nationality] = @nationality,
                        [maritalstatus] = @maritalstatus,
                        [address] = @address,
                        [homephone] = @homephone,
                        [phonenumber] = @phonenumber,
                        [email] = @email,
                        [tc] = @tc,
                        [insurancestartdate] = CONVERT(DATE, @insurancestartdate, 23)
                    WHERE
                        [id] = @id;
                    ", new { username=mdl.Username, usersurname=mdl.UserSurname, dateofbirth=mdl.DateOfBirth, gender=mdl.Gender, height=mdl.height, weight= mdl.weight , nationality =mdl.Nationality, maritalstatus =mdl.MaritalStatus, address = mdl.Address, homephone =mdl.HomePhone, phonenumber =mdl.PhoneNumber, email =mdl.Email,tc=mdl.TC, insurancestartdate =mdl.InsuranceStartDate});



                    ResultData<KisiselBilgilerDto> resultData = new ResultData<KisiselBilgilerDto>
                    {
                        Data = mdl,
                        message = "Sorgu başarılı",
                        successful = true,
                        number_result = 0,
                        Id = mdl.Id
                    };
                    return resultData;
                }
                else
                {
                    ResultData<KisiselBilgilerDto> resultData = new ResultData<KisiselBilgilerDto>
                    {
                        Data = deger,
                        message = "Kullanıcı Bulunamadı",
                        successful = true,
                        number_result = 0,
                        Id = mdl.Id
                    };
                    return resultData;
                }

            }
            catch (Exception ex)
            {
                KisiselBilgilerDto emptydata = new KisiselBilgilerDto();
                ResultData<KisiselBilgilerDto> resultData = new ResultData<KisiselBilgilerDto>
                {
                    Data = emptydata,
                    message = "Sorgu Hatalı :" + ex.Message.ToString(),
                    successful = false,
                    Id = mdl.Id,
                    number_result = 10
                };
                return resultData;
            }
        }




        public ResultData<bool> InsertSchool(List<UserSchool> data)
        {
            foreach (UserSchool item in data)
            {
                try
                {
                    if (data != null)
                    {
                        var data_ = connection.Query<UserSchool>("SELECT *  FROM [HRJOBPOOL].[dbo].[UserSchool] where userid=@key and degree=@degree", new { degree = item.degree, key = item.userid }).FirstOrDefault();
                        if (data_ != null)
                        {
                            connection.Execute(@"update [UserSchool] set [userid]=@userid
      ,[schoolName]=@schoolName
      ,[department]=@department
      ,[starteddate]=@starteddate
      ,[graduationdegree]=@graduationdegree
      ,[degree]=@degree
      ,[enddate]=@enddate where id=@id", new
                            {
                                userid = item.userid,
                                schoolName = item.schoolName,
                                department = item.department,
                                starteddate = item.starteddate,
                                graduationdegree = item.graduationdegree,
                                degree = item.degree,
                                enddate = item.enddate,
                                id = data_.id
                            });
                        }
                        else
                        {
                            connection.Execute(@"  insert [UserSchool]([userid]
      ,[schoolName]
      ,[department]
      ,[starteddate]
      ,[graduationdegree]
      ,[degree]
      ,[enddate]) values (
	  @userid 
      ,@schoolName 
      ,@department 
      ,@starteddate 
      ,@graduationdegree 
      ,@degree 
      ,@enddate 	  
	  ) ", new
                            {
                                userid = item.userid,
                                schoolName = item.schoolName,
                                department = item.department,
                                starteddate = item.starteddate,
                                graduationdegree = item.graduationdegree,
                                degree = item.degree,
                                enddate = item.enddate
                            });
                        }

                    }
                }
                catch(Exception ex) { 
                
                }
                
              
            }
            
            return new ResultData<bool> { Data=true,successful=true};
        }

        public List<UserSchool> GetSchoolBilgileri(int id)
        {
            return connection.Query<UserSchool>("select * from UserSchool where userid=@userid", new {userid=id}).ToList();
        }
    }
}
