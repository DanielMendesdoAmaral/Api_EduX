using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Perfil : BaseDomains
    {
        //Atributos
        public string Permissao { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}