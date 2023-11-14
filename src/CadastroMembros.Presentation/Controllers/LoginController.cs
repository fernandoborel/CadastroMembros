using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CadastroMembros.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LoginController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel usuarioVm)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioAppService.ObterPorLoginESenha(usuarioVm.Login, usuarioVm.Senha);
                if (usuario != null)
                {
                    //Cookie
                    var identity = new ClaimsIdentity(
                            new[] { new Claim(ClaimTypes.Name, usuario.Login) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);

                    TempData["MensagemSucesso"] = "Login efetuado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MensagemErro"] = "Acesso negado. Usuário inválido.";
                }
            }

            TempData["MensagemErro"] = "Erro ao efetuar o login!";
            return View(usuarioVm);
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel usuarioVm)
        {
            if (ModelState.IsValid)
            {
                //DESCOMENTAR QUANDO FINALIZAR O PROJETO
                //if (await _usuarioAppService.ObterPorEmail(usuarioVm.Email) != null)
                //{
                //    TempData["MensagemErro"] = "E-mail já cadastrado!";
                //    return View(usuarioVm);
                //}

                await _usuarioAppService.CriarUsuarioAsync(usuarioVm);
                TempData["MensagemSucesso"] = "Usuário criado com sucesso!";
                return RedirectToAction("Login", "Login");
            }
            TempData["MensagemErro"] = "Erro ao cadastrar o usuário!";
            return View(usuarioVm);
        }

        public async Task<IActionResult> Logout()
        {
            // Destruir o cookie de autenticação do usuário
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }
    }
}
