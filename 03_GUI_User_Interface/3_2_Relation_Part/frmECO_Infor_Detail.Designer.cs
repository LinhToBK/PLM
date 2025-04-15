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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvECOContent = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvECOListFile = new Zuby.ADGV.AdvancedDataGridView();
            this.txtECONo = new System.Windows.Forms.TextBox();
            this.txtECODate = new System.Windows.Forms.TextBox();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.txtApprover = new System.Windows.Forms.TextBox();
            this.txtECOLog = new System.Windows.Forms.TextBox();
            this.txtECOStatus = new System.Windows.Forms.TextBox();
            this.txtECOType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOContent)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOListFile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ECO No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "ECO Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "ECO Log";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Requester";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Approver";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "ECO Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "ECO Type";
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 235);
            this.panel1.TabIndex = 2;
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
            // txtECONo
            // 
            this.txtECONo.Location = new System.Drawing.Point(107, 14);
            this.txtECONo.Name = "txtECONo";
            this.txtECONo.Size = new System.Drawing.Size(190, 30);
            this.txtECONo.TabIndex = 2;
            // 
            // txtECODate
            // 
            this.txtECODate.Location = new System.Drawing.Point(107, 70);
            this.txtECODate.Name = "txtECODate";
            this.txtECODate.Size = new System.Drawing.Size(190, 30);
            this.txtECODate.TabIndex = 2;
            // 
            // txtRequester
            // 
            this.txtRequester.Location = new System.Drawing.Point(107, 126);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.Size = new System.Drawing.Size(190, 30);
            this.txtRequester.TabIndex = 2;
            // 
            // txtApprover
            // 
            this.txtApprover.Location = new System.Drawing.Point(107, 182);
            this.txtApprover.Name = "txtApprover";
            this.txtApprover.Size = new System.Drawing.Size(190, 30);
            this.txtApprover.TabIndex = 2;
            // 
            // txtECOLog
            // 
            this.txtECOLog.Location = new System.Drawing.Point(407, 14);
            this.txtECOLog.Multiline = true;
            this.txtECOLog.Name = "txtECOLog";
            this.txtECOLog.Size = new System.Drawing.Size(252, 86);
            this.txtECOLog.TabIndex = 2;
            // 
            // txtECOStatus
            // 
            this.txtECOStatus.Location = new System.Drawing.Point(407, 126);
            this.txtECOStatus.Name = "txtECOStatus";
            this.txtECOStatus.Size = new System.Drawing.Size(252, 30);
            this.txtECOStatus.TabIndex = 2;
            // 
            // txtECOType
            // 
            this.txtECOType.Location = new System.Drawing.Point(407, 182);
            this.txtECOType.Name = "txtECOType";
            this.txtECOType.Size = new System.Drawing.Size(252, 30);
            this.txtECOType.TabIndex = 2;
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
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