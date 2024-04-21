using AdminRooms.Models;

namespace AdminRooms.Services.Interfaz
{
    public interface ICuartosService
    {
        Task<IEnumerable<Cuarto>> GetAllRooms();
        Task<Cuarto> GetRoom(int id);
        Task<IEnumerable<Cuarto>> GetAvailableRooms();
        Task<IEnumerable<Cuarto>> GetDisableRooms();
        Task UpdateRoom(int id,Cuarto room);
        Task DeleteRoom(int id);
        Task AddRoom(Cuarto room);
        Task AddGuestToRoom(int id, int idHuesped, int idAsignacion);
        Task DeleteUserFromRoom(int id);




    }
}
