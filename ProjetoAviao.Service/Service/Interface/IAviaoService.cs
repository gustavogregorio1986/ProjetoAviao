using ProjetoAviao.Data.DTO;
using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Service.Service.Interface
{
    public interface IAviaoService
    {
        void AdicionarAviao(Aviao aviao);

        List<Aviao> ObterPaginado(int paginaAtual, int itensPorPagina, out int totalItens);

        List<Aviao> ListarAtivos(int paginaAtual, int itensPorPagina, int ativo, out int totalItens);

        List<Aviao> ListarInativos(int paginaAtual, int itensPorPagina, int inativo, out int totalItens);

        ExportacaoExcelResultado ExportarAvioesParaExcel(int paginaAtual, int itensPorPagina);

        void AlternarStatus(Guid id);


    }
}
