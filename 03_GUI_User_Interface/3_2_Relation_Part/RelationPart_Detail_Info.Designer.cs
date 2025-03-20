namespace PLM_Lynx._03_GUI_User_Interface
{
    partial class frmRelationPart_Detail_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelationPart_Detail_Info));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PicPart = new System.Windows.Forms.PictureBox();
            this.dgvListFile = new System.Windows.Forms.DataGridView();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartDescription = new System.Windows.Forms.TextBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.txtPartLog = new System.Windows.Forms.TextBox();
            this.txtPicStatus = new System.Windows.Forms.TextBox();
            this.txtListFileStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDownLoadFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_PartInfor = new System.Windows.Forms.Panel();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Panel_Download = new System.Windows.Forms.Panel();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.checklistTypeFile = new System.Windows.Forms.CheckedListBox();
            this.checklistStage = new System.Windows.Forms.CheckedListBox();
            this.PanelDataGridView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel_PartInfor.SuspendLayout();
            this.Panel_Download.SuspendLayout();
            this.PanelDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Part \r\nDescription";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current Stage";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Part Log";
            // 
            // PicPart
            // 
            this.PicPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicPart.Location = new System.Drawing.Point(365, 7);
            this.PicPart.Name = "PicPart";
            this.PicPart.Size = new System.Drawing.Size(131, 120);
            this.PicPart.TabIndex = 1;
            this.PicPart.TabStop = false;
            // 
            // dgvListFile
            // 
            this.dgvListFile.AllowUserToAddRows = false;
            this.dgvListFile.AllowUserToDeleteRows = false;
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListFile.Location = new System.Drawing.Point(0, 28);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.ReadOnly = true;
            this.dgvListFile.RowHeadersWidth = 51;
            this.dgvListFile.Size = new System.Drawing.Size(504, 168);
            this.dgvListFile.TabIndex = 2;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(82, 29);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(112, 29);
            this.txtPartCode.TabIndex = 3;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(82, 64);
            this.txtPartName.Multiline = true;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(277, 63);
            this.txtPartName.TabIndex = 3;
            // 
            // txtPartDescription
            // 
            this.txtPartDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPartDescription.Location = new System.Drawing.Point(82, 163);
            this.txtPartDescription.Multiline = true;
            this.txtPartDescription.Name = "txtPartDescription";
            this.txtPartDescription.ReadOnly = true;
            this.txtPartDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartDescription.Size = new System.Drawing.Size(414, 14);
            this.txtPartDescription.TabIndex = 3;
            // 
            // txtPartStage
            // 
            this.txtPartStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartStage.Location = new System.Drawing.Point(114, 133);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(36, 29);
            this.txtPartStage.TabIndex = 3;
            // 
            // txtPartLog
            // 
            this.txtPartLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPartLog.Location = new System.Drawing.Point(83, 204);
            this.txtPartLog.Multiline = true;
            this.txtPartLog.Name = "txtPartLog";
            this.txtPartLog.ReadOnly = true;
            this.txtPartLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartLog.Size = new System.Drawing.Size(413, 90);
            this.txtPartLog.TabIndex = 3;
            // 
            // txtPicStatus
            // 
            this.txtPicStatus.Location = new System.Drawing.Point(201, 29);
            this.txtPicStatus.Name = "txtPicStatus";
            this.txtPicStatus.ReadOnly = true;
            this.txtPicStatus.Size = new System.Drawing.Size(158, 29);
            this.txtPicStatus.TabIndex = 3;
            this.txtPicStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtListFileStatus
            // 
            this.txtListFileStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtListFileStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtListFileStatus.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListFileStatus.Location = new System.Drawing.Point(0, 0);
            this.txtListFileStatus.Multiline = true;
            this.txtListFileStatus.Name = "txtListFileStatus";
            this.txtListFileStatus.ReadOnly = true;
            this.txtListFileStatus.Size = new System.Drawing.Size(504, 22);
            this.txtListFileStatus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(9, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Có thể nhấn \"Esc\" để thoát khỏi form này ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownLoadFile
            // 
            this.btnDownLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDownLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDownLoadFile.Image")));
            this.btnDownLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownLoadFile.Location = new System.Drawing.Point(338, 58);
            this.btnDownLoadFile.Name = "btnDownLoadFile";
            this.btnDownLoadFile.Size = new System.Drawing.Size(143, 27);
            this.btnDownLoadFile.TabIndex = 6;
            this.btnDownLoadFile.Text = "DownLoad File";
            this.btnDownLoadFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownLoadFile.UseVisualStyleBackColor = false;
            this.btnDownLoadFile.Click += new System.EventHandler(this.btnDownLoadFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(338, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 40);
            this.label6.TabIndex = 7;
            this.label6.Text = "Chọn hàng cần download. \r\nGiữ Ctrl để chọn nhiều hàng";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Panel_PartInfor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Download, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PanelDataGridView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 669);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Panel_PartInfor
            // 
            this.Panel_PartInfor.AutoScroll = true;
            this.Panel_PartInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel_PartInfor.Controls.Add(this.txtPartLog);
            this.Panel_PartInfor.Controls.Add(this.txtPartName);
            this.Panel_PartInfor.Controls.Add(this.txtPartPrice);
            this.Panel_PartInfor.Controls.Add(this.txtPartStage);
            this.Panel_PartInfor.Controls.Add(this.label9);
            this.Panel_PartInfor.Controls.Add(this.label8);
            this.Panel_PartInfor.Controls.Add(this.label4);
            this.Panel_PartInfor.Controls.Add(this.label7);
            this.Panel_PartInfor.Controls.Add(this.txtPartDescription);
            this.Panel_PartInfor.Controls.Add(this.txtPicStatus);
            this.Panel_PartInfor.Controls.Add(this.label5);
            this.Panel_PartInfor.Controls.Add(this.PicPart);
            this.Panel_PartInfor.Controls.Add(this.label1);
            this.Panel_PartInfor.Controls.Add(this.txtPartCode);
            this.Panel_PartInfor.Controls.Add(this.label3);
            this.Panel_PartInfor.Controls.Add(this.label2);
            this.Panel_PartInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_PartInfor.Location = new System.Drawing.Point(3, 3);
            this.Panel_PartInfor.Name = "Panel_PartInfor";
            this.Panel_PartInfor.Size = new System.Drawing.Size(504, 328);
            this.Panel_PartInfor.TabIndex = 0;
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartPrice.Location = new System.Drawing.Point(267, 133);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.ReadOnly = true;
            this.txtPartPrice.Size = new System.Drawing.Size(166, 29);
            this.txtPartPrice.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "(VND)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Current Price";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_Download
            // 
            this.Panel_Download.AutoScroll = true;
            this.Panel_Download.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Panel_Download.Controls.Add(this.btnApplyFilter);
            this.Panel_Download.Controls.Add(this.label6);
            this.Panel_Download.Controls.Add(this.checklistTypeFile);
            this.Panel_Download.Controls.Add(this.checklistStage);
            this.Panel_Download.Controls.Add(this.btnDownLoadFile);
            this.Panel_Download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Download.Location = new System.Drawing.Point(3, 337);
            this.Panel_Download.Name = "Panel_Download";
            this.Panel_Download.Size = new System.Drawing.Size(504, 127);
            this.Panel_Download.TabIndex = 0;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(338, 25);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(95, 27);
            this.btnApplyFilter.TabIndex = 8;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // checklistTypeFile
            // 
            this.checklistTypeFile.AllowDrop = true;
            this.checklistTypeFile.FormattingEnabled = true;
            this.checklistTypeFile.Location = new System.Drawing.Point(118, 14);
            this.checklistTypeFile.Name = "checklistTypeFile";
            this.checklistTypeFile.ScrollAlwaysVisible = true;
            this.checklistTypeFile.Size = new System.Drawing.Size(102, 100);
            this.checklistTypeFile.TabIndex = 7;
            // 
            // checklistStage
            // 
            this.checklistStage.AllowDrop = true;
            this.checklistStage.FormattingEnabled = true;
            this.checklistStage.Location = new System.Drawing.Point(8, 14);
            this.checklistStage.Name = "checklistStage";
            this.checklistStage.ScrollAlwaysVisible = true;
            this.checklistStage.Size = new System.Drawing.Size(104, 100);
            this.checklistStage.TabIndex = 7;
            // 
            // PanelDataGridView
            // 
            this.PanelDataGridView.AutoScroll = true;
            this.PanelDataGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelDataGridView.Controls.Add(this.dgvListFile);
            this.PanelDataGridView.Controls.Add(this.txtListFileStatus);
            this.PanelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDataGridView.Location = new System.Drawing.Point(3, 470);
            this.PanelDataGridView.Name = "PanelDataGridView";
            this.PanelDataGridView.Size = new System.Drawing.Size(504, 196);
            this.PanelDataGridView.TabIndex = 0;
            // 
            // frmRelationPart_Detail_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(510, 669);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmRelationPart_Detail_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Component Detail";
            this.Load += new System.EventHandler(this.frmRelationPart_Detail_Info_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelationPart_Detail_Info_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Panel_PartInfor.ResumeLayout(false);
            this.Panel_PartInfor.PerformLayout();
            this.Panel_Download.ResumeLayout(false);
            this.Panel_Download.PerformLayout();
            this.PanelDataGridView.ResumeLayout(false);
            this.PanelDataGridView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox PicPart;
        private System.Windows.Forms.DataGridView dgvListFile;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartDescription;
        private System.Windows.Forms.TextBox txtPartStage;
        private System.Windows.Forms.TextBox txtPartLog;
        private System.Windows.Forms.TextBox txtPicStatus;
        private System.Windows.Forms.TextBox txtListFileStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDownLoadFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel_PartInfor;
        private System.Windows.Forms.Panel Panel_Download;
        private System.Windows.Forms.Panel PanelDataGridView;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checklistStage;
        private System.Windows.Forms.CheckedListBox checklistTypeFile;
        private System.Windows.Forms.Button btnApplyFilter;
    }
}