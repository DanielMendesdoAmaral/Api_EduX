using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_Api_EFcore.Repositories;
using Edux_API_EFcore.Auxiliar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux_Api_EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }


        /// <summary>
        /// Mostra todas as Turmas cadastradas
        /// </summary>
        /// <returns>Lista com todas as Turmas</returns>
        // GET: api/<TurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turmas = _turmaRepository.Listar();
                var qtdTurmas = turmas.Count;

                if (qtdTurmas == 0)
                    return NoContent();

                return Ok(turmas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Mostra uma única Turma especificado pelo seu ID
        /// </summary>
        /// <param name="id">ID da Turma</param>
        /// <returns>Uma Turma</returns>
        // GET api/<TurmaController>/buscar/id/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var turma = _turmaRepository.BuscarPorId(id);

                if (turma == null)
                    return NotFound();

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com.");
            }
        }


        /// <summary>
        /// Mostra um único Objetivo especificado pelo seu NOME
        /// </summary>
        /// <param name="nome">Objeto nome</param>
        /// <returns>Uma Turma</returns>
        // GET: api/<TurmaController>/buscar/nome/1DT
        [Authorize]
        [HttpGet("buscar/nome/{nome}")]
        public IActionResult Get(string nome)
        {
            try
            {
                var turmas = _turmaRepository.BuscarPorNome(nome);
                var qtdTurmas = turmas.Count;

                if (qtdTurmas == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdTurmas,
                    data = turmas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Cadastra uma nova Turma
        /// </summary>
        /// <param name="turma">Objeto turma</param>
        /// <param name="professores">Objeto professores</param>
        /// <param name="alunos">Objeto alunos</param>
        /// <returns>Turma Cadastrada</returns>
        // POST api/<TurmaController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessoresAlunosTurma professoresAlunosTurma)
        {
            try
            {
                _turmaRepository.Adicionar(professoresAlunosTurma);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        ///  Altera uma determinada Tuma
        /// </summary>
        /// <param name="turma">Objeto turma com as alterações</param>
        /// <param name="professores">Objeto professores com as alterações</param>
        /// <param name="alunos">Objeto alunos com as alterações</param>
        /// <returns>Informações alteradas da Turma</returns>
        // PUT api/<TurmaController>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProfessoresAlunosTurma professoresAlunosTurma) 
        {
            try
            {
                _turmaRepository.Editar(id, professoresAlunosTurma);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Excluí uma determinada Turma
        /// </summary>
        /// <param name="id">ID da Turma</param>
        /// <returns>ID excluído</returns>
        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _turmaRepository.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }
    }
}
