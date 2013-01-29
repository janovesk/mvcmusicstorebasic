using System.Collections.Generic;
using NServiceBus;

namespace ShoppingCartService.Commands
{
    public class CreatOrderCommand: ICommand 
    {
        public string OrderId { get; set; }
        public string User { get; set; }
        public List<CartItem> CartItems { get; set; } 

        public class CartItem
        {
            public int AlbumId { get; set; }
            public decimal Price { get; set; }
        }
    }
}
