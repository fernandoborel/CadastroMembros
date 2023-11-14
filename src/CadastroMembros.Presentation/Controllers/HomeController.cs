using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.ViewModel;
using CadastroMembros.Domain.Enums;
using CadastroMembros.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroMembros.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public HomeController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel();
            try
            {
                var membrosCadastrados = await _pessoaAppService.ObterTodosAsync();

                model.TotalMembrosCadastrados = membrosCadastrados.Count();

                model.TotalMembros = membrosCadastrados.Count(m => m.Vinculo == Vinculo.Membro);
                model.TotalCongregados = membrosCadastrados.Count(m => m.Vinculo == Vinculo.Congregado);
                model.TotalVisitantes = membrosCadastrados.Count(m => m.Vinculo == Vinculo.Visitante);

                model.TotalHomens = membrosCadastrados.Count(m => m.Sexo == Sexo.Masculino);
                model.TotalMulheres = membrosCadastrados.Count(m => m.Sexo == Sexo.Feminino);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}