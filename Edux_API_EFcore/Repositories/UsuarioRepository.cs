using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_Api_EFcore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EduxContext _ctx;

        public UsuarioRepository ()
        {
            _ctx = new EduxContext();
        }

        # region Leitura
        public List<Usuario> Mostrar()
        {
            try
            {

                return _ctx.Usuarios.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuarios.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public List<Usuario> BuscarPorNome (string nome)
        {
            try
            {
                return _ctx.Usuarios.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        # endregion

        # region Gravação
        public void Adicionar(Usuario u)
        {
            try
            {
                u.Senha = Criptografia.Criptografar(u.Senha, u.Email.Substring(0, 4));

                u.DataCadastro = DateTime.Now;

                _ctx.Usuarios.Add(u);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, Usuario u)
        {
            try
            {

                Usuario usuarioTemp = _ctx.Usuarios.Find(id);
                if (usuarioTemp == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }
                usuarioTemp.Nome = u.Nome;
                usuarioTemp.Email = u.Email;
                usuarioTemp.Senha = u.Senha;

                _ctx.Usuarios.Update(usuarioTemp);
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

                Usuario usuarioTemp = BuscarPorId(id);
                if (usuarioTemp == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                _ctx.Usuarios.Remove(usuarioTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }
        # endregion
    }
}
