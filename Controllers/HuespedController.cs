using AdminRooms.Models;
using AdminRooms.Models.ViewModel;
using AdminRooms.Services.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;


namespace AdminRooms.Controllers
{

    [Authorize]
    public class HuespedController : Controller
    {
        private readonly IHuespedService _huespedService;

        public HuespedController(IHuespedService huespedService)
        {
            _huespedService = huespedService;
        }

        public async Task<IActionResult> Index()
        {
            //Traemos a todos los huespeds
            IEnumerable<Huesped> huesped = await _huespedService.GetGuests();

            return View(huesped);
        }

        [HttpGet]
        public async Task<IActionResult> AddGuest()
        {
            //Obtenemos todos los generos para ponerlos en un selectlist
            IEnumerable<Genero> generos = await _huespedService.GetGenders();
            ViewBag.Generos = generos;
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest(HuespedViewModel viewModel)
        {
            //Obtenemos todos los generos para ponerlos en un selectlist
            IEnumerable<Genero> generos = await _huespedService.GetGenders();
            ViewBag.Generos = generos;

            if (ModelState.IsValid)
            {

                Huesped huesped = new Huesped
                {
                    Nombre = viewModel.Nombre,
                    Apellido = viewModel.Apellido,
                    MotivoEstancia = viewModel.MotivoEstancia,
                    Telefono = viewModel.Telefono,
                    IdGenero = viewModel.Genero,
                    TelefonoEmergencia = viewModel.TelefonoEmergencia,
                    Correo = viewModel.Correo,
                    PagoInicial = viewModel.PagoInicial,
                    FechaAlta = viewModel.FechaAlta,
                    FechaSalidaPrev = viewModel.FechaSalidaPrev,
                    Alacena = viewModel.Alacena,
                    Refrigerador = viewModel.Refrigerador,
                };
                await _huespedService.AddGuest(huesped);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> EditGuest(int id)
        {
            IEnumerable<Genero> generos = await _huespedService.GetGenders();
            ViewBag.Generos = generos;

            Huesped huesped = await _huespedService.GetGestById(id);

            HuespedViewModel viewModel = new HuespedViewModel
            {
                Nombre = huesped.Nombre,
                Apellido = huesped.Apellido,
                Genero = huesped.IdGenero,
                MotivoEstancia = huesped.MotivoEstancia,
                Telefono = huesped.Telefono,
                Correo = huesped.Correo,
                TelefonoEmergencia = huesped.TelefonoEmergencia,
                PagoInicial = huesped.PagoInicial,
                FechaSalidaPrev = huesped.FechaSalidaPrev,
                FechaAlta = huesped.FechaAlta,
                Alacena = huesped.Alacena,
                Refrigerador = huesped.Refrigerador,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditGuest(int id, HuespedViewModel viewModel)
        {
            IEnumerable<Genero> generos = await _huespedService.GetGenders();
            ViewBag.Generos = generos;

            if (ModelState.IsValid)
            {
                Huesped huesped = new Huesped
                {
                    IdHuesped = id,
                    Nombre = viewModel.Nombre,
                    Apellido = viewModel.Apellido,
                    MotivoEstancia = viewModel.MotivoEstancia,
                    Telefono = viewModel.Telefono,
                    IdGenero = viewModel.Genero,
                    TelefonoEmergencia = viewModel.TelefonoEmergencia,
                    Correo = viewModel.Correo,
                    PagoInicial = viewModel.PagoInicial,
                    FechaSalidaPrev = viewModel.FechaSalidaPrev,
                    Alacena = viewModel.Alacena,
                    Refrigerador = viewModel.Refrigerador,
                    FechaAlta = viewModel.FechaAlta,


                };
                await _huespedService.UpdateGuest(id, huesped);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Huesped huesped = await _huespedService.GetGestById(id);
                //Si el huesped no tiene cuarto se elimina
                if (huesped.IdCuarto != 0)
                {
                    await _huespedService.RemoveGuest(id);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguearla o devolver un mensaje de error.
                return RedirectToAction(nameof(Index)); // O redirigir a una página de error.
            }

        }
    }


}
