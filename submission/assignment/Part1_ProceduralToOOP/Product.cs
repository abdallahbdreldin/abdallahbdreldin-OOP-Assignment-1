namespace Part1_ProceduralToOOP
{
    public class Product
    {
        public const int MAX_PRODUCTS = 50;
        public static int ProductCount => _products.Count;
        private static readonly List<Product> _products = new List<Product>();
        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public static void AddProduct(Product product)
        {
            if (!CanAddProduct())
            {
                throw new ArgumentOutOfRangeException("Cannot add more products. Maximum limit reached.");
            }
            else if (FindProductById(product.Id) != null)
            {
                throw new ArgumentException($"Product with ID {product.Id} already exists.");
            }
            _products.Add(product);
        }

        public static Product? FindProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static string GetAllProducts()
        {
            if (_products.Count == 0)
            {
                return "No products found.";
            }
            Console.WriteLine($"\n=== PRODUCTS {ProductCount} ===\n");

            string productList = string.Empty;

            foreach (var product in _products)
            {
                productList += $"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}\n";
            }
            return productList;
        }
        private static bool CanAddProduct()
        {
            return ProductCount < MAX_PRODUCTS;
        }
    }
}
