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
    public class UserTypesController : ControllerBase
    {
        private IUserTypeRepository _typeRepository { get; set; }
        public UserTypesController(IUserTypeRepository repo)
        {
            _typeRepository = repo;
        }

        /// <summary>
        /// List all user types
        /// </summary>

        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_typeRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a user type by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idType}")]
        public IActionResult SearchId(int idType)
        {
            try
            {
                return Ok(_typeRepository.SearchType(idType));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Posts a new user type
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpPost]
        public IActionResult Post(UserType type)
        {
            try
            {
                _typeRepository.PostType(type);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates the infos about a user type
        /// </summary>

        //[Authorize]
        [HttpPut("{idType}")]
        public IActionResult Put(int idType, UserType type)
        {
            try
            {
                _typeRepository.UpdateTypeId(idType, type);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deletes a user type
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idType}")]
        public IActionResult Delete(int idType)
        {
            try
            {
                _typeRepository.DeleteType(idType);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

    }
}
