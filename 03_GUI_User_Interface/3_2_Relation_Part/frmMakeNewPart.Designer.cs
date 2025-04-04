namespace PLM_Lynx._03_GUI_User_Interface
{
    partial class frmMakeNewPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakeNewPart));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApplyTemplate = new System.Windows.Forms.Button();
            this.txtApplyTemPlate = new System.Windows.Forms.TextBox();
            this.txtFamilyDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPartFamily = new System.Windows.Forms.ComboBox();
            this.txtPartDescript = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnListNear = new System.Windows.Forms.Button();
            this.btnAddFileAttachment = new System.Windows.Forms.Button();
            this.dgvFileAttachment = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvFamily = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.txtPartMaterial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamily)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPartMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.cboMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btnApplyTemplate);
            this.splitContainer1.Panel1.Controls.Add(this.txtApplyTemPlate);
            this.splitContainer1.Panel1.Controls.Add(this.txtFamilyDescription);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cboPartFamily);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartDescript);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartName);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(978, 527);
            this.splitContainer1.SplitterDistance = 546;
            this.splitContainer1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Template Descript";
            // 
            // btnApplyTemplate
            // 
            this.btnApplyTemplate.Location = new System.Drawing.Point(463, 176);
            this.btnApplyTemplate.Name = "btnApplyTemplate";
            this.btnApplyTemplate.Size = new System.Drawing.Size(55, 23);
            this.btnApplyTemplate.TabIndex = 9;
            this.btnApplyTemplate.Text = "Apply";
            this.btnApplyTemplate.UseVisualStyleBackColor = true;
            this.btnApplyTemplate.Click += new System.EventHandler(this.btnApplyTemplate_Click);
            // 
            // txtApplyTemPlate
            // 
            this.txtApplyTemPlate.Location = new System.Drawing.Point(343, 205);
            this.txtApplyTemPlate.Multiline = true;
            this.txtApplyTemPlate.Name = "txtApplyTemPlate";
            this.txtApplyTemPlate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtApplyTemPlate.Size = new System.Drawing.Size(175, 59);
            this.txtApplyTemPlate.TabIndex = 8;
            // 
            // txtFamilyDescription
            // 
            this.txtFamilyDescription.Location = new System.Drawing.Point(229, 12);
            this.txtFamilyDescription.Name = "txtFamilyDescription";
            this.txtFamilyDescription.ReadOnly = true;
            this.txtFamilyDescription.Size = new System.Drawing.Size(289, 23);
            this.txtFamilyDescription.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(9, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Gợi ý :  PartName nên ghi rõ tên model và tính năng \r\nDescription :nên ghi kích t" +
    "hước bao";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(7, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Có thể kéo thả file vào vùng Part File Attachment để thêm file\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(9, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "File đính kèm có đuôi : .jpg .PDF, .dwg, .dwf, .stp, iegs, .prt";
            // 
            // cboPartFamily
            // 
            this.cboPartFamily.FormattingEnabled = true;
            this.cboPartFamily.Location = new System.Drawing.Point(92, 11);
            this.cboPartFamily.Name = "cboPartFamily";
            this.cboPartFamily.Size = new System.Drawing.Size(120, 23);
            this.cboPartFamily.TabIndex = 4;
            this.cboPartFamily.SelectionChangeCommitted += new System.EventHandler(this.cboPartFamily_SelectionChangeCommitted);
            // 
            // txtPartDescript
            // 
            this.txtPartDescript.Location = new System.Drawing.Point(92, 82);
            this.txtPartDescript.Multiline = true;
            this.txtPartDescript.Name = "txtPartDescript";
            this.txtPartDescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartDescript.Size = new System.Drawing.Size(426, 59);
            this.txtPartDescript.TabIndex = 2;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(92, 43);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(426, 23);
            this.txtPartName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDeleteFile);
            this.groupBox2.Controls.Add(this.btnListNear);
            this.groupBox2.Controls.Add(this.btnAddFileAttachment);
            this.groupBox2.Controls.Add(this.dgvFileAttachment);
            this.groupBox2.Location = new System.Drawing.Point(0, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 257);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Part File Attachment";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteFile.Location = new System.Drawing.Point(482, 87);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(58, 60);
            this.btnDeleteFile.TabIndex = 1;
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnListNear
            // 
            this.btnListNear.Image = ((System.Drawing.Image)(resources.GetObject("btnListNear.Image")));
            this.btnListNear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListNear.Location = new System.Drawing.Point(482, 153);
            this.btnListNear.Name = "btnListNear";
            this.btnListNear.Size = new System.Drawing.Size(58, 90);
            this.btnListNear.TabIndex = 6;
            this.btnListNear.Text = "&Hiển thị\r\n chi tiết \r\ngần nhất";
            this.btnListNear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListNear.UseVisualStyleBackColor = true;
            this.btnListNear.Click += new System.EventHandler(this.btnListNear_Click);
            // 
            // btnAddFileAttachment
            // 
            this.btnAddFileAttachment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFileAttachment.Image")));
            this.btnAddFileAttachment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddFileAttachment.Location = new System.Drawing.Point(482, 21);
            this.btnAddFileAttachment.Name = "btnAddFileAttachment";
            this.btnAddFileAttachment.Size = new System.Drawing.Size(58, 60);
            this.btnAddFileAttachment.TabIndex = 0;
            this.btnAddFileAttachment.Text = "Add\r\nFile";
            this.btnAddFileAttachment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddFileAttachment.UseVisualStyleBackColor = true;
            this.btnAddFileAttachment.Click += new System.EventHandler(this.btnAddFileAttachment_Click);
            // 
            // dgvFileAttachment
            // 
            this.dgvFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFileAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileAttachment.Location = new System.Drawing.Point(6, 21);
            this.dgvFileAttachment.Name = "dgvFileAttachment";
            this.dgvFileAttachment.RowTemplate.Height = 23;
            this.dgvFileAttachment.Size = new System.Drawing.Size(473, 222);
            this.dgvFileAttachment.TabIndex = 1;
            this.dgvFileAttachment.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFileAttachment_DragDrop);
            this.dgvFileAttachment.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvFileAttachment_DragEnter);
            this.dgvFileAttachment.DoubleClick += new System.EventHandler(this.dgvFileAttachment_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Part Family";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Descript";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Part Name";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvFamily);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExit);
            this.splitContainer2.Panel2.Controls.Add(this.btnAddPart);
            this.splitContainer2.Size = new System.Drawing.Size(428, 527);
            this.splitContainer2.SplitterDistance = 426;
            this.splitContainer2.TabIndex = 2;
            // 
            // dgvFamily
            // 
            this.dgvFamily.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFamily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFamily.Location = new System.Drawing.Point(0, 0);
            this.dgvFamily.Name = "dgvFamily";
            this.dgvFamily.RowTemplate.Height = 23;
            this.dgvFamily.Size = new System.Drawing.Size(428, 426);
            this.dgvFamily.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(227, 23);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 40);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddPart
            // 
            this.btnAddPart.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPart.Image")));
            this.btnAddPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPart.Location = new System.Drawing.Point(50, 23);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(120, 40);
            this.btnAddPart.TabIndex = 0;
            this.btnAddPart.Text = "Add New Part";
            this.btnAddPart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Part Material";
            // 
            // cboMaterial
            // 
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(92, 151);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(100, 23);
            this.cboMaterial.TabIndex = 11;
            this.cboMaterial.SelectedIndexChanged += new System.EventHandler(this.cboMaterial_SelectedIndexChanged);
            // 
            // txtPartMaterial
            // 
            this.txtPartMaterial.Location = new System.Drawing.Point(204, 151);
            this.txtPartMaterial.Name = "txtPartMaterial";
            this.txtPartMaterial.Size = new System.Drawing.Size(126, 23);
            this.txtPartMaterial.TabIndex = 12;
            // 
            // frmMakeNewPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 527);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMakeNewPart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make New Part";
            this.Load += new System.EventHandler(this.frmMakeNewPart_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMakeNewPart_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileAttachment)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamily)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvFamily;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvFileAttachment;
        private System.Windows.Forms.TextBox txtPartDescript;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFileAttachment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPartFamily;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListNear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFamilyDescription;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnApplyTemplate;
        private System.Windows.Forms.TextBox txtApplyTemPlate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.TextBox txtPartMaterial;
    }
}