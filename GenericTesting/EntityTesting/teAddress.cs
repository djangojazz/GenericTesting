//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityTesting
{
    using System;
    using System.Collections.Generic;
    
    public partial class teAddress
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddressExtended { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public System.Data.Entity.Spatial.DbGeography GeographyPoint { get; set; }
    }
}
