namespace PLM_Lynx._03_GUI_User_Interface._3_6_Help
{
    partial class Test_Check_Box
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
            this.dgvTest = new Zuby.ADGV.AdvancedDataGridView();
            this.ckcApply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTest
            // 
            this.dgvTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckcApply,
            this.Content});
            this.dgvTest.FilterAndSortEnabled = true;
            this.dgvTest.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvTest.Location = new System.Drawing.Point(72, 40);
            this.dgvTest.MaxFilterButtonImageHeight = 23;
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvTest.RowHeadersWidth = 51;
            this.dgvTest.RowTemplate.Height = 24;
            this.dgvTest.Size = new System.Drawing.Size(463, 209);
            this.dgvTest.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvTest.TabIndex = 0;
            // 
            // ckcApply
            // 
            this.ckcApply.HeaderText = "";
            this.ckcApply.MinimumWidth = 24;
            this.ckcApply.Name = "ckcApply";
            this.ckcApply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Content
            // 
            this.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Content.HeaderText = "Column1";
            this.Content.MinimumWidth = 24;
            this.Content.Name = "Content";
            this.Content.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Test_Check_Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 471);
            this.Controls.Add(this.dgvTest);
            this.Name = "Test_Check_Box";
            this.Text = "Test_Check_Box";
            this.Load += new System.EventHandler(this.Test_Check_Box_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvTest;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ckcApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
    }
}