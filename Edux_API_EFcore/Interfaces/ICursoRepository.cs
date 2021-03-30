using Edux_Api_EFcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Interfaces
{
    interface ICursoRepository
    {
        List<Curso> Listar();

        List<Curso> BuscarPorTitulo(string titulo);

        Curso BuscarPorId(Guid id);

        void Adicionar(Curso curso);

        void Editar(Guid id, Curso curso);

        void Remover(Guid id);
    }
}
