
using AdminRooms.Models;
using AdminRooms.Models.ViewModel;
using AdminRooms.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using Rotativa.AspNetCore;
using System.Drawing.Printing;
using System.Globalization;
using Humanizer;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AdminRooms.Controllers
{
    [Authorize]
    public class FinanzasController : Controller
    {

        private readonly IFinanzasServices _finanzasServices;
        private readonly ICuartosService _cuartosService;
        private readonly IHuespedService _huespedService;


        public FinanzasController(IFinanzasServices finanzasServices, ICuartosService cuartosService, IHuespedService huespedService)
        {
            _finanzasServices = finanzasServices;
            _cuartosService = cuartosService;
            _huespedService = huespedService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Asignacion> asignaciones = await _finanzasServices.GetAllAsignacions();
            ViewBag.Asignaciones = asignaciones;

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Facturas(string? fecha_inicial = null, string? fecha_final = null)
        {
            //Nos da los dates de hoy a un mes atras
            //DateTime fechaInicial = DateTime.ParseExact(fecha_inicial ?? DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //DateTime fechaFinal = DateTime.ParseExact(fecha_final ?? DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //Nos da las fechas del actual mes (del 1 al 31)
            DateTime fechaInicial = DateTime.ParseExact(fecha_inicial ?? DateTime.Now.Year + "-" + DateTime.Now.Month + "-01", "yyyy-M-dd", CultureInfo.InvariantCulture);
            DateTime fechaFinal = DateTime.ParseExact(fecha_final ?? fechaInicial.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //Pasamos las fechas a los inputs
            ViewData["FechaInicial"] = fechaInicial.ToString("yyyy-MM-dd");
            ViewData["FechaFinal"] = fechaFinal.ToString("yyyy-MM-dd");

            //NOs traera las facturas de las fwchas seleccionadas
            IEnumerable<Factura> factura = await _finanzasServices.GetFacturaByDate(fechaInicial, fechaFinal);
            //Nos dara el balance de dinero de ingresos y egresos
            double diferencia = await _finanzasServices.DiffMoneyStats(fechaInicial, fechaFinal);
            ViewBag.Diferencia = diferencia;

            ViewBag.Factura = factura;
            //Pasamos estos datos de fecha con un temp data para que lo tengan otros controladores 
            TempData["FechaInicial"] = fechaInicial;
            TempData["FechaFinal"] = fechaFinal;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GraficaFecha()
        {
            //Obtenemos las fechas ingresadas en factura/gastos gracias al tempdata
            DateTime inicial = (DateTime)TempData["FechaInicial"];
            DateTime final = (DateTime)TempData["FechaFinal"];

            //obtenemos los ingresos y egresos 
            List<MoneyStats> MoneyStatsDate = await _finanzasServices.GetMoneyStatsByDate(inicial, final);
            //Lo retornamos al javascript del navegador, mas de este metodo en el cshtml de factura/gastos
            return StatusCode(StatusCodes.Status200OK, MoneyStatsDate);

        }
        [HttpGet]
        public async Task<IActionResult> GraficaGastos()
        {
            //Obtenemos las fechas ingresadas en factura/gastos gracias al tempdata
            DateTime inicial = (DateTime)TempData["FechaInicial"];
            DateTime final = (DateTime)TempData["FechaFinal"];

            //obtenemos los gastos divididos por categoria 
            List<MoneyStats> MoneyStats = await _finanzasServices.GetBillStatsByDate(inicial, final);

            //Lo retornamos al javascript del navegador, mas de este metodo en el cshtml de factura/gastos
            return StatusCode(StatusCodes.Status200OK, MoneyStats);
        }

        [HttpGet]
        public async Task<IActionResult> GastosCompletos(string? fecha_inicial = null, string? fecha_final = null)
        {
            //Nos da los dates de hoy a un mes atras
            //DateTime fechaInicial = DateTime.ParseExact(fecha_inicial ?? DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //DateTime fechaFinal = DateTime.ParseExact(fecha_final ?? DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //Nos da los dates del actual mes 
            DateTime fechaInicial = DateTime.ParseExact(fecha_inicial ?? DateTime.Now.Year + "-" + DateTime.Now.Month + "-01", "yyyy-M-dd", CultureInfo.InvariantCulture);
            DateTime fechaFinal = DateTime.ParseExact(fecha_final ?? fechaInicial.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            ViewData["FechaInicial"] = fechaInicial.ToString("yyyy-MM-dd");
            ViewData["FechaFinal"] = fechaFinal.ToString("yyyy-MM-dd");
            TempData["FechaInicial"] = fechaInicial;
            TempData["FechaFinal"] = fechaFinal;


            IEnumerable<Gasto> gasto = await _finanzasServices.GetGastos(fechaInicial, fechaFinal);
            double diferencia = await _finanzasServices.DiffMoneyStats(fechaInicial, fechaFinal);
            ViewBag.Diferencia = diferencia;
            ViewBag.Gasto = gasto;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            Factura factura = await _finanzasServices.GetFacturaByID(id);

            int idAsignacion = factura.IdAsignacion ?? 0;

            if(idAsignacion != 0)
            {
                await _finanzasServices.DeleteDateAsing(idAsignacion);
            }

            await _finanzasServices.DeleteFactura(id);

            return RedirectToAction(nameof(Facturas));
        }

        [HttpGet]
        public async Task<IActionResult> EditFactura(int id)
        {
            Factura factura = await _finanzasServices.GetFacturaByID(id);


            string errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;

            int idAsignacion = factura.IdAsignacion ?? 0;

            FacturaViewModel viewModel = new FacturaViewModel
            {
                IdFactura = factura.IdFactura,
                Huesped = factura.Huesped,
                Monto = factura.Monto,
                Fecha = factura.Fecha,
                Concepto = factura.Concepto,
                idAsignacion = idAsignacion
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditFactura(string accion, int IdFactura, int idAsignacion, FacturaViewModel viewModel)
        
        {
            int contNulls = 0;
            //Validamos que se eligio una opcion 
            contNulls += viewModel.PagoEfectivo == true ? 1 : 0;
            contNulls += viewModel.RetiroSinTarjeta == true ? 1 : 0;
            contNulls += viewModel.PagoTransferencia == true ? 1 : 0;

            //Si se escogio alguna opcion seguiremos el proceso de la factura
            if (!ModelState.IsValid && contNulls == 1)
            {
                const string FACTURA_PDF = "Guardar y generar factura";
                Factura factura = new Factura
                {
                    Huesped = viewModel.Huesped,
                    Monto = viewModel.Monto,
                    Fecha = viewModel.Fecha,
                    Concepto = viewModel.Concepto,
                };

                //Si tiene una asignacion activa, se edita la fecha de la asignacion
                if (viewModel.idAsignacion != 0) {
                    Asignacion asignacion = new Asignacion
                    {
                        UltimoPago = viewModel.Fecha
                    };
                    await _finanzasServices.EditDateAsing(idAsignacion, asignacion);
                }

                await _finanzasServices.EditFactura(IdFactura, factura);

                if (FACTURA_PDF == accion)
                {
                    //se retorna la nueva factura
                    //Transformamos la cantidad a texto
                    int monto = (int)viewModel.Monto;
                    string montoText = monto.ToWords();

                    //Se crea un nuevo viewmodel por si se necesita actualizar el montotexto
                    FacturaViewModel pdfViewModel = new FacturaViewModel
                    {
                        Huesped = viewModel.Huesped,
                        Fecha = viewModel.Fecha,
                        Monto = viewModel.Monto,
                        MontoTexto = montoText,
                        Concepto = viewModel.Concepto,
                        PagoEfectivo = viewModel.PagoEfectivo,
                        PagoTransferencia = viewModel.PagoTransferencia,
                        RetiroSinTarjeta = viewModel.RetiroSinTarjeta,

                    };
                    string fechaFormateada = viewModel.Fecha.ToString("dd/MM/yyyy");
                    return new ViewAsPdf("PdfFactura", pdfViewModel)
                    {
                        FileName = $"Recibo_{viewModel.Huesped}_{fechaFormateada}.pdf",
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                        PageSize = Rotativa.AspNetCore.Options.Size.A4
                    };
                }
                else
                {
                    return RedirectToAction(nameof(Facturas));

                }
            }
            TempData["ErrorMessage"] = "Olvidaste seleccionar el tipo de pago.";
            return RedirectToAction("EditFactura", new { id = viewModel.IdFactura });
        }

        [HttpGet]
        public async Task<IActionResult> GenerarPago(int id)
        {
            //Obtenemos los datos necesarios para la factura
            Asignacion asignacion = await _finanzasServices.GetAsignacionById(id);
            Cuarto cuarto = await _cuartosService.GetRoom(asignacion.IdCuarto);
            Huesped huesped = await _huespedService.GetGestById(asignacion.IdHuesped);
            //Validamos los campos nulos para evitar errores
            double costo = cuarto.Costo ?? 0;
            string correo = huesped.Correo ?? "Este usuario no cuenta con correo para enviar factura";

            string errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;


            string nombreCompleto = $"{huesped.Nombre} {huesped.Apellido}";
            //Llenamos el viewmodel para tener los inputs necesarios llenos y facilitar la factura
            FacturaViewModel viewModel = new FacturaViewModel
            {
                Huesped = nombreCompleto,
                Fecha = DateTime.Now,
                Monto = costo,
                idAsignacion = id,
                Correo = correo,
            };

            //retornamos la vista con el modelo
            return View(viewModel);
        }

        //Generamos el pago y la factura si se desea generar
        [HttpPost]
        public async Task<IActionResult> GenerarPago(FacturaViewModel viewModel, string accion)
        {
            int contNulls = 0;
            //Validamos que se eligio una opcion 
            contNulls += viewModel.PagoEfectivo == true ? 1 : 0;
            contNulls += viewModel.RetiroSinTarjeta == true ? 1 : 0;
            contNulls += viewModel.PagoTransferencia == true ? 1 : 0;


            //Se valida que el modelo no venga vacio en las partes requeridas
            if (viewModel.Huesped != null && viewModel.Monto != null && viewModel.Fecha != null && contNulls == 1)
            {
                string FACTURA = "Pagar y Factura";

                //Llenamos la nueva factura
                Factura factura = new Factura
                {
                    Huesped = viewModel.Huesped,
                    Fecha = viewModel.Fecha,
                    Concepto = viewModel.Concepto,
                    Monto = viewModel.Monto,
                    IdAsignacion = viewModel.idAsignacion,
                };

                //En asignacion, generamos la nueva fecha de pago la cual se dio la factura para llevar un orden
                Asignacion asignacion = new Asignacion
                {
                    IdAsignacion = viewModel.idAsignacion,
                    UltimoPago = viewModel.Fecha,
                };

                //Llamamos a los metodos de asignar ultimo pago y guardar factura
                await _finanzasServices.AsingLastPay(asignacion);
                await _finanzasServices.SaveFactura(factura);

                //Si el cliente eligio generar factura se habilita esta opcion par hacerla
                if (accion == FACTURA)
                {
                    //se retorna la nueva factura
                    // return View("PdfFactura", viewModel);
                    int monto = (int)viewModel.Monto;
                    string montoText = monto.ToWords();

                    //Se crea un nuevo viewmodel por si se necesita actualizar el montotexto
                    FacturaViewModel pdfViewModel = new FacturaViewModel
                    {
                        Huesped = viewModel.Huesped,
                        Fecha = viewModel.Fecha,
                        Monto = viewModel.Monto,
                        MontoTexto = montoText,
                        Concepto = viewModel.Concepto,
                        PagoEfectivo = viewModel.PagoEfectivo,
                        PagoTransferencia = viewModel.PagoTransferencia,
                        RetiroSinTarjeta = viewModel.RetiroSinTarjeta,

                    };
                    string fechaFormateada = viewModel.Fecha.ToString("dd/MM/yyyy");
                    return new ViewAsPdf("PdfFactura", pdfViewModel)
                    {
                        FileName = $"Recibo_{viewModel.Huesped}_{fechaFormateada}.pdf",
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                        PageSize = Rotativa.AspNetCore.Options.Size.A4
                    };
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Olvidaste seleccionar el tipo de pago.";

            return RedirectToAction("GenerarPago", new { id = viewModel.idAsignacion});
        }

        [HttpGet]
        public async Task<IActionResult> Gastos()
        {
            IEnumerable<GastosFijo> gastosFijos = await _finanzasServices.GetGastosFijos();
            IEnumerable<GastosFijo> gastosSemiFijos = await _finanzasServices.GetGastosSemiFijos();

            ViewBag.Fijos = gastosFijos;
            ViewBag.SemiFijos = gastosSemiFijos;

            return View();
        }

        [HttpGet]
        public IActionResult AddGastoFijo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddGastoSemiFijo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGastoFijo(GastoFijoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                GastosFijo gastoFijo = new GastosFijo
                {
                    IdTipoGasto = (int)TipoGasto.Fija,
                    Nombre = viewModel.Nombre,
                    Monto = viewModel.Monto,
                    FechaAviso = viewModel.FechaAviso,
                };

                await _finanzasServices.SaveGastoFijo(gastoFijo);

                return RedirectToAction(nameof(Gastos));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddGastoSemiFijo(GastoSemiFijoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                GastosFijo gastoSemiFijo = new GastosFijo
                {
                    IdTipoGasto = (int)TipoGasto.SemiFija,
                    Nombre = viewModel.Nombre,
                };

                await _finanzasServices.SaveGastoSemiFijo(gastoSemiFijo);

                return RedirectToAction(nameof(Gastos));
            }
            return View(viewModel);

        }


        [HttpGet]
        public async Task<IActionResult> EditGastoFijo(int id)
        {
            GastosFijo gastoFijo = await _finanzasServices.GetGastoById(id);

            GastoFijoViewModel viewModel = new GastoFijoViewModel
            {
                IdGastosFijos = id,
                Nombre = gastoFijo.Nombre,
                Monto = gastoFijo.Monto,
                FechaAviso = gastoFijo.FechaAviso
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> EditGastoSemiFijo(int id)
        {
            GastosFijo gastoSemiFijo = await _finanzasServices.GetGastoById(id);

            GastoSemiFijoViewModel viewModel = new GastoSemiFijoViewModel
            {
                IdGastosFijos = id,
                Nombre = gastoSemiFijo.Nombre,
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditGastoFijo(GastoFijoViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                GastosFijo gastos = new GastosFijo
                {
                    Nombre = viewModel.Nombre,
                    Monto = viewModel.Monto,
                    FechaAviso = viewModel.FechaAviso,
                };
                await _finanzasServices.EditGastoFijo(id, gastos);
                return RedirectToAction(nameof(Gastos));
            }

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditGastoSemiFijo(GastoSemiFijoViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                GastosFijo gastos = new GastosFijo
                {
                    Nombre = viewModel.Nombre,
                };
                await _finanzasServices.EditGastoSemiFijo(id, gastos);
                return RedirectToAction(nameof(Gastos));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            await _finanzasServices.DeleteGasto(id);

            return RedirectToAction(nameof(Gastos));
        }

        [HttpPost]
        public async Task<IActionResult> AddGastoFijoFinal(int id, GastoViewModel viewModel)
        {
            if (id != 0)
            {
                GastosFijo fijo = await _finanzasServices.GetGastoById(id);
                fijo.Pagado = true;

                if (fijo != null)
                {
                    Gasto gasto = new Gasto
                    {
                        IdTipoGasto = fijo.IdTipoGasto,
                        IdGastoFijo = fijo.IdGastosFijos,
                        Monto = (double)fijo.Monto,
                        Nombre = fijo.Nombre,
                        Fecha = viewModel.Fecha,
                    };
                    fijo.FechaPagado = viewModel.Fecha;
                    if (viewModel.ActivarAviso == true)
                    {
                        DateTime fechaActual = DateTime.Now;
                        fijo.FechaAviso = fechaActual.AddMonths(1);
                    }
                    else if (viewModel.FechaAviso != null)
                    {
                        fijo.FechaAviso = viewModel.FechaAviso;

                    }
                    else
                    {
                        DateTime fechaActual = DateTime.Now;
                        fijo.FechaAviso = fechaActual.AddMonths(1);
                    }

                    await _finanzasServices.GenerateGastoFijo(gasto);
                    await _finanzasServices.ChangeGastoFijo(fijo);
                }
            }

            return RedirectToAction(nameof(Gastos));
        }

        [HttpPost]
        public async Task<IActionResult> AddGastoSemiFijoFinal(int id, GastoViewModel viewModel)
        {
            if (id != 0)
            {
                GastosFijo semi = await _finanzasServices.GetGastoById(id);

                if (semi != null)
                {
                    Gasto gasto = new Gasto
                    {
                        IdTipoGasto = semi.IdTipoGasto,
                        IdGastoFijo = semi.IdGastosFijos,
                        Monto = viewModel.Monto,
                        Nombre = semi.Nombre,
                        Fecha = viewModel.Fecha,
                    };

                    semi.Monto = viewModel.Monto;
                    semi.FechaPagado = viewModel.Fecha;

                    await _finanzasServices.GenerateGastoFijo(gasto);
                    await _finanzasServices.ChangeGastoFijo(semi);
                }
            }

            return RedirectToAction(nameof(Gastos));
        }

        [HttpPost]
        public async Task<IActionResult> AddGastoVariable(GastoViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                Gasto gasto = new Gasto
                {
                    IdTipoGasto = (int)TipoGasto.Variable,
                    Monto = viewModel.Monto,
                    Nombre = viewModel.Nombre,
                    Fecha = viewModel.Fecha,
                };
                await _finanzasServices.GenerateGastoFijo(gasto);
            }
            return RedirectToAction(nameof(Gastos));

        }

        [HttpGet]
        public async Task<IActionResult> EditGastoCompleto(int id)
        {
            Gasto gasto = await _finanzasServices.GetGastoCompletoByID(id);

            if (gasto != null)
            {
                int idGastoFijo = 0;
                if (gasto.IdGastoFijo != null)
                {
                    idGastoFijo = gasto.IdGastoFijo.Value;
                }
                GastoViewModel viewModel = new GastoViewModel
                {
                    Nombre = gasto.Nombre,
                    Fecha = gasto.Fecha,
                    Monto = gasto.Monto,
                    idGastoRegistro = idGastoFijo
                };
                return View(viewModel);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> EditGastoCompleto(GastoViewModel viewModel, int id)
        {
            if (ModelState.IsValid == true)
            {
                //Obtenemos la fecha del gasto antes de la modificacion
                Gasto temp = await _finanzasServices.GetGastoCompletoByID(id);
                var fechaTemp = temp.Fecha;
                Gasto gasto = new Gasto
                {
                    Nombre = viewModel.Nombre,
                    Monto = viewModel.Monto,
                    Fecha = viewModel.Fecha,
                };

                await _finanzasServices.EditGasto(gasto, id);

                if (viewModel.idGastoRegistro != 0)
                {
                    GastosFijo fijo = await _finanzasServices.GetGastoById(viewModel.idGastoRegistro);

                    if (fijo != null)
                    {
                        if (fijo.FechaPagado == fechaTemp && fijo.IdTipoGasto != 1)
                        {
                            fijo.FechaPagado = gasto.Fecha;
                            fijo.Monto = gasto.Monto;

                            await _finanzasServices.EditGastoRap(fijo);
                        }
                    }
                }
                return RedirectToAction(nameof(GastosCompletos));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGastoCompleto(int id)
        {
            Gasto temp = await _finanzasServices.GetGastoCompletoByID(id);
            var fechaTemp = temp.Fecha;

            if (temp.IdGastoFijo.HasValue)
            {
                GastosFijo fijo = await _finanzasServices.GetGastoById((int)temp.IdGastoFijo);

                if (fijo != null)
                {
                    if (fijo.FechaPagado == fechaTemp && fijo.IdTipoGasto != 1)
                    {
                        fijo.FechaPagado = null;
                        fijo.Monto = null;

                        await _finanzasServices.EditGastoRap(fijo);
                    }
                }
            }

            await _finanzasServices.DeleteGastoCompleto(id);


            return RedirectToAction(nameof(GastosCompletos));
        }


        public enum TipoGasto
        {
            Fija = 1,
            SemiFija = 2,
            Variable = 3,
        }





    }
}
