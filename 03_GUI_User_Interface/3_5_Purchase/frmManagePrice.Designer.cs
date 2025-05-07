namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmManagePrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePrice));
            this.btnExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvListTimKiem = new System.Windows.Forms.DataGridView();
            this.groupBoxPartInformation = new System.Windows.Forms.GroupBox();
            this.ckcAllowModifyRate = new System.Windows.Forms.CheckBox();
            this.txtExportPriceUSD = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExportPrice = new System.Windows.Forms.TextBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.cboPrecision = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUSDPrice = new System.Windows.Forms.TextBox();
            this.groupBoxCurrentPrice = new System.Windows.Forms.GroupBox();
            this.rdioVND = new System.Windows.Forms.RadioButton();
            this.rdioUSD = new System.Windows.Forms.RadioButton();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTypeCurrent = new System.Windows.Forms.Label();
            this.labelExportPrice = new System.Windows.Forms.Label();
            this.labelPrecision = new System.Windows.Forms.Label();
            this.labelImportPrice = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.labelPartStage = new System.Windows.Forms.Label();
            this.labelPartCode = new System.Windows.Forms.Label();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.txtPartPriceLog = new System.Windows.Forms.TextBox();
            this.btnSaveNewPrice = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.groupBoxSearchPart = new System.Windows.Forms.GroupBox();
            this.btnMakeNewPO = new System.Windows.Forms.Button();
            this.btnTraCuuPO = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).BeginInit();
            this.groupBoxPartInformation.SuspendLayout();
            this.groupBoxCurrentPrice.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxSearchPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(571, 28);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 90);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListTimKiem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxPartInformation, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLog, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSearchPart, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5192F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.22037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.39232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.70117F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 679);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(3, 81);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowHeadersWidth = 51;
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(647, 213);
            this.dgvListTimKiem.TabIndex = 2;
            this.dgvListTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellDoubleClick);
            this.dgvListTimKiem.SelectionChanged += new System.EventHandler(this.dgvListTimKiem_SelectionChanged);
            this.dgvListTimKiem.DoubleClick += new System.EventHandler(this.dgvListTimKiem_DoubleClick);
            // 
            // groupBoxPartInformation
            // 
            this.groupBoxPartInformation.Controls.Add(this.ckcAllowModifyRate);
            this.groupBoxPartInformation.Controls.Add(this.txtExportPriceUSD);
            this.groupBoxPartInformation.Controls.Add(this.txtRate);
            this.groupBoxPartInformation.Controls.Add(this.label5);
            this.groupBoxPartInformation.Controls.Add(this.txtExportPrice);
            this.groupBoxPartInformation.Controls.Add(this.txtPartStage);
            this.groupBoxPartInformation.Controls.Add(this.cboPrecision);
            this.groupBoxPartInformation.Controls.Add(this.label11);
            this.groupBoxPartInformation.Controls.Add(this.label6);
            this.groupBoxPartInformation.Controls.Add(this.txtUSDPrice);
            this.groupBoxPartInformation.Controls.Add(this.groupBoxCurrentPrice);
            this.groupBoxPartInformation.Controls.Add(this.txtPartPrice);
            this.groupBoxPartInformation.Controls.Add(this.txtDescript);
            this.groupBoxPartInformation.Controls.Add(this.txtPartName);
            this.groupBoxPartInformation.Controls.Add(this.txtPartCode);
            this.groupBoxPartInformation.Controls.Add(this.label10);
            this.groupBoxPartInformation.Controls.Add(this.lblTypeCurrent);
            this.groupBoxPartInformation.Controls.Add(this.labelExportPrice);
            this.groupBoxPartInformation.Controls.Add(this.labelPrecision);
            this.groupBoxPartInformation.Controls.Add(this.labelImportPrice);
            this.groupBoxPartInformation.Controls.Add(this.labelDescription);
            this.groupBoxPartInformation.Controls.Add(this.labelPartName);
            this.groupBoxPartInformation.Controls.Add(this.labelPartStage);
            this.groupBoxPartInformation.Controls.Add(this.labelPartCode);
            this.groupBoxPartInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPartInformation.Location = new System.Drawing.Point(3, 300);
            this.groupBoxPartInformation.Name = "groupBoxPartInformation";
            this.groupBoxPartInformation.Size = new System.Drawing.Size(647, 234);
            this.groupBoxPartInformation.TabIndex = 3;
            this.groupBoxPartInformation.TabStop = false;
            this.groupBoxPartInformation.Text = "Part Information";
            // 
            // ckcAllowModifyRate
            // 
            this.ckcAllowModifyRate.AutoSize = true;
            this.ckcAllowModifyRate.Location = new System.Drawing.Point(357, 197);
            this.ckcAllowModifyRate.Name = "ckcAllowModifyRate";
            this.ckcAllowModifyRate.Size = new System.Drawing.Size(73, 27);
            this.ckcAllowModifyRate.TabIndex = 5;
            this.ckcAllowModifyRate.Text = "Eable";
            this.ckcAllowModifyRate.UseVisualStyleBackColor = true;
            this.ckcAllowModifyRate.CheckedChanged += new System.EventHandler(this.ckcAllowModifyRate_CheckedChanged);
            // 
            // txtExportPriceUSD
            // 
            this.txtExportPriceUSD.Location = new System.Drawing.Point(415, 161);
            this.txtExportPriceUSD.Name = "txtExportPriceUSD";
            this.txtExportPriceUSD.ReadOnly = true;
            this.txtExportPriceUSD.Size = new System.Drawing.Size(143, 29);
            this.txtExportPriceUSD.TabIndex = 7;
            this.txtExportPriceUSD.TextChanged += new System.EventHandler(this.txtExportPriceUSD_TextChanged);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(430, 196);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(113, 29);
            this.txtRate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "USD/VND";
            // 
            // txtExportPrice
            // 
            this.txtExportPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtExportPrice.Location = new System.Drawing.Point(415, 125);
            this.txtExportPrice.Name = "txtExportPrice";
            this.txtExportPrice.Size = new System.Drawing.Size(143, 29);
            this.txtExportPrice.TabIndex = 7;
            this.txtExportPrice.TextChanged += new System.EventHandler(this.txtExportPrice_TextChanged);
            // 
            // txtPartStage
            // 
            this.txtPartStage.Location = new System.Drawing.Point(92, 53);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(126, 29);
            this.txtPartStage.TabIndex = 6;
            // 
            // cboPrecision
            // 
            this.cboPrecision.FormattingEnabled = true;
            this.cboPrecision.Items.AddRange(new object[] {
            "0.0",
            "0.00",
            "0.000",
            "0.0000"});
            this.cboPrecision.Location = new System.Drawing.Point(330, 53);
            this.cboPrecision.Name = "cboPrecision";
            this.cboPrecision.Size = new System.Drawing.Size(57, 29);
            this.cboPrecision.TabIndex = 5;
            this.cboPrecision.SelectedIndexChanged += new System.EventHandler(this.cboPrecision_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(567, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 23);
            this.label11.TabIndex = 4;
            this.label11.Text = "( USD )";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "( USD )";
            // 
            // txtUSDPrice
            // 
            this.txtUSDPrice.Location = new System.Drawing.Point(413, 53);
            this.txtUSDPrice.Name = "txtUSDPrice";
            this.txtUSDPrice.ReadOnly = true;
            this.txtUSDPrice.Size = new System.Drawing.Size(143, 29);
            this.txtUSDPrice.TabIndex = 3;
            this.txtUSDPrice.TextChanged += new System.EventHandler(this.txtUSDPrice_TextChanged);
            // 
            // groupBoxCurrentPrice
            // 
            this.groupBoxCurrentPrice.BackColor = System.Drawing.Color.Lime;
            this.groupBoxCurrentPrice.Controls.Add(this.rdioVND);
            this.groupBoxCurrentPrice.Controls.Add(this.rdioUSD);
            this.groupBoxCurrentPrice.Location = new System.Drawing.Point(6, 148);
            this.groupBoxCurrentPrice.Name = "groupBoxCurrentPrice";
            this.groupBoxCurrentPrice.Size = new System.Drawing.Size(104, 76);
            this.groupBoxCurrentPrice.TabIndex = 2;
            this.groupBoxCurrentPrice.TabStop = false;
            this.groupBoxCurrentPrice.Text = "Current";
            // 
            // rdioVND
            // 
            this.rdioVND.AutoSize = true;
            this.rdioVND.Location = new System.Drawing.Point(12, 45);
            this.rdioVND.Name = "rdioVND";
            this.rdioVND.Size = new System.Drawing.Size(67, 27);
            this.rdioVND.TabIndex = 1;
            this.rdioVND.TabStop = true;
            this.rdioVND.Text = "VND";
            this.rdioVND.UseVisualStyleBackColor = true;
            this.rdioVND.CheckedChanged += new System.EventHandler(this.rdioVND_CheckedChanged);
            // 
            // rdioUSD
            // 
            this.rdioUSD.AutoSize = true;
            this.rdioUSD.Location = new System.Drawing.Point(12, 20);
            this.rdioUSD.Name = "rdioUSD";
            this.rdioUSD.Size = new System.Drawing.Size(64, 27);
            this.rdioUSD.TabIndex = 0;
            this.rdioUSD.TabStop = true;
            this.rdioUSD.Text = "USD";
            this.rdioUSD.UseVisualStyleBackColor = true;
            this.rdioUSD.CheckedChanged += new System.EventHandler(this.rdioUSD_CheckedChanged);
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPartPrice.Location = new System.Drawing.Point(413, 20);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.ReadOnly = true;
            this.txtPartPrice.Size = new System.Drawing.Size(143, 29);
            this.txtPartPrice.TabIndex = 1;
            this.txtPartPrice.TextChanged += new System.EventHandler(this.txtPartPrice_TextChanged);
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(128, 125);
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.ReadOnly = true;
            this.txtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescript.Size = new System.Drawing.Size(223, 101);
            this.txtDescript.TabIndex = 1;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(92, 86);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(538, 29);
            this.txtPartName.TabIndex = 1;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(92, 20);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(185, 29);
            this.txtPartCode.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "( VND )";
            // 
            // lblTypeCurrent
            // 
            this.lblTypeCurrent.AutoSize = true;
            this.lblTypeCurrent.Location = new System.Drawing.Point(564, 25);
            this.lblTypeCurrent.Name = "lblTypeCurrent";
            this.lblTypeCurrent.Size = new System.Drawing.Size(66, 23);
            this.lblTypeCurrent.TabIndex = 0;
            this.lblTypeCurrent.Text = "( VND )";
            // 
            // labelExportPrice
            // 
            this.labelExportPrice.AutoSize = true;
            this.labelExportPrice.Location = new System.Drawing.Point(349, 128);
            this.labelExportPrice.Name = "labelExportPrice";
            this.labelExportPrice.Size = new System.Drawing.Size(59, 46);
            this.labelExportPrice.TabIndex = 0;
            this.labelExportPrice.Text = "Export\r\nPrice";
            // 
            // labelPrecision
            // 
            this.labelPrecision.AutoSize = true;
            this.labelPrecision.Location = new System.Drawing.Point(243, 58);
            this.labelPrecision.Name = "labelPrecision";
            this.labelPrecision.Size = new System.Drawing.Size(78, 23);
            this.labelPrecision.TabIndex = 0;
            this.labelPrecision.Text = "Precision";
            // 
            // labelImportPrice
            // 
            this.labelImportPrice.AutoSize = true;
            this.labelImportPrice.Location = new System.Drawing.Point(304, 25);
            this.labelImportPrice.Name = "labelImportPrice";
            this.labelImportPrice.Size = new System.Drawing.Size(104, 23);
            this.labelImportPrice.TabIndex = 0;
            this.labelImportPrice.Text = "Import Price";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(10, 119);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(72, 23);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Descript";
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(10, 91);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(91, 23);
            this.labelPartName.TabIndex = 0;
            this.labelPartName.Text = "Part Name";
            // 
            // labelPartStage
            // 
            this.labelPartStage.AutoSize = true;
            this.labelPartStage.Location = new System.Drawing.Point(12, 58);
            this.labelPartStage.Name = "labelPartStage";
            this.labelPartStage.Size = new System.Drawing.Size(87, 23);
            this.labelPartStage.TabIndex = 0;
            this.labelPartStage.Text = "Part Stage";
            // 
            // labelPartCode
            // 
            this.labelPartCode.AutoSize = true;
            this.labelPartCode.Location = new System.Drawing.Point(9, 25);
            this.labelPartCode.Name = "labelPartCode";
            this.labelPartCode.Size = new System.Drawing.Size(85, 23);
            this.labelPartCode.TabIndex = 0;
            this.labelPartCode.Text = "Part Code";
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.txtPartPriceLog);
            this.groupBoxLog.Controls.Add(this.btnSaveNewPrice);
            this.groupBoxLog.Controls.Add(this.btnExit);
            this.groupBoxLog.Controls.Add(this.btnModify);
            this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog.Location = new System.Drawing.Point(3, 540);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(647, 136);
            this.groupBoxLog.TabIndex = 1;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // txtPartPriceLog
            // 
            this.txtPartPriceLog.Location = new System.Drawing.Point(9, 28);
            this.txtPartPriceLog.Multiline = true;
            this.txtPartPriceLog.Name = "txtPartPriceLog";
            this.txtPartPriceLog.Size = new System.Drawing.Size(342, 99);
            this.txtPartPriceLog.TabIndex = 3;
            // 
            // btnSaveNewPrice
            // 
            this.btnSaveNewPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNewPrice.Image")));
            this.btnSaveNewPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNewPrice.Location = new System.Drawing.Point(399, 77);
            this.btnSaveNewPrice.Name = "btnSaveNewPrice";
            this.btnSaveNewPrice.Size = new System.Drawing.Size(160, 41);
            this.btnSaveNewPrice.TabIndex = 2;
            this.btnSaveNewPrice.Text = "Save New Price";
            this.btnSaveNewPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNewPrice.UseVisualStyleBackColor = true;
            this.btnSaveNewPrice.Click += new System.EventHandler(this.btnSaveNewPrice_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(399, 30);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(160, 41);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify Price";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // groupBoxSearchPart
            // 
            this.groupBoxSearchPart.Controls.Add(this.btnMakeNewPO);
            this.groupBoxSearchPart.Controls.Add(this.btnTraCuuPO);
            this.groupBoxSearchPart.Controls.Add(this.btnSearch);
            this.groupBoxSearchPart.Controls.Add(this.txtKeySearch);
            this.groupBoxSearchPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearchPart.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSearchPart.Name = "groupBoxSearchPart";
            this.groupBoxSearchPart.Size = new System.Drawing.Size(647, 72);
            this.groupBoxSearchPart.TabIndex = 0;
            this.groupBoxSearchPart.TabStop = false;
            this.groupBoxSearchPart.Text = "Search Part";
            // 
            // btnMakeNewPO
            // 
            this.btnMakeNewPO.Location = new System.Drawing.Point(335, 20);
            this.btnMakeNewPO.Name = "btnMakeNewPO";
            this.btnMakeNewPO.Size = new System.Drawing.Size(144, 40);
            this.btnMakeNewPO.TabIndex = 3;
            this.btnMakeNewPO.Text = "Make New PO";
            this.btnMakeNewPO.UseVisualStyleBackColor = true;
            this.btnMakeNewPO.Click += new System.EventHandler(this.btnMakeNewPO_Click);
            // 
            // btnTraCuuPO
            // 
            this.btnTraCuuPO.Location = new System.Drawing.Point(493, 20);
            this.btnTraCuuPO.Name = "btnTraCuuPO";
            this.btnTraCuuPO.Size = new System.Drawing.Size(111, 40);
            this.btnTraCuuPO.TabIndex = 2;
            this.btnTraCuuPO.Text = "Search PO";
            this.btnTraCuuPO.UseVisualStyleBackColor = true;
            this.btnTraCuuPO.Click += new System.EventHandler(this.btnTraCuuPO_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(226, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(9, 28);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(209, 29);
            this.txtKeySearch.TabIndex = 0;
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // frmManagePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 679);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmManagePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Price";
            this.Load += new System.EventHandler(this.frmManagePrice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).EndInit();
            this.groupBoxPartInformation.ResumeLayout(false);
            this.groupBoxPartInformation.PerformLayout();
            this.groupBoxCurrentPrice.ResumeLayout(false);
            this.groupBoxCurrentPrice.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.groupBoxSearchPart.ResumeLayout(false);
            this.groupBoxSearchPart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvListTimKiem;
        private System.Windows.Forms.GroupBox groupBoxPartInformation;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.Label labelPartCode;
        private System.Windows.Forms.Button btnSaveNewPrice;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label labelImportPrice;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label lblTypeCurrent;
        private System.Windows.Forms.GroupBox groupBoxCurrentPrice;
        private System.Windows.Forms.RadioButton rdioVND;
        private System.Windows.Forms.RadioButton rdioUSD;
        private System.Windows.Forms.GroupBox groupBoxSearchPart;
        private System.Windows.Forms.Button btnMakeNewPO;
        private System.Windows.Forms.Button btnTraCuuPO;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.CheckBox ckcAllowModifyRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtPartStage;
        private System.Windows.Forms.ComboBox cboPrecision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUSDPrice;
        private System.Windows.Forms.Label labelPartStage;
        private System.Windows.Forms.Label labelPrecision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelExportPrice;
        private System.Windows.Forms.TextBox txtExportPriceUSD;
        private System.Windows.Forms.TextBox txtExportPrice;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox txtPartPriceLog;
    }
}