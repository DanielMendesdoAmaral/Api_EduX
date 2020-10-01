using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edux_Api_EFcore.Domains;

namespace Edux_Api_EFcore.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Mostrar();
        Usuario BuscarPorId(Guid id);
        List<Usuario> BuscarPorNome(string nome);
        void Adicionar(Usuario u);
        void Editar(Guid id, Usuario u);
        void Remover(Guid id);
    }
}
