namespace HotelReservationSystem
{
    public class Guest
    {
        public int Id { get;}
        public string FullName { get; } = null!;
        public string PhoneNumber { get; } = null!;
        private List<Reservation> _reservations = new();
        public IReadOnlyList<Reservation> Reservations => _reservations;
        public Guest(int id, string fullName, string phoneNumber)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException(nameof(fullName));
            if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));

            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation.Guest != this)
            {
                throw new InvalidOperationException("Reservation guest does not match this guest.");
            }

            _reservations.Add(reservation);
        }
    }
}