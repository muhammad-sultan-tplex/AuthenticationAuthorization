using AuthenticationAuthorization.Authentication;
using AuthenticationAuthorization.Dtos;
using AuthenticationAuthorization.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using AuthenticationAuthorization.Generics;
using AuthenticationAuthorization.Repository;

namespace AuthenticationAuthorization.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IMapper _mapper;
        public readonly IUserRepository _IUserRepository;

        public UsersController(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IMapper mapper
            , IUserRepository IUserRepository) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _IUserRepository = IUserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int PageNumber, int PageSize)
        {
            var ss = _IUserRepository.Name;
            var users = await _userManager.Users.Include(r => r.Role).ToListAsync();

            List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);

            var result = Pagination<UserDto>.ToPagedList(usersDto, PageNumber, PageSize);

            return Ok(new ResponseModel<UserDto> { Result = result });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserDto userModel) 
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleId = await _roleManager.FindByNameAsync(userModel.RoleName);

            if (roleId == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "Role does not exists." });

            user.Role = roleId;
            await _userManager.CreateAsync(user, userModel.Password);

            return Ok(new ResponseModel { Status = "Success", Message = "User Added successfully!" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string userId) 
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            await _userManager.DeleteAsync(user);

            return Ok(new ResponseModel { Status = "Success", Message = "User Deleted successfully!" });
        }
    }
}
