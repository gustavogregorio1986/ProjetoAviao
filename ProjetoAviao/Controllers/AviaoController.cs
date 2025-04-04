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
                        Destino = aviao.Destino
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


        public IActionResult Consultar()
        {
            return View();
        }
    }
}
