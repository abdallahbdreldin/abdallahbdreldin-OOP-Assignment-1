namespace Part3_BuilderPattern.Task_3._3
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;

        public Address BillingAddress { get; set; } = null!;
        public Address ShippingAddress { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }

    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;
    }

    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Currency { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
