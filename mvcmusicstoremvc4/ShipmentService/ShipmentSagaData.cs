using System;
using NServiceBus.Saga;

namespace ShipmentService
{
    public class ShipmentSagaData : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }

        [Unique]
        public virtual string OrderId { get; set; }
        public virtual decimal OrderTotalAmount { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }
        public virtual bool OrderReceived { get; set; }
        public virtual bool ShipmentAddressReceived { get; set; }

        public virtual void ShipTo(string name, string address, string zip, string city)
        {
            Name = name;
            Address = address;
            Zip = zip;
            City = city;
            ShipmentAddressReceived = true;
        }
    }
}