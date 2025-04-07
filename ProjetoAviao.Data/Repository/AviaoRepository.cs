using Microsoft.EntityFrameworkCore;
using ProjetoAviao.Data.Context;
using ProjetoAviao.Data.Repository.Interface;
using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public void Atualizar(Aviao aviao)
        {
            _db.Avioes.Update(aviao);
            _db.SaveChanges();
        }

        public List<Aviao> ListarAtivos(int paginaAtual, int itensPorPagina, int ativo, out int totalItens)
        {
            var query = _db.Avioes.Where(a => a.Ativo == 1);

            totalItens = query.Count();

            return query
                .OrderBy(a => a.Id)
                .Skip((paginaAtual - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToList();
        }

        public List<Aviao> ListarInativos(int paginaAtual, int itensPorPagina, int inativo, out int totalItens)
        {
            var query = _db.Avioes.Where(a => a.Ativo == 0);

            totalItens = query.Count();

            return query
                .OrderBy(a => a.Id)
                .Skip((paginaAtual - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToList();
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

        public Aviao ObterPorId(Guid id)
        {
            return _db.Avioes.FirstOrDefault(a => a.Id == id);
        }
    }
}
