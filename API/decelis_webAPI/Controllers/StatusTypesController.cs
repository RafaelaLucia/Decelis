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
    public class StatusTypesController : ControllerBase
    {
        private IStatusTypeRepository _statusRepository { get; set; }
        public StatusTypesController(IStatusTypeRepository repo)
        {
            _statusRepository = repo;
        }

        /// <summary>
        /// List all status
        /// </summary>

        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_statusRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a status by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idStatus}")]
        public IActionResult SearchId(int idStatus)
        {
            try
            {
                return Ok(_statusRepository.SearchStatus(idStatus));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Posts a new status
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpPost]
        public IActionResult Post(StatusType status)
        {
            try
            {
                _statusRepository.PostStatus(status);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deletes a status
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idStatus}")]
        public IActionResult Delete(int idStatus)
        {
            try
            {
                _statusRepository.DeleteStatus(idStatus);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
