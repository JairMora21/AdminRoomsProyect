using AdminRooms.Models;
using AdminRooms.Models.ViewModel;
using static AdminRooms.Services.Implementacion.FinanzasServices;

namespace AdminRooms.Services.Interfaz
{
    public interface IFinanzasServices
    {
        //Asignacion
        Task<IEnumerable<Asignacion>> GetAllAsignacions();
        Task<Asignacion> GetAsignacionById(int id);
        Task<Asignacion> CreateAssignation(Cuarto cuarto, Huesped huesped);
        Task DeleteAssignation(int id);
        Task AsingLastPay(Asignacion asignacion);
        Task EditDateAsing(int id, Asignacion asignacion);
        Task DeleteDateAsing(int id);

        //Facturas
        Task<Factura> SaveFactura(Factura factura);
        Task<IEnumerable<Factura>> GetFacturas();
        Task<Factura> GetFacturaByID(int id);
        Task<IEnumerable<Factura>> GetFacturaByDate(DateTime firstDate, DateTime lastDate);
        Task EditFactura(int id, Factura factura);
        Task DeleteFactura(int id);

        //Gastos fijo
        Task<GastosFijo> GetGastoById(int id);
        Task DeleteGasto(int id);
        Task<IEnumerable<GastosFijo>> GetGastosFijos();
        Task<IEnumerable<GastosFijo>> GetGastosSemiFijos();
        Task SaveGastoFijo(GastosFijo gastoFijo);
        Task SaveGastoSemiFijo(GastosFijo gastosSemiFijo);
        Task EditGastoFijo (int id,  GastosFijo gastoFijo);
        Task EditGastoSemiFijo(int id, GastosFijo gastoSemiFijo);
        Task EditGastoRap(GastosFijo gastos);
        Task ChangeGastoFijo(GastosFijo gastoFijo);

        //Gastos 
        Task GenerateGastoFijo(Gasto gasto);
        Task<IEnumerable<Gasto>> GetGastos(DateTime firstDate, DateTime lastDate);
        Task<Gasto> GetGastoCompletoByID(int id);
        Task EditGasto(Gasto gasto, int id);
        Task DeleteGastoCompleto(int id);

        //Graficas de gastos y pagos 
        Task<List<MoneyStats>> GetMoneyStatsByDate(DateTime firstDate, DateTime lastDate);
        Task<List<MoneyStats>> GetBillStatsByDate(DateTime firstDate, DateTime lastDate);
        Task<double> DiffMoneyStats(DateTime fechaInicio, DateTime fechaFin);
        Task<double[]> GetMoneyStatsByMonth(DateTime fecha);

    }

}
