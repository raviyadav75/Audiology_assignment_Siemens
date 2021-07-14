using JewelryEstimate_Assignment.DTOs;
using JewelryEstimate_Assignment.Entities;
using JewelryEstimate_Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JewelryEstimate_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            AppUser user;
            if (!ModelState.IsValid)
            {
                return BadRequest("Input parameter is wrong");
            }

            try
            {
                user = await _userRepository.GetUserAsync(loginDTO.UserName);
            }
            catch(AggregateException ex)
            {
                //Log exception here
                return StatusCode(500);
            }

            if (user == null)
                return Unauthorized("Invalid User Name");

            if (loginDTO.Password != user.Password)
                return Unauthorized("Invalid Password");

            return new UserDTO() { userName = user.UserName, FirstName = user.FirstName,
                LastName = user.LastName, IsPrivilegdUser = user.IsPrivileged };
            
        }
    }
}
