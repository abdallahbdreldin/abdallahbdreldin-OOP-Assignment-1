namespace HotelReservationSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite
    }

    public enum RoomStatus
    {
        Available,
        Booked,
        UnderMaintenance
    }
    public class Room
    {
        public int Number { get; }
        public RoomType Type { get;  }
        public RoomStatus Status { get; private set; } = RoomStatus.Available;
        public decimal NightlyRate { get; private set; }
        public Reservation? Reservation { get; set; }
        public Room(int number, RoomType type, Reservation reservation, decimal nightlyRate)
        {
            Number = number;
            Type = type;
            Reservation = reservation;
            NightlyRate = nightlyRate;
        }

        public void MarkAsBooked()
        {
            if (Status != RoomStatus.Available)
            {
                throw new InvalidOperationException("Room can only be booked if it is available.");
            }
            Status = RoomStatus.Booked;
        }

        public void MarkAsAvailable()
        {
            if (Status != RoomStatus.Booked)
            {
                throw new InvalidOperationException("Room can only be marked as available if it is currently booked.");
            }
            Status = RoomStatus.Available;
        }

        public void StartMaintenance()
        {
            if (Status == RoomStatus.Booked)
            {
                throw new InvalidOperationException("Room cannot be marked as under maintenance if it is currently booked.");
            }
            Status = RoomStatus.UnderMaintenance;
        }

        public void EndMaintenance()
        {
            if (Status != RoomStatus.UnderMaintenance)
            {
                throw new InvalidOperationException("Room can only be marked as available if it is currently under maintenance.");
            }
            Status = RoomStatus.Available;
        }

        public decimal ChangeNightlyRate(decimal newRate)
        {
            if (newRate < 0)
            {
                throw new ArgumentOutOfRangeException("Nightly rate cannot be negative.");
            }
            NightlyRate = newRate;
            return NightlyRate;
        }

        public bool IsAvailableForReservation(DateTime checkInDate, DateTime checkOutDate)
        {
            if (Reservation == null)
            {
                return true;
            }
            
            return !(checkInDate < Reservation.Check_OutDate && checkOutDate > Reservation.Check_InDate);
        }
    }
}
