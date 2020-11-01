using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Edux_API_EFcore.Auxiliar;
using Microsoft.EntityFrameworkCore;
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

                return _ctx.Turmas.Include(t => t.AlunosTurmas).Include(t=>t.ProfessoresTurmas).Include(t=>t.Curso).ToList();

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
                return _ctx.Turmas.Include(t => t.AlunosTurmas).Include(t => t.ProfessoresTurmas).Include(t => t.Curso).FirstOrDefault(turma => turma.Id == Id);
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

        public void Adicionar(ProfessoresAlunosTurma professoresAlunosTurma)
        {
            try
            {
                Turma turmaJuntar = new Turma();

                foreach (ProfessorTurma item in professoresAlunosTurma.professores)
                {
                    turmaJuntar.ProfessoresTurmas.Add(new ProfessorTurma
                    {
                        Descricao = item.Descricao,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaJuntar.Id
                    });
                }

                foreach (AlunoTurma item in professoresAlunosTurma.alunos)
                {
                    turmaJuntar.AlunosTurmas.Add(new AlunoTurma
                    {
                        Matricula = Guid.NewGuid().ToString(),
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaJuntar.Id
                    });
                }

                turmaJuntar.Descricao = professoresAlunosTurma.turma.Descricao;
                turmaJuntar.Curso = professoresAlunosTurma.turma.Curso;
                turmaJuntar.IdCurso = professoresAlunosTurma.turma.IdCurso;

                _ctx.Turmas.Add(turmaJuntar);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Editar(Guid id, ProfessoresAlunosTurma professoresAlunosTurma)
        {
            try
            {
                Turma turmaAlterar = BuscarPorId(id);

                if (turmaAlterar == null)
                    throw new Exception("Impossível alterar Turma pois faltam dados.");

                //ANTES DE ADICIONAR OS NOVOS OBJETOS PRIMEIRO REMOVEMOS OS JÁ EXISTENTES

                turmaAlterar.ProfessoresTurmas.Clear();
                turmaAlterar.AlunosTurmas.Clear();

                turmaAlterar.AlunosTurmas.AddRange(professoresAlunosTurma.alunos);
                turmaAlterar.ProfessoresTurmas.AddRange(professoresAlunosTurma.professores);

                /*foreach (ProfessorTurma item in professoresAlunosTurma.professores)
                {
                    turmaAlterar.ProfessoresTurmas.Add(new ProfessorTurma
                    {
                        Descricao = item.Descricao,
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaAlterar.Id
                    });
                }

                foreach (AlunoTurma item in professoresAlunosTurma.alunos)
                {
                    turmaAlterar.AlunosTurmas.Add(new AlunoTurma
                    {
                        Matricula = Guid.NewGuid().ToString(),
                        IdUsuario = item.IdUsuario,
                        IdTurma = turmaAlterar.Id
                    });
                }*/

                turmaAlterar.IdCurso = professoresAlunosTurma.turma.IdCurso;
                turmaAlterar.Descricao = professoresAlunosTurma.turma.Descricao;

                _ctx.Turmas.Update(turmaAlterar);

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
