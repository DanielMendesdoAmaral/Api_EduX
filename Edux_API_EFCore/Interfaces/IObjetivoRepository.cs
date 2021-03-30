using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface IObjetivoRepository
    {

        List<Objetivo> Listar();

        Objetivo BuscarPorId(Guid Id);

        List<Objetivo> BuscarPorTermo(string termo);

        Objetivo Adicionar(Objetivo objetivo);

        void Editar(Guid id, Objetivo objetivo);

        void Remover(Guid Id);


    }
}
