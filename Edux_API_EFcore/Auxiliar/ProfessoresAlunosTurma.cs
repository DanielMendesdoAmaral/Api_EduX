using System.Collections.Generic;
using Edux_Api_EFcore.Domains;

namespace Edux_API_EFcore.Auxiliar
{
    public class ProfessoresAlunosTurma
    {
        public List<ProfessorTurma> professores { get; set; }
        public List<AlunoTurma> alunos { get; set; }
        public Turma turma { get; set; }

        public ProfessoresAlunosTurma()
        {
            professores = new List<ProfessorTurma>();
            alunos = new List<AlunoTurma>();
            turma = new Turma();
        }
    }
}