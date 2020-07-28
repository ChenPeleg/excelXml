using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace PrjSApp
{
    public class BOOrder : BOAbstract
    {
        //public PrjSApp.ApplicationManager m_ApplicationManager;
        public BOOrder()
        {
        } 

        public override bool GetData(string p_DataId,
                                        XmlDocument p_XmlWhere,
                                        XmlDocument p_XmlSort,
                                        int MaxCount,
                                        SqlCommand p_command,
                                        XmlDocument p_XmlUserInfo,
                                        out XmlDocument p_XmlData,
                                        out XmlDocument p_XmlErrors)
        {
            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
          
            p_XmlErrors = null;
            //
            try
            {

                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    "p_MaxCount", MaxCount, null, 0,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                

                XmlDocument Xml_SPC = new XmlDocument();
                p_XmlData = new XmlDocument();
                string TableName = "";
                string strData = "";
                XmlDocument XmlWhere;
                XmlNode XmlOrCondition;

                p_XmlErrors = null;
                switch (p_DataId)
                {
                    case "ORD_Enumerator":
                        {
                            int iNextId;
                            m_ApplicationManager.m_Numerator.GetNextNumber("ORD_MAIN", p_command,
                                p_XmlUserInfo, out iNextId, out p_XmlErrors);                            
                            strData += "</root>";
                            strData = "<root>" + iNextId.ToString();
                            p_XmlData.LoadXml(strData);
                            break;
                        }

                       
                    case "ORD_MAIN":
                        {
                            TableName = "ORD_MAIN";
                            string strFields = null;
                            if (p_DataId == "Count(ORD_MAIN)")
                                strFields = "Count(*) Count";

                            m_ApplicationManager.m_DAM.GetData(null, TableName, null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;
                        }
                    case "Count(ORD_ExtendedWithProductID)":
                    case "ORD_ExtendedWithProductID":
                        {
                            TableName = "ORD_ExtendedWithProductID";
                            string strFields = null;
                            if (p_DataId == "Count(ORD_ExtendedWithProductID)")
                                strFields = "Count(*) Count";

                            m_ApplicationManager.m_DAM.GetData(strFields, TableName,null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;
                        }
                    case "ORD_CS":
                        {
                            TableName = "ORD_CS";
                            m_ApplicationManager.m_DAM.GetData(null,TableName,null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;
                        }
                    case "ORD_MAIN_Elements":
                        {
                            TableName = "ORD_MAIN_Elements";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;
                        }

                    case "ORD_Attribute":
                        {
                            TableName = "ORD_Attribute";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;
                        }
                    case "PRJ_Contractor":
                        {
                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "TableId", "=", "12", "");

                            TableName = "GEN_CodeRow";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;                            
                        }
                    case "PRJ_Side":
                        {
                               XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "TableId", "=", "7", "");

                            TableName = "GEN_CodeRow";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;    
                        }
                    case "PRJ_MaterialOrigin":
                        {
                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "TableId", "=", "13", "");

                            TableName = "GEN_CodeRow";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;    
                        }
                    case "PRJ_SUBSTAGE"://material
                        {
                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "TableId", "=", "2", "");

                            TableName = "GEN_CodeRow";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;    
                        }
                    case "PRJ_Lab":
                        {
                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "TableId", "=", "14", "");

                            TableName = "GEN_CodeRow";
                            m_ApplicationManager.m_DAM.GetData(null,TableName, null, XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            break;    
                        }
                    case "ORD_Full":
                        {
                            //First get main part
                            m_ApplicationManager.m_DAM.GetData(null, "ORD_MAIN",  null, p_XmlWhere, p_XmlSort, MaxCount, p_command, p_XmlUserInfo, out strData, out p_XmlErrors);
                            strData += "</root>";
                            strData = "<root>" + strData;
                            p_XmlData.LoadXml(strData);
                            if (strData!="")
                            //Build list of id's of main
                             {
                                string ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(p_XmlData,
                                    "ORD_MAIN", "Id");
                                XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                                XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere,
                                     XmlOrCondition, "MainId", "IN", ListValues, "");
                                //Get ORD_MAIN_Elements
                                m_ApplicationManager.m_DAM.GetData(null, "ORD_MAIN_Elements", 
                                    null, XmlWhere, null, MaxCount,
                                    p_command, p_XmlUserInfo, out strData,
                                    out p_XmlErrors);
                                m_ApplicationManager.m_XmlUtility.CombineXml(p_XmlData,
                                     strData, "Id", "MainId", "ORD_MAIN");
                                //Get ORD_CS
                                m_ApplicationManager.m_DAM.GetData(null, "ORD_CS", 
                                    null, XmlWhere, null, MaxCount,
                                    p_command, p_XmlUserInfo, out strData,
                                    out p_XmlErrors);
                                m_ApplicationManager.m_XmlUtility.CombineXml(p_XmlData,
                                     strData, "Id", "MainId", "ORD_MAIN");
                                //Get ORD_StageAttribute
                                m_ApplicationManager.m_DAM.GetData(null, "ORD_StageAttribute", 
                                    null, XmlWhere, null, MaxCount,
                                    p_command, p_XmlUserInfo, out strData,
                                    out p_XmlErrors);
                                m_ApplicationManager.m_XmlUtility.CombineXml(p_XmlData,
                                     strData, "Id", "MainId", "ORD_MAIN");
                            }


                            break;
                        }

                }
                //Log EXIT (Pouts)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    "MaxCount", MaxCount, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                return true;
            }
            catch (Exception e)
            {
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                     "p_DataId", p_DataId, null, null, //String values
                     null, null, null, null, //String values
                     "MaxCount", MaxCount, null, 0,     //Int Values
                     null, null, null, null, //Int values
                     "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                     null, null, null, null,
                     p_XmlUserInfo,
                     e  //Exception Values
                    );
                string strData = "</root>";
                p_XmlData = new XmlDocument();
                strData = "<root>" + strData;
                p_XmlData.LoadXml(strData);
                return false;
            }
           
        }
       

        public override bool SaveData(string p_DataId,
                                        ref XmlDocument p_XmlData,
                                        XmlDocument p_AttributeList,
                                        SqlCommand p_command,
                                        XmlDocument p_XmlUserInfo,
                                        out XmlDocument p_XmlErrors)
        {
            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            p_XmlErrors = null;
            string str_TableName = "";

            try
            {

                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlData", p_XmlData, "AttributeList", p_AttributeList, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );


                switch (p_DataId)
                {
                    case "ORD_MAIN":
                        {
                            string mainId = "";
                            string UpdateTimeStamp = "";
                            XmlDocument xmlCSATTR = new XmlDocument();
                            xmlCSATTR.LoadXml
                                (m_ApplicationManager.m_SQLUtil.GetXmlSaveAttributes("ORD_CS"));
                            XmlDocument xmlAttributesATTR = new XmlDocument();
                            xmlAttributesATTR.LoadXml 
                                (m_ApplicationManager.m_SQLUtil.GetXmlSaveAttributes("ORD_Attribute"));
                            string Status = p_XmlData.DocumentElement.FirstChild.Attributes["Status"].Value;
                            if (Status == "UpdateC")
                            {

                                p_XmlData.DocumentElement.FirstChild.Attributes["Status"].Value = "Insert";
                                p_XmlData.DocumentElement.FirstChild.Attributes["Id"].Value = "-1";
                            }
                            //save ord main table
                            if (!m_ApplicationManager.m_DAM.SaveData("ORD_MAIN", p_XmlData, "//ORD_MAIN",
                                       p_AttributeList, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;

                            ////get new id and UpdatedTimeStamp
                            XmlNode Node = p_XmlData.SelectSingleNode("//ORD_MAIN");
                            mainId = Node.Attributes["Id"].Value;
                            UpdateTimeStamp= Node.Attributes["UpdateTimeStamp"].Value;

                            //set new main id  and updatedtimestampinto sons path
                            p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, mainId, "ORD_MAIN_Elements", "MainId");
                            p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, mainId, "ORD_CS", "MainId");
                            p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, mainId, "ORD_Attribute", "MainId");
  
                            //p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, UpdateTimeStamp, "ORD_MAIN_Elements", "UpdateTimeStamp");
                            //p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, UpdateTimeStamp, "ORD_CS", "UpdateTimeStamp");
                            //p_XmlData = UpdateNewAttributeIntoXml(p_XmlData, UpdateTimeStamp, "ORD_StageAttribute", "UpdateTimeStamp");

                            //save ORD_MAIN_Elements CS SA
                            if (!m_ApplicationManager.m_DAM.SaveData("ORD_MAIN_Elements", p_XmlData, "//ORD_MAIN_Elements",
                                          null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                            if (!m_ApplicationManager.m_DAM.SaveData("ORD_CS", p_XmlData, "//ORD_CS",
                                                  xmlCSATTR, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                            if (!m_ApplicationManager.m_DAM.SaveData("ORD_Attribute", p_XmlData, "//ORD_Attribute",
                                          xmlAttributesATTR, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;

                            ////save data index table
                            SaveDataIndex(p_XmlData, mainId, p_command, p_XmlUserInfo, out p_XmlErrors);
                            
                            break;
                            
                        }
                    case "ORD_CS":
                        {
                            str_TableName = "ORD_CS";
                            if (!m_ApplicationManager.m_DAM.SaveData(str_TableName,
                                p_XmlData, p_AttributeList, p_command,
                                p_XmlUserInfo, out p_XmlErrors)) return false;
                            break;
                        }

                    case "ElementDataIndex":
                        {
                            str_TableName = "ElementDataIndex";
                            if (!m_ApplicationManager.m_DAM.SaveData(str_TableName,
                                p_XmlData, p_AttributeList, p_command,
                                p_XmlUserInfo, out p_XmlErrors)) return false;
                            break;
                        }
                    case "ORD_MAIN_Elements":
                        {
                            str_TableName = "ORD_MAIN_Elements";
                            if (!m_ApplicationManager.m_DAM.SaveData(str_TableName,
                                p_XmlData, p_AttributeList, p_command,
                                p_XmlUserInfo, out p_XmlErrors)) return false;
                            break;
                        }
                    case "ORDCancelData":
                        {
                            foreach (XmlNode nodedata in p_XmlData.SelectNodes("//ORD_MAIN"))
                                m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(nodedata,
                                         "isdeleted", "1", p_XmlData);
        
                            if (!m_ApplicationManager.m_DAM.SaveData("ORD_Main",
                                     p_XmlData, "//ORD_MAIN", null,
                                     p_command, p_XmlUserInfo, out p_XmlErrors)) return false;

                            string StringData = "";
                            XmlNode nodeORDMain = p_XmlData.SelectSingleNode("//ORD_MAIN");
                            XmlDocument xmlDataIndex = new XmlDocument();
                            XmlDocument XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlNode XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "DataId", " = ", nodeORDMain.Attributes["Id"].Value.ToString(), "");
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "ElementDataCode", " = ", "1", "");
                            if (!m_ApplicationManager.m_DAM.GetData(null, "ElementDataIndex", null,
                                       XmlWhere, null,
                                       100, p_command,
                                       p_XmlUserInfo,
                                       out StringData,
                                       out p_XmlErrors)) return false;
                            StringData += "</root>";
                            StringData = "<root>" + StringData;
                            xmlDataIndex.LoadXml(StringData);
                            XmlNode nodeDataIndex = xmlDataIndex.FirstChild.FirstChild;
                            nodeDataIndex.Attributes.Append(xmlDataIndex.CreateAttribute("Status"));
                            nodeDataIndex.Attributes["Status"].Value = "Update";
                            nodeDataIndex.Attributes["ElementDataStatusCode"].Value = "4";
                            if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex",
                                xmlDataIndex,
                                null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                            break;
                        }
                       

                }
                //Log Exit (Pout)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlData", p_XmlData, "AttributeList", p_AttributeList, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                return true;
            }
            catch (Exception e)
            {
                // Log Error (Pins + Exception)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData",
                   OpertionType,
                   "p_DataId", p_DataId, null, null, //String values
                   null, null, null, null, //String values
                   null, null, null, null,     //Int Values
                   null, null, null, null, //Int values
                   "p_XmlData", p_XmlData, "AttributeList", p_AttributeList,//XML Values
                   null, null, null, null,
                   p_XmlUserInfo,
                   e  //Exception Values
                   );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);
                return false;
            }

            
        }

        #region    Private Methods

        private bool SaveDataIndex(XmlDocument p_XmlData,
                                    string ORDID,
                                    SqlCommand p_command,
                                    XmlDocument p_XmlUserInfo,
                                    out XmlDocument p_XmlErrors)
        {
            //get Elements name
            string TableName = "";
            string strRem = "";
            //string strTestedPart = "";
            string strSPC_Book_Stage_Spec = "";
            p_XmlErrors = null;
            XmlDocument xmlDataIndex = new XmlDocument();
            XmlDocument xmlDataIndex_Elements = new XmlDocument();
            ////get new element id
            //XmlNode Node = p_XmlData.SelectSingleNode("//ORD_MAIN/ORD_MAIN_Elements");
            //if (Node != null) 
            //    strEle = Node.Attributes["PrjProductTreeId"].Value;
            ////get remark                                
            XmlNode Node = p_XmlData.SelectSingleNode("//ORD_MAIN");
            //strStatus = Node.Attributes["Status"].Value;

            strSPC_Book_Stage_Spec = Node.Attributes["SpcBookStageSpecText"].Value;
            string strComments = m_ApplicationManager.m_XmlUtility.SafeGetAttributeValue(Node, "Comments");
            strRem = GetStrRemark(strSPC_Book_Stage_Spec, strComments, p_command, p_XmlUserInfo);


            //strDataIndex = "<root>" + BuildXml_DataList(ORDID, strEle, strRem, strTestDate, strStatus
            //                                                            ,p_command,p_XmlUserInfo) + "</root>";
            //xmlDataIndex.LoadXml(strDataIndex);
            // string Status = xmlDataIndex.DocumentElement.FirstChild.Attributes["Status"].Value;
            XmlDocument XmlWhere;
            XmlNode XmlOrCondition;
            string StringData = "";
            string ORDMAinID = p_XmlData.DocumentElement.FirstChild.Attributes["Id"].Value;

            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "MainId", " = ", ORDMAinID, "");
            TableName = "ORD_MAIN_Elements";
            if (!m_ApplicationManager.m_DAM.GetData(null, TableName, null,
                       XmlWhere, null,
                       100, p_command,
                       p_XmlUserInfo,
                       out StringData,
                       out p_XmlErrors)) return false;
            if (StringData == "")
                throw new Exception("BOOrder: Can not save with no elements");

            StringData += "</root>";
            StringData = "<root>" + StringData;
            XmlDocument xmlOrdMain_Elements = new XmlDocument();
            xmlOrdMain_Elements.LoadXml(StringData);
           
            XmlNode nodeORDMain = p_XmlData.SelectSingleNode("//ORD_MAIN");
            //case of insert
            if (nodeORDMain.Attributes["Status"].Value == "Insert")
            {
                xmlDataIndex.LoadXml(m_ApplicationManager.m_SQLUtil.GetXmlNewRecord
                                  ("ElementDataIndex"));
                xmlDataIndex_Elements.LoadXml(m_ApplicationManager.m_SQLUtil.GetXmlNewRecord
                                    ("ElementDataIndex_Elements"));
                XmlNode nodeDataIndex = xmlDataIndex.FirstChild.FirstChild;
                XmlNode nodeDataIndex_Elements = xmlDataIndex_Elements.FirstChild.FirstChild;
                //XmlNode nodeOrdMain = p_XmlData.SelectSingleNode("//ORD_MAIN");
                nodeDataIndex.Attributes["Date"].Value = nodeORDMain.Attributes["TestDate"].Value.ToString();
                nodeDataIndex.Attributes["Id"].Value = "0";
                nodeDataIndex.Attributes["ElementDataCode"].Value = "1";
                //if (nodeNCMain.Attributes["StatusCode"].Value == "1") //Open
                //    nodeDataIndex.Attributes["ElementDataStatusCode"].Value = "3";
                //else
                //    nodeDataIndex.Attributes["ElementDataStatusCode"].Value = "2";
                nodeDataIndex.Attributes["Name"].Value = strRem;//.Attributes["SpcBookStageSpwcText"].Value.ToString();
                nodeDataIndex.Attributes["DataId"].Value = nodeORDMain.Attributes["Id"].Value.ToString();
                 nodeDataIndex.Attributes["Comments"].Value = m_ApplicationManager.m_XmlUtility.SafeGetAttributeValue(nodeORDMain, "Comments");
 
                nodeDataIndex.Attributes["Status"].Value = "Insert";
                //nodeDataIndex.Attributes["ElementId"].Value = NodeElement.Attributes["PrjProductTreeId"].Value.ToString();
                if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex",
                    xmlDataIndex,
                    null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;

                foreach (XmlNode NodeElement in p_XmlData.SelectNodes("//ORD_MAIN_Elements"))
                {
                    nodeDataIndex_Elements.Attributes["Status"].Value = "Insert";
                    nodeDataIndex_Elements.Attributes["ElementDataIndexId"].Value = xmlDataIndex.DocumentElement.FirstChild.Attributes["Id"].Value.ToString();
                    nodeDataIndex_Elements.Attributes["ElementId"].Value = NodeElement.Attributes["PrjProductTreeId"].Value.ToString();
                    if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex_Elements",
                       xmlDataIndex_Elements,
                       null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                }

            }
            //case of update
            if (nodeORDMain.Attributes["Status"].Value == "Update")
            {
                XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "DataId", " = ", nodeORDMain.Attributes["Id"].Value.ToString(), "");
                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "ElementDataCode", " = ", "1", "");
                TableName = "ElementDataIndex";
                if (!m_ApplicationManager.m_DAM.GetData(null, TableName, null,
                           XmlWhere, null,
                           100, p_command,
                           p_XmlUserInfo,
                           out StringData,
                           out p_XmlErrors)) return false;
                StringData += "</root>";
                StringData = "<root>" + StringData;
                xmlDataIndex.LoadXml(StringData);
                XmlNode nodeDataIndex = xmlDataIndex.FirstChild.FirstChild;
                //nodeDataIndex.Attributes["Id"].Value = p_XmlDataUpdate.FirstChild.FirstChild.Attributes["Id"].Value;
                nodeDataIndex.Attributes["Name"].Value = strRem;//.Attributes["SpcBookStageSpwcText"].Value;
                nodeDataIndex.Attributes["Date"].Value = nodeORDMain.Attributes["TestDate"].Value;
                nodeDataIndex.Attributes["Comments"].Value = m_ApplicationManager.m_XmlUtility.SafeGetAttributeValue(nodeORDMain, "Comments");
                nodeDataIndex.Attributes.Append(xmlDataIndex.CreateAttribute("Status"));
                nodeDataIndex.Attributes["Status"].Value = "Update";
                //if (nodeORDMain.Attributes["StatusCode"].Value == "1") //Open
                //    nodeDataIndex.Attributes["ElementDataStatusCode"].Value = "3";
                //else
                //    nodeDataIndex.Attributes["ElementDataStatusCode"].Value = "2";

                if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex", xmlDataIndex
                        , null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;

                string ElementDataIndexId = xmlDataIndex.FirstChild.FirstChild.Attributes["Id"].Value;

                XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "ElementDataIndexId", " = ", ElementDataIndexId, "");
                TableName = "ElementDataIndex_Elements";
                if (!m_ApplicationManager.m_DAM.GetData(null, TableName, null,
                           XmlWhere, null,
                           100, p_command,
                           p_XmlUserInfo,
                           out StringData,
                           out p_XmlErrors)) return false;
                StringData += "</root>";
                StringData = "<root>" + StringData;
                xmlDataIndex_Elements.LoadXml(StringData);
                if (p_XmlData.SelectNodes("//ORD_MAIN_Elements").Count > 0)
                {
                    foreach (XmlNode NodeUpdate in xmlDataIndex_Elements.DocumentElement.ChildNodes)
                    {
                        NodeUpdate.Attributes.Append(xmlDataIndex_Elements.CreateAttribute("Status"));
                        NodeUpdate.Attributes["Status"].Value = "Delete";
                        NodeUpdate.Attributes["isdeleted"].Value = "1";
                        if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex_Elements",
                               xmlDataIndex_Elements,
                               null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                    }
                    xmlDataIndex_Elements.LoadXml(m_ApplicationManager.m_SQLUtil.GetXmlNewRecord
                          ("ElementDataIndex_Elements"));
                    XmlNode nodeDataIndex_Elements = xmlDataIndex_Elements.FirstChild.FirstChild;

                    foreach (XmlNode NodeOrdElements in xmlOrdMain_Elements.SelectNodes("//ORD_MAIN_Elements"))
                    {
                            nodeDataIndex_Elements.Attributes["ElementDataIndexId"].Value = ElementDataIndexId;
                            nodeDataIndex_Elements.Attributes["ElementId"].Value = NodeOrdElements.Attributes["PrjProductTreeId"].Value.ToString();
                            nodeDataIndex_Elements.Attributes["Status"].Value = "Insert";    
                           if (!m_ApplicationManager.m_DAM.SaveData("ElementDataIndex_Elements",
                               xmlDataIndex_Elements,
                               null, p_command, p_XmlUserInfo, out p_XmlErrors)) return false;
                    }
                }
            }
            return true;
        }

        private string BuildXml_DataList(string newId,
                                            string strElemId,
                                            string strRemark,
                                            string TestDate,
                                            string strStatus,
                                            SqlCommand p_command,
                                            XmlDocument p_XmlUserInfo)
        {
            XmlDocument document = new XmlDocument();
            //XmlNode Root;
            //Root = document.CreateNode(XmlNodeType.Element, "Root", "");
            //document.AppendChild(Root);
            XmlNode newElem;
            XmlAttribute Attr = null;
            string p_StringData = null;
            XmlDocument p_XmlErrors = null;           
            XmlDocument p_XmlData = null;
            string strId = "";
            string strInsertTimeStamp = "";
            newElem = document.CreateNode(XmlNodeType.Element, "ElementDataIndex", "");

            //insert status
            Attr = document.CreateAttribute("Status");
            Attr.Value = strStatus;
            newElem.Attributes.Append(Attr);     
     
            //dor 18/04/2006
            //if is update get data index id
            if (strStatus.Trim().Equals("Update"))
            {
                XmlDocument XmlWhere;
                XmlNode XmlOrCondition;
                XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "DataId", "=", newId, "");
                m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "ElementDataCode", "=", "1", "");
                string TableName = "ElementDataIndex";
                m_ApplicationManager.m_DAM.GetData(null, TableName, null, XmlWhere, null, 1, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                if (!p_StringData.Trim().Equals(""))
                {
                    p_XmlData = new XmlDocument();
                    p_XmlData.LoadXml(p_StringData);

                    strId = p_XmlData.DocumentElement.Attributes["Id"].Value;
                    //insert id
                    Attr = document.CreateAttribute("Id");
                    Attr.Value = strId;
                    newElem.Attributes.Append(Attr);

                    //InsertTimeStamp
                    strInsertTimeStamp = p_XmlData.DocumentElement.Attributes["InsertTimeStamp"].Value;
                    Attr = document.CreateAttribute("InsertTimeStamp");
                    Attr.Value = strInsertTimeStamp;
                    newElem.Attributes.Append(Attr);

                    //UpdateTimeStamp
                    strInsertTimeStamp = p_XmlData.DocumentElement.Attributes["UpdateTimeStamp"].Value;
                    Attr = document.CreateAttribute("UpdateTimeStamp");
                    Attr.Value = strInsertTimeStamp;
                    newElem.Attributes.Append(Attr);

                    if (strElemId == null)
                        strElemId = "";//p_XmlData.DocumentElement.Attributes["ElementId"].Value;   
                }            
                   
            }
         
            //ElementId
            //Attr = document.CreateAttribute("ElementId");
            //Attr.Value = strElemId;
            //newElem.Attributes.Append(Attr);           

            //[Date]
            Attr = document.CreateAttribute("Date");
            try
            {               
                Attr.Value = TestDate;//m_ApplicationManager.m_SQLUtil.Get_TimeStamp(dt).ToString();
            }
            catch
            {
                Attr.Value = m_ApplicationManager.m_SQLUtil.Get_TimeStamp(DateTime.Now).ToString();
            }
            newElem.Attributes.Append(Attr);

            //ElementDataCode6
            Attr = document.CreateAttribute("ElementDataCode");
            Attr.Value = "1";
            newElem.Attributes.Append(Attr);

            //Name
            Attr = document.CreateAttribute("Name");
            Attr.Value = strRemark;//"הזמנת בדיקה";
            newElem.Attributes.Append(Attr);

            //DataId       
            Attr = document.CreateAttribute("DataId");
            Attr.Value = newId;
            newElem.Attributes.Append(Attr);

            document.AppendChild(newElem);

            return document.InnerXml;

        }

            private XmlDocument UpdateNewAttributeIntoXml(XmlDocument m_Document,
                                                    string NewAttribute,
                                                    string strSelectNodes,
                                                    string strAttributeName)
            {
                XmlNode NodeTime = m_Document.DocumentElement.FirstChild;
                XmlNodeList ElementData_List = m_Document.SelectNodes("//" + strSelectNodes);
                foreach (XmlNode Node in ElementData_List)
                {
                    Node.Attributes[strAttributeName].Value = NewAttribute;
                }
                return m_Document;
            }

        private bool isInXmlPath(XmlDocument p_xmlData, string strPath)
        {
            XmlNodeList NodeListData = p_xmlData.SelectNodes("//" + strPath);
            if (NodeListData.Count == 0) return false;
            return true;
        }

        private string GetStrRemark ( string strSPC_Book_Stage_Spec,
            string strComments,
                            SqlCommand p_command,
                            XmlDocument p_XmlUserInfo)

        {
            string strRemark = "";

            strRemark = strSPC_Book_Stage_Spec;
            if (strComments != "")
                strRemark += " " + strComments;

            return strRemark;
        }

        #endregion

    }
}
