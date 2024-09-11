using JobApplicationApi.Model;
using JobApplicationApi.Reporsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository usr = new UserRepository();
        TokenRepository tkn = new TokenRepository("90b3b0b3743dde3acf7abf101f544540b1033d7075e121e12330c60c110d8662ca101da07136c4112", 3600);
        // GET: api/<UserController>
        [HttpGet("{token}")]
        public ResultData<string> Get(string token)
        {
            ClaimsPrincipal data =tkn.DecodeToken(token);
            try
            {
                return usr.UserAktif(Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value));

            }
            catch (Exception ex)
            {
                return new ResultData<string> { successful=false};

            }
        }
        [HttpPost("UpdateIsActive")]
        public ResultData<string> UpdateIsActive(UpdateIsActive options)
        {
            ClaimsPrincipal data = tkn.DecodeToken(options.token);
            return usr.UpdateIsActive(Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value), options.deger);
        }

        [HttpPost("GetKisiselBilgiler")]
        public ResultData<UserKisiselBilgiler> GetKisiselBilgiler(GetTokenValue model)
        {
            ClaimsPrincipal data = tkn.DecodeToken(model.token);
            if(data==null)
            {
                UserKisiselBilgiler emptydata = new UserKisiselBilgiler();
                ResultData<UserKisiselBilgiler> resultData = new ResultData<UserKisiselBilgiler>
                {
                    Data = emptydata,
                    message = "Token işlenemedi" ,
                    successful = false,
                    Id = 0,
                    number_result = 0
                };
                return resultData;
            }
            return usr.GetUserKisiselBilgiler(Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value));
        }


        [HttpPost("UpdateUserKisiselBilgiler")]
        public ResultData<KisiselBilgilerDto> UpdateUserKisiselBilgiler(KisiselBilgilerDto model)
        {
            ClaimsPrincipal data = tkn.DecodeToken(model.token);
            if (data == null)
            {
                KisiselBilgilerDto emptydata = new KisiselBilgilerDto();
                ResultData<KisiselBilgilerDto> resultData = new ResultData<KisiselBilgilerDto>
                {
                    Data = emptydata,
                    message = "Token işlenemedi",
                    successful = false,
                    Id = 0,
                    number_result = 0
                };
                return resultData;
            }
            model.Id = Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return usr.UpdateUserKisiselBilgiler((model));
        }
        
        [HttpPost("UpdateUserOkul")]
        public ResultData<bool> UpdateUserOkul(UserSchoolDto model)
        {
            ClaimsPrincipal data = tkn.DecodeToken(model.token);
            if (data == null)
            {
                ResultData<bool> resultData = new ResultData<bool>
                {
                    Data = false,
                    message = "Token işlenemedi",
                    successful = false,
                    Id = 0,
                    number_result = 0
                };
                return resultData;
            }
          
            int userid = Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            List<UserSchool> updatedata = new List<UserSchool>();
            if(model.Firstdegree== "İLK ÖĞRETİM")
            {
                updatedata.Add(new UserSchool { 
                    userid=userid,
                    degree=model.Firstdegree,
                    department=model.Firstdepartment,
                    enddate=model.Firstenddate,
                    graduationdegree=model.Firstgraduationdegree,
                    id=model.Firstid,
                    schoolName=model.FirstschoolName,
                    starteddate=model.Firststarteddate
                });                    
            }
            if (model.Hightdegree == "LİSE")
            {
                updatedata.Add(new UserSchool
                {
                    userid = userid,
                    degree = model.Hightdegree,
                    department = model.Hightdepartment,
                    enddate = model.Hightenddate,
                    graduationdegree = model.Hightgraduationdegree,
                    id = model.Hightid,
                    schoolName = model.HightschoolName,
                    starteddate = model.Hightstarteddate
                });
            }
            if (model.Lisansdegree == "LİSANS") {
                updatedata.Add(new UserSchool
                {
                    userid = userid,
                    degree = model.Lisansdegree,
                    department = model.Lisansdepartment,
                    enddate = model.Lisansenddate,
                    graduationdegree = model.Lisansgraduationdegree,
                    id = model.Lisansid,
                    schoolName = model.LisansschoolName,
                    starteddate = model.Lisansstarteddate
                });
            }
            if (model.Masterdegree == "MASTER") {
                updatedata.Add(new UserSchool
                {
                    userid = userid,
                    degree = model.Masterdegree,
                    department = model.Masterdepartment,
                    enddate = model.Masterenddate,
                    graduationdegree = model.Mastergraduationdegree,
                    id = model.Masterid,
                    schoolName = model.MasterschoolName,
                    starteddate = model.Masterstarteddate
                });
            }
            if (model.Masterdegree == "DOKTORA") {
                updatedata.Add(new UserSchool
                {
                    userid = userid,
                    degree = model.Doktoradegree,
                    department = model.Doktoradepartment,
                    enddate = model.Doktoraenddate,
                    graduationdegree = model.Doktoragraduationdegree,
                    id = model.Doktoraid,
                    schoolName = model.DoktoraschoolName,
                    starteddate = model.Doktorastarteddate
                });
            }


            return usr.InsertSchool((updatedata));
        }

        [HttpPost("GetEgitimBilgileri")]
        public ResultData<UserSchoolDto> GetEgitimBilgileri(GetTokenValue model_)
        {
            UserSchoolDto emptydata = new UserSchoolDto();

            ClaimsPrincipal data = tkn.DecodeToken(model_.token);
            if (data == null)
            {
                UserSchoolDto emptydata_ = new UserSchoolDto();
                ResultData<UserSchoolDto> resultData = new ResultData<UserSchoolDto>
                {
                    Data = emptydata_,
                    message = "Token işlenemedi",
                    successful = false,
                    Id = 0,
                    number_result = 0
                };
                return resultData;
            }



            var resultdata= usr.GetSchoolBilgileri(Convert.ToInt16(data.FindFirst(ClaimTypes.NameIdentifier)?.Value));

            foreach (UserSchool model in resultdata)
            {
                if (model.degree == "İLK ÖĞRETİM")
                {
                    emptydata.Firstid = model.id;
                    emptydata.userid = model.userid;
                    emptydata.Firstdegree = model.degree;
                    emptydata.Firstdepartment = model.department;
                    emptydata.Firstenddate = model.enddate;
                    emptydata.Firstgraduationdegree = model.graduationdegree;
                    emptydata.FirstschoolName = model.schoolName;
                    emptydata.Firststarteddate = model.starteddate;                   
                }
                if (model.degree == "LİSE")
                {
                    emptydata.Hightid = model.id;
                    emptydata.userid = model.userid;
                    emptydata.Hightdegree = model.degree;
                    emptydata.Hightdepartment = model.department;
                    emptydata.Hightenddate = model.enddate;
                    emptydata.Hightgraduationdegree = model.graduationdegree;
                    emptydata.HightschoolName = model.schoolName;
                    emptydata.Hightstarteddate = model.starteddate;                  
                }
                if (model.degree == "LİSANS")
                {
                    emptydata.Lisansid = model.id;
                    emptydata.userid = model.userid;
                    emptydata.Lisansdegree = model.degree;
                    emptydata.Lisansdepartment = model.department;
                    emptydata.Lisansenddate = model.enddate;
                    emptydata.Lisansgraduationdegree = model.graduationdegree;
                    emptydata.LisansschoolName = model.schoolName;
                    emptydata.Lisansstarteddate = model.starteddate;                    
                }
                if (model.degree == "MASTER")
                {
                    emptydata.Masterid = model.id;
                    emptydata.userid = model.userid;
                    emptydata.Masterdegree = model.degree;
                    emptydata.Masterdepartment = model.department;
                    emptydata.Masterenddate = model.enddate;
                    emptydata.Mastergraduationdegree = model.graduationdegree;
                    emptydata.MasterschoolName = model.schoolName;
                    emptydata.Masterstarteddate = model.starteddate;
                }
                if (model.degree == "DOKTORA")
                {
                    emptydata.Doktoraid = model.id;
                    emptydata.userid = model.userid;
                    emptydata.Doktoradegree = model.degree;
                    emptydata.Doktoradepartment = model.department;
                    emptydata.Doktoraenddate = model.enddate;
                    emptydata.Doktoragraduationdegree = model.graduationdegree;
                    emptydata.DoktoraschoolName = model.schoolName;
                    emptydata.Doktorastarteddate = model.starteddate;
                }
            }
            return new ResultData<UserSchoolDto> { Data=emptydata};
        }



        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
