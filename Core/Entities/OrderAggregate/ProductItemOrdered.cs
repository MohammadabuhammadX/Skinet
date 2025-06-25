//Supporting classes for order
namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered  // this is just going to act as a snapshot of our order at time or our product item at the time it was placed , just based on the face that the product name might change the product image might change but we wouldn't want to change it as well inside our order so we don't want a relation between our order and our product item. we're store the values as it was when it was ordered into out database  
    //this class not going to have an id , Because it is going to be owned by the order itself 
    {
        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        public ProductItemOrdered()
        {

        }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }


    }
}
//this is allows us to take a snapshot of the product item that was ordered based on the fact that the product item might change in the future, for example, the product name might change, the product image might change, but we wouldn't want to change it inside our order. So we don't want a relation between our order and our product item. We're going to store the values as they were when it was ordered into our database.
