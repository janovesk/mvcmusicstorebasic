using NServiceBus;

namespace ShipmentService.Commands
{
    public class ShipToCommand : ICommand
    {
        public virtual string OrderId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }
    }
}
