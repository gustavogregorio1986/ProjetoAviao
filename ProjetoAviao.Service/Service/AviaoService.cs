using ClosedXML.Excel;
using ProjetoAviao.Data.DTO;
using ProjetoAviao.Data.Repository;
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

        public ExportacaoExcelResultado ExportarAvioesParaExcel(int paginaAtual, int itensPorPagina)
        {
            int totalItens;
            var avioes = _repository.ObterPaginado(paginaAtual, itensPorPagina, out totalItens);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Avioes");

                worksheet.Cell(1, 1).Value = "Aviacao";
                worksheet.Cell(1, 2).Value = "Tipo";
                worksheet.Cell(1, 3).Value = "Origem";
                worksheet.Cell(1, 4).Value = "Conexao";
                worksheet.Cell(1, 5).Value = "Destino";
                worksheet.Cell(1, 6).Value = "Status";

                int linha = 2;
                foreach (var aviao in avioes)
                {
                    worksheet.Cell(linha, 1).Value = aviao.Aviacao;
                    worksheet.Cell(linha, 2).Value = aviao.Tipo;
                    worksheet.Cell(linha, 3).Value = aviao.Origem;
                    worksheet.Cell(linha, 4).Value = aviao.Conexao;
                    worksheet.Cell(linha, 5).Value = aviao.Destino;
                    worksheet.Cell(linha, 6).Value = aviao.Ativo == 1 ? "Ativo" : "Inativo";
                    linha++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return new ExportacaoExcelResultado
                    {
                        Arquivo = stream.ToArray(),
                        TotalItens = totalItens
                    };
                }
            }
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
