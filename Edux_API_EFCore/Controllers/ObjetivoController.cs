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
    public class ObjetivoController : ControllerBase
    {

        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivoController()
        {

            _objetivoRepository = new ObjetivoRepository();

        }


        /// <summary>
        /// Mostra todos os Objetivos cadastradas
        /// </summary>
        /// <returns>Lista com todos os Objetivos</returns>
        // GET: api/<ObjetivoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var objetivos = _objetivoRepository.Listar();
                var qtdObjetivos = objetivos.Count;

                if (qtdObjetivos == 0)
                    return NoContent();

                return Ok(objetivos);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }
        }


        /// <summary>
        /// Mostra um único Objetivo especificado pelo seu ID
        /// </summary>
        /// <param name="Id">ID do Objetivo</param>
        /// <returns>Um Objetivo</returns>
        // GET api/<ObjetivoController>/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                var objetivo = _objetivoRepository.BuscarPorId(Id);

                if (objetivo == null)
                    return NotFound();

                return Ok(objetivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }
        }


        /// <summary>
        /// Mostra um único Objetivo especificado pelo seu TERMO
        /// </summary>
        /// <param name="termo">Objeto Termo</param>
        /// <returns>Um Objetivo</returns>
        // GET api/<ObjetivoController>/
        [HttpGet("buscar/termo/{termo}")]
        public IActionResult Get(string termo)
        {

            try
            {

                var objetivos = _objetivoRepository.BuscarPorTermo(termo);
                var qtdObjetivos = objetivos.Count;

                if (qtdObjetivos == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = qtdObjetivos,
                    data = objetivos
                });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }

        }


        /// <summary>
        ///  Cadastra um novo Objetivo
        /// </summary>
        /// <param name="objetivo">Objeto objetivo</param>
        /// <returns>Obejtivo Cadastrado</returns>
        // POST api/<ObjetivoController>
        [HttpPost]
        public IActionResult Post([FromBody] Objetivo objetivo)
        {

            try
            {

                objetivo = _objetivoRepository.Adicionar(objetivo);
                return Ok(objetivo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");


            }

        }


        /// <summary>
        /// Altera um determinado Objetivo
        /// </summary>
        /// <param name="objetivo">Objeto objetivo com as alterações</param>
        /// <returns>Informações alteradas do Objetivo</returns>
        // PUT api/<ObjetivoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Objetivo objetivo)
        {

            try
            {
                _objetivoRepository.Editar(id, objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }

        }


        /// <summary>
        /// Excluí um determinado Objetivo
        /// </summary>
        /// <param name="Id">ID do Objetivo</param>
        /// <returns>ID excluído</returns>
        // DELETE api/<ObjetivoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {

            try
            {
                _objetivoRepository.Remover(Id);


                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + ". contate nossa equipe de suporte para solucionarmos o erro presente nesta página email : edux.suporte@gmail.com, telefone : (11)31212121");

            }

        }


    }
}
