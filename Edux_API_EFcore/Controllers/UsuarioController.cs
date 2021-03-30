using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Contexts;
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
    public class UsuarioController : ControllerBase
    {
        private readonly EduxContext _ctx;
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Mostra todos os Usuários cadastradas
        /// </summary>
        /// <returns>Lista com todos os Usuários</returns>
        // GET: api/<UsuarioController>
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepository.Mostrar();
                if (usuarios.Count == 0)
                {
                    return NoContent();
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ranking")]
        public IActionResult Rankear()
        {
            try
            {
                var usuario = _ctx.Usuarios.Where(a=>a.AlunosTurmas.Count>0).Include(u => u.AlunosTurmas).ThenInclude(a => a.ObjetivosAlunos).ThenInclude(o=>o.Objetivo).ToList();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Mostra um único Usuário especificado pelo seu ID
        /// </summary>
        /// <param name="id">ID do Usuário</param>
        /// <returns>Um Usuário</returns>
        // GET api/<UsuarioController>/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorId(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Mostra um único Usuário especificado pelo seu NOME
        /// </summary>
        /// <param name="nome">Objeto Nome</param>
        /// <returns>Um Usuário</returns>
        // GET api/<ObjetivoController>/
        [HttpGet("buscar/nome/{nome}")]
        public IActionResult Get(string nome)
        {
            try
            {

                var usuarios = _usuarioRepository.BuscarPorNome(nome);
                var qtdUsuarios = usuarios.Count;

                if (qtdUsuarios == 0)
                {
                    return NoContent();
                }                     

                return Ok(new
                {
                    totalCount = qtdUsuarios,
                    data = usuarios
                });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }


        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuário</param>
        /// <returns>Usuário Cadastrado</returns>
        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Adicionar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Altera um determinado Usuário
        /// </summary>
        /// <param name="usuario">Objeto usuario com as alterações</param>
        /// <returns>Informações alteradas do Usuário</returns>
        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Editar(id, usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Excluí um determinado Usuário
        /// </summary>
        /// <param name="id">ID do Usuário</param>
        /// <returns>ID excluído</returns>
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
