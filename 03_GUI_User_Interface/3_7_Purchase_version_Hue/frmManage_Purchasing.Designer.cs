namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    partial class frmManage_Purchasing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage_Purchasing));
            this.table_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckcViewTop100 = new System.Windows.Forms.CheckBox();
            this.dtp_DateTo = new System.Windows.Forms.DateTimePicker();
            this.dtp_DateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearch_By_Date = new System.Windows.Forms.Button();
            this.btnSearch_by_Supplier = new System.Windows.Forms.Button();
            this.cbo_tblPur_Supplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_Control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPO = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Search_PO = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgv_Search_PO = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_dgv_Search_PO_ModifyPO = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgv_Search_PO_Copy_to_GRPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_dgv_Search_PO_Edit_View_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgv_Search_PO_Refresh_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMake_New_PO = new System.Windows.Forms.Button();
            this.btnModifyPO = new System.Windows.Forms.Button();
            this.btnCopytoGRPO = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdate_GRPO = new System.Windows.Forms.Button();
            this.btnCopy_to_AP_Invoice = new System.Windows.Forms.Button();
            this.dgv_Search_GRPO = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgv_Search_GRPO = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_dgv_Search_GRPO_Update_GRPO = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgv_Search_GRPO_Refresh_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdate_APInvoice = new System.Windows.Forms.Button();
            this.dgv_Search_APInvoice = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgv_Search_APInvoice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_dgv_Search_APInvoice_Update_APInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgv_Search_APInvoice_Refresh_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.DsachAnh = new System.Windows.Forms.ImageList(this.components);
            this.table_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab_Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_PO)).BeginInit();
            this.cms_dgv_Search_PO.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_GRPO)).BeginInit();
            this.cms_dgv_Search_GRPO.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_APInvoice)).BeginInit();
            this.cms_dgv_Search_APInvoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 1;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Controls.Add(this.panel1, 0, 0);
            this.table_Main.Controls.Add(this.tab_Control, 0, 1);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 2;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Size = new System.Drawing.Size(937, 615);
            this.table_Main.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.ckcViewTop100);
            this.panel1.Controls.Add(this.dtp_DateTo);
            this.panel1.Controls.Add(this.dtp_DateFrom);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSearch_By_Date);
            this.panel1.Controls.Add(this.btnSearch_by_Supplier);
            this.panel1.Controls.Add(this.cbo_tblPur_Supplier);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 114);
            this.panel1.TabIndex = 0;
            // 
            // ckcViewTop100
            // 
            this.ckcViewTop100.AutoSize = true;
            this.ckcViewTop100.Checked = true;
            this.ckcViewTop100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckcViewTop100.Location = new System.Drawing.Point(544, 23);
            this.ckcViewTop100.Name = "ckcViewTop100";
            this.ckcViewTop100.Size = new System.Drawing.Size(105, 21);
            this.ckcViewTop100.TabIndex = 5;
            this.ckcViewTop100.Text = "View Top 100";
            this.ckcViewTop100.UseVisualStyleBackColor = true;
            // 
            // dtp_DateTo
            // 
            this.dtp_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateTo.Location = new System.Drawing.Point(166, 58);
            this.dtp_DateTo.Name = "dtp_DateTo";
            this.dtp_DateTo.Size = new System.Drawing.Size(109, 25);
            this.dtp_DateTo.TabIndex = 4;
            // 
            // dtp_DateFrom
            // 
            this.dtp_DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateFrom.Location = new System.Drawing.Point(25, 58);
            this.dtp_DateFrom.Name = "dtp_DateFrom";
            this.dtp_DateFrom.Size = new System.Drawing.Size(109, 25);
            this.dtp_DateFrom.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(846, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 33);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch_By_Date
            // 
            this.btnSearch_By_Date.Location = new System.Drawing.Point(289, 54);
            this.btnSearch_By_Date.Name = "btnSearch_By_Date";
            this.btnSearch_By_Date.Size = new System.Drawing.Size(157, 33);
            this.btnSearch_By_Date.TabIndex = 3;
            this.btnSearch_By_Date.Text = "Search by Date";
            this.btnSearch_By_Date.UseVisualStyleBackColor = true;
            this.btnSearch_By_Date.Click += new System.EventHandler(this.btnSearch_By_Date_Click);
            // 
            // btnSearch_by_Supplier
            // 
            this.btnSearch_by_Supplier.Location = new System.Drawing.Point(289, 15);
            this.btnSearch_by_Supplier.Name = "btnSearch_by_Supplier";
            this.btnSearch_by_Supplier.Size = new System.Drawing.Size(157, 33);
            this.btnSearch_by_Supplier.TabIndex = 3;
            this.btnSearch_by_Supplier.Text = "Search by Supplier";
            this.btnSearch_by_Supplier.UseVisualStyleBackColor = true;
            this.btnSearch_by_Supplier.Click += new System.EventHandler(this.btnSearch_by_Supplier_Click);
            // 
            // cbo_tblPur_Supplier
            // 
            this.cbo_tblPur_Supplier.FormattingEnabled = true;
            this.cbo_tblPur_Supplier.Location = new System.Drawing.Point(91, 19);
            this.cbo_tblPur_Supplier.Name = "cbo_tblPur_Supplier";
            this.cbo_tblPur_Supplier.Size = new System.Drawing.Size(185, 25);
            this.cbo_tblPur_Supplier.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "=>";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tab_Control
            // 
            this.tab_Control.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tab_Control.Controls.Add(this.tabPage1);
            this.tab_Control.Controls.Add(this.tabPage2);
            this.tab_Control.Controls.Add(this.tabPage3);
            this.tab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Control.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Control.ImageList = this.DsachAnh;
            this.tab_Control.Location = new System.Drawing.Point(3, 123);
            this.tab_Control.Name = "tab_Control";
            this.tab_Control.SelectedIndex = 0;
            this.tab_Control.Size = new System.Drawing.Size(931, 489);
            this.tab_Control.TabIndex = 1;
            this.tab_Control.SelectedIndexChanged += new System.EventHandler(this.tab_Control_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPO);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "01. Purchase Order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPO
            // 
            this.tableLayoutPO.ColumnCount = 2;
            this.tableLayoutPO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPO.Controls.Add(this.dgv_Search_PO, 1, 0);
            this.tableLayoutPO.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPO.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPO.Name = "tableLayoutPO";
            this.tableLayoutPO.RowCount = 1;
            this.tableLayoutPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPO.Size = new System.Drawing.Size(917, 450);
            this.tableLayoutPO.TabIndex = 2;
            // 
            // dgv_Search_PO
            // 
            this.dgv_Search_PO.AllowUserToAddRows = false;
            this.dgv_Search_PO.AllowUserToDeleteRows = false;
            this.dgv_Search_PO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Search_PO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Search_PO.ContextMenuStrip = this.cms_dgv_Search_PO;
            this.dgv_Search_PO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Search_PO.FilterAndSortEnabled = true;
            this.dgv_Search_PO.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_PO.Location = new System.Drawing.Point(153, 3);
            this.dgv_Search_PO.MaxFilterButtonImageHeight = 23;
            this.dgv_Search_PO.MultiSelect = false;
            this.dgv_Search_PO.Name = "dgv_Search_PO";
            this.dgv_Search_PO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Search_PO.Size = new System.Drawing.Size(761, 444);
            this.dgv_Search_PO.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_PO.TabIndex = 1;
            this.dgv_Search_PO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_PO_CellClick);
            this.dgv_Search_PO.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Search_PO_RowPostPaint);
            // 
            // cms_dgv_Search_PO
            // 
            this.cms_dgv_Search_PO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_dgv_Search_PO_ModifyPO,
            this.cms_dgv_Search_PO_Copy_to_GRPO,
            this.toolStripSeparator1,
            this.cms_dgv_Search_PO_Edit_View_Table,
            this.cms_dgv_Search_PO_Refresh_Data});
            this.cms_dgv_Search_PO.Name = "cms_dgv_Search_PO";
            this.cms_dgv_Search_PO.Size = new System.Drawing.Size(154, 98);
            // 
            // cms_dgv_Search_PO_ModifyPO
            // 
            this.cms_dgv_Search_PO_ModifyPO.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_PO_ModifyPO.Image")));
            this.cms_dgv_Search_PO_ModifyPO.Name = "cms_dgv_Search_PO_ModifyPO";
            this.cms_dgv_Search_PO_ModifyPO.Size = new System.Drawing.Size(153, 22);
            this.cms_dgv_Search_PO_ModifyPO.Text = "Modify this PO";
            this.cms_dgv_Search_PO_ModifyPO.Click += new System.EventHandler(this.cms_dgv_Search_PO_ModifyPO_Click);
            // 
            // cms_dgv_Search_PO_Copy_to_GRPO
            // 
            this.cms_dgv_Search_PO_Copy_to_GRPO.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_PO_Copy_to_GRPO.Image")));
            this.cms_dgv_Search_PO_Copy_to_GRPO.Name = "cms_dgv_Search_PO_Copy_to_GRPO";
            this.cms_dgv_Search_PO_Copy_to_GRPO.Size = new System.Drawing.Size(153, 22);
            this.cms_dgv_Search_PO_Copy_to_GRPO.Text = "Copy to GRPO";
            this.cms_dgv_Search_PO_Copy_to_GRPO.Click += new System.EventHandler(this.cms_dgv_Search_PO_Copy_to_GRPO_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // cms_dgv_Search_PO_Edit_View_Table
            // 
            this.cms_dgv_Search_PO_Edit_View_Table.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_PO_Edit_View_Table.Image")));
            this.cms_dgv_Search_PO_Edit_View_Table.Name = "cms_dgv_Search_PO_Edit_View_Table";
            this.cms_dgv_Search_PO_Edit_View_Table.Size = new System.Drawing.Size(153, 22);
            this.cms_dgv_Search_PO_Edit_View_Table.Text = "Edit View Table";
            this.cms_dgv_Search_PO_Edit_View_Table.Click += new System.EventHandler(this.cms_dgv_Search_PO_Edit_View_Table_Click);
            // 
            // cms_dgv_Search_PO_Refresh_Data
            // 
            this.cms_dgv_Search_PO_Refresh_Data.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_PO_Refresh_Data.Image")));
            this.cms_dgv_Search_PO_Refresh_Data.Name = "cms_dgv_Search_PO_Refresh_Data";
            this.cms_dgv_Search_PO_Refresh_Data.Size = new System.Drawing.Size(153, 22);
            this.cms_dgv_Search_PO_Refresh_Data.Text = "Refresh Data";
            this.cms_dgv_Search_PO_Refresh_Data.Click += new System.EventHandler(this.cms_dgv_Search_PO_Refresh_Data_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMake_New_PO);
            this.flowLayoutPanel1.Controls.Add(this.btnModifyPO);
            this.flowLayoutPanel1.Controls.Add(this.btnCopytoGRPO);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 444);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnMake_New_PO
            // 
            this.btnMake_New_PO.Image = ((System.Drawing.Image)(resources.GetObject("btnMake_New_PO.Image")));
            this.btnMake_New_PO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMake_New_PO.Location = new System.Drawing.Point(3, 3);
            this.btnMake_New_PO.Name = "btnMake_New_PO";
            this.btnMake_New_PO.Size = new System.Drawing.Size(141, 37);
            this.btnMake_New_PO.TabIndex = 4;
            this.btnMake_New_PO.Text = "Make New PO";
            this.btnMake_New_PO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMake_New_PO.UseVisualStyleBackColor = true;
            this.btnMake_New_PO.Click += new System.EventHandler(this.btnMake_New_PO_Click);
            // 
            // btnModifyPO
            // 
            this.btnModifyPO.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPO.Image")));
            this.btnModifyPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPO.Location = new System.Drawing.Point(3, 46);
            this.btnModifyPO.Name = "btnModifyPO";
            this.btnModifyPO.Size = new System.Drawing.Size(141, 37);
            this.btnModifyPO.TabIndex = 3;
            this.btnModifyPO.Text = "Modify this PO";
            this.btnModifyPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPO.UseVisualStyleBackColor = true;
            this.btnModifyPO.Click += new System.EventHandler(this.btnModifyPO_Click);
            // 
            // btnCopytoGRPO
            // 
            this.btnCopytoGRPO.Image = ((System.Drawing.Image)(resources.GetObject("btnCopytoGRPO.Image")));
            this.btnCopytoGRPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopytoGRPO.Location = new System.Drawing.Point(3, 89);
            this.btnCopytoGRPO.Name = "btnCopytoGRPO";
            this.btnCopytoGRPO.Size = new System.Drawing.Size(141, 37);
            this.btnCopytoGRPO.TabIndex = 2;
            this.btnCopytoGRPO.Text = "Copy To GRPO";
            this.btnCopytoGRPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopytoGRPO.UseVisualStyleBackColor = true;
            this.btnCopytoGRPO.Click += new System.EventHandler(this.btnCopytoGRPO_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02. Goods Receipt PO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_Search_GRPO, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.flowLayoutPanel2.Controls.Add(this.btnUpdate_GRPO);
            this.flowLayoutPanel2.Controls.Add(this.btnCopy_to_AP_Invoice);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(144, 444);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnUpdate_GRPO
            // 
            this.btnUpdate_GRPO.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_GRPO.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate_GRPO.Image")));
            this.btnUpdate_GRPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate_GRPO.Location = new System.Drawing.Point(3, 3);
            this.btnUpdate_GRPO.Name = "btnUpdate_GRPO";
            this.btnUpdate_GRPO.Size = new System.Drawing.Size(130, 36);
            this.btnUpdate_GRPO.TabIndex = 0;
            this.btnUpdate_GRPO.Text = "Update GRPO";
            this.btnUpdate_GRPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate_GRPO.UseVisualStyleBackColor = true;
            this.btnUpdate_GRPO.Click += new System.EventHandler(this.btnUpdate_GRPO_Click);
            // 
            // btnCopy_to_AP_Invoice
            // 
            this.btnCopy_to_AP_Invoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy_to_AP_Invoice.Location = new System.Drawing.Point(3, 45);
            this.btnCopy_to_AP_Invoice.Name = "btnCopy_to_AP_Invoice";
            this.btnCopy_to_AP_Invoice.Size = new System.Drawing.Size(130, 36);
            this.btnCopy_to_AP_Invoice.TabIndex = 1;
            this.btnCopy_to_AP_Invoice.Text = "Copy AP Invoice";
            this.btnCopy_to_AP_Invoice.UseVisualStyleBackColor = true;
            this.btnCopy_to_AP_Invoice.Click += new System.EventHandler(this.btnCopy_to_AP_Invoice_Click);
            // 
            // dgv_Search_GRPO
            // 
            this.dgv_Search_GRPO.AllowUserToAddRows = false;
            this.dgv_Search_GRPO.AllowUserToDeleteRows = false;
            this.dgv_Search_GRPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Search_GRPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Search_GRPO.ContextMenuStrip = this.cms_dgv_Search_GRPO;
            this.dgv_Search_GRPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Search_GRPO.FilterAndSortEnabled = true;
            this.dgv_Search_GRPO.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_GRPO.Location = new System.Drawing.Point(153, 3);
            this.dgv_Search_GRPO.MaxFilterButtonImageHeight = 23;
            this.dgv_Search_GRPO.MultiSelect = false;
            this.dgv_Search_GRPO.Name = "dgv_Search_GRPO";
            this.dgv_Search_GRPO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Search_GRPO.Size = new System.Drawing.Size(761, 444);
            this.dgv_Search_GRPO.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_GRPO.TabIndex = 2;
            this.dgv_Search_GRPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_GRPO_CellClick);
            this.dgv_Search_GRPO.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Search_GRPO_RowPostPaint);
            // 
            // cms_dgv_Search_GRPO
            // 
            this.cms_dgv_Search_GRPO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_dgv_Search_GRPO_Update_GRPO,
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice,
            this.toolStripSeparator2,
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing,
            this.cms_dgv_Search_GRPO_Refresh_Data});
            this.cms_dgv_Search_GRPO.Name = "cms_dgv_Search_GRPO";
            this.cms_dgv_Search_GRPO.Size = new System.Drawing.Size(170, 98);
            // 
            // cms_dgv_Search_GRPO_Update_GRPO
            // 
            this.cms_dgv_Search_GRPO_Update_GRPO.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_GRPO_Update_GRPO.Image")));
            this.cms_dgv_Search_GRPO_Update_GRPO.Name = "cms_dgv_Search_GRPO_Update_GRPO";
            this.cms_dgv_Search_GRPO_Update_GRPO.Size = new System.Drawing.Size(169, 22);
            this.cms_dgv_Search_GRPO_Update_GRPO.Text = "Update GRPO";
            this.cms_dgv_Search_GRPO_Update_GRPO.Click += new System.EventHandler(this.cms_dgv_Search_GRPO_Update_GRPO_Click);
            // 
            // cms_dgv_Search_GRPO_Copy_AP_Invoice
            // 
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_GRPO_Copy_AP_Invoice.Image")));
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice.Name = "cms_dgv_Search_GRPO_Copy_AP_Invoice";
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice.Size = new System.Drawing.Size(169, 22);
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice.Text = "Copy AP Invoice";
            this.cms_dgv_Search_GRPO_Copy_AP_Invoice.Click += new System.EventHandler(this.cms_dgv_Search_GRPO_Copy_AP_Invoice_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // cms_dgv_Search_GRPO_Edit_Table_Viewing
            // 
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_GRPO_Edit_Table_Viewing.Image")));
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing.Name = "cms_dgv_Search_GRPO_Edit_Table_Viewing";
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing.Size = new System.Drawing.Size(169, 22);
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing.Text = "Edit Table Viewing";
            this.cms_dgv_Search_GRPO_Edit_Table_Viewing.Click += new System.EventHandler(this.cms_dgv_Search_GRPO_Edit_Table_Viewing_Click);
            // 
            // cms_dgv_Search_GRPO_Refresh_Data
            // 
            this.cms_dgv_Search_GRPO_Refresh_Data.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_GRPO_Refresh_Data.Image")));
            this.cms_dgv_Search_GRPO_Refresh_Data.Name = "cms_dgv_Search_GRPO_Refresh_Data";
            this.cms_dgv_Search_GRPO_Refresh_Data.Size = new System.Drawing.Size(169, 22);
            this.cms_dgv_Search_GRPO_Refresh_Data.Text = "Refresh Data";
            this.cms_dgv_Search_GRPO_Refresh_Data.Click += new System.EventHandler(this.cms_dgv_Search_GRPO_Refresh_Data_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(923, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "03. AP Invoice";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgv_Search_APInvoice, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(923, 456);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnUpdate_APInvoice);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(144, 450);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnUpdate_APInvoice
            // 
            this.btnUpdate_APInvoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_APInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnUpdate_APInvoice.Name = "btnUpdate_APInvoice";
            this.btnUpdate_APInvoice.Size = new System.Drawing.Size(141, 42);
            this.btnUpdate_APInvoice.TabIndex = 0;
            this.btnUpdate_APInvoice.Text = "Update AP Invoice";
            this.btnUpdate_APInvoice.UseVisualStyleBackColor = true;
            this.btnUpdate_APInvoice.Click += new System.EventHandler(this.btnUpdate_APInvoice_Click);
            // 
            // dgv_Search_APInvoice
            // 
            this.dgv_Search_APInvoice.AllowUserToAddRows = false;
            this.dgv_Search_APInvoice.AllowUserToDeleteRows = false;
            this.dgv_Search_APInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Search_APInvoice.ContextMenuStrip = this.cms_dgv_Search_APInvoice;
            this.dgv_Search_APInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Search_APInvoice.FilterAndSortEnabled = true;
            this.dgv_Search_APInvoice.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_APInvoice.Location = new System.Drawing.Point(153, 3);
            this.dgv_Search_APInvoice.MaxFilterButtonImageHeight = 23;
            this.dgv_Search_APInvoice.Name = "dgv_Search_APInvoice";
            this.dgv_Search_APInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Search_APInvoice.Size = new System.Drawing.Size(767, 450);
            this.dgv_Search_APInvoice.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgv_Search_APInvoice.TabIndex = 1;
            this.dgv_Search_APInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_APInvoice_CellClick);
            this.dgv_Search_APInvoice.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Search_APInvoice_RowPostPaint);
            // 
            // cms_dgv_Search_APInvoice
            // 
            this.cms_dgv_Search_APInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_dgv_Search_APInvoice_Update_APInvoice,
            this.toolStripSeparator3,
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing,
            this.cms_dgv_Search_APInvoice_Refresh_Data});
            this.cms_dgv_Search_APInvoice.Name = "cms_dgv_Search_APInvoice";
            this.cms_dgv_Search_APInvoice.Size = new System.Drawing.Size(181, 98);
            // 
            // cms_dgv_Search_APInvoice_Update_APInvoice
            // 
            this.cms_dgv_Search_APInvoice_Update_APInvoice.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_APInvoice_Update_APInvoice.Image")));
            this.cms_dgv_Search_APInvoice_Update_APInvoice.Name = "cms_dgv_Search_APInvoice_Update_APInvoice";
            this.cms_dgv_Search_APInvoice_Update_APInvoice.Size = new System.Drawing.Size(180, 22);
            this.cms_dgv_Search_APInvoice_Update_APInvoice.Text = "Update AP Invoice";
            this.cms_dgv_Search_APInvoice_Update_APInvoice.Click += new System.EventHandler(this.cms_dgv_Search_APInvoice_Update_APInvoice_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // cms_dgv_Search_APInvoice_Edit_Table_Viewing
            // 
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_APInvoice_Edit_Table_Viewing.Image")));
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing.Name = "cms_dgv_Search_APInvoice_Edit_Table_Viewing";
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing.Size = new System.Drawing.Size(180, 22);
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing.Text = "Edit Table Viewing";
            this.cms_dgv_Search_APInvoice_Edit_Table_Viewing.Click += new System.EventHandler(this.cms_dgv_Search_APInvoice_Edit_Table_Viewing_Click);
            // 
            // cms_dgv_Search_APInvoice_Refresh_Data
            // 
            this.cms_dgv_Search_APInvoice_Refresh_Data.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgv_Search_APInvoice_Refresh_Data.Image")));
            this.cms_dgv_Search_APInvoice_Refresh_Data.Name = "cms_dgv_Search_APInvoice_Refresh_Data";
            this.cms_dgv_Search_APInvoice_Refresh_Data.Size = new System.Drawing.Size(180, 22);
            this.cms_dgv_Search_APInvoice_Refresh_Data.Text = "Refresh Data";
            this.cms_dgv_Search_APInvoice_Refresh_Data.Click += new System.EventHandler(this.cms_dgv_Search_APInvoice_Refresh_Data_Click);
            // 
            // DsachAnh
            // 
            this.DsachAnh.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DsachAnh.ImageStream")));
            this.DsachAnh.TransparentColor = System.Drawing.Color.Transparent;
            this.DsachAnh.Images.SetKeyName(0, "icons8-purchase-order-25.png");
            this.DsachAnh.Images.SetKeyName(1, "icons8-receipt-25.png");
            this.DsachAnh.Images.SetKeyName(2, "icons8-invoice-20.png");
            // 
            // frmManage_Purchasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 615);
            this.Controls.Add(this.table_Main);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManage_Purchasing";
            this.Text = "Manage Purchase Operations";
            this.Load += new System.EventHandler(this.frmManage_Purchasing_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManage_Purchasing_KeyDown);
            this.table_Main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab_Control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_PO)).EndInit();
            this.cms_dgv_Search_PO.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_GRPO)).EndInit();
            this.cms_dgv_Search_GRPO.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search_APInvoice)).EndInit();
            this.cms_dgv_Search_APInvoice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch_by_Supplier;
        private System.Windows.Forms.ComboBox cbo_tblPur_Supplier;
        private System.Windows.Forms.TabControl tab_Control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList DsachAnh;
        private Zuby.ADGV.AdvancedDataGridView dgv_Search_PO;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPO;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip cms_dgv_Search_PO;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_PO_ModifyPO;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_PO_Copy_to_GRPO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_PO_Edit_View_Table;
        private System.Windows.Forms.DateTimePicker dtp_DateTo;
        private System.Windows.Forms.DateTimePicker dtp_DateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch_By_Date;
        private System.Windows.Forms.CheckBox ckcViewTop100;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUpdate_GRPO;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCopy_to_AP_Invoice;
        private Zuby.ADGV.AdvancedDataGridView dgv_Search_GRPO;
        private System.Windows.Forms.ContextMenuStrip cms_dgv_Search_GRPO;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_GRPO_Update_GRPO;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_GRPO_Copy_AP_Invoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_GRPO_Edit_Table_Viewing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMake_New_PO;
        private System.Windows.Forms.Button btnModifyPO;
        private System.Windows.Forms.Button btnCopytoGRPO;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_GRPO_Refresh_Data;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_PO_Refresh_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Zuby.ADGV.AdvancedDataGridView dgv_Search_APInvoice;
        private System.Windows.Forms.Button btnUpdate_APInvoice;
        private System.Windows.Forms.ContextMenuStrip cms_dgv_Search_APInvoice;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_APInvoice_Update_APInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_APInvoice_Edit_Table_Viewing;
        private System.Windows.Forms.ToolStripMenuItem cms_dgv_Search_APInvoice_Refresh_Data;
    }
}