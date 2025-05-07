namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    partial class frmListECO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListECO));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelListECO = new System.Windows.Forms.Panel();
            this.dgvListECO = new Zuby.ADGV.AdvancedDataGridView();
            this.cboListNear = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtECOContent = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelNo = new System.Windows.Forms.Label();
            this.txtECOType = new System.Windows.Forms.TextBox();
            this.txtECOStatus = new System.Windows.Forms.TextBox();
            this.txtECOProposal = new System.Windows.Forms.TextBox();
            this.txtECODate = new System.Windows.Forms.TextBox();
            this.txtECONo = new System.Windows.Forms.TextBox();
            this.dgvECOContent = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelListECO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListECO)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOContent)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panelListECO);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1075, 615);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelListECO
            // 
            this.panelListECO.AutoScroll = true;
            this.panelListECO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelListECO.Controls.Add(this.dgvListECO);
            this.panelListECO.Controls.Add(this.cboListNear);
            this.panelListECO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListECO.Location = new System.Drawing.Point(0, 0);
            this.panelListECO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelListECO.Name = "panelListECO";
            this.panelListECO.Size = new System.Drawing.Size(1075, 392);
            this.panelListECO.TabIndex = 0;
            // 
            // dgvListECO
            // 
            this.dgvListECO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListECO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListECO.FilterAndSortEnabled = true;
            this.dgvListECO.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListECO.Location = new System.Drawing.Point(0, 60);
            this.dgvListECO.MaxFilterButtonImageHeight = 23;
            this.dgvListECO.Name = "dgvListECO";
            this.dgvListECO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListECO.RowHeadersWidth = 51;
            this.dgvListECO.RowTemplate.Height = 24;
            this.dgvListECO.Size = new System.Drawing.Size(1075, 332);
            this.dgvListECO.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListECO.TabIndex = 5;
            this.dgvListECO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListECO_CellClick);
            this.dgvListECO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListECO_CellDoubleClick);
            this.dgvListECO.Click += new System.EventHandler(this.dgvListECO_Click);
            // 
            // cboListNear
            // 
            this.cboListNear.FormattingEnabled = true;
            this.cboListNear.Location = new System.Drawing.Point(12, 12);
            this.cboListNear.Name = "cboListNear";
            this.cboListNear.Size = new System.Drawing.Size(339, 31);
            this.cboListNear.TabIndex = 1;
            this.cboListNear.SelectedIndexChanged += new System.EventHandler(this.cboListNear_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvECOContent, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 217);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.txtECOContent);
            this.panel1.Controls.Add(this.labelType);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.labelDate);
            this.panel1.Controls.Add(this.labelNo);
            this.panel1.Controls.Add(this.txtECOType);
            this.panel1.Controls.Add(this.txtECOStatus);
            this.panel1.Controls.Add(this.txtECOProposal);
            this.panel1.Controls.Add(this.txtECODate);
            this.panel1.Controls.Add(this.txtECONo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 211);
            this.panel1.TabIndex = 0;
            // 
            // txtECOContent
            // 
            this.txtECOContent.Location = new System.Drawing.Point(293, 59);
            this.txtECOContent.Multiline = true;
            this.txtECOContent.Name = "txtECOContent";
            this.txtECOContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtECOContent.Size = new System.Drawing.Size(264, 132);
            this.txtECOContent.TabIndex = 2;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(289, 12);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(41, 23);
            this.labelType.TabIndex = 1;
            this.labelType.Text = "Loại";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 165);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(87, 23);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Trạng thái";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 114);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(87, 23);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Người tạo";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(9, 63);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(79, 23);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "ECODate";
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Location = new System.Drawing.Point(9, 12);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(71, 23);
            this.labelNo.TabIndex = 1;
            this.labelNo.Text = "ECO No";
            // 
            // txtECOType
            // 
            this.txtECOType.Location = new System.Drawing.Point(340, 8);
            this.txtECOType.Name = "txtECOType";
            this.txtECOType.ReadOnly = true;
            this.txtECOType.Size = new System.Drawing.Size(217, 30);
            this.txtECOType.TabIndex = 0;
            // 
            // txtECOStatus
            // 
            this.txtECOStatus.Location = new System.Drawing.Point(101, 164);
            this.txtECOStatus.Name = "txtECOStatus";
            this.txtECOStatus.ReadOnly = true;
            this.txtECOStatus.Size = new System.Drawing.Size(167, 30);
            this.txtECOStatus.TabIndex = 0;
            // 
            // txtECOProposal
            // 
            this.txtECOProposal.Location = new System.Drawing.Point(101, 110);
            this.txtECOProposal.Name = "txtECOProposal";
            this.txtECOProposal.ReadOnly = true;
            this.txtECOProposal.Size = new System.Drawing.Size(167, 30);
            this.txtECOProposal.TabIndex = 0;
            // 
            // txtECODate
            // 
            this.txtECODate.Location = new System.Drawing.Point(101, 59);
            this.txtECODate.Name = "txtECODate";
            this.txtECODate.ReadOnly = true;
            this.txtECODate.Size = new System.Drawing.Size(167, 30);
            this.txtECODate.TabIndex = 0;
            // 
            // txtECONo
            // 
            this.txtECONo.Location = new System.Drawing.Point(101, 8);
            this.txtECONo.Name = "txtECONo";
            this.txtECONo.ReadOnly = true;
            this.txtECONo.Size = new System.Drawing.Size(167, 30);
            this.txtECONo.TabIndex = 0;
            // 
            // dgvECOContent
            // 
            this.dgvECOContent.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvECOContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECOContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvECOContent.Location = new System.Drawing.Point(594, 3);
            this.dgvECOContent.Name = "dgvECOContent";
            this.dgvECOContent.RowHeadersWidth = 51;
            this.dgvECOContent.RowTemplate.Height = 24;
            this.dgvECOContent.Size = new System.Drawing.Size(343, 211);
            this.dgvECOContent.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(3, 101);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 43);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "  Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(3, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 43);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel  ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprove.Location = new System.Drawing.Point(3, 3);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(108, 43);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnApprove);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(943, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(129, 211);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // frmListECO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 615);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListECO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách cập nhật gần đây";
            this.Load += new System.EventHandler(this.frmListECO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelListECO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListECO)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOContent)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelListECO;
        private System.Windows.Forms.ComboBox cboListNear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelNo;
        private System.Windows.Forms.TextBox txtECOType;
        private System.Windows.Forms.TextBox txtECOStatus;
        private System.Windows.Forms.TextBox txtECOProposal;
        private System.Windows.Forms.TextBox txtECODate;
        private System.Windows.Forms.TextBox txtECONo;
        private System.Windows.Forms.DataGridView dgvECOContent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.TextBox txtECOContent;
        private Zuby.ADGV.AdvancedDataGridView dgvListECO;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}