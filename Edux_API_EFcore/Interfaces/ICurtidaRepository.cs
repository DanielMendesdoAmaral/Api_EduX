using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface ICurtidaRepository
    {
        List<Curtida> Mostrar();

        Curtida BuscarPorId(Guid id);

        Curtida Adicionar(Curtida curtida);

        void Editar(Guid id, Curtida curtida);

        void Remover(Guid id);
    }
}
