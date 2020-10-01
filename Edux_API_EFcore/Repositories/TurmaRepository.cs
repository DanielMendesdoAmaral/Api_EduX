using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EduxContext _ctx;

       public TurmaRepository()
        {

            _ctx = new EduxContext();

        }

        #region Leitura


        public List<Turma> Listar()
        {
            try
            {

                return _ctx.Turmas.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }


        public Turma BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Turmas.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Turma> BuscarPorNome(string nome)
        {
            try
            {

                return _ctx.Turmas.Where(o => o.Descricao.Contains(nome)).ToList();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        #endregion


        #region Gravação

        public void Adicionar(Turma turma, List<ProfessorTurma> professores, List<AlunoTurma> alunos)
        {
            try
            {
                Turma turmaJuntar = new Turma();

                foreach (ProfessorTurma item in professores)
                {
                    turmaJuntar.ProfessoresTurmas.Add(new ProfessorTurma
                    {
                        Descricao = item.Descricao,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaJuntar.Id
                    });
                }

                foreach (AlunoTurma item in alunos)
                {
                    turmaJuntar.AlunosTurmas.Add(new AlunoTurma
                    {
                        Matricula = item.Matricula,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaJuntar.Id
                    });
                }

                turmaJuntar.Descricao = turma.Descricao;
                turmaJuntar.Curso = turma.Curso;
                turmaJuntar.IdCurso = turma.IdCurso;

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, Turma turma, List<ProfessorTurma> professores, List<AlunoTurma> alunos)
        {
            try
            {
                Turma turmaAlterar = BuscarPorId(id);

                if (turmaAlterar == null)
                    throw new Exception("Impossível alterar Turma pois faltam dados.");

                foreach (ProfessorTurma item in professores)
                {
                    turmaAlterar.ProfessoresTurmas.Add(new ProfessorTurma
                    {
                        Descricao = item.Descricao,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaAlterar.Id
                    });
                }

                foreach (AlunoTurma item in alunos)
                {
                    turmaAlterar.AlunosTurmas.Add(new AlunoTurma
                    {
                        Matricula = item.Matricula,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaAlterar.Id
                    });
                }

                turmaAlterar.IdCurso = turma.IdCurso;
                turmaAlterar.Descricao = turma.Descricao;

                _ctx.Turmas.Update(turma);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid Id)
        {
            try
            {
                Turma TurmaExcluido = BuscarPorId(Id);

                if (TurmaExcluido == null)
                    throw new Exception("Impossível excluir a Turma desejado pois faltam dados.");

                _ctx.Turmas.Remove(TurmaExcluido);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
