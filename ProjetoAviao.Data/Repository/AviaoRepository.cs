using ProjetoAviao.Data.Context;
using ProjetoAviao.Data.Repository.Interface;
using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Data.Repository
{
    public class AviaoRepository : IAviaoRepository
    {
        private readonly DbContexto _db;

        public AviaoRepository(DbContexto db)
        {
            _db = db;
        }

        public void AdicionarAviao(Aviao aviao)
        {
            _db.Add(aviao);
            _db.SaveChanges();
        }

        public List<Aviao> ObterPaginado(int paginaAtual, int itensPorPagina, out int totalItens)
        {
            totalItens = _db.Avioes.Count();

            return _db.Avioes
                .OrderBy(a => a.Id)
                .Skip((paginaAtual - 1) * itensPorPagina)
                .Take(totalItens)
                .ToList();
        }
    }
}
