namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    partial class frmSolidwork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolidwork));
            this.cboListDrawing = new System.Windows.Forms.ComboBox();
            this.cboListAssemblyFiles = new System.Windows.Forms.ComboBox();
            this.txtDrawingFileStatus = new System.Windows.Forms.TextBox();
            this.btnChangeNameSheets = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportDWG = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAssemblyFileStatus = new System.Windows.Forms.TextBox();
            this.btnDownloadVBA = new System.Windows.Forms.Button();
            this.btnExportStep = new System.Windows.Forms.Button();
            this.btnExportJPG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboListDrawing
            // 
            this.cboListDrawing.FormattingEnabled = true;
            this.cboListDrawing.Location = new System.Drawing.Point(17, 87);
            this.cboListDrawing.Name = "cboListDrawing";
            this.cboListDrawing.Size = new System.Drawing.Size(261, 31);
            this.cboListDrawing.TabIndex = 0;
            // 
            // cboListAssemblyFiles
            // 
            this.cboListAssemblyFiles.FormattingEnabled = true;
            this.cboListAssemblyFiles.Location = new System.Drawing.Point(17, 77);
            this.cboListAssemblyFiles.Name = "cboListAssemblyFiles";
            this.cboListAssemblyFiles.Size = new System.Drawing.Size(261, 31);
            this.cboListAssemblyFiles.TabIndex = 0;
            // 
            // txtDrawingFileStatus
            // 
            this.txtDrawingFileStatus.Location = new System.Drawing.Point(17, 41);
            this.txtDrawingFileStatus.Name = "txtDrawingFileStatus";
            this.txtDrawingFileStatus.ReadOnly = true;
            this.txtDrawingFileStatus.Size = new System.Drawing.Size(261, 30);
            this.txtDrawingFileStatus.TabIndex = 2;
            // 
            // btnChangeNameSheets
            // 
            this.btnChangeNameSheets.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeNameSheets.Image")));
            this.btnChangeNameSheets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeNameSheets.Location = new System.Drawing.Point(17, 134);
            this.btnChangeNameSheets.Name = "btnChangeNameSheets";
            this.btnChangeNameSheets.Size = new System.Drawing.Size(227, 40);
            this.btnChangeNameSheets.TabIndex = 3;
            this.btnChangeNameSheets.Text = "Change name of sheets";
            this.btnChangeNameSheets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeNameSheets.UseVisualStyleBackColor = true;
            this.btnChangeNameSheets.Click += new System.EventHandler(this.btnChangeNameSheets_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(603, 493);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDrawingFileStatus);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.btnExportPDF);
            this.groupBox1.Controls.Add(this.btnExportDWG);
            this.groupBox1.Controls.Add(this.btnChangeNameSheets);
            this.groupBox1.Controls.Add(this.cboListDrawing);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List drawing files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(17, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chú ý : sẽ đổi tên bản vẽ theo tên của  part / subassembly\r\nđược kéo ra đầu tiên " +
    "trong sheet.";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(452, 134);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(309, 134);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(98, 40);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.Image")));
            this.btnExportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPDF.Location = new System.Drawing.Point(331, 82);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(183, 40);
            this.btnExportPDF.TabIndex = 3;
            this.btnExportPDF.Text = "Export .PDF Files";
            this.btnExportPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportDWG
            // 
            this.btnExportDWG.Image = ((System.Drawing.Image)(resources.GetObject("btnExportDWG.Image")));
            this.btnExportDWG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportDWG.Location = new System.Drawing.Point(331, 36);
            this.btnExportDWG.Name = "btnExportDWG";
            this.btnExportDWG.Size = new System.Drawing.Size(183, 40);
            this.btnExportDWG.TabIndex = 3;
            this.btnExportDWG.Text = "Export .DWG Files";
            this.btnExportDWG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportDWG.UseVisualStyleBackColor = true;
            this.btnExportDWG.Click += new System.EventHandler(this.btnExportDWG_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAssemblyFileStatus);
            this.groupBox2.Controls.Add(this.btnDownloadVBA);
            this.groupBox2.Controls.Add(this.btnExportStep);
            this.groupBox2.Controls.Add(this.btnExportJPG);
            this.groupBox2.Controls.Add(this.cboListAssemblyFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List assembly file";
            // 
            // txtAssemblyFileStatus
            // 
            this.txtAssemblyFileStatus.Location = new System.Drawing.Point(17, 29);
            this.txtAssemblyFileStatus.Name = "txtAssemblyFileStatus";
            this.txtAssemblyFileStatus.Size = new System.Drawing.Size(261, 30);
            this.txtAssemblyFileStatus.TabIndex = 1;
            // 
            // btnDownloadVBA
            // 
            this.btnDownloadVBA.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadVBA.Image")));
            this.btnDownloadVBA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadVBA.Location = new System.Drawing.Point(17, 126);
            this.btnDownloadVBA.Name = "btnDownloadVBA";
            this.btnDownloadVBA.Size = new System.Drawing.Size(425, 40);
            this.btnDownloadVBA.TabIndex = 3;
            this.btnDownloadVBA.Text = "Download Code Excel to Convert BOM => Partlist";
            this.btnDownloadVBA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadVBA.UseVisualStyleBackColor = true;
            this.btnDownloadVBA.Click += new System.EventHandler(this.btnDownloadVBA_Click);
            // 
            // btnExportStep
            // 
            this.btnExportStep.Image = ((System.Drawing.Image)(resources.GetObject("btnExportStep.Image")));
            this.btnExportStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportStep.Location = new System.Drawing.Point(331, 72);
            this.btnExportStep.Name = "btnExportStep";
            this.btnExportStep.Size = new System.Drawing.Size(183, 40);
            this.btnExportStep.TabIndex = 3;
            this.btnExportStep.Text = "Export .STEP Files";
            this.btnExportStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportStep.UseVisualStyleBackColor = true;
            this.btnExportStep.Click += new System.EventHandler(this.btnExportStep_Click);
            // 
            // btnExportJPG
            // 
            this.btnExportJPG.Image = ((System.Drawing.Image)(resources.GetObject("btnExportJPG.Image")));
            this.btnExportJPG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportJPG.Location = new System.Drawing.Point(331, 24);
            this.btnExportJPG.Name = "btnExportJPG";
            this.btnExportJPG.Size = new System.Drawing.Size(183, 40);
            this.btnExportJPG.TabIndex = 3;
            this.btnExportJPG.Text = "Export .JPG Files";
            this.btnExportJPG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportJPG.UseVisualStyleBackColor = true;
            this.btnExportJPG.Click += new System.EventHandler(this.btnExportJPG_Click);
            // 
            // frmSolidwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 493);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSolidwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solidwork";
            this.Load += new System.EventHandler(this.frmSolidwork_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboListDrawing;
        private System.Windows.Forms.ComboBox cboListAssemblyFiles;
        private System.Windows.Forms.TextBox txtDrawingFileStatus;
        private System.Windows.Forms.Button btnChangeNameSheets;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportDWG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAssemblyFileStatus;
        private System.Windows.Forms.Button btnExportStep;
        private System.Windows.Forms.Button btnExportJPG;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownloadVBA;
        private System.Windows.Forms.Label label1;
    }
}