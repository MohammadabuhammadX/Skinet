//Supporting classes for order
namespace Core.Entities.OrderAggregate
{
    public class DeliveryMethod : BaseEntity
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
//this going to allow the user to choose what sort of delivery they want and it has a base entity because we want to be able to identify it in our database and we want to be able to retrieve it from our database and we want to be able to update it in our database and we want to be able to delete it from our database so we need an id for it and this is going to be used by our order when the user places an order they can choose what sort of delivery they want and this is going to be used to store the delivery method that the user has chosen for their order.
//so that means there's going to be a table for delivery methods in our database and this is going to be used to store the delivery methods that the user can choose from when they place an order.