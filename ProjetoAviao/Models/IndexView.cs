using Microsoft.AspNetCore.Mvc;
using ProjetoAviao.Dominio.Dominio;
using ProjetoAviao.Service.Service.Interface;

namespace ProjetoAviao.Models
{
    public class IndexView
    {
        public List<Aviao> Avioes { get; set; } = new();
        public int TotalItens { get; set; }
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }

        public int TotalPaginas => (int)Math.Ceiling((double)TotalItens / ItensPorPagina);
    }
}
