using Edux_Api_EFcore.Contexts;
using Edux_Api_EFcore.Domains;
using Edux_Api_EFcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EduxContext _ctx;

        public InstituicaoRepository ()
        {
            _ctx = new EduxContext();
        }
        # region Leitura
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Instituicoes.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public List<Instituicao> BuscarPorNome(string nome)
        {
            try
            {

                return _ctx.Instituicoes.Where(c => c.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public List<Instituicao> Mostrar()
        {
            try
            {

                return _ctx.Instituicoes.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        #endregion

        # region Gravação
        public void Editar(Guid id, Instituicao i)
        {
            try
            {

                Instituicao instituicaoTemp = _ctx.Instituicoes.Find(id);
                if (instituicaoTemp == null)
                {
                    throw new Exception("Instituição não encontrada.");
                }
                instituicaoTemp.Nome = i.Nome;
                instituicaoTemp.Logradouro = i.Logradouro;
                instituicaoTemp.Numero = i.Numero;
                instituicaoTemp.Complemento = i.Complemento;
                instituicaoTemp.Bairro = i.Bairro;
                instituicaoTemp.Cidade = i.Cidade;
                instituicaoTemp.UF = i.UF;
                instituicaoTemp.CEP = i.CEP;

                _ctx.Instituicoes.Update(instituicaoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Adicionar(Instituicao i)
        {
            try
            {

                _ctx.Instituicoes.Add(i);

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

                Instituicao instituicaoTemp = BuscarPorId(id);
                if (instituicaoTemp == null)
                {
                    throw new Exception("Instituição não encontrada.");
                }

                _ctx.Instituicoes.Remove(instituicaoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        # endregion
    }
}
