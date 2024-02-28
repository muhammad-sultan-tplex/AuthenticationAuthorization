using AuthenticationAuthorization.Authentication;
using AuthenticationAuthorization.Dtos;
using AuthenticationAuthorization.Generics;
using AuthenticationAuthorization.Models;
using AuthenticationAuthorization.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RolesController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IMapper _mapper; 

        public RolesController(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IMapper mapper) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int PageNumber, int PageSize)
        {
            var roles = await _roleManager.Roles.ToListAsync();

            List<RoleDto> userRoles = _mapper.Map<List<RoleDto>>(roles);

            var result = Pagination<RoleDto>.ToPagedList(userRoles, PageNumber, PageSize);

            return Ok(new ResponseModel<RoleDto> { Result = result });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] string Name)
        {
            await _roleManager.CreateAsync(new IdentityRole(Name));

            return Ok(new ResponseModel { Status = "Success", Message = "Role Created successfully!" });
        }
    }
}
