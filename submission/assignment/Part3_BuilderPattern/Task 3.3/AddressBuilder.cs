namespace Part3_BuilderPattern.Task_3._3
{
    public class AddressBuilder
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _state;
        private readonly string _zipCode;
        private readonly string _country;

        public AddressBuilder(string street, string city, string state, string zipCode, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _country = country;
        }

        public Address Build()
        {
            return new Address
            {
                Street = _street,
                City = _city,
                State = _state,
                ZipCode = _zipCode,
                Country = _country
            };
        }
    }
}
