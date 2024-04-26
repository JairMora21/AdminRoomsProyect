using AdminRooms.Models;
using AdminRooms.Models.ViewModel;
using AdminRooms.Services.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//prueba travis-ci
namespace AdminRooms.Controllers
{
    [Authorize]
    public class CuartosController : Controller
    {
        private readonly ICuartosService _cuartosService;
        private readonly IHuespedService _huespedService;
        private readonly IFinanzasServices _finanzasServices;


        public CuartosController(ICuartosService cuartosService, IHuespedService huespedService, IFinanzasServices finanzasServices)
        {
            _cuartosService = cuartosService;
            _huespedService = huespedService;
            _finanzasServices = finanzasServices;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Cuarto> cuartos = await _cuartosService.GetAllRooms();
            IEnumerable<Cuarto> cuartosDisponibles = await _cuartosService.GetAvailableRooms();
            IEnumerable<Cuarto> cuartosOcupados = await _cuartosService.GetDisableRooms();
            IEnumerable<Huesped> huespedsSinCuartos = await _huespedService.GetNoRoomGuest();


            ViewBag.Huespeds = huespedsSinCuartos;

            ViewBag.CuartosTodos = cuartos;
            ViewBag.CuartosDisponibles = cuartosDisponibles;
            ViewBag.CuartosOcupados = cuartosOcupados;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditRoom(int id)
        {
            Cuarto cuarto = await _cuartosService.GetRoom(id);

            var cuartoNull = 1;

            if (cuarto.NumeroCuarto == null)
            {
                cuartoNull = 0;
            }
            else
            {
                cuartoNull = (int)cuarto.NumeroCuarto;
            }

            CuartoViewModel viewModel = new CuartoViewModel
            {
                Costo = cuarto.Costo,
                NumeroCuarto = cuartoNull
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoom(int id, CuartoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Cuarto cuartoAct = new Cuarto
                {
                    IdCuarto = id,
                    Costo = viewModel.Costo,
                    NumeroCuarto = viewModel.NumeroCuarto
                };

                await _cuartosService.UpdateRoom(id, cuartoAct);


                return RedirectToAction(nameof(Index));

            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CuartoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Cuarto cuarto = new Cuarto
                {
                    NumeroCuarto = viewModel.NumeroCuarto,
                    Costo = viewModel.Costo,
                    Disponibilidad = true
                };

                await _cuartosService.AddRoom(cuarto);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AsingarHuesped(int idCuarto, int idHuesped)
        {
            //Si no se manda un huesped no se hace ninguna accion
            if (idHuesped != 0)
            {
                //Obtenemos los huespeds y cuartos especificos para crear una nueva asignacion
                Huesped huesped = await _huespedService.GetGestById(idHuesped);
                Cuarto cuarto = await _cuartosService.GetRoom(idCuarto);
                //Creamos la asignacion y al mismo timepo obtenemos el objeto de asignacion
                Asignacion asignacion = await _finanzasServices.CreateAssignation(cuarto, huesped);
                //Obtenemos el id de la asignacion
                var idAsignacion = asignacion.IdAsignacion;

                //Se lo mandamos a la actualizacion del cuarto
                await _cuartosService.AddGuestToRoom(idCuarto, idHuesped, idAsignacion);
                await _huespedService.AddRoomToGuest(idHuesped, idCuarto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRoom(int idCuarto, int idHuesped, int idAsignacion)
        {
            try
            {
                await _cuartosService.DeleteUserFromRoom(idCuarto);
                await _huespedService.DeleteRoomFromGuest(idHuesped);
                await _finanzasServices.DeleteAssignation(idAsignacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción, loguearla o devolver un mensaje de error.
                return RedirectToAction(nameof(Index)); // O redirigir a una página de error.
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int idCuarto)
        {
            await _cuartosService.DeleteRoom(idCuarto);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Cuartos()
        {
            return View();
        }
    }
}
