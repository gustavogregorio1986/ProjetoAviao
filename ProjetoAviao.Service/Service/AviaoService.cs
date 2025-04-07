using ProjetoAviao.Data.Repository.Interface;
using ProjetoAviao.Dominio.Dominio;
using ProjetoAviao.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Service.Service
{
    public class AviaoService : IAviaoService
    {
        private readonly IAviaoRepository _repository;

        public AviaoService(IAviaoRepository repository)
        {
            _repository = repository;
        }

        public void AdicionarAviao(Aviao aviao)
        {
            _repository.AdicionarAviao(aviao);
        }

        public void AlternarStatus(Guid id)
        {
            var aviao = _repository.ObterPorId(id);

            if (aviao == null)
                throw new Exception("Aviao não encontrado!");

            aviao.AlterarStatus();

            _repository.Atualizar(aviao);
        }

        public List<Aviao> ListarAtivos(int paginaAtual, int itensPorPagina, int ativo ,out int totalItens)
        {
            return _repository.ListarAtivos(paginaAtual, itensPorPagina, ativo, out totalItens);
        }

        public List<Aviao> ListarInativos(int paginaAtual, int itensPorPagina, int inativo, out int totalItens)
        {
            return _repository.ListarInativos(paginaAtual, itensPorPagina, inativo, out totalItens);
        }

        public List<Aviao> ObterPaginado(int paginaAtual, int itensPorPagina, out int totalItens)
        {
            return _repository.ObterPaginado(paginaAtual, itensPorPagina, out totalItens);
        }
    }
}
