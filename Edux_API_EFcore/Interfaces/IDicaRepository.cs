//DANIEL

using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface IDicaRepository
    {
        List<Dica> Buscar();

        Dica Buscar(Guid id);

        List<Dica> Buscar(string palavraChave);

        void Criar(Dica dica);

        void Editar(Guid id, Dica dicaEditada);

        void Excluir(Guid id);
    }
}