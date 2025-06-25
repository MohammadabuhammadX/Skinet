using Core.Entities.OrderAggregate;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(OrderBy => OrderBy.OrderItems);
            AddInclude(OrderBy => OrderBy.DeliveryMethod);
            AddOrderByDescending(OrderBy => OrderBy.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email)
            : base( o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(OrderBy => OrderBy.OrderItems);
            AddInclude(OrderBy => OrderBy.DeliveryMethod);
        }
    }
}
