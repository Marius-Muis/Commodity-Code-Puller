using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using PdfiumViewer;
using System.IO;
using CCP;
using CCP.Properties;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace SQL_Test
{
    public partial class frmMethodInfo : Form
    {
        DataHandler dh = new DataHandler();
        List<Class1> arrClass1 = new List<Class1>();
        private PrintDocument thisDocument = new PrintDocument();

        PictureBox pbLoad = new PictureBox();   // picturebox to display a loading splash image while the program is loading.
        private delegate void safeCallDel();

        public frmMethodInfo()
        {
            InitializeComponent();
            pbLoad.Size = new Size(tbMethodInfo.Size.Width, tbMethodInfo.Size.Height);
            pbLoad.Image = Resources.loading;
            pbLoad.SizeMode = PictureBoxSizeMode.CenterImage;
            pbLoad.BackColor = Color.Transparent;
            lblCurrDate.Parent = tbpPrintView;
            lblCurrDate.Visible = false;
            txtCode.Focus();
        }

        //  Shows the loading splash screen
        public void showLoad()
        {
            if (this.InvokeRequired)
            {
                Delegate sfd = new safeCallDel(showLoad);
                this.Invoke(sfd);
            }
            else
            {
                this.Controls.Add(pbLoad);
                pbLoad.BringToFront();
                pbLoad.Location = new Point(0, 0);
            }
        }

        //  Hides the loading splash screen
        public void hideLoad()
        {
            if (this.InvokeRequired)
            {
                Delegate sfd = new safeCallDel(hideLoad);
                this.Invoke(sfd);
            }
            else
            {
                this.Controls.Remove(pbLoad);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)     // If the enter key is pressed while focused on txtCode
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl == txtCode)
            {
                Search();
            }
        }

        public void Search()
        {
            try
            {
                Thread tLoadSplashStart = new Thread(() =>
                {
                    showLoad();
                });
                tLoadSplashStart.Start();
                //tLoadSplashStart.Join();
                if (txtCode.Text == null || txtCode.Text == "" || int.TryParse(txtCode.Text, out int stockCode) == false)
                    throw new ArgumentNullException("Please enter a valid commodity code.");
                else
                {
                    dh.testConnection();
                    pullSchematics();
                    string code = txtCode.Text;

                    txtCustomerName.Text = dh.getStockDesc(code);
                    txtWorkCentre.Text = dh.getStockName(code);

                    /*
                     *      Class5 controls
                     */
                    Class5 cl5 = dh.GetMethodDetails(code);
                    txtCoreIron.Text = cl5.CoreIron;
                    txtICBiscuits.Text = cl5.Ic;
                    //  Core making instructions    //////////////////////////////////////////////////////////////////
                    if (cl5.CoreMaking1 != "" && cl5.CoreMaking1 != null)
                        txtCoreMakingInstruction1.Text = cl5.CoreMaking1;
                    else
                        txtCoreMakingInstruction1.Text = "No Core Making Instructions is available for this part!";

                    if (cl5.CoreMaking2 != "" && cl5.CoreMaking2 != null)
                        txtCoreMakingInstruction2.Text = cl5.CoreMaking2;
                    else
                        txtCoreMakingInstruction2.Visible = false;

                    if (cl5.CoreMaking3 != "" && cl5.CoreMaking3 != null)
                        txtCoreMakingInstruction3.Text = cl5.CoreMaking3;
                    else
                        txtCoreMakingInstruction3.Visible = false;

                    if (cl5.CoreMaking4 != "" && cl5.CoreMaking4 != null)
                        txtCoreMakingInstruction4.Text = cl5.CoreMaking4;
                    else
                        txtCoreMakingInstruction4.Visible = false;

                    if (cl5.CoreMaking5 != "" && cl5.CoreMaking5 != null)
                        txtCoreMakingInstruction5.Text = cl5.CoreMaking5;
                    else
                        txtCoreMakingInstruction5.Visible = false;

                    if (cl5.CoreMaking6 != "" && cl5.CoreMaking6 != null)
                        txtCoreMakingInstruction6.Text = cl5.CoreMaking6;
                    else
                        txtCoreMakingInstruction6.Visible = false;

                    if (cl5.CoreMaking7 != "" && cl5.CoreMaking7 != null)
                        txtCoreMakingInstruction7.Text = cl5.CoreMaking7;
                    else
                        txtCoreMakingInstruction7.Visible = false;

                    if (cl5.CoreMaking8 != "" && cl5.CoreMaking8 != null)
                        txtCoreMakingInstruction8.Text = cl5.CoreMaking8;
                    else
                        txtCoreMakingInstruction8.Visible = false;
                    ////////////////////////////////////////////////////////////////////////////
                    txtCastMass.Text = cl5.CastMassKg;
                    txtCastTemp.Text = cl5.CastTemperatureDeg;
                    txtCastTime.Text = cl5.CastTimeSeconds;
                    txtCastingInstructions.Text = cl5.CastingInstruction;
                    txtHotTopping.Text = cl5.HotTopping;
                    //  Knockout instructions   //////////////////////////////////////////////////////
                    if (cl5.KOInstruction1 != null && cl5.KOInstruction1 != "")
                        txtKOInstruction1.Text = cl5.KOInstruction1;
                    else
                        txtKOInstruction1.Text = "No KO Instructions is available for this part!";

                    if (cl5.KOInstruction2 != null && cl5.KOInstruction2 != "")
                        txtKOInstruction2.Text = cl5.KOInstruction2;
                    else
                        txtKOInstruction2.Visible = false;

                    if (cl5.KOInstruction3 != null && cl5.KOInstruction3 != "")
                        txtKOInstruction3.Text = cl5.KOInstruction3;
                    else
                        txtKOInstruction3.Visible = false;

                    if (cl5.KOInstruction4 != null && cl5.KOInstruction4 != "")
                        txtKOInstruction4.Text = cl5.KOInstruction4;
                    else
                        txtKOInstruction4.Visible = false;

                    if (cl5.KOInstruction5 != null && cl5.KOInstruction5 != "")
                        txtKOInstruction5.Text = cl5.KOInstruction5;
                    else
                        txtKOInstruction5.Visible = false;

                    if (cl5.KOInstruction6 != null && cl5.KOInstruction6 != "")
                        txtKOInstruction6.Text = cl5.KOInstruction6;
                    else
                        txtKOInstruction6.Visible = false;
                    /////////////////////////////////////////////////////////////////////////////////
                    txtChromite.Text = cl5.ChromiteInstructio;
                    txtFDYNotes.Text = cl5.FoundryNotes;
                    txtPaintInstructions.Text = cl5.PaintInstructions;
                    txtChills.Text = cl5.ChillsYesNo;
                    txtFettledMass.Text = cl5.FettledMassKg;
                    txtQtyBoxBtm.Text = cl5.MouldingBoxBottom;
                    txtQtyBoxTop.Text = cl5.MouldingBoxTop;
                    txtRunnerCup.Text = cl5.PouringBasin;
                    txtDowngate.Text = cl5.Downgate;
                    txtRunnerBar.Text = cl5.RunnerBar;
                    txtIngates.Text = cl5.Ingates;
                    txtVenting.Text = cl5.Vents;
                    //  Moulding instructions   ////////////////////////////////////////////////////////////////
                    if (cl5.MouldInstruct1 != null && cl5.MouldInstruct1 != "")
                        txtMouldingInstruction1.Text = cl5.MouldInstruct1;
                    else
                        txtMouldingInstruction1.Text = "No Moulding Instructions is available for this part!";

                    if (cl5.MouldInstruct2 != null && cl5.MouldInstruct2 != "")
                        txtMouldingInstruction2.Text = cl5.MouldInstruct2;
                    else
                        txtMouldingInstruction2.Visible = false;

                    if (cl5.MouldInstruct3 != null && cl5.MouldInstruct3 != "")
                        txtMouldingInstruction3.Text = cl5.MouldInstruct3;
                    else
                        txtMouldingInstruction3.Visible = false;

                    if (cl5.MouldInstruct4 != null && cl5.MouldInstruct4 != "")
                        txtMouldingInstruction4.Text = cl5.MouldInstruct4;
                    else
                        txtMouldingInstruction4.Visible = false;

                    if (cl5.MouldInstruct5 != null && cl5.MouldInstruct5 != "")
                        txtMouldingInstruction5.Text = cl5.MouldInstruct5;
                    else
                        txtMouldingInstruction5.Visible = false;

                    if (cl5.MouldInstruct6 != null && cl5.MouldInstruct6 != "")
                        txtMouldingInstruction6.Text = cl5.MouldInstruct6;
                    else
                        txtMouldingInstruction6.Visible = false;

                    if (cl5.MouldInstruct7 != null && cl5.MouldInstruct7 != "")
                        txtMouldingInstruction7.Text = cl5.MouldInstruct7;
                    else
                        txtMouldingInstruction7.Visible = false;

                    if (cl5.MouldInstruct8 != null && cl5.MouldInstruct8 != "")
                        txtMouldingInstruction8.Text = cl5.MouldInstruct8;
                    else
                        txtMouldingInstruction8.Visible = false;
                    ////////////////////////////////////////////////////////////////////////////////
                    //  Closing instrcutions    ////////////////////////////////////////////////////
                    if (cl5.CloseInstruct1 != null && cl5.CloseInstruct1 != "")
                        txtClosingInstruction1.Text = cl5.CloseInstruct1;
                    else
                        txtClosingInstruction1.Text = "No Closing Instructions is available for this part!";

                    if (cl5.CloseInstruct2 != null && cl5.CloseInstruct2 != "")
                        txtClosingInstruction2.Text = cl5.CloseInstruct2;
                    else
                        txtClosingInstruction2.Visible = false;

                    if (cl5.CloseInstruct3 != null && cl5.CloseInstruct3 != "")
                        txtClosingInstruction3.Text = cl5.CloseInstruct3;
                    else
                        txtClosingInstruction3.Visible = false;

                    if (cl5.CloseInstruct4 != null && cl5.CloseInstruct4 != "")
                        txtClosingInstruction4.Text = cl5.CloseInstruct4;
                    else
                        txtClosingInstruction4.Visible = false;

                    if (cl5.CloseInstruct5 != null && cl5.CloseInstruct5 != "")
                        txtClosingInstruction5.Text = cl5.CloseInstruct5;
                    else
                        txtClosingInstruction5.Visible = false;

                    if (cl5.CloseInstruct6 != null && cl5.CloseInstruct6 != "")
                        txtClosingInstruction6.Text = cl5.CloseInstruct6;
                    else
                        txtClosingInstruction6.Visible = false;

                    if (cl5.CloseInstruct7 != null && cl5.CloseInstruct7 != "")
                        txtClosingInstruction7.Text = cl5.CloseInstruct7;
                    else
                        txtClosingInstruction7.Visible = false;

                    if (cl5.CloseInstruct8 != null && cl5.CloseInstruct8 != "")
                        txtClosingInstruction8.Text = cl5.CloseInstruct8;
                    else
                        txtClosingInstruction8.Visible = false;
                    ////////////////////////////////////////////////////////////////////////////////////
                    txtSimulationFileNo.Text = cl5.SimulationFileNo;
                    txtRevisionBy.Text = cl5.MethodRevisionBy;
                    txtApprovalBy.Text = cl5.MethodApprovedBy;
                    txtApprovedYesNo.Text = cl5.MethodApprovedYes;
                    txtRevisionDate.Text = (Convert.ToDateTime(cl5.MethodRevisionDate)).ToShortDateString();
                    txtApprovalDate.Text = (Convert.ToDateTime(cl5.MethodApprovedDate)).ToShortDateString();
                    /*
                     * 
                     */

                    Class7 cl7 = dh.GetProductClass(code);
                    txtProductDescription.Text = cl7.something2;

                    /*
                     *      Class3 controls
                     */
                    Class3 cl3 = dh.GetDescription(code);
                    txtPartDescription.Text = cl3.something1;
                    txtLongDesc.Text = cl3.something2;
                    txtMaterialGrade.Text = cl3.something3;
                    txtFinalMass.Text = String.Format("{0} Kg", cl3.something4.Split('.')[0]);
                    txtBoxSize.Text = cl3.something6;
                    txtPatternPerBoard.Text = cl3.something9;
                    txtTraceNumber.Text = String.Format("{0}", cl3.something8.Split('.')[0]);
                    if (Convert.ToDouble(cl3.something7) == 0)
                        txtInserts.Text = "No";
                    else
                        txtInserts.Text = "Yes";
                    /*
                     * 
                     */

                    txtCommodityCode.Text = code;
                    txtSandMass.Text = string.Format("{0} Kg", dh.getQtyPer(code).Split('.')[0]);

                    /*
                     *      Scrap history
                     */
                    List<Class4> arrClass4 = dh.getScrapRate(txtCode.Text);
                    if (arrClass4 == null)
                    {
                        txtQtyCast.Text = "N/A";
                        txtQtyScrapped.Text = "N/A";
                        txtScrapRate.Text = "N/A";
                    }
                    else
                    {
                        DateTime lastEntryDate = Convert.ToDateTime(arrClass4.Last().DateEntry);
                        Dictionary<string, int> arrReasons = new Dictionary<string, int>();
                        int countCast = 0;
                        int countScrap = 0;

                        foreach (Class4 item in arrClass4)
                        {
                            if (item.DateEntry.AddMonths(6) >= lastEntryDate)
                            {
                                countCast += Convert.ToInt32(item.QtyCast);
                                countScrap += Convert.ToInt32(item.QtyScrapped);
                                if (arrReasons.ContainsKey(item.Description) == false)
                                {
                                    arrReasons.Add(item.Description, Convert.ToInt32(item.QtyScrapped));
                                }
                                else
                                {
                                    if (item.Description != "")
                                        arrReasons[item.Description] = Convert.ToInt32(item.QtyScrapped);
                                }
                            }
                        }
                        txtQtyCast.Text = countCast.ToString();
                        txtQtyScrapped.Text = countScrap.ToString();
                        List<Class6> arrClass6 = new List<Class6>();
                        foreach (string Description in arrReasons.Keys)
                        {
                            if (Description != null && Description != "" && arrReasons[Description] != 0)
                                arrClass6.Add(new Class6(Description, Convert.ToInt32(arrReasons[Description])));
                        }
                        BindingSource bsScrapReasons = new BindingSource();
                        bsScrapReasons.DataSource = arrClass6;
                        dgvScrapReasons.DataSource = null;
                        dgvScrapReasons.DataSource = arrClass6;

                        //Following Code does the Scrap% Calculation (txtQtyCast; txtQtyScrapped; txtScrapRate)
                        double d1, d2;
                        if (double.TryParse(txtQtyScrapped.Text, out d1) && double.TryParse(txtQtyCast.Text, out d2))
                            txtScrapRate.Text = ((d1 / d2)).ToString("#.00 %");
                        else
                            txtScrapRate.Text = "N/A";
                    }

                    arrClass1 = dh.getComponents(txtCode.Text);

                    List<Class1> arrICInsertsDetails = new List<Class1>();
                    List<Class1> arrClosingCoreDetails = new List<Class1>();
                    List<Class1> arrCoresExternalDetails = new List<Class1>();
                    List<Class1> arrInsertsDetails = new List<Class1>();
                    List<Class1> arrCoreIronDetails = new List<Class1>();

                    foreach (Class1 item in arrClass1)
                    {
                        string type = item.Component.Substring(0, 4);
                        if (type.IndexOf("32-3") == 0)
                            arrICInsertsDetails.Add(item);
                        else
                        {
                            if (type.IndexOf("32") == 0)
                                arrClosingCoreDetails.Add(item);
                            else
                            {
                                if (type.IndexOf("4") == 0)
                                    arrCoresExternalDetails.Add(item);
                                else
                                {
                                    if (type.IndexOf("7") == 0)
                                        arrInsertsDetails.Add(item);
                                    else
                                    {
                                        if (type.IndexOf("D") == 0)
                                            arrCoreIronDetails.Add(item);
                                    }
                                }
                            }
                        }

                    }

                    TextBox[] arrCoreIronTxtComponent = { txtCoreIronComponent1, txtCoreIronComponent2, txtCoreIronComponent3, txtCoreIronComponent4, txtCoreIronComponent5, txtCoreIronComponent6 };
                    TextBox[] arrCoreIronTxtDescription = { txtCoreIron1Description, txtCoreIron2Description, txtCoreIron3Description, txtCoreIron4Description, txtCoreIron5Description, txtCoreIron6Description };
                    TextBox[] arrCoreIronTxtQtyPer = { txtCoreIron1Qty, txtCoreIron2Qty, txtCoreIron3Qty, txtCoreIron4Qty, txtCoreIron5Qty, txtCoreIron6Qty };
                    foreach (TextBox txt in arrCoreIronTxtComponent)
                        txt.Visible = false;
                    txtCoreIronComponent1.Visible = true;
                    txtCoreIronComponent1.Text = "No Core Iron";
                    foreach (TextBox txt in arrCoreIronTxtDescription)
                        txt.Visible = false;
                    foreach (TextBox txt in arrCoreIronTxtQtyPer)
                        txt.Visible = false;
                    int CoreIronCounter = 0;
                    foreach (Class1 bc in arrCoreIronDetails)
                    {
                        arrCoreIronTxtComponent[CoreIronCounter].Visible = true;
                        arrCoreIronTxtComponent[CoreIronCounter].Text = bc.Component;
                        arrCoreIronTxtDescription[CoreIronCounter].Visible = true;
                        arrCoreIronTxtDescription[CoreIronCounter].Text = bc.Description;
                        arrCoreIronTxtQtyPer[CoreIronCounter].Visible = true;
                        arrCoreIronTxtQtyPer[CoreIronCounter].Text = bc.QtyPer;
                        CoreIronCounter++;

                    }


                    TextBox[] arrClosingCoreTxtComponent = { txtCoreComponent1, txtCoreComponent2, txtCoreComponent3, txtCoreComponent4, txtCoreComponent5, txtCoreComponent6, txtCoreComponent7 };
                    TextBox[] arrClosingCoreTxtDescription = { txtCoreDescription1, txtCoreDescription2, txtCoreDescription3, txtCoreDescription4, txtCoreDescription5, txtCoreDescription6, txtCoreDescription7 };
                    TextBox[] arrClosingCoreTxtQtyPer = { txtCoreQty1, txtCoreQty2, txtCoreQty3, txtCoreQty4, txtCoreQty5, txtCoreQty6, txtCoreQty7 };
                    foreach (TextBox txt in arrClosingCoreTxtComponent)
                        txt.Visible = false;
                    txtCoreComponent1.Visible = true;
                    txtCoreComponent1.Text = "No Cores";
                    foreach (TextBox txt in arrClosingCoreTxtDescription)
                        txt.Visible = false;
                    foreach (TextBox txt in arrClosingCoreTxtQtyPer)
                        txt.Visible = false;
                    int CoreDetailCounter = 0;
                    foreach (Class1 bc in arrClosingCoreDetails)
                    {
                        arrClosingCoreTxtComponent[CoreDetailCounter].Visible = true;
                        arrClosingCoreTxtComponent[CoreDetailCounter].Text = bc.Component;
                        arrClosingCoreTxtDescription[CoreDetailCounter].Visible = true;
                        arrClosingCoreTxtDescription[CoreDetailCounter].Text = bc.Description;
                        arrClosingCoreTxtQtyPer[CoreDetailCounter].Visible = true;
                        arrClosingCoreTxtQtyPer[CoreDetailCounter].Text = bc.QtyPer;
                        CoreDetailCounter++;
                    }

                    TextBox[] arrInsertTxtComponent = { txtInsertComponent1, txtInsertComponent2, txtInsertComponent3, txtInsertComponent4, txtInsertComponent5 };
                    TextBox[] arrInsertTxtDescription = { txtInsertDescription1, txtInsertDescription2, txtInsertDescription3, txtInsertDescription4, txtInsertDescription5 };
                    TextBox[] arrInsertTxtQtyPer = { txtInsertQtyPer1, txtInsertQtyPer2, txtInsertQtyPer3, txtInsertQtyPer4, txtInsertQtyPer5, };
                    foreach (TextBox txt in arrInsertTxtComponent)
                        txt.Visible = false;
                    txtInsertComponent1.Visible = true;
                    txtInsertComponent1.Text = "No Inserts";
                    foreach (TextBox txt in arrInsertTxtDescription)
                        txt.Visible = false;
                    foreach (TextBox txt in arrInsertTxtQtyPer)
                        txt.Visible = false;
                    int InsertDetailCounter = 0;
                    foreach (Class1 bc in arrInsertsDetails)
                    {
                        arrInsertTxtComponent[InsertDetailCounter].Visible = true;
                        arrInsertTxtComponent[InsertDetailCounter].Text = bc.Component;
                        arrInsertTxtDescription[InsertDetailCounter].Visible = true;
                        arrInsertTxtDescription[InsertDetailCounter].Text = bc.Description;
                        arrInsertTxtQtyPer[InsertDetailCounter].Visible = true;
                        arrInsertTxtQtyPer[InsertDetailCounter].Text = bc.QtyPer;
                        InsertDetailCounter++;
                    }

                    TextBox[] arrFeederTxtComponent = { txtFeederComponent1, txtFeederComponent2, txtFeederComponent3, txtFeederComponent4, txtFeederComponent5, txtFeederComponent6, txtFeederComponent7, txtFeederComponent8 };
                    TextBox[] arrFeederTxtDescription = { txtFeederDescription1, txtFeederDescription2, txtFeederDescription3, txtFeederDescription4, txtFeederDescription5, txtFeederDescription6, txtFeederDescription7, txtFeederDescription8 };
                    TextBox[] arrFeederTxtQtyPer = { txtFeederQtyPer1, txtFeederQtyPer2, txtFeederQtyPer3, txtFeederQtyPer4, txtFeederQtyPer5, txtFeederQtyPer6, txtFeederQtyPer7, txtFeederQtyPer8 };
                    foreach (TextBox txt in arrFeederTxtComponent)
                        txt.Visible = false;
                    txtFeederComponent1.Visible = true;
                    txtFeederComponent1.Text = "No Feeders";
                    foreach (TextBox txt in arrFeederTxtDescription)
                        txt.Visible = false;
                    foreach (TextBox txt in arrFeederTxtQtyPer)
                        txt.Visible = false;
                    int FeederDetailCounter = 0;
                    foreach (Class1 bc in arrCoresExternalDetails)
                    {
                        arrFeederTxtComponent[FeederDetailCounter].Visible = true;
                        arrFeederTxtComponent[FeederDetailCounter].Text = bc.Component;
                        arrFeederTxtDescription[FeederDetailCounter].Visible = true;
                        arrFeederTxtDescription[FeederDetailCounter].Text = bc.Description;
                        arrFeederTxtQtyPer[FeederDetailCounter].Visible = true;
                        arrFeederTxtQtyPer[FeederDetailCounter].Text = bc.QtyPer;
                        FeederDetailCounter++;
                    }

                    TextBox[] arrICInsertsTxtComponent = { txtICInsertComponent1, txtICInsertComponent2, txtICInsertComponent3, txtICInsertComponent4, txtICInsertComponent5 };
                    TextBox[] arrICInsertsTxtDescription = { txtICInsertDescription1, txtICInsertDescription2, txtICInsertDescription3, txtICInsertDescription4, txtICInsertDescription5 };
                    TextBox[] arrICInsertsTxtQtyPer = { txtICInsertQtyPer1, txtICInsertQtyPer2, txtICInsertQtyPer3, txtICInsertQtyPer4, txtICInsertQtyPer5, };
                    foreach (TextBox txt in arrICInsertsTxtComponent)
                        txt.Visible = false;
                    txtICInsertComponent1.Visible = true;
                    txtICInsertComponent1.Text = "No IC Biscuits";
                    foreach (TextBox txt in arrICInsertsTxtDescription)
                        txt.Visible = false;
                    foreach (TextBox txt in arrICInsertsTxtQtyPer)
                        txt.Visible = false;
                    int ICInsertsDetailCounter = 0;
                    foreach (Class1 bc in arrICInsertsDetails)
                    {
                        arrICInsertsTxtComponent[ICInsertsDetailCounter].Visible = true;
                        arrICInsertsTxtComponent[ICInsertsDetailCounter].Text = bc.Component;
                        arrICInsertsTxtDescription[ICInsertsDetailCounter].Visible = true;
                        arrICInsertsTxtDescription[ICInsertsDetailCounter].Text = bc.Description;
                        arrICInsertsTxtQtyPer[ICInsertsDetailCounter].Visible = true;
                        arrICInsertsTxtQtyPer[ICInsertsDetailCounter].Text = bc.QtyPer;
                        ICInsertsDetailCounter++;
                    }

                    //  throws exception "Invalid Object (table Produc_products does not exist)"
                    //txtProductID.Text = dh.getProductID(txtCode.Text);
                    //dgvIncidents.DataSource = dh.getIncidents(code);

                    if (txtApprovedYesNo.Text == "No" || txtApprovedYesNo.Text == "" || txtApprovedYesNo.Text == null)
                    {
                        MessageBox.Show("The method hasn't been approved yet, so it can't be printed.");
                        btnPrint.Enabled = false;
                    }
                    else
                        btnPrint.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Thread tLoadSplashEndException = new Thread(() =>
                {
                    hideLoad();
                });
                tLoadSplashEndException.Start();
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //hideLoad();
            Thread tLoadSplashEnd = new Thread(() =>
            {
                hideLoad();
            });
            tLoadSplashEnd.Start();
        }


        //Form control clearing section
        private void btnClear_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            foreach (Panel pnl in tbpPrintView.Controls.OfType<Panel>())
            {
                foreach (DataGridView dgv in pnl.Controls.OfType<DataGridView>())
                    dgv.DataSource = null;
                foreach (TextBox txt in pnl.Controls.OfType<TextBox>())
                    txt.Clear();
            }
            for (int i = tlpPDFs.Controls.Count - 1; i >= 0; --i)
                tlpPDFs.Controls[i].Dispose();
            tlpPDFs.Controls.Clear();
            tlpPDFs.RowCount = 0;
            txtCode.Clear();

            foreach (Panel pnl in tbpClientView.Controls.OfType<Panel>())
            {
                foreach (TextBox txt in pnl.Controls.OfType<TextBox>())
                    txt.Clear();
                foreach (Panel topmostpnl in pnl.Controls.OfType<Panel>())
                {
                    foreach (TextBox txt in topmostpnl.Controls.OfType<TextBox>())
                        txt.Clear();
                }
            }

            txtCode.Focus();
        }




        //Printing section
        private void ScaleControls(Control c, ref Graphics g, double s)
        {
            //To detach controls for panels, groupboxes etc.
            List<Control> hold = null;

            foreach (Control ctrl in c.Controls)
            {
                if (ctrl is GroupBox || ctrl is Panel || ctrl is TabPage)
                {
                    //backup reference to controls
                    hold = new List<Control>();
                    foreach (Control gctrl in ctrl.Controls)
                    {
                        hold.Add(gctrl);
                    }
                    ctrl.Controls.Clear();
                }

                //backup old location, size and font (see explanation)
                Point oldLoc = ctrl.Location;
                Size oldSize = ctrl.Size;
                Font oldFont = ctrl.Font;

                //calc scaled location, size and font
                ctrl.Location = new Point((int)(ctrl.Location.X * s), (int)(ctrl.Location.Y * s));
                ctrl.Size = new Size((int)(ctrl.Size.Width * s), (int)(ctrl.Height * s));
                ctrl.Font = new Font(ctrl.Font.FontFamily, ctrl.Font.Size * 5,
                                     ctrl.Font.Style, ctrl.Font.Unit);

                //draw this scaled control to hi-res bitmap
                if (ctrl is PictureBox)
                {
                    PictureBox pic = (PictureBox)ctrl;
                    if (pic.Image != null)
                    {
                        using (Bitmap bmp = new Bitmap(ctrl.Size.Width, ctrl.Size.Height))
                        {
                            ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle);
                            g.DrawImage(bmp, ctrl.Location);
                        }
                    }
                }
                else
                {
                    using (Bitmap bmp = new Bitmap(ctrl.Size.Width, ctrl.Size.Height))
                    {
                        ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle);
                        g.DrawImage(bmp, ctrl.Location);
                    }
                }

                //restore control's geo
                ctrl.Location = oldLoc;
                ctrl.Size = oldSize;
                ctrl.Font = oldFont;

                //recursive for panel, groupbox and other controls
                if (ctrl is GroupBox || ctrl is Panel || ctrl is TabPage)
                {
                    foreach (Control gctrl in hold)
                    {
                        ctrl.Controls.Add(gctrl);
                    }
                    ScaleControls(ctrl, ref g, s);
                }
            }
        }

        public int pageCount = 0;
        private void CaptureScreen(object sender, PrintPageEventArgs e)
        {
            double scale = 0;



            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;




            if (pageCount == 0)
            {
                pnlInitControls.Visible = false;
                lblCurrDate.Visible = true;
                lblCurrDate.Text = "Printed on: " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString();
                lblCurrDate.Location = pnlInitControls.Location;
                lblCurrDate.Font = new System.Drawing.Font("Lucida Fax", 10);

                ////this will produce 5x "sharper" print
                //Bitmap memTabClient = new Bitmap(tbpPrintView.Width * 5, tbpPrintView.Height * 5);

                //Graphics g = Graphics.FromImage(memTabClient);
                //ScaleControls(tbpPrintView, ref g, 5);

                //scale = memTabClient.Width / e.PageBounds.Width;

                //e.Graphics.DrawImage(memTabClient, 0, 0,
                //          Convert.ToInt32(memTabClient.Width / scale),
                //          Convert.ToInt32(memTabClient.Height / scale));





                Bitmap memoryImage = new Bitmap(tbpPrintView.Width, tbpPrintView.Height, tbpPrintView.CreateGraphics());
                tbpPrintView.DrawToBitmap(memoryImage, new Rectangle(0, 0, tbpPrintView.Width, tbpPrintView.Height));
                memoryImage = ResizeBitmap(memoryImage, 5);
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)memoryImage.Height / (float)memoryImage.Width);
                e.Graphics.DrawImage(memoryImage, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            }
            else
            {
                tbMethodInfo.SelectedIndex = 1;

                ////this will produce 5x "sharper" print
                //Bitmap memTabPrint = new Bitmap(tbpClientView.Width * 5, tbpClientView.Height * 5);

                //Graphics g = Graphics.FromImage(memTabPrint);
                //ScaleControls(tbpClientView, ref g, 5);

                //scale = memTabPrint.Width / e.PageBounds.Width;

                //e.Graphics.DrawImage(memTabPrint, 0, 0,
                //          Convert.ToInt32(memTabPrint.Width / scale),
                //          Convert.ToInt32(memTabPrint.Height / scale));

                Bitmap memoryImage = new Bitmap(tbpClientView.Width, tbpClientView.Height, tbpClientView.CreateGraphics());
                tbpClientView.DrawToBitmap(memoryImage, new Rectangle(0, 0, tbpClientView.Width, tbpClientView.Height));
                memoryImage = ResizeBitmap(memoryImage, 5);
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)memoryImage.Height / (float)memoryImage.Width);
                e.Graphics.DrawImage(memoryImage, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            }
            pageCount++;
            e.HasMorePages = (pageCount < 2);
        }
        private static Bitmap ResizeBitmap(Bitmap source, int factor)
        {
            Bitmap result = new Bitmap(source.Width * factor, source.Height * factor);
            result.SetResolution(source.HorizontalResolution * factor, source.VerticalResolution * factor);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(source, 0, 0, source.Width * factor, source.Height * factor);
            }
            return result;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pullSchematics();
            pageCount = 0;
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CaptureScreen);
            prtDialog.Document = doc;
            DialogResult result = prtDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    doc.DefaultPageSettings.Landscape = false;
                    doc.Print();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            tbMethodInfo.SelectedIndex = 0;
            pnlInitControls.Visible = true;

            DialogResult dr = MessageBox.Show("New comm-code?", "Printing Complete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                btnClear_Click(this, EventArgs.Empty);
                txtCode.Focus();
            }
        }

        //PDFs on Print View page section
        private void pullSchematics()
        {
            string[] arrFiles = null;
            try
            {
                arrFiles = Directory.GetFiles(@"Z:\MethodPics", txtCode.Text + "*");
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to establish a connection to the network drive containing the schematics.");
            }
            finally
            {
                if (arrFiles != null)
                {
                    tlpPDFs.ColumnStyles.Clear();
                    tlpPDFs.RowStyles.Clear();

                    int numWindows = arrFiles.Count();
                    if (numWindows < 3)
                    {
                        tlpPDFs.RowCount = 1;
                        tlpPDFs.ColumnCount = numWindows;
                    }
                    else
                    {
                        tlpPDFs.RowCount = (int)Math.Ceiling(Convert.ToDecimal((double)numWindows / 3));
                        tlpPDFs.ColumnCount = 3;
                    }

                    for (int i = 0; i < tlpPDFs.ColumnCount; i++)
                    {
                        ColumnStyle c = new ColumnStyle();
                        c.SizeType = SizeType.Percent;
                        c.Width = Convert.ToSingle(Math.Ceiling((decimal)100 / (decimal)tlpPDFs.ColumnCount));
                        tlpPDFs.ColumnStyles.Add(c);
                    }
                    for (int i = 0; i < tlpPDFs.RowCount; i++)
                    {
                        RowStyle r = new RowStyle();
                        r.SizeType = SizeType.Percent;
                        r.Height = Convert.ToSingle(Math.Ceiling((decimal)100 / (decimal)tlpPDFs.RowCount));
                        tlpPDFs.RowStyles.Add(r);
                    }

                    foreach (string path in arrFiles)
                    {
                        if (path.EndsWith(".pdf"))
                        {
                            byte[] data = File.ReadAllBytes(path);
                            PdfiumViewer.PdfDocument doc;
                            using (Stream stream = new MemoryStream(data))
                            {
                                using (doc = PdfiumViewer.PdfDocument.Load(stream))
                                {
                                    PictureBox pict = new PictureBox();
                                    pict.Image = doc.Render(0, 1000, 2000, false);
                                    pict.SizeMode = PictureBoxSizeMode.Zoom;
                                    pict.Dock = DockStyle.Fill;
                                    tlpPDFs.Controls.Add(pict);
                                }
                            }
                            data = null;
                        }
                        else
                        {
                            try
                            {
                                PictureBox pict = new PictureBox();
                                pict.Load(path);
                                pict.SizeMode = PictureBoxSizeMode.Zoom;
                                pict.Dock = DockStyle.Fill;
                                tlpPDFs.Controls.Add(pict);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    arrFiles = null;
                }
            }
        }

        private void frmMethodInfo_Shown(object sender, EventArgs e)
        {
            txtCode.Focus();
        }
    }
}