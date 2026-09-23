namespace Part3_BuilderPattern.Task_3._3
{
    public class OrderBuilder
    {
        private readonly DateTime _orderDate;
        private string? _paymentMethod;
        private string? _currency;
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;
        public OrderBuilder(DateTime orderDate)
        {       
            _orderDate = orderDate;
        }

        public OrderBuilder WithPayment(string paymentMethod, string currency)
        {
            _paymentMethod = paymentMethod;
            _currency = currency;

            return this;
        }

        public OrderBuilder WithTotals(decimal subTotal, decimal discountAmount, decimal taxAmount, decimal totalAmount)
        {
            _subTotal = subTotal;
            _discountAmount = discountAmount;
            _taxAmount = taxAmount;
            _totalAmount = totalAmount;

            return this;
        }
        public Order Build()
        {
            return new Order
            {
                OrderDate = _orderDate,
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
