using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {

        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(

            IBasketRepository basketRepository,
            IUnitOfWork unitOfWork
            )
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            /*//1- Get basket from the repo, at the point we dont trust what's inside the basket, Well we trust what's in hte basket as in the items and the quantity of items, but what we can't trust is what the price has been set to . we're going to need to go and check that in what is insisde the database 
            // one way to think about this is if you think of a typical shop on a high street and if you go into that shop and you see all the products on the shelf they might have stickers on them to tell you what price they are ,adn you could go and swap those stickers with another product and make it cheaper , but when you get the basket to the counter. the shopkeeper does't trust the sticker he uses a barcode scanner to check the actual price of the product, so even though you swap the stickers it doesn't mean tha you're going ot get cheaper price and we're doing the same thing  
            //2- Get items form the product repo
            //3- Get delivery method from repo --> beacuse we're only going to have the id of the delivery method at this stage
            //4- calc subtotal is based on what we know the price is from items we get from the product repo
            //5-create order
            //save it to database
            //return order*/

            var baskert = await _basketRepository.GetBasketAsync(basketId);

            var items = new List<OrderItem>();
            foreach (var item in baskert.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, null);

            _unitOfWork.Repository<Order>().Add(order);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null; //that means nothing's been saved to the database and if that's the case then we're just going to return null, and let orderController deal with sending back the erorr response  

            //delete the basket --> if the order saved 

            await _basketRepository.DeleteBasketAsync(basketId);

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}
