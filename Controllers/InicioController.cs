using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AdminRooms.Models.ViewModel;
using AdminRooms.Services.Interfaz;
using AdminRooms.Models;

namespace AdminRooms.Controllers
{
    public class InicioController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IResidenciasService _residenciasServices;

        public InicioController(IConfiguration configuration, IResidenciasService residenciasServices)
        {
            _configuration = configuration;
            _residenciasServices = residenciasServices;

        }
        public IActionResult Index()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;

            //Verificamos si el usuario esta autenticado, si lo esta no le pedira contraseña
            if(claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            //Busca al usuario 
           Usuario usuario = await _residenciasServices.GetUsuario(viewModel.User,viewModel.Password);  

            //Si el usuario es encontrado, empieza la accion de logeo
            if (usuario != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, viewModel.User),
                    new Claim("OtherProperty", "Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "Usuario no encontrado";
            return View();
        }
    }
}
