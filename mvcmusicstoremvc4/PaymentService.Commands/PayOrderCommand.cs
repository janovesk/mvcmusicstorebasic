using NServiceBus;

namespace PaymentService.Commands
{
    public class PayOrderCommand : ICommand
    {
        public string OrderId { get; set; }
        public decimal AmountToPay { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string VisaNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
    }
}
