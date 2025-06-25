namespace API.Dtos
{
    public class OrderDto
    {
        public string basketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto shipToAddress { get; set; } // reuse this you'll be pleased to know we won't create a new dto just for the address and the AddressDto already got our validation
        // AddressDto we need to map into the address inside our order aggregate so what we'll also need to do is create a mapping profile for list 
    }
}
