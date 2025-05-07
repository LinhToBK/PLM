namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmManageSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageSupplier));
            this.labelName = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelRepresentative = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveChange = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnModifySupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtRepresentative = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(22, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(123, 23);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Supplier Name";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(22, 70);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(126, 23);
            this.labelPhone.TabIndex = 0;
            this.labelPhone.Text = "Supplier Phone";
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(413, 70);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(101, 23);
            this.labelTax.TabIndex = 0;
            this.labelTax.Text = "Supplier Tax";
            // 
            // labelRepresentative
            // 
            this.labelRepresentative.AutoSize = true;
            this.labelRepresentative.Location = new System.Drawing.Point(413, 20);
            this.labelRepresentative.Name = "labelRepresentative";
            this.labelRepresentative.Size = new System.Drawing.Size(189, 23);
            this.labelRepresentative.TabIndex = 0;
            this.labelRepresentative.Text = "Supplier Representative";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(22, 120);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(142, 23);
            this.labelLocation.TabIndex = 0;
            this.labelLocation.Text = "Supplier Location";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(22, 188);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(115, 23);
            this.labelNote.TabIndex = 0;
            this.labelNote.Text = "Supplier Note";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveChange);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteSupplier);
            this.splitContainer1.Panel1.Controls.Add(this.btnModifySupplier);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddSupplier);
            this.splitContainer1.Panel1.Controls.Add(this.txtNote);
            this.splitContainer1.Panel1.Controls.Add(this.txtLocation);
            this.splitContainer1.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel1.Controls.Add(this.txtID);
            this.splitContainer1.Panel1.Controls.Add(this.txtTax);
            this.splitContainer1.Panel1.Controls.Add(this.txtRepresentative);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.labelPhone);
            this.splitContainer1.Panel1.Controls.Add(this.labelNote);
            this.splitContainer1.Panel1.Controls.Add(this.labelRepresentative);
            this.splitContainer1.Panel1.Controls.Add(this.labelLocation);
            this.splitContainer1.Panel1.Controls.Add(this.labelName);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.labelTax);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSupplier);
            this.splitContainer1.Size = new System.Drawing.Size(835, 577);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(740, 259);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(67, 43);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveChange.Image")));
            this.btnSaveChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChange.Location = new System.Drawing.Point(572, 259);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(142, 43);
            this.btnSaveChange.TabIndex = 9;
            this.btnSaveChange.Text = "Save Change";
            this.btnSaveChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Enabled = false;
            this.btnDeleteSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSupplier.Image")));
            this.btnDeleteSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSupplier.Location = new System.Drawing.Point(384, 259);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(162, 43);
            this.btnDeleteSupplier.TabIndex = 8;
            this.btnDeleteSupplier.Text = "Delete Supplier";
            this.btnDeleteSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // btnModifySupplier
            // 
            this.btnModifySupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifySupplier.Image")));
            this.btnModifySupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifySupplier.Location = new System.Drawing.Point(194, 259);
            this.btnModifySupplier.Name = "btnModifySupplier";
            this.btnModifySupplier.Size = new System.Drawing.Size(164, 43);
            this.btnModifySupplier.TabIndex = 7;
            this.btnModifySupplier.Text = "Modify Supplier";
            this.btnModifySupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifySupplier.UseVisualStyleBackColor = true;
            this.btnModifySupplier.Click += new System.EventHandler(this.btnModifySupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSupplier.Image")));
            this.btnAddSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSupplier.Location = new System.Drawing.Point(26, 259);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(142, 43);
            this.btnAddSupplier.TabIndex = 6;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(187, 165);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(623, 68);
            this.txtNote.TabIndex = 5;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(187, 117);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(623, 30);
            this.txtLocation.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(187, 66);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(202, 30);
            this.txtPhone.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(774, 66);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(35, 30);
            this.txtID.TabIndex = 11;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(545, 66);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(140, 30);
            this.txtTax.TabIndex = 3;
            // 
            // txtRepresentative
            // 
            this.txtRepresentative.Location = new System.Drawing.Point(608, 16);
            this.txtRepresentative.Name = "txtRepresentative";
            this.txtRepresentative.Size = new System.Drawing.Size(202, 30);
            this.txtRepresentative.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(187, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 30);
            this.txtName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(716, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "ID";
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.BackgroundColor = System.Drawing.Color.Aqua;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplier.MultiSelect = false;
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.RowHeadersWidth = 51;
            this.dgvSupplier.RowTemplate.Height = 24;
            this.dgvSupplier.Size = new System.Drawing.Size(835, 238);
            this.dgvSupplier.TabIndex = 0;
            this.dgvSupplier.Click += new System.EventHandler(this.dgvSupplier_Click);
            // 
            // frmManageSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 577);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManageSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý nhà cung cấp";
            this.Load += new System.EventHandler(this.frmManageSupplier_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelRepresentative;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtRepresentative;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveChange;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnModifySupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
    }
}