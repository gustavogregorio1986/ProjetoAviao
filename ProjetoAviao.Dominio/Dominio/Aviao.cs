using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Dominio.Dominio
{
    public class Aviao
    {
        public Guid Id { get; set; }

        public string? Aviacao { get; set; }

        public string? Tipo { get; set; }

        public string? Origem { get; set; }

        public string? Conexao { get; set; }

        public string? Destino { get; set; }

        public int Ativo { get; set; }

        public Aviao() { }

        public Aviao(string aviacao)
        {
            Id = Guid.NewGuid();
            Aviacao = aviacao;
            Ativo = 1;
        }

        public void AlterarStatus()
        {
            Ativo = Ativo == 1 ? 0 : 1;
        }
    }
}
