using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.UserManagementAggregates
{
    public class OnlineShopRole : IdentityRole, IDbSetEntity
    {
    }
}
