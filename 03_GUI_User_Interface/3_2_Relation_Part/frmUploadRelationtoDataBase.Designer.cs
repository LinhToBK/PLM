namespace PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part
{
    partial class frmUploadRelationtoDataBase
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListChild = new System.Windows.Forms.DataGridView();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(296, 28);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(164, 29);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload to DataBase";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(504, 28);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 29);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parent Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parent Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "List Child with Quantity";
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListChild.Location = new System.Drawing.Point(0, 177);
            this.dgvListChild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RowTemplate.Height = 23;
            this.dgvListChild.Size = new System.Drawing.Size(576, 271);
            this.dgvListChild.TabIndex = 2;
            // 
            // txtParentCode
            // 
            this.txtParentCode.Location = new System.Drawing.Point(121, 30);
            this.txtParentCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(126, 22);
            this.txtParentCode.TabIndex = 3;
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(121, 76);
            this.txtParentName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(442, 22);
            this.txtParentName.TabIndex = 3;
            // 
            // frmUploadRelationtoDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 448);
            this.Controls.Add(this.txtParentName);
            this.Controls.Add(this.txtParentCode);
            this.Controls.Add(this.dgvListChild);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpload);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUploadRelationtoDataBase";
            this.Text = "Upload Relation to DataBase";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListChild;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.TextBox txtParentName;
    }
}