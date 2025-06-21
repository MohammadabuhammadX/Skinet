using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
            
        }
        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; } // because the basket is really is customers thing and it's not something that we're storing in our database then we'll let the customer generate the ID of the basket
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    }
}
