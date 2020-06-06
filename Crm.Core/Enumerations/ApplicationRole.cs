using System;
using System.Collections.Generic;
using System.Text;
using Base.Static.Enumerate;

namespace Crm.Core.Enumerations
{
    public static class RoleNames
    {
        public const string Sale = "Sale";
        public const string Manager = "SaleManager";
        public const string Admin = "Admin";       
        public const string Coordinate = "Coordinate";       
        public const string SaleSupervisorView = "SaleSupervisorView";       
        public const string AfterSale = "AfterSale";       
        public const string CustomerCarer = "CustomerCarer";     
        public const string SaleSupervisorEditor = "SaleSupervisorEditor";     
        public const string ListingAcquistion = "ListingAcquistion";     
        
    }
    public static class RoleIds
    {
        /// <summary>
        /// Quyền sale
        /// </summary>
        public const int Sale = 6;
        /// <summary>
        /// Quyền sale manager
        /// </summary>
        public const int Manager = 7;
        /// <summary>
        /// Quyền admin
        /// </summary>
        public const int Admin = 8;
        /// <summary>
        /// Quyền điều phối
        /// </summary>
        public const int Coordinate = 9;
        /// <summary>
        /// Quyền xem của sale supervisor
        /// </summary>
        public const int SaleSupervisorView = 10;
        /// <summary>
        /// Quyền Aftersale
        /// </summary>
        public const int AfterSale = 11;
        /// <summary>
        /// Quyền CSKH
        /// </summary>
        public const int CustomerCarer = 12;
        /// <summary>
        /// Quyền sale supervisor editor
        /// </summary>
        public const int SaleSupervisorEditor = 13;
        /// <summary>
        /// Quyền ListingAcquistion 
        /// </summary>
        public const int ListingAcquistion = 14;
    }
    public class ApplicationRole : Enumeration
    {
    }
}
