using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.ComponentModel;
using PrjCSUtils;


namespace PrjSApp
{
    /// <summary>
    /// Summary description for DataAccessManager.
    /// </summary>
    public class DataAccessManager
    {
        public PrjSApp.ApplicationManager m_ApplicationManager;

        public DataAccessManager()
        {
        }

        public bool GetData(string p_sFields,
                            string p_sTableName,
                            string p_TagName,
                            XmlDocument p_XmlWhere,
                            XmlDocument p_XmlSort,
                            int p_MaxCount,
                            SqlCommand p_command,
                            XmlDocument p_XmlUserInfo,
                            out string p_StringData,
                            out XmlDocument p_XmlErrors)
        {

            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            string s_ProcedureName = "";
            string s_TableName = "";
            string sFields = "";
            string sTable = "";
            string sXmlWhere = "";
            string sXmlSort = "";
            p_StringData = "";
            p_XmlErrors = null;
            int language;
            try
            {
                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_sFields", p_sFields,  //String values
                    "p_sTableName", p_sTableName, //String values
                    "p_TagName", p_TagName, //String values
                    null, null,  //String values
                    "p_MaxCount", p_MaxCount, "", null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                    "", null, "", null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                XmlDocument xmldata = new XmlDocument();


                string Node_language = p_XmlUserInfo.DocumentElement.Attributes["Language"].Value;

                language = int.Parse(Node_language);

                if (p_sFields != null) sFields = p_sFields;
                Get_StoredProcedure_Name(p_sTableName, p_TagName, language, out sTable, out s_ProcedureName);
                s_TableName = sTable;
                string strCommandText;
                switch (s_ProcedureName)
                {
                    case "Select_All":
                    case "Select_Queries":
                        sXmlWhere = m_ApplicationManager.m_SQLUtil.Get_WhereString(p_XmlWhere);
                        sXmlSort = m_ApplicationManager.m_SQLUtil.Get_SortString(p_XmlSort);
                        strCommandText = "EXEC " + s_ProcedureName +
                                "'" + sFields + "'" +
                                ",'" + s_TableName + "'" +
                                ",'" + sXmlWhere + "'" +
                                ",'" + sXmlSort + "'" +
                                ",'" + p_MaxCount + "'";
                        break;


                        

                    case "SelectedElementDataIndex":
                        //Split the where by data tables

                        string productid = "";
 
                        if (p_XmlWhere != null)
                        {
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='productid']"))
                            {
                                productid = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                        }
                        if (productid == "")
                            throw new Exception("Missing required condition on productid");

                        string CSFrom = "";
                        string CSTo = "";
                        if (p_XmlWhere != null)
                        {
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='FromCut']"))
                            {
                                CSFrom = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='ToCut']"))
                            {
                                CSTo = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                        }


                        sXmlWhere = m_ApplicationManager.m_SQLUtil.Get_WhereString(p_XmlWhere);
                        string OrAndSelection = "AND";
                        if (p_sTableName == "FreeTextSearchElementDataIndex")
                        {
                            sXmlWhere = sXmlWhere.Replace("AND", "OR");
                            OrAndSelection = "OR";
                        }
 




                        sXmlSort = m_ApplicationManager.m_SQLUtil.Get_SortString(p_XmlSort);

                        strCommandText = "EXEC " + s_ProcedureName +
                                "'" + sFields + "'" +
                                ",'" + s_TableName + "'" +
                                ",'" + productid + "'" +
                                ",'" + sXmlWhere + "'" +
                                ",'" + CSFrom + "'" +
                                ",'" + CSTo + "'" +
                                ",'" + OrAndSelection + "'" +
                                ",'" + sXmlSort + "'" +
                                ",'" + p_MaxCount + "'";

                        break;
                    case "ORD_Selection":
                        //Split the where by data tables

                         productid = "";

                        if (p_XmlWhere != null)
                        {
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='productid']"))
                            {
                                productid = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                        }
                        if (productid == "")
                            throw new Exception("Missing required condition on productid");

                         CSFrom = "";
                         CSTo = "";
                        if (p_XmlWhere != null)
                        {
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='FromCut']"))
                            {
                                CSFrom = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                            foreach (XmlNode nodeAnd in p_XmlWhere.SelectNodes("//AndCondition[@field='ToCut']"))
                            {
                                CSTo = nodeAnd.Attributes["value1"].Value.ToString();
                                m_ApplicationManager.m_SQLUtil.Del_AndCondition(ref p_XmlWhere, nodeAnd);
                            }
                        }


                        sXmlWhere = m_ApplicationManager.m_SQLUtil.Get_WhereString(p_XmlWhere);
                      




                        sXmlSort = m_ApplicationManager.m_SQLUtil.Get_SortString(p_XmlSort);

                        strCommandText = "EXEC " + s_ProcedureName +
                                "'" + sFields + "'" +
                                ",'" + productid + "'" +
                                ",'" + sXmlWhere + "'" +
                                ",'" + CSFrom + "'" +
                                ",'" + CSTo + "'" +
                                 ",'" + sXmlSort + "'" +
                                ",'" + p_MaxCount + "'";

                        break;

                    default:
                        sXmlWhere = m_ApplicationManager.m_SQLUtil.Get_WhereString(p_XmlWhere);
                        sXmlSort = m_ApplicationManager.m_SQLUtil.Get_SortString(p_XmlSort);
                        strCommandText = "EXEC " + s_ProcedureName +
                                "'" + s_TableName + "'" +
                                 ",'" + sXmlWhere + "'" +
                               ",'" + sXmlSort + "'" +
                                ",'" + p_MaxCount + "'";
                        break;
                }


                p_command.CommandText = strCommandText;
                string strData = "";
                SqlDataReader reader = null;
                reader = p_command.ExecuteReader();
                while (reader.Read())
                {
                    strData += reader[0].ToString();
                }
                reader.Close();
                p_StringData = strData;
                if (reader != null) reader.Dispose();


                //Log EXIT (Pouts)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_sFields", p_sFields,  //String values
                    "p_sTableName", p_sTableName, //String values
                    "p_TagName", p_TagName, //String values
                    null, null,  //String values
                    null, null, null, null,  //Int Values
                    null, null, null, null,     //Int Values
                    null, null, null, null,  //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
            }
            catch (Exception e)
            {
                // Log Error (Pins + Exception)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                     "p_sTableName", p_sTableName, "p_TagName", p_TagName, //String values
                     null, null, null, null, //String values
                     "p_MaxCount", p_MaxCount, //Int Values
                     null, 0, null, null, null, null,     //Int Values
                     "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                     null, null, null, null,
                     p_XmlUserInfo,
                     e  //Exception Values
                     );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);
                return false;
            }


