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
    public class SkillLevelsController : ControllerBase
    {
        private ISkillLevelRepository _skillRepository { get; set; }
        public SkillLevelsController(ISkillLevelRepository repo)
        {
            _skillRepository = repo;
        }

        /// <summary>
        /// List all levels
        /// </summary>

        // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_skillRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Search for a level by its id
        /// </summary>

        // [Authorize]
        [HttpGet("{idLevel}")]
        public IActionResult SearchId(int idLevel)
        {
            try
            {
                return Ok(_skillRepository.SearchSkill(idLevel));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Posts a new level
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpPost]
        public IActionResult Post(SkillLevel level)
        {
            try
            {
                _skillRepository.PostSkill(level);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates the infos about a level
        /// </summary>

        //[Authorize]
        [HttpPut("{idLevel}")]
        public IActionResult Put(int idLevel, SkillLevel level)
        {
            try
            {
                _skillRepository.UpdateSkillId(idLevel, level);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deletes a level
        /// </summary>

        //[Authorize(Roles = "1,3")]
        [HttpDelete("{idLevel}")]
        public IActionResult Delete(int idLevel)
        {
            try
            {
                _skillRepository.DeleteSkill(idLevel);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }

    }
}
