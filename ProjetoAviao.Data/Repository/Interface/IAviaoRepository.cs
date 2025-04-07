using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Data.Repository.Interface
{
    public interface IAviaoRepository
    {
        void AdicionarAviao(Aviao aviao);

        List<Aviao> ObterPaginado(int paginaAtual, int itensPorPagina, out int totalItens);

        List<Aviao> ListarAtivos(int paginaAtual, int itensPorPagina, int ativo, out int totalItens);

        List<Aviao> ListarInativos(int paginaAtual, int itensPorPagina, int inativo, out int totalItens);

        Aviao ObterPorId(Guid id);

        void Atualizar(Aviao aviao);
    }
}
