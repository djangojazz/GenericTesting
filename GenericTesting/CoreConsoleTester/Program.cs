using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CoreConsoleTester
{
    class Program
    {
        private static JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        public static string CreateToken()
        {
            //create the token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, "Default"),
                new Claim(JwtRegisteredClaimNames.GivenName, "Default"),
                new Claim(JwtRegisteredClaimNames.Sub, "JetPlannerPro"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, "Admin"),
                new Claim(JwtRegisteredClaimNames.NameId, "111"),
                new Claim(JwtRegisteredClaimNames.Prn, "Login"),
                new Claim(JwtRegisteredClaimNames.Prn, "ChangeUsers"),
                new Claim(JwtRegisteredClaimNames.Prn, "MoreStuff"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RunRabb!tRunD!gThatHol3Forg3tTheSun"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                "http://localhost:9122",
                "users",
                claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds);

            return _handler.WriteToken(token);
        }

        static void Main(string[] args)
        {
            var stringToken = CreateToken();
            //var parts = stringToken.Split('.');
            //var base64String = parts[1];

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKeys = new[] { new SymmetricSecurityKey(Encoding.ASCII.GetBytes("RunRabb!tRunD!gThatHol3Forg3tTheSun")) }
            };

            try
            {
                _handler.ValidateToken(stringToken, validationParameters, out SecurityToken token);
                var claims = ((JwtSecurityToken)token).Claims;

                string s = String.Empty;

                claims.ToList().ForEach(x => s += $"{x.Type} {x.Value} {Environment.NewLine}");
                Console.WriteLine(s);

                //int mod4 = base64String.Length % 4;
                //if (mod4 > 0)
                //{
                //    base64String += new string('=', 4 - mod4);
                //}

                //var decoded = Convert.FromBase64String(base64String);

                //var part = Encoding.UTF8.GetString(decoded);
                //var jwt = JObject.Parse(part);
                

                //var company = jwt.SelectToken("family_name[0]").Value<string>();
                //var department = jwt.SelectToken("family_name[1]").Value<string>();
                //var application = jwt.SelectToken("given_name").Value<string>();
                //var userName = jwt.SelectToken("unique_name").Value<string>();
                //var userId = jwt.SelectToken("nameid").Value<string>();

                //Console.WriteLine($"Company: {company}   Department: {department}   Application: {application} User: {userName}  UserId: {userId}");
            }
            catch (Exception ex)
            {
                throw;
            }

            
            

            Console.ReadLine();
        }
    }
}
