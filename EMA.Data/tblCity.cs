//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMA.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCity()
        {
            this.tblStudents = new HashSet<tblStudent>();
        }
    
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        public virtual tblCountry tblCountry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
