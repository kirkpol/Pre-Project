//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuggestTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuggestTable()
        {
            this.CauseTables = new HashSet<CauseTable>();
        }
    
        public int ID_Inflamed { get; set; }
        public string Inflamed { get; set; }
        public string Suggest { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauseTable> CauseTables { get; set; }
    }
}