using Microsoft.AspNetCore.Mvc;
using ProjetoAviao.Dominio.Dominio;
using ProjetoAviao.Models;
using ProjetoAviao.Service.Service.Interface;
using System.Runtime.Intrinsics.X86;

namespace ProjetoAviao.Controllers
{
    public class AviaoController : Controller
    {
        private readonly IAviaoService _aviaoService;

        public AviaoController(IAviaoService aviaoService)
        {
            _aviaoService = aviaoService;
        }

        public IActionResult Cadastrar()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Aviao aviao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AviaoView aviaoView = new AviaoView
                    {
                        Aviacao = aviao.Aviacao,
                        Tipo = aviao.Tipo,
                        Origem = aviao.Origem,
                        Destino = aviao.Destino,
                        Ativo = aviao.Ativo
                    };

                    _aviaoService.AdicionarAviao(aviao);

                    TempData["Mensagem"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Cadastrar");
                }
                else
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine("Erro de validação: " + error.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erro ao salvar avião: " + ex.Message);
            }

            return View(aviao);
        }


        [HttpGet]
        public IActionResult Consultar(int paginaAtual = 1, int itensPorPagina = 5)
        {
            var avioes = _aviaoService.ObterPaginado(paginaAtual, itensPorPagina, out int total);

            var viewModel = new IndexView
            {
                Avioes = avioes,
                TotalItens = total,
                PaginaAtual = paginaAtual,
                ItensPorPagina = itensPorPagina
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ListarAtivos(int paginaAtual = 1, int ativo = 1, int itensPorPagina = 5)
        {
            var avioes = _aviaoService.ListarAtivos(paginaAtual, itensPorPagina, ativo, out int total);

            var viewModel = new IndexView
            {
                Avioes = avioes,
                TotalItens = total,
                PaginaAtual = paginaAtual,
                ItensPorPagina = itensPorPagina
            };

            return View(viewModel);

        }

        [HttpGet]
        public IActionResult ListarInativos(int paginaAtual = 1, int inativo = 0, int itensPorPagina = 5)
        {
            var avioes = _aviaoService.ListarInativos(paginaAtual, itensPorPagina, inativo, out int total);

            var viewModel = new IndexView
            {
                Avioes = avioes,
                TotalItens = total,
                PaginaAtual = paginaAtual,
                ItensPorPagina = itensPorPagina
            };

            return View(viewModel);

        }
    }
}
