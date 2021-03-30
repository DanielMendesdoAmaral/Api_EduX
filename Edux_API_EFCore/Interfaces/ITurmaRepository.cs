using Edux_Api_EFcore.Domains;
using Edux_API_EFcore.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface ITurmaRepository
    {
        List<Turma> Listar();

        Turma BuscarPorId(Guid Id);

        List<Turma> BuscarPorNome(string nome);

        void Adicionar(ProfessoresAlunosTurma professoresAlunosTurma);

        void Editar(Guid id, ProfessoresAlunosTurma professoresAlunosTurma);

        void Remover(Guid Id);
    }
}