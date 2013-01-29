using System;
using NServiceBus;
using ShipmentService.Commands;

namespace ShipmentService
{
    public class ShipViaDHLCommandHandler : IHandleMessages<ShipViaDHLCommand>
    {
        public void Handle(ShipViaDHLCommand message)
        {
           //Do some boring 3.party integration here, like a web service or generate a file on ftp somewhere.
            Console.WriteLine("Order " + message.OrderId + " shipped with DHL.");
        }
    }
}
