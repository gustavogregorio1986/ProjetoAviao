using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Data.DTO
{
    public class ExportacaoExcelResultado
    {
        public byte[] Arquivo { get; set; }
        public int TotalItens { get; set; }
    }
}
