using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Objetivo : BaseDomains
    {
        //Atributo
        public string Descricao { get; set; }

        //Foreign Keys
        public Guid IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}