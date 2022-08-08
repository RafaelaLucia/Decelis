using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using decelis_webAPI.Repositories;
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
    public class ClassesController : ControllerBase
    {
        private IClassRepository _classRepository { get; set; }
        public ClassesController()
        {
            _classRepository = new ClassRepository();
        }

        /// <summary>
        /// List all classes
        /// </summary>
      
        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_classRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a class by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idClass}")]
        public IActionResult SearchId(int idClass)
        {
            try
            {
                return Ok(_classRepository.SearchClass(idClass));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Posts a new class
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpPost]
        public IActionResult Post(Class classe)
        {
            try
            {
                _classRepository.PostClass(classe);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates the infos about a class
        /// </summary>

        //[Authorize]
        [HttpPut("{idClass}")]
        public IActionResult Put(int idClass, Class classe)
        {
            try
            {
                _classRepository.UpdateClassId(idClass, classe);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deletes a class
        /// </summary>
        
        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idClass}")]
        public IActionResult Delete(int idClass)
        {
            try
            {
                _classRepository.DeleteClass(idClass);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
