﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos
{
    public class PostProductResultAppDto
    {
       // public Guid Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }
        public long Code { get; set; }
        public string? EntityDescription { get; set; }
        public bool IsActivated { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string? DateCreatedPersian { get; set; }
        public bool IsModified { get; set; }
        public DateTime DateModifiedLatin { get; set; }
        public string? DateModifiedPersian { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string? DateSoftDeletedPersian { get; set; }
    }
}