            return true;

        }

        public bool SaveData(string p_sTableName,
                            XmlDocument p_XmlData,
                            XmlDocument p_AttributeList,
                            SqlCommand p_command,
                            XmlDocument p_XmlUserInfo,
                            out XmlDocument p_XmlErrors)
        {
            return this.SaveData(p_sTableName, p_XmlData, "//" + p_XmlData.DocumentElement.FirstChild.Name,
                p_AttributeList, p_command, p_XmlUserInfo, out p_XmlErrors);

        }

        public bool UpdateField(string p_sTableName,
                                string p_FieldName,
                                object p_Value,
                                string p_WhereCondition,
                                SqlCommand p_command,
                                XmlDocument p_XmlUserInfo,
                                out XmlDocument p_XmlErrors)
        {
            bool result = false;
            string sValue = "";
            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            p_XmlErrors = null;
            try
            {
                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "UpdateField", OpertionType,
                    "p_sTableName", p_sTableName, "p_WhereCondition", p_WhereCondition, //String values
                    "p_FieldName", p_FieldName, "p_Value", p_Value.ToString(), //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                if (p_Value is string) sValue = "'" + p_Value.ToString().Trim() + "'";
                else if ((p_Value is int) || (p_Value is Int64) || (p_Value is double)) sValue = p_Value.ToString();
                else if (p_Value is bool)
                {
                    bool v = (bool)p_Value;
                    if (v) sValue = "1";
                    else sValue = "0";
                }
                string strComman = "UPDATE " + p_sTableName + " SET " + p_FieldName.Trim() + "=" + sValue + " WHERE " + p_WhereCondition;
                p_command.CommandText = strComman;
                int i = p_command.ExecuteNonQuery();
                result = (i > 0);
            }
            catch (Exception e)
            {
                // Log Error (Pins + Exception)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionError;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "UpdateField", OpertionType,
                    "p_sTableName", p_sTableName, "p_WhereCondition", p_WhereCondition, //String values
                    "p_FieldName", p_FieldName, "p_Value", p_Value.ToString(), //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    e  //Exception Values
                    );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);
            }
            finally
            {
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "UpdateField", OpertionType,
                    "p_sTableName", p_sTableName, "p_WhereCondition", p_WhereCondition, //String values
                    "p_FieldName", p_FieldName, "p_Value", p_Value.ToString(), //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    null, null, null, null, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
            }
            return result;
        }

        public bool SaveData(string p_sTableName,
                             XmlDocument p_XmlData,
                             string XPATHDATAFilter,
                             XmlDocument p_AttributeList,
                             SqlCommand p_command,
                             XmlDocument p_XmlUserInfo,
                             out XmlDocument p_XmlErrors)
        {


            string ClassName = this.GetType().ToString();
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            p_XmlErrors = null;
            try
            {
                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_sTableName", p_sTableName, null, null, //String values
                    "TagName", XPATHDATAFilter, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlData", p_XmlData, "p_AttributeList", p_AttributeList, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );


                XmlNodeList DataNodeList = p_XmlData.SelectNodes(XPATHDATAFilter);
                if (DataNodeList.Count == 0) return true;
                XmlDocument xmlAttributes = p_AttributeList;
                double CurrentTimeStampDB = -1.0;
                double CurrentTimeStamp;
                string str_ProcedureName = "";
                string str_ColumnsName = "";
                string str_ColumnsValue = "";
                string s_TableName = "";
                string str_sTable = "";
                string sName = "";
                int i_NextId = 0;
                string strCommand;
                string Id;
                switch (p_sTableName)
                {

                    case "PRJ_Product_Relation_LevelId"://case of set level
                        string Node_language = p_XmlUserInfo.DocumentElement.Attributes["Language"].Value;
                        int language = int.Parse(Node_language);
                        Get_StoredProcedure_Name(p_sTableName, null, language, out str_sTable, out str_ProcedureName);
                        s_TableName = str_sTable;
                        string ProductId = p_XmlData.DocumentElement.FirstChild.Attributes["Id"].Value;
                        strCommand = "EXEC " + str_ProcedureName + " '" + ProductId + "'";
                        p_command.CommandText = strCommand;
                        p_command.ExecuteNonQuery();
                        break;

                    case "CLT_AutoSign":

                        GetUpdate_DBNames(p_sTableName, out str_sTable, out str_ProcedureName);
                        Id = p_XmlData.DocumentElement.FirstChild.Attributes["Id"].Value;
                        string RoleCode = p_XmlData.DocumentElement.FirstChild.Attributes["RoleCode"].Value;
                        strCommand = "EXEC " + str_ProcedureName + " '" + Id + "'" + ",'" + RoleCode + "'";
                        p_command.CommandText = strCommand;
                        p_command.ExecuteNonQuery();
                        break;

                    case "CLT_Validate": //Case of CLT_Validate
                    case "APR_Team_Validate": //Case of APR_Team_Validate
                    case "APR_MaterialSource_Validate": //Case of APR_MaterialSource_Validate
                    case "TST_Validate":
                    case "ASM_Validate":
                    case "DOC_Validate":
                    case "NC_Validate":
                    case "SAP_Validate":
                    case "TST_AutoCalculation": //Case of TST_AutoCalculation

                        GetUpdate_DBNames(p_sTableName, out str_sTable, out str_ProcedureName);
                        Id = p_XmlData.DocumentElement.FirstChild.Attributes["Id"].Value;
                        strCommand = "EXEC " + str_ProcedureName + " '" + Id + "'";
                        p_command.CommandText = strCommand;
                        p_command.ExecuteNonQuery();
                        break;


 



                    default:

                        CurrentTimeStamp = m_ApplicationManager.m_SQLUtil.Get_CurrentTimeStamp();


                        if (IsSupportLogicalDelete(p_sTableName))
                            ChangeDeleteToLogicalDelete(DataNodeList, xmlAttributes);
                        if (xmlAttributes == null)
                        {
                            //Find the node having max attributes and use it as an example (Danny 16/11)
                            int iNodeMaxCnt = 0;
                            int iMaxCnt = 0;
                            for (int iNodeCurr = 0; iNodeCurr < DataNodeList.Count; iNodeCurr++)
                                if (DataNodeList[iNodeCurr].Attributes.Count > iMaxCnt)
                                {
                                    iMaxCnt = DataNodeList[iNodeCurr].Attributes.Count;
                                    iNodeMaxCnt = iNodeCurr;
                                }
                            xmlAttributes = m_ApplicationManager.m_XmlUtility.CreateXMLAttributeFromXMLData
                                (DataNodeList[iNodeMaxCnt]);
                        }
                        TransformDate(DataNodeList, xmlAttributes);

                        double NearestTimeStamp; //TimeStamp when the user took data from the DB

                        string pWhereId;
                        string pNames_Values = "";
                        int MaxId = 0;


                        //Case Of Update
                        XmlNodeList ListUpdate = p_XmlData.SelectNodes(XPATHDATAFilter + "[@Status='Update']");
                        if (ListUpdate.Count != 0)
                        {

                            foreach (XmlNode Node in ListUpdate)
                            {
                                if (Node.Attributes["Id"] == null)
                                    Id = Node.Attributes["ID"].Value;
                                else
                                    Id = Node.Attributes["Id"].Value;

                                NearestTimeStamp = Get_InsertTimeStamp(p_sTableName, Id, p_command, out p_XmlErrors);
                                string time_stamp = "";
                                try
                                {
                                    time_stamp = Node.Attributes["UpdateTimeStamp"].Value.ToString().Trim();
                                }
                                catch { }

                                bool result = false;
                                if (time_stamp != "")
                                {
                                    try { CurrentTimeStampDB = double.Parse(time_stamp.Trim()); }
                                    catch { CurrentTimeStampDB = -1.0; }
                                }
                                if ((time_stamp == "") && (NearestTimeStamp == 0.0)) result = true;
                                else if ((time_stamp != "") && (NearestTimeStamp == 0.0) && (CurrentTimeStampDB == 0.0)) result = true;
                                else if ((time_stamp != "") && (NearestTimeStamp == 0.0) && (CurrentTimeStampDB != 0.0))
                                {
                                    throw new Exception("DAM: Error in timestamp conditions -> \n" +
                                        "p_sTableName: " + p_sTableName + ",\n TagName: " + XPATHDATAFilter + ",\n time_stamp=" + time_stamp + ",\n NearestTimeStamp=" + NearestTimeStamp.ToString());
                                }
                                else if ((time_stamp != "") && (NearestTimeStamp != 0.0) && (CurrentTimeStampDB != NearestTimeStamp))
                                {
                                    throw new Exception("DAM: Error in timestamp conditions -> \n" +
                                         "p_sTableName: " + p_sTableName + ",\n TagName: " + XPATHDATAFilter + ",\n time_stamp=" + time_stamp + ",\n NearestTimeStamp=" + NearestTimeStamp.ToString());
                                }
                                else result = true;
                                if (result)
                                {
                                    if (p_XmlUserInfo.ChildNodes[1] != null)
                                    {
                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                           (Node, "UpdateUserId",
                                           p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                           p_XmlData);
                                        m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes(xmlAttributes, "UpdateUserId");
                                    }


   
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                         (Node, "UpdateTimeStamp",
                                          m_ApplicationManager.m_SQLUtil.Get_CurrentTimeStamp().ToString(),
                                         p_XmlData);
                                    m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes(xmlAttributes, "UpdateTimeStamp");


                                    GetUpdate_DBNames(p_sTableName, out str_sTable, out sName);
                                    str_ProcedureName = sName;
                                    s_TableName = str_sTable;
                                    pWhereId = "Id = " + Id;

                                    //For Update : @pTableName , @pNames_Values , @pWhereId
                                    pNames_Values = Build_UpdateNames_Values(xmlAttributes, Node, Id);



                                    strCommand = "EXEC " + str_ProcedureName + " '" + s_TableName + "', '" + pNames_Values + "','" + pWhereId + "'";
                                    p_command.CommandText = strCommand;
                                    p_command.ExecuteNonQuery();
                                }
                            }
                        }

                        //Case Of Insert
                        bool bSupportsExternalId = false;
                        XmlNodeList ListInsert = p_XmlData.SelectNodes(XPATHDATAFilter + "[@Status='Insert']");
                        if (ListInsert.Count != 0)
                        {
                            foreach (XmlNode Node in ListInsert)
                            {
                                GetInsert_DBNames(p_sTableName, out str_sTable, out sName, out bSupportsExternalId);
                                str_ProcedureName = sName;
                                s_TableName = str_sTable;

                                //Get nextID if not given by the user
                                string CurrId = m_ApplicationManager.m_XmlUtility.SafeGetAttributeValue(Node, "Id");
                                if (CurrId != "" && bSupportsExternalId)
                                {
                                    if (int.Parse(CurrId) == -1)
                                    {
                                        m_ApplicationManager.m_Numerator.GetNextNumber(s_TableName, p_command, p_XmlUserInfo, out i_NextId, out p_XmlErrors);
                                        MaxId = i_NextId;
                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                        (Node, "Id", MaxId.ToString(), p_XmlData);
                                    }
                                }
                                else
                                {
                                    m_ApplicationManager.m_Numerator.GetNextNumber(s_TableName, p_command, p_XmlUserInfo, out i_NextId, out p_XmlErrors);
                                    MaxId = i_NextId;
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                        (Node, "Id", MaxId.ToString(), p_XmlData);
                                }
                                m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes
                                   (xmlAttributes, "Id");

                                m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                    (Node, "InsertTimeStamp", CurrentTimeStamp.ToString(), p_XmlData);
                                m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes
                                    (xmlAttributes, "InsertTimeStamp");

                                m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                    (Node, "UpdateTimeStamp", CurrentTimeStamp.ToString(), p_XmlData);
                                m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes
                                   (xmlAttributes, "UpdateTimeStamp");
                                if (p_XmlUserInfo.ChildNodes[1] != null)
                                {
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                        (Node, "InsertUserId",
                                        p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                        p_XmlData);
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                        (Node, "UpdateUserId",
                                        p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                        p_XmlData);
                                }
                                if (p_XmlUserInfo.ChildNodes[1] == null)
                                {
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                         (Node, "InsertUserId",
                                        p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                         p_XmlData);
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                        (Node, "UpdateUserId",
                                        p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                        p_XmlData);
                                }
                                m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes
                                    (xmlAttributes, "InsertUserId");
                                ////////try
                                m_ApplicationManager.m_XmlUtility.SafeAddXMLAttributeToXMLAttributes
                                   (xmlAttributes, "UpdateUserId");
                                str_ColumnsName = Build_InsertNames_Values(xmlAttributes, Node, out str_ColumnsValue);
                                strCommand = "EXEC " + str_ProcedureName + " '" + s_TableName + "', '" +
                                    str_ColumnsName + "','" +
                                    str_ColumnsValue + "'";
                                p_command.CommandText = strCommand;
                                p_command.ExecuteNonQuery();

                            }
                        }

                        //Case Of Delete
                        XmlNodeList ListDelete = p_XmlData.SelectNodes(XPATHDATAFilter + "[@Status='Delete']");
                        if (ListDelete.Count != 0)
                        {
                            foreach (XmlNode Node in ListDelete)
                            {
                                Id = Node.Attributes["Id"].Value;
                                if (p_XmlUserInfo.ChildNodes[1] != null)
                                {
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                       (Node, "DeleteUserID",
                                       p_XmlUserInfo.ChildNodes[1].Attributes["UserName"].Value,
                                       p_XmlData);
                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute
                                       (Node, "DeleteTimeStamp", CurrentTimeStamp.ToString(), p_XmlData);
                                }

                                GetDelete_DBNames(p_sTableName, out str_sTable, out sName);
                                str_ProcedureName = sName;
                                s_TableName = str_sTable;
                                strCommand = "EXEC " + str_ProcedureName + " '" + s_TableName + "', '" + Id + "'";
                                p_command.CommandText = strCommand;
                                p_command.ExecuteNonQuery();
                            }
                        }
                        ////case of setlevel
                        //XmlNodeList ListSetLevel = p_XmlData.SelectNodes(XPATHDATAFilter + "[@Status='SetLevel']");
                        //if (ListSetLevel.Count != 0)
                        //{
                        //    foreach (XmlNode Node in ListSetLevel)
                        //    {
                        //        Id = Node.Attributes["Id"].Value;
                        //        //Delete_StoredProcedure_Name(p_sTableName, out str_sTable, out sName);
                        //        str_ProcedureName = "SetLevel";
                        //        s_TableName = str_sTable;
                        //        string strCommand = "EXEC " + str_ProcedureName + "'" + Id + "'";
                        //        p_command.CommandText = strCommand;
                        //        int i = p_command.ExecuteNonQuery();
                        //    }
                        //}

                        break;
                }

                //Log EXIT (Pouts)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_sTableName", p_sTableName, "TagName", XPATHDATAFilter, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlData", p_XmlData, "p_XmlFieldsNames", null, //XML Values
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
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                     "p_sTableName", p_sTableName, "TagName", XPATHDATAFilter, //String values
                     null, null, null, null, //String values
                     null, null, null, null,     //Int Values
                     null, null, null, null, //Int values
                     "p_XmlData", p_XmlData, "p_XmlFieldsNames", null, //XML Values
                     null, null, null, null,
                     p_XmlUserInfo,
                     e  //Exception Values
                    );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);

                return false;
            }
        }

        private void TransformDate(XmlNodeList p_NodeListData, XmlDocument p_AttributeList)
        {
            List<string> Datelist = new List<string>();
            XmlNodeList List = p_AttributeList.SelectNodes("//node");
            foreach (XmlNode Node in List)
            {
                string text = Node.InnerText;
                if (text.Contains("Date") || text.Contains("date"))
                {
                    if (!text.Contains("Update"))
                    {
                        Datelist.Add(text);
                    }
                }
            }
            if (Datelist.Count > 0)
            {
                foreach (XmlNode Node in p_NodeListData)
                {
                    for (int i = 0; i < Datelist.Count; i++)
                    {
                        if (Node.Attributes[Datelist[i]] != null)
                        {
                            string NodeValue = Node.Attributes[Datelist[i]].Value;
                            if (NodeValue != null)
                            {
                                if (NodeValue.IndexOf('/') != -1 || NodeValue.IndexOf('-') != -1)
                                    Node.Attributes[Datelist[i]].Value = m_ApplicationManager.m_SQLUtil.TextToDouble(NodeValue).ToString();
                                //"dbo.Date2Number(''" + NodeValue + "'')";
                            }
                        }
                    }
                }
            }
        }

        public SqlCommand GetCommand(XmlDocument p_XmlUserInfo)
        {

            string strSiteId = p_XmlUserInfo.DocumentElement.Attributes["SiteId"].Value;
            string strDB = "";
            string UserId = "";
            string pwd = "";
            string strDataSource = "";

            XmlDocument XmlConnectionData = new XmlDocument();

            //write attr for m_xmlsites
            if (m_ApplicationManager.m_XmlSites != null)
            {
                string ConnectionData = m_ApplicationManager.m_XmlSites;
                XmlConnectionData.LoadXml(ConnectionData);
                XmlNode DataNode = XmlConnectionData.SelectSingleNode("//Site[@Id='" + strSiteId + "']");
                strDB = DataNode.Attributes["strDB"].Value;
                UserId = DataNode.Attributes["UserId"].Value;
                pwd = DataNode.Attributes["pwd"].Value;
                strDataSource = DataNode.Attributes["strDataSourceProd"].Value;

            }
            else
            {
                try
                {
                    strDB = p_XmlUserInfo.DocumentElement.Attributes["strDB"].Value;
                    UserId = p_XmlUserInfo.DocumentElement.Attributes["UserId"].Value;
                    pwd = p_XmlUserInfo.DocumentElement.Attributes["pwd"].Value;
                    strDataSource = "TNM-SQL;";
                }
                catch
                {
                    strDB = "";
                }
            }


            //Don't delete this - Tomer 08/08/06
            //byte[] bytes = new byte[1000];
            //XmlDocument doc = new XmlDocument();
            //Assembly a = Assembly.GetExecutingAssembly();
            //Stream txtStream = null;
            ////StreamReader txtStreamReader = null;
            //string[] resNames = a.GetManifestResourceNames();
            //txtStream = a.GetManifestResourceStream(resNames[0]);
            //int numBytesToRead = (int)txtStream.Length;
            //int numBytesRead = 0;
            //while (numBytesToRead > 0)
            //{
            //    //Read may return anything from 0 to numBytesToRead.
            //    int n = txtStream.Read(bytes, numBytesRead, numBytesToRead);
            //    //The end of the file is reached.
            //    if (n == 0)
            //        break;
            //    numBytesRead += n;
            //    numBytesToRead -= n;
            //}
            //txtStream.Close();
            //ByteConverter byteconverter = new ByteConverter();
            //string s = ASCIIEncoding.ASCII.GetString(bytes);
            //Don't delete this - Tomer 08/08/06








            SqlCommand Command = new SqlCommand();


            //put it in hash-table
            SqlConnection Connection = new SqlConnection("data source=" + strDataSource + ";Pooling=True;Connect Timeout=600;initial catalog=" + strDB + ";User Id=" + UserId + ";Password=" + pwd + ";");


            Connection.Open();
            Command.Connection = Connection;
            Command.CommandTimeout = 120;
            Command.CommandText = "SET DATEFORMAT dmy";
            Command.ExecuteNonQuery();
            return Command;
        }

        public void CloseCommand(SqlCommand Command, XmlDocument UserInfo)
        {
            Command.Connection.Close();
            Command.Connection = null;
            Command.Dispose();
        }

        #region Private Functions

        //************************************************************************
        //* This is the main function which maps the logic sTableName           **
        //*    to the physical Stored ptocedure name required for getting data  **
        //* Similar we have also Get_StoredProcedure_Name,                      **
        //*      Save_StoredProcedure_Name,Delete_StoredProcedure_Name          **
        //*                                                                     **
        //* Writeen by Danny 26/2/2006                                          **
        //************************************************************************
        private void Get_StoredProcedure_Name(string p_DataTable, string p_TagName,
                                             int p_language, out string p_SQLTable,
                                             out string p_sName)
        {
            bool Is_aView = false;
            p_sName = "";
            p_SQLTable = "";
            string sDataTable = p_DataTable;
            string sAlias = null;
            if (sDataTable.StartsWith("Queries_"))
            {
                Is_aView = false;
                p_sName = "Select_Queries";
                p_SQLTable = sDataTable.Substring(8);
            }
            else
            {

                switch (sDataTable)
                {
                    case "NC_Main":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = sDataTable;
                            break;
                        }


                    case "NC_Elements":
                    case "NC_CS":
                    case "NC_Documentation":
                    case "NC_OP":
                    case "ASM_Main":
                    case "ASM_Elements":
                    case "ASM_CS":
                    case "ASM_Documentation":
                    case "SAP_Main":
                    case "SAP_Elements":
                    case "SAP_OP":
                    case "SAP_CS":
                    case "SAP_Documentation":
                    case "CLT_Main":
                    case "CLT_Elements":
                    case "CLT_Test":
                    case "CLT_Documentation":
                    case "CLT_CS":
                    case "CLT_PRCRow":
                    case "SPC_Part_Template_Value":
                    case "SPC_Part_Template":
                    case "SPC_Book":
                    case "SPC_Book_Section":
                    case "SPC_Book_Stage":
                    case "SPC_Part":
                    case "Spc_Part":
                    case "SPC_Main":
                    case "PRC_Main":
                    case "PRC_TemplateRow":
                    case "GEN_CodeHead":
                    case "SPC_Stage":
                    case "PRJ_Stage_Material":
                    case "ElementDataIndex_Elements":
                     case "ORD_CS":
                    case "ORD_MAIN_Elements":
                    case "PRJ_Product_Relation":
                    case "PRJ_ProductTree":
                    case "APR_MaterialSource_CS":
                    case "APR_MaterialSource_Test":
                    case "APR_MaterialSource_Elements":
                    case "APR_MaterialSource_Documentation_Files":
                    case "APR_Supplier":
                    case "APR_Team_CS":
                    case "APR_Team_Test":
                    case "APR_Team_Elements":
                    case "APR_Team_Material":
                    case "APR_Team_Documentation":
                    case "APR_Contractor_Elements":
                    case "APR_Contractor_Documentation":
                    case "TST_Part":
                    case "TST_Part_ColumnFormat":
                    case "TST_Part_Row":
                    case "TST_Part_Row_Value":
                    case "TST_CS":
                    case "TST_Elements":
                    case "TST_Documentation":
                    case "INT_Part":
                    case "vint_part":
                    case "INT_Part_ColumnFormat":
                    case "INT_Part_Row":
                    case "INT_Part_Row_Value":
                    case "INT_Docs":
                    case "GEN_LanguageStrings":
                    case "GEN_GeoDocConfig":
                    case "Doc_Main":
                    case "Doc_Elements":
                    case "Doc_Documentation":
                    case "PSS_Main":
                    case "PSS_RuleRangeDef":
                    case "PSS_RuleRange_Values":
                    case "PSS_RuleZfifiutStatisticDef":
                    case "PSS_RuleRange_ExcludesMatirials":
                    case "vPSS_Main":
                    case "LYPDEF_CSAttr":
                    case "LYPDEF_LYRAttr":
                    case "USER_Main":
                    case "USER_Role":
                    case "Gen_Log":
                    case "Gen_ClientAppLog":
                    case "Gen_WebServerLog":
                    case "GEN_Storage":
                    case "RPT_Ext":

                        {
                            p_sName = "Select_All";
                            p_SQLTable = sDataTable;
                            break;
                        }


                    case "SPC_Book_Stage_Spec":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vSPC_Book_Stage_Spec";
                            sAlias = sDataTable;
                            break;
                        }
                    case "SPC_Book_Stage_SubStage":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vSPC_Book_Stage_SubStage";
                            sAlias = sDataTable;
                            break;
                        }
                    case "realSPC_Book_Stage_Spec":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "SPC_Book_Stage_Spec";
                            sAlias = "SPC_Book_Stage_Spec";
                            break;
                        }

                     case "SPC_Part_Column":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "SPC_Part_Column";
                            break;
                        }
                    case "GEN_CodeRow":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "GEN_CodeRow";
                            break;
                        }

                    case "USER_MainWithRole":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "USER_MainWithRole";
                            break;
                        }

                    case "GEN_CodeRowReal":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "GEN_CodeRowReal";
                            break;
                        }
                    case "Prj_Material":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "Prj_Material";
                            break;
                        }
                    case "ElementDataIndex":
                        {
                            Is_aView = false;
                            p_sName = "Select_All";
                            p_SQLTable = "ElementDataIndex";
                            break;
                        }


                    case "SelectedElementDataIndex":
                    case "FreeTextSearchElementDataIndex":
                        {
                            Is_aView = true;
                            p_sName = "SelectedElementDataIndex";
                            p_SQLTable = "SelectedElementDataIndex";
                            break;
                        }






                    case "ORD_MAIN":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = sDataTable;
                            Is_aView = true;
                            break;
                        }

                    case "ORD_Attribute":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = sDataTable;
                            Is_aView = true;
                            break;
                        }


                    case "ORD_StageAttribute":
                        {

                            p_sName = "Select_All";
                            p_SQLTable = "vORD_StageAttribute";
                            p_TagName = "ORD_StageAttribute";
                            break;
                        }

                    case "ORD_ExtendedWithProductID":
                        {
                            Is_aView = true;
                            p_sName = "ORD_Selection";
                            p_SQLTable = "ORD_Main";
                            break;
                        }


                    case "CLT_TestBriefRow":
                        {

                            p_sName = "Select_All";
                            p_SQLTable = "vCLT_TestBriefRow";
                            p_TagName = "CLT_TestBriefRow";
                            break;
                        }
                    case "CLTForSign":
                        {

                            p_sName = "Select_All";
                            p_SQLTable = "vCLTForSign";
                            p_TagName = "CLTForSign";
                            break;
                        }


                    case "TST_StageAttribute":
                        {

                            p_sName = "Select_All";
                            p_SQLTable = "vTST_StageAttribute";
                            p_TagName = "TST_StageAttribute";
                            break;
                        }
                    case "MaterialName":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vMaterialName";
                            break;
                        }


                    case "MaxProductTreeChildPos":
                        {

                            p_sName = "SP_GetMaxChildPos";
                            p_SQLTable = sDataTable;
                            break;
                        }

                    case "ProductTreeFull":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vProductTreeFull";
                            break;
                        }
                    case "ProductTreeRoot":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vProductTreeRoot";
                            break;
                        }


                    case "APR_Index":
                    case "APR_MaterialSource":
                    case "APR_IndexwithStageMatirialComments":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = sDataTable;
                            break;
                        }



                    case "APR_MaterialSource_Documentation":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "APR_MaterialSource_Documentation";
                            break;
                        }


                    case "APR_Team":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "APR_Team";
                            break;
                        }

                    case "APR_Contractor":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "APR_Contractor";
                            break;
                        }


                    case "INT_Main":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vINT_Main";
                            sAlias = "INT_MAIN";
                            break;
                        }

                    case "SPC_Book_Stage_Spec_Attribute":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "SPC_Book_Stage_Spec_Attribute";
                             break;
                        }


                    case "Count(TST_Main)":
                    case "Tst_Main":
                    case "TST_Main":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "TST_Main";
                            //sAlias = "TST_MAIN";
                            break;
                        }


                    case "TST_Result_Value":
                        {
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = "TST_Result_Value";
                            break;
                        }


                    case "INT_MainUseCount":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vINT_MainUseCount";
                            sAlias = "INT_MainUseCount";
                            break;
                        }
                    case "INT_MainUnUsedOnly":
                        {
                            p_sName = "Select_All";
                            p_SQLTable = "vINT_MainUnUsedOnly";
                            sAlias = "INT_MainUseCount";
                            break;
                        }

                    case "qcAdmin_int_docs":
                    case "qcAdmin_int_MissingSpcBookStageSpecId":
                    case "qc_Admin_int_main":
                        {
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "int_main";
                            break;
                        }
  

                    case "qcAdmin_int_InTst":
                        {
                            Is_aView = true;
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "INT_MainUseCount";
                            break;
                        }

                    case "qcAdmin_int_NotInTst":
                        {
                            Is_aView = true;
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "vINT_MainUnUsedOnly";
                            break;
                        }
                    case "qc_Admin_INT_MAIN_UPDATE_LOG":
                        {
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "INT_MAIN_UPDATE_LOG";
                            break;
                        }
                    case "qc_Admin_INT_IMP_LOG":
                        {
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "INT_IMP_LOG";
                            break;
                        }



                    case "qc_Admin_part":
                        {
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "v_qcAdmin_part_row";
                            break;
                        }
                    case "qcAdmin_NeverSent":
                        {
                            p_sName = "sp_Qc_Admin";
                            p_SQLTable = "INT_LAB_List";
                            break;
                        }


                    case "PSS_MaterialRange":
                        {
                            //Is_MultiLanguage = true;
                            Is_aView = true;
                            p_sName = "Select_All";
                            p_SQLTable = p_DataTable;
                            p_TagName = "PSS_RuleRange_Values";
                            break;
                        }
                    case "LD_Main":
                    case "LD_STG":
                    case "LD_CS":
                    case "LD_STG_CS":
                    case "LY_Main":
                    case "LY_CLT":
                    case "LY_TST":
                        {
                            Is_aView = false;
                            p_sName = "Select_All";
                            p_SQLTable = p_DataTable;
                            break;
                        }
                    case "PRJ_Product_Relation_LevelId":
                        {
                            p_sName = "SetLevel";
                            p_SQLTable = p_DataTable;
                            break;
                        }
                    default:
                        break;
                }
            }
            if (Is_aView)
            {
                sAlias = p_SQLTable.ToString();
                p_SQLTable = "v" + p_SQLTable;

            }

            if (p_TagName != null)
                if (p_TagName != "") sAlias = p_TagName;


            if (sAlias != null)
                p_SQLTable = p_SQLTable + " " + sAlias;

        }


        private void GetInsert_DBNames(string p_sLogicalTableName,
                                              out string p_sDBTableName,
                                              out string p_sDBSToredProcedureName,
                                              out bool p_SupportsExtrnalId)
        {

            p_sDBTableName = GetDBTableName(p_sLogicalTableName);
            p_sDBSToredProcedureName = "Insert_Row";

            //Switch for sTableName
            p_SupportsExtrnalId = false;
            switch (p_sLogicalTableName)
            {
                case "SAP_Main":
                case "ASM_Main":
                case "NC_Main":
                case "CLT_Main":
                case "APR_Team":
                case "APR_MaterialSource":
                case "APR_Contractor":
                    p_SupportsExtrnalId = true;
                    break;
                case "TST_AutoCalculation":
                case "CLT_Validate":
                case "APR_Team_Validate":
                case "APR_MaterialSource_Validate":
                case "TST_Validate":
                case "ASM_Validate":
                case "DOC_Validate":
                case "NC_Validate":
                case "SAP_Validate":


                    p_sDBSToredProcedureName = p_sLogicalTableName;
                    break;

                default:
                    break;
            }

        }
        private void GetUpdate_DBNames(string p_sLogicalTableName,
                                                out string p_sDBTableName,
                                                out string p_sDBSToredProcedureName)
        {
            p_sDBTableName = GetDBTableName(p_sLogicalTableName);
            p_sDBSToredProcedureName = "Update_Row";
            switch (p_sLogicalTableName)
            {
                case "TST_AutoCalculation":
                case "CLT_Validate":
                case "APR_Team_Validate":
                case "APR_MaterialSource_Validate":
                case "TST_Validate":
                case "ASM_Validate":
                case "DOC_Validate":
                case "NC_Validate":
                case "SAP_Validate":
                case "CLT_AutoSign":
                

                    p_sDBSToredProcedureName = p_sLogicalTableName;
                    break;
            }

        }



        private void GetDelete_DBNames(string p_sLogicalTableName,
                                                  out string p_sDBTableName,
                                                  out string p_sDBSToredProcedureName)
        {
            p_sDBTableName = GetDBTableName(p_sLogicalTableName);
            p_sDBSToredProcedureName = "Delete_Row";
        }

        private bool IsSupportLogicalDelete(string sTableName)
        {
            bool b_SupportsLogicalDelete = false;
            switch (sTableName)
            {
                case "GEN_CodeRowReal":
                case "PRJ_ProductTree":
                case "PRJ_Product_Relation":
                case "PRJ_Stage_Material":
                case "SPC_Book":
                case "SPC_Stage":
                case "SPC_Book_Stage":
                case "SPC_Book_Stage_Spec":
                case "SPC_Main":
                case "SPC_Part":
                case "SPC_Part_Column":
                case "LYPDEF_Main":
                case "USER_Main":
                case "USER_Role":


                    b_SupportsLogicalDelete = true;
                    break;
                default:
                    break;
            }
            return b_SupportsLogicalDelete;
        }

        //************************************************************************
        //* This is the function which maps the logic sTableName                **
        //*    to the physical Table name in DB                                 **
        //* Writeen by Danny 26/2/2006                                          **
        //************************************************************************
        private string GetDBTableName(string p_sLogicalTableName)
        {
            string sDataTable = p_sLogicalTableName;

            string sDBTableName = "";
            switch (sDataTable)
            {
                case "APR_Index":
                case "APR_IndexwithStageMatirialComments":
                case "APR_MaterialSource":
                case "APR_MaterialSource_Documentation":
                case "APR_MaterialSource_Documentation_Files":
                case "APR_MaterialSource_Test":
                case "APR_MaterialSource_Elements":
                case "APR_Team_Elements":
                case "APR_Team":
                case "APR_Team_CS":
                case "APR_Team_Documentation":
                case "APR_Team_Test":
                case "APR_Contractor":
                case "APR_Contractor_Elements":
                case "APR_Contractor_Documentation":
                case "ASM_CS":
                case "ASM_Documentation":
                case "ASM_Elements":
                case "ASM_Main":
                case "CLT_CS":
                case "CLT_Documentation":
                case "CLT_Elements":
                case "CLT_Main":
                case "CLT_Test":
                case "CLT_PRCRow":
                case "CLT_TestBriefRow":
                case "CLTForSign":
                case "CLT_AutoSign":
                case "Doc_Documentation":
                case "Doc_Elements":
                case "Doc_Main":
                case "GEN_CodeRow":
                case "GEN_CodeRowReal":
                case "GEN_LanguageStrings":
                case "INT_MAIN":
                case "INT_Docs":
                case "NC_CS":
                case "NC_Documentation":
                case "NC_Elements":
                case "NC_Main":
                case "NC_OP":
                case "NC_Test":
                case "ORD_CS":
                case "ORD_Main":
                case "ORD_MAIN":
                case "ORD_MAIN_Elements":
                case "ORD_Attribute":
                case "ElementDataIndex":
                case "ElementDataIndex_Elements":
                case "PRJ_Product_Relation":
                case "PRJ_ProductTree":
                case "PRJ_Stage_Material":
                case "SAP_CS":
                case "SAP_Documentation":
                case "SAP_Elements":
                case "SAP_Main":
                case "SAP_OP":
                case "SPC_Book":
                case "SPC_Book_Stage":
                case "SPC_Book_Stage_SubStage":
                case "SPC_Book_Stage_Spec":
                case "SPC_Main":
                case "SPC_Part":
                case "SPC_Part_Column":
                case "SPC_Stage":
                case "SPC_SubStage":
                case "PRC_Main":
                case "PRC_TemplateRow":
                case "TST_CS":
                case "TST_Elements":
                case "TST_Documentation":
                case "TST_Main":
                case "TST_Part":
                case "TST_Part_ColumnFormat":
                case "TST_Part_Row":
                case "TST_Part_Row_Value":
                case "TST_StageAttribute":
                case "TST_AutoCalculation":
                case "TST_Validate":
                case "CLT_Validate":
                case "APR_Team_Validate":
                case "APR_MaterialSource_Validate":
                case "ASM_Validate":
                case "DOC_Validate":
                case "NC_Validate":
                case "SAP_Validate":
                  case "PSS_Main":
                case "PSS_RuleRangeDef":
                case "PSS_RuleRange_Values":
                case "USER_Main":
                case "USER_Role":
                case "USER_MainWithRole":
                case "Gen_WebServerLog":
                case "Gen_ClientAppLog":
                case "GEN_Storage":
                case "LD_Main":
                case "LD_STG":
                case "LD_CS":
                case "LD_STG_CS":
                case "LY_Main":
                case "LY_CLT":
                case "LY_CS":
                case "RPT_Ext":

                    {
                        sDBTableName = p_sLogicalTableName;
                        break;
                    }

                 default:
                    break;
            }
            return sDBTableName;


        }

        private void ChangeDeleteToLogicalDelete(XmlNodeList p_NodeListData, XmlDocument p_AttributeList)
        {
            foreach (XmlNode Node in p_NodeListData)
            {
                if (Node.Attributes["Status"].Value == "Delete")
                {
                    Node.Attributes["Status"].Value = "Update";
                    if (Node.Attributes["isdeleted"] != null)
                        Node.Attributes["isdeleted"].Value = "1";
                    else
                        Node.Attributes["IsDeleted"].Value = "1";
                    //AttributeString = "<root><node>RowId</node><node>Name</node><node>Pos</node><node>InsertTimeStamp</node><node>UpdateTimeStamp</node><node>TableId</node><node>isdeleted</node></root>";
                    //bDeletedOrUpdate = true;
                }
            }
        }

        private double Get_InsertTimeStamp(string p_TableName, string p_Id,
                                           SqlCommand p_oCommand,
                                           out XmlDocument p_xmlErrors)
        {
            try
            {
                p_xmlErrors = null;
                string TimeStamp = "";
                //List<string> AttributeList; 
                p_oCommand.CommandText = "EXEC Create_Get_InsertTimeStamp " + "'" + p_TableName + "','" + p_Id + "'";
                SqlDataReader reader = p_oCommand.ExecuteReader();
                if (reader.Read())
                {
                    //object TempObject; //for casting
                    //m_SessionManager.m_CacheManager.Get("AttributeList", out TempObject, out p_XmlErrors);
                    //AttributeList = (List<string>)TempObject;
                    TimeStamp = reader["InsertTimeStamp"].ToString();

                }
                reader.Dispose();
                reader.Close();
                if (TimeStamp.Trim().Equals("")) TimeStamp = "0";
                return double.Parse(TimeStamp);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

        private string Build_UpdateNames_Values(XmlDocument AttributeList,
                                          XmlNode Node, string Id)
        {
            string Names_Value;
            StringBuilder names = new StringBuilder();
            XmlNodeList NodeList = AttributeList.SelectNodes("//node");
            string ColumnName = "";
            string Value = "";
            foreach (XmlNode AttributeNode in NodeList)
            {
                ColumnName = AttributeNode.InnerText;
                if (Node.Attributes[ColumnName]!=null)
                {
                    Value = Node.Attributes[ColumnName].Value; //Value of the 

                    if (Value.Contains("'"))
                    {
                        //int index = Value.IndexOf("'");
                        //Value = Value.Insert(index, "'''");
                        Value = Value.Replace("'", "''''");
                    }
                    if (ColumnName == "InsertTimeStamp")
                    {
                        if (Value.Contains("/"))
                            Value = m_ApplicationManager.m_SQLUtil.TextToDouble(Value).ToString();
                    }
                    if ((ColumnName.Contains("Date")) || (ColumnName == "InsertTimeStamp"))
                    {
                        double dblValue;
                        if (double.TryParse(Value, out dblValue))
                            names.Append(ColumnName + " = " + Value + " ");
                        else
                            names.Append(ColumnName + " = " + "0" + " ");

                    }
                    else
                    {
                        names.Append(ColumnName + " = ''" + Value + "'' ");
                    }
                    if (AttributeNode.NextSibling != null) names.Append(", ");
                }
            }
            XmlNode IsDeletedNode = Node.Attributes["isdeleted"];
            if (IsDeletedNode==null)
                IsDeletedNode = Node.Attributes["IsDeleted"];
            bool bIsDeleted = IsDeletedNode != null;
            if (bIsDeleted)
                bIsDeleted = IsDeletedNode.Value != "0";

            if (bIsDeleted && !names.ToString().Contains("isdeleted") && !names.ToString().Contains("IsDeleted"))
                names.Append(", IsDeleted = ''1'' ");

            Names_Value = names.ToString();
            int pos = Names_Value.Trim().Length;
            if (',' == Names_Value.Trim()[pos - 1]) Names_Value = Names_Value.Remove((pos - 1)) + " ";
            return Names_Value;
        }

        private string Build_InsertNames_Values(XmlDocument AttributeList,
                                                XmlNode Node,
                                                out string ColumnsValue)
        {
            int startIndex = 0;
            string ColumnsName = "";
            XmlNodeList NodeList = AttributeList.SelectNodes("//node");
            StringBuilder columnNames = new StringBuilder();
            StringBuilder columnValues = new StringBuilder();
            bool Flag = false;
            string innerText = "";
            string ColumnName;
            string ColumnValue;

            foreach (XmlNode AttributeNode in NodeList)
            {
                if (!AttributeNode.InnerText.Contains(" "))
                {
                    ColumnName = AttributeNode.InnerText;
                }
                else
                {
                    startIndex = AttributeNode.InnerText.IndexOf(' ');
                    ColumnName = AttributeNode.InnerText.Substring(startIndex);
                    Flag = true;
                }
                if (Flag) innerText = AttributeNode.InnerText.Substring(0, startIndex);
                else innerText = AttributeNode.InnerText;

                //string NodeValue = null;// = Node.Attributes[innerText].Value;
                if (Node.Attributes[innerText] != null)
                {
                    ColumnValue = Node.Attributes[innerText].Value.ToString();
                    if (ColumnName.Contains("Date"))
                    {
                        double dblValue;
                        if (!double.TryParse(ColumnValue, out dblValue))
                            ColumnValue = "0";
                    }


                    if (!ColumnValue.StartsWith("dbo"))
                    {
                        ColumnValue = " ''" + ColumnValue.Replace("'", "''''") + "'' ";
                    }
                    else
                        ColumnValue = " " + ColumnValue + " ";
                }
                else
                    ColumnValue = " null ";





                if (ColumnName.ToLower() != "isdeleted")
                {
                    columnNames.Append(ColumnName + ",");
                    columnValues.Append(ColumnValue + ",");

                }
                Flag = false;
            }

            columnNames.Append("IsDeleted");
            columnValues.Append("''0''");

            ColumnsValue = columnValues.ToString();
            ColumnsName = columnNames.ToString();
            return ColumnsName;

        }

        private bool GetMyRegString(string pKey, out string p_connStr)
        {
            try
            {
                Microsoft.Win32.RegistryKey reg;
                p_connStr = null;
                reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\ControlQ\\", true);
                if (reg != null)
                    p_connStr = reg.GetValue(pKey, null).ToString();
                else
                    p_connStr = null;
                return true;
            }
            catch
            {

                p_connStr = null;
                return false;

            }

        }
        #endregion


    }
}
