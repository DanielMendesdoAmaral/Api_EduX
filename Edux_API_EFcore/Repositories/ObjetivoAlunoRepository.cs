using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAlunoRepository
    {
        private readonly EduxContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new EduxContext();
        }

        public List<ObjetivoAluno> Buscar()
        {
            try
            {
                return _ctx.ObjetivosAlunos
                    .Include(o => o.AlunoTurma.Usuario)
                    .Include(o => o.Objetivo)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAluno Buscar(Guid id)
        {
            try
            {
                return _ctx.ObjetivosAlunos
                    .Include(o => o.AlunoTurma.Usuario)
                    .Include(o => o.Objetivo)
                    .FirstOrDefault(o => o.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ObjetivoAluno> BuscarPorAluno(Guid idAluno)
        {
            try
            {
                var objetivoPorAluno = _ctx.ObjetivosAlunos.Where(o => o.AlunoTurma.Usuario.Id == idAluno)
                    .Include(o => o.AlunoTurma.Usuario)
                    .Include(o => o.Objetivo)
                    .ToList();
                return objetivoPorAluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Cadastrar(ObjetivoAluno objetivoAluno)
        {
            try
            {
                objetivoAluno.DataAlcancado = DateTime.Now;
                _ctx.ObjetivosAlunos.Add(objetivoAluno);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Guid id, ObjetivoAluno objetivoAluno)
        {
            try
            {
                ObjetivoAluno objetivoAlunoVerificar = Buscar(id);

                if (objetivoAlunoVerificar == null)
                    throw new Exception("Impossível incluir a edição do ObjetivoAluno pois faltam dados.");

                objetivoAlunoVerificar.DataAlcancado = objetivoAluno.DataAlcancado;
                objetivoAlunoVerificar.IdAlunoTurma = objetivoAluno.IdAlunoTurma;
                objetivoAlunoVerificar.IdObjetivo = objetivoAluno.IdObjetivo;
                objetivoAlunoVerificar.Nota = objetivoAluno.Nota;

                _ctx.ObjetivosAlunos.Update(objetivoAlunoVerificar);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                ObjetivoAluno objetivoAlunoASerExcluido = Buscar(id);

                if (objetivoAlunoASerExcluido == null)
                    throw new Exception("Impossível excluir o ObjetivoAluno pois faltam dados.");

                _ctx.ObjetivosAlunos.Remove(objetivoAlunoASerExcluido);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}