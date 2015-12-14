using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeDesktopApp
{
    public partial class TestManyToMany : Form
    {
        public TestManyToMany()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {

            using (KYLIEEntities ctx = new KYLIEEntities())
            {

                SCAN_ScanType st = new SCAN_ScanType();
                st.Barcode = "DISP2222";
                st.ScanDate = DateTime.Now;
                st.ScanType = 2;



                // Check exists, or add new

                SCAN_AssemblyScans sa = ctx.SCAN_AssemblyScans.FirstOrDefault(f => f.UniqueIdentifier == 1);

                st.SCAN_AssemblyScans.Add(sa);

                //st.SCAN_AssemblyScans.Add(new SCAN_AssemblyScans() { Barcode = "A145-1", EntityID = 145, UniqueIdentifier = 1 });
                //st.SCAN_AssemblyScans.Add(new SCAN_AssemblyScans() { Barcode = "A144-2", EntityID = 144, UniqueIdentifier = 2 });
                //st.SCAN_AssemblyScans.Add(new SCAN_AssemblyScans() { Barcode = "A143-3", EntityID = 143, UniqueIdentifier = 3 });

                //SCAN_ScanType newScan = 
                //newScan.SCAN_AssemblyScans.Add(sa);

                ctx.SCAN_ScanType.Add(st);

                ctx.SaveChanges();

            }

        }
    }
}
