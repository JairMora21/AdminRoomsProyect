using AdminRooms.Models;

namespace AdminRooms.Services.Interfaz
{
    public interface IResidenciasService
    {
        Task<IEnumerable<Casa>> GetHomes();
        Task<Casa> GetHomeById(int id);
        Task<Casa> AddHome(Casa casa);
        Task UpdateHome(int id, Casa casa);
        Task RemoveHome(int id);


        Task<Usuario> GetUsuario(string user, string password);


    }
}
