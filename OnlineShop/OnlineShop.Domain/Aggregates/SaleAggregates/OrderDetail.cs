using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderDetail : MainEntityBase, IDbSetEntity
    {
        //Keys
        public Guid ProductId { get; set; } 
        public Guid OrderHeaderId { get; set; } 

        //Navigation 
        public Product Product { get; set; }
        public OrderHeader OrderHeader { get; set; }

        //Fields
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }


    }
}
