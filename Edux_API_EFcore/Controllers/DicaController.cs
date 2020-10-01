using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_Api_EFcore.Repositories;
using Edux_Api_EFcore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux_Api_EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly IDicaRepository _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        /// <summary>
        /// Mostra todas as Dicas cadastradas
        /// </summary>
        /// <returns>Lista com todos as Dicas</returns>
        // GET: api/<DicaController>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.Buscar();
                var qtdDicas = dicas.Count;

                if (qtdDicas == 0)
                    return NoContent(); 

                return Ok(new
                { 
                    totalCount = qtdDicas, 
                    data = dicas
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Mostra uma única Dica especificado pelo seu ID
        /// </summary>
        /// <param name="id">ID da Dica</param>
        /// <returns>Uma Dica</returns>
        // GET api/<DicaController>/buscar/id/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var dica = _dicaRepository.Buscar(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com.");
            }
        }


        /// <summary>
        /// Mostra uma única Categoria especificado por uma PALAVRA CHAVE
        /// </summary>
        /// <param name="palavraChave">Objeto palavraChave</param>
        /// <returns>Uma Dica</returns>
        // GET: api/<DicaController>/buscar/termo/desenvolvimento
        [Authorize]
        [HttpGet("buscar/palavra_chave/{palavraChave}")]
        public IActionResult Get(string palavraChave)
        {
            try
            {
                var dicas = _dicaRepository.Buscar(palavraChave);
                var qtdDicas = dicas.Count;

                if (qtdDicas == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdDicas,
                    data = dicas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Cadastra uma nova Dica
        /// </summary>
        /// <param name="dica">Objeto Dica</param>
        /// <returns>Categoria Dica</returns>
        // POST api/<DicaController>
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPost]
        public IActionResult Post([FromForm] Dica dica)
        {
            try
            {
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);
                    dica.UrlImagem = urlImagem;
                }

                _dicaRepository.Criar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Altera uma determinada Dica
        /// </summary>
        /// <param name="dica">Objeto Dica com as alterações</param>
        /// <returns>Informações alterada da Dica </returns>
        // PUT api/<DicaController>
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Dica dica)
        {
            try
            {
                _dicaRepository.Editar(id, dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }

        /// <summary>
        /// Excluí uma determinada Dica
        /// </summary>
        /// <param name="id">ID da Dica</param>
        /// <returns>ID Excluído</returns>
        // DELETE api/<DicaController>/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var dica = _dicaRepository.Buscar(id);

                if (dica == null)
                    return NotFound();

                _dicaRepository.Excluir(id);
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
           }
        }
    }
}