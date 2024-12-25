namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    partial class frmECO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmECO));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpenRelationManage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearchDetail = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListTimKiem = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdatePart = new System.Windows.Forms.Button();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChildCode = new System.Windows.Forms.TextBox();
            this.txtChildName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCheckListChild = new System.Windows.Forms.Button();
            this.btnAddParent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModifyQuantity = new System.Windows.Forms.Button();
            this.dgvListChild = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1289, 508);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.btnOpenRelationManage);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.btnSearchDetail);
            this.splitContainer3.Panel1.Controls.Add(this.btnTimKiem);
            this.splitContainer3.Panel1.Controls.Add(this.txtTimKiem);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvListTimKiem);
            this.splitContainer3.Size = new System.Drawing.Size(646, 508);
            this.splitContainer3.SplitterDistance = 172;
            this.splitContainer3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 56);
            this.label5.TabIndex = 2;
            this.label5.Text = "ECO bao gồm : \r\n1. Cập nhật thông tin của Part\r\n2. Xóa  ràng buộc của 2 Part\r\n3. " +
    "Sửa Quantity của Child Part đối với 1 Parent Part";
            // 
            // btnOpenRelationManage
            // 
            this.btnOpenRelationManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnOpenRelationManage.Location = new System.Drawing.Point(147, 87);
            this.btnOpenRelationManage.Name = "btnOpenRelationManage";
            this.btnOpenRelationManage.Size = new System.Drawing.Size(123, 23);
            this.btnOpenRelationManage.TabIndex = 5;
            this.btnOpenRelationManage.Text = "Tạo ràng buộc mới";
            this.btnOpenRelationManage.UseVisualStyleBackColor = false;
            this.btnOpenRelationManage.Click += new System.EventHandler(this.btnOpenRelationManage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(276, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 84);
            this.label7.TabIndex = 2;
            this.label7.Text = "Phím tắt : \r\n+) Alt + T => Thêm Part từ danh sách vào Infor \r\n+) Alt + P => Thêm " +
    "Parent\r\n+) Alt + C => Thêm Child\r\n+) Nhập ô tìm kiếm => Nhấn Enter để tra cứu\r\n+" +
    ") Alt + L => Check List Child";
            // 
            // btnSearchDetail
            // 
            this.btnSearchDetail.Location = new System.Drawing.Point(12, 87);
            this.btnSearchDetail.Name = "btnSearchDetail";
            this.btnSearchDetail.Size = new System.Drawing.Size(123, 23);
            this.btnSearchDetail.TabIndex = 4;
            this.btnSearchDetail.Text = "Tra cứu chi tiết";
            this.btnSearchDetail.UseVisualStyleBackColor = true;
            this.btnSearchDetail.Click += new System.EventHandler(this.btnSearchDetail_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(340, 118);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(73, 29);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "&Search";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(149, 121);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(179, 22);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập từ khóa tìm kiếm";
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(0, 0);
            this.dgvListTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(646, 332);
            this.dgvListTimKiem.TabIndex = 3;
            this.dgvListTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(639, 508);
            this.splitContainer2.SplitterDistance = 72;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.btnUpdatePart);
            this.groupBox2.Controls.Add(this.txtPartName);
            this.groupBox2.Controls.Add(this.txtPartCode);
            this.groupBox2.Controls.Add(this.btnAddPart);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 72);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Information of Part";
            // 
            // btnUpdatePart
            // 
            this.btnUpdatePart.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdatePart.Location = new System.Drawing.Point(413, 16);
            this.btnUpdatePart.Name = "btnUpdatePart";
            this.btnUpdatePart.Size = new System.Drawing.Size(68, 48);
            this.btnUpdatePart.TabIndex = 4;
            this.btnUpdatePart.Text = "&Update Part";
            this.btnUpdatePart.UseVisualStyleBackColor = false;
            this.btnUpdatePart.Click += new System.EventHandler(this.btnUpdatePart_Click);
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(115, 42);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(286, 22);
            this.txtPartName.TabIndex = 3;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(300, 14);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(100, 22);
            this.txtPartCode.TabIndex = 3;
            // 
            // btnAddPart
            // 
            this.btnAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddPart.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPart.Image")));
            this.btnAddPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPart.Location = new System.Drawing.Point(9, 35);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(87, 29);
            this.btnAddPart.TabIndex = 1;
            this.btnAddPart.Text = "Add Par&t";
            this.btnAddPart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPart.UseVisualStyleBackColor = false;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cập nhật Version DV/PV/MP, bản vẽ,...";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer4.Panel1.Controls.Add(this.label8);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.txtChildCode);
            this.splitContainer4.Panel1.Controls.Add(this.txtChildName);
            this.splitContainer4.Panel1.Controls.Add(this.txtQuantity);
            this.splitContainer4.Panel1.Controls.Add(this.btnAddChild);
            this.splitContainer4.Panel1.Controls.Add(this.label6);
            this.splitContainer4.Panel1.Controls.Add(this.btnCheckListChild);
            this.splitContainer4.Panel1.Controls.Add(this.btnAddParent);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.Controls.Add(this.txtParentName);
            this.splitContainer4.Panel1.Controls.Add(this.txtParentCode);
            this.splitContainer4.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer4.Panel1.Controls.Add(this.btnModifyQuantity);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvListChild);
            this.splitContainer4.Size = new System.Drawing.Size(639, 431);
            this.splitContainer4.SplitterDistance = 194;
            this.splitContainer4.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Parent Infor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Child Infor";
            // 
            // txtChildCode
            // 
            this.txtChildCode.Location = new System.Drawing.Point(381, 34);
            this.txtChildCode.Name = "txtChildCode";
            this.txtChildCode.ReadOnly = true;
            this.txtChildCode.Size = new System.Drawing.Size(129, 22);
            this.txtChildCode.TabIndex = 3;
            // 
            // txtChildName
            // 
            this.txtChildName.Location = new System.Drawing.Point(264, 69);
            this.txtChildName.Name = "txtChildName";
            this.txtChildName.ReadOnly = true;
            this.txtChildName.Size = new System.Drawing.Size(246, 22);
            this.txtChildName.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(458, 95);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(52, 22);
            this.txtQuantity.TabIndex = 4;
            // 
            // btnAddChild
            // 
            this.btnAddChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddChild.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChild.Image")));
            this.btnAddChild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddChild.Location = new System.Drawing.Point(264, 31);
            this.btnAddChild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(95, 29);
            this.btnAddChild.TabIndex = 1;
            this.btnAddChild.Text = "Add &Child";
            this.btnAddChild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddChild.UseVisualStyleBackColor = false;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(14, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 56);
            this.label6.TabIndex = 5;
            this.label6.Text = "ECO Relation  bao gồm : \r\n1. Xóa  ràng buộc của 2 Part \r\n( Nếu xóa thì phải tạo l" +
    "ại đó nhé )\r\n2. Sửa Quantity của Child Part đối với 1 Parent Part";
            // 
            // btnCheckListChild
            // 
            this.btnCheckListChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCheckListChild.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckListChild.Image")));
            this.btnCheckListChild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckListChild.Location = new System.Drawing.Point(125, 31);
            this.btnCheckListChild.Name = "btnCheckListChild";
            this.btnCheckListChild.Size = new System.Drawing.Size(110, 60);
            this.btnCheckListChild.TabIndex = 6;
            this.btnCheckListChild.Text = "Check \r\n&List Child";
            this.btnCheckListChild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckListChild.UseVisualStyleBackColor = false;
            this.btnCheckListChild.Click += new System.EventHandler(this.btnCheckListChild_Click);
            // 
            // btnAddParent
            // 
            this.btnAddParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddParent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddParent.Image")));
            this.btnAddParent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddParent.Location = new System.Drawing.Point(14, 31);
            this.btnAddParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(95, 29);
            this.btnAddParent.TabIndex = 1;
            this.btnAddParent.Text = "Add &Parent";
            this.btnAddParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddParent.UseVisualStyleBackColor = false;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantity";
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(14, 92);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(221, 22);
            this.txtParentName.TabIndex = 3;
            // 
            // txtParentCode
            // 
            this.txtParentCode.Location = new System.Drawing.Point(14, 65);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(95, 22);
            this.txtParentCode.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(398, 144);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Relation";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnModifyQuantity
            // 
            this.btnModifyQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnModifyQuantity.Enabled = false;
            this.btnModifyQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyQuantity.Image")));
            this.btnModifyQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyQuantity.Location = new System.Drawing.Point(264, 144);
            this.btnModifyQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyQuantity.Name = "btnModifyQuantity";
            this.btnModifyQuantity.Size = new System.Drawing.Size(132, 29);
            this.btnModifyQuantity.TabIndex = 1;
            this.btnModifyQuantity.Text = "Modify Quantity";
            this.btnModifyQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyQuantity.UseVisualStyleBackColor = false;
            this.btnModifyQuantity.Click += new System.EventHandler(this.btnModifyQuantity_Click);
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListChild.Location = new System.Drawing.Point(0, 0);
            this.dgvListChild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RowTemplate.Height = 23;
            this.dgvListChild.Size = new System.Drawing.Size(639, 233);
            this.dgvListChild.TabIndex = 0;
            this.dgvListChild.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListChild_CellDoubleClick);
            // 
            // frmECO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 508);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmECO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ECO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmECO_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTimKiem)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListChild)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvListTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdatePart;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchDetail;
        private System.Windows.Forms.Button btnOpenRelationManage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChildCode;
        private System.Windows.Forms.TextBox txtChildName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCheckListChild;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModifyQuantity;
        private System.Windows.Forms.DataGridView dgvListChild;
    }
}