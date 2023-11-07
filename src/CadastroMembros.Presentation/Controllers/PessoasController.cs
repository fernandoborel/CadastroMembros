using Microsoft.AspNetCore.Mvc;

namespace CadastroMembros.Presentation.Controllers
{
    public class PessoasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
