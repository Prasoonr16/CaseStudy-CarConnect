using DAO;
using Entity;

namespace HelperLibrary
{
    public class ReservationServiceHelper
    {
        ReservationService reservationService = null;
        public ReservationServiceHelper()
        {
            reservationService = new ReservationService();
        }

        public Reservation getReservationById(int reservationId)
        {
            return reservationService.GetReservationById(reservationId);
        }

        public List<Reservation> getReservationByCustomerId(int customerId)
        {
            return reservationService.GetReservationByCustomerId(customerId);
        }

        public bool createReservation(Reservation reservation)
        {
            return reservationService.CreateReservation(reservation);
        }

        public bool updateReservation(int reservationId, Reservation reservation)
        {
            return reservationService.UpdateReservation(reservationId, reservation);
        }
        public bool cancelReservation(int reservationId)
        {
            return reservationService.CancelReservation(reservationId);
        }
    }
}
