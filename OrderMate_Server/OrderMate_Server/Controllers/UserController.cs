using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderMate_Server.Resources;

namespace OrderMate_Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;


        public object Configuration { get; private set; }

        private UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;


        public UserController(
            IConfiguration configuration,
            ILoggerManager logger,
            IRepositoryWrapper repository,
            IMapper mapper, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,

            SignInManager<User> signInManager)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user != null && (await _userManager.CheckPasswordAsync(user, model.password)))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Username, model.password, false, false);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var firstRole = roles.FirstOrDefault();

                        if (firstRole == null)
                        {
                            firstRole = "No role";
                        }
                        var token = GenerateJwtToken(user, firstRole);
                        return Ok(new { token });
                    }
                }
                message = "invalid username and/or password";
                return BadRequest(new { message });
            }
            return BadRequest();
        }


  
        [HttpGet]
        public IActionResult GetAllUsersAsync()
        {
            try
            {

                var users = _repository.User.GetAllUsers();
                _logger.LogInfo($"Returned all users from db.");

                // var usersResult = _mapper.Map<IEnumerable<User>>(users);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllUsers action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUserById(string id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);

                if (user == null)
                {
                    _logger.LogError($"user with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned user with id: {id}");

                    var userResult = _mapper.Map<User>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetUserWithDetails(string id)
        {
            try
            {
                var user = _repository.User.GetUserWithDetails(id);

                if (user == null)
                {
                    _logger.LogError($"user with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"user with details for id: {id}");

                    var userResult = _mapper.Map<User>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserResource model)
        {
           
            try
            {
                if (model == null)
                {
                    _logger.LogError("user object sent from client is null.");
                    return BadRequest("user object is null");

                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var appuser = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    User_Contact_Number = model.User_Contact_Number,
                    PhoneNumber = model.User_Contact_Number,
                    User_Name = model.User_Name,
                    User_Surname = model.User_Surname,
                

                };

                var result = await _userManager.CreateAsync(appuser, model.Password);

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(model.UserRoleIdFk);
                    var roleresult = await _userManager.AddToRoleAsync(appuser, role.Name);

                    
                }

                return Ok(result);



            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.InnerException.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] UserForUpdateDto user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogError("user object sent from client is null.");
                    return BadRequest("user object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var userEntity = _repository.User.GetUserById(id);
                if (userEntity == null)
                {
                    _logger.LogError($"user with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(user, userEntity);

                _repository.User.UpdateUser(userEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);
                if (user == null)
                {
                    _logger.LogError($"user with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.User.DeleteUser(user);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        //Helper methods
        private object GenerateJwtToken(User user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("userName",user.UserName),
                new Claim("userRole",role), //it will return only the first role
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("profile/{userName}")]
        public async Task<object> GetUserProfile(string userName)
        {
            //return "user profile";

            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);


            var userDetails = new
            {
                name = user.User_Name,
                userName = user.UserName,
                Roles = userRoles
            };

            return userDetails;

            
        }



    }
}
