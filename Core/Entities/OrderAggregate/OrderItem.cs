//Supporting classes for order
namespace Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }
        public OrderItem()
        {

        }
        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
//this contains our product item ordered that snapshot of the item we were ordering, the price of the item at the time we ordered it and the quantity of the item that we ordered. This is going to be used by our order when we place an order, we're going to create an order item for each product that we ordered and this is going to be used to store the details of that product that we ordered. So this is going to be used to store the details of each product that we ordered in our order.
//it going to have a base entity because we want to be able to identify it in our database and we want to be able to retrieve it from our database and we want to be able to update it in our database and we want to be able to delete it from our database so we need an id for it.