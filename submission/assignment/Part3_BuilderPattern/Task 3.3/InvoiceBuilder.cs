namespace Part3_BuilderPattern.Task_3._3
{
    public class InvoiceBuilder
    {
        private readonly int _id;
        private readonly string _customerName = null!;
        private readonly string _customerEmail = null!;
        private readonly string _customerPhone = null!;
        private Order? _order;
        private Address? _billingAddress;
        private Address? _shippingAddress;
        public InvoiceBuilder(int id, string customerName, string customerEmail, string customerPhone)
        {
            _id = id;
            _customerName = customerName;
            _customerEmail = customerEmail;
            _customerPhone = customerPhone;
        }

        public InvoiceBuilder WithOrder(Order order)
        {
            _order = order;
            return this;
        }

        public InvoiceBuilder WithBillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public Invoice Build()
        {
            if (_order == null)
            {
                throw new InvalidOperationException("Order must be set before building the invoice.");
            }
            if (_billingAddress == null)
            {
                throw new InvalidOperationException("Billing address must be set before building the invoice.");
            }
            if (_shippingAddress == null)
            {
                throw new InvalidOperationException("Shipping address must be set before building the invoice.");
            }
            return new Invoice
            {
                InvoiceId = _id,
                CustomerName = _customerName,
                CustomerEmail = _customerEmail,
                CustomerPhone = _customerPhone,
                Order = _order,
                BillingAddress = _billingAddress,
                ShippingAddress = _shippingAddress
            };
        }
    }
}
