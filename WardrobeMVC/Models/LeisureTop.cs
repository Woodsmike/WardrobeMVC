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
    
    public partial class LeisureTop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LeisureTop()
        {
            this.LeisureOutfits = new HashSet<LeisureOutfit>();
        }
    
        public int LeisureTopID { get; set; }
        public string LeisureTopName { get; set; }
        public string LeisureTopPhoto { get; set; }
        public string LeisureTopColor { get; set; }
        public string LeisureTopSeason { get; set; }
        public string LeisureTopOccasion { get; set; }
        public string LeisureTopType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeisureOutfit> LeisureOutfits { get; set; }
    }
}
