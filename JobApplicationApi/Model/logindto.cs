using System.Text.Json.Serialization;

namespace JobApplicationApi.Model
{
    public class logindto
    {
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
    }
    public class registerdto
    {
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("ad")]
        public string ad { get; set; }
        [JsonPropertyName("soyad")]
        public string soyad { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
    }
}
