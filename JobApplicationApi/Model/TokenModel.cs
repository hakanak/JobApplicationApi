using System.Text.Json.Serialization;

namespace JobApplicationApi.Model
{
    public class TokenModel
    {
        [JsonPropertyName("AccessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("Expiration")]
        public string Expiration { get; set; }

        [JsonPropertyName("Successful")]
        public bool Successful { get; set; }

        [JsonPropertyName("User")]
        public UserModel User { get; set; }
    }

    public class UserModel
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Ename")]
        public string Ename { get; set; }

        [JsonPropertyName("Lang")]
        public string Lang { get; set; }
    }

   
}
