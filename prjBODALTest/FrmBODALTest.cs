using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using PrjSApp;
using PrjSInterface;
//using TestOrderData;

namespace prjBODALTest
{
    public partial class FrmBODALTest : Form
    {
         private string m_strErrors;
        private XmlDocument m_xmlWhere;
        private XmlDocument m_xmlSort;
        private XmlDocument m_xmlUserInfo;
        private XmlDocument m_xmlWhereTemp;
        private XmlDocument m_xmlSortTemp;
        private ApplicationManager m_AM;
        private string m_strData;

 
        private PrjSApp.BOAbstract m_BOABS;
        private PrjSInterface.ServiceInterface m_ServiceInterface;



        private void InitDALData()
        {
            DelList(cmTABLEDATAID);


            cmTABLEDATAID.Items.Add("SPC_Book_Stage_Spec_Attribute");
            cmTABLEDATAID.Items.Add("ORD_Attribute");
            cmTABLEDATAID.Items.Add("NC_Main");
            cmTABLEDATAID.Items.Add("CLT_Main");
            cmTABLEDATAID.Items.Add("RPT_SUBFOLDER");
            cmTABLEDATAID.Items.Add("RPT_LIST");
            cmTABLEDATAID.Items.Add("RPT_PARAMS");
             cmTABLEDATAID.Items.Add("SPC_Full");
            cmTABLEDATAID.Items.Add("LD_Full");
            cmTABLEDATAID.Items.Add("LD_Main");
            cmTABLEDATAID.Items.Add("ProductTreeSimple");
            cmTABLEDATAID.Items.Add("TST_StageAttribute");
            cmTABLEDATAID.Items.Add("SelectedElementDataIndex");
            cmTABLEDATAID.Items.Add("FreeTextSearchElementDataIndex");          
            cmTABLEDATAID.Items.Add("TST_Main");
            cmTABLEDATAID.Items.Add("TST_Full");
            cmTABLEDATAID.Items.Add("TST_CS");
            cmTABLEDATAID.Items.Add("FileBufferFromTemp");
            cmTABLEDATAID.Items.Add("FileBufferFromStorage");
            cmTABLEDATAID.Items.Add("Gen_Log");
            cmTABLEDATAID.Items.Add("Gen_ClientAppLog");
            cmTABLEDATAID.Items.Add("Gen_WebServerLog");
            cmTABLEDATAID.Items.Add("USER_Main");
            cmTABLEDATAID.Items.Add("SPC_Book");
            cmTABLEDATAID.Items.Add("Book_Section");
             cmTABLEDATAID.Items.Add("Book_Full");
            cmTABLEDATAID.Items.Add("SPC_Book_Stage");
            cmTABLEDATAID.Items.Add("SPC_Book_Stage_Spec");
            cmTABLEDATAID.Items.Add("SPC_Part");
            cmTABLEDATAID.Items.Add("SPC_Part_Column");
            cmTABLEDATAID.Items.Add("GEN_CodeRow");
            cmTABLEDATAID.Items.Add("ElementDataIndex");
            cmTABLEDATAID.Items.Add("ORD_MAIN");
            cmTABLEDATAID.Items.Add("ORD_CS");
            cmTABLEDATAID.Items.Add("ORD_MAIN_Elements");
            cmTABLEDATAID.Items.Add("PRJ_Product_Relation");
            cmTABLEDATAID.Items.Add("PRJ_ProductTree");
            cmTABLEDATAID.Items.Add("ProductTreeSimple");
            cmTABLEDATAID.Items.Add("ProductTreeFull");
            cmTABLEDATAID.Items.Add("ProductTreeRoot");
            cmTABLEDATAID.Items.Add("APR_Index");
            cmTABLEDATAID.Items.Add("APR_MaterialSource");
            cmTABLEDATAID.Items.Add("APR_MaterialSource_CS");
            cmTABLEDATAID.Items.Add("APR_MaterialSource_Test");
            cmTABLEDATAID.Items.Add("APR_MaterialSource_Documentation");
            cmTABLEDATAID.Items.Add("APR_MaterialSource_Documentation_Files");
            cmTABLEDATAID.Items.Add("APR_Supplier");
            cmTABLEDATAID.Items.Add("APR_Team");
            cmTABLEDATAID.Items.Add("APR_Team_CS");
            cmTABLEDATAID.Items.Add("APR_Team_Test");
            cmTABLEDATAID.Items.Add("APR_Team_Element");
            cmTABLEDATAID.Items.Add("APR_Team_Material");
            cmTABLEDATAID.Items.Add("INT_Main");
            cmTABLEDATAID.Items.Add("INT_Part");
            cmTABLEDATAID.Items.Add("INT_Part_ColumnFormat");
            cmTABLEDATAID.Items.Add("INT_Part_Row");
            cmTABLEDATAID.Items.Add("INT_Docs");
            cmTABLEDATAID.Items.Add("INT_Part_Row_Value");
            cmTABLEDATAID.Items.Add("RPT_Main");
            cmTABLEDATAID.Items.Add("RPT_Part");
            cmTABLEDATAID.Items.Add("RPT_Part_Column");
            cmTABLEDATAID.Items.Add("RPT_Part_Data1");
            cmTABLEDATAID.Items.Add("RPT_Part_Data2");
            cmTABLEDATAID.Items.Add("RPTDEF_Part");
            cmTABLEDATAID.Items.Add("RPTDEF_MAIN");
            cmTABLEDATAID.Items.Add("RPTDEF_Part_Column");
            cmTABLEDATAID.Items.Add("GEN_LanguageStrings");
 
        }

