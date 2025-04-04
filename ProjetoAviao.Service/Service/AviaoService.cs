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
    }
}
