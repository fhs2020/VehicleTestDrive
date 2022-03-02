using ReservationsApi.Models;

namespace ReservationsApi.Interface
{
    public interface IReservation
    {
        Task<List<Reservation>> GetReservations();
        Task UpdateMailStatus(int id);

    }
}
