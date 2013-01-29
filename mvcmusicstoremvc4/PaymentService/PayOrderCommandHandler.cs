using System;
using NServiceBus;
using PaymentService.Commands;
using PaymentService.Events;

namespace PaymentService
{
    public class PayOrderCommandHandler : IHandleMessages<PayOrderCommand>
    {
        public IBus Bus { get; set; }
        public void Handle(PayOrderCommand message)
        {
            decimal amountPaid = 100.0m; //Do some boring 3.party integration here, like a web service or generate a file on ftp somewhere.
            
            Bus.Publish<IOrderPaidEvent>(m =>
                                             {
                                                 m.OrderId = message.OrderId;
                                                 m.AmountPaid = message.AmountToPay;
                                             });
            Console.WriteLine("Paid " + amountPaid + " for order " + message.OrderId);
        }
    }
}
