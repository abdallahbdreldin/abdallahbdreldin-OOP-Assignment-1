namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        private readonly int _id;
        private readonly string _customerName;
        private readonly string _customerEmail;
        private readonly string _customerPhone;
        private readonly DateTime _orderDate;
        private string? _billingStreet;
        private string? _billingCity;
        private string? _billingState;
        private string? _billingZipCode;
        private string? _billingCountry;
        private string? _shippingStreet;
        private string? _shippingCity;
        private string? _shippingState;
        private string? _shippingZipCode;
        private string? _shippingCountry;
        private string? _paymentMethod;
        private string? _currency;
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;

        public InvoiceBuilder(int id, string customerName, string customerEmail, string customerPhone, DateTime orderDate)
        {
            _id = id;
            _customerName = customerName;
            _customerEmail = customerEmail;
            _customerPhone = customerPhone;
            _orderDate = orderDate;
        }

        public InvoiceBuilder WithBillingAddress(string street, string city, string state, string zipCode, string country)
        {
            _billingStreet = street;
            _billingCity = city;
            _billingState = state;
            _billingZipCode = zipCode;
            _billingCountry = country;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(string street, string city, string state, string zipCode, string country)
        {
            _shippingStreet = street;
            _shippingCity = city;
            _shippingState = state;
            _shippingZipCode = zipCode;
            _shippingCountry = country;
            return this;
        }

        public InvoiceBuilder WithPayment(string paymentMethod, string currency)
        {
            _paymentMethod = paymentMethod;
            _currency = currency;
            return this;
        }

        public InvoiceBuilder WithTotals(decimal subTotal, decimal discountAmount, decimal taxAmount)
        {
            _subTotal = subTotal;
            _discountAmount = discountAmount;
            _taxAmount = taxAmount;
            _totalAmount = subTotal - discountAmount + taxAmount;
            return this;
        }

        public Invoice Build()
        {
            return new Invoice
            {
                InvoiceId = _id,
                CustomerName = _customerName,
                CustomerEmail = _customerEmail,
                CustomerPhone = _customerPhone,
                OrderDate = _orderDate,
                BillingStreet = _billingStreet,
                BillingCity = _billingCity,
                BillingState = _billingState,
                BillingZipCode = _billingZipCode,
                BillingCountry = _billingCountry,
                ShippingStreet = _shippingStreet,
                ShippingCity = _shippingCity,
                ShippingState = _shippingState,
                ShippingZipCode = _shippingZipCode,
                ShippingCountry = _shippingCountry,
                PaymentMethod = _paymentMethod,
                Currency = _currency,
                SubTotal = _subTotal,
                DiscountAmount = _discountAmount,
                TaxAmount = _taxAmount,
                TotalAmount = _totalAmount
            };
        }
    }
}
