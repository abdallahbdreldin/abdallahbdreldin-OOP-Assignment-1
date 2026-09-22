namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the OOP Order Management System!\n");
            Console.WriteLine("Seed sample data, show a demo, then open the menu.\n");

            try
            {
              SeedSampleData();
              RunDemoScenario();

             Console.WriteLine(Customer.GetAllCustomers());
              
             Console.WriteLine(Product.GetAllProducts());

             Order.GetAllOrders();

             Console.WriteLine($"\nPaid sales total after demo: {Order.GetTotalSalesPaidOnly()}\n");

             RunInteractiveMenu();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
        }

        static void RunInteractiveMenu()
        {
            int choice = -1;

            while (choice != 0)
            {
                PrintMenu();

                choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(Customer.GetAllCustomers());
                        break;

                    case 2:
                        Console.WriteLine(Product.GetAllProducts());
                        break;

                    case 3:
                        Order.GetAllOrders();
                        break;

                    case 4:
                        Console.Write("Order id: ");
                        int orderId = int.Parse(Console.ReadLine()!);

                        Order? order = Order.FindOrderById(orderId);

                        if (order != null)
                        {
                            order.GetOrderDetails();
                        }
                        else
                        {
                            Console.WriteLine($"Order with ID {orderId} does not exist.");
                        }

                        break;

                    case 5:
                        Console.Write("Order id: ");
                        orderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Customer id: ");
                        int customerId = int.Parse(Console.ReadLine()!);

                        Console.Write("Date (YYYY-MM-DD): ");
                        DateTime date = DateTime.Parse(Console.ReadLine()!);

                        Customer? customer = Customer.FindCustomerById(customerId);

                        if (customer == null)
                        {
                            Console.WriteLine($"Customer with ID {customerId} does not exist.");
                            break;
                        }

                        Order newOrder = new Order(orderId, customer, date);
                        Order.CreateOrder(newOrder);

                        Console.WriteLine($"Order {orderId} created successfully.");
                        break;

                    case 6:
                        Console.Write("Order id: ");
                        orderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Product id: ");
                        int productId = int.Parse(Console.ReadLine()!);

                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine()!);

                        Order? existingOrder = Order.FindOrderById(orderId);
                        Product? product = Product.FindProductById(productId);

                        if (existingOrder == null || product == null)
                        {
                            Console.WriteLine("Order or product does not exist.");
                            break;
                        }

                        existingOrder.AddLineToOrder(
                            new OrderLine(product, quantity)
                        );

                        Console.WriteLine("Product added to order successfully.");
                        break;

                    case 7:
                        Console.Write("Order id: ");
                        orderId = int.Parse(Console.ReadLine()!);

                        Order? orderToPay = Order.FindOrderById(orderId);

                        if (orderToPay != null)
                        {
                            orderToPay.MarkAsPaid();
                            Console.WriteLine($"Order {orderId} marked as paid.");
                        }
                        else
                        {
                            Console.WriteLine($"Order with ID {orderId} does not exist.");
                        }

                        break;

                    case 8:
                        Console.WriteLine(
                            $"Paid sales total: {Order.GetTotalSalesPaidOnly():C2}"
                        );
                        break;

                    case 0:
                        Console.WriteLine("Bye.");
                        break;

                    default:
                        Console.WriteLine("Unknown choice.");
                        break;
                }
            }
        }

        static void SeedSampleData()
        {
            var mona = new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true);
            var omar = new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria");
            var sara = new Customer(3, "Sara Nabil", "sara@example.com", "Giza");

            Customer.AddCustomer(mona);
            Customer.AddCustomer(omar);
            Customer.AddCustomer(sara);

            var usbCable = new Product(101, "USB Cable", 50.0, 100);
            var mouse = new Product(102, "Wireless Mouse", 250.0, 40);
            var keyboard = new Product(103, "Mechanical Keyboard", 1200.0, 15);
            var laptopStand = new Product(104, "Laptop Stand", 400.0, 25);

            Product.AddProduct(usbCable);
            Product.AddProduct(mouse);
            Product.AddProduct(keyboard);
            Product.AddProduct(laptopStand);
        }

        static void RunDemoScenario()
        {
            var mona = new Customer(12, "Ali Ahmed", "mona@example.com", "Cairo", true);
            Customer.AddCustomer(mona);

            var usbCable = new Product(10, "Type-c Cable", 50, 100);
            Product.AddProduct(usbCable);

            var order = new Order(1001, mona, DateTime.Now);
            Order.CreateOrder(order);

            order.AddLineToOrder(new OrderLine(usbCable, 2));

            order.MarkAsPaid();

            order.GetOrderDetails();
        }
    }
}
