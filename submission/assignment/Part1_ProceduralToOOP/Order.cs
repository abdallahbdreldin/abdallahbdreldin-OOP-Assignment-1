namespace Part1_ProceduralToOOP
{
    public class Order
    {
        public const int MAX_ORDERS = 100;
        public static int OrderCount { get; private set; } = 0;
        private static readonly List<Order> _orders = new List<Order>();
        public int Id { get; private set; }
        public Customer Customer  { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public bool IsPaid { get; set; }

        public Order(int id, Customer customer,DateTime date)
        {
            Id = id;
            Customer = customer;
            OrderLines = new List<OrderLine>();
            Date = date;
            IsPaid = false;
        }

        public static void CreateOrder(Order order)
        {
            if (!CanAddOrder())
            {
                throw new ArgumentOutOfRangeException("Cannot add more orders. Maximum limit reached.");
            }

            if (FindOrderById(order.Id) != null)
            {
                throw new ArgumentException($"An order with ID {order.Id} already exists.");
            }

            if(order.Customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null.");
            }

            if (Customer.FindCustomerById(order.Customer.Id) == null)
            {
                throw new ArgumentException($"Customer with ID {order.Customer.Id} does not exist.");
            }

            _orders.Add(order);
            IncrementOrderCount();
        }

        public static Order? FindOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void AddLineToOrder(OrderLine orderLine)
        {
            if(IsPaid)
            {
                throw new InvalidOperationException("Cannot add order lines to a paid order.");
            }

            if(OrderLines.Count >= OrderLine.MAX_LINES_PER_ORDER)
            {
                throw new InvalidOperationException("Cannot add more order lines. Maximum limit reached.");
            }

            if(orderLine.Product is null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }

            if(orderLine.Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity must be a positive integer.");
            }

            if(orderLine.Product.Stock < orderLine.Quantity)
            {
                throw new InvalidOperationException($"Not enough stock for product {orderLine.Product.Name}. Available: {orderLine.Product.Stock}, Requested: {orderLine.Quantity}");
            }

            OrderLines.Add(orderLine);
            orderLine.Product.Stock -= orderLine.Quantity;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var line in OrderLines)
            {
                total += line.Product.Price * line.Quantity;
            }
            return total;
        }

        public void MarkAsPaid()
        {   
            if(OrderLines.Count == 0)
            {
                throw new InvalidOperationException("Cannot pay an empty order.");
            }

            IsPaid = true;
        }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {Id}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Is Paid: {IsPaid}");
            Console.WriteLine($"Customer: {Customer.Name} (ID: {Customer.Id})");
            Console.WriteLine($"\n=== PRODUCTS IN ORDER {Id} ===\n");
            foreach (var line in OrderLines)
            {
                Console.WriteLine($"Product ID: {line.Product.Id}, Name: {line.Product.Name}, Price: {line.Product.Price:C}, Quantity: {line.Quantity}");
            }
            Console.WriteLine($"Total: {CalculateTotal():C}");
        }

        public static void GetAllOrders()
        {
            if (_orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }
            Console.WriteLine($"\n=== ORDERS {OrderCount} ===\n");

            foreach (var order in _orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Date: {order.Date}, Is Paid: {order.IsPaid}, Customer: {order.Customer.Name} (ID: {order.Customer.Id})");
                Console.WriteLine($"Total: {order.CalculateTotal():C}");
                Console.WriteLine("Products in Order:");
                foreach (var line in order.OrderLines)
                {
                    Console.WriteLine($"  Product ID: {line.Product.Id}, Name: {line.Product.Name}, Price: {line.Product.Price:C}, Quantity: {line.Quantity}");
                }
                Console.WriteLine();
            }
        }

        public static double GetTotalSalesPaidOnly()
        {
            double totalSales = 0;
            foreach (var order in _orders)
            {
                if (order.IsPaid)
                {
                    totalSales += order.CalculateTotal();
                }
            }
            return totalSales;
        }

        private static bool CanAddOrder()
        {
            return OrderCount < MAX_ORDERS;
        }

        private static void IncrementOrderCount()
        {
            OrderCount++;
        }
    }
}
