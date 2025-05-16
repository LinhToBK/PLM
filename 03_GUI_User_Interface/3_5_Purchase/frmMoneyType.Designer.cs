namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmMoneyType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoneyType));
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvListMoneyType = new Zuby.ADGV.AdvancedDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtOldCurrency = new System.Windows.Forms.TextBox();
            this.txtNewCurrency = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMoneyType)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.Location = new System.Drawing.Point(3, 40);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(108, 33);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Change";
            this.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(117, 40);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListMoneyType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 356);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvListMoneyType
            // 
            this.dgvListMoneyType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMoneyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListMoneyType.FilterAndSortEnabled = true;
            this.dgvListMoneyType.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListMoneyType.Location = new System.Drawing.Point(3, 3);
            this.dgvListMoneyType.MaxFilterButtonImageHeight = 23;
            this.dgvListMoneyType.Name = "dgvListMoneyType";
            this.dgvListMoneyType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListMoneyType.RowHeadersWidth = 51;
            this.dgvListMoneyType.RowTemplate.Height = 24;
            this.dgvListMoneyType.Size = new System.Drawing.Size(237, 250);
            this.dgvListMoneyType.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListMoneyType.TabIndex = 0;
            this.dgvListMoneyType.Click += new System.EventHandler(this.dgvListMoneyType_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtOldCurrency);
            this.flowLayoutPanel1.Controls.Add(this.txtNewCurrency);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 259);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 94);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // txtOldCurrency
            // 
            this.txtOldCurrency.Enabled = false;
            this.txtOldCurrency.Location = new System.Drawing.Point(3, 3);
            this.txtOldCurrency.Name = "txtOldCurrency";
            this.txtOldCurrency.Size = new System.Drawing.Size(100, 30);
            this.txtOldCurrency.TabIndex = 1;
            // 
            // txtNewCurrency
            // 
            this.txtNewCurrency.Enabled = false;
            this.txtNewCurrency.Location = new System.Drawing.Point(109, 3);
            this.txtNewCurrency.Name = "txtNewCurrency";
            this.txtNewCurrency.Size = new System.Drawing.Size(100, 30);
            this.txtNewCurrency.TabIndex = 1;
            // 
            // frmMoneyType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 356);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMoneyType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMoneyType";
            this.Load += new System.EventHandler(this.frmMoneyType_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMoneyType)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Zuby.ADGV.AdvancedDataGridView dgvListMoneyType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtOldCurrency;
        private System.Windows.Forms.TextBox txtNewCurrency;
    }
}