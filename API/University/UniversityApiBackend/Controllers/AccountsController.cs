using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.DataModels;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;

        public AccountsController(JwtSettings jwtSettings, UniversityDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        // Usuarios de ejemplo
        // TODO: Cambiar por usuarios reales


        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "david@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "felipe@gmail.com",
                Name = "User1",
                Password = "User1"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                 select user).FirstOrDefault();

                Console.WriteLine($"Usuario encontrado {searchUser}");

                // var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                
                if (searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        Id = searchUser.Id,
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Credenciales inválidas");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Se obtuvo un error de token", ex);
            }
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }

}
