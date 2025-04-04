namespace PLM_Lynx._03_GUI_User_Interface._3_6_Help
{
    partial class frmAboutMe
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelCongty = new System.Windows.Forms.Panel();
            this.btnSaveInfor = new System.Windows.Forms.Button();
            this.btnModifyCompany = new System.Windows.Forms.Button();
            this.txtCompanyTaxCode = new System.Windows.Forms.TextBox();
            this.txtCompanyLocation = new System.Windows.Forms.TextBox();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelVersion = new System.Windows.Forms.Panel();
            this.btnSaveVersion = new System.Windows.Forms.Button();
            this.btnAddVersion = new System.Windows.Forms.Button();
            this.txtVersionContent = new System.Windows.Forms.TextBox();
            this.txtVersionID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvVersion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelCongty.SuspendLayout();
            this.panelVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelCongty);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelVersion);
            this.splitContainer1.Size = new System.Drawing.Size(917, 562);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelCongty
            // 
            this.panelCongty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelCongty.Controls.Add(this.btnSaveInfor);
            this.panelCongty.Controls.Add(this.btnModifyCompany);
            this.panelCongty.Controls.Add(this.txtCompanyTaxCode);
            this.panelCongty.Controls.Add(this.txtCompanyLocation);
            this.panelCongty.Controls.Add(this.txtCompanyPhone);
            this.panelCongty.Controls.Add(this.txtCompanyName);
            this.panelCongty.Controls.Add(this.label4);
            this.panelCongty.Controls.Add(this.label3);
            this.panelCongty.Controls.Add(this.label2);
            this.panelCongty.Controls.Add(this.label1);
            this.panelCongty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCongty.Location = new System.Drawing.Point(0, 0);
            this.panelCongty.Name = "panelCongty";
            this.panelCongty.Size = new System.Drawing.Size(917, 193);
            this.panelCongty.TabIndex = 0;
            // 
            // btnSaveInfor
            // 
            this.btnSaveInfor.Location = new System.Drawing.Point(191, 103);
            this.btnSaveInfor.Name = "btnSaveInfor";
            this.btnSaveInfor.Size = new System.Drawing.Size(129, 34);
            this.btnSaveInfor.TabIndex = 2;
            this.btnSaveInfor.Text = "Lưu cập nhật";
            this.btnSaveInfor.UseVisualStyleBackColor = true;
            this.btnSaveInfor.Click += new System.EventHandler(this.btnSaveInfor_Click);
            // 
            // btnModifyCompany
            // 
            this.btnModifyCompany.Location = new System.Drawing.Point(23, 103);
            this.btnModifyCompany.Name = "btnModifyCompany";
            this.btnModifyCompany.Size = new System.Drawing.Size(129, 34);
            this.btnModifyCompany.TabIndex = 0;
            this.btnModifyCompany.Text = "Sửa thông tin";
            this.btnModifyCompany.UseVisualStyleBackColor = true;
            this.btnModifyCompany.Click += new System.EventHandler(this.btnModifyCompany_Click);
            // 
            // txtCompanyTaxCode
            // 
            this.txtCompanyTaxCode.Location = new System.Drawing.Point(724, 12);
            this.txtCompanyTaxCode.Name = "txtCompanyTaxCode";
            this.txtCompanyTaxCode.Size = new System.Drawing.Size(170, 27);
            this.txtCompanyTaxCode.TabIndex = 1;
            this.txtCompanyTaxCode.TextChanged += new System.EventHandler(this.txtCompanyTaxCode_TextChanged);
            // 
            // txtCompanyLocation
            // 
            this.txtCompanyLocation.Location = new System.Drawing.Point(111, 55);
            this.txtCompanyLocation.Name = "txtCompanyLocation";
            this.txtCompanyLocation.Size = new System.Drawing.Size(783, 27);
            this.txtCompanyLocation.TabIndex = 1;
            this.txtCompanyLocation.TextChanged += new System.EventHandler(this.txtCompanyLocation_TextChanged);
            // 
            // txtCompanyPhone
            // 
            this.txtCompanyPhone.Location = new System.Drawing.Point(420, 12);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.Size = new System.Drawing.Size(210, 27);
            this.txtCompanyPhone.TabIndex = 1;
            this.txtCompanyPhone.TextChanged += new System.EventHandler(this.txtCompanyPhone_TextChanged);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(110, 12);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(262, 27);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(636, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã số thuế";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "SĐT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên công ty";
            // 
            // panelVersion
            // 
            this.panelVersion.AutoScroll = true;
            this.panelVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelVersion.Controls.Add(this.btnSaveVersion);
            this.panelVersion.Controls.Add(this.btnAddVersion);
            this.panelVersion.Controls.Add(this.txtVersionContent);
            this.panelVersion.Controls.Add(this.txtVersionID);
            this.panelVersion.Controls.Add(this.label7);
            this.panelVersion.Controls.Add(this.label6);
            this.panelVersion.Controls.Add(this.label5);
            this.panelVersion.Controls.Add(this.dgvVersion);
            this.panelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVersion.Location = new System.Drawing.Point(0, 0);
            this.panelVersion.Name = "panelVersion";
            this.panelVersion.Size = new System.Drawing.Size(917, 364);
            this.panelVersion.TabIndex = 0;
            // 
            // btnSaveVersion
            // 
            this.btnSaveVersion.Location = new System.Drawing.Point(237, 58);
            this.btnSaveVersion.Name = "btnSaveVersion";
            this.btnSaveVersion.Size = new System.Drawing.Size(118, 28);
            this.btnSaveVersion.TabIndex = 3;
            this.btnSaveVersion.Text = "Lưu cập nhật";
            this.btnSaveVersion.UseVisualStyleBackColor = true;
            this.btnSaveVersion.Click += new System.EventHandler(this.btnSaveVersion_Click);
            // 
            // btnAddVersion
            // 
            this.btnAddVersion.Location = new System.Drawing.Point(95, 58);
            this.btnAddVersion.Name = "btnAddVersion";
            this.btnAddVersion.Size = new System.Drawing.Size(112, 28);
            this.btnAddVersion.TabIndex = 3;
            this.btnAddVersion.Text = "Thêm Version";
            this.btnAddVersion.UseVisualStyleBackColor = true;
            this.btnAddVersion.Click += new System.EventHandler(this.btnAddVersion_Click);
            // 
            // txtVersionContent
            // 
            this.txtVersionContent.Location = new System.Drawing.Point(378, 17);
            this.txtVersionContent.Multiline = true;
            this.txtVersionContent.Name = "txtVersionContent";
            this.txtVersionContent.Size = new System.Drawing.Size(516, 69);
            this.txtVersionContent.TabIndex = 2;
            this.txtVersionContent.TextChanged += new System.EventHandler(this.txtVersionContent_TextChanged);
            // 
            // txtVersionID
            // 
            this.txtVersionID.Location = new System.Drawing.Point(213, 17);
            this.txtVersionID.Name = "txtVersionID";
            this.txtVersionID.Size = new System.Drawing.Size(72, 27);
            this.txtVersionID.TabIndex = 2;
            this.txtVersionID.TextChanged += new System.EventHandler(this.txtVersionID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nội dung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Lịch sử các version";
            // 
            // dgvVersion
            // 
            this.dgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvVersion.Location = new System.Drawing.Point(0, 112);
            this.dgvVersion.Name = "dgvVersion";
            this.dgvVersion.RowHeadersWidth = 51;
            this.dgvVersion.RowTemplate.Height = 24;
            this.dgvVersion.Size = new System.Drawing.Size(917, 252);
            this.dgvVersion.TabIndex = 0;
            // 
            // frmAboutMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 562);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAboutMe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAboutMe";
            this.Load += new System.EventHandler(this.frmAboutMe_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelCongty.ResumeLayout(false);
            this.panelCongty.PerformLayout();
            this.panelVersion.ResumeLayout(false);
            this.panelVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelCongty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelVersion;
        private System.Windows.Forms.TextBox txtCompanyTaxCode;
        private System.Windows.Forms.TextBox txtCompanyLocation;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnSaveInfor;
        private System.Windows.Forms.Button btnModifyCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvVersion;
        private System.Windows.Forms.TextBox txtVersionContent;
        private System.Windows.Forms.TextBox txtVersionID;
        private System.Windows.Forms.Button btnSaveVersion;
        private System.Windows.Forms.Button btnAddVersion;
    }
}