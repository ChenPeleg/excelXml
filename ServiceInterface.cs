using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Transactions;
using System.Configuration;


//using PrjSInterface

namespace PrjSInterface
{
    public class ServiceInterface : MarshalByRefObject
    {
        public PrjSApp.ApplicationManager m_ApplicationManager;

        public ServiceInterface()
        {
            m_ApplicationManager = new PrjSApp.ApplicationManager();
        }

        public bool GetData(string p_DataId,
                            string p_XmlWhere,
                            string p_XmlSort,
                            int p_MaxCount,
                            string p_XmlUserInfo,
                            out string p_XmlData,
                            out string p_XmlErrors)
        {
            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;

            XmlDocument XmlWhere = null;
            XmlDocument XmlSort = null;
            XmlDocument XmlUserInfo = null;
            XmlDocument XmlData = null;
            XmlDocument XmlErrors = null;
            p_XmlErrors = null;
            p_XmlData = null;

            try
            {
                if (p_XmlUserInfo != null)
                {

                    XmlUserInfo = new XmlDocument();
                    XmlUserInfo.LoadXml(p_XmlUserInfo);
                }
                else XmlUserInfo = null;

                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId, "p_XmlWhere", p_XmlWhere, //String values
                    "p_XmlSort", p_XmlSort, null, null, //String values
                    "p_MaxCount", p_MaxCount, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    XmlUserInfo,
                    null  //Exception Values
                    );

                if (p_XmlWhere != null)
                {
                    XmlWhere = new XmlDocument();
                    XmlWhere.LoadXml(p_XmlWhere);
                }
                else XmlWhere = null;
                if (p_XmlSort != null)
                {
                    XmlSort = new XmlDocument();
                    XmlSort.LoadXml(p_XmlSort);
                }
                else XmlSort = null;


                //open command
                SqlCommand command;
                command = m_ApplicationManager.m_DAM.GetCommand(XmlUserInfo);
                PrjSApp.BOAbstract m_BOAbstract = null;

                string sDataId = p_DataId;

                switch (sDataId)
                {
                    case "Book":
                    case "Book_Section":
                    case "Book_Stage":
                    case "Book_StageSpec":
                    case "Book_Full" /*"Book_Spec"*/ :
                    case "SpecTree_Full":
                    case "PRJ_Stage_Material":
                    case "SPC_Book_Stage_Spec_Attribute":
                    {
                            m_BOAbstract = m_ApplicationManager.m_BOSPCBook;
                            break;
                    }
                    case "CLT_Elements" /*"CheckList"*/ :
                    case "CLT_CS" /*"CheckList"*/ :
                    case "CLT_Main" /*"CheckList"*/ :
                    case "CLT_Test" /*"CheckList"*/ :
                    case "CLT_Certificates":
                    case "CLT_PRCRow":
                    case "CLT_Open":
                    case "CLT_OpenMonthly":
                    case "CLT_ListOpen":
                    case "CLT_ListNoTest":
                    case "CLT_ListToSign":
                    case "CLT_CountToSign":
                    case "CLT_TestBriefRow":
                    case "CLT_ForSign":


                        {
                            m_BOAbstract = m_ApplicationManager.m_BOCheckList;
                            break;
                        }
                    case "Doc_Elements":
                    case "Doc_Documentation":
                    case "Doc_Main":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BODoc;
                            break;
                        }
                    case "Spc_Part" /*"Spc_Part"*/ :
                    case "SPC_Main":
                    case "PRC_Main":
                    case "PRC_TemplateRow":
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_BOSPCParts;
                            break;
                        }
                    case "Count(SelectedElementDataIndex)":
                    case "SelectedElementDataIndex":
                    case "Count(FreeTextSearchElementDataIndex)":
                    case "FreeTextSearchElementDataIndex":
                    case "Product":
                    case "ProductTreeSimple":
                    case "ProductTreeFull":
                    case "Product_Relation":
                    case "ElementDataIndex":
                    case "GeoElementsNames":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOElement;
                            break;
                        }
                    case "ORD_MAIN_Elements":
                    case "ORD_CS":
                    case "ORD_Attribute":
                    case "ORD_Enumerator":
                    case "TestOrder":
                    case "ORD_MAIN":
                    case "ORD_Full":
                    case "ORDDEF_StageAttribute":
                    case "ORD_StageAttribute":
                    case "Count(ORD_ExtendedWithProductID)":
                    case "ORD_ExtendedWithProductID":
                    case "ORDCancelData":