        private void InitBOData()
        {
            
            cmBOs.Items.Add("BOTST");
            cmBOs.Items.Add("DocumentManager");
            cmBOs.Items.Add("LogManager");
            cmBOs.Items.Add("BOPermission");
            cmBOs.Items.Add("BOElement");
            cmBOs.Items.Add("BOSPCParts");
            cmBOs.Items.Add("BOSPCBOOK");
            cmBOs.Items.Add("BOTestOrder");
            cmBOs.Items.Add("BOApproval");
            cmBOs.Items.Add("clsCodeManager");
            cmBOs.Items.Add("BOElement");
            cmBOs.Items.Add("BOInterface");
            cmBOs.Items.Add("BOOrder");
            cmBOs.Items.Add("BOCheckList");
            cmBOs.Items.Add("BOTestPass");
            cmBOs.Items.Add("BOTestPass");
            cmBOs.Items.Add("BOSAP");
            cmBOs.Items.Add("BONC");

            DelList(cmTABLEDATAID);


        }


        private void InitBODALData()
        {
            DelList(cmTABLEDATAID);
            switch (cmBOs.Text)
            {
                case "BOTST":
                    m_BOABS = m_AM.m_BOTst;
                    cmTABLEDATAID.Items.Add("TST_Main");
                      break;

                case "DocumentManager":
                    m_BOABS = m_AM.m_DocumentManager;
                    cmTABLEDATAID.Items.Add("SaveFileBufferInTempFolder");
                    cmTABLEDATAID.Items.Add("MoveTempFileToStorage");
                    break;


                case "LogManager":
                    m_BOABS = m_AM.m_LogManager;
                    cmTABLEDATAID.Items.Add("Gen_WebServerLog");
                    cmTABLEDATAID.Items.Add("Gen_ClientAppLog");
                    break;

                case "BOPermission":
                    m_BOABS = m_AM.m_BOPermission;
                    cmTABLEDATAID.Items.Add("USER_Full");
                    break;

                case "BOElement":
                    m_BOABS = m_AM.m_BOElement;
                    cmTABLEDATAID.Items.Add("ProductTree");
                    cmTABLEDATAID.Items.Add("Product_Relation");
                    cmTABLEDATAID.Items.Add("ElementDataIndex");
                    cmTABLEDATAID.Items.Add("SelectedElementDataIndex");
                    break;

                case "BOSPCParts":
                    m_BOABS = m_AM.m_BOSPCParts;
                    cmTABLEDATAID.Items.Add("Spc_Part");
                    cmTABLEDATAID.Items.Add("SPC_Part_Column");
                    break;

                case "BOSPCBOOK":
                    m_BOABS = m_AM.m_BOSPCBook;
                    cmTABLEDATAID.Items.Add("Book");
                    cmTABLEDATAID.Items.Add("Book_Section");
                    cmTABLEDATAID.Items.Add("Book_Stage");
                    cmTABLEDATAID.Items.Add("Book_StageSpec");
                    cmTABLEDATAID.Items.Add("Book_Full");
                    break;

                case "BOTestOrder":
                    m_BOABS = m_AM.m_BOOrder;
                    cmTABLEDATAID.Items.Add("TestOrder");
                    break;

                case "BOApproval":
                    m_BOABS = m_AM.m_BOApproval;
                    cmTABLEDATAID.Items.Add("APR_Index");
                    cmTABLEDATAID.Items.Add("APR_MaterialSource");
                    cmTABLEDATAID.Items.Add("APR_MaterialSource_CS");
                    cmTABLEDATAID.Items.Add("APR_MaterialSource_Test");
                    cmTABLEDATAID.Items.Add("APR_MaterialSource_Documentation");
                    cmTABLEDATAID.Items.Add("APR_MaterialSource_Documentation_Files");
                    cmTABLEDATAID.Items.Add("Apr_MaterialSource_Full");
                    cmTABLEDATAID.Items.Add("Apr_Team_Full");
                    cmTABLEDATAID.Items.Add("APR_Team");
                    cmTABLEDATAID.Items.Add("APR_Team_CS");
                    cmTABLEDATAID.Items.Add("APR_Team_Test");
                    cmTABLEDATAID.Items.Add("APR_Team_Element");
                    cmTABLEDATAID.Items.Add("APR_Team_Material");

                    break;

                case "clsCodeManager":
                    m_BOABS = m_AM.m_CodeManager;
                    cmTABLEDATAID.Items.Add("GEN_CodeRow");
                    cmTABLEDATAID.Items.Add("GEN_LanguageStrings");
                    cmTABLEDATAID.Items.Add("PRJ_Contractor");
                    cmTABLEDATAID.Items.Add("PRJ_Side");
                    cmTABLEDATAID.Items.Add("PRJ_MaterialOrigin");
                    cmTABLEDATAID.Items.Add("PRJ_SUBSTAGE");
                    cmTABLEDATAID.Items.Add("PRJ_Lab");
                    break;

                case "BOInterface":
                    m_BOABS = m_AM.m_BOInterface;
                    cmTABLEDATAID.Items.Add("INT_Main");
                    cmTABLEDATAID.Items.Add("INT_Part");
                    cmTABLEDATAID.Items.Add("INT_Part_ColumnFormat");
                    cmTABLEDATAID.Items.Add("INT_Part_Row");
                    cmTABLEDATAID.Items.Add("INT_Docs");
                    cmTABLEDATAID.Items.Add("INT_UnUsed");
                    cmTABLEDATAID.Items.Add("Count(INT_Main)");


                    break;
                case "BOOrder":
                    m_BOABS = m_AM.m_BOOrder;
                    cmTABLEDATAID.Items.Add("ORD_MAIN");
                    cmTABLEDATAID.Items.Add("ORD_CS");
                    cmTABLEDATAID.Items.Add("ORD_MAIN_Elements");
                    break;



                case "BOCheckList":
                    m_BOABS = m_AM.m_BOCheckList;
                    cmTABLEDATAID.Items.Add("CheckList_AutoSign");
                    cmTABLEDATAID.Items.Add("CLTPrintOut");
                    cmTABLEDATAID.Items.Add("CheckList_Full");
                    cmTABLEDATAID.Items.Add("AutoFillCLT_PRCRow");
                    cmTABLEDATAID.Items.Add("CheckList_AutoSign");

                    break;

                case "BOTestPass":
                    m_BOABS = m_AM.m_BOTestPass;
                    cmTABLEDATAID.Items.Add("PSS_Main");
                    break;
                case "BOSAP":
                    m_BOABS = m_AM.m_BOSAP;
                    cmTABLEDATAID.Items.Add("SAP_Full");
                    break;
                case "BONC":
                    m_BOABS = m_AM.m_BOSAP;
                    cmTABLEDATAID.Items.Add("NC_Full");
                    cmTABLEDATAID.Items.Add("NCPrintOut");
                    break;
            }
        }


