﻿namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmMakePO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakePO));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboVendorName = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();
            this.txtCompanyLocation = new System.Windows.Forms.TextBox();
            this.txtVendorLocation = new System.Windows.Forms.TextBox();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListTimKiem = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvListItem = new System.Windows.Forms.DataGridView();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtTotalVND = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtTotalUSD = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PanelInfor = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.btnViewDetailItems = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnViewNearPO = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.btnSavePO = new System.Windows.Forms.Button();
            this.btnCancelPO = new System.Windows.Forms.Button();
            this.btnExportPO = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStaffPosition = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStaffDept = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItem)).BeginInit();
            this.PanelInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.51073F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.48927F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvListTimKiem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PanelInfor, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 639);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cboVendorName);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.txtVendorCode);
            this.panel1.Controls.Add(this.txtPaymentTerms);
            this.panel1.Controls.Add(this.txtCompanyLocation);
            this.panel1.Controls.Add(this.txtVendorLocation);
            this.panel1.Controls.Add(this.txtCompanyPhone);
            this.panel1.Controls.Add(this.txtCompanyName);
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.txtOrderDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(317, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 233);
            this.panel1.TabIndex = 0;
            // 
            // cboVendorName
            // 
            this.cboVendorName.FormattingEnabled = true;
            this.cboVendorName.Location = new System.Drawing.Point(351, 45);
            this.cboVendorName.Name = "cboVendorName";
            this.cboVendorName.Size = new System.Drawing.Size(121, 23);
            this.cboVendorName.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(351, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 23);
            this.textBox2.TabIndex = 2;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Location = new System.Drawing.Point(565, 45);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.ReadOnly = true;
            this.txtVendorCode.Size = new System.Drawing.Size(59, 23);
            this.txtVendorCode.TabIndex = 2;
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.Location = new System.Drawing.Point(106, 151);
            this.txtPaymentTerms.Multiline = true;
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaymentTerms.Size = new System.Drawing.Size(518, 44);
            this.txtPaymentTerms.TabIndex = 2;
            this.txtPaymentTerms.Text = "90 days payment after T/T Base on";
            // 
            // txtCompanyLocation
            // 
            this.txtCompanyLocation.Location = new System.Drawing.Point(10, 77);
            this.txtCompanyLocation.Multiline = true;
            this.txtCompanyLocation.Name = "txtCompanyLocation";
            this.txtCompanyLocation.ReadOnly = true;
            this.txtCompanyLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCompanyLocation.Size = new System.Drawing.Size(253, 33);
            this.txtCompanyLocation.TabIndex = 2;
            // 
            // txtVendorLocation
            // 
            this.txtVendorLocation.Location = new System.Drawing.Point(351, 77);
            this.txtVendorLocation.Multiline = true;
            this.txtVendorLocation.Name = "txtVendorLocation";
            this.txtVendorLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVendorLocation.Size = new System.Drawing.Size(273, 33);
            this.txtVendorLocation.TabIndex = 2;
            // 
            // txtCompanyPhone
            // 
            this.txtCompanyPhone.Location = new System.Drawing.Point(80, 119);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.ReadOnly = true;
            this.txtCompanyPhone.Size = new System.Drawing.Size(183, 23);
            this.txtCompanyPhone.TabIndex = 2;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(10, 45);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(253, 23);
            this.txtCompanyName.TabIndex = 2;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(53, 7);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(174, 23);
            this.txtPONo.TabIndex = 2;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(524, 7);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(100, 23);
            this.txtOrderDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "PO NO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(484, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Vendor Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Telephone : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Vendor Tel :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Payment Terms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "Vendor \r\nLocation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Vendor Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(249, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PURCHASE ORDER";
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(3, 242);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(308, 394);
            this.dgvListTimKiem.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(317, 242);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.dgvListItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.txtRate);
            this.splitContainer1.Panel2.Controls.Add(this.txtTotalVND);
            this.splitContainer1.Panel2.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel2.Controls.Add(this.txtTotalUSD);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Size = new System.Drawing.Size(647, 394);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvListItem
            // 
            this.dgvListItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListItem.Location = new System.Drawing.Point(0, 0);
            this.dgvListItem.Name = "dgvListItem";
            this.dgvListItem.RowTemplate.Height = 23;
            this.dgvListItem.Size = new System.Drawing.Size(647, 277);
            this.dgvListItem.TabIndex = 0;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(457, 80);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(102, 23);
            this.txtRate.TabIndex = 1;
            // 
            // txtTotalVND
            // 
            this.txtTotalVND.Location = new System.Drawing.Point(457, 44);
            this.txtTotalVND.Name = "txtTotalVND";
            this.txtTotalVND.Size = new System.Drawing.Size(127, 23);
            this.txtTotalVND.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(7, 33);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(395, 55);
            this.txtRemark.TabIndex = 1;
            // 
            // txtTotalUSD
            // 
            this.txtTotalUSD.Location = new System.Drawing.Point(457, 8);
            this.txtTotalUSD.Name = "txtTotalUSD";
            this.txtTotalUSD.Size = new System.Drawing.Size(127, 23);
            this.txtTotalUSD.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(561, 84);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "(USD/VND)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(588, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "(VND)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(590, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "(USD)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Remark";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(408, 84);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(408, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total";
            // 
            // PanelInfor
            // 
            this.PanelInfor.AutoScroll = true;
            this.PanelInfor.Controls.Add(this.btnPreview);
            this.PanelInfor.Controls.Add(this.btnAddItems);
            this.PanelInfor.Controls.Add(this.btnViewDetailItems);
            this.PanelInfor.Controls.Add(this.btnSearch);
            this.PanelInfor.Controls.Add(this.btnHelp);
            this.PanelInfor.Controls.Add(this.btnViewNearPO);
            this.PanelInfor.Controls.Add(this.label5);
            this.PanelInfor.Controls.Add(this.txtStaffName);
            this.PanelInfor.Controls.Add(this.btnSavePO);
            this.PanelInfor.Controls.Add(this.btnCancelPO);
            this.PanelInfor.Controls.Add(this.btnExportPO);
            this.PanelInfor.Controls.Add(this.txtKeySearch);
            this.PanelInfor.Controls.Add(this.label12);
            this.PanelInfor.Controls.Add(this.txtStaffPosition);
            this.PanelInfor.Controls.Add(this.label13);
            this.PanelInfor.Controls.Add(this.label6);
            this.PanelInfor.Controls.Add(this.txtStaffDept);
            this.PanelInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelInfor.Location = new System.Drawing.Point(3, 3);
            this.PanelInfor.Name = "PanelInfor";
            this.PanelInfor.Size = new System.Drawing.Size(308, 233);
            this.PanelInfor.TabIndex = 4;
            // 
            // btnPreview
            // 
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.Location = new System.Drawing.Point(9, 193);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 29);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnAddItems
            // 
            this.btnAddItems.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItems.Image")));
            this.btnAddItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItems.Location = new System.Drawing.Point(141, 193);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(141, 29);
            this.btnAddItems.TabIndex = 3;
            this.btnAddItems.Text = "Add Item for PO List";
            this.btnAddItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItems.UseVisualStyleBackColor = true;
            // 
            // btnViewDetailItems
            // 
            this.btnViewDetailItems.Location = new System.Drawing.Point(173, 76);
            this.btnViewDetailItems.Name = "btnViewDetailItems";
            this.btnViewDetailItems.Size = new System.Drawing.Size(109, 23);
            this.btnViewDetailItems.TabIndex = 3;
            this.btnViewDetailItems.Text = "View Detail Items";
            this.btnViewDetailItems.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(247, 110);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(238, 7);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(44, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnViewNearPO
            // 
            this.btnViewNearPO.Location = new System.Drawing.Point(9, 76);
            this.btnViewNearPO.Name = "btnViewNearPO";
            this.btnViewNearPO.Size = new System.Drawing.Size(104, 23);
            this.btnViewNearPO.TabIndex = 3;
            this.btnViewNearPO.Text = "View Near PO";
            this.btnViewNearPO.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Name";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(53, 7);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(163, 23);
            this.txtStaffName.TabIndex = 1;
            // 
            // btnSavePO
            // 
            this.btnSavePO.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePO.Image")));
            this.btnSavePO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePO.Location = new System.Drawing.Point(191, 153);
            this.btnSavePO.Name = "btnSavePO";
            this.btnSavePO.Size = new System.Drawing.Size(89, 29);
            this.btnSavePO.TabIndex = 5;
            this.btnSavePO.Text = "Save PO";
            this.btnSavePO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePO.UseVisualStyleBackColor = true;
            // 
            // btnCancelPO
            // 
            this.btnCancelPO.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelPO.Image")));
            this.btnCancelPO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelPO.Location = new System.Drawing.Point(100, 153);
            this.btnCancelPO.Name = "btnCancelPO";
            this.btnCancelPO.Size = new System.Drawing.Size(89, 29);
            this.btnCancelPO.TabIndex = 5;
            this.btnCancelPO.Text = "Cancel PO";
            this.btnCancelPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelPO.UseVisualStyleBackColor = true;
            // 
            // btnExportPO
            // 
            this.btnExportPO.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPO.Image")));
            this.btnExportPO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportPO.Location = new System.Drawing.Point(9, 153);
            this.btnExportPO.Name = "btnExportPO";
            this.btnExportPO.Size = new System.Drawing.Size(89, 29);
            this.btnExportPO.TabIndex = 5;
            this.btnExportPO.Text = "Export PO";
            this.btnExportPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPO.UseVisualStyleBackColor = true;
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(49, 116);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(179, 23);
            this.txtKeySearch.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(138, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Position";
            // 
            // txtStaffPosition
            // 
            this.txtStaffPosition.Location = new System.Drawing.Point(202, 41);
            this.txtStaffPosition.Name = "txtStaffPosition";
            this.txtStaffPosition.Size = new System.Drawing.Size(80, 23);
            this.txtStaffPosition.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 30);
            this.label13.TabIndex = 0;
            this.label13.Text = "Find\r\nitem";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dept";
            // 
            // txtStaffDept
            // 
            this.txtStaffDept.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffDept.Location = new System.Drawing.Point(53, 41);
            this.txtStaffDept.Name = "txtStaffDept";
            this.txtStaffDept.Size = new System.Drawing.Size(83, 23);
            this.txtStaffDept.TabIndex = 1;
            // 
            // frmMakePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(967, 639);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMakePO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMakePO";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItem)).EndInit();
            this.PanelInfor.ResumeLayout(false);
            this.PanelInfor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboVendorName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtPaymentTerms;
        private System.Windows.Forms.TextBox txtVendorLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCompanyLocation;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.TextBox txtStaffPosition;
        private System.Windows.Forms.TextBox txtStaffDept;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnViewDetailItems;
        private System.Windows.Forms.Button btnViewNearPO;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.DataGridView dgvListTimKiem;
        private System.Windows.Forms.Button btnExportPO;
        private System.Windows.Forms.Button btnSavePO;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvListItem;
        private System.Windows.Forms.TextBox txtTotalVND;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtTotalUSD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel PanelInfor;
        private System.Windows.Forms.Button btnCancelPO;
    }
}