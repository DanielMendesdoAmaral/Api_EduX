using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly EduxContext _ctx;

        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura
        public List<Perfil> Mostrar()
        {
            try
            {

                return _ctx.Perfis.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Perfis.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        #endregion

        #region Gravação
        public void Adicionar(Perfil p)
        {
            try
            {

                _ctx.Perfis.Add(p);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, Perfil p)
        {
            try
            {

                Perfil perfilTemp = _ctx.Perfis.Find(id);
                if (perfilTemp == null)
                {
                    throw new Exception("Perfil não encontrado.");
                }
                perfilTemp.Permissao = p.Permissao;

                _ctx.Perfis.Update(perfilTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Remover(Guid id)
        {
            try
            {

                Perfil perfilTemp = BuscarPorId(id);
                if (perfilTemp == null)
                {
                    throw new Exception("Perfil não encontrado.");
                }

                _ctx.Perfis.Remove(perfilTemp);
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
