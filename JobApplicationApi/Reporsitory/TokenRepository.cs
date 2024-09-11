using JobApplicationApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobApplicationApi.Reporsitory
{
    public class TokenRepository
    {
        private readonly string _jwtSecret;
        private readonly double _jwtExpirationInMinutes;

        public TokenRepository(string jwtSecret, double jwtExpirationInMinutes)
        {
            _jwtSecret = jwtSecret;
            _jwtExpirationInMinutes = jwtExpirationInMinutes;
        }

        public string CreateAccessToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var claims = new List<Claim>
        {
            //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
            // Burada kullanıcının sahip olabileceği başka iddiaları (claims) ekleyebilirsiniz.
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // Tokenin yayıncısını doğrulama
                ValidateAudience = false, // Tokenin alıcısını doğrulama
                ValidateLifetime = true, // Tokenin süresini doğrulama
                ClockSkew = TimeSpan.Zero // Zaman farkını sıfırlama
            };

            try
            {
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return claimsPrincipal;
            }
            catch (Exception ex)
            {
                // Token geçerli değilse veya doğrulama hatası oluştuysa burada hata işleme kodunu ekleyebilirsiniz.
                // Örneğin, bir hata günlüğüne yazabilir veya istemciye hata mesajı gönderebilirsiniz.
                
                //throw ex;
                ClaimsPrincipal result = null;
                return result;
            }
        }
    }
}
