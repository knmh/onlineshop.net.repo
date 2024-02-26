using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.UserManagementAggregates
{
    public class OnlineShopUserActivity : IEntity<Guid>, ITitledEntity, ICreatedEntity, IDescriptionEntity, IDbSetEntity
    {
        //key
        public OnlineShopUserRole OnlineShopUserRole { get; set; }
        //Fields
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string DateCreatedPersian { get; set; }
        public string EntityDescription { get; set; }
    }
}
