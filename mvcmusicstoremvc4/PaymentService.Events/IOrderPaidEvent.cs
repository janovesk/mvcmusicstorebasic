using NServiceBus;

namespace PaymentService.Events
{
    public interface IOrderPaidEvent : IEvent
    {
        string OrderId { get; set; }
        decimal AmountPaid { get; set; }
    }
}
