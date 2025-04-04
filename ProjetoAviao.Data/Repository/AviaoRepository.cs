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
    }
}
