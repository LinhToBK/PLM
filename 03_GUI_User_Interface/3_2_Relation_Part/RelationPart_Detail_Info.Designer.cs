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
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Part Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Stage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Part Log";
            // 
            // PicPart
            // 
            this.PicPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicPart.Location = new System.Drawing.Point(344, 32);
            this.PicPart.Name = "PicPart";
            this.PicPart.Size = new System.Drawing.Size(176, 126);
            this.PicPart.TabIndex = 1;
            this.PicPart.TabStop = false;
            // 
            // dgvListFile
            // 
            this.dgvListFile.AllowUserToAddRows = false;
            this.dgvListFile.AllowUserToDeleteRows = false;
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListFile.Location = new System.Drawing.Point(0, 389);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.ReadOnly = true;
            this.dgvListFile.Size = new System.Drawing.Size(532, 152);
            this.dgvListFile.TabIndex = 2;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(125, 32);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(100, 25);
            this.txtPartCode.TabIndex = 3;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(125, 62);
            this.txtPartName.Multiline = true;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(213, 63);
            this.txtPartName.TabIndex = 3;
            // 
            // txtPartDescription
            // 
            this.txtPartDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPartDescription.Location = new System.Drawing.Point(123, 164);
            this.txtPartDescription.Multiline = true;
            this.txtPartDescription.Name = "txtPartDescription";
            this.txtPartDescription.ReadOnly = true;
            this.txtPartDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartDescription.Size = new System.Drawing.Size(397, 81);
            this.txtPartDescription.TabIndex = 3;
            // 
            // txtPartStage
            // 
            this.txtPartStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartStage.Location = new System.Drawing.Point(125, 133);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(100, 25);
            this.txtPartStage.TabIndex = 3;
            // 
            // txtPartLog
            // 
            this.txtPartLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPartLog.Location = new System.Drawing.Point(123, 253);
            this.txtPartLog.Multiline = true;
            this.txtPartLog.Name = "txtPartLog";
            this.txtPartLog.ReadOnly = true;
            this.txtPartLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartLog.Size = new System.Drawing.Size(397, 104);
            this.txtPartLog.TabIndex = 3;
            // 
            // txtPicStatus
            // 
            this.txtPicStatus.Location = new System.Drawing.Point(231, 32);
            this.txtPicStatus.Name = "txtPicStatus";
            this.txtPicStatus.ReadOnly = true;
            this.txtPicStatus.Size = new System.Drawing.Size(107, 25);
            this.txtPicStatus.TabIndex = 3;
            this.txtPicStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtListFileStatus
            // 
            this.txtListFileStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtListFileStatus.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListFileStatus.Location = new System.Drawing.Point(6, 318);
            this.txtListFileStatus.Multiline = true;
            this.txtListFileStatus.Name = "txtListFileStatus";
            this.txtListFileStatus.ReadOnly = true;
            this.txtListFileStatus.Size = new System.Drawing.Size(111, 38);
            this.txtListFileStatus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(27, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Có thể nhấn \"Esc\" để thoát khỏi form này ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownLoadFile
            // 
            this.btnDownLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDownLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDownLoadFile.Image")));
            this.btnDownLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownLoadFile.Location = new System.Drawing.Point(6, 286);
            this.btnDownLoadFile.Name = "btnDownLoadFile";
            this.btnDownLoadFile.Size = new System.Drawing.Size(111, 26);
            this.btnDownLoadFile.TabIndex = 6;
            this.btnDownLoadFile.Text = "DownLoad File";
            this.btnDownLoadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownLoadFile.UseVisualStyleBackColor = false;
            this.btnDownLoadFile.Click += new System.EventHandler(this.btnDownLoadFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(3, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(429, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Để Download File thì cần chọn hàng cần download. Giữ Ctrl để chọn nhiều hàng";
            // 
            // frmRelationPart_Detail_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(532, 541);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDownLoadFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtListFileStatus);
            this.Controls.Add(this.txtPartLog);
            this.Controls.Add(this.txtPartStage);
            this.Controls.Add(this.txtPartDescription);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.txtPicStatus);
            this.Controls.Add(this.txtPartCode);
            this.Controls.Add(this.dgvListFile);
            this.Controls.Add(this.PicPart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmRelationPart_Detail_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Component Detail";
            this.Load += new System.EventHandler(this.frmRelationPart_Detail_Info_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelationPart_Detail_Info_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}