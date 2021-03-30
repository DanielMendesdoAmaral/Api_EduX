using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_Api_EFcore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux_Api_EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAlunoRepository _objetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            _objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }


        /// <summary>
        /// Lista com todos os Objetivos
        /// </summary>
        /// <returns>Mostra todos os ObjetivosAlunos cadastradas</returns>
        // GET: api/<ObjetivoAlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var objetivosAlunos = _objetivoAlunoRepository.Buscar();
                var qtdObjetivosAlunos = objetivosAlunos.Count;

                if (qtdObjetivosAlunos == 0)
                    return NoContent();

                return Ok(objetivosAlunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }



        /// <summary>
        /// Mostra um único ObjetivoAluno especificado pelo seu ID
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno</param>
        /// <returns>Um ObjetivoAluno</returns>
        // GET api/<ObjetivoAlunoController>/buscar/id/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var objetivoAluno = _objetivoAlunoRepository.Buscar(id);

                if (objetivoAluno == null)
                    return NotFound();

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com.");
            }
        }


        /// <summary>
        /// Mostra um único ObjetivoAluno especificado pelo seu IDALUNO
        /// </summary>
        /// <param name="idAluno">Objeto idAluno</param>
        /// <returns>Um ObjetivoAluno</returns>
        // GET api/<ObjetivoAlunoController>/buscar/id/5
        [HttpGet("buscar/por_aluno/{idAluno}")]
        public IActionResult GetPorAluno(Guid idAluno)
        {
            try
            {
                var objetivosAlunos = _objetivoAlunoRepository.BuscarPorAluno(idAluno);
                var qtdObjetivosAlunos = objetivosAlunos.Count;

                if (qtdObjetivosAlunos == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdObjetivosAlunos,
                    data = objetivosAlunos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Cadastra um novo ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">Objeto objetivoAluno</param>
        /// <returns>ObejtivoAluno Cadastrado</returns>
        // POST api/<ObjetivoAlunoController>
        [HttpPost]
        public IActionResult Post([FromBody] ObjetivoAluno objetivoAluno)
        {
            try
            {
                _objetivoAlunoRepository.Cadastrar(objetivoAluno);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Altera um determinado ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">Objeto objetivoAluno com as alterações</param>
        /// <returns>Informações alteradas do ObjetivoAluno</returns>
        // PUT api/<ObjetivoAlunoController>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ObjetivoAluno objetivoAluno)
        {
            try
            {
                _objetivoAlunoRepository.Alterar(id, objetivoAluno);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Exclui um determinado ObjetivoAluno
        /// </summary>
        /// <param name="id">Id do ObjetivoAluno a ser excluído</param>
        /// <returns>StatusCodes e </returns>
        // DELETE api/<ObjetivoAlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (_objetivoAlunoRepository.Buscar(id) == null)
                    return NotFound();

                _objetivoAlunoRepository.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }
    }
}