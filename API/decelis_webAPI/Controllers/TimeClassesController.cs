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
    public class TimeClassesController : ControllerBase
    {
        private ITimeClassRepository _timeRepository { get; set; }
        public TimeClassesController(ITimeClassRepository repo)
        {
            _timeRepository = repo;
        }

        /// <summary>
        /// List all periods
        /// </summary>

        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_timeRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a period by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idTime}")]
        public IActionResult SearchId(int idTime)
        {
            try
            {
                return Ok(_timeRepository.SearchTime(idTime));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Posts a new period
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpPost]
        public IActionResult Post(TimeClass time)
        {
            try
            {
                _timeRepository.PostTime(time);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates the infos about a period
        /// </summary>

        //[Authorize]
        [HttpPut("{idTime}")]
        public IActionResult Put(int idTime, TimeClass time)
        {
            try
            {
                _timeRepository.UpdateTimeId(idTime, time);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deletes a period
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idTime}")]
        public IActionResult Delete(int idTime)
        {
            try
            {
                _timeRepository.DeleteTime(idTime);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
