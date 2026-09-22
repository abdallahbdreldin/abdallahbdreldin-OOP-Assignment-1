namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {
        public const int MAX_LINES_PER_ORDER = 20;
        public int Id { get; private set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
