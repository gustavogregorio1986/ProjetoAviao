using Microsoft.EntityFrameworkCore;
using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Data.Context
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Aviao> Avioes { get; set; }
    }
}
