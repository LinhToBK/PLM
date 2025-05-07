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
            this.groupBoxTypeFile = new System.Windows.Forms.GroupBox();
            this.ckcAll = new System.Windows.Forms.CheckBox();
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
            this.groupBoxOnlyPartChild = new System.Windows.Forms.GroupBox();
            this.radioChildren = new System.Windows.Forms.RadioButton();
            this.radioCurrentPart = new System.Windows.Forms.RadioButton();
            this.labelPartCode = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.dgvListChild = new System.Windows.Forms.DataGridView();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.groupBoxLastestVersion = new System.Windows.Forms.GroupBox();
            this.radioNearestDocument = new System.Windows.Forms.RadioButton();
            this.radioAllDocument = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.labelSaveFolder = new System.Windows.Forms.Label();
            this.txtFolderDownload = new System.Windows.Forms.TextBox();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxListChildPart = new System.Windows.Forms.GroupBox();
            this.groupBoxDownload = new System.Windows.Forms.GroupBox();
            this.groupBoxinfor = new System.Windows.Forms.GroupBox();
            this.txtPartVersion = new System.Windows.Forms.TextBox();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.groupBoxTypeFile.SuspendLayout();
            this.groupBoxOnlyPartChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.groupBoxLastestVersion.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxListChildPart.SuspendLayout();
            this.groupBoxDownload.SuspendLayout();
            this.groupBoxinfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTypeFile
            // 
            this.groupBoxTypeFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBoxTypeFile.Controls.Add(this.ckcAll);
            this.groupBoxTypeFile.Controls.Add(this.label6);
            this.groupBoxTypeFile.Controls.Add(this.label5);
            this.groupBoxTypeFile.Controls.Add(this.label4);
            this.groupBoxTypeFile.Controls.Add(this.label3);
            this.groupBoxTypeFile.Controls.Add(this.label2);
            this.groupBoxTypeFile.Controls.Add(this.ckcJpgFile);
            this.groupBoxTypeFile.Controls.Add(this.ckcDwgFile);
            this.groupBoxTypeFile.Controls.Add(this.ckcPrtFile);
            this.groupBoxTypeFile.Controls.Add(this.ckcPdfFile);
            this.groupBoxTypeFile.Controls.Add(this.ckcStepFile);
            this.groupBoxTypeFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTypeFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTypeFile.Location = new System.Drawing.Point(3, 284);
            this.groupBoxTypeFile.Name = "groupBoxTypeFile";
            this.groupBoxTypeFile.Size = new System.Drawing.Size(575, 103);
            this.groupBoxTypeFile.TabIndex = 1;
            this.groupBoxTypeFile.TabStop = false;
            this.groupBoxTypeFile.Text = "Type of File";
            // 
            // ckcAll
            // 
            this.ckcAll.AutoSize = true;
            this.ckcAll.Location = new System.Drawing.Point(450, 60);
            this.ckcAll.Name = "ckcAll";
            this.ckcAll.Size = new System.Drawing.Size(51, 27);
            this.ckcAll.TabIndex = 2;
            this.ckcAll.Text = "All";
            this.ckcAll.UseVisualStyleBackColor = true;
            this.ckcAll.CheckedChanged += new System.EventHandler(this.ckcAll_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(415, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Image : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(227, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "AutoCad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Solid/NX :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(214, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Document :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "3D CAD :";
            // 
            // ckcJpgFile
            // 
            this.ckcJpgFile.AutoSize = true;
            this.ckcJpgFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcJpgFile.Location = new System.Drawing.Point(493, 29);
            this.ckcJpgFile.Name = "ckcJpgFile";
            this.ckcJpgFile.Size = new System.Drawing.Size(60, 27);
            this.ckcJpgFile.TabIndex = 0;
            this.ckcJpgFile.Text = ".jpg";
            this.ckcJpgFile.UseVisualStyleBackColor = true;
            // 
            // ckcDwgFile
            // 
            this.ckcDwgFile.AutoSize = true;
            this.ckcDwgFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcDwgFile.Location = new System.Drawing.Point(317, 60);
            this.ckcDwgFile.Name = "ckcDwgFile";
            this.ckcDwgFile.Size = new System.Drawing.Size(98, 27);
            this.ckcDwgFile.TabIndex = 0;
            this.ckcDwgFile.Text = ".dwg/dxf";
            this.ckcDwgFile.UseVisualStyleBackColor = true;
            // 
            // ckcPrtFile
            // 
            this.ckcPrtFile.AutoSize = true;
            this.ckcPrtFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcPrtFile.Location = new System.Drawing.Point(100, 60);
            this.ckcPrtFile.Name = "ckcPrtFile";
            this.ckcPrtFile.Size = new System.Drawing.Size(58, 27);
            this.ckcPrtFile.TabIndex = 0;
            this.ckcPrtFile.Text = ".prt";
            this.ckcPrtFile.UseVisualStyleBackColor = true;
            // 
            // ckcPdfFile
            // 
            this.ckcPdfFile.AutoSize = true;
            this.ckcPdfFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcPdfFile.Location = new System.Drawing.Point(317, 29);
            this.ckcPdfFile.Name = "ckcPdfFile";
            this.ckcPdfFile.Size = new System.Drawing.Size(61, 27);
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
            this.ckcStepFile.Location = new System.Drawing.Point(100, 29);
            this.ckcStepFile.Name = "ckcStepFile";
            this.ckcStepFile.Size = new System.Drawing.Size(98, 27);
            this.ckcStepFile.TabIndex = 0;
            this.ckcStepFile.Text = ".stp/step";
            this.ckcStepFile.UseVisualStyleBackColor = true;
            // 
            // groupBoxOnlyPartChild
            // 
            this.groupBoxOnlyPartChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBoxOnlyPartChild.Controls.Add(this.radioChildren);
            this.groupBoxOnlyPartChild.Controls.Add(this.radioCurrentPart);
            this.groupBoxOnlyPartChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOnlyPartChild.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOnlyPartChild.Location = new System.Drawing.Point(3, 393);
            this.groupBoxOnlyPartChild.Name = "groupBoxOnlyPartChild";
            this.groupBoxOnlyPartChild.Size = new System.Drawing.Size(575, 72);
            this.groupBoxOnlyPartChild.TabIndex = 2;
            this.groupBoxOnlyPartChild.TabStop = false;
            this.groupBoxOnlyPartChild.Text = "Download Only Part or with Child Part";
            // 
            // radioChildren
            // 
            this.radioChildren.AutoSize = true;
            this.radioChildren.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioChildren.Location = new System.Drawing.Point(263, 33);
            this.radioChildren.Name = "radioChildren";
            this.radioChildren.Size = new System.Drawing.Size(224, 27);
            this.radioChildren.TabIndex = 0;
            this.radioChildren.TabStop = true;
            this.radioChildren.Text = "Download with Child Part";
            this.radioChildren.UseVisualStyleBackColor = true;
            // 
            // radioCurrentPart
            // 
            this.radioCurrentPart.AutoSize = true;
            this.radioCurrentPart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCurrentPart.Location = new System.Drawing.Point(20, 33);
            this.radioCurrentPart.Name = "radioCurrentPart";
            this.radioCurrentPart.Size = new System.Drawing.Size(101, 27);
            this.radioCurrentPart.TabIndex = 0;
            this.radioCurrentPart.TabStop = true;
            this.radioCurrentPart.Text = "Only Part";
            this.radioCurrentPart.UseVisualStyleBackColor = true;
            // 
            // labelPartCode
            // 
            this.labelPartCode.AutoSize = true;
            this.labelPartCode.Location = new System.Drawing.Point(12, 36);
            this.labelPartCode.Name = "labelPartCode";
            this.labelPartCode.Size = new System.Drawing.Size(80, 23);
            this.labelPartCode.TabIndex = 3;
            this.labelPartCode.Text = "PartCode";
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(12, 77);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(86, 23);
            this.labelPartName.TabIndex = 3;
            this.labelPartName.Text = "PartName";
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListChild.Location = new System.Drawing.Point(3, 25);
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RowHeadersWidth = 51;
            this.dgvListChild.RowTemplate.Height = 23;
            this.dgvListChild.Size = new System.Drawing.Size(569, 122);
            this.dgvListChild.TabIndex = 4;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(107, 33);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(118, 29);
            this.txtPartCode.TabIndex = 5;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(107, 74);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(436, 29);
            this.txtPartName.TabIndex = 5;
            // 
            // groupBoxLastestVersion
            // 
            this.groupBoxLastestVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBoxLastestVersion.Controls.Add(this.radioNearestDocument);
            this.groupBoxLastestVersion.Controls.Add(this.radioAllDocument);
            this.groupBoxLastestVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLastestVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLastestVersion.Location = new System.Drawing.Point(3, 471);
            this.groupBoxLastestVersion.Name = "groupBoxLastestVersion";
            this.groupBoxLastestVersion.Size = new System.Drawing.Size(575, 72);
            this.groupBoxLastestVersion.TabIndex = 6;
            this.groupBoxLastestVersion.TabStop = false;
            this.groupBoxLastestVersion.Text = "Download Near Document";
            // 
            // radioNearestDocument
            // 
            this.radioNearestDocument.AutoSize = true;
            this.radioNearestDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNearestDocument.Location = new System.Drawing.Point(20, 33);
            this.radioNearestDocument.Name = "radioNearestDocument";
            this.radioNearestDocument.Size = new System.Drawing.Size(231, 27);
            this.radioNearestDocument.TabIndex = 0;
            this.radioNearestDocument.TabStop = true;
            this.radioNearestDocument.Text = "Download  Lastest Version";
            this.radioNearestDocument.UseVisualStyleBackColor = true;
            // 
            // radioAllDocument
            // 
            this.radioAllDocument.AutoSize = true;
            this.radioAllDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAllDocument.Location = new System.Drawing.Point(263, 33);
            this.radioAllDocument.Name = "radioAllDocument";
            this.radioAllDocument.Size = new System.Drawing.Size(191, 27);
            this.radioAllDocument.TabIndex = 0;
            this.radioAllDocument.TabStop = true;
            this.radioAllDocument.Text = "Download all Version";
            this.radioAllDocument.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(517, 31);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 29);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(407, 31);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(104, 29);
            this.btnDownLoad.TabIndex = 9;
            this.btnDownLoad.Text = "Download";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // labelSaveFolder
            // 
            this.labelSaveFolder.AutoSize = true;
            this.labelSaveFolder.Location = new System.Drawing.Point(12, 34);
            this.labelSaveFolder.Name = "labelSaveFolder";
            this.labelSaveFolder.Size = new System.Drawing.Size(97, 23);
            this.labelSaveFolder.TabIndex = 3;
            this.labelSaveFolder.Text = "Save Folder";
            // 
            // txtFolderDownload
            // 
            this.txtFolderDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtFolderDownload.Location = new System.Drawing.Point(115, 31);
            this.txtFolderDownload.Name = "txtFolderDownload";
            this.txtFolderDownload.ReadOnly = true;
            this.txtFolderDownload.Size = new System.Drawing.Size(251, 29);
            this.txtFolderDownload.TabIndex = 5;
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(372, 31);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(29, 29);
            this.btnChooseFolder.TabIndex = 10;
            this.btnChooseFolder.Text = "...";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxListChildPart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLastestVersion, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxOnlyPartChild, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxDownload, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTypeFile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxinfor, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(581, 627);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // groupBoxListChildPart
            // 
            this.groupBoxListChildPart.Controls.Add(this.dgvListChild);
            this.groupBoxListChildPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxListChildPart.Location = new System.Drawing.Point(3, 128);
            this.groupBoxListChildPart.Name = "groupBoxListChildPart";
            this.groupBoxListChildPart.Size = new System.Drawing.Size(575, 150);
            this.groupBoxListChildPart.TabIndex = 0;
            this.groupBoxListChildPart.TabStop = false;
            this.groupBoxListChildPart.Text = "List Child Part";
            // 
            // groupBoxDownload
            // 
            this.groupBoxDownload.Controls.Add(this.txtFolderDownload);
            this.groupBoxDownload.Controls.Add(this.btnExit);
            this.groupBoxDownload.Controls.Add(this.btnChooseFolder);
            this.groupBoxDownload.Controls.Add(this.btnDownLoad);
            this.groupBoxDownload.Controls.Add(this.labelSaveFolder);
            this.groupBoxDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDownload.Location = new System.Drawing.Point(3, 549);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(575, 75);
            this.groupBoxDownload.TabIndex = 7;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "Download";
            // 
            // groupBoxinfor
            // 
            this.groupBoxinfor.Controls.Add(this.txtPartVersion);
            this.groupBoxinfor.Controls.Add(this.labelPartName);
            this.groupBoxinfor.Controls.Add(this.txtPartName);
            this.groupBoxinfor.Controls.Add(this.txtPartCode);
            this.groupBoxinfor.Controls.Add(this.labelCurrentVersion);
            this.groupBoxinfor.Controls.Add(this.labelPartCode);
            this.groupBoxinfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxinfor.Location = new System.Drawing.Point(3, 3);
            this.groupBoxinfor.Name = "groupBoxinfor";
            this.groupBoxinfor.Size = new System.Drawing.Size(575, 119);
            this.groupBoxinfor.TabIndex = 8;
            this.groupBoxinfor.TabStop = false;
            this.groupBoxinfor.Text = "Check information before download";
            // 
            // txtPartVersion
            // 
            this.txtPartVersion.Location = new System.Drawing.Point(443, 33);
            this.txtPartVersion.Name = "txtPartVersion";
            this.txtPartVersion.Size = new System.Drawing.Size(100, 29);
            this.txtPartVersion.TabIndex = 6;
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Location = new System.Drawing.Point(286, 36);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(129, 23);
            this.labelCurrentVersion.TabIndex = 3;
            this.labelCurrentVersion.Text = "Current Version";
            // 
            // frmDownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(581, 627);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDownloadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Part";
            this.Load += new System.EventHandler(this.frmDownloadFile_Load);
            this.groupBoxTypeFile.ResumeLayout(false);
            this.groupBoxTypeFile.PerformLayout();
            this.groupBoxOnlyPartChild.ResumeLayout(false);
            this.groupBoxOnlyPartChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.groupBoxLastestVersion.ResumeLayout(false);
            this.groupBoxLastestVersion.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxListChildPart.ResumeLayout(false);
            this.groupBoxDownload.ResumeLayout(false);
            this.groupBoxDownload.PerformLayout();
            this.groupBoxinfor.ResumeLayout(false);
            this.groupBoxinfor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxTypeFile;
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
        private System.Windows.Forms.GroupBox groupBoxOnlyPartChild;
        private System.Windows.Forms.RadioButton radioChildren;
        private System.Windows.Forms.RadioButton radioCurrentPart;
        private System.Windows.Forms.Label labelPartCode;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.DataGridView dgvListChild;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.GroupBox groupBoxLastestVersion;
        private System.Windows.Forms.RadioButton radioNearestDocument;
        private System.Windows.Forms.RadioButton radioAllDocument;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Label labelSaveFolder;
        private System.Windows.Forms.TextBox txtFolderDownload;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxListChildPart;
        private System.Windows.Forms.GroupBox groupBoxDownload;
        private System.Windows.Forms.GroupBox groupBoxinfor;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.TextBox txtPartVersion;
        private System.Windows.Forms.CheckBox ckcAll;
    }
}