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
    
    public partial class teOrder
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
    
        public virtual tePerson tePerson { get; set; }
    }
}