        public FrmBODALTest()
        {
            InitializeComponent();
            m_xmlUserInfo = new XmlDocument();
            m_xmlWhereTemp = new XmlDocument();
            m_xmlSortTemp = new XmlDocument();
            m_AM = new ApplicationManager();

            m_ServiceInterface = new ServiceInterface();
            m_ServiceInterface.m_ApplicationManager = m_AM;

            //m_xmlUserInfo.Load("..\\..\\" + "XmlUserInfo.xml");
             //m_command = m_AM.m_DAM.GetCommand(m_xmlUserInfo);


            InitBOData();
            InitDALData();
        }

        private void btnGOTest_Click(object sender, EventArgs e)
        {

            string strErrors = "";
            txtXMLErrors.Text = "Working .....";

            // XmlDocument xmlData;
            bool bRet = true;
            XmlDocument XmlData = new XmlDocument();
            XmlDocument XmlAttributeString = new XmlDocument();


            lablelProgress1.Visible = false;
            progressBar1.Visible = false;
            int iMaxCount = 100000;
            m_xmlUserInfo.Load(@"c:\Projects\QC V3\TNM-QC-V3\DataServer\prjBODALTest\XmlUserInfo.xml");
            if (rbDAL.Checked) //DAL CAse
            {
                m_strData = "";
                string strWhere = null;
                if (m_xmlWhere != null) strWhere = m_xmlWhere.InnerXml.ToString();
                string strSort = null;
                if (m_xmlSort != null) strSort = m_xmlSort.InnerXml.ToString();

                bRet = m_ServiceInterface.GetData(cmTABLEDATAID.Text, strWhere, strSort, iMaxCount, m_xmlUserInfo.InnerXml.ToString(), out m_strData, out m_strErrors);
                if (txtNewTag.Text != "")
                    m_strData = m_strData.Replace("NewTable", txtNewTag.Text);


            }
            else //Bo Case
            {

                if (rbGet.Checked)
                {
                    string strWhere = null;
                    if (m_xmlWhere != null) strWhere = m_xmlWhere.InnerXml.ToString();

                    string strSort = null;
                    if (m_xmlSort != null) strSort = m_xmlSort.InnerXml.ToString();
                    m_strData = "";
                    bRet = m_ServiceInterface.GetData(cmTABLEDATAID.Text,
                        strWhere,
                        strSort,
                        iMaxCount,
                        m_xmlUserInfo.InnerXml.ToString(),
                        out m_strData,
                        out m_strErrors);
                }
                else //Save
                {
                    if (m_xmlWhere == null && m_strData != "")
                    {
                        m_xmlWhere = new XmlDocument();
                        if (m_strData.ToUpper().IndexOf("ROOT") == -1)
                            m_xmlWhere.LoadXml("<Root>" + m_strData + "</Root>");
                        else
                            m_xmlWhere.LoadXml(m_strData);
                    }

                    if (m_xmlWhere == null)
                    {
                        bRet = true;
                        m_strData = " *** WARNING *** ==> You must select some XMLDATA for this test";

                    }
                    else
                    {
                        string strSort = null;
                        string strxmlData;
                        if (m_xmlSort != null) strSort = m_xmlSort.OuterXml;
                        if (rbSave.Checked) //Single transaction
                        {
                            strxmlData = m_xmlWhere.InnerXml;
                            bRet = m_ServiceInterface.SaveData(cmTABLEDATAID.Text,
                                ref strxmlData, strSort, m_xmlUserInfo.InnerXml, out strErrors);
                        }
                        else
                        {
                            XmlDocument xmlFullData = new XmlDocument();
                            xmlFullData.LoadXml(m_xmlWhere.InnerXml);
                            int iTotal = xmlFullData.FirstChild.ChildNodes.Count;
                            int iCnt = 0;
                            lablelProgress1.Visible = true;

                            progressBar1.Visible = true;
                            progressBar1.Maximum = iTotal;

                            foreach (XmlNode nodeFullData in xmlFullData.FirstChild)
                            {
                                iCnt++;
                                progressBar1.Value = iCnt;
                                lablelProgress1.Text = iCnt.ToString() + " / " + iTotal.ToString();
                                Application.DoEvents();

                                //if (bRet)
                                strxmlData = "<" + xmlFullData.FirstChild.Name + ">" +
                                   nodeFullData.OuterXml +
                                   "</" + xmlFullData.FirstChild.Name + ">";
                                bRet = m_ServiceInterface.SaveData(cmTABLEDATAID.Text,
                                   ref strxmlData,
                                   strSort, m_xmlUserInfo.InnerXml, out strErrors);
                            }


                        }

                        //                        bRet = m_BOABS.SaveData(cmTABLEDATAID.Text, m_xmlWhere, m_xmlSort, m_command, m_xmlUserInfo, out m_xmlErrors);
                    }
                }



            }


            if (bRet)
            {

                if (chkDataShow.Checked == true)
                    txtXMLData.Text = m_strData;
                txtXMLErrors.Text = "Finished succefully";
            }
            else
            {
                txtXMLData.Text = " *** ERROR *** ==>";
                if (rbDAL.Checked)
                {
                    if (m_strErrors != null)
                        txtXMLErrors.Text = m_strErrors;
                    else
                        txtXMLErrors.Text = "Error occured(Return False). No XMLERRORS returned!!";
                }
                else
                    txtXMLErrors.Text = strErrors;
            }

        }

