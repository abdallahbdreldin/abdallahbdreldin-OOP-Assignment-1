namespace HotelReservationSystem
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
    }
    public class Reservation
    {
        public int Id { get; }
        public DateTime Check_InDate { get; } = DateTime.Now;
        public DateTime Check_OutDate { get; }
        public Room Room{ get; private set; } = null!;
        public Guest Guest { get; private set; } = null!;
        public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;
        public decimal TotalCost => Room?.NightlyRate * (Check_OutDate- Check_InDate).Days ?? 0;

        public Reservation(int id, DateTime checkInDate, DateTime checkOutDate, Room room, Guest guest)
        {
            if(checkInDate >= checkOutDate)
            {
                throw new ArgumentException("Check-in date must be before check-out date.");
            }
            Id = id;
            Check_InDate = checkInDate;
            Check_OutDate = checkOutDate;
            Room = room;
            Guest = guest;
        }

        public void ConfirmReservation()
        {
            if (Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException("Reservation can only be confirmed from pending status.");
            }
            Status = ReservationStatus.Confirmed;
        }

        public void CheckGuestIn()
        {
            if (Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException("Reservation must be confirmed before checking in.");
            }
            Status = ReservationStatus.CheckedIn;
        }

        public void CheckGuestOut()
        {
            if (Status != ReservationStatus.CheckedIn)
            {
                throw new InvalidOperationException("Guest must be checked in before checking out.");
            }
            Status = ReservationStatus.CheckedOut;
        }

        public void CancelReservation()
        {
            if (Status == ReservationStatus.CheckedIn || Status == ReservationStatus.CheckedOut)
            {
                throw new InvalidOperationException("Cannot cancel a reservation that is already checked in or checked out.");
            }
            Status = ReservationStatus.Pending;
        }

        public static void PrintReservationDetails(Reservation reservation)
        {
            Console.WriteLine($"Reservation ID: {reservation.Id}");
            Console.WriteLine($"Guest: {reservation.Guest.FullName}");
            Console.WriteLine($"Room Number: {reservation.Room.Number}");
            Console.WriteLine($"Check-In Date: {reservation.Check_InDate.ToShortDateString()}");
            Console.WriteLine($"Check-Out Date: {reservation.Check_OutDate.ToShortDateString()}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Total Cost: {reservation.TotalCost:C}");
        }
    }
}
