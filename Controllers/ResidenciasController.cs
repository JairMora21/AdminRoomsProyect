using AdminRooms.Models;
using AdminRooms.Models.ViewModel;
using AdminRooms.Services.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminRooms.Controllers
{
    [Authorize]
    public class ResidenciasController : Controller
    {

        private readonly IResidenciasService _residenciasServices;

        public ResidenciasController(IResidenciasService residenciasServices)
        {
            _residenciasServices = residenciasServices;
        }

        public async Task<IActionResult> Index()
        {
            //Traenis todas las casas
            IEnumerable<Casa> casa = await _residenciasServices.GetHomes();

            return View(casa);
        }

        [HttpGet]
        public IActionResult AddHome()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHome(CasaViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Agregamos una nueva casa
                var casa = new Casa()
                {
                    Nombre = model.Nombre,
                    Direccion = model.Direccion,
                    NumeroCuartos = model.NumeroCuartos
                };
                await _residenciasServices.AddHome(casa);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditHome(int id) {

            Casa casa = await _residenciasServices.GetHomeById(id);

            CasaViewModel casaModel = new CasaViewModel
            {
                Nombre = casa.Nombre,
                Direccion = casa.Direccion,
                NumeroCuartos = casa.NumeroCuartos,
            };

            return View(casaModel);
        }

        [HttpPost]
        public async  Task<IActionResult> EditHome(int id, CasaViewModel casaModel)
        {
            if (ModelState.IsValid)
            {
                Casa casa = new Casa
                {
                    IdCasa = id,
                    Nombre = casaModel.Nombre,
                    Direccion = casaModel.Direccion,
                    NumeroCuartos = casaModel.NumeroCuartos,
                };
                await _residenciasServices.UpdateHome(id, casa);
                return RedirectToAction(nameof(Index));
            }

            return View(casaModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _residenciasServices.RemoveHome(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
