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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.cboChooseNoRow.Location = new System.Drawing.Point(203, 63);
            this.cboChooseNoRow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboChooseNoRow.Name = "cboChooseNoRow";
            this.cboChooseNoRow.Size = new System.Drawing.Size(276, 29);
            this.cboChooseNoRow.TabIndex = 1;
            this.cboChooseNoRow.SelectedIndexChanged += new System.EventHandler(this.cboChooseNoRow_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn số đối tượng hiển thị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(589, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phím tắt cửa sổ Form : Escape";
            // 
            // frmListNear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}