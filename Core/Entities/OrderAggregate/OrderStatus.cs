using System.Runtime.Serialization;
//Supporting classes for order
namespace Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Received")]
        PaymentReceived,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed,
        //Shipped, 
        //Delivered,
        //Cancelled,
        //Refunded 
    }
}

