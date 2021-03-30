using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Mostrar();
        Instituicao BuscarPorId(Guid id);
        List<Instituicao> BuscarPorNome(string nome);
        void Adicionar(Instituicao i);
        void Editar(Guid id, Instituicao i);
        void Remover(Guid id);
    }
}
