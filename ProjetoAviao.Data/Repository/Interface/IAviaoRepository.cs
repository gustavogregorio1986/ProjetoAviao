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
    }
}
