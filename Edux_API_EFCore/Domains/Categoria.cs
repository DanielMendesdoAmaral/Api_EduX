using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Categoria : BaseDomains
    {
        //Atributo
        public string Tipo { get; set; }

        ////Relacionamento com a tabela Categoria e Objetivo  1,N
        public List<Objetivo> Objetivos { get; set; }
    }
}