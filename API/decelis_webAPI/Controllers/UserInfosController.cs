using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private IUserInfoRepository _userRepository { get; set; }
        public UserInfosController(IUserInfoRepository repo)
        {
            _userRepository = repo;
        }

        /// <summary>
        /// List all users
        /// </summary>

        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a user by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idUser}")]
        public IActionResult SearchId(Guid idUser)
        {
            try
            {
                return Ok(_userRepository.SearchUser(idUser));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //[Authorize(Roles = "1,3")]
     /*   [HttpPost]
        public IActionResult Post(UserInfo user)
        {
            try
            {
                _userRepository.PostUser(user);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }*/

    
        //[Authorize]
       /* [HttpPut("{idUser}")]
        public IActionResult Put(Guid idUser, UserInfo user)
        {
            try
            {
                _userRepository.UpdateUserId(idUser, user);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }*/

        /// <summary>
        /// Deletes a user
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idUser}")]
        public IActionResult Delete(Guid idUser)
        {
            try
            {
                _userRepository.DeleteUser(idUser);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
