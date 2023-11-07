using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroMembros.Presentation.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PessoaViewModel> pessoaVm = await _pessoaAppService.ObterTodosAsync();
            return View(pessoaVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PessoaViewModel pessoaVm)
        {
            if (ModelState.IsValid)
            {
                await _pessoaAppService.CriarPessoaAsync(pessoaVm);
                TempData["MensagemSuccesso"] = "Membro criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Erro ao cadastrar o membro!";
            return View(pessoaVm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pessoaVm = await _pessoaAppService.ObterPessoaPorIdAsync(id);
            return View(pessoaVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PessoaViewModel pessoaVm)
        {
            if (ModelState.IsValid)
            {
                await _pessoaAppService.AtualizarPessoaAsync(pessoaVm);
                TempData["MensagemSuccesso"] = "Membro atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pessoaVm = await _pessoaAppService.ObterPessoaPorIdAsync(id);
            return View(pessoaVm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _pessoaAppService.ExcluirPessoaAsync(id);
                TempData["MensagemSuccesso"] = "Membro removido com sucesso!";
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não conseguimos excluir o membro {e.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
