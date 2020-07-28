namespace prjBODALTest
{
    partial class FrmBODALTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGOTest = new System.Windows.Forms.Button();
            this.txtXMLData = new System.Windows.Forms.TextBox();
            this.rbDAL = new System.Windows.Forms.RadioButton();
            this.rbBO = new System.Windows.Forms.RadioButton();
            this.cmBOs = new System.Windows.Forms.ComboBox();
            this.cmTABLEDATAID = new System.Windows.Forms.ComboBox();
            this.flWhere = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.flSort = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.txtXMLErrors = new System.Windows.Forms.TextBox();
            this.btnSaveXMLData = new System.Windows.Forms.Button();
            this.txtXMLDATAFilePath = new System.Windows.Forms.TextBox();
            this.rbSave = new System.Windows.Forms.RadioButton();
            this.rbGet = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSaveMultiTransaction = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAttributeString = new System.Windows.Forms.Button();
            this.pathAttributeString = new System.Windows.Forms.TextBox();
            this.chkWhereShow = new System.Windows.Forms.CheckBox();
            this.chkDataShow = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lablelProgress1 = new System.Windows.Forms.Label();
            this.txtFields = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewTag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGOTest
            // 
            this.btnGOTest.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGOTest.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnGOTest.Location = new System.Drawing.Point(46, 213);
            this.btnGOTest.Name = "btnGOTest";
            this.btnGOTest.Size = new System.Drawing.Size(159, 105);
            this.btnGOTest.TabIndex = 0;
            this.btnGOTest.Text = "GO Test";
            this.btnGOTest.UseVisualStyleBackColor = true;
            this.btnGOTest.Click += new System.EventHandler(this.btnGOTest_Click);
            // 
            // txtXMLData
            // 
            this.txtXMLData.Location = new System.Drawing.Point(46, 352);
            this.txtXMLData.Multiline = true;
            this.txtXMLData.Name = "txtXMLData";
            this.txtXMLData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXMLData.Size = new System.Drawing.Size(280, 143);
            this.txtXMLData.TabIndex = 1;
            this.txtXMLData.Text = "Output XMLData";
            // 
            // rbDAL
            // 
            this.rbDAL.AutoSize = true;
            this.rbDAL.Checked = true;
            this.rbDAL.Location = new System.Drawing.Point(0, 12);
            this.rbDAL.Name = "rbDAL";
            this.rbDAL.Size = new System.Drawing.Size(70, 17);
            this.rbDAL.TabIndex = 2;
            this.rbDAL.TabStop = true;
            this.rbDAL.Text = "DAL Test";
            this.rbDAL.UseVisualStyleBackColor = true;
            this.rbDAL.CheckedChanged += new System.EventHandler(this.rbDAL_CheckedChanged);
            // 
            // rbBO
            // 
            this.rbBO.AutoSize = true;
            this.rbBO.Location = new System.Drawing.Point(95, 12);
            this.rbBO.Name = "rbBO";
            this.rbBO.Size = new System.Drawing.Size(64, 17);
            this.rbBO.TabIndex = 3;
            this.rbBO.Text = "BO Test";
            this.rbBO.UseVisualStyleBackColor = true;
            this.rbBO.CheckedChanged += new System.EventHandler(this.rbBO_CheckedChanged);
            // 
            // cmBOs
            // 
            this.cmBOs.FormattingEnabled = true;
            this.cmBOs.Location = new System.Drawing.Point(46, 50);
            this.cmBOs.Name = "cmBOs";
            this.cmBOs.Size = new System.Drawing.Size(159, 21);
            this.cmBOs.TabIndex = 4;
            this.cmBOs.Text = "-- Select BO --";
            this.cmBOs.Visible = false;
            this.cmBOs.SelectedIndexChanged += new System.EventHandler(this.cmBOs_SelectedIndexChanged);
            // 
            // cmTABLEDATAID
            // 
            this.cmTABLEDATAID.FormattingEnabled = true;
            this.cmTABLEDATAID.Location = new System.Drawing.Point(46, 77);
            this.cmTABLEDATAID.Name = "cmTABLEDATAID";
            this.cmTABLEDATAID.Size = new System.Drawing.Size(159, 21);
            this.cmTABLEDATAID.TabIndex = 5;
            this.cmTABLEDATAID.Text = "-- Select TABLE/DATAID --";
            this.cmTABLEDATAID.SelectedIndexChanged += new System.EventHandler(this.cmTABLEDATAID_SelectedIndexChanged);
            // 
            // flWhere
            // 
            this.flWhere.FormattingEnabled = true;
            this.flWhere.Location = new System.Drawing.Point(299, 79);
            this.flWhere.Name = "flWhere";
            this.flWhere.Pattern = "XMLWhere*.*;XMLData*.*";
            this.flWhere.Size = new System.Drawing.Size(155, 108);
            this.flWhere.TabIndex = 8;
            this.flWhere.SelectedIndexChanged += new System.EventHandler(this.flWhere_SelectedIndexChanged);
            // 
            // flSort
            // 
            this.flSort.FormattingEnabled = true;
            this.flSort.Location = new System.Drawing.Point(299, 213);
            this.flSort.Name = "flSort";
            this.flSort.Pattern = "XMLSort*.*;XMLAttr*.*";
            this.flSort.Size = new System.Drawing.Size(155, 108);
            this.flSort.TabIndex = 9;
            this.flSort.SelectedIndexChanged += new System.EventHandler(this.flSort_SelectedIndexChanged);
            // 
            // txtWhere
            // 
            this.txtWhere.Enabled = false;
            this.txtWhere.Location = new System.Drawing.Point(520, 85);
            this.txtWhere.Multiline = true;
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWhere.Size = new System.Drawing.Size(262, 102);
            this.txtWhere.TabIndex = 10;
            this.txtWhere.Text = "XMLWhere";
            // 
            // txtSort
            // 
            this.txtSort.Enabled = false;
            this.txtSort.Location = new System.Drawing.Point(520, 217);
            this.txtSort.Multiline = true;
            this.txtSort.Name = "txtSort";
            this.txtSort.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSort.Size = new System.Drawing.Size(262, 104);
            this.txtSort.TabIndex = 11;
            this.txtSort.Text = "XMLSort";
            // 
            // txtXMLErrors
            // 
            this.txtXMLErrors.Location = new System.Drawing.Point(435, 353);
            this.txtXMLErrors.Multiline = true;
            this.txtXMLErrors.Name = "txtXMLErrors";
            this.txtXMLErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXMLErrors.Size = new System.Drawing.Size(347, 143);
            this.txtXMLErrors.TabIndex = 12;
            this.txtXMLErrors.Text = "Output XMLErrors";
            // 
            // btnSaveXMLData
            // 
            this.btnSaveXMLData.Location = new System.Drawing.Point(46, 512);
            this.btnSaveXMLData.Name = "btnSaveXMLData";
            this.btnSaveXMLData.Size = new System.Drawing.Size(159, 23);
            this.btnSaveXMLData.TabIndex = 13;
            this.btnSaveXMLData.Text = "Save XmlData TO ==>";
            this.btnSaveXMLData.UseVisualStyleBackColor = true;
            this.btnSaveXMLData.Click += new System.EventHandler(this.btnSaveXMLData_Click);
            // 
            // txtXMLDATAFilePath
            // 
            this.txtXMLDATAFilePath.Location = new System.Drawing.Point(237, 512);
            this.txtXMLDATAFilePath.Name = "txtXMLDATAFilePath";
            this.txtXMLDATAFilePath.Size = new System.Drawing.Size(132, 20);
            this.txtXMLDATAFilePath.TabIndex = 14;
            // 
            // rbSave
            // 
            this.rbSave.AutoSize = true;
            this.rbSave.Location = new System.Drawing.Point(7, 17);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(50, 17);
            this.rbSave.TabIndex = 15;
            this.rbSave.Text = "Save";
            this.rbSave.UseVisualStyleBackColor = true;
            this.rbSave.Visible = false;
            this.rbSave.CheckedChanged += new System.EventHandler(this.rbSave_CheckedChanged);
            // 
            // rbGet
            // 
            this.rbGet.AutoSize = true;
            this.rbGet.Checked = true;
            this.rbGet.Location = new System.Drawing.Point(111, 17);
            this.rbGet.Name = "rbGet";
            this.rbGet.Size = new System.Drawing.Size(42, 17);
            this.rbGet.TabIndex = 16;
            this.rbGet.TabStop = true;
            this.rbGet.Text = "Get";
            this.rbGet.UseVisualStyleBackColor = true;
            this.rbGet.Visible = false;
            this.rbGet.CheckedChanged += new System.EventHandler(this.rbGet_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSaveMultiTransaction);
            this.groupBox1.Controls.Add(this.rbGet);
            this.groupBox1.Controls.Add(this.rbSave);
            this.groupBox1.Location = new System.Drawing.Point(46, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 73);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // rbSaveMultiTransaction
            // 
            this.rbSaveMultiTransaction.AutoSize = true;
            this.rbSaveMultiTransaction.Location = new System.Drawing.Point(7, 40);
            this.rbSaveMultiTransaction.Name = "rbSaveMultiTransaction";
            this.rbSaveMultiTransaction.Size = new System.Drawing.Size(134, 17);
            this.rbSaveMultiTransaction.TabIndex = 17;
            this.rbSaveMultiTransaction.Text = "Save Multi Transaction";
            this.rbSaveMultiTransaction.UseVisualStyleBackColor = true;
            this.rbSaveMultiTransaction.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbBO);
            this.groupBox2.Controls.Add(this.rbDAL);
            this.groupBox2.Location = new System.Drawing.Point(46, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 35);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // btnAttributeString
            // 
            this.btnAttributeString.Location = new System.Drawing.Point(46, 595);
            this.btnAttributeString.Name = "btnAttributeString";
            this.btnAttributeString.Size = new System.Drawing.Size(159, 23);
            this.btnAttributeString.TabIndex = 20;
            this.btnAttributeString.Text = "Get AttributeString <==";
            this.btnAttributeString.UseVisualStyleBackColor = true;
            this.btnAttributeString.Visible = false;
            // 
            // pathAttributeString
            // 
            this.pathAttributeString.Location = new System.Drawing.Point(237, 595);
            this.pathAttributeString.Name = "pathAttributeString";
            this.pathAttributeString.Size = new System.Drawing.Size(132, 20);
            this.pathAttributeString.TabIndex = 21;
            this.pathAttributeString.Visible = false;
            // 
            // chkWhereShow
            // 
            this.chkWhereShow.AutoSize = true;
            this.chkWhereShow.Checked = true;
            this.chkWhereShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWhereShow.Location = new System.Drawing.Point(460, 87);
            this.chkWhereShow.Name = "chkWhereShow";
            this.chkWhereShow.Size = new System.Drawing.Size(53, 17);
            this.chkWhereShow.TabIndex = 23;
            this.chkWhereShow.Text = "Show";
            this.chkWhereShow.UseVisualStyleBackColor = true;
            // 
            // chkDataShow
            // 
            this.chkDataShow.AutoSize = true;
            this.chkDataShow.Checked = true;
            this.chkDataShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataShow.Location = new System.Drawing.Point(347, 373);
            this.chkDataShow.Name = "chkDataShow";
            this.chkDataShow.Size = new System.Drawing.Size(53, 17);
            this.chkDataShow.TabIndex = 24;
            this.chkDataShow.Text = "Show";
            this.chkDataShow.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(435, 510);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(347, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // lablelProgress1
            // 
            this.lablelProgress1.AutoSize = true;
            this.lablelProgress1.Location = new System.Drawing.Point(594, 545);
            this.lablelProgress1.Name = "lablelProgress1";
            this.lablelProgress1.Size = new System.Drawing.Size(35, 13);
            this.lablelProgress1.TabIndex = 26;
            this.lablelProgress1.Text = "label1";
            this.lablelProgress1.Visible = false;
            // 
            // txtFields
            // 
            this.txtFields.Location = new System.Drawing.Point(299, 35);
            this.txtFields.Name = "txtFields";
            this.txtFields.Size = new System.Drawing.Size(155, 20);
            this.txtFields.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fields";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Where";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Sort/Attributes";
            // 
            // txtNewTag
            // 
            this.txtNewTag.Location = new System.Drawing.Point(520, 35);
            this.txtNewTag.Name = "txtNewTag";
            this.txtNewTag.Size = new System.Drawing.Size(155, 20);
            this.txtNewTag.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "New Tag";
            // 
            // FrmBODALTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 624);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFields);
            this.Controls.Add(this.lablelProgress1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkDataShow);
            this.Controls.Add(this.chkWhereShow);
            this.Controls.Add(this.pathAttributeString);
            this.Controls.Add(this.btnAttributeString);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtXMLDATAFilePath);
            this.Controls.Add(this.btnSaveXMLData);
            this.Controls.Add(this.txtXMLErrors);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.txtWhere);
            this.Controls.Add(this.flSort);
            this.Controls.Add(this.flWhere);
            this.Controls.Add(this.cmTABLEDATAID);
            this.Controls.Add(this.cmBOs);
            this.Controls.Add(this.txtXMLData);
            this.Controls.Add(this.btnGOTest);
            this.Name = "FrmBODALTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmBODALTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGOTest;
        private System.Windows.Forms.TextBox txtXMLData;
        private System.Windows.Forms.RadioButton rbDAL;
        private System.Windows.Forms.RadioButton rbBO;
        private System.Windows.Forms.ComboBox cmBOs;
        private System.Windows.Forms.ComboBox cmTABLEDATAID;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox flWhere;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox flSort;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.TextBox txtXMLErrors;
        private System.Windows.Forms.Button btnSaveXMLData;
        private System.Windows.Forms.TextBox txtXMLDATAFilePath;
        private System.Windows.Forms.RadioButton rbSave;
        private System.Windows.Forms.RadioButton rbGet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAttributeString;
        private System.Windows.Forms.TextBox pathAttributeString;
        private System.Windows.Forms.RadioButton rbSaveMultiTransaction;
        private System.Windows.Forms.CheckBox chkWhereShow;
        private System.Windows.Forms.CheckBox chkDataShow;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lablelProgress1;
        private System.Windows.Forms.TextBox txtFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewTag;
        private System.Windows.Forms.Label label4;
    }
}

