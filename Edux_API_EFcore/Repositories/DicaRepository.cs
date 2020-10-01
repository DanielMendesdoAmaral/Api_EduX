//DANIEL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edux_Api_EFcore.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        private readonly EduxContext _ctx;

        public DicaRepository()
        {
            _ctx = new EduxContext();
        }
     
        public List<Dica> Buscar()
        {
            try
            {
                return _ctx.Dicas
                    .Include(d => d.Usuario)
                    .Include(d => d.Curtidas)
                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dica Buscar(Guid id)
        {
            try
            {
                return _ctx.Dicas
                    .Include(d => d.Usuario)
                    .Include(d => d.Curtidas)
                    .FirstOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Dica> Buscar(string palavraChave)
        {
            try
            {
                var dicasTermo = _ctx.Dicas.Where(d => d.Texto.Contains(palavraChave))
                    .Include(d => d.Usuario)
                    .Include(d => d.Curtidas)
                    .ToList();
                dicasTermo.AddRange(_ctx.Dicas.Where(d => d.Usuario.Nome.Contains(palavraChave))
                    .Include(d => d.Usuario)
                    .Include(d => d.Curtidas)
                    .ToList());
                return dicasTermo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Criar(Dica dica)
        {
            try
            {
                _ctx.Dicas.Add(dica);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Guid id, Dica dicaEditada)
        {
            try
            {
                Dica dicaAlterada = Buscar(id);

                if (dicaEditada == null)
                    throw new Exception("Impossível incluir a edição do post pois faltam dados.");

                dicaAlterada.Curtidas = dicaEditada.Curtidas;
                dicaAlterada.IdUsuario = dicaEditada.IdUsuario;
                dicaAlterada.Imagem = dicaEditada.Imagem;
                dicaAlterada.Texto = dicaEditada.Texto;
                dicaAlterada.UrlImagem = dicaEditada.UrlImagem;

                _ctx.Dicas.Update(dicaAlterada);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Dica dicaASerExcluida = Buscar(id);

                if (dicaASerExcluida == null)
                    throw new Exception("Impossível excluir o post pois faltam dados.");

                _ctx.Dicas.Remove(dicaASerExcluida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}