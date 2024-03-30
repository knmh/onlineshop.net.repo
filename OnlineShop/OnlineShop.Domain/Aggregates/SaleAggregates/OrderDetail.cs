using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderDetail : MainEntityBase, IDbSetEntity
    {
        //Keys
        public Guid ProductId { get; set; } // Assuming ProductId is the foreign key for Product
        public Guid OrderHeaderId { get; set; } // Assuming OrderHeaderId is the foreign key for OrderHeader

        //Navigation 
        public Product Product { get; set; }
        public OrderHeader OrderHeader { get; set; }

        //Fields
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }


    }
}
