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
    
    public partial class SCAN_ScanType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCAN_ScanType()
        {
            this.SCAN_AssemblyScans = new HashSet<SCAN_AssemblyScans>();
        }
    
        public int ScanID { get; set; }
        public int ScanType { get; set; }
        public System.DateTime ScanDate { get; set; }
        public string Barcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCAN_AssemblyScans> SCAN_AssemblyScans { get; set; }
    }
}
