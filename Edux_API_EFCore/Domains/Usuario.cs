using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Usuario : BaseDomains
    {
        //Atributos
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimoAcesso { get; set; }

        //Foreign Keys
        public Guid IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }



        public List<Curtida> Curtidas { get; set; }

        public List<ProfessorTurma> ProfessoresTurmas { get; set; }

        public List<Dica> Dicas { get; set; }

        public List<AlunoTurma> AlunosTurmas { get; set; }
    }
}
