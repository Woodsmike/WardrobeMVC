//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormalOutfit
    {
        public int FormalOutfitID { get; set; }
        public int MainOutfitID { get; set; }
        public int FormalTopID { get; set; }
        public int FormalBottomID { get; set; }
        public int FormalShoesID { get; set; }
        public int FormalAccessoryID { get; set; }
    
        public virtual FormalAccessory FormalAccessory { get; set; }
        public virtual FormalBottom FormalBottom { get; set; }
        public virtual FormalSho FormalSho { get; set; }
        public virtual FormalTop FormalTop { get; set; }
        public virtual Outfit Outfit { get; set; }
    }
}
