using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Frameworks.Abstracts
{
    public interface ISimpleEntity :
       IEntity<int>, ITitledEntity, IActiveEntity, IDescriptionEntity
    {
    }
}
