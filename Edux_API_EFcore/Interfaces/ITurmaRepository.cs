using Edux_Api_EFcore.Domains;
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

        void Adicionar(Turma turma, List<ProfessorTurma> professores, List<AlunoTurma> alunos);

        void Editar(Guid id, Turma turma, List<ProfessorTurma> professores, List<AlunoTurma> alunos);

        void Remover(Guid Id);
    }
}