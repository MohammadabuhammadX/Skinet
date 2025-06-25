using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress,
            DeliveryMethod deliveryMethod, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            //OrderDate = orderDate; // is something that we're setting inside the class as well 
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            SubTotal = subTotal;
            //Status = status;  // we're already setting inside our class
            //PaymentIntentId = paymentIntentId;
        }
        public Order()
        {
            
        }
        public string BuyerEmail { get; set; } // this is what we're going to use to retrieve the list of orders for a particular user we're not going to relate our order to identities, which is in a separate context boundary 

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }

    }
}
