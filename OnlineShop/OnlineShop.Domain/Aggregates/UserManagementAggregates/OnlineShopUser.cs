using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.UserManagementAggregates
{
    public class OnlineShopUser : IdentityUser, IActiveEntity, ICreatedEntity, IModifiedEntity, ISoftDeletedEntity, IDbSetEntity
    {
        //Fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // why string?
        public string CellPhone { get; set; }
        public bool CellPhoneConfirmed { get; set; }
        // why string?
        public string NationalId { get; set; }
        public bool NationalIdConfirmed { get; set; }
        public byte[]? Picture { get; set; }
        public string? Location { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string? DateSoftDeletedPersian { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string? DateCreatedPersian { get; set; }
        public bool IsModified { get; set; }
        public DateTime DateModifiedLatin { get; set; }
        public string? DateModifiedPersian { get; set; }
        public DateTime? LastSignInTime { get; set; }
        public DateTime? LastSignOutTime { get; set; }
        

    }
}
 