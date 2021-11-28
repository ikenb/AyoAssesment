using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ConvertMetricUnits.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;
        private readonly IDistributedCache _cache;
        private readonly JWTSettings _jwtSettings;
        public UserRepository(IConfiguration configuration, IDistributedCache cache, IOptions<JWTSettings> appsettings)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _cache = cache;
        }
        public User Authenticate(string userName, string password)
        {
            var parameter = DapperParameter.BuildDapperGetUserParameters(userName);
            var user = _db.Query<User>("GetUserByUserName", parameter, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials
                                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = string.Empty;

            return user;
        }

     
        public User Register(string username, string password, string role)
        {
            var encryptedpassword = EncryptPassword(password);

            var parameter = DapperParameter.BuildDapperSaveUserParameters(username, encryptedpassword, role);

            var result = _db.Execute("SaveUser", parameter, commandType: CommandType.StoredProcedure);

            var user = new User()
            {
                Username = username,
                Role = role
            };

            return (result > 0)? user : new User();

        }

        public bool IsUniqueUser(string username)
        {
            var parameter = DapperParameter.BuildDapperGetUserParameters(username);

            var user = _db.Query<User>("GetUserByUserName", parameter, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();


            if (user == null)
                return true;

            return false;
        }

        public string EncryptPassword(string password)
        {
            MD5 md5 = MD5.Create();
      
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder sb = new StringBuilder();
           
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
