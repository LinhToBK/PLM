namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.btnSavePO = new System.Windows.Forms.Button();
            this.txtStaffPosition = new System.Windows.Forms.TextBox();
            this.labelStaffPosition = new System.Windows.Forms.Label();
            this.btnOldPO = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.labelStaffName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtStaffDept = new System.Windows.Forms.TextBox();
            this.labelStaffDept = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.btnExportPO = new System.Windows.Forms.Button();
            this.labelPurchaseOrder = new System.Windows.Forms.Label();
            this.btnCancelPO = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.labelFinditem = new System.Windows.Forms.Label();
            this.PanelInfor = new System.Windows.Forms.Panel();
            this.groupBoxCurrentPart = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddchild = new System.Windows.Forms.Button();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.ckcViewChild = new System.Windows.Forms.CheckBox();
            this.labelPartCode = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.labelPartName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnManageSupplier = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtTotalVND = new System.Windows.Forms.TextBox();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.CboTolerance = new System.Windows.Forms.ComboBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.labelPONo = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.labelRate = new System.Windows.Forms.Label();
            this.cboSupplierName = new System.Windows.Forms.ComboBox();
            this.txtTotalUSD = new System.Windows.Forms.TextBox();
            this.txtSupplierTax = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierPhone = new System.Windows.Forms.TextBox();
            this.labelSupplierID = new System.Windows.Forms.Label();
            this.txtSupplierLocation = new System.Windows.Forms.TextBox();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtCompanyTaxCode = new System.Windows.Forms.TextBox();
            this.labelSupplierTax = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyLocation = new System.Windows.Forms.TextBox();
            this.labelCompanyTelephone = new System.Windows.Forms.Label();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();
            this.labelSupplierTel = new System.Windows.Forms.Label();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.labelPaymentTerm = new System.Windows.Forms.Label();
            this.labelSupplierName = new System.Windows.Forms.Label();
            this.labelSupplierLocation = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvListItem = new System.Windows.Forms.DataGridView();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.labelRemark = new System.Windows.Forms.Label();
            this.dgvListTimKiem = new System.Windows.Forms.DataGridView();
            this.dgvListChild = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelInfor.SuspendLayout();
            this.groupBoxCurrentPart.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelInfor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvListTimKiem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvListChild, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.81847F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.18153F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1575, 669);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboTemplate);
            this.panel1.Controls.Add(this.btnSavePO);
            this.panel1.Controls.Add(this.txtStaffPosition);
            this.panel1.Controls.Add(this.labelStaffPosition);
            this.panel1.Controls.Add(this.btnOldPO);
            this.panel1.Controls.Add(this.btnAddItems);
            this.panel1.Controls.Add(this.labelStaffName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtStaffDept);
            this.panel1.Controls.Add(this.labelStaffDept);
            this.panel1.Controls.Add(this.txtStaffName);
            this.panel1.Controls.Add(this.btnExportPO);
            this.panel1.Controls.Add(this.labelPurchaseOrder);
            this.panel1.Controls.Add(this.btnCancelPO);
            this.panel1.Controls.Add(this.txtKeySearch);
            this.panel1.Controls.Add(this.labelFinditem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(278, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 287);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "( Shift + A )";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTemplate
            // 
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Items.AddRange(new object[] {
            "Template 0",
            "Template 1"});
            this.cboTemplate.Location = new System.Drawing.Point(289, 192);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(105, 28);
            this.cboTemplate.TabIndex = 11;
            // 
            // btnSavePO
            // 
            this.btnSavePO.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePO.Image")));
            this.btnSavePO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePO.Location = new System.Drawing.Point(289, 51);
            this.btnSavePO.Name = "btnSavePO";
            this.btnSavePO.Size = new System.Drawing.Size(105, 33);
            this.btnSavePO.TabIndex = 5;
            this.btnSavePO.Text = "Save PO";
            this.btnSavePO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePO.UseVisualStyleBackColor = true;
            this.btnSavePO.Click += new System.EventHandler(this.btnSavePO_Click);
            // 
            // txtStaffPosition
            // 
            this.txtStaffPosition.Location = new System.Drawing.Point(90, 146);
            this.txtStaffPosition.Name = "txtStaffPosition";
            this.txtStaffPosition.ReadOnly = true;
            this.txtStaffPosition.Size = new System.Drawing.Size(180, 27);
            this.txtStaffPosition.TabIndex = 3;
            // 
            // labelStaffPosition
            // 
            this.labelStaffPosition.AutoSize = true;
            this.labelStaffPosition.Location = new System.Drawing.Point(13, 149);
            this.labelStaffPosition.Name = "labelStaffPosition";
            this.labelStaffPosition.Size = new System.Drawing.Size(61, 20);
            this.labelStaffPosition.TabIndex = 2;
            this.labelStaffPosition.Text = "Position";
            // 
            // btnOldPO
            // 
            this.btnOldPO.Image = ((System.Drawing.Image)(resources.GetObject("btnOldPO.Image")));
            this.btnOldPO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOldPO.Location = new System.Drawing.Point(289, 143);
            this.btnOldPO.Name = "btnOldPO";
            this.btnOldPO.Size = new System.Drawing.Size(105, 33);
            this.btnOldPO.TabIndex = 3;
            this.btnOldPO.Text = "Search Old PO";
            this.btnOldPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOldPO.UseVisualStyleBackColor = true;
            this.btnOldPO.Click += new System.EventHandler(this.btnOldPO_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.BackColor = System.Drawing.Color.Olive;
            this.btnAddItems.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItems.Image")));
            this.btnAddItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItems.Location = new System.Drawing.Point(13, 237);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(141, 33);
            this.btnAddItems.TabIndex = 3;
            this.btnAddItems.Text = "Add Item for PO List";
            this.btnAddItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItems.UseVisualStyleBackColor = false;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // labelStaffName
            // 
            this.labelStaffName.AutoSize = true;
            this.labelStaffName.Location = new System.Drawing.Point(13, 57);
            this.labelStaffName.Name = "labelStaffName";
            this.labelStaffName.Size = new System.Drawing.Size(49, 20);
            this.labelStaffName.TabIndex = 2;
            this.labelStaffName.Text = "Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(250, 189);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtStaffDept
            // 
            this.txtStaffDept.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffDept.Location = new System.Drawing.Point(90, 100);
            this.txtStaffDept.Name = "txtStaffDept";
            this.txtStaffDept.ReadOnly = true;
            this.txtStaffDept.Size = new System.Drawing.Size(180, 27);
            this.txtStaffDept.TabIndex = 1;
            // 
            // labelStaffDept
            // 
            this.labelStaffDept.AutoSize = true;
            this.labelStaffDept.Location = new System.Drawing.Point(13, 103);
            this.labelStaffDept.Name = "labelStaffDept";
            this.labelStaffDept.Size = new System.Drawing.Size(42, 20);
            this.labelStaffDept.TabIndex = 1;
            this.labelStaffDept.Text = "Dept";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(90, 54);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(180, 27);
            this.txtStaffName.TabIndex = 1;
            // 
            // btnExportPO
            // 
            this.btnExportPO.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPO.Image")));
            this.btnExportPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPO.Location = new System.Drawing.Point(273, 237);
            this.btnExportPO.Name = "btnExportPO";
            this.btnExportPO.Size = new System.Drawing.Size(121, 33);
            this.btnExportPO.TabIndex = 5;
            this.btnExportPO.Text = "Export Excel";
            this.btnExportPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportPO.UseVisualStyleBackColor = true;
            this.btnExportPO.Click += new System.EventHandler(this.btnExportPO_Click);
            // 
            // labelPurchaseOrder
            // 
            this.labelPurchaseOrder.AutoSize = true;
            this.labelPurchaseOrder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPurchaseOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelPurchaseOrder.Location = new System.Drawing.Point(84, 10);
            this.labelPurchaseOrder.Name = "labelPurchaseOrder";
            this.labelPurchaseOrder.Size = new System.Drawing.Size(226, 32);
            this.labelPurchaseOrder.TabIndex = 3;
            this.labelPurchaseOrder.Text = "PURCHASE ORDER";
            // 
            // btnCancelPO
            // 
            this.btnCancelPO.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelPO.Image")));
            this.btnCancelPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelPO.Location = new System.Drawing.Point(289, 97);
            this.btnCancelPO.Name = "btnCancelPO";
            this.btnCancelPO.Size = new System.Drawing.Size(105, 33);
            this.btnCancelPO.TabIndex = 5;
            this.btnCancelPO.Text = "Cancel PO";
            this.btnCancelPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelPO.UseVisualStyleBackColor = true;
            this.btnCancelPO.Click += new System.EventHandler(this.btnCancelPO_Click);
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(90, 193);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(154, 27);
            this.txtKeySearch.TabIndex = 0;
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // labelFinditem
            // 
            this.labelFinditem.AutoSize = true;
            this.labelFinditem.Location = new System.Drawing.Point(13, 196);
            this.labelFinditem.Name = "labelFinditem";
            this.labelFinditem.Size = new System.Drawing.Size(77, 20);
            this.labelFinditem.TabIndex = 10;
            this.labelFinditem.Text = "Find items";
            this.labelFinditem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelInfor
            // 
            this.PanelInfor.AutoScroll = true;
            this.PanelInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelInfor.Controls.Add(this.groupBoxCurrentPart);
            this.PanelInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelInfor.Location = new System.Drawing.Point(3, 3);
            this.PanelInfor.Name = "PanelInfor";
            this.PanelInfor.Size = new System.Drawing.Size(269, 287);
            this.PanelInfor.TabIndex = 0;
            // 
            // groupBoxCurrentPart
            // 
            this.groupBoxCurrentPart.Controls.Add(this.label4);
            this.groupBoxCurrentPart.Controls.Add(this.btnAddchild);
            this.groupBoxCurrentPart.Controls.Add(this.txtPartCode);
            this.groupBoxCurrentPart.Controls.Add(this.ckcViewChild);
            this.groupBoxCurrentPart.Controls.Add(this.labelPartCode);
            this.groupBoxCurrentPart.Controls.Add(this.txtPartName);
            this.groupBoxCurrentPart.Controls.Add(this.label1);
            this.groupBoxCurrentPart.Controls.Add(this.txtPartPrice);
            this.groupBoxCurrentPart.Controls.Add(this.labelPartName);
            this.groupBoxCurrentPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCurrentPart.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCurrentPart.Name = "groupBoxCurrentPart";
            this.groupBoxCurrentPart.Size = new System.Drawing.Size(269, 287);
            this.groupBoxCurrentPart.TabIndex = 0;
            this.groupBoxCurrentPart.TabStop = false;
            this.groupBoxCurrentPart.Text = "Information of Part Click";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "( Shift + C )";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddchild
            // 
            this.btnAddchild.Location = new System.Drawing.Point(6, 214);
            this.btnAddchild.Name = "btnAddchild";
            this.btnAddchild.Size = new System.Drawing.Size(141, 33);
            this.btnAddchild.TabIndex = 3;
            this.btnAddchild.Text = "Add items for PO";
            this.btnAddchild.UseVisualStyleBackColor = true;
            this.btnAddchild.Click += new System.EventHandler(this.btnAddchild_Click);
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(98, 32);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(106, 27);
            this.txtPartCode.TabIndex = 0;
            // 
            // ckcViewChild
            // 
            this.ckcViewChild.AutoSize = true;
            this.ckcViewChild.Location = new System.Drawing.Point(153, 219);
            this.ckcViewChild.Name = "ckcViewChild";
            this.ckcViewChild.Size = new System.Drawing.Size(101, 24);
            this.ckcViewChild.TabIndex = 2;
            this.ckcViewChild.Text = "View Child";
            this.ckcViewChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckcViewChild.UseVisualStyleBackColor = true;
            this.ckcViewChild.CheckedChanged += new System.EventHandler(this.ckcViewChild_CheckedChanged);
            // 
            // labelPartCode
            // 
            this.labelPartCode.AutoSize = true;
            this.labelPartCode.Location = new System.Drawing.Point(9, 35);
            this.labelPartCode.Name = "labelPartCode";
            this.labelPartCode.Size = new System.Drawing.Size(73, 20);
            this.labelPartCode.TabIndex = 1;
            this.labelPartCode.Text = "Part Code";
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(98, 68);
            this.txtPartName.Multiline = true;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(150, 65);
            this.txtPartName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Part Price";
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.Location = new System.Drawing.Point(98, 142);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.ReadOnly = true;
            this.txtPartPrice.Size = new System.Drawing.Size(106, 27);
            this.txtPartPrice.TabIndex = 0;
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(12, 90);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(78, 20);
            this.labelPartName.TabIndex = 1;
            this.labelPartName.Text = "Part Name";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BtnManageSupplier);
            this.panel2.Controls.Add(this.txtRate);
            this.panel2.Controls.Add(this.txtTotalVND);
            this.panel2.Controls.Add(this.labelTotalAmount);
            this.panel2.Controls.Add(this.btnDeletePart);
            this.panel2.Controls.Add(this.CboTolerance);
            this.panel2.Controls.Add(this.btnClearList);
            this.panel2.Controls.Add(this.labelPONo);
            this.panel2.Controls.Add(this.txtPONo);
            this.panel2.Controls.Add(this.labelRate);
            this.panel2.Controls.Add(this.cboSupplierName);
            this.panel2.Controls.Add(this.txtTotalUSD);
            this.panel2.Controls.Add(this.txtSupplierTax);
            this.panel2.Controls.Add(this.txtSupplierID);
            this.panel2.Controls.Add(this.txtSupplierPhone);
            this.panel2.Controls.Add(this.labelSupplierID);
            this.panel2.Controls.Add(this.txtSupplierLocation);
            this.panel2.Controls.Add(this.labelOrderDate);
            this.panel2.Controls.Add(this.txtOrderDate);
            this.panel2.Controls.Add(this.txtCompanyTaxCode);
            this.panel2.Controls.Add(this.labelSupplierTax);
            this.panel2.Controls.Add(this.txtCompanyName);
            this.panel2.Controls.Add(this.txtCompanyLocation);
            this.panel2.Controls.Add(this.labelCompanyTelephone);
            this.panel2.Controls.Add(this.txtPaymentTerms);
            this.panel2.Controls.Add(this.labelSupplierTel);
            this.panel2.Controls.Add(this.txtCompanyPhone);
            this.panel2.Controls.Add(this.labelPaymentTerm);
            this.panel2.Controls.Add(this.labelSupplierName);
            this.panel2.Controls.Add(this.labelSupplierLocation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(711, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(861, 287);
            this.panel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "VND";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "USD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnManageSupplier
            // 
            this.BtnManageSupplier.Image = ((System.Drawing.Image)(resources.GetObject("BtnManageSupplier.Image")));
            this.BtnManageSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnManageSupplier.Location = new System.Drawing.Point(631, 10);
            this.BtnManageSupplier.Name = "BtnManageSupplier";
            this.BtnManageSupplier.Size = new System.Drawing.Size(164, 33);
            this.BtnManageSupplier.TabIndex = 6;
            this.BtnManageSupplier.Text = "Manage Supplier";
            this.BtnManageSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnManageSupplier.UseVisualStyleBackColor = true;
            this.BtnManageSupplier.Click += new System.EventHandler(this.BtnManageSupplier_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(65, 229);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(71, 27);
            this.txtRate.TabIndex = 1;
            this.txtRate.Text = "25000";
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // txtTotalVND
            // 
            this.txtTotalVND.Location = new System.Drawing.Point(427, 229);
            this.txtTotalVND.Name = "txtTotalVND";
            this.txtTotalVND.ReadOnly = true;
            this.txtTotalVND.Size = new System.Drawing.Size(127, 27);
            this.txtTotalVND.TabIndex = 1;
            this.txtTotalVND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalVND.TextChanged += new System.EventHandler(this.txtTotalVND_TextChanged);
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new System.Drawing.Point(377, 232);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(42, 20);
            this.labelTotalAmount.TabIndex = 0;
            this.labelTotalAmount.Text = "Total";
            this.labelTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeletePart.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePart.Image")));
            this.btnDeletePart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletePart.Location = new System.Drawing.Point(144, 228);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.Size = new System.Drawing.Size(116, 29);
            this.btnDeletePart.TabIndex = 4;
            this.btnDeletePart.Text = "Delete Part";
            this.btnDeletePart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletePart.UseVisualStyleBackColor = false;
            this.btnDeletePart.Click += new System.EventHandler(this.btnDeletePart_Click);
            // 
            // CboTolerance
            // 
            this.CboTolerance.FormattingEnabled = true;
            this.CboTolerance.Items.AddRange(new object[] {
            "0.0",
            "0.00",
            "0.000"});
            this.CboTolerance.Location = new System.Drawing.Point(610, 228);
            this.CboTolerance.Name = "CboTolerance";
            this.CboTolerance.Size = new System.Drawing.Size(44, 28);
            this.CboTolerance.TabIndex = 2;
            this.CboTolerance.SelectedIndexChanged += new System.EventHandler(this.CboTolerance_SelectedIndexChanged);
            // 
            // btnClearList
            // 
            this.btnClearList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClearList.Image = ((System.Drawing.Image)(resources.GetObject("btnClearList.Image")));
            this.btnClearList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearList.Location = new System.Drawing.Point(268, 228);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(101, 29);
            this.btnClearList.TabIndex = 4;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // labelPONo
            // 
            this.labelPONo.AutoSize = true;
            this.labelPONo.Location = new System.Drawing.Point(15, 16);
            this.labelPONo.Name = "labelPONo";
            this.labelPONo.Size = new System.Drawing.Size(54, 20);
            this.labelPONo.TabIndex = 1;
            this.labelPONo.Text = "PO NO";
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(86, 13);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(167, 27);
            this.txtPONo.TabIndex = 2;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(14, 232);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(39, 20);
            this.labelRate.TabIndex = 0;
            this.labelRate.Text = "Rate";
            // 
            // cboSupplierName
            // 
            this.cboSupplierName.FormattingEnabled = true;
            this.cboSupplierName.Location = new System.Drawing.Point(489, 49);
            this.cboSupplierName.Name = "cboSupplierName";
            this.cboSupplierName.Size = new System.Drawing.Size(141, 28);
            this.cboSupplierName.TabIndex = 3;
            this.cboSupplierName.SelectedIndexChanged += new System.EventHandler(this.cboSupplierName_SelectedIndexChanged);
            // 
            // txtTotalUSD
            // 
            this.txtTotalUSD.Location = new System.Drawing.Point(662, 229);
            this.txtTotalUSD.Name = "txtTotalUSD";
            this.txtTotalUSD.ReadOnly = true;
            this.txtTotalUSD.Size = new System.Drawing.Size(85, 27);
            this.txtTotalUSD.TabIndex = 1;
            this.txtTotalUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSupplierTax
            // 
            this.txtSupplierTax.Location = new System.Drawing.Point(688, 135);
            this.txtSupplierTax.Name = "txtSupplierTax";
            this.txtSupplierTax.ReadOnly = true;
            this.txtSupplierTax.Size = new System.Drawing.Size(107, 27);
            this.txtSupplierTax.TabIndex = 2;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(764, 50);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(32, 27);
            this.txtSupplierID.TabIndex = 2;
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.Location = new System.Drawing.Point(478, 135);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.Size = new System.Drawing.Size(141, 27);
            this.txtSupplierPhone.TabIndex = 9;
            // 
            // labelSupplierID
            // 
            this.labelSupplierID.AutoSize = true;
            this.labelSupplierID.Location = new System.Drawing.Point(656, 53);
            this.labelSupplierID.Name = "labelSupplierID";
            this.labelSupplierID.Size = new System.Drawing.Size(83, 20);
            this.labelSupplierID.TabIndex = 1;
            this.labelSupplierID.Text = "Supplier ID";
            this.labelSupplierID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSupplierLocation
            // 
            this.txtSupplierLocation.Location = new System.Drawing.Point(459, 91);
            this.txtSupplierLocation.Multiline = true;
            this.txtSupplierLocation.Name = "txtSupplierLocation";
            this.txtSupplierLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSupplierLocation.Size = new System.Drawing.Size(337, 33);
            this.txtSupplierLocation.TabIndex = 2;
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(282, 16);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(94, 20);
            this.labelOrderDate.TabIndex = 1;
            this.labelOrderDate.Text = "Order Date : ";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(415, 13);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(100, 27);
            this.txtOrderDate.TabIndex = 2;
            // 
            // txtCompanyTaxCode
            // 
            this.txtCompanyTaxCode.Location = new System.Drawing.Point(261, 135);
            this.txtCompanyTaxCode.Name = "txtCompanyTaxCode";
            this.txtCompanyTaxCode.Size = new System.Drawing.Size(107, 27);
            this.txtCompanyTaxCode.TabIndex = 2;
            // 
            // labelSupplierTax
            // 
            this.labelSupplierTax.AutoSize = true;
            this.labelSupplierTax.Location = new System.Drawing.Point(627, 138);
            this.labelSupplierTax.Name = "labelSupplierTax";
            this.labelSupplierTax.Size = new System.Drawing.Size(53, 20);
            this.labelSupplierTax.TabIndex = 1;
            this.labelSupplierTax.Text = "No.Tax";
            this.labelSupplierTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(15, 50);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(353, 27);
            this.txtCompanyName.TabIndex = 2;
            // 
            // txtCompanyLocation
            // 
            this.txtCompanyLocation.Location = new System.Drawing.Point(15, 91);
            this.txtCompanyLocation.Multiline = true;
            this.txtCompanyLocation.Name = "txtCompanyLocation";
            this.txtCompanyLocation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCompanyLocation.Size = new System.Drawing.Size(353, 33);
            this.txtCompanyLocation.TabIndex = 2;
            // 
            // labelCompanyTelephone
            // 
            this.labelCompanyTelephone.AutoSize = true;
            this.labelCompanyTelephone.Location = new System.Drawing.Point(15, 138);
            this.labelCompanyTelephone.Name = "labelCompanyTelephone";
            this.labelCompanyTelephone.Size = new System.Drawing.Size(89, 20);
            this.labelCompanyTelephone.TabIndex = 1;
            this.labelCompanyTelephone.Text = "Telephone : ";
            this.labelCompanyTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.Location = new System.Drawing.Point(110, 174);
            this.txtPaymentTerms.Multiline = true;
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaymentTerms.Size = new System.Drawing.Size(686, 42);
            this.txtPaymentTerms.TabIndex = 2;
            this.txtPaymentTerms.Text = "90 days payment after T/T Base on";
            // 
            // labelSupplierTel
            // 
            this.labelSupplierTel.AutoSize = true;
            this.labelSupplierTel.Location = new System.Drawing.Point(376, 138);
            this.labelSupplierTel.Name = "labelSupplierTel";
            this.labelSupplierTel.Size = new System.Drawing.Size(94, 20);
            this.labelSupplierTel.TabIndex = 1;
            this.labelSupplierTel.Text = "Supplier Tel :";
            this.labelSupplierTel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCompanyPhone
            // 
            this.txtCompanyPhone.Location = new System.Drawing.Point(112, 135);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.Size = new System.Drawing.Size(141, 27);
            this.txtCompanyPhone.TabIndex = 2;
            // 
            // labelPaymentTerm
            // 
            this.labelPaymentTerm.AutoSize = true;
            this.labelPaymentTerm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentTerm.Location = new System.Drawing.Point(15, 175);
            this.labelPaymentTerm.Name = "labelPaymentTerm";
            this.labelPaymentTerm.Size = new System.Drawing.Size(65, 40);
            this.labelPaymentTerm.TabIndex = 1;
            this.labelPaymentTerm.Text = "Payment\r\nTerms";
            this.labelPaymentTerm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSupplierName
            // 
            this.labelSupplierName.AutoSize = true;
            this.labelSupplierName.Location = new System.Drawing.Point(376, 53);
            this.labelSupplierName.Name = "labelSupplierName";
            this.labelSupplierName.Size = new System.Drawing.Size(108, 20);
            this.labelSupplierName.TabIndex = 1;
            this.labelSupplierName.Text = "Supplier Name";
            this.labelSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSupplierLocation
            // 
            this.labelSupplierLocation.AutoSize = true;
            this.labelSupplierLocation.Location = new System.Drawing.Point(376, 97);
            this.labelSupplierLocation.Name = "labelSupplierLocation";
            this.labelSupplierLocation.Size = new System.Drawing.Size(66, 20);
            this.labelSupplierLocation.TabIndex = 1;
            this.labelSupplierLocation.Text = "Location";
            this.labelSupplierLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(711, 296);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvListItem);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.txtRemark);
            this.splitContainer2.Panel2.Controls.Add(this.labelRemark);
            this.splitContainer2.Size = new System.Drawing.Size(861, 370);
            this.splitContainer2.SplitterDistance = 284;
            this.splitContainer2.TabIndex = 5;
            // 
            // dgvListItem
            // 
            this.dgvListItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListItem.Location = new System.Drawing.Point(0, 0);
            this.dgvListItem.Name = "dgvListItem";
            this.dgvListItem.RowHeadersWidth = 51;
            this.dgvListItem.RowTemplate.Height = 23;
            this.dgvListItem.Size = new System.Drawing.Size(861, 284);
            this.dgvListItem.TabIndex = 0;
            this.dgvListItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListItem_CellDoubleClick);
            this.dgvListItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListItem_CellValueChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtRemark.Location = new System.Drawing.Point(166, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(695, 82);
            this.txtRemark.TabIndex = 1;
            this.txtRemark.Text = "1. Term and Condition : Under PO Contract\r\n2. Shipping Instruction\r\n3. Above unit" +
    " price is not including VAT";
            // 
            // labelRemark
            // 
            this.labelRemark.AutoSize = true;
            this.labelRemark.Location = new System.Drawing.Point(15, 28);
            this.labelRemark.Name = "labelRemark";
            this.labelRemark.Size = new System.Drawing.Size(59, 20);
            this.labelRemark.TabIndex = 0;
            this.labelRemark.Text = "Remark";
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(278, 296);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowHeadersWidth = 51;
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(427, 370);
            this.dgvListTimKiem.TabIndex = 2;
            this.dgvListTimKiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellClick);
            this.dgvListTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellDoubleClick);
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListChild.FilterAndSortEnabled = true;
            this.dgvListChild.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListChild.Location = new System.Drawing.Point(3, 296);
            this.dgvListChild.MaxFilterButtonImageHeight = 23;
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListChild.RowHeadersWidth = 51;
            this.dgvListChild.RowTemplate.Height = 24;
            this.dgvListChild.Size = new System.Drawing.Size(269, 370);
            this.dgvListChild.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListChild.TabIndex = 6;
            this.dgvListChild.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListChild_CellDoubleClick);
            // 
            // frmMakePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1575, 669);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMakePO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMakePO";
            this.Load += new System.EventHandler(this.frmMakePO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMakePO_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelInfor.ResumeLayout(false);
            this.groupBoxCurrentPart.ResumeLayout(false);
            this.groupBoxCurrentPart.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.Label labelPurchaseOrder;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label labelPONo;
        private System.Windows.Forms.Label labelSupplierTel;
        private System.Windows.Forms.Label labelSupplierLocation;
        private System.Windows.Forms.Label labelSupplierName;
        private System.Windows.Forms.ComboBox cboSupplierName;
        private System.Windows.Forms.TextBox txtSupplierPhone;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtPaymentTerms;
        private System.Windows.Forms.TextBox txtSupplierLocation;
        private System.Windows.Forms.Label labelSupplierID;
        private System.Windows.Forms.Label labelPaymentTerm;
        private System.Windows.Forms.TextBox txtCompanyLocation;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label labelCompanyTelephone;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.TextBox txtStaffPosition;
        private System.Windows.Forms.TextBox txtStaffDept;
        private System.Windows.Forms.Label labelFinditem;
        private System.Windows.Forms.Label labelStaffPosition;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label labelStaffDept;
        private System.Windows.Forms.Label labelStaffName;
        private System.Windows.Forms.Button btnOldPO;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.DataGridView dgvListTimKiem;
        private System.Windows.Forms.Button btnExportPO;
        private System.Windows.Forms.Button btnSavePO;
        private System.Windows.Forms.DataGridView dgvListItem;
        private System.Windows.Forms.TextBox txtTotalVND;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtTotalUSD;
        private System.Windows.Forms.Label labelRemark;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Panel PanelInfor;
        private System.Windows.Forms.Button btnCancelPO;
        private System.Windows.Forms.TextBox txtSupplierTax;
        private System.Windows.Forms.Label labelSupplierTax;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.Button BtnManageSupplier;
        private System.Windows.Forms.ComboBox CboTolerance;
        private System.Windows.Forms.TextBox txtCompanyTaxCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelPartCode;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.GroupBox groupBoxCurrentPart;
        private System.Windows.Forms.CheckBox ckcViewChild;
        private Zuby.ADGV.AdvancedDataGridView dgvListChild;
        private System.Windows.Forms.Button btnAddchild;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}