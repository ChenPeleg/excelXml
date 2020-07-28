using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;

namespace PrjSApp
{
    public enum levels { SPC_Book = 1, SPC_Book_Stage, SPC_Book_Stage_Spec, SPC_Part, SPC_Part_Column }
    public class BOSPCBook : BOAbstract
    {
       // public PrjSApp.ApplicationManager m_ApplicationManager;
        public BOSPCBook()
        {

        }

        public override bool GetData(string p_DataId, XmlDocument p_XmlWhere,
                                        XmlDocument p_XmlSort,
                                        int p_MaxCount,
                                        SqlCommand p_command,
                                        XmlDocument p_XmlUserInfo,
                                        out XmlDocument p_XmlData,
                                        out XmlDocument p_XmlErrors)
        {
            XmlDocument Xml_SPC = new XmlDocument();
            p_XmlData = null; 
            string TableName = "";
            string p_StringData = "";
            p_XmlErrors = null;
            PrjSApp.clsLogManager.OperationTypes OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionEntry;
            string ClassName = this.GetType().ToString();

            try
            {
                //Log Entry (Pins)
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId,  //String values
                    null, null, //String values
                    null, null, //String values
                    null, null,  //String values
                    "p_MaxCount", p_MaxCount, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_xmlSort", p_XmlSort, //XML Values
                    "", null, "", null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );
                switch (p_DataId)
                {
                    case "Book":
                        {
                            TableName = "SPC_Book";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }

                    case "Book_Section":
                        {
                            TableName = "SPC_Book_Section";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }
                        
                    case "Book_Stage":
                        {
                            TableName = "SPC_Book_Stage";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }
                    case "Book_StageSpec":
                        {
                            TableName = "SPC_Book_Stage_Spec";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }
                    case "PRJ_Stage_Material":
                        {
                            TableName = "PRJ_Stage_Material";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }
                    case "SPC_Book_Stage_Spec_Attribute":
                        {
                            TableName = "SPC_Book_Stage_Spec_Attribute";
                            m_ApplicationManager.m_DAM.GetData(null, TableName, "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            Xml_SPC.LoadXml("<root>" + p_StringData + "</root>");
                            p_XmlData = Xml_SPC;
                            break;
                        }

                    case "Book_Full":
                        {

                            string[] TableName_Array = new string[3];
                            TableName_Array[0] = "SPC_Book";
                            TableName_Array[1] = "SPC_Book_Stage";
                            TableName_Array[2] = "SPC_Book_Stage_Spec";

                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[0], "", null, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            //loadxml
                            Xml_SPC.LoadXml(p_StringData);
                            //Building the where the rellevent Books to the project
                            XmlDocument XmlWhere;
                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlNode XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                            String ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 1, "Id");
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "BookId", "IN", ListValues, "");

                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[1], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            //dom,string->fragment
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullPath(Xml_SPC, p_StringData, "Id", "BookId", 1);

                            if (p_XmlWhere != null)
                            {
                                XmlWhere = p_XmlWhere;
                                XmlOrCondition = XmlWhere.SelectSingleNode("//ORcondition");
                            }
                            else
                            {
                                XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                                XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);
                            }

                            ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 2, "Id");

                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "BookStageId", "IN", ListValues, "");

                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[2], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullPath(Xml_SPC, p_StringData, "Id", "BookStageId", 2);

