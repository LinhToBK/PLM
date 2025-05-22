namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmFindPO_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindPO_Update));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchByDateTime = new System.Windows.Forms.Button();
            this.ckcOnlyDay = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.btnFindItem = new System.Windows.Forms.Button();
            this.btnSearchByPartCode = new System.Windows.Forms.Button();
            this.dgvListPartCode = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgvListCode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findPOThisPartCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvResult = new Zuby.ADGV.AdvancedDataGridView();
            this.cms_dgvResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_dgvResult_ViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_dgvResult_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPartCode)).BeginInit();
            this.cms_dgvListCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.cms_dgvResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvResult, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.93128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.06872F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1198, 553);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1192, 247);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.dtpStartDate);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpEndDate);
            this.flowLayoutPanel1.Controls.Add(this.btnSearchByDateTime);
            this.flowLayoutPanel1.Controls.Add(this.ckcOnlyDay);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1186, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(58, 3);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(117, 30);
            this.dtpStartDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(181, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "to";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(213, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(117, 30);
            this.dtpEndDate.TabIndex = 1;
            // 
            // btnSearchByDateTime
            // 
            this.btnSearchByDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchByDateTime.Location = new System.Drawing.Point(336, 3);
            this.btnSearchByDateTime.Name = "btnSearchByDateTime";
            this.btnSearchByDateTime.Size = new System.Drawing.Size(182, 30);
            this.btnSearchByDateTime.TabIndex = 2;
            this.btnSearchByDateTime.Text = "Search By Date";
            this.btnSearchByDateTime.UseVisualStyleBackColor = true;
            this.btnSearchByDateTime.Click += new System.EventHandler(this.btnSearchByDateTime_Click);
            // 
            // ckcOnlyDay
            // 
            this.ckcOnlyDay.AutoSize = true;
            this.ckcOnlyDay.Location = new System.Drawing.Point(524, 3);
            this.ckcOnlyDay.Name = "ckcOnlyDay";
            this.ckcOnlyDay.Size = new System.Drawing.Size(73, 27);
            this.ckcOnlyDay.TabIndex = 3;
            this.ckcOnlyDay.Text = "1 day";
            this.ckcOnlyDay.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvListPartCode, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1186, 199);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.txtPartCode);
            this.flowLayoutPanel2.Controls.Add(this.btnFindItem);
            this.flowLayoutPanel2.Controls.Add(this.btnSearchByPartCode);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(262, 193);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Part Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(3, 26);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(191, 30);
            this.txtPartCode.TabIndex = 2;
            this.txtPartCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartCode_KeyDown);
            // 
            // btnFindItem
            // 
            this.btnFindItem.Location = new System.Drawing.Point(3, 62);
            this.btnFindItem.Name = "btnFindItem";
            this.btnFindItem.Size = new System.Drawing.Size(191, 32);
            this.btnFindItem.TabIndex = 4;
            this.btnFindItem.Text = "Find Item";
            this.btnFindItem.UseVisualStyleBackColor = true;
            this.btnFindItem.Click += new System.EventHandler(this.btnFindItem_Click);
            // 
            // btnSearchByPartCode
            // 
            this.btnSearchByPartCode.Location = new System.Drawing.Point(3, 100);
            this.btnSearchByPartCode.Name = "btnSearchByPartCode";
            this.btnSearchByPartCode.Size = new System.Drawing.Size(191, 32);
            this.btnSearchByPartCode.TabIndex = 3;
            this.btnSearchByPartCode.Text = "Search By Part Code";
            this.btnSearchByPartCode.UseVisualStyleBackColor = true;
            this.btnSearchByPartCode.Click += new System.EventHandler(this.btnSearchByPartCode_Click);
            // 
            // dgvListPartCode
            // 
            this.dgvListPartCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPartCode.ContextMenuStrip = this.cms_dgvListCode;
            this.dgvListPartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListPartCode.FilterAndSortEnabled = true;
            this.dgvListPartCode.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListPartCode.Location = new System.Drawing.Point(271, 3);
            this.dgvListPartCode.MaxFilterButtonImageHeight = 23;
            this.dgvListPartCode.Name = "dgvListPartCode";
            this.dgvListPartCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListPartCode.RowHeadersWidth = 51;
            this.dgvListPartCode.RowTemplate.Height = 24;
            this.dgvListPartCode.Size = new System.Drawing.Size(912, 193);
            this.dgvListPartCode.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListPartCode.TabIndex = 3;
            // 
            // cms_dgvListCode
            // 
            this.cms_dgvListCode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_dgvListCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findPOThisPartCodeToolStripMenuItem,
            this.openPartToolStripMenuItem});
            this.cms_dgvListCode.Name = "cms_dgvListCode";
            this.cms_dgvListCode.Size = new System.Drawing.Size(229, 56);
            // 
            // findPOThisPartCodeToolStripMenuItem
            // 
            this.findPOThisPartCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("findPOThisPartCodeToolStripMenuItem.Image")));
            this.findPOThisPartCodeToolStripMenuItem.Name = "findPOThisPartCodeToolStripMenuItem";
            this.findPOThisPartCodeToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.findPOThisPartCodeToolStripMenuItem.Text = "Find PO this Part Code";
            this.findPOThisPartCodeToolStripMenuItem.Click += new System.EventHandler(this.findPOThisPartCodeToolStripMenuItem_Click);
            // 
            // openPartToolStripMenuItem
            // 
            this.openPartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openPartToolStripMenuItem.Image")));
            this.openPartToolStripMenuItem.Name = "openPartToolStripMenuItem";
            this.openPartToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.openPartToolStripMenuItem.Text = "Open Part";
            this.openPartToolStripMenuItem.Click += new System.EventHandler(this.openPartToolStripMenuItem_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.ContextMenuStrip = this.cms_dgvResult;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.FilterAndSortEnabled = true;
            this.dgvResult.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvResult.Location = new System.Drawing.Point(3, 256);
            this.dgvResult.MaxFilterButtonImageHeight = 23;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvResult.RowHeadersWidth = 51;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(1192, 294);
            this.dgvResult.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvResult.TabIndex = 1;
            // 
            // cms_dgvResult
            // 
            this.cms_dgvResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_dgvResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_dgvResult_ViewDetail,
            this.cms_dgvResult_Update});
            this.cms_dgvResult.Name = "cms_dgvResult";
            this.cms_dgvResult.Size = new System.Drawing.Size(182, 56);
            // 
            // cms_dgvResult_ViewDetail
            // 
            this.cms_dgvResult_ViewDetail.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgvResult_ViewDetail.Image")));
            this.cms_dgvResult_ViewDetail.Name = "cms_dgvResult_ViewDetail";
            this.cms_dgvResult_ViewDetail.Size = new System.Drawing.Size(181, 26);
            this.cms_dgvResult_ViewDetail.Text = "View Detail PO";
            this.cms_dgvResult_ViewDetail.Click += new System.EventHandler(this.cms_dgvResult_ViewDetail_Click);
            // 
            // cms_dgvResult_Update
            // 
            this.cms_dgvResult_Update.Image = ((System.Drawing.Image)(resources.GetObject("cms_dgvResult_Update.Image")));
            this.cms_dgvResult_Update.Name = "cms_dgvResult_Update";
            this.cms_dgvResult_Update.Size = new System.Drawing.Size(181, 26);
            this.cms_dgvResult_Update.Text = "Update PO";
            // 
            // frmFindPO_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFindPO_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFindPO_Update";
            this.Load += new System.EventHandler(this.frmFindPO_Update_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPartCode)).EndInit();
            this.cms_dgvListCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.cms_dgvResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearchByDateTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Button btnSearchByPartCode;
        private Zuby.ADGV.AdvancedDataGridView dgvResult;
        private System.Windows.Forms.CheckBox ckcOnlyDay;
        private System.Windows.Forms.ContextMenuStrip cms_dgvResult;
        private System.Windows.Forms.ToolStripMenuItem cms_dgvResult_ViewDetail;
        private System.Windows.Forms.ToolStripMenuItem cms_dgvResult_Update;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Zuby.ADGV.AdvancedDataGridView dgvListPartCode;
        private System.Windows.Forms.Button btnFindItem;
        private System.Windows.Forms.ContextMenuStrip cms_dgvListCode;
        private System.Windows.Forms.ToolStripMenuItem findPOThisPartCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPartToolStripMenuItem;
    }
}