using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SistemaConsultorio.DAL;
using SistemaConsultorio.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaConsultorio.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index() //https://localhost:44346/login/index
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new {Msg = "Usuario ja logado"});
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModel login) //https://localhost:44346/login/logar
        {
            UsuarioRepositorySqlServer usuarioRepository = new UsuarioRepositorySqlServer(_configuration);

            var usuario = usuarioRepository.Autenticar(login);
            
            List<Claim> direitosAcesso = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,usuario.Id.ToString()),
                new Claim(ClaimTypes.Name,usuario.Nome)
            };

            var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            await HttpContext.SignInAsync(userPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.Now.AddHours(1)
                });

            if (!(usuario.Usuario is null))
                return Json(new { Msg = $"Bem-vindo, {usuario.Nome}" });

            return Json(new { Msg = $"Não foi possível realizar autenticação" });
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
