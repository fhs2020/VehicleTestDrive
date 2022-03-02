using Microsoft.EntityFrameworkCore;

using ReservationsApi.Interface;
using ReservationsApi.Models;

using System.Net;
using System.Net.Mail;

using VehicleApi.Data;

namespace ReservationsApi.Services
{
    public class ReservationService : IReservation
    {
        private ApiDbContext dbContext;

        public ReservationService()
        {
            dbContext = new ApiDbContext();
        }

        public Task<List<Reservation>> GetReservations()
        {

            return dbContext.Reservations.ToListAsync();
        }

        public async Task UpdateMailStatus(int id)
        {
            var reservationResult = await dbContext.Reservations.FindAsync(id);

            if (reservationResult == null && reservationResult.IsMailSent == false)
            {
                var smtpCliente = new SmtpClient("smtp.live.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("beatyourcitation@outlook.com", "baller100"),
                    EnableSsl = true
                };

                smtpCliente.Send("beatyourcitation@outlook.com", reservationResult.Email, "Vehicle Test Drive", "Your test drive is reserved with success!");

                reservationResult.IsMailSent = true;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
