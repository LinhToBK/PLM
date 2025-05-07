namespace PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part
{
    partial class frmECO_Infor_Detail
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
            this.labelECONo = new System.Windows.Forms.Label();
            this.labelECODate = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelRequester = new System.Windows.Forms.Label();
            this.labelApprover = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.dgvECOContent = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtApprover = new System.Windows.Forms.TextBox();
            this.txtECOType = new System.Windows.Forms.TextBox();
            this.txtECOStatus = new System.Windows.Forms.TextBox();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.txtECOLog = new System.Windows.Forms.TextBox();
            this.txtECODate = new System.Windows.Forms.TextBox();
            this.txtECONo = new System.Windows.Forms.TextBox();
            this.dgvECOListFile = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOContent)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOListFile)).BeginInit();
            this.SuspendLayout();
            // 
            // labelECONo
            // 
            this.labelECONo.AutoSize = true;
            this.labelECONo.Location = new System.Drawing.Point(16, 18);
            this.labelECONo.Name = "labelECONo";
            this.labelECONo.Size = new System.Drawing.Size(71, 23);
            this.labelECONo.TabIndex = 0;
            this.labelECONo.Text = "ECO No";
            // 
            // labelECODate
            // 
            this.labelECODate.AutoSize = true;
            this.labelECODate.Location = new System.Drawing.Point(16, 74);
            this.labelECODate.Name = "labelECODate";
            this.labelECODate.Size = new System.Drawing.Size(84, 23);
            this.labelECODate.TabIndex = 0;
            this.labelECODate.Text = "ECO Date";
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(307, 18);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(76, 23);
            this.labelLog.TabIndex = 0;
            this.labelLog.Text = "ECO Log";
            // 
            // labelRequester
            // 
            this.labelRequester.AutoSize = true;
            this.labelRequester.Location = new System.Drawing.Point(16, 130);
            this.labelRequester.Name = "labelRequester";
            this.labelRequester.Size = new System.Drawing.Size(86, 23);
            this.labelRequester.TabIndex = 0;
            this.labelRequester.Text = "Requester";
            // 
            // labelApprover
            // 
            this.labelApprover.AutoSize = true;
            this.labelApprover.Location = new System.Drawing.Point(16, 186);
            this.labelApprover.Name = "labelApprover";
            this.labelApprover.Size = new System.Drawing.Size(80, 23);
            this.labelApprover.TabIndex = 0;
            this.labelApprover.Text = "Approver";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(307, 130);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(94, 23);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "ECO Status";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(307, 186);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(83, 23);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "ECO Type";
            // 
            // dgvECOContent
            // 
            this.dgvECOContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECOContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvECOContent.FilterAndSortEnabled = true;
            this.dgvECOContent.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECOContent.Location = new System.Drawing.Point(3, 244);
            this.dgvECOContent.MaxFilterButtonImageHeight = 23;
            this.dgvECOContent.Name = "dgvECOContent";
            this.dgvECOContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvECOContent.RowHeadersWidth = 51;
            this.dgvECOContent.RowTemplate.Height = 24;
            this.dgvECOContent.Size = new System.Drawing.Size(668, 175);
            this.dgvECOContent.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECOContent.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvECOContent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvECOListFile, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 604);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.txtApprover);
            this.panel1.Controls.Add(this.txtECOType);
            this.panel1.Controls.Add(this.txtECOStatus);
            this.panel1.Controls.Add(this.txtRequester);
            this.panel1.Controls.Add(this.txtECOLog);
            this.panel1.Controls.Add(this.txtECODate);
            this.panel1.Controls.Add(this.txtECONo);
            this.panel1.Controls.Add(this.labelApprover);
            this.panel1.Controls.Add(this.labelECONo);
            this.panel1.Controls.Add(this.labelECODate);
            this.panel1.Controls.Add(this.labelLog);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.labelType);
            this.panel1.Controls.Add(this.labelRequester);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 235);
            this.panel1.TabIndex = 2;
            // 
            // txtApprover
            // 
            this.txtApprover.Location = new System.Drawing.Point(107, 182);
            this.txtApprover.Name = "txtApprover";
            this.txtApprover.Size = new System.Drawing.Size(190, 30);
            this.txtApprover.TabIndex = 2;
            // 
            // txtECOType
            // 
            this.txtECOType.Location = new System.Drawing.Point(407, 182);
            this.txtECOType.Name = "txtECOType";
            this.txtECOType.Size = new System.Drawing.Size(252, 30);
            this.txtECOType.TabIndex = 2;
            // 
            // txtECOStatus
            // 
            this.txtECOStatus.Location = new System.Drawing.Point(407, 126);
            this.txtECOStatus.Name = "txtECOStatus";
            this.txtECOStatus.Size = new System.Drawing.Size(252, 30);
            this.txtECOStatus.TabIndex = 2;
            // 
            // txtRequester
            // 
            this.txtRequester.Location = new System.Drawing.Point(107, 126);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.Size = new System.Drawing.Size(190, 30);
            this.txtRequester.TabIndex = 2;
            // 
            // txtECOLog
            // 
            this.txtECOLog.Location = new System.Drawing.Point(407, 14);
            this.txtECOLog.Multiline = true;
            this.txtECOLog.Name = "txtECOLog";
            this.txtECOLog.Size = new System.Drawing.Size(252, 86);
            this.txtECOLog.TabIndex = 2;
            // 
            // txtECODate
            // 
            this.txtECODate.Location = new System.Drawing.Point(107, 70);
            this.txtECODate.Name = "txtECODate";
            this.txtECODate.Size = new System.Drawing.Size(190, 30);
            this.txtECODate.TabIndex = 2;
            // 
            // txtECONo
            // 
            this.txtECONo.Location = new System.Drawing.Point(107, 14);
            this.txtECONo.Name = "txtECONo";
            this.txtECONo.Size = new System.Drawing.Size(190, 30);
            this.txtECONo.TabIndex = 2;
            // 
            // dgvECOListFile
            // 
            this.dgvECOListFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvECOListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECOListFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvECOListFile.FilterAndSortEnabled = true;
            this.dgvECOListFile.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECOListFile.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvECOListFile.Location = new System.Drawing.Point(3, 425);
            this.dgvECOListFile.MaxFilterButtonImageHeight = 23;
            this.dgvECOListFile.Name = "dgvECOListFile";
            this.dgvECOListFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvECOListFile.RowHeadersWidth = 51;
            this.dgvECOListFile.RowTemplate.Height = 24;
            this.dgvECOListFile.Size = new System.Drawing.Size(668, 176);
            this.dgvECOListFile.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECOListFile.TabIndex = 3;
            this.dgvECOListFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvECOListFile_CellClick);
            this.dgvECOListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvECOListFile_CellDoubleClick);
            // 
            // frmECO_Infor_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmECO_Infor_Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ECO Detail Information ( \"ESC\" for escape )";
            this.Load += new System.EventHandler(this.frmECO_Infor_Detail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmECO_Infor_Detail_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOContent)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOListFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelECONo;
        private System.Windows.Forms.Label labelECODate;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label labelRequester;
        private System.Windows.Forms.Label labelApprover;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelType;
        private Zuby.ADGV.AdvancedDataGridView dgvECOContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView dgvECOListFile;
        private System.Windows.Forms.TextBox txtApprover;
        private System.Windows.Forms.TextBox txtRequester;
        private System.Windows.Forms.TextBox txtECOLog;
        private System.Windows.Forms.TextBox txtECODate;
        private System.Windows.Forms.TextBox txtECONo;
        private System.Windows.Forms.TextBox txtECOType;
        private System.Windows.Forms.TextBox txtECOStatus;
    }
}