                        {
                            m_BOAbstract = m_ApplicationManager.m_BOOrder;
                            break;
                        }
                    case "SPC_Part":
                    case "SPC_Part_Column" /*"spc_part_column"*/ :
                    case "SPC_Book_Stage":
                    case "SPC_Book_Stage_SubStage":
                    case "SPC_Book_Stage_Spec":
                    case "SPC_Full":
                    case "SPC_Stage":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOSPCParts;
                            break;
                        }
                    case "GEN_CodeRow" /*"GEN_CodeRow"*/ :
                    case "GEN_LanguageStrings":
                    case "PRJ_MaterialOrigin":
                    case "PRJ_Lab":
                    case "PRJ_SUBSTAGE":
                    case "PRJ_Side":
                    case "Prj_Material":
                    case "MaterialName":
                    case "PRJ_Contractor":
                    case "GEN_CodeHead":
                    case "GEN_CodeRowReal":
                        {
                            m_BOAbstract = m_ApplicationManager.m_CodeManager;
                            break;
                        }

                     case "APR_MaterialSource":
                    case "APR_MaterialSource_CS":
                    case "APR_MaterialSource_Certificates":
                    case "APR_MaterialSource_Documentation":
                    case "APR_MaterialSource_Elements":
                    case "APR_MaterialSource_Documentation_Files":
                    case "Apr_MaterialSource_Full":
                    case "Apr_Team_Full":
                    case "APR_Team":
                    case "APR_Team_CS":
                    case "APR_Team_Test":
                    case "APR_Team_Element":
                    case "APR_Team_Material":
                    case "APR_Team_Documentation":
                    case "Apr_Contractor_Full":
                    case "APR_Contractor":
                    case "APR_Contractor_Elements":
                    case "APR_Contractor_Documentation":

                        {
                            m_BOAbstract = m_ApplicationManager.m_BOApproval;
                            break;
                        }
                    case "ASM_Main":
                    case "ASM_Elements":
                    case "ASM_Documentation":
                    case "ASM_CS":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOASM;
                            break;
                        }
                    case "vINT_Docs":
                    case "INT_Main":
                    case "INT_Part":
                    case "vint_part":
                    case "INT_Part_ColumnFormat":
                    case "INT_Part_Row":
                    case "INT_Part_Row_Value":
                    case "INT_Docs":
                    case "INT_Full":
                    case "INT_UseCount":
                    case "INT_UnUsedOnly":
                    case "INT_UnUsed":
                    case "vINT_MainUnUsedOnly":
                    case "Count(INT_Main)":
                    case "Count(INT_UseCount)":
                    case "Count(INT_UnUsedOnly)":

                        {
                            m_BOAbstract = m_ApplicationManager.m_BOInterface;
                            break;
                        }


                    case "Count(TST_Main)":
                    case "TST_Main":
                    case "Tst_Full":
                    case "TST_Full":
                    case "TST_CS":
                    case "TST_Elements":
                    case "TST_Documentation":
                    case "TST_StageAttribute":
                    case "TST_Result_Value":
                    case "TST_FailPercent":
                    case "TST_CntMonthlyBySpec":
                    case "TST_ZfifutNotInCLT":
                        
                       {
                            m_BOAbstract = m_ApplicationManager.m_BOTst;
                            break;
                        }

                    case "CheckList_Full":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOCheckList;
                            break;
                        }
                    case "NC_Full":
                    case "NC_CS":
                    case "NC_Elements":
                    case "NC_Main":
                    case "NC_Documentation":
                    case "NC_OP":
                    case "NC_ClosePeriodAverage":
                    case "NC_OpenLevel3":
                    case "NC_ListCloseDateOverDue":
                    case "NC_OpenCloseRate":
                    case "NC_OpenBySeverity":
                    case "NC_ListOpenSeverity3":
                    case "NC_ListOpenOneMonth":
                    case "NC_CountByProduct":


                        {
                            m_BOAbstract = m_ApplicationManager.m_BONC;
                            break;
                        }

                    case "SAP_Full":
                    case "SAP_CS":
                    case "SAP_Elements":
                    case "SAP_Main":
                    case "SAP_Documentation":
                    case "SAP_OP":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOSAP;
                            break;
                        }

                    case "GetNextTmpDocId":
                    case "FileBufferFromTemp":
                    case "FileBufferFromStorage":
                    case "FileBufferFromDisk":
                    case "INTDocBuffer":
                        {
                            m_BOAbstract = m_ApplicationManager.m_DocumentManager;
                            break;
                        }
                    case "qcAdmin_int_docs":
                    case "qcAdmin_int_NotInTst":
                    case "qcAdmin_int_InTst":
                    case "qcAdmin_int_MissingSpcBookStageSpecId":
                    case "qc_Admin_int_main":
                    case "qc_Admin_part":
                    case "qc_Admin_INT_MAIN_UPDATE_LOG":
                    case "qc_Admin_INT_IMP_LOG":
                    case "qcAdmin_NeverSent":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOInt;
                            break;
                        }
                    case "LYR_LayerProgress":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOCheckList;
                            break;
                        }
                    case "CLT_Documentation":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOCheckList;
                            break;
                        }
                    case "PSS_Main":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOTestPass;
                            break;
                        }
                    case "Max(Pos)":
                      case "PSS_RuleMain":
                    case "PSS_Algorithm":
                    case "PSS_RuleRangeDef":
                    case "PSS_RuleRange_Values":
                    case "PSS_MaterialRange":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BORuleDef;
                            break;
                        }
                    case "USER_Main":
                    case "USER_Role":
                    case "USER_MainWithRole":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOPermission;
                            break;
                        }


                    case "Gen_Log":
                    case "Gen_ClientAppLog":
                    case "Gen_WebServerLog":
                        {
                            m_BOAbstract = m_ApplicationManager.m_LogManager;
                            break;
                        }
                    case "LD_Main":
                    case "LD_Full":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOLayerDiagram;
                            break;
                        }

                    case "RPT_SUBFOLDER":
                    case "RPT_LIST":
                    case "RPT_PARAMS":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BORpt;
                            break;
                        }


                    default:
                        throw new Exception("DataId not recognized:" + sDataId);
                }
                //if (!IsFileAction)
                bool bOk = m_BOAbstract.GetData(p_DataId, XmlWhere, XmlSort, p_MaxCount, command, XmlUserInfo, out XmlData, out XmlErrors);
                if (XmlData == null) p_XmlData = null;
                else p_XmlData = XmlData.InnerXml;
                if (XmlErrors == null) p_XmlErrors = null;
                else p_XmlErrors = XmlErrors.InnerXml;
                m_ApplicationManager.m_DAM.CloseCommand(command, XmlUserInfo);

                //Log Exit (Pout)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_XmlData", p_XmlData, null, null, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    XmlUserInfo,
                    null  //Exception Values
                    );
                return bOk;
            }
            catch (Exception e)
            {
                // Log Error (Pins + Exception)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                     "p_DataId", p_DataId, "p_XmlWhere", p_XmlWhere, //String values
                     "p_XmlSort", p_XmlSort, null, null, //String values
                     "p_MaxCount", p_MaxCount, null, null,     //Int Values
                     null, null, null, null, //Int values
                     null, null, null, null, //XML Values
                     null, null, null, null,
                     XmlUserInfo,
                     e  //Exception Values
                     );
                m_ApplicationManager.m_ErrorManager.AddError(ref XmlErrors, e.Message, XmlUserInfo);
                p_XmlErrors = XmlErrors.InnerXml;
                return false;
            }
        }

        public bool SaveData(string p_DataId,
                             ref string p_XmlData,
                             string p_AttributeList,
                             string p_XmlUserInfo,
            out string p_XmlErrors)
        {
            XmlDocument XmlData = null;
            XmlDocument XmlUserInfo = null;
            XmlDocument XmlAttributeList = null;
            XmlDocument XmlErrors = null;
            p_XmlErrors = null;
            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            SqlCommand command=null ;

            try
            {

                if (p_XmlUserInfo != null)
                {

                    XmlUserInfo = new XmlDocument();
                    XmlUserInfo.LoadXml(p_XmlUserInfo);
                }
                else XmlUserInfo = null;

                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_DataId", p_DataId, "p_AttributeList", p_AttributeList, //String values
                    "p_XmlData", p_XmlData, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    XmlUserInfo,
                    null  //Exception Values
                    );

                if (p_AttributeList != null)
                {

                    XmlAttributeList = new XmlDocument();
                    XmlAttributeList.LoadXml(p_AttributeList);
                }
                else XmlAttributeList = null;


                if (p_XmlData != null)
                {

                    XmlData = new XmlDocument();
                    XmlData.LoadXml(p_XmlData);
                }
                else XmlData = null;
                p_XmlErrors = null;

    
                PrjSApp.BOAbstract m_BOAbstract = null;
                switch (p_DataId)
                {
                    case "Book_Full" /*"Book_Spec"*/ :
                    case "SPC_Tree_Full":
                    case "SpecTree_Full":
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_BOSPCBook;
                            break;
                        }
                    case "SPC_Main":
                    case "SPC_Stage":
                    case "Spc_Part" /*"Spc_Part"*/ :
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_BOSPCParts;
                            break;
                        }
                    case "ElementDataIndex":
                    case "PrjDataIndex":
                    case "ProductTree":
                    case "PRJ_ProductTree":
                    case "PRJ_Product_Relation":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOElement;
                            break;
                        }
                    case "ORD_CS":
                    case "ORD_MAIN_Elements":
                    case "ORD_MAIN":
                    case "ORDDEF_StageAttribute":
                    case "ORD_StageAttribute":
                    case "TestOrder":
                    case "ORDCancelData":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOOrder;
                            break;
                        }
                    case "SPC_Part_Column" /*"spc_part_column"*/ :
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_BOSPCParts;
                            break;
                        }
                    case "GEN_CodeRow" /*"GEN_CodeRow"*/ :
                    case "GEN_CodeHead":
                    case "GEN_CodeRowReal":
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_CodeManager;
                            break;
                        }
                    case "MaterialName" /*"GEN_CodeRow"*/ :
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_CodeManager;
                            break;
                        }
                    case "GEN_LanguageStrings":
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_CodeManager;
                            break;
                        }
                    case "TST_Main":
                    case "TST_CS":
                    case "TST_Elements":
                    case "TSTCancelData":
                        {
                            //open transaction
                            m_BOAbstract = m_ApplicationManager.m_BOTst;
                            break;
                        }
                    case "CheckList_Full":
                    case "AutoFillCLT_PRCRow":
                     case "CLTCancelData":
                    case "CLTPrintOut":
                    case "CheckList_AutoSign":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOCheckList;
                            break;
                        }
                    case "InnerDocument_Full":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BODoc;
                            break;
                        }
                    case "NC_Full":
                    case "NcCancelData":
                    case "NCPrintOut":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BONC;
                            break;
                        }
                      case "SAP_Full":
                    case "SAPCancelData":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOSAP;
                            break;
                        }
                    case "ASM_Main":
                    case "ASM_Elements":
                    case "ASM_Documentation":
                    case "ASM_CS":
                    case "ASMCancelData":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOASM;
                            break;
                        }


                    case "INT_Main":
                    case "INT_Docs":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOInt;
                            break;
                        }
                    case "Apr_Team_Full":
                    case "APRTeamPrintOut":
                    case "Apr_MaterialSource_Full":
                    case "Apr_Contractor_Full":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOApproval;
                            break;
                        }
                    case "SaveFileInTempFolder":
                    case "SaveFileBufferInTempFolder":
                    case "MoveTempFileToStorage":
                        {
                            m_BOAbstract = m_ApplicationManager.m_DocumentManager;
                            break;
                        }
                    case "PRJ_Stage_Material":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOSPCBook;
                            break;
                        }
                    case "PSS_Main":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOTestPass;
                            break;
                        }
                     case "RuleDefFull":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BORuleDef;
                            break;
                        }
                    case "USER_Full":
                        {
                            m_BOAbstract = m_ApplicationManager.m_BOPermission;
                            break;
                        }
                    case "Gen_WebServerLog":
                    case "Gen_ClientAppLog":
                        {
                            m_BOAbstract = m_ApplicationManager.m_LogManager;
                            break;
                        }

                    default:
                        throw new Exception("DataId not recognized:" + p_DataId);
                }
                bool ret; // We must use it to close the resource                
                command = m_ApplicationManager.m_DAM.GetCommand(XmlUserInfo);
                command.Transaction = command.Connection.BeginTransaction();
                
                if (m_BOAbstract.SaveData(p_DataId,
                                          ref XmlData,
                                          XmlAttributeList,
                                          command,
                                          XmlUserInfo,
                                          out XmlErrors))
                {
                    if (XmlErrors == null) p_XmlErrors = null;
                    else p_XmlErrors = XmlErrors.InnerXml;
                    if (XmlData != null)
                        p_XmlData = XmlData.InnerXml;
                    //Close Transaction
                    if (command.Transaction != null)
                        if (command.Transaction.Connection!=null)
                            command.Transaction.Commit();
                    ret = true;
                }
                else
                {
                    if (XmlErrors == null) p_XmlErrors = null;
                    else p_XmlErrors = XmlErrors.InnerXml;
                    if (command.Transaction != null) command.Transaction.Rollback();
                    ret = false;
                }
                //Close connection

                m_ApplicationManager.m_DAM.CloseCommand(command, XmlUserInfo);

                //Log Exit (Pout)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    null, null, null, null, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    XmlUserInfo,
                    null  //Exception Values
                    );

                return ret;


            }
            catch (Exception e)
            {
                // Log Error (Pins + Exception)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_DataId", p_DataId, "p_AttributeList", p_AttributeList, //String values
                    "p_XmlData", p_XmlData, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    XmlUserInfo,
                    e  //Exception Values
                    );
                if (command!=null)
                    if (command.Transaction != null) command.Transaction.Rollback();
                m_ApplicationManager.m_ErrorManager.AddError(ref XmlErrors, e.Message, XmlUserInfo);
                p_XmlErrors = XmlErrors.InnerXml;
                return false;
            }

        }



    }
}