        private void rbBO_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBO.Checked)
            {
                ClearXMLs();
                cmBOs.Visible = true;
                DelList(cmTABLEDATAID);
                rbSave.Visible = true;
                rbSaveMultiTransaction.Visible = true;
                rbGet.Visible = true;
                rbGet.Checked = true;


            }


        }


        private void cmBOs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearXMLs();

            //Load DataId's of selected BO
            InitBODALData();


        }

        private void rbDAL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDAL.Checked)
            {
                InitDALData();
                ClearXMLs();
                cmBOs.Visible = false;
                rbGet.Visible = false;
                rbSave.Visible = false;


            }
        }

        private void cmTABLEDATAID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearXMLs();
            if (rbDAL.Checked)
            {
                //Try to open folder
                try
                {
                    flWhere.Path = ("..\\..\\XMLDAL\\" + cmTABLEDATAID.Text);
                    flSort.Path = ("..\\..\\XMLDAL\\" + cmTABLEDATAID.Text);
                }
                catch 
                {
                 }
            }
            else
                //Try to open folder
                try
                {
                    flWhere.Path = ("..\\..\\XMLBO\\" + cmTABLEDATAID.Text);
                    flSort.Path = ("..\\..\\XMLBO\\" + cmTABLEDATAID.Text);
                }
                catch (Exception ex )
                {
                    txtXMLErrors.Text = ex.Message;
                }




        }

        private void flWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkWhereShow.Checked)
            {
                System.IO.StreamReader SR = new System.IO.StreamReader(flWhere.Path + "\\" + flWhere.FileName);
                txtWhere.Text = SR.ReadToEnd();

                SR.Close();
            }
            m_xmlWhereTemp.Load(flWhere.Path + "\\" + flWhere.FileName);
            m_xmlWhere = m_xmlWhereTemp;
        }

        private void flSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.IO.StreamReader SR = new System.IO.StreamReader(flSort.Path + "\\" + flSort.FileName);
            txtSort.Text = SR.ReadToEnd();
            SR.Close();
            m_xmlSortTemp.Load(flSort.Path + "\\" + flSort.FileName);
            m_xmlSort = m_xmlSortTemp;
        }
        private void ClearXMLs()
        {
            m_xmlWhere = null;
            txtWhere.Text = "";
            m_xmlSort = null;
            txtSort.Text = "";
        }

        private void DelList(ComboBox CB)
        {

            for (int i = CB.Items.Count - 1; i >= 0; i--) CB.Items.RemoveAt(i);
            CB.Text = "-- Select --";
        }

        private void btnSaveXMLData_Click(object sender, EventArgs e)
        {
            if (m_strData != string.Empty)
            {
                System.IO.StreamWriter SR = new System.IO.StreamWriter(txtXMLDATAFilePath.Text);
                SR.Write("<root>" + m_strData + "</root>");
                SR.Close();
            }
            MessageBox.Show("Done");
        }

        private void rbSave_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbGet_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void FrmBODALTest_Load(object sender, EventArgs e)
        {

        }


        //private void btnTestIsInOrder_Click(object sender, EventArgs e)
        //{
        //    //TestRetults tr = new TestRetults(1, m_command);
        //    //SetTestResult srt = new SetTestResult(1516, m_command);
        //    //BOPassTester bpt = new BOPassTester();
        //    //bpt.TestIsInOrder("1093", m_command);

        //    txtXMLDATAFilePath.Text = "";
        //    // clsMoveTestFromIntToTst moveTest = new clsMoveTestFromIntToTst(1993, 35, m_command);
        //    clsMoveTestFromIntToTst moveTest = new clsMoveTestFromIntToTst(5);
        //    MessageBox.Show("עודכנו ");



        //}




    }
}