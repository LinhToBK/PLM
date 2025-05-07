namespace PLM_Lynx._03_GUI_User_Interface
{
    partial class frmListNear
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
            this.dgvListNearPart = new System.Windows.Forms.DataGridView();
            this.cboChooseNoRow = new System.Windows.Forms.ComboBox();
            this.lblChooseQuantity = new System.Windows.Forms.Label();
            this.lblEscape = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNearPart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListNearPart
            // 
            this.dgvListNearPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListNearPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListNearPart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListNearPart.Location = new System.Drawing.Point(0, 136);
            this.dgvListNearPart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvListNearPart.Name = "dgvListNearPart";
            this.dgvListNearPart.RowHeadersWidth = 51;
            this.dgvListNearPart.RowTemplate.Height = 23;
            this.dgvListNearPart.Size = new System.Drawing.Size(800, 501);
            this.dgvListNearPart.TabIndex = 0;
            // 
            // cboChooseNoRow
            // 
            this.cboChooseNoRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseNoRow.FormattingEnabled = true;
            this.cboChooseNoRow.Location = new System.Drawing.Point(251, 60);
            this.cboChooseNoRow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboChooseNoRow.Name = "cboChooseNoRow";
            this.cboChooseNoRow.Size = new System.Drawing.Size(276, 29);
            this.cboChooseNoRow.TabIndex = 1;
            this.cboChooseNoRow.SelectedIndexChanged += new System.EventHandler(this.cboChooseNoRow_SelectedIndexChanged);
            // 
            // lblChooseQuantity
            // 
            this.lblChooseQuantity.AutoSize = true;
            this.lblChooseQuantity.Location = new System.Drawing.Point(12, 66);
            this.lblChooseQuantity.Name = "lblChooseQuantity";
            this.lblChooseQuantity.Size = new System.Drawing.Size(216, 23);
            this.lblChooseQuantity.TabIndex = 2;
            this.lblChooseQuantity.Text = "Chọn số đối tượng hiển thị";
            // 
            // lblEscape
            // 
            this.lblEscape.AutoSize = true;
            this.lblEscape.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblEscape.Location = new System.Drawing.Point(556, 65);
            this.lblEscape.Name = "lblEscape";
            this.lblEscape.Size = new System.Drawing.Size(216, 19);
            this.lblEscape.TabIndex = 2;
            this.lblEscape.Text = "Phím tắt cửa sổ Form : Escape";
            // 
            // frmListNear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.lblEscape);
            this.Controls.Add(this.lblChooseQuantity);
            this.Controls.Add(this.cboChooseNoRow);
            this.Controls.Add(this.dgvListNearPart);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmListNear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách các Part gần nhất";
            this.Load += new System.EventHandler(this.frmListNear_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListNear_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNearPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListNearPart;
        private System.Windows.Forms.ComboBox cboChooseNoRow;
        private System.Windows.Forms.Label lblChooseQuantity;
        private System.Windows.Forms.Label lblEscape;
    }
}