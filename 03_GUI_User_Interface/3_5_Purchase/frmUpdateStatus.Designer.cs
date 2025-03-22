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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPOCode = new System.Windows.Forms.TextBox();
            this.txtPOStatus = new System.Windows.Forms.TextBox();
            this.cboNewStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "PO Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Update Status";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(29, 236);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 45);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPOCode
            // 
            this.txtPOCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtPOCode.Location = new System.Drawing.Point(168, 17);
            this.txtPOCode.Name = "txtPOCode";
            this.txtPOCode.Size = new System.Drawing.Size(176, 30);
            this.txtPOCode.TabIndex = 2;
            // 
            // txtPOStatus
            // 
            this.txtPOStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtPOStatus.Location = new System.Drawing.Point(168, 125);
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
            this.cboNewStatus.Location = new System.Drawing.Point(168, 179);
            this.cboNewStatus.Name = "cboNewStatus";
            this.cboNewStatus.Size = new System.Drawing.Size(176, 31);
            this.cboNewStatus.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "PO Date";
            // 
            // txtPODate
            // 
            this.txtPODate.BackColor = System.Drawing.SystemColors.Info;
            this.txtPODate.Location = new System.Drawing.Point(168, 71);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.Size = new System.Drawing.Size(176, 30);
            this.txtPODate.TabIndex = 2;
            // 
            // frmUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 317);
            this.Controls.Add(this.cboNewStatus);
            this.Controls.Add(this.txtPOStatus);
            this.Controls.Add(this.txtPODate);
            this.Controls.Add(this.txtPOCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUpdateStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Status of PO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateStatus_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPOCode;
        private System.Windows.Forms.TextBox txtPOStatus;
        private System.Windows.Forms.ComboBox cboNewStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPODate;
    }
}