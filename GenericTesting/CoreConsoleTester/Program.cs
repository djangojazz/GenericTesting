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
            var permissions = new List<string> { "Login", "ChangeUser", "MoreStuff" };

            //create the token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, "Default"),
                new Claim(JwtRegisteredClaimNames.GivenName, "Default"),
                new Claim(JwtRegisteredClaimNames.Sub, "JetPlannerPro"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, "Admin"),
                new Claim(JwtRegisteredClaimNames.NameId, "111"),
            };
            
            permissions.ForEach(x => claims.Add(new Claim(JwtRegisteredClaimNames.Prn, x)));

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
                
                Console.WriteLine();
                var company = claims.SingleOrDefault(x => x.Type == "family_name")?.Value ?? string.Empty;
                var department = claims.SingleOrDefault(x => x.Type == "given_name")?.Value ?? string.Empty;
                var application = claims.SingleOrDefault(x => x.Type == "sub")?.Value ?? string.Empty;
                var userName = claims.SingleOrDefault(x => x.Type == "unique_name")?.Value ?? string.Empty;
                var userId = claims.SingleOrDefault(x => x.Type == "nameid")?.Value ?? string.Empty;
                var permissions = claims.Where(x => x.Type == "prn").ToList();
                
                Console.WriteLine($"Company: {company}   Department: {department}   Application: {application} User: {userName}  UserId: {userId}");
                permissions.ForEach(x => Console.WriteLine(x.Value));
            }
            catch (Exception ex)
            {
                throw;
            }

            
            

            Console.ReadLine();
        }
    }
}
