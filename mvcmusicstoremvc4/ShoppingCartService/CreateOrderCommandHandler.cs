using System;
using System.Linq;
using NServiceBus;
using ShoppingCartService.Commands;
using ShoppingCartService.Events;

namespace ShoppingCartService
{
    public class CreateOrderCommandHandler : IHandleMessages<CreatOrderCommand>
    {
        private readonly IBus _bus;

        public CreateOrderCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(CreatOrderCommand message)
        {
            var totalAmount = message.CartItems.Sum(ci => ci.Price);
            _bus.Publish<IOrderCreatedEvent>(e =>
                                            {
                                                e.TotalAmount = totalAmount;
                                                e.OrderId = message.OrderId;
                                                e.User = message.User;
                                                e.OrderLines = (from ci in message.CartItems
                                                                select new OrderLine
                                                                        {
                                                                            AlbumId = ci.AlbumId,
                                                                            Price = ci.Price
                                                                        }).ToArray();
                                            });
            WriteDebug(message);
        }

        private static void WriteDebug(CreatOrderCommand message)
        {
            var m = string.Format("Published order {0} for user {1}", message.OrderId, message.User);
            Console.WriteLine(m);
        }
    }
}