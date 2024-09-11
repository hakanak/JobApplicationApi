using System.Text.Json.Serialization;

namespace JobApplicationApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserSurname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string TC { get; set; }
        public DateTime? InsuranceStartDate { get; set; }
        public string IsMilitaryService { get; set; }
        public DateTime? MilitaryRegistrationDate { get; set; }
        public string MilitaryAddress { get; set; }
        public string MilitaryReason { get; set; }
        public string IsConviction { get; set; }
        public string ConvictionReason { get; set; }
        public string IsCompulsoryService { get; set; }
        public string CompulsoryServiceReason { get; set; }
        public string IsDriversLicense { get; set; }
        public string DriversLicenseReason { get; set; }
        public string IsIllness { get; set; }
        public string IllnessReason { get; set; }
        public string IsSeriousHealth { get; set; }
        public string SeriousHealthReason { get; set; }
        public string IsSmoke { get; set; }
        public string FatherName { get; set; }
        public string FatherProfession { get; set; }
        public string MotherName { get; set; }
        public string MotherProfession { get; set; }
        public string Siblings { get; set; }
        public string PartnerName { get; set; }
        public string PartnerProfession { get; set; }
        public DateTime? PartnerDateOfBirth { get; set; }
        public string Children { get; set; }
        public string Interests { get; set; }
        public string RoleInClub { get; set; }
        public DateTime? StartingWork { get; set; }
        public string Travel { get; set; }
        public string EmergencyRelative { get; set; }
        public int? IsActive { get; set; }
        public string Guid { get; set; }
    }


    public class UserKisiselBilgiler
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("token")]
        public string token { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("UserSurname")]
        public string UserSurname { get; set; }
        [JsonPropertyName("DateOfBirth")]
        public string? DateOfBirth { get; set; }
        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("height")]
        public int height { get; set; }
        [JsonPropertyName("weight")]
        public int weight { get; set; }
        [JsonPropertyName("Nationality")]
        public string? Nationality { get; set; }
        [JsonPropertyName("MaritalStatus")]
        public string? MaritalStatus { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }

        [JsonPropertyName("HomePhone")]
        public string? HomePhone { get; set; }
        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("TC")]
        public string TC { get; set; }
        [JsonPropertyName("InsuranceStartDate")]
        public string? InsuranceStartDate { get; set; }
        [JsonPropertyName("IsActive")]
        public int? IsActive { get; set; }
        [JsonPropertyName("Guid")]
        public string Guid { get; set; }

    }




    public class UpdateIsActive
    {
        [JsonPropertyName("token")]
        public string token { get; set; }

        [JsonPropertyName("deger")]
        public int deger { get; set; }
    }

    public class GetTokenValue
    {
        [JsonPropertyName("token")]
        public string? token { get; set; }
    }

    public class KisiselBilgilerDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("token")]
        public string token { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("UserSurname")]
        public string UserSurname { get; set; }
        [JsonPropertyName("DateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("height")]
        public int height { get; set; }
        [JsonPropertyName("weight")]
        public int weight { get; set; }
        [JsonPropertyName("Nationality")]
        public string Nationality { get; set; }
        [JsonPropertyName("MaritalStatus")]
        public string MaritalStatus { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("HomePhone")]
        public string? HomePhone { get; set; }
        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("TC")]
        public string TC { get; set; }
        [JsonPropertyName("InsuranceStartDate")]
        public DateTime InsuranceStartDate { get; set; }
    }
}
