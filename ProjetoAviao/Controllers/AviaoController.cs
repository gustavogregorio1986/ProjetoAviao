using Microsoft.AspNetCore.Mvc;

namespace ProjetoAviao.Controllers
{
    public class AviaoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }
    }
}
