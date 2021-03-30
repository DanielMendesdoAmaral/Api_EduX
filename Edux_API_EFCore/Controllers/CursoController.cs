using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_Api_EFcore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux_Api_EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        /// <summary>
        /// Mostra todos os Cursos cadastradas
        /// </summary>
        /// <returns>Lista com todos os Cursos</returns>
        // GET: api/<CursoController>
        [HttpGet]
        public IActionResult GetCurso()
        {
            try
            {
                var cursos = _cursoRepository.Listar();
                var qtdCursos = cursos.Count;

                if (qtdCursos == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdCursos,
                    data = cursos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Mostra um único Curso especificado pelo seu ID
        /// </summary>
        /// <param name="id">ID do Curso</param>
        /// <returns>Um Curso</returns>
        // GET api/<CursoController>/buscar/id/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpGet("buscar/id/{id}")]
        public IActionResult GetCurso(Guid id)
        {
            try
            {
                var curso = _cursoRepository.BuscarPorId(id);

                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com.");
            }
        }


        /// <summary>
        ///  Mostra um único Curso especificado pelo seu TITULO
        /// </summary>
        /// <param name="titulo">Objeto Titulo</param>
        /// <returns>Um Curso</returns>
        // GET api/<CursoController>/buscar/titulo/DesenvolvimentoDeSistemas
        [Authorize]
        [HttpGet("buscar/titulo/{titulo}")]
        public IActionResult GetCurso(string titulo)
        {
            try
            {
                var cursos = _cursoRepository.BuscarPorTitulo(titulo);
                var qtdCursos = cursos.Count;

                if (qtdCursos == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdCursos,
                    data = cursos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Cadastra um novo Curso
        /// </summary>
        /// <param name="curso">Objeto Curso</param>
        /// <returns>Curso Cadastrado</returns>
        // POST api/<CursoController>
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPost]
        public IActionResult PostCurso([FromBody] Curso curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }



        /// <summary>
        /// Altera um determinado Curso
        /// </summary>
        /// <param name="curso">Objeto curso com as alterações</param>
        /// <returns>Informações alteradas do Curso </returns>
        // PUT api/<CursoController>
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPut("{id}")]
        public IActionResult PutCurso(Guid id, [FromBody] Curso curso)
        {
            try
            {
                _cursoRepository.Editar(id, curso);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }


        /// <summary>
        /// Excluí um determinado Curso
        /// </summary>
        /// <param name="id">ID do Curso</param>
        /// <returns>ID excluído</returns>
        // DELETE api/<CursoController>/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCurso(Guid id)
        {
            try
            {
                _cursoRepository.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". Envie um email para a nossa equipe de suporte: edux.suport@gmail.com");
            }
        }
    }
}