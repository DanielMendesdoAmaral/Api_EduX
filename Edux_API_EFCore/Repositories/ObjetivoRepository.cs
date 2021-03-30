using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edux_Api_EFcore.Repositories
{
    
    
    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly EduxContext _ctx;

        public ObjetivoRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        public List<Objetivo> Listar()
        {
            try
            {

                return _ctx.Objetivos.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public Objetivo BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Objetivos.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Objetivo> BuscarPorTermo(string termo)
        {
            try
            {

                return _ctx.Objetivos.Where(o => o.Descricao.Contains(termo)).ToList();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        #endregion


        #region Gravação

        public Objetivo Adicionar(Objetivo objetivo)
        {
            try
            {

                _ctx.Objetivos.Add(objetivo);

                _ctx.SaveChanges();

                return objetivo;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, Objetivo objetivo)
        {
            try
            {
                Objetivo objetivoAlterado = BuscarPorId(id);

                if (objetivo == null)
                    throw new Exception("Impossível alterar Objetivo pois faltam dados.");

                objetivoAlterado.Descricao = objetivo.Descricao;
                objetivoAlterado.IdCategoria = objetivo.IdCategoria;


                _ctx.Objetivos.Update(objetivoAlterado);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid Id)
        {
            try
            {
                Objetivo objetivoExcluido = BuscarPorId(Id);

                if (objetivoExcluido == null)
                    throw new Exception("Impossível excluir o Objetivo desejado pois faltam dados.");

                _ctx.Objetivos.Remove(objetivoExcluido);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
