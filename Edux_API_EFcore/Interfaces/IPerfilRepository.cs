using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface IPerfilRepository
    {
        List<Perfil> Mostrar();
        Perfil BuscarPorId(Guid id);
        void Adicionar(Perfil p);
        void Editar(Guid id, Perfil p);
        void Remover(Guid id);
    }
}