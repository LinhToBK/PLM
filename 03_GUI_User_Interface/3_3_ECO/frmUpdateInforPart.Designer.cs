namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    partial class frmUpdateInforPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateInforPart));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtListFileStatus = new System.Windows.Forms.TextBox();
            this.cboNewStage = new System.Windows.Forms.ComboBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.txtPartDescript = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.dgvListFile = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtPartLog = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddNewFile = new System.Windows.Forms.Button();
            this.dgvListUpload = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNoteMore = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.txtNoteMore);
            this.splitContainer1.Panel1.Controls.Add(this.txtListFileStatus);
            this.splitContainer1.Panel1.Controls.Add(this.cboNewStage);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartStage);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartDescript);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartName);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartCode);
            this.splitContainer1.Panel1.Controls.Add(this.dgvListFile);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 586);
            this.splitContainer1.SplitterDistance = 544;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtListFileStatus
            // 
            this.txtListFileStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtListFileStatus.Location = new System.Drawing.Point(212, 303);
            this.txtListFileStatus.Name = "txtListFileStatus";
            this.txtListFileStatus.ReadOnly = true;
            this.txtListFileStatus.Size = new System.Drawing.Size(288, 19);
            this.txtListFileStatus.TabIndex = 4;
            // 
            // cboNewStage
            // 
            this.cboNewStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboNewStage.FormattingEnabled = true;
            this.cboNewStage.Items.AddRange(new object[] {
            "DV",
            "PV",
            "MP"});
            this.cboNewStage.Location = new System.Drawing.Point(406, 180);
            this.cboNewStage.Margin = new System.Windows.Forms.Padding(4);
            this.cboNewStage.Name = "cboNewStage";
            this.cboNewStage.Size = new System.Drawing.Size(58, 27);
            this.cboNewStage.TabIndex = 3;
            // 
            // txtPartStage
            // 
            this.txtPartStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPartStage.Location = new System.Drawing.Point(104, 180);
            this.txtPartStage.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(58, 26);
            this.txtPartStage.TabIndex = 2;
            // 
            // txtPartDescript
            // 
            this.txtPartDescript.BackColor = System.Drawing.SystemColors.Info;
            this.txtPartDescript.Location = new System.Drawing.Point(152, 104);
            this.txtPartDescript.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartDescript.Multiline = true;
            this.txtPartDescript.Name = "txtPartDescript";
            this.txtPartDescript.Size = new System.Drawing.Size(358, 67);
            this.txtPartDescript.TabIndex = 2;
            // 
            // txtPartName
            // 
            this.txtPartName.BackColor = System.Drawing.SystemColors.Info;
            this.txtPartName.Location = new System.Drawing.Point(104, 65);
            this.txtPartName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(406, 26);
            this.txtPartName.TabIndex = 1;
            // 
            // txtPartCode
            // 
            this.txtPartCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartCode.Location = new System.Drawing.Point(104, 33);
            this.txtPartCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(127, 26);
            this.txtPartCode.TabIndex = 2;
            // 
            // dgvListFile
            // 
            this.dgvListFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Location = new System.Drawing.Point(0, 343);
            this.dgvListFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.Size = new System.Drawing.Size(544, 220);
            this.dgvListFile.TabIndex = 1;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(278, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Hướng dẫn ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông tin hiện tại của Part";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Update New Stage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 306);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Danh sách file trong code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Part Stage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 76);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Descript\r\n( Nên ghi vật liệu,\r\nkích thước bao,\r\nỨng dụng để làm gì )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Name";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer2.Panel1.Controls.Add(this.txtPartLog);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteFile);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddNewFile);
            this.splitContainer2.Panel1.Controls.Add(this.dgvListUpload);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExit);
            this.splitContainer2.Panel2.Controls.Add(this.btnUpload);
            this.splitContainer2.Size = new System.Drawing.Size(513, 586);
            this.splitContainer2.SplitterDistance = 494;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtPartLog
            // 
            this.txtPartLog.Location = new System.Drawing.Point(77, 16);
            this.txtPartLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartLog.Multiline = true;
            this.txtPartLog.Name = "txtPartLog";
            this.txtPartLog.ReadOnly = true;
            this.txtPartLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartLog.Size = new System.Drawing.Size(423, 115);
            this.txtPartLog.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(251, 219);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 30);
            this.label11.TabIndex = 2;
            this.label11.Text = "1. Có thể kéo thả vào vùng upload file\r\n2. Chọn 1 dòng thì mới nhấn được \"Delete " +
    "File\"";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 228);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Danh sách file updaload lên DataBase";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Part Log";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFile.Location = new System.Drawing.Point(267, 179);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(103, 34);
            this.btnDeleteFile.TabIndex = 1;
            this.btnDeleteFile.Text = "&Delete File";
            this.btnDeleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddNewFile
            // 
            this.btnAddNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewFile.Image")));
            this.btnAddNewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewFile.Location = new System.Drawing.Point(77, 179);
            this.btnAddNewFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddNewFile.Name = "btnAddNewFile";
            this.btnAddNewFile.Size = new System.Drawing.Size(93, 34);
            this.btnAddNewFile.TabIndex = 1;
            this.btnAddNewFile.Text = "&Add File";
            this.btnAddNewFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewFile.UseVisualStyleBackColor = true;
            this.btnAddNewFile.Click += new System.EventHandler(this.btnAddNewFile_Click);
            // 
            // dgvListUpload
            // 
            this.dgvListUpload.AllowDrop = true;
            this.dgvListUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListUpload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListUpload.Location = new System.Drawing.Point(0, 259);
            this.dgvListUpload.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvListUpload.Name = "dgvListUpload";
            this.dgvListUpload.Size = new System.Drawing.Size(513, 235);
            this.dgvListUpload.TabIndex = 0;
            this.dgvListUpload.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvListUpload_DragDrop);
            this.dgvListUpload.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvListUpload_DragEnter);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(318, 18);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 34);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(54, 18);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(164, 34);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload to DataBase";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 253);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Note More";
            // 
            // txtNoteMore
            // 
            this.txtNoteMore.Location = new System.Drawing.Point(104, 228);
            this.txtNoteMore.Multiline = true;
            this.txtNoteMore.Name = "txtNoteMore";
            this.txtNoteMore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNoteMore.Size = new System.Drawing.Size(406, 69);
            this.txtNoteMore.TabIndex = 5;
            // 
            // frmUpdateInforPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 586);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmUpdateInforPart";
            this.Text = "Update Infor Part";
            this.Load += new System.EventHandler(this.frmUpdateInforPart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUpload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvListFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNewStage;
        private System.Windows.Forms.TextBox txtPartStage;
        private System.Windows.Forms.TextBox txtPartDescript;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddNewFile;
        private System.Windows.Forms.DataGridView dgvListUpload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtPartLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtListFileStatus;
        private System.Windows.Forms.TextBox txtNoteMore;
        private System.Windows.Forms.Label label12;
    }
}