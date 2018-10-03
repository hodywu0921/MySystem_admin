using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem_admin.Models
{
    public class VendorViewModel
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public Nullable<System.DateTime> Establishment { get; set; }
        public string LawRepresentative { get; set; }
        public string BusinessLicense { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<decimal> Tariff { get; set; }
        public Nullable<decimal> LY_Renvenue { get; set; }
        public Nullable<decimal> TY_Renvenue { get; set; }
        public Nullable<decimal> SalesAmounts { get; set; }
        public string ManagementType { get; set; }
        public string ManagementCategory { get; set; }
        public string Subsidiary { get; set; }
        public Nullable<bool> IsFTA { get; set; }
        public string System { get; set; }
        public Nullable<int> EmpHeadcount { get; set; }
        public Nullable<bool> IsDiscount { get; set; }
        public string Contact { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTel { get; set; }
        public Nullable<bool> Flag { get; set; }

        //Trade Term
        public Nullable<int> OADate { get; set; }
        public Nullable<bool> IsContact { get; set; }
        public string Currency { get; set; }
        public string PayingMethod { get; set; }
        public Nullable<bool> IsContract { get; set; }

    }
}