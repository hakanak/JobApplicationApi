using JobApplicationApi.Model;
using System.Data.SqlClient;
using Dapper;

namespace JobApplicationApi.Reporsitory
{
    public class SystemRepository
    {
        private SqlConnection connection = new SqlConnection("Data Source=intranetdb.tirsan.com;Initial Catalog=HRJOBPOOL;Integrated Security=false;User ID=PYO;Password=Rapor2015");

        public UserDto Login(logindto model)
        {
            UserDto userToCheck = connection.Query<UserDto>(@"SELECt [id]
                ,[username] + ' '+[usersurname] as name 
				,isactive as durum
				,email as email
,id as id
            FROM [HRJOBPOOL].[dbo].[User] where email='hesapcaglak@gmail.com'", new { key = model.email }).FirstOrDefault();
            if (userToCheck != null)
            {
                userToCheck.issuccesfull= true;
                return userToCheck;
            }
            userToCheck.issuccesfull = false;
            return userToCheck;
        }
        public UserDto Register(registerdto model)
        {
            UserDto userToCheck = new UserDto();
            userToCheck = connection.Query<UserDto>(@"SELECt [id]
                ,[username] + ' '+[usersurname] as name 
				,isactive as durum
				,email as email
,id as id
            FROM [HRJOBPOOL].[dbo].[User] where email=@key", new { key = model.email }).FirstOrDefault();
            if (userToCheck == null)
            {
                connection.Execute(" insert [User]( [username],[usersurname],[email],[passwordhash]) values(@username,@usersurname,@email,@passwordhash)", new
                {
                    username = model.ad,
                    usersurname = model.soyad,
                    email = model.email,
                    passwordhash = model.password
                });
                userToCheck = connection.Query<UserDto>(@"SELECt [id]
                ,[username] + ' '+[usersurname] as name 
				,isactive as durum
				,email as email
,id as id
            FROM [HRJOBPOOL].[dbo].[User] where email=@key", new { key = model.email }).FirstOrDefault();
                userToCheck.issuccesfull = true;
                return userToCheck;
            }
            userToCheck.issuccesfull = false;
            return userToCheck;
        }


        
    }
}
