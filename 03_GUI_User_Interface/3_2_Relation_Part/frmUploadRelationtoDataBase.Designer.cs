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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadRelationtoDataBase));
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelParentCode = new System.Windows.Forms.Label();
            this.labelParentName = new System.Windows.Forms.Label();
            this.labelListChild = new System.Windows.Forms.Label();
            this.dgvListChild = new System.Windows.Forms.DataGridView();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.AutoSize = true;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(318, 16);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(140, 33);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Make a ECO";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(502, 16);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 33);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelParentCode
            // 
            this.labelParentCode.AutoSize = true;
            this.labelParentCode.Location = new System.Drawing.Point(12, 22);
            this.labelParentCode.Name = "labelParentCode";
            this.labelParentCode.Size = new System.Drawing.Size(104, 23);
            this.labelParentCode.TabIndex = 1;
            this.labelParentCode.Text = "Parent Code";
            // 
            // labelParentName
            // 
            this.labelParentName.AutoSize = true;
            this.labelParentName.Location = new System.Drawing.Point(12, 73);
            this.labelParentName.Name = "labelParentName";
            this.labelParentName.Size = new System.Drawing.Size(110, 23);
            this.labelParentName.TabIndex = 1;
            this.labelParentName.Text = "Parent Name";
            // 
            // labelListChild
            // 
            this.labelListChild.AutoSize = true;
            this.labelListChild.Location = new System.Drawing.Point(12, 117);
            this.labelListChild.Name = "labelListChild";
            this.labelListChild.Size = new System.Drawing.Size(187, 23);
            this.labelListChild.TabIndex = 1;
            this.labelListChild.Text = "List Child with Quantity";
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListChild.Location = new System.Drawing.Point(0, 151);
            this.dgvListChild.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RowHeadersWidth = 51;
            this.dgvListChild.RowTemplate.Height = 23;
            this.dgvListChild.Size = new System.Drawing.Size(576, 357);
            this.dgvListChild.TabIndex = 2;
            // 
            // txtParentCode
            // 
            this.txtParentCode.Location = new System.Drawing.Point(148, 18);
            this.txtParentCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(126, 29);
            this.txtParentCode.TabIndex = 3;
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(148, 69);
            this.txtParentName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(415, 29);
            this.txtParentName.TabIndex = 3;
            // 
            // frmUploadRelationtoDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(576, 508);
            this.Controls.Add(this.txtParentName);
            this.Controls.Add(this.txtParentCode);
            this.Controls.Add(this.dgvListChild);
            this.Controls.Add(this.labelListChild);
            this.Controls.Add(this.labelParentName);
            this.Controls.Add(this.labelParentCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpload);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmUploadRelationtoDataBase";
            this.Text = "Upload Relation to DataBase";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelParentCode;
        private System.Windows.Forms.Label labelParentName;
        private System.Windows.Forms.Label labelListChild;
        private System.Windows.Forms.DataGridView dgvListChild;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.TextBox txtParentName;
    }
}