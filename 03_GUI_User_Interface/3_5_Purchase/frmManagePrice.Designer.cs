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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.cboPrecision = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUSDPrice = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdioVND = new System.Windows.Forms.RadioButton();
            this.rdioUSD = new System.Windows.Forms.RadioButton();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.lblTypeCurrent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckcAllowModifyRate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnSaveNewPrice = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnMakeNewPO = new System.Windows.Forms.Button();
            this.btnTraCuuPO = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(429, 53);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 41);
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
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5192F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.22037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.39232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.70117F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 679);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(3, 81);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(518, 213);
            this.dgvListTimKiem.TabIndex = 2;
            this.dgvListTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellDoubleClick);
            this.dgvListTimKiem.SelectionChanged += new System.EventHandler(this.dgvListTimKiem_SelectionChanged);
            this.dgvListTimKiem.DoubleClick += new System.EventHandler(this.dgvListTimKiem_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPartStage);
            this.groupBox1.Controls.Add(this.cboPrecision);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUSDPrice);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtPartPrice);
            this.groupBox1.Controls.Add(this.txtDescript);
            this.groupBox1.Controls.Add(this.txtPartName);
            this.groupBox1.Controls.Add(this.txtPartCode);
            this.groupBox1.Controls.Add(this.lblTypeCurrent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 234);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Part";
            // 
            // txtPartStage
            // 
            this.txtPartStage.Location = new System.Drawing.Point(92, 53);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(59, 25);
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
            this.cboPrecision.Location = new System.Drawing.Point(229, 53);
            this.cboPrecision.Name = "cboPrecision";
            this.cboPrecision.Size = new System.Drawing.Size(57, 25);
            this.cboPrecision.TabIndex = 5;
            this.cboPrecision.SelectedIndexChanged += new System.EventHandler(this.cboPrecision_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "( USD )";
            // 
            // txtUSDPrice
            // 
            this.txtUSDPrice.Location = new System.Drawing.Point(312, 53);
            this.txtUSDPrice.Name = "txtUSDPrice";
            this.txtUSDPrice.ReadOnly = true;
            this.txtUSDPrice.Size = new System.Drawing.Size(131, 25);
            this.txtUSDPrice.TabIndex = 3;
            this.txtUSDPrice.TextChanged += new System.EventHandler(this.txtUSDPrice_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Lime;
            this.groupBox3.Controls.Add(this.rdioVND);
            this.groupBox3.Controls.Add(this.rdioUSD);
            this.groupBox3.Location = new System.Drawing.Point(6, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(80, 76);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current";
            // 
            // rdioVND
            // 
            this.rdioVND.AutoSize = true;
            this.rdioVND.Location = new System.Drawing.Point(12, 45);
            this.rdioVND.Name = "rdioVND";
            this.rdioVND.Size = new System.Drawing.Size(53, 21);
            this.rdioVND.TabIndex = 1;
            this.rdioVND.TabStop = true;
            this.rdioVND.Text = "VND";
            this.rdioVND.UseVisualStyleBackColor = true;
            // 
            // rdioUSD
            // 
            this.rdioUSD.AutoSize = true;
            this.rdioUSD.Location = new System.Drawing.Point(12, 20);
            this.rdioUSD.Name = "rdioUSD";
            this.rdioUSD.Size = new System.Drawing.Size(51, 21);
            this.rdioUSD.TabIndex = 0;
            this.rdioUSD.TabStop = true;
            this.rdioUSD.Text = "USD";
            this.rdioUSD.UseVisualStyleBackColor = true;
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPartPrice.Location = new System.Drawing.Point(312, 20);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.ReadOnly = true;
            this.txtPartPrice.Size = new System.Drawing.Size(131, 25);
            this.txtPartPrice.TabIndex = 1;
            this.txtPartPrice.TextChanged += new System.EventHandler(this.txtPartPrice_TextChanged);
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(92, 119);
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.ReadOnly = true;
            this.txtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescript.Size = new System.Drawing.Size(417, 107);
            this.txtDescript.TabIndex = 1;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(92, 86);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(417, 25);
            this.txtPartName.TabIndex = 1;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(92, 20);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(126, 25);
            this.txtPartCode.TabIndex = 1;
            // 
            // lblTypeCurrent
            // 
            this.lblTypeCurrent.AutoSize = true;
            this.lblTypeCurrent.Location = new System.Drawing.Point(463, 25);
            this.lblTypeCurrent.Name = "lblTypeCurrent";
            this.lblTypeCurrent.Size = new System.Drawing.Size(51, 17);
            this.lblTypeCurrent.TabIndex = 0;
            this.lblTypeCurrent.Text = "( VND )";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Precision";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Part Descript";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Part Stage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckcAllowModifyRate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRate);
            this.groupBox2.Controls.Add(this.btnSaveNewPrice);
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập nhật";
            // 
            // ckcAllowModifyRate
            // 
            this.ckcAllowModifyRate.AutoSize = true;
            this.ckcAllowModifyRate.Location = new System.Drawing.Point(21, 80);
            this.ckcAllowModifyRate.Name = "ckcAllowModifyRate";
            this.ckcAllowModifyRate.Size = new System.Drawing.Size(107, 21);
            this.ckcAllowModifyRate.TabIndex = 5;
            this.ckcAllowModifyRate.Text = "Modify Tỷ giá";
            this.ckcAllowModifyRate.UseVisualStyleBackColor = true;
            this.ckcAllowModifyRate.CheckedChanged += new System.EventHandler(this.ckcAllowModifyRate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tỷ giá USD/VND";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(21, 51);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 25);
            this.txtRate.TabIndex = 3;
            // 
            // btnSaveNewPrice
            // 
            this.btnSaveNewPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNewPrice.Image")));
            this.btnSaveNewPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNewPrice.Location = new System.Drawing.Point(299, 53);
            this.btnSaveNewPrice.Name = "btnSaveNewPrice";
            this.btnSaveNewPrice.Size = new System.Drawing.Size(119, 41);
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
            this.btnModify.Location = new System.Drawing.Point(212, 53);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 41);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnMakeNewPO);
            this.groupBox4.Controls.Add(this.btnTraCuuPO);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Controls.Add(this.txtKeySearch);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(518, 72);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm Part";
            // 
            // btnMakeNewPO
            // 
            this.btnMakeNewPO.Location = new System.Drawing.Point(313, 20);
            this.btnMakeNewPO.Name = "btnMakeNewPO";
            this.btnMakeNewPO.Size = new System.Drawing.Size(111, 40);
            this.btnMakeNewPO.TabIndex = 3;
            this.btnMakeNewPO.Text = "Make New PO";
            this.btnMakeNewPO.UseVisualStyleBackColor = true;
            // 
            // btnTraCuuPO
            // 
            this.btnTraCuuPO.Location = new System.Drawing.Point(432, 16);
            this.btnTraCuuPO.Name = "btnTraCuuPO";
            this.btnTraCuuPO.Size = new System.Drawing.Size(79, 48);
            this.btnTraCuuPO.TabIndex = 2;
            this.btnTraCuuPO.Text = "Tra cứu PO";
            this.btnTraCuuPO.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(226, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 40);
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
            this.txtKeySearch.Size = new System.Drawing.Size(209, 25);
            this.txtKeySearch.TabIndex = 0;
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // frmManagePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 679);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmManagePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý giá";
            this.Load += new System.EventHandler(this.frmManagePrice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvListTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveNewPrice;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTypeCurrent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdioVND;
        private System.Windows.Forms.RadioButton rdioUSD;
        private System.Windows.Forms.GroupBox groupBox4;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}