namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmUpdateStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateStatus));
            this.labeNo = new System.Windows.Forms.Label();
            this.labelCurrentStatus = new System.Windows.Forms.Label();
            this.labelUpdateStatus = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPOCode = new System.Windows.Forms.TextBox();
            this.txtPOStatus = new System.Windows.Forms.TextBox();
            this.cboNewStatus = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtListFile = new System.Windows.Forms.TextBox();
            this.buttonDownloadFile = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxAddFile = new System.Windows.Forms.GroupBox();
            this.dgvNewFile = new Zuby.ADGV.AdvancedDataGridView();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.groupBoxCurrentListFiel = new System.Windows.Forms.GroupBox();
            this.dgvListFile = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxAddFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewFile)).BeginInit();
            this.groupBoxCurrentListFiel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.SuspendLayout();
            // 
            // labeNo
            // 
            this.labeNo.AutoSize = true;
            this.labeNo.Location = new System.Drawing.Point(21, 18);
            this.labeNo.Name = "labeNo";
            this.labeNo.Size = new System.Drawing.Size(61, 23);
            this.labeNo.TabIndex = 0;
            this.labeNo.Text = "PO No";
            // 
            // labelCurrentStatus
            // 
            this.labelCurrentStatus.AutoSize = true;
            this.labelCurrentStatus.Location = new System.Drawing.Point(21, 132);
            this.labelCurrentStatus.Name = "labelCurrentStatus";
            this.labelCurrentStatus.Size = new System.Drawing.Size(119, 23);
            this.labelCurrentStatus.TabIndex = 0;
            this.labelCurrentStatus.Text = "Current Status";
            // 
            // labelUpdateStatus
            // 
            this.labelUpdateStatus.AutoSize = true;
            this.labelUpdateStatus.Location = new System.Drawing.Point(21, 189);
            this.labelUpdateStatus.Name = "labelUpdateStatus";
            this.labelUpdateStatus.Size = new System.Drawing.Size(117, 23);
            this.labelUpdateStatus.TabIndex = 0;
            this.labelUpdateStatus.Text = "Update Status";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(25, 241);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 45);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(231, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPOCode
            // 
            this.txtPOCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtPOCode.Location = new System.Drawing.Point(158, 14);
            this.txtPOCode.Name = "txtPOCode";
            this.txtPOCode.Size = new System.Drawing.Size(176, 30);
            this.txtPOCode.TabIndex = 2;
            // 
            // txtPOStatus
            // 
            this.txtPOStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtPOStatus.Location = new System.Drawing.Point(158, 128);
            this.txtPOStatus.Name = "txtPOStatus";
            this.txtPOStatus.Size = new System.Drawing.Size(176, 30);
            this.txtPOStatus.TabIndex = 2;
            // 
            // cboNewStatus
            // 
            this.cboNewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboNewStatus.FormattingEnabled = true;
            this.cboNewStatus.Items.AddRange(new object[] {
            "Created",
            "Purchased",
            "Canceled",
            "Payment"});
            this.cboNewStatus.Location = new System.Drawing.Point(158, 185);
            this.cboNewStatus.Name = "cboNewStatus";
            this.cboNewStatus.Size = new System.Drawing.Size(176, 31);
            this.cboNewStatus.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(21, 75);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(74, 23);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "PO Date";
            // 
            // txtPODate
            // 
            this.txtPODate.BackColor = System.Drawing.SystemColors.Info;
            this.txtPODate.Location = new System.Drawing.Point(158, 71);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.Size = new System.Drawing.Size(176, 30);
            this.txtPODate.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtListFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDownloadFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtPODate);
            this.splitContainer1.Panel1.Controls.Add(this.txtPOStatus);
            this.splitContainer1.Panel1.Controls.Add(this.txtPOCode);
            this.splitContainer1.Panel1.Controls.Add(this.labelDate);
            this.splitContainer1.Panel1.Controls.Add(this.cboNewStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labeNo);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.labelUpdateStatus);
            this.splitContainer1.Panel1.Controls.Add(this.labelCurrentStatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(767, 535);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 4;
            // 
            // txtListFile
            // 
            this.txtListFile.Location = new System.Drawing.Point(25, 305);
            this.txtListFile.Name = "txtListFile";
            this.txtListFile.ReadOnly = true;
            this.txtListFile.Size = new System.Drawing.Size(309, 30);
            this.txtListFile.TabIndex = 4;
            // 
            // buttonDownloadFile
            // 
            this.buttonDownloadFile.AutoSize = true;
            this.buttonDownloadFile.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownloadFile.Image")));
            this.buttonDownloadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDownloadFile.Location = new System.Drawing.Point(102, 361);
            this.buttonDownloadFile.Name = "buttonDownloadFile";
            this.buttonDownloadFile.Size = new System.Drawing.Size(155, 45);
            this.buttonDownloadFile.TabIndex = 0;
            this.buttonDownloadFile.Text = "Download File";
            this.buttonDownloadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDownloadFile.UseVisualStyleBackColor = true;
            this.buttonDownloadFile.Click += new System.EventHandler(this.buttonDownloadFile_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxAddFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxCurrentListFiel);
            this.splitContainer2.Size = new System.Drawing.Size(403, 535);
            this.splitContainer2.SplitterDistance = 266;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxAddFile
            // 
            this.groupBoxAddFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxAddFile.Controls.Add(this.dgvNewFile);
            this.groupBoxAddFile.Controls.Add(this.btnDeleteFile);
            this.groupBoxAddFile.Controls.Add(this.btnAddFile);
            this.groupBoxAddFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAddFile.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAddFile.Name = "groupBoxAddFile";
            this.groupBoxAddFile.Size = new System.Drawing.Size(403, 266);
            this.groupBoxAddFile.TabIndex = 0;
            this.groupBoxAddFile.TabStop = false;
            this.groupBoxAddFile.Text = "Add file in update status";
            // 
            // dgvNewFile
            // 
            this.dgvNewFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNewFile.FilterAndSortEnabled = true;
            this.dgvNewFile.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvNewFile.Location = new System.Drawing.Point(3, 94);
            this.dgvNewFile.MaxFilterButtonImageHeight = 23;
            this.dgvNewFile.Name = "dgvNewFile";
            this.dgvNewFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvNewFile.RowHeadersWidth = 51;
            this.dgvNewFile.RowTemplate.Height = 24;
            this.dgvNewFile.Size = new System.Drawing.Size(397, 169);
            this.dgvNewFile.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvNewFile.TabIndex = 1;
            this.dgvNewFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewFile_CellDoubleClick);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.AutoSize = true;
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFile.Location = new System.Drawing.Point(179, 29);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(122, 45);
            this.btnDeleteFile.TabIndex = 0;
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.AutoSize = true;
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFile.Location = new System.Drawing.Point(32, 29);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(115, 45);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // groupBoxCurrentListFiel
            // 
            this.groupBoxCurrentListFiel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBoxCurrentListFiel.Controls.Add(this.dgvListFile);
            this.groupBoxCurrentListFiel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCurrentListFiel.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCurrentListFiel.Name = "groupBoxCurrentListFiel";
            this.groupBoxCurrentListFiel.Size = new System.Drawing.Size(403, 265);
            this.groupBoxCurrentListFiel.TabIndex = 0;
            this.groupBoxCurrentListFiel.TabStop = false;
            this.groupBoxCurrentListFiel.Text = "List files currently";
            // 
            // dgvListFile
            // 
            this.dgvListFile.AllowUserToAddRows = false;
            this.dgvListFile.AllowUserToDeleteRows = false;
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListFile.FilterAndSortEnabled = true;
            this.dgvListFile.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListFile.Location = new System.Drawing.Point(3, 26);
            this.dgvListFile.MaxFilterButtonImageHeight = 23;
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListFile.RowHeadersWidth = 51;
            this.dgvListFile.RowTemplate.Height = 24;
            this.dgvListFile.Size = new System.Drawing.Size(397, 236);
            this.dgvListFile.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListFile.TabIndex = 0;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // frmUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 535);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUpdateStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Status of PO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateStatus_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateStatus_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxAddFile.ResumeLayout(false);
            this.groupBoxAddFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewFile)).EndInit();
            this.groupBoxCurrentListFiel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labeNo;
        private System.Windows.Forms.Label labelCurrentStatus;
        private System.Windows.Forms.Label labelUpdateStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPOCode;
        private System.Windows.Forms.TextBox txtPOStatus;
        private System.Windows.Forms.ComboBox cboNewStatus;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox txtPODate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxAddFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.GroupBox groupBoxCurrentListFiel;
        private System.Windows.Forms.Button buttonDownloadFile;
        private Zuby.ADGV.AdvancedDataGridView dgvNewFile;
        private Zuby.ADGV.AdvancedDataGridView dgvListFile;
        private System.Windows.Forms.TextBox txtListFile;
    }
}