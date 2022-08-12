using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using IDOApplication.Models;
using IDOApplication.Api.Repository;
using IDOApplication.Api.Models;

namespace IDOApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpPost("/api/User/login")]
        public async Task<ActionResult> Login(UserDtoLogin user)
        {
            try
            {
                var userLogin = await userRepository.GetUser(user.Email, user.Password);

                if (userLogin == null)
                {
                    return Unauthorized($"Invalid User");
                }

                return Ok("User is Valid");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePassword(UserDtoUpdate user)
        {

            try
            {
                var userLogin = await userRepository.GetUser(user.Email, user.OldPassword);

                if (userLogin == null)
                {
                    return Unauthorized($"Invalid User");
                }
                if (user.NewPassword.ToString() != user.ComfirmPassword.ToString())
                {
                    return BadRequest();
                }
                try
                {
                    await userRepository.updatePassword(user.Email, user.OldPassword, user.NewPassword);
                    return Ok("password updated successfully");
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error");
                }

                //return Ok("User is Valid");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error");
            }
        
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserDtoAdd user)
        {

            try
            {
                var email = await userRepository.getUserByEmail(user.Email);
                if (email != null)
                {
                    return Conflict("Email already exists");
                }
                if (user.Password.ToString() != user.ComfirmPassword.ToString())
                {
                    return BadRequest();
                }
                await userRepository.addUser(user.Email,user.Password);
                return Ok("user added successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }

        }

        [HttpPost("/api/User/get")]
        public async Task<ActionResult> GetId(UserDtoGet user)
        {
            try
            {
                var userId = await userRepository.GetId(user.Email);

                if (userId == null)
                {
                    return NotFound($"Invalid User");
                }

                return Ok(userId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error");
            }
        }





    }
}
