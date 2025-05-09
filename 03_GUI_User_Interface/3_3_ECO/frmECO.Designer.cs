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
            this.labelNote1 = new System.Windows.Forms.Label();
            this.btnOpenRelationManage = new System.Windows.Forms.Button();
            this.labelNote2 = new System.Windows.Forms.Label();
            this.btnSearchDetail = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.labelNote3 = new System.Windows.Forms.Label();
            this.dgvListTimKiem = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxPart = new System.Windows.Forms.GroupBox();
            this.btnUpdatePart = new System.Windows.Forms.Button();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.labelNote4 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnModifyQuantity = new System.Windows.Forms.Button();
            this.labelParent = new System.Windows.Forms.Label();
            this.labelNote5 = new System.Windows.Forms.Label();
            this.btnCheckListChild = new System.Windows.Forms.Button();
            this.btnAddParent = new System.Windows.Forms.Button();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvListChild = new Zuby.ADGV.AdvancedDataGridView();
            this.ckcApply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
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
            this.groupBoxPart.SuspendLayout();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 576);
            this.splitContainer1.SplitterDistance = 578;
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
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel1.Controls.Add(this.btnExit);
            this.splitContainer3.Panel1.Controls.Add(this.labelNote1);
            this.splitContainer3.Panel1.Controls.Add(this.btnOpenRelationManage);
            this.splitContainer3.Panel1.Controls.Add(this.labelNote2);
            this.splitContainer3.Panel1.Controls.Add(this.btnSearchDetail);
            this.splitContainer3.Panel1.Controls.Add(this.btnTimKiem);
            this.splitContainer3.Panel1.Controls.Add(this.txtTimKiem);
            this.splitContainer3.Panel1.Controls.Add(this.labelNote3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvListTimKiem);
            this.splitContainer3.Size = new System.Drawing.Size(578, 576);
            this.splitContainer3.SplitterDistance = 195;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 6;
            // 
            // labelNote1
            // 
            this.labelNote1.AutoSize = true;
            this.labelNote1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote1.ForeColor = System.Drawing.Color.Blue;
            this.labelNote1.Location = new System.Drawing.Point(12, 18);
            this.labelNote1.Name = "labelNote1";
            this.labelNote1.Size = new System.Drawing.Size(222, 80);
            this.labelNote1.TabIndex = 2;
            this.labelNote1.Text = "ECO bao gồm : \r\n1. Cập nhật thông tin của Part\r\n2. Xóa  ràng buộc của 2 Part\r\n3. " +
    "Sửa số lượng trong ràng buộc";
            // 
            // btnOpenRelationManage
            // 
            this.btnOpenRelationManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnOpenRelationManage.Location = new System.Drawing.Point(159, 99);
            this.btnOpenRelationManage.Name = "btnOpenRelationManage";
            this.btnOpenRelationManage.Size = new System.Drawing.Size(180, 39);
            this.btnOpenRelationManage.TabIndex = 5;
            this.btnOpenRelationManage.Text = "Tạo ràng buộc mới";
            this.btnOpenRelationManage.UseVisualStyleBackColor = false;
            this.btnOpenRelationManage.Click += new System.EventHandler(this.btnOpenRelationManage_Click);
            // 
            // labelNote2
            // 
            this.labelNote2.AutoSize = true;
            this.labelNote2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote2.ForeColor = System.Drawing.Color.Blue;
            this.labelNote2.Location = new System.Drawing.Point(342, 18);
            this.labelNote2.Name = "labelNote2";
            this.labelNote2.Size = new System.Drawing.Size(203, 100);
            this.labelNote2.TabIndex = 2;
            this.labelNote2.Text = "Phím tắt : \r\n+) Alt + T => Thêm Part \r\n+) Alt + P => Thêm Parent\r\n+) Nhấn Enter =" +
    " Search\r\n+) Alt + L => Check List Child";
            // 
            // btnSearchDetail
            // 
            this.btnSearchDetail.Location = new System.Drawing.Point(12, 99);
            this.btnSearchDetail.Name = "btnSearchDetail";
            this.btnSearchDetail.Size = new System.Drawing.Size(141, 39);
            this.btnSearchDetail.TabIndex = 4;
            this.btnSearchDetail.Text = "Tra cứu chi tiết";
            this.btnSearchDetail.UseVisualStyleBackColor = true;
            this.btnSearchDetail.Click += new System.EventHandler(this.btnSearchDetail_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(394, 149);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(92, 33);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "&Search";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(204, 151);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(179, 29);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // labelNote3
            // 
            this.labelNote3.AutoSize = true;
            this.labelNote3.Location = new System.Drawing.Point(12, 154);
            this.labelNote3.Name = "labelNote3";
            this.labelNote3.Size = new System.Drawing.Size(186, 23);
            this.labelNote3.TabIndex = 2;
            this.labelNote3.Text = "Nhập từ khóa tìm kiếm";
            // 
            // dgvListTimKiem
            // 
            this.dgvListTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListTimKiem.Location = new System.Drawing.Point(0, 0);
            this.dgvListTimKiem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvListTimKiem.Name = "dgvListTimKiem";
            this.dgvListTimKiem.RowHeadersWidth = 51;
            this.dgvListTimKiem.RowTemplate.Height = 23;
            this.dgvListTimKiem.Size = new System.Drawing.Size(578, 376);
            this.dgvListTimKiem.TabIndex = 3;
            this.dgvListTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTimKiem_CellDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxPart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(572, 576);
            this.splitContainer2.SplitterDistance = 95;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxPart
            // 
            this.groupBoxPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBoxPart.Controls.Add(this.btnUpdatePart);
            this.groupBoxPart.Controls.Add(this.txtPartName);
            this.groupBoxPart.Controls.Add(this.txtPartCode);
            this.groupBoxPart.Controls.Add(this.btnAddPart);
            this.groupBoxPart.Controls.Add(this.labelNote4);
            this.groupBoxPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPart.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPart.Name = "groupBoxPart";
            this.groupBoxPart.Size = new System.Drawing.Size(572, 95);
            this.groupBoxPart.TabIndex = 0;
            this.groupBoxPart.TabStop = false;
            this.groupBoxPart.Text = "Update Information of Part";
            // 
            // btnUpdatePart
            // 
            this.btnUpdatePart.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdatePart.Location = new System.Drawing.Point(420, 27);
            this.btnUpdatePart.Name = "btnUpdatePart";
            this.btnUpdatePart.Size = new System.Drawing.Size(114, 54);
            this.btnUpdatePart.TabIndex = 4;
            this.btnUpdatePart.Text = "&Update Part";
            this.btnUpdatePart.UseVisualStyleBackColor = false;
            this.btnUpdatePart.Click += new System.EventHandler(this.btnUpdatePart_Click);
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(123, 52);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(286, 29);
            this.txtPartName.TabIndex = 3;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(278, 21);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(131, 29);
            this.txtPartCode.TabIndex = 3;
            // 
            // btnAddPart
            // 
            this.btnAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddPart.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPart.Image")));
            this.btnAddPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPart.Location = new System.Drawing.Point(9, 50);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(105, 33);
            this.btnAddPart.TabIndex = 1;
            this.btnAddPart.Text = "Add Par&t";
            this.btnAddPart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPart.UseVisualStyleBackColor = false;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // labelNote4
            // 
            this.labelNote4.AutoSize = true;
            this.labelNote4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote4.ForeColor = System.Drawing.Color.Blue;
            this.labelNote4.Location = new System.Drawing.Point(6, 25);
            this.labelNote4.Name = "labelNote4";
            this.labelNote4.Size = new System.Drawing.Size(184, 20);
            this.labelNote4.TabIndex = 0;
            this.labelNote4.Text = "(version, vật liệu, bản vẽ,...)";
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
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer4.Panel1.Controls.Add(this.btnModifyQuantity);
            this.splitContainer4.Panel1.Controls.Add(this.labelParent);
            this.splitContainer4.Panel1.Controls.Add(this.labelNote5);
            this.splitContainer4.Panel1.Controls.Add(this.btnCheckListChild);
            this.splitContainer4.Panel1.Controls.Add(this.btnAddParent);
            this.splitContainer4.Panel1.Controls.Add(this.txtParentName);
            this.splitContainer4.Panel1.Controls.Add(this.txtParentCode);
            this.splitContainer4.Panel1.Controls.Add(this.btnDelete);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvListChild);
            this.splitContainer4.Size = new System.Drawing.Size(572, 475);
            this.splitContainer4.SplitterDistance = 187;
            this.splitContainer4.SplitterWidth = 5;
            this.splitContainer4.TabIndex = 8;
            // 
            // btnModifyQuantity
            // 
            this.btnModifyQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnModifyQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyQuantity.Image")));
            this.btnModifyQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyQuantity.Location = new System.Drawing.Point(394, 92);
            this.btnModifyQuantity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModifyQuantity.Name = "btnModifyQuantity";
            this.btnModifyQuantity.Size = new System.Drawing.Size(166, 33);
            this.btnModifyQuantity.TabIndex = 1;
            this.btnModifyQuantity.Text = "Modify Quantity";
            this.btnModifyQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyQuantity.UseVisualStyleBackColor = false;
            this.btnModifyQuantity.Click += new System.EventHandler(this.btnModifyQuantity_Click);
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Location = new System.Drawing.Point(14, 60);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(100, 23);
            this.labelParent.TabIndex = 7;
            this.labelParent.Text = "Parent Infor";
            // 
            // labelNote5
            // 
            this.labelNote5.AutoSize = true;
            this.labelNote5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote5.ForeColor = System.Drawing.Color.Blue;
            this.labelNote5.Location = new System.Drawing.Point(14, 92);
            this.labelNote5.Name = "labelNote5";
            this.labelNote5.Size = new System.Drawing.Size(339, 80);
            this.labelNote5.TabIndex = 5;
            this.labelNote5.Text = "ECO Relation: \r\n1. Xóa  ràng buộc của 2 Part \r\n( Nếu xóa thì phải tạo lại đó nhé " +
    ")\r\n2. Sửa Quantity của Child Part đối với 1 Parent Part";
            // 
            // btnCheckListChild
            // 
            this.btnCheckListChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCheckListChild.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckListChild.Image")));
            this.btnCheckListChild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckListChild.Location = new System.Drawing.Point(297, 15);
            this.btnCheckListChild.Name = "btnCheckListChild";
            this.btnCheckListChild.Size = new System.Drawing.Size(169, 33);
            this.btnCheckListChild.TabIndex = 6;
            this.btnCheckListChild.Text = "Check List Child";
            this.btnCheckListChild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckListChild.UseVisualStyleBackColor = false;
            this.btnCheckListChild.Click += new System.EventHandler(this.btnCheckListChild_Click);
            // 
            // btnAddParent
            // 
            this.btnAddParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddParent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddParent.Image")));
            this.btnAddParent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddParent.Location = new System.Drawing.Point(10, 15);
            this.btnAddParent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(119, 33);
            this.btnAddParent.TabIndex = 1;
            this.btnAddParent.Text = "Add &Parent";
            this.btnAddParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddParent.UseVisualStyleBackColor = false;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // txtParentName
            // 
            this.txtParentName.Location = new System.Drawing.Point(152, 57);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(408, 29);
            this.txtParentName.TabIndex = 3;
            // 
            // txtParentCode
            // 
            this.txtParentCode.Location = new System.Drawing.Point(152, 17);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(119, 29);
            this.txtParentCode.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(394, 139);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Relation";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // dgvListChild
            // 
            this.dgvListChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListChild.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckcApply,
            this.PartCode,
            this.PartName,
            this.PartQuantity});
            this.dgvListChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListChild.FilterAndSortEnabled = true;
            this.dgvListChild.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListChild.Location = new System.Drawing.Point(0, 0);
            this.dgvListChild.MaxFilterButtonImageHeight = 23;
            this.dgvListChild.Name = "dgvListChild";
            this.dgvListChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListChild.RowHeadersWidth = 51;
            this.dgvListChild.RowTemplate.Height = 24;
            this.dgvListChild.Size = new System.Drawing.Size(572, 283);
            this.dgvListChild.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListChild.TabIndex = 0;
            this.dgvListChild.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListChild_CellDoubleClick);
            this.dgvListChild.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListChild_CellValueChanged);
            this.dgvListChild.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListChild_CurrentCellDirtyStateChanged);
            // 
            // ckcApply
            // 
            this.ckcApply.HeaderText = "";
            this.ckcApply.MinimumWidth = 24;
            this.ckcApply.Name = "ckcApply";
            this.ckcApply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ckcApply.Width = 125;
            // 
            // PartCode
            // 
            this.PartCode.HeaderText = "Part Code";
            this.PartCode.MinimumWidth = 24;
            this.PartCode.Name = "PartCode";
            this.PartCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PartCode.Width = 125;
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Part Name";
            this.PartName.MinimumWidth = 24;
            this.PartName.Name = "PartName";
            this.PartName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PartName.Width = 125;
            // 
            // PartQuantity
            // 
            this.PartQuantity.HeaderText = "Qty";
            this.PartQuantity.MinimumWidth = 24;
            this.PartQuantity.Name = "PartQuantity";
            this.PartQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PartQuantity.Width = 125;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(497, 149);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 33);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmECO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1154, 576);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmECO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ECO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmECO_FormClosing);
            this.Load += new System.EventHandler(this.frmECO_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmECO_KeyDown);
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
            this.groupBoxPart.ResumeLayout(false);
            this.groupBoxPart.PerformLayout();
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
        private System.Windows.Forms.Label labelNote3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxPart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Label labelNote4;
        private System.Windows.Forms.Label labelNote1;
        private System.Windows.Forms.Button btnUpdatePart;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label labelNote2;
        private System.Windows.Forms.Button btnSearchDetail;
        private System.Windows.Forms.Button btnOpenRelationManage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.Label labelNote5;
        private System.Windows.Forms.Button btnCheckListChild;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModifyQuantity;
        private Zuby.ADGV.AdvancedDataGridView dgvListChild;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ckcApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartQuantity;
        private System.Windows.Forms.Button btnExit;
    }
}