                            p_XmlData = Xml_SPC;
                            break;
                        }
                    case "SpecTree_Full":
                        {

                            string[] TableName_Array = new string[5];

                            TableName_Array[0] = "SPC_Book";
                            TableName_Array[1] = "SPC_Book_Stage";
                            TableName_Array[2] = "SPC_Book_Stage_Spec";
                            TableName_Array[3] = "SPC_Part";
                            TableName_Array[4] = "SPC_Part_Column";



                            string[] TableNameForShow = new string[5];

                            TableNameForShow[0] = "@#9416";
                            TableNameForShow[1] = "@#9417";
                            TableNameForShow[2] = "@#9418";
                            TableNameForShow[3] = "@#9419";
                            TableNameForShow[4] = "@#9420";

                            //TableNameForShow[0] = "9416";
                            //TableNameForShow[1] = "9417";
                            //TableNameForShow[2] = "9418";
                            //TableNameForShow[3] = "9419";
                            //TableNameForShow[4] = "9420";


                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[0], "", p_XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            //loadxml
                            //Xml_SPC.LoadXml(p_StringData);

                            //strReturnValue = p_StringData;
                            //p_StringData += "</ @#9424>";
                            //p_StringData = "<@#9424 >"+"  "  + p_StringData;
                            p_StringData += "</root>";
                            p_StringData = "<root >" + p_StringData;
                            Xml_SPC.LoadXml(p_StringData);


                            //Building the where the rellevent Books to the project

                            XmlDocument XmlWhere;


                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlNode XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                            // InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Book, TableNameForShow[Convert.ToInt32(levels.SPC_Bookage) - 1], out p_StringData);

                            //String ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 2, "Id");
                            String ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, "SPC_Book", "Id");
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "BookId", "IN", ListValues, "");


                            InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Book_Stage, TableNameForShow[Convert.ToInt32(levels.SPC_Book_Stage) - 1], out p_StringData);


                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", 2);
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", "SPC_Book");
                            p_XmlSort = m_ApplicationManager.m_SQLUtil.Build_EmptySort();
                            m_ApplicationManager.m_SQLUtil.Add_SortCondition(p_XmlSort, "Pos", "ASC");


                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[1], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);

                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "BookId", "Header_SPC_Book_Stage");
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "BookId", 3);


                            //  InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Book_Stage, TableNameForShow[Convert.ToInt32(levels.SPC_Book_Stage) - 1], out p_StringData);

                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                            //ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 4, "Id");
                            ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, "SPC_Book_Stage", "Id");

                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "BookStageId", "IN", ListValues, "");

                            InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Book_Stage_Spec, TableNameForShow[Convert.ToInt32(levels.SPC_Book_Stage_Spec) - 1], out p_StringData);
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", 4);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", "SPC_Book_Stage");

                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[2], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "BookStageId", 5);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "BookStageId", "Header_SPC_Book_Stage_Spec");

                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                            //ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 6, "SpecMainId");
                            ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, "SPC_Book_Stage_Spec", "SpecMainId");

                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "SpecMainId", "IN", ListValues, "");

                            InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Part, TableNameForShow[Convert.ToInt32(levels.SPC_Part) - 1], out p_StringData);
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "SpecMainId", "ParentId", 6);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "SpecMainId", "ParentId", "SPC_Book_Stage_Spec");

                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[3], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "SpecMainId", "SpecMainId", "Header_SPC_Part");
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "SpecMainId", "SpecMainId", 7);

                            XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();
                            XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                            ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, "SPC_Part", "Id");
                            //ListValues = m_ApplicationManager.m_XmlUtility.BuildAttributeList(Xml_SPC, 8, "Id");
                            m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "SpcPartId", "IN", ListValues, "");

                            //add
                            InsertHeaderRows(Xml_SPC, ListValues, levels.SPC_Part_Column, TableNameForShow[Convert.ToInt32(levels.SPC_Part_Column) - 1], out p_StringData);
                            // m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", 8);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "ParentId", "SPC_Part");

                            p_MaxCount = 1500;
                            m_ApplicationManager.m_DAM.GetData(null, TableName_Array[4], "", XmlWhere, p_XmlSort, p_MaxCount, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                            //m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "SpcPartId", 9);
                            m_ApplicationManager.m_XmlUtility.CombineXmlFullId(Xml_SPC, p_StringData, "Id", "SpcPartId", "Header_SPC_Part_Column");


                            p_XmlData = Xml_SPC;
                            break;
                        }
                }
                //Log EXIT (Pouts)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    "p_MaxCount", p_MaxCount, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_XmlSort", p_XmlSort, //XML Values
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
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "GetData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    "p_MaxCount", p_MaxCount, null, null, //Int Values
                    null, null, null, null, //Int values
                    "p_XmlWhere", p_XmlWhere, "p_XmlSort", p_XmlSort, //XML Values
                    null, null, null, null, //XML Values
                    p_XmlUserInfo,
                    e  //Exception Values
                    );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);
                
                return false;
            }
            
        }

        private void InsertHeaderRows(XmlDocument Xml_SPC, string ListValues, levels level, string Name, out string p_Headers)
        {
            StringBuilder Headers = new StringBuilder();
            string strInsertedIDs = "";
            string[] List = ListValues.Substring(1, ListValues.Length - 2).Split(',');
            foreach (string str in List)
            {
                if (!strInsertedIDs.Contains("," + str + ","))
                {
                    strInsertedIDs += "," + str + ",";
                    Headers.Append("<Header_").Append(level.ToString()).Append(" Id='").Append(str).Append("' ParentId='").Append(str).Append("' Name='").Append(Name).Append("' Level='").Append(Convert.ToInt32(level)).Append("' SpecMainId='").Append(str).Append("'/>");
                }
            }
            p_Headers = Headers.ToString();
        }

        public override bool SaveData(string p_DataId,
                                        ref XmlDocument p_XmlData,
                                        XmlDocument AttributeList,
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
                    "p_XmlData", p_XmlData, "AttributeList", AttributeList, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );

                switch (p_DataId)
                {
                    case "SPC_Tree_Full":
                    case "SpecTree_Full":
                        {

                            //string[] TableName_Array = new string[5];

                            //TableName_Array[0] = "SPC_Book";
                            //TableName_Array[1] = "SPC_Book_Stage";
                            //TableName_Array[2] = "SPC_Book_Stage_Spec";
                            //TableName_Array[3] = "SPC_Part";
                            //TableName_Array[4] = "SPC_Part_Column";
                            XmlDocument XmlData = new XmlDocument();
                            XmlNode Root;
                            Root = XmlData.CreateNode(XmlNodeType.Element, "Root", "");
                            XmlData.AppendChild(Root);
                            XmlNode newElem = XmlData.CreateNode(XmlNodeType.Element, "SpecTree_Full", "");

                            XmlAttribute Attr = null;

                            XmlNode xmlElem = p_XmlData.FirstChild.FirstChild;
                            string strStatus = xmlElem.Attributes["Status"].Value;
                            string strLevel = xmlElem.Attributes["Level"].Value;
                            switch (strLevel)
                            {
                                case "1"://book
                                    {
                                        switch (strStatus)
                                        {
                                            case "InsertNew":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Name 
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);
                                                    break;
                                                }
                                            case "Update":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);
                                                    break;
                                                }
                                            case "Delete":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //isdeleted
                                                    Attr = XmlData.CreateAttribute("isdeleted");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);
                                                    break;
                                                }

                                        }
                                        Root.AppendChild(newElem);

                                        if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book",
                                            XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                            return false;
                                        break;
                                    }
                                case "2"://stage
                                    {
                                        Attr = null;
                                        switch (strStatus)
                                        {
                                            case "InsertNew":
                                                {
                                                    //insert new data to SPC_Stage
                                                    //status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //send to save data
                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Stage",
                                                   XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    string strId = XmlData.FirstChild.FirstChild.Attributes["Id"].Value;
                                                    XmlData.RemoveAll();

                                                    Root = XmlData.CreateNode(XmlNodeType.Element, "Root", "");
                                                    XmlData.AppendChild(Root);
                                                    newElem = XmlData.CreateNode(XmlNodeType.Element, "SpecTree_Full", "");


                                                    //insert a relation to SPC_Book_Stage
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //BootId
                                                    Attr = XmlData.CreateAttribute("BookId");
                                                    Attr.Value = xmlElem.Attributes["ParentId"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //StageId
                                                    Attr = XmlData.CreateAttribute("StageId");
                                                    Attr.Value = strId;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //send to save data
                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage",
                                                    XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Insert":
                                                {
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //BookId
                                                    Attr = XmlData.CreateAttribute("BookId");
                                                    Attr.Value = xmlElem.Attributes["ParentId"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //StageId
                                                    Attr = XmlData.CreateAttribute("StageId");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);


                                                    //send to save data
                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage",
                                                    XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Update":
                                                {
                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";
                                                    string strId = xmlElem.Attributes["Id"].Value;

                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Book_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);
                                                    strId = Xml_Element.FirstChild.FirstChild.Attributes["StageId"].Value;

                                                    Xml_Element.RemoveAll();
                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);


                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = strId;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = Xml_Element.FirstChild.FirstChild.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = Xml_Element.FirstChild.FirstChild.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //send to save data
                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Stage",
                                                    XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    XmlData.RemoveAll();

                                                    Root = XmlData.CreateNode(XmlNodeType.Element, "Root", "");
                                                    XmlData.AppendChild(Root);
                                                    newElem = XmlData.CreateNode(XmlNodeType.Element, "SpecTree_Full", "");

                                                    //update the name in SPC_Book_Stage table

                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "StageId", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Book_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    foreach (XmlNode node in Xml_Element.FirstChild)
                                                    {
                                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(node, "Status", strStatus, Xml_Element);
                                                        node.Attributes["Name"].Value = xmlElem.Attributes["Name"].Value;
                                                        if (node.Attributes["Id"].Value == xmlElem.Attributes["Id"].Value)
                                                        {
                                                            node.Attributes["Pos"].Value = xmlElem.Attributes["Pos"].Value;
                                                        }
                                                    }
                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Delete":
                                                {
                                                    //Save the Stage Id 
                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    string strId = xmlElem.Attributes["Id"].Value;
                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Book_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);

                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    strId = Xml_Element.FirstChild.FirstChild.Attributes["StageId"].Value;
                                                    //delete the relation from SPC_Book_Stage table
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //isdeleted
                                                    Attr = XmlData.CreateAttribute("IsDeleted");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage",
                                                       XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;
                                                    //check if this is a last relation 

                                                    //update the name in SPC_Book_Stage table

                                                    Xml_Element.RemoveAll();

                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "StageId", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Book_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    if (p_StringData == "")//there are no another relations of this stage
                                                    {
                                                        Xml_Element.RemoveAll();

                                                        ListValues = "(" + strId + ")";

                                                        XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                        XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                        m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                        m_ApplicationManager.m_DAM.GetData(null, "SPC_Stage", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);

                                                        //Load xml
                                                        strReturnValue = p_StringData;
                                                        p_StringData += "</root>";
                                                        p_StringData = "<root>" + p_StringData;
                                                        Xml_Element.LoadXml(p_StringData);

                                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Delete", Xml_Element);

                                                        if (!m_ApplicationManager.m_DAM.SaveData("SPC_Stage",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                            return false;

                                                    }
                                                    break;
                                                }

                                        }


                                        break;
                                    }
                                case "3"://spec
                                    {
                                        switch (strStatus)
                                        {
                                            case "Insert":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //BookStageId
                                                    Attr = XmlData.CreateAttribute("BookStageId");
                                                    Attr.Value = xmlElem.Attributes["ParentId"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //SpecMainId
                                                    Attr = XmlData.CreateAttribute("SpecMainId");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage_Spec",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;
                                                    break;
                                                }
                                            case "InsertNew":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //NumParts
                                                    Attr = XmlData.CreateAttribute("NumParts");
                                                    Attr.Value = "0";
                                                    newElem.Attributes.Append(Attr);

                                                    //IsPassUpdateable
                                                    Attr = XmlData.CreateAttribute("IsPassUpdateable");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //save to SPC_Main table
                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Main",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    //insert the new relation
                                                    string strId = XmlData.FirstChild.FirstChild.Attributes["Id"].Value;
                                                    XmlData.RemoveAll();

                                                    Root = XmlData.CreateNode(XmlNodeType.Element, "Root", "");
                                                    XmlData.AppendChild(Root);
                                                    newElem = XmlData.CreateNode(XmlNodeType.Element, "SpecTree_Full", "");

                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //BookStageId
                                                    Attr = XmlData.CreateAttribute("BookStageId");
                                                    Attr.Value = xmlElem.Attributes["ParentId"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //SpecMainId
                                                    Attr = XmlData.CreateAttribute("SpecMainId");
                                                    Attr.Value = strId;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage_Spec",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Update":
                                                {
                                                    //update spc main
                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";
                                                    string strId = xmlElem.Attributes["Id"].Value;

                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "realSPC_Book_Stage_Spec", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);
                                                    strId = Xml_Element.FirstChild.FirstChild.Attributes["SpecMainId"].Value;
                                                    Xml_Element.RemoveAll();

                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Main", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);


                                                    //status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = strId;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = Xml_Element.FirstChild.FirstChild.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsetTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = Xml_Element.FirstChild.FirstChild.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Main",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    //Update the name of relations

                                                    Xml_Element.RemoveAll();
                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "SpecMainId", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "realSPC_Book_Stage_Spec", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    foreach (XmlNode node in Xml_Element.FirstChild)
                                                    {
                                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(node, "Status", strStatus, Xml_Element);
                                                        node.Attributes["Name"].Value = xmlElem.Attributes["Name"].Value;
                                                        if (node.Attributes["Id"].Value == xmlElem.Attributes["Id"].Value)
                                                        {
                                                            node.Attributes["Pos"].Value = xmlElem.Attributes["Pos"].Value;
                                                        }
                                                    }
                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage_Spec",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;


                                                    break;
                                                }
                                            case "Delete":
                                                {
                                                    // save the SpecMainId
                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    string strId = xmlElem.Attributes["Id"].Value;
                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");

                                                    m_ApplicationManager.m_DAM.GetData(null, "realSPC_Book_Stage_Spec", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);

                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);
                                                    strId = Xml_Element.FirstChild.FirstChild.Attributes["SpecMainId"].Value;

                                                    //delete the relation from SPC_Book_Stage_Spec table
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //isdeleted
                                                    Attr = XmlData.CreateAttribute("IsDeleted");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Book_Stage_Spec",
                                                       XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;
                                                    //check if this is a last relation 

                                                    Xml_Element.RemoveAll();
                                                    ListValues = "(" + strId + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "SpecMainId", "IN", ListValues, "");

                                                    m_ApplicationManager.m_DAM.GetData(null, "realSPC_Book_Stage_Spec", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    if (p_StringData == "")
                                                    {
                                                        Xml_Element.RemoveAll();

                                                        ListValues = "(" + strId + ")";

                                                        XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                        XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                        m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                        m_ApplicationManager.m_DAM.GetData(null, "SPC_Main", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);

                                                        //Load xml
                                                        strReturnValue = p_StringData;
                                                        p_StringData += "</root>";
                                                        p_StringData = "<root>" + p_StringData;
                                                        Xml_Element.LoadXml(p_StringData);

                                                        m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Delete", Xml_Element);

                                                        if (!m_ApplicationManager.m_DAM.SaveData("SPC_Main",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                            return false;
                                                    }

                                                    break;
                                                }
                                        }

                                        break;
                                    }
                                case "4"://table
                                    {
                                        switch (strStatus)
                                        {
                                            case "InsertNew":
                                                {
                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    ListValues = "(" + xmlElem.Attributes["ParentId"].Value + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Book_Stage_Spec", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);
                                                    string strParent = Xml_Element.FirstChild.FirstChild.Attributes["SpecMainId"].Value;

                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //ID
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //SpecMainId
                                                    Attr = XmlData.CreateAttribute("SpecMainId");
                                                    Attr.Value = strParent;
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //TypeCode
                                                    Attr = XmlData.CreateAttribute("TypeCode");
                                                    Attr.Value = xmlElem.Attributes["Type"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //NumColumns
                                                    Attr = XmlData.CreateAttribute("NumColumns");
                                                    Attr.Value = "0";
                                                    newElem.Attributes.Append(Attr);

                                                    //IsForPass
                                                    Attr = XmlData.CreateAttribute("IsForPass");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    //add a table to spc_main tables counter

                                                    ListValues = "(" + strParent + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Main", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Update", Xml_Element);
                                                    int NumParts = int.Parse(Xml_Element.FirstChild.FirstChild.Attributes["NumParts"].Value) + 1;
                                                    Xml_Element.FirstChild.FirstChild.Attributes["NumParts"].Value = NumParts.ToString();

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Main",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Update":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //TypeCode
                                                    Attr = XmlData.CreateAttribute("TypeCode");
                                                    Attr.Value = xmlElem.Attributes["Type"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part",
                                                       XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Delete":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Isdeleted
                                                    Attr = XmlData.CreateAttribute("IsDeleted");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part",
                                                       XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;
                                                    //Update NumParts

                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    ListValues = "(" + xmlElem.Attributes["ParentId"].Value + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Main", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Update", Xml_Element);
                                                    int NumParts = int.Parse(Xml_Element.FirstChild.FirstChild.Attributes["NumParts"].Value) - 1;
                                                    Xml_Element.FirstChild.FirstChild.Attributes["NumParts"].Value = NumParts.ToString();

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Main",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "5"://column
                                    {
                                        switch (strStatus)
                                        {
                                            case "InsertNew":
                                                {
                                                    //status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = "Insert";
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = "-1";
                                                    newElem.Attributes.Append(Attr);

                                                    //SpcPartId
                                                    Attr = XmlData.CreateAttribute("SpcPartId");
                                                    Attr.Value = xmlElem.Attributes["ParentId"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //FormatCode
                                                    Attr = XmlData.CreateAttribute("FormatCode");
                                                    Attr.Value = xmlElem.Attributes["Format"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //ListID
                                                    if (xmlElem.Attributes["ListId"].Value != "")
                                                    {
                                                        Attr = XmlData.CreateAttribute("ListID");
                                                        Attr.Value = xmlElem.Attributes["ListId"].Value;
                                                        newElem.Attributes.Append(Attr);
                                                    }
                                                    //IsUpdateable
                                                    Attr = XmlData.CreateAttribute("IsUpdateable");
                                                    Attr.Value = xmlElem.Attributes["IsUpdateable"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //IsForRPTDetails
                                                    Attr = XmlData.CreateAttribute("IsForRPTDetail");
                                                    Attr.Value = "0";
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part_Column",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    //add a table to spc_part tables counter

                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    ListValues = "(" + xmlElem.Attributes["ParentId"].Value + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Part", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Update", Xml_Element);
                                                    int NumParts = int.Parse(Xml_Element.FirstChild.FirstChild.Attributes["NumColumns"].Value) + 1;
                                                    Xml_Element.FirstChild.FirstChild.Attributes["NumColumns"].Value = NumParts.ToString();

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;


                                                    break;
                                                }
                                            case "Update":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Name
                                                    Attr = XmlData.CreateAttribute("Name");
                                                    Attr.Value = xmlElem.Attributes["Name"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //Pos
                                                    Attr = XmlData.CreateAttribute("Pos");
                                                    Attr.Value = xmlElem.Attributes["Pos"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //FormatCode
                                                    Attr = XmlData.CreateAttribute("FormatCode");
                                                    Attr.Value = xmlElem.Attributes["Format"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //ListID
                                                    if (xmlElem.Attributes["ListId"].Value != "")
                                                    {
                                                        Attr = XmlData.CreateAttribute("ListID");
                                                        Attr.Value = xmlElem.Attributes["ListId"].Value;
                                                        newElem.Attributes.Append(Attr);
                                                    }
                                                    //IsUpdateable
                                                    Attr = XmlData.CreateAttribute("IsUpdateable");
                                                    Attr.Value = xmlElem.Attributes["IsUpdateable"].Value;
                                                    newElem.Attributes.Append(Attr);


                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part_Column",
                                                       XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    break;
                                                }
                                            case "Delete":
                                                {
                                                    //Status
                                                    Attr = XmlData.CreateAttribute("Status");
                                                    Attr.Value = strStatus;
                                                    newElem.Attributes.Append(Attr);

                                                    //Id
                                                    Attr = XmlData.CreateAttribute("Id");
                                                    Attr.Value = xmlElem.Attributes["Id"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //IsDeleted
                                                    Attr = XmlData.CreateAttribute("IsDeleted");
                                                    Attr.Value = "1";
                                                    newElem.Attributes.Append(Attr);

                                                    //UpdateTimeStamp
                                                    Attr = XmlData.CreateAttribute("UpdateTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["UpdateTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    //InsertTimeStamp
                                                    Attr = XmlData.CreateAttribute("InsertTimeStamp");
                                                    Attr.Value = xmlElem.Attributes["InsertTimeStamp"].Value;
                                                    newElem.Attributes.Append(Attr);

                                                    Root.AppendChild(newElem);

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part_Column",
                                                        XmlData, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;

                                                    //remove a table to spc_part tables counter

                                                    XmlDocument XmlWhere;
                                                    XmlDocument Xml_Element = new XmlDocument();
                                                    XmlNode XmlOrCondition;
                                                    String ListValues = "";
                                                    string strReturnValue = "";
                                                    string p_StringData = "";

                                                    ListValues = "(" + xmlElem.Attributes["ParentId"].Value + ")";

                                                    XmlWhere = m_ApplicationManager.m_SQLUtil.Build_EmptyXmlWhere();

                                                    XmlOrCondition = m_ApplicationManager.m_SQLUtil.Add_OrCondition(XmlWhere);

                                                    m_ApplicationManager.m_SQLUtil.Add_AndCondition(XmlWhere, XmlOrCondition, "Id", "IN", ListValues, "");
                                                    m_ApplicationManager.m_DAM.GetData(null, "SPC_Part", "", XmlWhere, null, 100, p_command, p_XmlUserInfo, out p_StringData, out p_XmlErrors);
                                                    //loadxml
                                                    strReturnValue = p_StringData;
                                                    p_StringData += "</root>";
                                                    p_StringData = "<root>" + p_StringData;
                                                    Xml_Element.LoadXml(p_StringData);

                                                    m_ApplicationManager.m_XmlUtility.SafeSetNodeAttribute(Xml_Element.FirstChild.FirstChild, "Status", "Update", Xml_Element);
                                                    int NumParts = int.Parse(Xml_Element.FirstChild.FirstChild.Attributes["NumColumns"].Value) - 1;
                                                    Xml_Element.FirstChild.FirstChild.Attributes["NumColumns"].Value = NumParts.ToString();

                                                    if (!m_ApplicationManager.m_DAM.SaveData("SPC_Part",
                                                        Xml_Element, null, p_command, p_XmlUserInfo, out p_XmlErrors))
                                                        return false;


                                                    break;
                                                }
                                        }

                                        break;
                                    }
                            }

                            break;
                        }
                    case "PRJ_Stage_Material":
                        {
                            str_TableName = "PRJ_Stage_Material";
                            if (!m_ApplicationManager.m_DAM.SaveData(str_TableName,
                                     p_XmlData, AttributeList, p_command,
                                     p_XmlUserInfo, out p_XmlErrors)) return false;
                            break;
                        }
                    default:
                        break;

                }
                //Log Exit (Pout)
                OpertionType = PrjSApp.clsLogManager.OperationTypes.OTFunctionExit;
                m_ApplicationManager.m_LogManager.AddLog(ClassName, "SaveData", OpertionType,
                    "p_DataId", p_DataId, null, null, //String values
                    null, null, null, null, //String values
                    null, null, null, null,     //Int Values
                    null, null, null, null, //Int values
                    "p_XmlData", p_XmlData, "AttributeList", AttributeList, //XML Values
                    null, null, null, null,
                    p_XmlUserInfo,
                    null  //Exception Values
                    );

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
                   "p_XmlData", p_XmlData, "AttributeList", AttributeList,//XML Values
                   null, null, null, null,
                   p_XmlUserInfo,
                   e  //Exception Values
                   );
                m_ApplicationManager.m_ErrorManager.AddError(ref p_XmlErrors, e.Message, p_XmlUserInfo);
                return false;

            }


            p_XmlErrors = null;
            return true;
        }

        


    }
}
