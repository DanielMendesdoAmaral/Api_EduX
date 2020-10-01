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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edux_Api_EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriaController : ControllerBase
    {
       

        private readonly ICategoriaRepository _categoriaRepository;
        
        public CategoriaController()
        {

            _categoriaRepository = new CategoriaRepository();

        }

        /// <summary>
        /// Mostra todas as Categorias cadastradas
        /// </summary>
        /// <returns>Lista com todos os produtos</returns>
        // GET: api/<CategoriaController>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
       
            try
            {
                             
                var categorias = _categoriaRepository.Listar();
                var qtdCategorias = categorias.Count;

                if (qtdCategorias == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdCategorias,
                    data = categorias
                }) ;


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }
        }



        /// <summary>
        /// Mostra uma única Categoria especificado pelo seu ID
        /// </summary>
        /// <param name="Id">ID da Categoria</param>
        /// <returns>Uma Categoria</returns>
        // GET api/<CategoriaController>/listar/id = 2
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                var categoria = _categoriaRepository.BuscarPorId(Id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }


        }


       
        /// <summary>
        /// Mostra uma única Categoria especificado pelo seu TIPO
        /// </summary>
        /// <param name="tipo">Objeto Tipo</param>
        /// <returns>Uma Categoria</returns>
        // GET api/<CategoriaController>/listar/tipo = critico
        [Authorize]
        [HttpGet("buscar/categoria/{categoria}")]
        public IActionResult Get(string tipo)
        {

            try
            {

                var categorias = _categoriaRepository.BuscarPorTipo(tipo);
                var qtdCategorias = categorias.Count;

                if (qtdCategorias == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdCategorias,
                    data = categorias
                });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }

        }



        /// <summary>
        /// Cadastra uma nova Categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
        /// <returns>Categoria cadastrada</returns>
        // POST api/<CategoriaController>
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {

            try
            {
                   
                categoria = _categoriaRepository.Adicionar(categoria);
                return Ok(categoria);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");


            }


        }



        /// <summary>
        /// Altera uma determinada Categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria com as alterações</param>
        /// <returns>Informações alterada da Categoria </returns>
        // PUT api/<CategoriaController>/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            try
            {
                _categoriaRepository.Editar(id, categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }


        }


        /// <summary>
        /// Excluí uma determinada Categoria
        /// </summary>
        /// <param name="Id">ID da Categoria</param>
        /// <returns>ID excluído</returns>
        // DELETE api/<CategoriaController>/5
        [Authorize(Roles = "Professor, Instituicao, Instituição")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {

            try
            {
                _categoriaRepository.Remover(Id);


                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }

        }

    }
}
