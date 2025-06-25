namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    partial class frmPurchase_Common_Information
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase_Common_Information));
            this.tabChung = new System.Windows.Forms.TabControl();
            this.tabSupplier = new System.Windows.Forms.TabPage();
            this.tableLayoutSupplier = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_tblPur_Supplier = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgv_tblPur_Supplier = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyThisSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTableViewingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvContactPersonList = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSupplierNote = new System.Windows.Forms.TextBox();
            this.txtSupplierLocation = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierPhone = new System.Windows.Forms.TextBox();
            this.txtSupplierTaxNumber = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.dgv_tblPur_Status = new Zuby.ADGV.AdvancedDataGridView();
            this.btnSaveStatus = new System.Windows.Forms.Button();
            this.txtStatusName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModifyStatus = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStatusID = new System.Windows.Forms.TextBox();
            this.tabUnit = new System.Windows.Forms.TabPage();
            this.txtUnitContent = new System.Windows.Forms.TextBox();
            this.txtUnitValue = new System.Windows.Forms.TextBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.txtUnitID = new System.Windows.Forms.TextBox();
            this.btnSaveUnit = new System.Windows.Forms.Button();
            this.btnNewUnit = new System.Windows.Forms.Button();
            this.btnModifyUnit = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_tblPur_Unit = new Zuby.ADGV.AdvancedDataGridView();
            this.tabCurrency = new System.Windows.Forms.TabPage();
            this.btnSaveCurrency = new System.Windows.Forms.Button();
            this.btnModifyCurrency = new System.Windows.Forms.Button();
            this.btnNewCurrency = new System.Windows.Forms.Button();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgv_tblPur_Currency = new Zuby.ADGV.AdvancedDataGridView();
            this.tabWareHouse = new System.Windows.Forms.TabPage();
            this.btnSaveWareHouse = new System.Windows.Forms.Button();
            this.btnModifyWareHouse = new System.Windows.Forms.Button();
            this.btnNewWareHouse = new System.Windows.Forms.Button();
            this.txtWareHouseName = new System.Windows.Forms.TextBox();
            this.txtWareHouseID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgv_tblPur_WareHouse = new Zuby.ADGV.AdvancedDataGridView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabChung.SuspendLayout();
            this.tabSupplier.SuspendLayout();
            this.tableLayoutSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Supplier)).BeginInit();
            this.cms_dgv_tblPur_Supplier.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactPersonList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Status)).BeginInit();
            this.tabUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Unit)).BeginInit();
            this.tabCurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Currency)).BeginInit();
            this.tabWareHouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_WareHouse)).BeginInit();
            this.SuspendLayout();
            // 
            // tabChung
            // 
            this.tabChung.Controls.Add(this.tabSupplier);
            this.tabChung.Controls.Add(this.tabStatus);
            this.tabChung.Controls.Add(this.tabUnit);
            this.tabChung.Controls.Add(this.tabCurrency);
            this.tabChung.Controls.Add(this.tabWareHouse);
            this.tabChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChung.ImageList = this.imageList;
            this.tabChung.Location = new System.Drawing.Point(0, 0);
            this.tabChung.Name = "tabChung";
            this.tabChung.SelectedIndex = 0;
            this.tabChung.Size = new System.Drawing.Size(794, 476);
            this.tabChung.TabIndex = 0;
            // 
            // tabSupplier
            // 
            this.tabSupplier.Controls.Add(this.tableLayoutSupplier);
            this.tabSupplier.ImageIndex = 0;
            this.tabSupplier.Location = new System.Drawing.Point(4, 26);
            this.tabSupplier.Name = "tabSupplier";
            this.tabSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabSupplier.Size = new System.Drawing.Size(786, 446);
            this.tabSupplier.TabIndex = 0;
            this.tabSupplier.Text = "01. Supplier";
            this.tabSupplier.UseVisualStyleBackColor = true;
            // 
            // tableLayoutSupplier
            // 
            this.tableLayoutSupplier.ColumnCount = 1;
            this.tableLayoutSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSupplier.Controls.Add(this.dgv_tblPur_Supplier, 0, 0);
            this.tableLayoutSupplier.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSupplier.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSupplier.Name = "tableLayoutSupplier";
            this.tableLayoutSupplier.RowCount = 2;
            this.tableLayoutSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSupplier.Size = new System.Drawing.Size(780, 440);
            this.tableLayoutSupplier.TabIndex = 3;
            // 
            // dgv_tblPur_Supplier
            // 
            this.dgv_tblPur_Supplier.AllowUserToAddRows = false;
            this.dgv_tblPur_Supplier.AllowUserToDeleteRows = false;
            this.dgv_tblPur_Supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPur_Supplier.ContextMenuStrip = this.cms_dgv_tblPur_Supplier;
            this.dgv_tblPur_Supplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tblPur_Supplier.FilterAndSortEnabled = true;
            this.dgv_tblPur_Supplier.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Supplier.Location = new System.Drawing.Point(3, 3);
            this.dgv_tblPur_Supplier.MaxFilterButtonImageHeight = 23;
            this.dgv_tblPur_Supplier.MultiSelect = false;
            this.dgv_tblPur_Supplier.Name = "dgv_tblPur_Supplier";
            this.dgv_tblPur_Supplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_tblPur_Supplier.Size = new System.Drawing.Size(774, 214);
            this.dgv_tblPur_Supplier.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Supplier.TabIndex = 1;
            this.dgv_tblPur_Supplier.Click += new System.EventHandler(this.dgv_tblPur_Supplier_Click);
            // 
            // cms_dgv_tblPur_Supplier
            // 
            this.cms_dgv_tblPur_Supplier.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_dgv_tblPur_Supplier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSupplierToolStripMenuItem,
            this.modifyThisSupplierToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.editTableViewingToolStripMenuItem});
            this.cms_dgv_tblPur_Supplier.Name = "cms_dgv_tblPur_Supplier";
            this.cms_dgv_tblPur_Supplier.Size = new System.Drawing.Size(185, 108);
            // 
            // addNewSupplierToolStripMenuItem
            // 
            this.addNewSupplierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewSupplierToolStripMenuItem.Image")));
            this.addNewSupplierToolStripMenuItem.Name = "addNewSupplierToolStripMenuItem";
            this.addNewSupplierToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.addNewSupplierToolStripMenuItem.Text = "Add New Supplier";
            this.addNewSupplierToolStripMenuItem.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem_Click);
            // 
            // modifyThisSupplierToolStripMenuItem
            // 
            this.modifyThisSupplierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modifyThisSupplierToolStripMenuItem.Image")));
            this.modifyThisSupplierToolStripMenuItem.Name = "modifyThisSupplierToolStripMenuItem";
            this.modifyThisSupplierToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.modifyThisSupplierToolStripMenuItem.Text = "Modify this Supplier";
            this.modifyThisSupplierToolStripMenuItem.Click += new System.EventHandler(this.modifyThisSupplierToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.refreshToolStripMenuItem.Text = "Refresh Data";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // editTableViewingToolStripMenuItem
            // 
            this.editTableViewingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editTableViewingToolStripMenuItem.Image")));
            this.editTableViewingToolStripMenuItem.Name = "editTableViewingToolStripMenuItem";
            this.editTableViewingToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.editTableViewingToolStripMenuItem.Text = "Edit Table Viewing";
            this.editTableViewingToolStripMenuItem.Click += new System.EventHandler(this.editTableViewingToolStripMenuItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.dgvContactPersonList, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 223);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(774, 214);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dgvContactPersonList
            // 
            this.dgvContactPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactPersonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContactPersonList.FilterAndSortEnabled = true;
            this.dgvContactPersonList.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvContactPersonList.Location = new System.Drawing.Point(467, 3);
            this.dgvContactPersonList.MaxFilterButtonImageHeight = 23;
            this.dgvContactPersonList.Name = "dgvContactPersonList";
            this.dgvContactPersonList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvContactPersonList.Size = new System.Drawing.Size(304, 208);
            this.dgvContactPersonList.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvContactPersonList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.txtSupplierNote);
            this.panel1.Controls.Add(this.txtSupplierLocation);
            this.panel1.Controls.Add(this.txtSupplierName);
            this.panel1.Controls.Add(this.txtSupplierPhone);
            this.panel1.Controls.Add(this.txtSupplierTaxNumber);
            this.panel1.Controls.Add(this.txtSupplierCode);
            this.panel1.Controls.Add(this.txtSupplierID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 208);
            this.panel1.TabIndex = 1;
            // 
            // txtSupplierNote
            // 
            this.txtSupplierNote.Location = new System.Drawing.Point(75, 143);
            this.txtSupplierNote.Multiline = true;
            this.txtSupplierNote.Name = "txtSupplierNote";
            this.txtSupplierNote.ReadOnly = true;
            this.txtSupplierNote.Size = new System.Drawing.Size(370, 50);
            this.txtSupplierNote.TabIndex = 1;
            // 
            // txtSupplierLocation
            // 
            this.txtSupplierLocation.Location = new System.Drawing.Point(75, 109);
            this.txtSupplierLocation.Name = "txtSupplierLocation";
            this.txtSupplierLocation.ReadOnly = true;
            this.txtSupplierLocation.Size = new System.Drawing.Size(370, 25);
            this.txtSupplierLocation.TabIndex = 1;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(75, 75);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(370, 25);
            this.txtSupplierName.TabIndex = 1;
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.Location = new System.Drawing.Point(278, 41);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.ReadOnly = true;
            this.txtSupplierPhone.Size = new System.Drawing.Size(167, 25);
            this.txtSupplierPhone.TabIndex = 1;
            // 
            // txtSupplierTaxNumber
            // 
            this.txtSupplierTaxNumber.Location = new System.Drawing.Point(278, 7);
            this.txtSupplierTaxNumber.Name = "txtSupplierTaxNumber";
            this.txtSupplierTaxNumber.ReadOnly = true;
            this.txtSupplierTaxNumber.Size = new System.Drawing.Size(167, 25);
            this.txtSupplierTaxNumber.TabIndex = 1;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(75, 41);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.ReadOnly = true;
            this.txtSupplierCode.Size = new System.Drawing.Size(99, 25);
            this.txtSupplierCode.TabIndex = 1;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(75, 7);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(49, 25);
            this.txtSupplierID.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Note";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tax Number";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phone";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Location";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.dgv_tblPur_Status);
            this.tabStatus.Controls.Add(this.btnSaveStatus);
            this.tabStatus.Controls.Add(this.txtStatusName);
            this.tabStatus.Controls.Add(this.label8);
            this.tabStatus.Controls.Add(this.btnModifyStatus);
            this.tabStatus.Controls.Add(this.label9);
            this.tabStatus.Controls.Add(this.txtStatusID);
            this.tabStatus.ImageIndex = 3;
            this.tabStatus.Location = new System.Drawing.Point(4, 26);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(786, 446);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "02. Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // dgv_tblPur_Status
            // 
            this.dgv_tblPur_Status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPur_Status.FilterAndSortEnabled = true;
            this.dgv_tblPur_Status.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Status.Location = new System.Drawing.Point(152, 22);
            this.dgv_tblPur_Status.MaxFilterButtonImageHeight = 23;
            this.dgv_tblPur_Status.Name = "dgv_tblPur_Status";
            this.dgv_tblPur_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_tblPur_Status.Size = new System.Drawing.Size(199, 150);
            this.dgv_tblPur_Status.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Status.TabIndex = 0;
            this.dgv_tblPur_Status.Click += new System.EventHandler(this.dgv_tblPur_Status_Click);
            // 
            // btnSaveStatus
            // 
            this.btnSaveStatus.Location = new System.Drawing.Point(203, 206);
            this.btnSaveStatus.Name = "btnSaveStatus";
            this.btnSaveStatus.Size = new System.Drawing.Size(148, 35);
            this.btnSaveStatus.TabIndex = 3;
            this.btnSaveStatus.Text = "Save Status";
            this.btnSaveStatus.UseVisualStyleBackColor = true;
            this.btnSaveStatus.Click += new System.EventHandler(this.btnSaveStatus_Click);
            // 
            // txtStatusName
            // 
            this.txtStatusName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStatusName.Location = new System.Drawing.Point(22, 147);
            this.txtStatusName.Name = "txtStatusName";
            this.txtStatusName.ReadOnly = true;
            this.txtStatusName.Size = new System.Drawing.Size(100, 25);
            this.txtStatusName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Status ID";
            // 
            // btnModifyStatus
            // 
            this.btnModifyStatus.Location = new System.Drawing.Point(16, 206);
            this.btnModifyStatus.Name = "btnModifyStatus";
            this.btnModifyStatus.Size = new System.Drawing.Size(131, 35);
            this.btnModifyStatus.TabIndex = 3;
            this.btnModifyStatus.Text = "Modify Status";
            this.btnModifyStatus.UseVisualStyleBackColor = true;
            this.btnModifyStatus.Click += new System.EventHandler(this.btnModifyStatus_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Status Name";
            // 
            // txtStatusID
            // 
            this.txtStatusID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStatusID.Location = new System.Drawing.Point(22, 52);
            this.txtStatusID.Name = "txtStatusID";
            this.txtStatusID.ReadOnly = true;
            this.txtStatusID.Size = new System.Drawing.Size(73, 25);
            this.txtStatusID.TabIndex = 2;
            // 
            // tabUnit
            // 
            this.tabUnit.Controls.Add(this.txtUnitContent);
            this.tabUnit.Controls.Add(this.txtUnitValue);
            this.tabUnit.Controls.Add(this.txtUnitName);
            this.tabUnit.Controls.Add(this.txtUnitID);
            this.tabUnit.Controls.Add(this.btnSaveUnit);
            this.tabUnit.Controls.Add(this.btnNewUnit);
            this.tabUnit.Controls.Add(this.btnModifyUnit);
            this.tabUnit.Controls.Add(this.label13);
            this.tabUnit.Controls.Add(this.label12);
            this.tabUnit.Controls.Add(this.label11);
            this.tabUnit.Controls.Add(this.label10);
            this.tabUnit.Controls.Add(this.dgv_tblPur_Unit);
            this.tabUnit.ImageIndex = 2;
            this.tabUnit.Location = new System.Drawing.Point(4, 26);
            this.tabUnit.Name = "tabUnit";
            this.tabUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnit.Size = new System.Drawing.Size(786, 446);
            this.tabUnit.TabIndex = 2;
            this.tabUnit.Text = "03. Unit";
            this.tabUnit.UseVisualStyleBackColor = true;
            // 
            // txtUnitContent
            // 
            this.txtUnitContent.Location = new System.Drawing.Point(538, 153);
            this.txtUnitContent.Name = "txtUnitContent";
            this.txtUnitContent.ReadOnly = true;
            this.txtUnitContent.Size = new System.Drawing.Size(188, 25);
            this.txtUnitContent.TabIndex = 2;
            // 
            // txtUnitValue
            // 
            this.txtUnitValue.Location = new System.Drawing.Point(538, 109);
            this.txtUnitValue.Name = "txtUnitValue";
            this.txtUnitValue.ReadOnly = true;
            this.txtUnitValue.Size = new System.Drawing.Size(188, 25);
            this.txtUnitValue.TabIndex = 1;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(538, 65);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.ReadOnly = true;
            this.txtUnitName.Size = new System.Drawing.Size(188, 25);
            this.txtUnitName.TabIndex = 0;
            // 
            // txtUnitID
            // 
            this.txtUnitID.Location = new System.Drawing.Point(538, 21);
            this.txtUnitID.Name = "txtUnitID";
            this.txtUnitID.ReadOnly = true;
            this.txtUnitID.Size = new System.Drawing.Size(85, 25);
            this.txtUnitID.TabIndex = 3;
            // 
            // btnSaveUnit
            // 
            this.btnSaveUnit.Location = new System.Drawing.Point(320, 210);
            this.btnSaveUnit.Name = "btnSaveUnit";
            this.btnSaveUnit.Size = new System.Drawing.Size(81, 34);
            this.btnSaveUnit.TabIndex = 5;
            this.btnSaveUnit.Text = "Save";
            this.btnSaveUnit.UseVisualStyleBackColor = true;
            this.btnSaveUnit.Click += new System.EventHandler(this.btnSaveUnit_Click);
            // 
            // btnNewUnit
            // 
            this.btnNewUnit.Location = new System.Drawing.Point(30, 210);
            this.btnNewUnit.Name = "btnNewUnit";
            this.btnNewUnit.Size = new System.Drawing.Size(118, 34);
            this.btnNewUnit.TabIndex = 3;
            this.btnNewUnit.Text = "New Unit";
            this.btnNewUnit.UseVisualStyleBackColor = true;
            this.btnNewUnit.Click += new System.EventHandler(this.btnNewUnit_Click);
            // 
            // btnModifyUnit
            // 
            this.btnModifyUnit.Location = new System.Drawing.Point(175, 210);
            this.btnModifyUnit.Name = "btnModifyUnit";
            this.btnModifyUnit.Size = new System.Drawing.Size(118, 34);
            this.btnModifyUnit.TabIndex = 4;
            this.btnModifyUnit.Text = "Modify Unit";
            this.btnModifyUnit.UseVisualStyleBackColor = true;
            this.btnModifyUnit.Click += new System.EventHandler(this.btnModifyUnit_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(435, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Unit Content";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(435, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Unit Value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Unit Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(435, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Unit ID";
            // 
            // dgv_tblPur_Unit
            // 
            this.dgv_tblPur_Unit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPur_Unit.FilterAndSortEnabled = true;
            this.dgv_tblPur_Unit.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Unit.Location = new System.Drawing.Point(28, 17);
            this.dgv_tblPur_Unit.MaxFilterButtonImageHeight = 23;
            this.dgv_tblPur_Unit.Name = "dgv_tblPur_Unit";
            this.dgv_tblPur_Unit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_tblPur_Unit.Size = new System.Drawing.Size(391, 181);
            this.dgv_tblPur_Unit.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Unit.TabIndex = 0;
            this.dgv_tblPur_Unit.Click += new System.EventHandler(this.dgv_tblPur_Unit_Click);
            // 
            // tabCurrency
            // 
            this.tabCurrency.Controls.Add(this.btnSaveCurrency);
            this.tabCurrency.Controls.Add(this.btnModifyCurrency);
            this.tabCurrency.Controls.Add(this.btnNewCurrency);
            this.tabCurrency.Controls.Add(this.txtCurrencyRate);
            this.tabCurrency.Controls.Add(this.txtCurrencyName);
            this.tabCurrency.Controls.Add(this.txtCurrencyID);
            this.tabCurrency.Controls.Add(this.label16);
            this.tabCurrency.Controls.Add(this.label15);
            this.tabCurrency.Controls.Add(this.label14);
            this.tabCurrency.Controls.Add(this.dgv_tblPur_Currency);
            this.tabCurrency.ImageIndex = 1;
            this.tabCurrency.Location = new System.Drawing.Point(4, 26);
            this.tabCurrency.Name = "tabCurrency";
            this.tabCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrency.Size = new System.Drawing.Size(786, 446);
            this.tabCurrency.TabIndex = 3;
            this.tabCurrency.Text = "04. Currency";
            this.tabCurrency.UseVisualStyleBackColor = true;
            // 
            // btnSaveCurrency
            // 
            this.btnSaveCurrency.Location = new System.Drawing.Point(366, 181);
            this.btnSaveCurrency.Name = "btnSaveCurrency";
            this.btnSaveCurrency.Size = new System.Drawing.Size(71, 34);
            this.btnSaveCurrency.TabIndex = 3;
            this.btnSaveCurrency.Text = "Save";
            this.btnSaveCurrency.UseVisualStyleBackColor = true;
            this.btnSaveCurrency.Click += new System.EventHandler(this.btnSaveCurrency_Click);
            // 
            // btnModifyCurrency
            // 
            this.btnModifyCurrency.Location = new System.Drawing.Point(191, 181);
            this.btnModifyCurrency.Name = "btnModifyCurrency";
            this.btnModifyCurrency.Size = new System.Drawing.Size(126, 34);
            this.btnModifyCurrency.TabIndex = 3;
            this.btnModifyCurrency.Text = "Modify Currency";
            this.btnModifyCurrency.UseVisualStyleBackColor = true;
            this.btnModifyCurrency.Click += new System.EventHandler(this.btnModifyCurrency_Click);
            // 
            // btnNewCurrency
            // 
            this.btnNewCurrency.Location = new System.Drawing.Point(17, 181);
            this.btnNewCurrency.Name = "btnNewCurrency";
            this.btnNewCurrency.Size = new System.Drawing.Size(126, 34);
            this.btnNewCurrency.TabIndex = 3;
            this.btnNewCurrency.Text = "New Currency";
            this.btnNewCurrency.UseVisualStyleBackColor = true;
            this.btnNewCurrency.Click += new System.EventHandler(this.btnNewCurrency_Click);
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.Location = new System.Drawing.Point(443, 144);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.ReadOnly = true;
            this.txtCurrencyRate.Size = new System.Drawing.Size(111, 25);
            this.txtCurrencyRate.TabIndex = 1;
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(443, 78);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.ReadOnly = true;
            this.txtCurrencyName.Size = new System.Drawing.Size(111, 25);
            this.txtCurrencyName.TabIndex = 0;
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.Location = new System.Drawing.Point(443, 16);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.ReadOnly = true;
            this.txtCurrencyID.Size = new System.Drawing.Size(76, 25);
            this.txtCurrencyID.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(339, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 17);
            this.label16.TabIndex = 1;
            this.label16.Text = "Currency Rate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(339, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Currency Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(343, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "Currency ID";
            // 
            // dgv_tblPur_Currency
            // 
            this.dgv_tblPur_Currency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPur_Currency.FilterAndSortEnabled = true;
            this.dgv_tblPur_Currency.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Currency.Location = new System.Drawing.Point(17, 16);
            this.dgv_tblPur_Currency.MaxFilterButtonImageHeight = 23;
            this.dgv_tblPur_Currency.Name = "dgv_tblPur_Currency";
            this.dgv_tblPur_Currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_tblPur_Currency.Size = new System.Drawing.Size(300, 150);
            this.dgv_tblPur_Currency.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_Currency.TabIndex = 0;
            this.dgv_tblPur_Currency.Click += new System.EventHandler(this.dgv_tblPur_Currency_Click);
            // 
            // tabWareHouse
            // 
            this.tabWareHouse.Controls.Add(this.btnSaveWareHouse);
            this.tabWareHouse.Controls.Add(this.btnModifyWareHouse);
            this.tabWareHouse.Controls.Add(this.btnNewWareHouse);
            this.tabWareHouse.Controls.Add(this.txtWareHouseName);
            this.tabWareHouse.Controls.Add(this.txtWareHouseID);
            this.tabWareHouse.Controls.Add(this.label18);
            this.tabWareHouse.Controls.Add(this.label17);
            this.tabWareHouse.Controls.Add(this.dgv_tblPur_WareHouse);
            this.tabWareHouse.ImageIndex = 4;
            this.tabWareHouse.Location = new System.Drawing.Point(4, 26);
            this.tabWareHouse.Name = "tabWareHouse";
            this.tabWareHouse.Padding = new System.Windows.Forms.Padding(3);
            this.tabWareHouse.Size = new System.Drawing.Size(786, 446);
            this.tabWareHouse.TabIndex = 4;
            this.tabWareHouse.Text = "05. WareHouse";
            this.tabWareHouse.UseVisualStyleBackColor = true;
            // 
            // btnSaveWareHouse
            // 
            this.btnSaveWareHouse.Location = new System.Drawing.Point(409, 189);
            this.btnSaveWareHouse.Name = "btnSaveWareHouse";
            this.btnSaveWareHouse.Size = new System.Drawing.Size(67, 37);
            this.btnSaveWareHouse.TabIndex = 3;
            this.btnSaveWareHouse.Text = "Save";
            this.btnSaveWareHouse.UseVisualStyleBackColor = true;
            this.btnSaveWareHouse.Click += new System.EventHandler(this.btnSaveWareHouse_Click);
            // 
            // btnModifyWareHouse
            // 
            this.btnModifyWareHouse.Location = new System.Drawing.Point(218, 189);
            this.btnModifyWareHouse.Name = "btnModifyWareHouse";
            this.btnModifyWareHouse.Size = new System.Drawing.Size(143, 37);
            this.btnModifyWareHouse.TabIndex = 3;
            this.btnModifyWareHouse.Text = "Modify Warehouse";
            this.btnModifyWareHouse.UseVisualStyleBackColor = true;
            this.btnModifyWareHouse.Click += new System.EventHandler(this.btnModifyWareHouse_Click);
            // 
            // btnNewWareHouse
            // 
            this.btnNewWareHouse.Location = new System.Drawing.Point(24, 189);
            this.btnNewWareHouse.Name = "btnNewWareHouse";
            this.btnNewWareHouse.Size = new System.Drawing.Size(143, 37);
            this.btnNewWareHouse.TabIndex = 3;
            this.btnNewWareHouse.Text = "New Warehouse";
            this.btnNewWareHouse.UseVisualStyleBackColor = true;
            this.btnNewWareHouse.Click += new System.EventHandler(this.btnNewWareHouse_Click);
            // 
            // txtWareHouseName
            // 
            this.txtWareHouseName.Location = new System.Drawing.Point(286, 145);
            this.txtWareHouseName.Name = "txtWareHouseName";
            this.txtWareHouseName.ReadOnly = true;
            this.txtWareHouseName.Size = new System.Drawing.Size(190, 25);
            this.txtWareHouseName.TabIndex = 2;
            // 
            // txtWareHouseID
            // 
            this.txtWareHouseID.Location = new System.Drawing.Point(286, 59);
            this.txtWareHouseID.Name = "txtWareHouseID";
            this.txtWareHouseID.ReadOnly = true;
            this.txtWareHouseID.Size = new System.Drawing.Size(100, 25);
            this.txtWareHouseID.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(286, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "Warehouse Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(286, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "Warehouse ID";
            // 
            // dgv_tblPur_WareHouse
            // 
            this.dgv_tblPur_WareHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPur_WareHouse.FilterAndSortEnabled = true;
            this.dgv_tblPur_WareHouse.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_WareHouse.Location = new System.Drawing.Point(24, 20);
            this.dgv_tblPur_WareHouse.MaxFilterButtonImageHeight = 23;
            this.dgv_tblPur_WareHouse.Name = "dgv_tblPur_WareHouse";
            this.dgv_tblPur_WareHouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_tblPur_WareHouse.Size = new System.Drawing.Size(240, 150);
            this.dgv_tblPur_WareHouse.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_tblPur_WareHouse.TabIndex = 0;
            this.dgv_tblPur_WareHouse.Click += new System.EventHandler(this.dgv_tblPur_WareHouse_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icons8-supplier-25.png");
            this.imageList.Images.SetKeyName(1, "icons8-money-25.png");
            this.imageList.Images.SetKeyName(2, "icons8-unit-25.png");
            this.imageList.Images.SetKeyName(3, "icons8-status-25.png");
            this.imageList.Images.SetKeyName(4, "icons8-warehouse-25.png");
            // 
            // frmPurchase_Common_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 476);
            this.Controls.Add(this.tabChung);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPurchase_Common_Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Common Information";
            this.Load += new System.EventHandler(this.frmPurchase_Common_Information_Load);
            this.tabChung.ResumeLayout(false);
            this.tabSupplier.ResumeLayout(false);
            this.tableLayoutSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Supplier)).EndInit();
            this.cms_dgv_tblPur_Supplier.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactPersonList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabStatus.ResumeLayout(false);
            this.tabStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Status)).EndInit();
            this.tabUnit.ResumeLayout(false);
            this.tabUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Unit)).EndInit();
            this.tabCurrency.ResumeLayout(false);
            this.tabCurrency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_Currency)).EndInit();
            this.tabWareHouse.ResumeLayout(false);
            this.tabWareHouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPur_WareHouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabChung;
        private System.Windows.Forms.TabPage tabSupplier;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabPage tabUnit;
        private System.Windows.Forms.TabPage tabCurrency;
        private System.Windows.Forms.TabPage tabWareHouse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSupplier;
        private Zuby.ADGV.AdvancedDataGridView dgv_tblPur_Supplier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Zuby.ADGV.AdvancedDataGridView dgvContactPersonList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierTaxNumber;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierNote;
        private System.Windows.Forms.TextBox txtSupplierLocation;
        private System.Windows.Forms.TextBox txtSupplierPhone;
        private System.Windows.Forms.ContextMenuStrip cms_dgv_tblPur_Supplier;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyThisSupplierToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveStatus;
        private System.Windows.Forms.Button btnModifyStatus;
        private System.Windows.Forms.TextBox txtStatusName;
        private System.Windows.Forms.TextBox txtStatusID;
        private Zuby.ADGV.AdvancedDataGridView dgv_tblPur_Status;
        private Zuby.ADGV.AdvancedDataGridView dgv_tblPur_Unit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveUnit;
        private System.Windows.Forms.Button btnModifyUnit;
        private System.Windows.Forms.Button btnNewUnit;
        private System.Windows.Forms.TextBox txtUnitContent;
        private System.Windows.Forms.TextBox txtUnitValue;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.TextBox txtUnitID;
        private Zuby.ADGV.AdvancedDataGridView dgv_tblPur_Currency;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSaveCurrency;
        private System.Windows.Forms.Button btnModifyCurrency;
        private System.Windows.Forms.Button btnNewCurrency;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private Zuby.ADGV.AdvancedDataGridView dgv_tblPur_WareHouse;
        private System.Windows.Forms.TextBox txtWareHouseName;
        private System.Windows.Forms.TextBox txtWareHouseID;
        private System.Windows.Forms.Button btnSaveWareHouse;
        private System.Windows.Forms.Button btnModifyWareHouse;
        private System.Windows.Forms.Button btnNewWareHouse;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTableViewingToolStripMenuItem;
    }
}