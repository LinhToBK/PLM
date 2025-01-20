namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    partial class frmDownloadFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckcJpgFile = new System.Windows.Forms.CheckBox();
            this.ckcDwgFile = new System.Windows.Forms.CheckBox();
            this.ckcPrtFile = new System.Windows.Forms.CheckBox();
            this.ckcPdfFile = new System.Windows.Forms.CheckBox();
            this.ckcStepFile = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioChildren = new System.Windows.Forms.RadioButton();
            this.radioCurrentPart = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvListChild = new System.Windows.Forms.DataGridView();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioNearestDocument = new System.Windows.Forms.RadioButton();
            this.radioAllDocument = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckcMP = new System.Windows.Forms.CheckBox();
            this.ckcPV = new System.Windows.Forms.CheckBox();
            this.ckcDV = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFolderDownload = new System.Windows.Forms.TextBox();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check information before download\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckcJpgFile);
            this.groupBox1.Controls.Add(this.ckcDwgFile);
            this.groupBox1.Controls.Add(this.ckcPrtFile);
            this.groupBox1.Controls.Add(this.ckcPdfFile);
            this.groupBox1.Controls.Add(this.ckcStepFile);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type of File";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(289, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "AutoCad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(186, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Siemen NX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "DOC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "3D CAD";
            // 
            // ckcJpgFile
            // 
            this.ckcJpgFile.AutoSize = true;
            this.ckcJpgFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcJpgFile.Location = new System.Drawing.Point(392, 41);
            this.ckcJpgFile.Name = "ckcJpgFile";
            this.ckcJpgFile.Size = new System.Drawing.Size(49, 21);
            this.ckcJpgFile.TabIndex = 0;
            this.ckcJpgFile.Text = ".jpg";
            this.ckcJpgFile.UseVisualStyleBackColor = true;
            // 
            // ckcDwgFile
            // 
            this.ckcDwgFile.AutoSize = true;
            this.ckcDwgFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcDwgFile.Location = new System.Drawing.Point(289, 41);
            this.ckcDwgFile.Name = "ckcDwgFile";
            this.ckcDwgFile.Size = new System.Drawing.Size(78, 21);
            this.ckcDwgFile.TabIndex = 0;
            this.ckcDwgFile.Text = ".dwg/dxf";
            this.ckcDwgFile.UseVisualStyleBackColor = true;
            // 
            // ckcPrtFile
            // 
            this.ckcPrtFile.AutoSize = true;
            this.ckcPrtFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcPrtFile.Location = new System.Drawing.Point(186, 41);
            this.ckcPrtFile.Name = "ckcPrtFile";
            this.ckcPrtFile.Size = new System.Drawing.Size(47, 21);
            this.ckcPrtFile.TabIndex = 0;
            this.ckcPrtFile.Text = ".prt";
            this.ckcPrtFile.UseVisualStyleBackColor = true;
            // 
            // ckcPdfFile
            // 
            this.ckcPdfFile.AutoSize = true;
            this.ckcPdfFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcPdfFile.Location = new System.Drawing.Point(107, 41);
            this.ckcPdfFile.Name = "ckcPdfFile";
            this.ckcPdfFile.Size = new System.Drawing.Size(50, 21);
            this.ckcPdfFile.TabIndex = 0;
            this.ckcPdfFile.Text = ".pdf";
            this.ckcPdfFile.UseVisualStyleBackColor = true;
            // 
            // ckcStepFile
            // 
            this.ckcStepFile.AutoSize = true;
            this.ckcStepFile.Checked = true;
            this.ckcStepFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckcStepFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcStepFile.Location = new System.Drawing.Point(12, 41);
            this.ckcStepFile.Name = "ckcStepFile";
            this.ckcStepFile.Size = new System.Drawing.Size(78, 21);
            this.ckcStepFile.TabIndex = 0;
            this.ckcStepFile.Text = ".stp/step";
            this.ckcStepFile.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.radioChildren);
            this.groupBox2.Controls.Add(this.radioCurrentPart);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 58);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download All Child or Only Part";
            // 
            // radioChildren
            // 
            this.radioChildren.AutoSize = true;
            this.radioChildren.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioChildren.Location = new System.Drawing.Point(213, 23);
            this.radioChildren.Name = "radioChildren";
            this.radioChildren.Size = new System.Drawing.Size(191, 21);
            this.radioChildren.TabIndex = 0;
            this.radioChildren.TabStop = true;
            this.radioChildren.Text = "Download with Part Children";
            this.radioChildren.UseVisualStyleBackColor = true;
            // 
            // radioCurrentPart
            // 
            this.radioCurrentPart.AutoSize = true;
            this.radioCurrentPart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCurrentPart.Location = new System.Drawing.Point(12, 23);
            this.radioCurrentPart.Name = "radioCurrentPart";
            this.radioCurrentPart.Size = new System.Drawing.Size(159, 21);
            this.radioCurrentPart.TabIndex = 0;
            this.radioCurrentPart.TabStop = true;
            this.radioCurrentPart.Text = "Download Current Part";
            this.radioCurrentPart.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "PartCode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "PartName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "List Children Part";
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Location = new System.Drawing.Point(12, 118);
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RowTemplate.Height = 23;
            this.dgvListChild.Size = new System.Drawing.Size(461, 129);
            this.dgvListChild.TabIndex = 4;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(80, 31);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(89, 25);
            this.txtPartCode.TabIndex = 5;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(80, 64);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(393, 25);
            this.txtPartName.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.radioNearestDocument);
            this.groupBox3.Controls.Add(this.radioAllDocument);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 62);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Download Near Document";
            // 
            // radioNearestDocument
            // 
            this.radioNearestDocument.AutoSize = true;
            this.radioNearestDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNearestDocument.Location = new System.Drawing.Point(12, 25);
            this.radioNearestDocument.Name = "radioNearestDocument";
            this.radioNearestDocument.Size = new System.Drawing.Size(180, 21);
            this.radioNearestDocument.TabIndex = 0;
            this.radioNearestDocument.TabStop = true;
            this.radioNearestDocument.Text = "Download  Lastest Version";
            this.radioNearestDocument.UseVisualStyleBackColor = true;
            // 
            // radioAllDocument
            // 
            this.radioAllDocument.AutoSize = true;
            this.radioAllDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAllDocument.Location = new System.Drawing.Point(213, 25);
            this.radioAllDocument.Name = "radioAllDocument";
            this.radioAllDocument.Size = new System.Drawing.Size(149, 21);
            this.radioAllDocument.TabIndex = 0;
            this.radioAllDocument.TabStop = true;
            this.radioAllDocument.Text = "Download all Version";
            this.radioAllDocument.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox4.Controls.Add(this.ckcMP);
            this.groupBox4.Controls.Add(this.ckcPV);
            this.groupBox4.Controls.Add(this.ckcDV);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 464);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(488, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stage";
            // 
            // ckcMP
            // 
            this.ckcMP.AutoSize = true;
            this.ckcMP.Location = new System.Drawing.Point(159, 24);
            this.ckcMP.Name = "ckcMP";
            this.ckcMP.Size = new System.Drawing.Size(47, 21);
            this.ckcMP.TabIndex = 0;
            this.ckcMP.Text = "MP";
            this.ckcMP.UseVisualStyleBackColor = true;
            // 
            // ckcPV
            // 
            this.ckcPV.AutoSize = true;
            this.ckcPV.Location = new System.Drawing.Point(86, 24);
            this.ckcPV.Name = "ckcPV";
            this.ckcPV.Size = new System.Drawing.Size(43, 21);
            this.ckcPV.TabIndex = 0;
            this.ckcPV.Text = "PV";
            this.ckcPV.UseVisualStyleBackColor = true;
            // 
            // ckcDV
            // 
            this.ckcDV.AutoSize = true;
            this.ckcDV.Checked = true;
            this.ckcDV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckcDV.Location = new System.Drawing.Point(12, 24);
            this.ckcDV.Name = "ckcDV";
            this.ckcDV.Size = new System.Drawing.Size(44, 21);
            this.ckcDV.TabIndex = 0;
            this.ckcDV.Text = "DV";
            this.ckcDV.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(267, 535);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 38);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(98, 535);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(125, 38);
            this.btnDownLoad.TabIndex = 9;
            this.btnDownLoad.Text = "Download";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Save Folder";
            // 
            // txtFolderDownload
            // 
            this.txtFolderDownload.Location = new System.Drawing.Point(251, 31);
            this.txtFolderDownload.Name = "txtFolderDownload";
            this.txtFolderDownload.Size = new System.Drawing.Size(186, 25);
            this.txtFolderDownload.TabIndex = 5;
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(443, 32);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(29, 23);
            this.btnChooseFolder.TabIndex = 10;
            this.btnChooseFolder.Text = "...";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // frmDownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(500, 587);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.txtFolderDownload);
            this.Controls.Add(this.txtPartCode);
            this.Controls.Add(this.dgvListChild);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDownloadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDownloadFile";
            this.Load += new System.EventHandler(this.frmDownloadFile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckcDwgFile;
        private System.Windows.Forms.CheckBox ckcPrtFile;
        private System.Windows.Forms.CheckBox ckcPdfFile;
        private System.Windows.Forms.CheckBox ckcStepFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckcJpgFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioChildren;
        private System.Windows.Forms.RadioButton radioCurrentPart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvListChild;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioNearestDocument;
        private System.Windows.Forms.RadioButton radioAllDocument;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckcMP;
        private System.Windows.Forms.CheckBox ckcPV;
        private System.Windows.Forms.CheckBox ckcDV;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFolderDownload;
        private System.Windows.Forms.Button btnChooseFolder;
    }
}