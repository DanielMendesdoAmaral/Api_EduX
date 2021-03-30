using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface IObjetivoAlunoRepository
    {
        List<ObjetivoAluno> Buscar();

        ObjetivoAluno Buscar(Guid id);

        List<ObjetivoAluno> BuscarPorAluno(Guid idAluno);

        void Cadastrar(ObjetivoAluno objetivoAluno);

        void Alterar(Guid id, ObjetivoAluno objetivoAluno);

        void Excluir(Guid id);
    }
}