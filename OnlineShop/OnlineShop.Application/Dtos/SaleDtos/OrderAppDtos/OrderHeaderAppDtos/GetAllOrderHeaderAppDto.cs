﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.SaleDtos.OrderManagementAppDtos.OrderHeaderAppDtos
{
    public class GetAllOrderHeaderAppDto
    {
        public Guid Id { get; set; }
        public long Code { get; set; }
        public string Title { get; set; }
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
        public string SellerUserId { get; set; }
        public string SellerRoleId { get; set; }
        public string BuyerUserId { get; set; }
        public string BuyerRoleId { get; set; }
    }
}