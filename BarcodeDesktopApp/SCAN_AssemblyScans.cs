//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcodeDesktopApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class SCAN_AssemblyScans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCAN_AssemblyScans()
        {
            this.SCAN_ScanType = new HashSet<SCAN_ScanType>();
        }
    
        public int AssemblyScanID { get; set; }
        public string Barcode { get; set; }
        public int EntityID { get; set; }
        public int UniqueIdentifier { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCAN_ScanType> SCAN_ScanType { get; set; }
    }
}
