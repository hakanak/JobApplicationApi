namespace JobApplicationApi.Model
{
    public class AccessToken
    {
        public string accessToken { get; set; }
        public DateTime Expiration { get; set; }
        public UserDto user { get; set; }
        //public List<UserCharmsDATA> charms { get; set; }
        //public List<UserPermsDATA> perms { get; set; }
        public bool Successful { get; set; }
    }
    public class UserDto
    {
        public string name { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string durum { get; set; }
        public bool issuccesfull { get; set; }
    }
    public class TokenData
    {
        public string token { get; set; }
        public UserDto user { get; set; }
        public bool successful { get; set; }
    }
}
