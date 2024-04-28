using OnlineShop.Domain.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Frameworks.Bases
{
    public class SimpleEntityBase :
    ISimpleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
