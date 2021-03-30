using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
   
    public class CurtidaRepository : ICurtidaRepository 
    {
        private readonly EduxContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        public List<Curtida> Mostrar()
        {
            try
            {

                return _ctx.Curtidas.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public Curtida BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Curtidas.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


        #region Gravação

        public Curtida Adicionar(Curtida curtida)
        {
            try
            {

                _ctx.Curtidas.Add(curtida);

                _ctx.SaveChanges();

                return curtida;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, Curtida curtida)
        {
            try
            {
                Curtida curtidaAlterado = BuscarPorId(id);

                if (curtidaAlterado == null)
                    throw new Exception("Curtida não encontrada");
             
 
                curtidaAlterado.IdUsuario = curtida.IdUsuario;
                curtidaAlterado.IdDica = curtida.IdDica;


                _ctx.Curtidas.Update(curtidaAlterado);

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
                Curtida curtidaExcluido = BuscarPorId(Id);

                if (curtidaExcluido == null)
                    throw new Exception("Impossível excluir a Curtida desejada.");

                _ctx.Curtidas.Remove(curtidaExcluido);
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
