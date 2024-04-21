using AdminRooms.Models;

namespace AdminRooms.Services.Interfaz
{
    public interface IHuespedService
    {
        Task<IEnumerable<Huesped>> GetGuests();
        Task<Huesped> GetGestById(int id);
        Task<Huesped> AddGuest(Huesped huesped);
        Task UpdateGuest(int id, Huesped huesped);
        Task RemoveGuest(int id);
        Task<IEnumerable<Genero>> GetGenders();
        Task<IEnumerable<Huesped>> GetNoRoomGuest();
        Task DeleteRoomFromGuest(int id);
        Task AddRoomToGuest(int id, int idCuarto);

    }
}
