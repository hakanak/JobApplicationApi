using System.Text.Json.Serialization;

namespace JobApplicationApi.Model
{
    public class UserSchool
    {
        public int? id { get; set; }
        public int userid { get; set; }
        public string schoolName { get; set; }
        public string department { get; set; }
        public int? starteddate { get; set; }
        public string graduationdegree { get; set; }
        public string degree { get; set; }
        public int? enddate { get; set; }
    }
    public class UserSchoolDto
    {
        [JsonPropertyName("Firstid")]
        public int? Firstid { get; set; } = 0;

        [JsonPropertyName("FirstschoolName")]
        public string? FirstschoolName { get; set; }

        [JsonPropertyName("Firstdepartment")]
        public string? Firstdepartment { get; set; }

        [JsonPropertyName("Firststarteddate")]
        public int? Firststarteddate { get; set; }

        [JsonPropertyName("Firstgraduationdegree")]
        public string? Firstgraduationdegree { get; set; }

        [JsonPropertyName("Firstdegree")]
        public string? Firstdegree { get; set; }

        [JsonPropertyName("Firstenddate")]
        public int? Firstenddate { get; set; }

        [JsonPropertyName("Hightid")]
        public int? Hightid { get; set; }

        [JsonPropertyName("Hightdepartment")]
        public string? Hightdepartment { get; set; }

        [JsonPropertyName("HightschoolName")]
        public string? HightschoolName { get; set; }

        [JsonPropertyName("Hightstarteddate")]
        public int? Hightstarteddate { get; set; }

        [JsonPropertyName("Hightgraduationdegree")]
        public string? Hightgraduationdegree { get; set; }

        [JsonPropertyName("Hightdegree")]
        public string? Hightdegree { get; set; }



        [JsonPropertyName("Hightenddate")]
        public int? Hightenddate { get; set; }

        [JsonPropertyName("Lisansid")]
        public int? Lisansid { get; set; }

        [JsonPropertyName("Lisansdepartment")]
        public string? Lisansdepartment { get; set; }

        [JsonPropertyName("LisansschoolName")]
        public string? LisansschoolName { get; set; }

        [JsonPropertyName("Lisansstarteddate")]
        public int? Lisansstarteddate { get; set; }

        [JsonPropertyName("Lisansgraduationdegree")]
        public string? Lisansgraduationdegree { get; set; }

        [JsonPropertyName("Lisansdegree")]
        public string? Lisansdegree { get; set; }

        [JsonPropertyName("Lisansenddate")]
        public int? Lisansenddate { get; set; }

        [JsonPropertyName("Doktoraid")]
        public int? Doktoraid { get; set; }

        [JsonPropertyName("Doktoradepartment")]
        public string? Doktoradepartment { get; set; }

        [JsonPropertyName("DoktoraschoolName")]
        public string? DoktoraschoolName { get; set; }

        [JsonPropertyName("Doktorastarteddate")]
        public int? Doktorastarteddate { get; set; }

        [JsonPropertyName("Doktoragraduationdegree")]
        public string? Doktoragraduationdegree { get; set; }

        [JsonPropertyName("Doktoradegree")]
        public string? Doktoradegree { get; set; }

        [JsonPropertyName("Doktoraenddate")]
        public int? Doktoraenddate { get; set; }

        [JsonPropertyName("Masterid")]
        public int? Masterid { get; set; }

        [JsonPropertyName("Masterdepartment")]
        public string? Masterdepartment { get; set; }

        [JsonPropertyName("MasterschoolName")]
        public string? MasterschoolName { get; set; }

        [JsonPropertyName("Masterstarteddate")]
        public int? Masterstarteddate { get; set; }

        [JsonPropertyName("Mastergraduationdegree")]
        public string? Mastergraduationdegree { get; set; }

        [JsonPropertyName("Masterdegree")]
        public string? Masterdegree { get; set; }

        [JsonPropertyName("Masterenddate")]
        public int? Masterenddate { get; set; }

        [JsonPropertyName("token")]
        public string? token { get; set; }

        [JsonPropertyName("userid")]
        public int? userid { get; set; }
    }

}
