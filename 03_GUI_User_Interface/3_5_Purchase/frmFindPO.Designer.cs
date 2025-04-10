namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmFindPO
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
            this.btnExit = new System.Windows.Forms.Button();
            this.BtnKeySearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ckcStatus = new System.Windows.Forms.CheckedListBox();
            this.ckcStaff = new System.Windows.Forms.CheckedListBox();
            this.ckcDate = new System.Windows.Forms.CheckedListBox();
            this.ckcMonth = new System.Windows.Forms.CheckedListBox();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioPart = new System.Windows.Forms.RadioButton();
            this.radioPO = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgvPartlist = new System.Windows.Forms.DataGridView();
            this.txtPOSupplier = new System.Windows.Forms.TextBox();
            this.txtPOAmount = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtNhanvien = new System.Windows.Forms.TextBox();
            this.txtPOCode = new System.Windows.Forms.TextBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartlist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(388, 145);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 54);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BtnKeySearch
            // 
            this.BtnKeySearch.Location = new System.Drawing.Point(238, 38);
            this.BtnKeySearch.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.BtnKeySearch.Name = "BtnKeySearch";
            this.BtnKeySearch.Size = new System.Drawing.Size(91, 34);
            this.BtnKeySearch.TabIndex = 1;
            this.BtnKeySearch.Text = "Search";
            this.BtnKeySearch.UseVisualStyleBackColor = true;
            this.BtnKeySearch.Click += new System.EventHandler(this.BtnKeySearch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.ckcStatus);
            this.splitContainer1.Panel1.Controls.Add(this.ckcStaff);
            this.splitContainer1.Panel1.Controls.Add(this.ckcDate);
            this.splitContainer1.Panel1.Controls.Add(this.ckcMonth);
            this.splitContainer1.Panel1.Controls.Add(this.dgvSearch);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dtpFilter);
            this.splitContainer1.Panel1.Controls.Add(this.txtKeySearch);
            this.splitContainer1.Panel1.Controls.Add(this.btnFilter);
            this.splitContainer1.Panel1.Controls.Add(this.BtnKeySearch);
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dgvPartlist);
            this.splitContainer1.Panel2.Controls.Add(this.txtPOSupplier);
            this.splitContainer1.Panel2.Controls.Add(this.txtPOAmount);
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Controls.Add(this.txtNhanvien);
            this.splitContainer1.Panel2.Controls.Add(this.txtPOCode);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdateStatus);
            this.splitContainer1.Panel2.Controls.Add(this.btnExportExcel);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1085, 620);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.TabIndex = 0;
            // 
            // ckcStatus
            // 
            this.ckcStatus.FormattingEnabled = true;
            this.ckcStatus.Location = new System.Drawing.Point(284, 145);
            this.ckcStatus.Name = "ckcStatus";
            this.ckcStatus.Size = new System.Drawing.Size(96, 54);
            this.ckcStatus.TabIndex = 9;
            this.ckcStatus.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckcStatus_ItemCheck);
            this.ckcStatus.SelectedIndexChanged += new System.EventHandler(this.ckcStatus_SelectedIndexChanged);
            // 
            // ckcStaff
            // 
            this.ckcStaff.FormattingEnabled = true;
            this.ckcStaff.Location = new System.Drawing.Point(157, 145);
            this.ckcStaff.Name = "ckcStaff";
            this.ckcStaff.Size = new System.Drawing.Size(121, 54);
            this.ckcStaff.TabIndex = 7;
            this.ckcStaff.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckcStaff_ItemCheck);
            // 
            // ckcDate
            // 
            this.ckcDate.AllowDrop = true;
            this.ckcDate.FormattingEnabled = true;
            this.ckcDate.Location = new System.Drawing.Point(91, 145);
            this.ckcDate.Name = "ckcDate";
            this.ckcDate.Size = new System.Drawing.Size(60, 54);
            this.ckcDate.TabIndex = 7;
            this.ckcDate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckcDate_ItemCheck);
            // 
            // ckcMonth
            // 
            this.ckcMonth.AllowDrop = true;
            this.ckcMonth.FormattingEnabled = true;
            this.ckcMonth.Location = new System.Drawing.Point(25, 145);
            this.ckcMonth.Name = "ckcMonth";
            this.ckcMonth.Size = new System.Drawing.Size(60, 54);
            this.ckcMonth.TabIndex = 7;
            this.ckcMonth.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckcMonth_ItemCheck);
            // 
            // dgvSearch
            // 
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(0, 214);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowHeadersWidth = 51;
            this.dgvSearch.RowTemplate.Height = 24;
            this.dgvSearch.Size = new System.Drawing.Size(380, 153);
            this.dgvSearch.TabIndex = 6;
            this.dgvSearch.Click += new System.EventHandler(this.dgvSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPart);
            this.groupBox1.Controls.Add(this.radioPO);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(340, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // radioPart
            // 
            this.radioPart.AutoSize = true;
            this.radioPart.Checked = true;
            this.radioPart.Location = new System.Drawing.Point(13, 49);
            this.radioPart.Name = "radioPart";
            this.radioPart.Size = new System.Drawing.Size(70, 21);
            this.radioPart.TabIndex = 0;
            this.radioPart.TabStop = true;
            this.radioPart.Text = "by Part";
            this.radioPart.UseVisualStyleBackColor = true;
            // 
            // radioPO
            // 
            this.radioPO.AutoSize = true;
            this.radioPO.Location = new System.Drawing.Point(13, 20);
            this.radioPO.Name = "radioPO";
            this.radioPO.Size = new System.Drawing.Size(64, 21);
            this.radioPO.TabIndex = 0;
            this.radioPO.Text = "by PO";
            this.radioPO.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập PO Code hoặc Part Code";
            // 
            // dtpFilter
            // 
            this.dtpFilter.AllowDrop = true;
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(25, 94);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(202, 30);
            this.dtpFilter.TabIndex = 3;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(23, 40);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(202, 30);
            this.txtKeySearch.TabIndex = 0;
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(238, 92);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(91, 34);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "By Date";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgvPartlist
            // 
            this.dgvPartlist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvPartlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartlist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPartlist.Location = new System.Drawing.Point(0, 214);
            this.dgvPartlist.Name = "dgvPartlist";
            this.dgvPartlist.RowHeadersWidth = 51;
            this.dgvPartlist.RowTemplate.Height = 24;
            this.dgvPartlist.Size = new System.Drawing.Size(633, 406);
            this.dgvPartlist.TabIndex = 3;
            // 
            // txtPOSupplier
            // 
            this.txtPOSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPOSupplier.Location = new System.Drawing.Point(127, 100);
            this.txtPOSupplier.Name = "txtPOSupplier";
            this.txtPOSupplier.ReadOnly = true;
            this.txtPOSupplier.Size = new System.Drawing.Size(168, 30);
            this.txtPOSupplier.TabIndex = 2;
            // 
            // txtPOAmount
            // 
            this.txtPOAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPOAmount.Location = new System.Drawing.Point(127, 59);
            this.txtPOAmount.Name = "txtPOAmount";
            this.txtPOAmount.ReadOnly = true;
            this.txtPOAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPOAmount.Size = new System.Drawing.Size(168, 30);
            this.txtPOAmount.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStatus.Location = new System.Drawing.Point(445, 59);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(103, 30);
            this.txtStatus.TabIndex = 2;
            // 
            // txtNhanvien
            // 
            this.txtNhanvien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNhanvien.Location = new System.Drawing.Point(380, 18);
            this.txtNhanvien.Name = "txtNhanvien";
            this.txtNhanvien.ReadOnly = true;
            this.txtNhanvien.Size = new System.Drawing.Size(168, 30);
            this.txtNhanvien.TabIndex = 2;
            // 
            // txtPOCode
            // 
            this.txtPOCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPOCode.Location = new System.Drawing.Point(127, 18);
            this.txtPOCode.Name = "txtPOCode";
            this.txtPOCode.ReadOnly = true;
            this.txtPOCode.Size = new System.Drawing.Size(168, 30);
            this.txtPOCode.TabIndex = 2;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(239, 145);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(144, 32);
            this.btnUpdateStatus.TabIndex = 1;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(21, 145);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(189, 32);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Export PO to Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Creator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "(VND)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "PO Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "PO Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "PO Code";
            // 
            // frmFindPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 620);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmFindPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find PO";
            this.Load += new System.EventHandler(this.frmFindPO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button BtnKeySearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPart;
        private System.Windows.Forms.RadioButton radioPO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPOSupplier;
        private System.Windows.Forms.TextBox txtPOAmount;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtNhanvien;
        private System.Windows.Forms.TextBox txtPOCode;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPartlist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox ckcMonth;
        private System.Windows.Forms.CheckedListBox ckcStaff;
        private System.Windows.Forms.CheckedListBox ckcDate;
        private System.Windows.Forms.CheckedListBox ckcStatus;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}