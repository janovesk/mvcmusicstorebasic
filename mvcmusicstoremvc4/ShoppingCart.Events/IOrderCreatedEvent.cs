using NServiceBus;

namespace ShoppingCartService.Events
{
    public interface IOrderCreatedEvent : IEvent
    {
        string OrderId { get; set; }
        decimal TotalAmount { get; set; }
        string User  { get; set; }
        OrderLine[] OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int AlbumId { get; set; }
        public decimal Price { get; set; }
    }
    
}
