using System;
using NServiceBus.Saga;
using ShipmentService.Commands;
using ShoppingCartService.Events;

namespace ShipmentService
{
    public class ShipmentSaga : Saga<ShipmentSagaData>,
                             IAmStartedByMessages<IOrderCreatedEvent>, 
                             IAmStartedByMessages<ShipToCommand>
                             
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<IOrderCreatedEvent>(s => s.OrderId, m => m.OrderId);
            ConfigureMapping<ShipToCommand>(s => s.OrderId, m => m.OrderId);
        }

        public void Handle(IOrderCreatedEvent message)
        {
            Data.OrderId = message.OrderId;
            Data.OrderTotalAmount = message.TotalAmount;
            Data.OrderReceived = true;
            CheckReadyToShip();
        }

        public void Handle(ShipToCommand message)
        {
            Data.OrderId = message.OrderId;
            Data.ShipTo(message.Name, message.Address, message.Zip, message.City);
            Console.WriteLine("Received address for order" + message.OrderId);
            CheckReadyToShip();

        }

        private void CheckReadyToShip()
        {
            bool readyToShip = Data.OrderReceived && Data.ShipmentAddressReceived;
            if (readyToShip)
            {
                Bus.SendLocal<ShipViaDHLCommand>(m =>
                                                {
                                                    m.Name = Data.Name;
                                                    m.Address = Data.Address;
                                                    m.City = Data.Address;
                                                    m.OrderId = Data.OrderId;
                                                });
                Console.WriteLine("Shipped order " + Data.OrderId);
                MarkAsComplete();
            }
        }
    }
}
