using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Frameworks.Abstracts
{
    public interface ISoftDeletedEntity
    {
        DateTime DateSoftDeletedLatin { get; set; }
        string DateSoftDeletedPersian { get; set; }
        bool IsDeleted { get; set; }
    }
}
