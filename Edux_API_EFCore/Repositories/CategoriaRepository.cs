using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly EduxContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura
        public List<Categoria> Listar()
        {
            try
            {

                return _ctx.Categorias.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }


        public Categoria BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Categorias.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Categoria> BuscarPorTipo(string tipo)
        {
            try
            {
                 return _ctx.Categorias.Where(c => c.Tipo.Contains(tipo)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        #endregion


        #region Gravação
        public Categoria Adicionar(Categoria categoria)
        {
            try
            {

                _ctx.Categorias.Add(categoria);

                _ctx.SaveChanges();

                return categoria;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }


        public void Editar(Guid id, Categoria categoria)
        {
            try
            {
                Categoria categoriaAlterada = BuscarPorId(id);

                if (categoria == null)
                    throw new Exception("Impossível alterar Categoria pois faltam dados.");

                categoriaAlterada.Tipo = categoria.Tipo;
           
                _ctx.Categorias.Update(categoriaAlterada);

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
               Categoria categoriaExcluida = BuscarPorId(Id);


                if (categoriaExcluida == null)
                    throw new Exception("Impossível excluir o Categoria desejada pois faltam dados.");

                _ctx.Categorias.Remove(categoriaExcluida);
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
