namespace Part1_ProceduralToOOP
{
    public class Customer
    {
        public const int MAX_CUSTOMERS = 50;
        public static int CustomerCount => _customers.Count;
        private static readonly List<Customer> _customers = new List<Customer>();

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public bool IsVip { get; set; } = false;

        public Customer(int id, string name, string email, string city, bool isVip = false)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public static void AddCustomer(Customer customer)
        {
            if (!CanAddCustomer())
            {
                throw new ArgumentOutOfRangeException("Cannot add more customers. Maximum limit reached.");
            }

            if(FindCustomerById(customer.Id) != null)
            {
                throw new ArgumentException($"Customer with ID {customer.Id} already exists.");
            }
            _customers.Add(customer);
        }

        public static Customer? FindCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public static string GetAllCustomers()
        {
            if (_customers.Count == 0)
            {
                return "No customers found.";
            }
            Console.WriteLine($"\n=== CUSTOMERS {CustomerCount} ===\n");

            string customerList = string.Empty;

            foreach (var customer in _customers)
            {
                customerList += $"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, City: {customer.City}, VIP: {customer.IsVip}\n";
            }
            return customerList;
        }

        private static bool CanAddCustomer()
        {
            return CustomerCount < MAX_CUSTOMERS;
        }
    }
}
