using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads/Imagens", nomeArquivo);

            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);
            file.CopyTo(streamImagem);

            return "https://localhost:49932/Upload/Imagens/" + nomeArquivo;
        }
    }
}