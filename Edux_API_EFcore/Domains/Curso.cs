using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Curso : BaseDomains
    {
      
        //Atributos
        public string Titulo { get; set; }

        //Foreign Keys
        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao Instituicao { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}