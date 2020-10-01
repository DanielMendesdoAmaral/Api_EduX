 //DANIEL

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Dica : BaseDomains
    {

        //Atributos
        public string Texto { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }

       
        //Foreign Key
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        //Dica 1-N Curtida
        public List<Curtida> Curtidas { get; set; }
    }
}