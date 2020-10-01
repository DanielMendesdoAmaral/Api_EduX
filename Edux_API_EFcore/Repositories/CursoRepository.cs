using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EduxContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduxContext();
        }

        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Cursos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Cursos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> BuscarPorTitulo(string titulo)
        {
            try
            {
                return _ctx.Cursos.Where(c => c.Titulo.Contains(titulo)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Guid id, Curso curso)
        {
            try
            {
                Curso cursoTitulo = BuscarPorId(id);
                if (cursoTitulo == null)
                    throw new Exception("Curso não encontrado.");

                cursoTitulo.IdInstituicao = curso.IdInstituicao;
                cursoTitulo.Titulo = curso.Titulo;
                cursoTitulo.Turmas = curso.Turmas;

                _ctx.Cursos.Update(cursoTitulo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Cursos.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Curso cursoTitulo = BuscarPorId(id);
                if (cursoTitulo == null)
                    throw new Exception("Curso não encontrado.");

                _ctx.Cursos.Remove(cursoTitulo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}