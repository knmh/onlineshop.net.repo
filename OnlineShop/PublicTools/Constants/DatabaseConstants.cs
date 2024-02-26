using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTools.Constants
{
    public static class DatabaseConstants
    {
        #region [Schemas]
        public static class Schemas
        {

            public const string UserManagement = "UserManagement";
            public const string Sale = "Sale";

        }
        #endregion
        #region [DefaultRoles]
        public static class DefaultRoles
        {

            public const string GodAdminId = "1";
            public const string GodAdminName = "GodAdmin";
            public const string GodAdminNormalizedName = "GODADMIN";
            public const string GodAdminConcurrencyStamp = "1";

            public const string AdminId = "2";
            public const string AdminName = "Admin";
            public const string AdminNormalizedName = "ADMIN";
            public const string AdminConcurrencyStamp = "2";

            public const string SellerId = "3";
            public const string SellerName = "Seller";
            public const string SellerNormalizedName = "SELLER";
            public const string SellerConcurrencyStamp = "3";

            public const string BuyerId = "4";
            public const string BuyerName = "Buyer";
            public const string BuyerNormalizedName = "BUYER";
            public const string BuyerConcurrencyStamp = "4";

        }
        #endregion

        #region [GodAdminUsers]
        public static class GodAdminUsers
        {
            public const string KianmehrUserId = "1";
            public const string KianmehrNationalId = "0020325721";
            public const string KianmehrPassword = "hkhkhk";
            public const string KianmehrUserName = "HediyehKNM";
            public const string KianmehrFirstName = "Hediyeh";
            public const string KianmehrLastName = "Kianmehr";
            public const string KianmehrCellphone = "09120816075";
        }

        #endregion  

        public static class CheckConstraints
        {
            public enum ReturnValueTypes
            {
                ScriptTitle=1,
                ScriptCode=2
                
            }

            #region [SetOnlyNumericalCheckConstraint]
            public static string SetOnlyNumericalCheckConstraint(string propertyTitle, ReturnValueTypes returnValueTypes)
            {
                return returnValueTypes switch
                {
                    (ReturnValueTypes)1 => $"Check_{propertyTitle}_OnlyNumerical",
                    (ReturnValueTypes)2 => $"Check_{propertyTitle}_OnlyNumerical",
                    _ => string.Empty,

                };
            } 
            #endregion

            // write for others ...
        }
    }
    }
