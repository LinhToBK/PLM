namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmManagePrice_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePrice_Update));
            this.table_layout = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_TimKiem = new System.Windows.Forms.Panel();
            this.dgvListSearch = new Zuby.ADGV.AdvancedDataGridView();
            this.cmsOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowtable_Feature = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMakeNewPO = new System.Windows.Forms.Button();
            this.btnSearchPO = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvListItems = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgvListItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.changePreferSupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Item_ViewFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkListItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.table_layout.SuspendLayout();
            this.Panel_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSearch)).BeginInit();
            this.cmsOption.SuspendLayout();
            this.flowtable_Feature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            this.cms_dgvListItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_layout
            // 
            this.table_layout.AutoSize = true;
            this.table_layout.ColumnCount = 3;
            this.table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.table_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.table_layout.Controls.Add(this.Panel_TimKiem, 0, 0);
            this.table_layout.Controls.Add(this.flowtable_Feature, 1, 0);
            this.table_layout.Controls.Add(this.dgvListItems, 2, 0);
            this.table_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout.Location = new System.Drawing.Point(0, 0);
            this.table_layout.Name = "table_layout";
            this.table_layout.RowCount = 1;
            this.table_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_layout.Size = new System.Drawing.Size(1278, 611);
            this.table_layout.TabIndex = 0;
            // 
            // Panel_TimKiem
            // 
            this.Panel_TimKiem.AutoScroll = true;
            this.Panel_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Panel_TimKiem.Controls.Add(this.dgvListSearch);
            this.Panel_TimKiem.Controls.Add(this.btnAddItems);
            this.Panel_TimKiem.Controls.Add(this.btnSearch);
            this.Panel_TimKiem.Controls.Add(this.txtSearch);
            this.Panel_TimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_TimKiem.Location = new System.Drawing.Point(3, 3);
            this.Panel_TimKiem.Name = "Panel_TimKiem";
            this.Panel_TimKiem.Size = new System.Drawing.Size(231, 605);
            this.Panel_TimKiem.TabIndex = 0;
            // 
            // dgvListSearch
            // 
            this.dgvListSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListSearch.ContextMenuStrip = this.cmsOption;
            this.dgvListSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListSearch.FilterAndSortEnabled = true;
            this.dgvListSearch.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListSearch.Location = new System.Drawing.Point(0, 87);
            this.dgvListSearch.MaxFilterButtonImageHeight = 23;
            this.dgvListSearch.Name = "dgvListSearch";
            this.dgvListSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListSearch.RowHeadersWidth = 51;
            this.dgvListSearch.RowTemplate.Height = 24;
            this.dgvListSearch.Size = new System.Drawing.Size(231, 518);
            this.dgvListSearch.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListSearch.TabIndex = 2;
            this.dgvListSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListSearch_MouseDown);
            // 
            // cmsOption
            // 
            this.cmsOption.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemsToolStripMenuItem,
            this.viewFeatureToolStripMenuItem,
            this.viewTableToolStripMenuItem1});
            this.cmsOption.Name = "cmsOption";
            this.cmsOption.Size = new System.Drawing.Size(134, 82);
            // 
            // addItemsToolStripMenuItem
            // 
            this.addItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addItemsToolStripMenuItem.Image")));
            this.addItemsToolStripMenuItem.Name = "addItemsToolStripMenuItem";
            this.addItemsToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.addItemsToolStripMenuItem.Text = "Add Items";
            this.addItemsToolStripMenuItem.Click += new System.EventHandler(this.addItemsToolStripMenuItem_Click);
            // 
            // viewFeatureToolStripMenuItem
            // 
            this.viewFeatureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewFeatureToolStripMenuItem.Image")));
            this.viewFeatureToolStripMenuItem.Name = "viewFeatureToolStripMenuItem";
            this.viewFeatureToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.viewFeatureToolStripMenuItem.Text = "Open Part";
            this.viewFeatureToolStripMenuItem.Click += new System.EventHandler(this.viewFeatureToolStripMenuItem_Click);
            // 
            // viewTableToolStripMenuItem1
            // 
            this.viewTableToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("viewTableToolStripMenuItem1.Image")));
            this.viewTableToolStripMenuItem1.Name = "viewTableToolStripMenuItem1";
            this.viewTableToolStripMenuItem1.Size = new System.Drawing.Size(133, 26);
            this.viewTableToolStripMenuItem1.Text = "View Table";
            // 
            // btnAddItems
            // 
            this.btnAddItems.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItems.Image")));
            this.btnAddItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItems.Location = new System.Drawing.Point(20, 49);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(107, 35);
            this.btnAddItems.TabIndex = 1;
            this.btnAddItems.Text = "Add Items";
            this.btnAddItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(144, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(20, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // flowtable_Feature
            // 
            this.flowtable_Feature.Controls.Add(this.btnImport);
            this.flowtable_Feature.Controls.Add(this.btnDeleteRow);
            this.flowtable_Feature.Controls.Add(this.btnClearList);
            this.flowtable_Feature.Controls.Add(this.btnCheck);
            this.flowtable_Feature.Controls.Add(this.btnUpdate);
            this.flowtable_Feature.Controls.Add(this.label1);
            this.flowtable_Feature.Controls.Add(this.label2);
            this.flowtable_Feature.Controls.Add(this.label3);
            this.flowtable_Feature.Controls.Add(this.label4);
            this.flowtable_Feature.Controls.Add(this.btnMakeNewPO);
            this.flowtable_Feature.Controls.Add(this.btnSearchPO);
            this.flowtable_Feature.Controls.Add(this.btnExit);
            this.flowtable_Feature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowtable_Feature.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowtable_Feature.Location = new System.Drawing.Point(240, 3);
            this.flowtable_Feature.Name = "flowtable_Feature";
            this.flowtable_Feature.Size = new System.Drawing.Size(144, 605);
            this.flowtable_Feature.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(132, 36);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.AutoSize = true;
            this.btnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRow.Image")));
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.Location = new System.Drawing.Point(3, 45);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(132, 36);
            this.btnDeleteRow.TabIndex = 1;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Image = ((System.Drawing.Image)(resources.GetObject("btnClearList.Image")));
            this.btnClearList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearList.Location = new System.Drawing.Point(3, 87);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(132, 36);
            this.btnClearList.TabIndex = 1;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(3, 129);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(132, 36);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(3, 171);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Short Key";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ctrl + I => Import";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alt+F4 => Close";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ctrl + F => Search";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMakeNewPO
            // 
            this.btnMakeNewPO.AutoSize = true;
            this.btnMakeNewPO.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeNewPO.Image")));
            this.btnMakeNewPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeNewPO.Location = new System.Drawing.Point(3, 289);
            this.btnMakeNewPO.Name = "btnMakeNewPO";
            this.btnMakeNewPO.Size = new System.Drawing.Size(132, 36);
            this.btnMakeNewPO.TabIndex = 1;
            this.btnMakeNewPO.Text = "Make New PO";
            this.btnMakeNewPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMakeNewPO.UseVisualStyleBackColor = true;
            // 
            // btnSearchPO
            // 
            this.btnSearchPO.AutoSize = true;
            this.btnSearchPO.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPO.Image")));
            this.btnSearchPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchPO.Location = new System.Drawing.Point(3, 331);
            this.btnSearchPO.Name = "btnSearchPO";
            this.btnSearchPO.Size = new System.Drawing.Size(132, 36);
            this.btnSearchPO.TabIndex = 1;
            this.btnSearchPO.Text = "Search Old PO";
            this.btnSearchPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchPO.UseVisualStyleBackColor = true;
            this.btnSearchPO.Click += new System.EventHandler(this.btnSearchPO_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(3, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvListItems
            // 
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.ContextMenuStrip = this.cms_dgvListItems;
            this.dgvListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListItems.FilterAndSortEnabled = true;
            this.dgvListItems.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListItems.Location = new System.Drawing.Point(390, 3);
            this.dgvListItems.MaxFilterButtonImageHeight = 23;
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListItems.RowHeadersWidth = 51;
            this.dgvListItems.RowTemplate.Height = 24;
            this.dgvListItems.Size = new System.Drawing.Size(885, 605);
            this.dgvListItems.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListItems.TabIndex = 2;
            this.dgvListItems.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvListItems_RowPostPaint);
            this.dgvListItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListItems_KeyDown);
            this.dgvListItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListItems_MouseDown);
            // 
            // cms_dgvListItems
            // 
            this.cms_dgvListItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_dgvListItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Delete,
            this.cms_Clear,
            this.checkListItemsToolStripMenuItem,
            this.changePreferSupToolStripMenuItem,
            this.pToolStripMenuItem,
            this.cms_Item_ViewFeature,
            this.viewTableToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.cms_dgvListItems.Name = "cms_dgvListItems";
            this.cms_dgvListItems.Size = new System.Drawing.Size(200, 234);
            // 
            // cms_Delete
            // 
            this.cms_Delete.Image = ((System.Drawing.Image)(resources.GetObject("cms_Delete.Image")));
            this.cms_Delete.Name = "cms_Delete";
            this.cms_Delete.Size = new System.Drawing.Size(199, 26);
            this.cms_Delete.Text = "Delete Row Items";
            this.cms_Delete.Click += new System.EventHandler(this.cms_Delete_Click);
            // 
            // cms_Clear
            // 
            this.cms_Clear.Image = ((System.Drawing.Image)(resources.GetObject("cms_Clear.Image")));
            this.cms_Clear.Name = "cms_Clear";
            this.cms_Clear.Size = new System.Drawing.Size(199, 26);
            this.cms_Clear.Text = "Clear All Items";
            this.cms_Clear.Click += new System.EventHandler(this.cms_Clear_Click);
            // 
            // changePreferSupToolStripMenuItem
            // 
            this.changePreferSupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePreferSupToolStripMenuItem.Image")));
            this.changePreferSupToolStripMenuItem.Name = "changePreferSupToolStripMenuItem";
            this.changePreferSupToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.changePreferSupToolStripMenuItem.Text = "Change Prefer Supplier";
            this.changePreferSupToolStripMenuItem.Click += new System.EventHandler(this.changePreferSupToolStripMenuItem_Click);
            // 
            // pToolStripMenuItem
            // 
            this.pToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pToolStripMenuItem.Image")));
            this.pToolStripMenuItem.Name = "pToolStripMenuItem";
            this.pToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.pToolStripMenuItem.Text = "Change Prefer Tax";
            this.pToolStripMenuItem.Click += new System.EventHandler(this.pToolStripMenuItem_Click);
            // 
            // cms_Item_ViewFeature
            // 
            this.cms_Item_ViewFeature.Image = ((System.Drawing.Image)(resources.GetObject("cms_Item_ViewFeature.Image")));
            this.cms_Item_ViewFeature.Name = "cms_Item_ViewFeature";
            this.cms_Item_ViewFeature.Size = new System.Drawing.Size(199, 26);
            this.cms_Item_ViewFeature.Text = "Open Part";
            this.cms_Item_ViewFeature.Click += new System.EventHandler(this.cms_Item_ViewFeature_Click);
            // 
            // viewTableToolStripMenuItem
            // 
            this.viewTableToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewTableToolStripMenuItem.Image")));
            this.viewTableToolStripMenuItem.Name = "viewTableToolStripMenuItem";
            this.viewTableToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.viewTableToolStripMenuItem.Text = "View Table";
            this.viewTableToolStripMenuItem.Click += new System.EventHandler(this.viewTableToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.pasteToolStripMenuItem.Text = "Paste Data";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // checkListItemsToolStripMenuItem
            // 
            this.checkListItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkListItemsToolStripMenuItem.Image")));
            this.checkListItemsToolStripMenuItem.Name = "checkListItemsToolStripMenuItem";
            this.checkListItemsToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.checkListItemsToolStripMenuItem.Text = "Check List Items";
            this.checkListItemsToolStripMenuItem.Click += new System.EventHandler(this.checkListItemsToolStripMenuItem_Click);
            // 
            // frmManagePrice_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 611);
            this.Controls.Add(this.table_layout);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManagePrice_Update";
            this.Text = "frmManagePrice_Update";
            this.Load += new System.EventHandler(this.frmManagePrice_Update_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManagePrice_Update_KeyDown);
            this.table_layout.ResumeLayout(false);
            this.Panel_TimKiem.ResumeLayout(false);
            this.Panel_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSearch)).EndInit();
            this.cmsOption.ResumeLayout(false);
            this.flowtable_Feature.ResumeLayout(false);
            this.flowtable_Feature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            this.cms_dgvListItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout;
        private System.Windows.Forms.Panel Panel_TimKiem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchPO;
        private System.Windows.Forms.Button btnMakeNewPO;
        private System.Windows.Forms.FlowLayoutPanel flowtable_Feature;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private Zuby.ADGV.AdvancedDataGridView dgvListSearch;
        private Zuby.ADGV.AdvancedDataGridView dgvListItems;
        private System.Windows.Forms.ContextMenuStrip cmsOption;
        private System.Windows.Forms.ToolStripMenuItem addItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFeatureToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms_dgvListItems;
        private System.Windows.Forms.ToolStripMenuItem cms_Delete;
        private System.Windows.Forms.ToolStripMenuItem cms_Clear;
        private System.Windows.Forms.ToolStripMenuItem cms_Item_ViewFeature;
        private System.Windows.Forms.ToolStripMenuItem viewTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTableToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem changePreferSupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkListItemsToolStripMenuItem;
    }
}