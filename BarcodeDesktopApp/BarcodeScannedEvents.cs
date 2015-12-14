using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace BarcodeDesktopApp
{
    public class BarcodeScannedEvents
    {

        internal Boolean InternalNoteStartScan = false;
        internal Boolean InternalNoteEndScan = false;

        internal void OnProcessStock(object sender, EventArgs e)
        {
            UpdateStockStatus();
        }

        internal void OnBarcodeScanned(object sender, BarcodeEventArgs e)
        {
            BarcodeForm bcInstance = BarcodeForm.GetInstance();
            if (e.Barcode != "9916" && e.Barcode != "9918" && e.Barcode != "9917" && e.Barcode != "9999")
            {
                bcInstance.lbScannedBarcodes.Items.Add(e.Barcode);
                Task.Factory.StartNew(() => LookupBarcode(e.Barcode));
            }
            bcInstance.tbScannedBarcode.Text = "";
        }

        internal void OnProcessScannedCodes(object sender, BarcodeProcessEventArgs e)
        {
            ScanObject scannedObject = null;
            List<ScanObject> scannedObjects = null;

            try
            {
                foreach (var item in BarcodeForm.GetInstance().lbScannedBarcodes.Items)
                {
                    string barcode = (string)item;
                    string switch_on = barcode.Substring(0, 1);
                    switch (switch_on)
                    {
                        case "A": // Assembly scanned

                            switch (e.type)
                            {
                                case BarcodeProcessType.DISPATCH:
                                    if (!InternalNoteStartScan)
                                    {
                                        throw new System.InvalidOperationException("Missed scan of delivery/galvanising note!");
                                    }

                                    if (scannedObject.ScannedObjects == null)
                                    {
                                        scannedObject.ScannedObjects = new List<ScanObjectItem>();
                                    }

                                    if (!barcode.Contains("-"))
                                    {
                                        throw new System.InvalidOperationException(string.Format("Invalid Assembly barcode {0}", barcode));
                                    }

                                    int[] decoded = DecodeAssembyBarcode(barcode);
                                    scannedObject.ScannedObjects.Add(new ScanObjectItem { ObjectBarcode = barcode, ObjectEntityTypeID = decoded[0], UniqueIdentifier = decoded[1] });

                                    break;

                                case BarcodeProcessType.RIGGING:

                                    if (!barcode.Contains("-"))
                                    {
                                        throw new System.InvalidOperationException(string.Format("Invalid Assembly barcode {0}", barcode));
                                    }

                                    ProcessRigging(ref scannedObject, barcode);
                                    break;

                                default:
                                    break;

                            }
                            break;

                        case "G": // Galv Note Scanned

                            if (InternalNoteStartScan == false)
                            {
                                InternalNoteStartScan = true;
                                scannedObject = new ScanObject(BarcodeProcessType.GALVANISING, barcode);
                            }
                            else if (InternalNoteStartScan == true)
                            {
                                if (scannedObject.ScanObjectIdentifier != barcode)
                                {
                                    throw new System.InvalidOperationException("Start and End note scans don't match!");
                                }

                                if (scannedObjects == null)
                                {
                                    scannedObjects = new List<ScanObject>();
                                }
                                scannedObjects.Add(scannedObject);

                                InternalNoteStartScan = false;
                            }
                            break;

                        case "D": // Delivery Note Scanned
                            if (InternalNoteStartScan == false)
                            {
                                InternalNoteStartScan = true;
                                scannedObject = new ScanObject(BarcodeProcessType.DISPATCH, barcode);
                            }
                            else if (InternalNoteStartScan == true)
                            {
                                if (scannedObject.ScanObjectIdentifier != barcode)
                                {
                                    throw new System.InvalidOperationException("Start and End note scans don't match!");
                                }
                                // FinaliseScannedObject(scannedObject);


                                if (scannedObjects == null)
                                {
                                    scannedObjects = new List<ScanObject>();
                                }
                                scannedObjects.Add(scannedObject);

                                InternalNoteStartScan = false;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Barcode Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (e.type == BarcodeProcessType.RIGGING)
                {
                    scannedObjects = new List<ScanObject>();
                    scannedObjects.Add(scannedObject);
                }

                FinaliseScannedObject(scannedObjects);
            }

        }

        /// <summary>
        /// DecodeAssembyBarcode  [0] = EntityID [1] = UniqueIdentifier
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>int[]</returns>
        private int[] DecodeAssembyBarcode(string barcode)
        {
            int[] decoded = new int[2];

            // A1234-3
            char[] delimiterChars = { '-', ',', '.', ':', '\t' };

            string[] splitBarcode = barcode.Split(delimiterChars);
            int EntityID = Int32.Parse(splitBarcode[0].Substring(1, splitBarcode[0].Length - 1));
            int UniqueIdentifier = Int32.Parse(splitBarcode[1]);

            decoded[0] = EntityID;
            decoded[1] = UniqueIdentifier;

            return decoded;
        }

        private void FinaliseScannedObject(List<ScanObject> o)
        {

            List<string> assembliesScanned = new List<string>();
            Boolean canAddAssembly = false;

            try
            {
                using (KYLIEEntities ctx = new KYLIEEntities())
                {
                    foreach (ScanObject scanObject in o)
                    {
                        // Check it doesn't already exist first, else add new.

                        SCAN_ScanType so = ctx.SCAN_ScanType.FirstOrDefault(f => f.Barcode == scanObject.ScanObjectIdentifier);
                        if (so != null)
                        {
                            MessageBox.Show(string.Format("{0} has already been scanned.", so.Barcode));
                            return;
                        }

                        // Now generate a new ScanType object to insert

                        SCAN_ScanType scanType = new SCAN_ScanType();
                        scanType.ScanDate = DateTime.Now;
                        scanType.Barcode = scanObject.ScanObjectIdentifier;
                        scanType.ScanType = (int)Convert.ChangeType(scanObject.ScanObjectType, scanObject.ScanObjectType.GetTypeCode());

                        foreach (ScanObjectItem item in scanObject.ScannedObjects)
                        {
                            if (assembliesScanned.Contains(item.ObjectBarcode))
                            {
                                MessageBox.Show(string.Format("{0} has already been scanned - ignoring.", item.ObjectBarcode));
                                canAddAssembly = false;
                            }
                            else
                            {
                                assembliesScanned.Add(item.ObjectBarcode);
                                canAddAssembly = true;
                            }

                            if (canAddAssembly)
                            {
                                // Has the assmebly already been added to SCAN_AssemblyScans?
                                SCAN_AssemblyScans a = ctx.SCAN_AssemblyScans.FirstOrDefault(f => f.Barcode == item.ObjectBarcode);

                                if (a == null)
                                {
                                    a = new SCAN_AssemblyScans();
                                    a.Barcode = item.ObjectBarcode;
                                    a.EntityID = item.ObjectEntityTypeID;
                                    a.UniqueIdentifier = item.UniqueIdentifier;
                                }
                                scanType.SCAN_AssemblyScans.Add(a);
                            }
                        }

                        ctx.SCAN_ScanType.Add(scanType);

                        ctx.SaveChanges();
                    }
                }
            }

            catch (Exception expn)
            {
                MessageBox.Show(expn.Message);
            }
            finally
            {
                // Should really fire an update stock event here
                UpdateStockStatus();
            }
        }

        private void UpdateStockStatus()
        {

            BarcodeForm.GetInstance().lbStockStatus.Items.Clear();
            BarcodeForm.GetInstance().lbStockStatus.Items.Add(string.Format("Stock Status: {0} on {1}.", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString()));

            using (KYLIEEntities ctx = new KYLIEEntities())
            {

                int dispatchTypeID = (int)Convert.ChangeType(BarcodeProcessType.DISPATCH, BarcodeProcessType.DISPATCH.GetTypeCode());
                int galvanisingTypeID = (int)Convert.ChangeType(BarcodeProcessType.GALVANISING, BarcodeProcessType.GALVANISING.GetTypeCode());

                Dictionary<int, int> entityGalvanisingIDs = new Dictionary<int, int>();
                Dictionary<int, int> entityDispatchIDs = new Dictionary<int, int>();

                // ##########  GALAVANISING #######################

                var galavanisingEntityIDsScanned = (from st in ctx.SCAN_ScanType
                                                    where st.ScanType == galvanisingTypeID
                                                    select st.SCAN_AssemblyScans).ToList();

                foreach (var sList in galavanisingEntityIDsScanned)
                {
                    foreach (var s in sList)
                    {
                        // Must be first time round, so add the first Assembly EntityID
                        if (entityGalvanisingIDs.Count == 0)
                        {
                            entityGalvanisingIDs.Add(s.EntityID, 1);
                        }
                        else
                        {
                            foreach (var a in entityGalvanisingIDs)
                            {
                                if (entityGalvanisingIDs.ContainsKey(s.EntityID))
                                {
                                    entityGalvanisingIDs[s.EntityID] = entityGalvanisingIDs[s.EntityID]+1;
                                    break;
                                }
                                else
                                {
                                    entityGalvanisingIDs.Add(s.EntityID, 1);
                                    break;
                                }
                            }
                        }
                    }

                }

                List<int> distinctScannedGalvanisingEntityIDs = entityGalvanisingIDs.Keys.ToList();
                var descriptionAssemblyGalvanising = ctx.Assemblies.Where(f => distinctScannedGalvanisingEntityIDs.Contains(f.SubComponents_PK)).Select(f => new { id = f.SubComponents_PK, desc = f.SubComponentDescription }).ToList();

                // ###### DISPATCH ##############################

                var dispatchEntityIDsScanned = (from st in ctx.SCAN_ScanType
                                                    where st.ScanType == dispatchTypeID
                                                    select st.SCAN_AssemblyScans).ToList();

                foreach (var sList in dispatchEntityIDsScanned)
                {
                    foreach (var s in sList)
                    {
                        // Must be first time round, so add the first Assembly EntityID
                        if (entityDispatchIDs.Count == 0)
                        {
                            entityDispatchIDs.Add(s.EntityID, 1);
                        }
                        else
                        {
                            foreach (var a in entityDispatchIDs)
                            {
                                if (entityDispatchIDs.ContainsKey(s.EntityID))
                                {
                                    entityDispatchIDs[s.EntityID] = entityDispatchIDs[s.EntityID] + 1;
                                    break;
                                }
                                else
                                {
                                    entityDispatchIDs.Add(s.EntityID, 1);
                                    break;
                                }
                            }
                        }
                    }

                }



                List<int> distinctScannedDispatchEntityIDs = entityDispatchIDs.Keys.ToList();
                var descriptionAssemblyDispatch = ctx.Assemblies.Where(f => distinctScannedDispatchEntityIDs.Contains(f.SubComponents_PK)).Select(f => new { id = f.SubComponents_PK, desc = f.SubComponentDescription }).ToList();






                // ####### DISPLAY #############################

                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("Scanned back from galvanising");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");


                foreach (var d in descriptionAssemblyGalvanising)
                {
                    int cnt = 0;
                    string assyDesc = "";
                    if (d.desc == null)
                    { assyDesc = "Can't find the assembly!!!!"; }
                    else { assyDesc = string.Format("\t{0} {1}", d.desc, entityGalvanisingIDs.TryGetValue(d.id, out cnt) ? cnt : 0); }
                    BarcodeForm.GetInstance().lbStockStatus.Items.Add(assyDesc);
                }

                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("Scanned as dispatched");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");


                foreach (var d in descriptionAssemblyDispatch)
                {
                    int cnt = 0;
                    string assyDesc = "";
                    if (d == null)
                    { assyDesc = "Can't find the assembly!!!!"; }
                    else { assyDesc = string.Format("\t{0} {1}", d.desc, entityDispatchIDs.TryGetValue(d.id, out cnt) ? cnt : 0); }
                    BarcodeForm.GetInstance().lbStockStatus.Items.Add(assyDesc);
                }

                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("Stock level");
                BarcodeForm.GetInstance().lbStockStatus.Items.Add("");

                foreach (var d in descriptionAssemblyGalvanising)
                {
                    int cntGalv = 0;
                    int cntDisp = 0;
                    string assyDesc = "";
                    if (d.desc == null)
                    { assyDesc = "Can't find the assembly!!!!"; }
                    else
                    {
                        int backFromGalv = entityGalvanisingIDs.TryGetValue(d.id, out cntGalv) ? cntGalv : 0;
                        int sentToDispatch = entityDispatchIDs.TryGetValue(d.id, out cntDisp) ? cntDisp : 0;

                        assyDesc = string.Format("\t{0} {1}", d.desc, (backFromGalv-sentToDispatch));
                            }
                    BarcodeForm.GetInstance().lbStockStatus.Items.Add(assyDesc);
                }

            }

        }

        private void LookupBarcode(string barcode)
        {

            string prefix = barcode.Substring(0, 1);

            char[] delimiterChars = { '-', ',', '.', ':', '\t' };

            string[] splitBarcode = barcode.Split(delimiterChars);
            int EntityID = Int32.Parse(splitBarcode[0].Substring(1, splitBarcode[0].Length - 1));
            int id = EntityID;

            string description = string.Empty;

            using (KYLIEEntities ctx = new KYLIEEntities())
            {
                switch (prefix)
                {
                    case "A":
                        description = ctx.Assemblies.Where(f => f.SubComponents_PK == id).Select(f => f.SubComponentDescription).FirstOrDefault();
                        if (description == null)
                        {
                            description = string.Format("Cannot locate the assembly {0}", id);
                        }
                        break;
                    case "G":
                        var galv = ctx.GalvDeliveries.Where(f => f.GalvDelID == id).FirstOrDefault();
                        if (galv != null)
                        {
                            description = string.Format("{0}", galv.GalvDestination);
                        }
                        else
                        {
                            description = string.Format("Cannot locate galvenisng note {}", id);
                        }

                        break;
                    case "D":
                        var disp = ctx.Dispatches.Where(f => f.HutchDispRefID == id).FirstOrDefault();
                        if (disp != null)
                        {
                            var contract = ctx.Contracts.Where(f => f.Contract_PK == disp.ContractID).FirstOrDefault();
                            description = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", contract.ContractName,
                                                                                             disp.Addr1,
                                                                                             disp.Addr2,
                                                                                             disp.Addr3,
                                                                                             disp.Town,
                                                                                             disp.County,
                                                                                             disp.PostCode);
                        }
                        else
                        {
                            description = string.Format("Cannot locate the dispatch note {0}!", id);
                        }
                        break;
                    default:
                        break;
                }
            }


            this.SetText(description);
        }

        private void ProcessRigging(ref ScanObject obj, string barcode)
        {
            if (obj == null)
            {
                obj = new ScanObject(BarcodeProcessType.RIGGING, "N/A");
            }

            if (obj.ScannedObjects == null)
            {
                obj.ScannedObjects = new List<ScanObjectItem>();
            }
            int[] decoded = DecodeAssembyBarcode(barcode);
            obj.ScannedObjects.Add(new ScanObjectItem { ObjectBarcode = barcode, ObjectEntityTypeID = decoded[0], UniqueIdentifier = decoded[1] });

        }

        delegate void SetTextCallback(string text);


        private void SetText(string text)
        {
            if (BarcodeForm.GetInstance().lbDecodedBarcode.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                BarcodeForm.GetInstance().Invoke(d, new object[] { text });
            }
            else
            {
                BarcodeForm.GetInstance().lbDecodedBarcode.Items.Add(text);
            }
        }


    }

    public class BarcodeEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }

    public class BarcodeProcessEventArgs : EventArgs
    {
        public BarcodeProcessType type { get; set; }
    }


    public class ScanObject
    {
        public ScanObject(BarcodeProcessType type, string identifier)
        {
            this.ScanObjectType = type;
            this.ScanObjectIdentifier = identifier;
        }

        public BarcodeProcessType ScanObjectType { get; set; }
        public string ScanObjectIdentifier { get; set; }
        public List<ScanObjectItem> ScannedObjects { get; set; }
    }

    public class ScanObjectItem
    {
        public string ObjectBarcode { get; set; }
        public int ObjectEntityTypeID { get; set; }
        public int UniqueIdentifier { get; set; }
    }


}


