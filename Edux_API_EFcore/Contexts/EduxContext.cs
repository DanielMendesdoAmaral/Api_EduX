//DANIEL

using Edux_Api_EFcore.Domains;
using Microsoft.EntityFrameworkCore;

namespace Edux_Api_EFcore.Contexts
{
    public class EduxContext : DbContext
    {
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<ObjetivoAluno> ObjetivosAlunos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Data Source=desktop-h1nfq8t\SQLEXPRESS;Initial Catalog=edux;User ID=sa;Password=sa132");
                base.OnConfiguring(optionBuilder);
            }
        }
    }
}