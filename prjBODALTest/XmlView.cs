using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace prjBODALTest
{
    public partial class XmlView : Form
    {
        private string m_XmlString;
        XmlDocument m_XmlDoc;

        public XmlView( string p_XmlString)
        {
            InitializeComponent();
            m_XmlString = p_XmlString;
            m_XmlDoc = new XmlDocument();
            m_XmlDoc.LoadXml(m_XmlString);
        }

        private void XmlView_Load(object sender, EventArgs e)
        {
            try
            {
                System.IO.StreamWriter SR = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + "\\BrowserXml.xml");
                SR.Write(m_XmlDoc.ToString());
                SR.Close();
                Uri a = new Uri(System.Windows.Forms.Application.StartupPath + "\\BrowserXml.xml");
                webBrowser1.Url = a;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
            
        }
    }
}