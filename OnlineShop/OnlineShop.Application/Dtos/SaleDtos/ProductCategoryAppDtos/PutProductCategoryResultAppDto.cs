using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.ProductCategoryAppDtos
{
    public class PutProductCategoryResultAppDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        public bool IsActivated { get; set; }
        public long Code { get; set; }
    }
}
