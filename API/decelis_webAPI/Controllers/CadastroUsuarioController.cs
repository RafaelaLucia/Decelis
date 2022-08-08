using decelis_webAPI.Contexts;
using System.IO;
using decelis_webAPI.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using decelis_webAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroUsuarioController : ControllerBase
    {
        private readonly DecelisContext _context;
        public CadastroUsuarioController(DecelisContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Posts a new user
        /// </summary>

        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUser([FromForm] UserInfo usuario, IFormFile arquivo)
        {

            #region Upload da Imagem com extensões permitidas apenas
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);
            
            
            if (usuario.UserImage == null)
            {
                usuario.UserImage = Path.Combine("StaticFiles", "Images", "padrao.png");
            }


            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            usuario.UserImage = uploadResultado;
            #endregion
            _context.UserInfos.Add(usuario);
           
            await _context.SaveChangesAsync();

            return Created("Usuario", usuario);
        }

        /// <summary>
        /// Updates the infos about a user
        /// </summary>

        [HttpPut]
        public async Task<ActionResult<UserInfo>> PostUser([FromForm] UserInfo usuarioAtualizado, IFormFile arquivo, Guid id)
        {
            if (id != usuarioAtualizado.IdUser)
            {
                return BadRequest();
            }

            try
            {
                #region 
                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                usuarioAtualizado.UserImage = uploadResultado;
                #endregion

                _context.Entry(usuarioAtualizado).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.UserInfos.Any(e => e.IdUser == id);
        }
    }
}
