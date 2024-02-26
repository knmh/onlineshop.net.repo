using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Frameworks.Abstracts
{
    public interface IModifiedEntity
    {
        bool IsModified { get; set; }
        DateTime DateModifiedLatin { get; set; }
        string DateModifiedPersian { get; set; }
    }
}
