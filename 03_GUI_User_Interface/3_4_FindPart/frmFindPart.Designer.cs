namespace PLM_Lynx._03_GUI_User_Interface
{
    partial class frmFindPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindPart));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvListFile = new System.Windows.Forms.DataGridView();
            this.groupboxImagePart = new System.Windows.Forms.GroupBox();
            this.picPart = new System.Windows.Forms.PictureBox();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHighLight = new System.Windows.Forms.TextBox();
            this.btnThemGanDay = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvParent = new System.Windows.Forms.DataGridView();
            this.Panel_Infor_Parent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParentLog = new System.Windows.Forms.TextBox();
            this.groupboxParentImage = new System.Windows.Forms.GroupBox();
            this.picParent = new System.Windows.Forms.PictureBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvChild = new System.Windows.Forms.DataGridView();
            this.Panel_Child_Infor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChildCode = new System.Windows.Forms.TextBox();
            this.txtChildName = new System.Windows.Forms.TextBox();
            this.btnExportOnly = new System.Windows.Forms.Button();
            this.btnExportFile = new System.Windows.Forms.Button();
            this.ckcWithImage = new System.Windows.Forms.CheckBox();
            this.groupboxChildImage = new System.Windows.Forms.GroupBox();
            this.picChild = new System.Windows.Forms.PictureBox();
            this.dgvSearch = new Zuby.ADGV.AdvancedDataGridView();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtStage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.groupboxImagePart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
            this.Panel_Infor_Parent.SuspendLayout();
            this.groupboxParentImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).BeginInit();
            this.Panel_Child_Infor.SuspendLayout();
            this.groupboxChildImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1128, 822);
            this.splitContainer1.SplitterDistance = 566;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 120);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(566, 387);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách chi tiết có thuộc tính";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.txtStage);
            this.groupBox3.Controls.Add(this.txtMaterial);
            this.groupBox3.Controls.Add(this.dgvListFile);
            this.groupBox3.Controls.Add(this.groupboxImagePart);
            this.groupBox3.Controls.Add(this.txtDescript);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.txtCode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 507);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(566, 315);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin của part đang click";
            // 
            // dgvListFile
            // 
            this.dgvListFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.GridColor = System.Drawing.Color.White;
            this.dgvListFile.Location = new System.Drawing.Point(15, 196);
            this.dgvListFile.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.RowHeadersWidth = 51;
            this.dgvListFile.Size = new System.Drawing.Size(493, 89);
            this.dgvListFile.TabIndex = 4;
            // 
            // groupboxImagePart
            // 
            this.groupboxImagePart.Controls.Add(this.picPart);
            this.groupboxImagePart.Location = new System.Drawing.Point(360, 24);
            this.groupboxImagePart.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxImagePart.Name = "groupboxImagePart";
            this.groupboxImagePart.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxImagePart.Size = new System.Drawing.Size(152, 164);
            this.groupboxImagePart.TabIndex = 3;
            this.groupboxImagePart.TabStop = false;
            this.groupboxImagePart.Text = "Image";
            // 
            // picPart
            // 
            this.picPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPart.Location = new System.Drawing.Point(4, 26);
            this.picPart.Margin = new System.Windows.Forms.Padding(4);
            this.picPart.Name = "picPart";
            this.picPart.Size = new System.Drawing.Size(144, 134);
            this.picPart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPart.TabIndex = 2;
            this.picPart.TabStop = false;
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(15, 58);
            this.txtDescript.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.ReadOnly = true;
            this.txtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescript.Size = new System.Drawing.Size(341, 47);
            this.txtDescript.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(263, 29);
            this.txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(15, 25);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(70, 29);
            this.txtCode.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHighLight);
            this.groupBox1.Controls.Add(this.btnThemGanDay);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtKeySearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(566, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập dữ liệu tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(265, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Highlight View";
            // 
            // txtHighLight
            // 
            this.txtHighLight.Location = new System.Drawing.Point(394, 35);
            this.txtHighLight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHighLight.Name = "txtHighLight";
            this.txtHighLight.Size = new System.Drawing.Size(122, 29);
            this.txtHighLight.TabIndex = 5;
            this.txtHighLight.TextChanged += new System.EventHandler(this.txtHighLight_TextChanged);
            // 
            // btnThemGanDay
            // 
            this.btnThemGanDay.Location = new System.Drawing.Point(8, 68);
            this.btnThemGanDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemGanDay.Name = "btnThemGanDay";
            this.btnThemGanDay.Size = new System.Drawing.Size(305, 32);
            this.btnThemGanDay.TabIndex = 3;
            this.btnThemGanDay.Text = "Danh sách thêm gần đây";
            this.btnThemGanDay.UseVisualStyleBackColor = true;
            this.btnThemGanDay.Click += new System.EventHandler(this.btnThemGanDay_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(219, 32);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(8, 35);
            this.txtKeySearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(206, 29);
            this.txtKeySearch.TabIndex = 1;
            this.txtKeySearch.TextChanged += new System.EventHandler(this.txtKeySearch_TextChanged);
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Infor_Parent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Child_Infor, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.98995F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.10553F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.90452F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 822);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgvParent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 182);
            this.panel1.TabIndex = 3;
            // 
            // dgvParent
            // 
            this.dgvParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParent.Location = new System.Drawing.Point(0, 0);
            this.dgvParent.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParent.Name = "dgvParent";
            this.dgvParent.RowHeadersWidth = 51;
            this.dgvParent.RowTemplate.Height = 23;
            this.dgvParent.Size = new System.Drawing.Size(552, 182);
            this.dgvParent.TabIndex = 0;
            this.dgvParent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellDoubleClick);
            this.dgvParent.Click += new System.EventHandler(this.dgvParent_Click);
            // 
            // Panel_Infor_Parent
            // 
            this.Panel_Infor_Parent.AutoScroll = true;
            this.Panel_Infor_Parent.Controls.Add(this.label2);
            this.Panel_Infor_Parent.Controls.Add(this.txtParentLog);
            this.Panel_Infor_Parent.Controls.Add(this.groupboxParentImage);
            this.Panel_Infor_Parent.Controls.Add(this.txtParentName);
            this.Panel_Infor_Parent.Controls.Add(this.txtParentCode);
            this.Panel_Infor_Parent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Infor_Parent.Location = new System.Drawing.Point(3, 191);
            this.Panel_Infor_Parent.Name = "Panel_Infor_Parent";
            this.Panel_Infor_Parent.Size = new System.Drawing.Size(552, 167);
            this.Panel_Infor_Parent.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh sách Part Cha";
            // 
            // txtParentLog
            // 
            this.txtParentLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentLog.Location = new System.Drawing.Point(12, 66);
            this.txtParentLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentLog.Multiline = true;
            this.txtParentLog.Name = "txtParentLog";
            this.txtParentLog.ReadOnly = true;
            this.txtParentLog.Size = new System.Drawing.Size(330, 92);
            this.txtParentLog.TabIndex = 1;
            // 
            // groupboxParentImage
            // 
            this.groupboxParentImage.Controls.Add(this.picParent);
            this.groupboxParentImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupboxParentImage.Location = new System.Drawing.Point(408, 0);
            this.groupboxParentImage.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxParentImage.Name = "groupboxParentImage";
            this.groupboxParentImage.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxParentImage.Size = new System.Drawing.Size(144, 167);
            this.groupboxParentImage.TabIndex = 2;
            this.groupboxParentImage.TabStop = false;
            this.groupboxParentImage.Text = "Image Part Cha Mẹ";
            // 
            // picParent
            // 
            this.picParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picParent.Location = new System.Drawing.Point(4, 24);
            this.picParent.Margin = new System.Windows.Forms.Padding(4);
            this.picParent.Name = "picParent";
            this.picParent.Size = new System.Drawing.Size(136, 139);
            this.picParent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picParent.TabIndex = 0;
            this.picParent.TabStop = false;
            // 
            // txtParentName
            // 
            this.txtParentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentName.Location = new System.Drawing.Point(98, 34);
            this.txtParentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(244, 27);
            this.txtParentName.TabIndex = 1;
            // 
            // txtParentCode
            // 
            this.txtParentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentCode.Location = new System.Drawing.Point(12, 34);
            this.txtParentCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(78, 27);
            this.txtParentCode.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dgvChild);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 364);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 248);
            this.panel2.TabIndex = 5;
            // 
            // dgvChild
            // 
            this.dgvChild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChild.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChild.Location = new System.Drawing.Point(0, 0);
            this.dgvChild.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChild.Name = "dgvChild";
            this.dgvChild.RowHeadersWidth = 51;
            this.dgvChild.RowTemplate.Height = 23;
            this.dgvChild.Size = new System.Drawing.Size(552, 248);
            this.dgvChild.TabIndex = 0;
            this.dgvChild.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChild_CellDoubleClick);
            this.dgvChild.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChild_CellFormatting);
            this.dgvChild.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvChild_CellPainting);
            this.dgvChild.Click += new System.EventHandler(this.dgvChild_Click);
            // 
            // Panel_Child_Infor
            // 
            this.Panel_Child_Infor.AutoScroll = true;
            this.Panel_Child_Infor.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Panel_Child_Infor.Controls.Add(this.label3);
            this.Panel_Child_Infor.Controls.Add(this.txtChildCode);
            this.Panel_Child_Infor.Controls.Add(this.txtChildName);
            this.Panel_Child_Infor.Controls.Add(this.btnExportOnly);
            this.Panel_Child_Infor.Controls.Add(this.btnExportFile);
            this.Panel_Child_Infor.Controls.Add(this.ckcWithImage);
            this.Panel_Child_Infor.Controls.Add(this.groupboxChildImage);
            this.Panel_Child_Infor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Child_Infor.Location = new System.Drawing.Point(3, 618);
            this.Panel_Child_Infor.Name = "Panel_Child_Infor";
            this.Panel_Child_Infor.Size = new System.Drawing.Size(552, 201);
            this.Panel_Child_Infor.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thông tin Part Con";
            // 
            // txtChildCode
            // 
            this.txtChildCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtChildCode.Location = new System.Drawing.Point(16, 36);
            this.txtChildCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtChildCode.Name = "txtChildCode";
            this.txtChildCode.ReadOnly = true;
            this.txtChildCode.Size = new System.Drawing.Size(74, 27);
            this.txtChildCode.TabIndex = 1;
            // 
            // txtChildName
            // 
            this.txtChildName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtChildName.Location = new System.Drawing.Point(102, 36);
            this.txtChildName.Margin = new System.Windows.Forms.Padding(4);
            this.txtChildName.Name = "txtChildName";
            this.txtChildName.ReadOnly = true;
            this.txtChildName.Size = new System.Drawing.Size(269, 27);
            this.txtChildName.TabIndex = 1;
            // 
            // btnExportOnly
            // 
            this.btnExportOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExportOnly.Image = ((System.Drawing.Image)(resources.GetObject("btnExportOnly.Image")));
            this.btnExportOnly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportOnly.Location = new System.Drawing.Point(16, 76);
            this.btnExportOnly.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportOnly.Name = "btnExportOnly";
            this.btnExportOnly.Size = new System.Drawing.Size(131, 45);
            this.btnExportOnly.TabIndex = 4;
            this.btnExportOnly.Text = "Export Excel File";
            this.btnExportOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportOnly.UseVisualStyleBackColor = false;
            this.btnExportOnly.Click += new System.EventHandler(this.btnExportOnly_Click);
            // 
            // btnExportFile
            // 
            this.btnExportFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportFile.Image = ((System.Drawing.Image)(resources.GetObject("btnExportFile.Image")));
            this.btnExportFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportFile.Location = new System.Drawing.Point(170, 76);
            this.btnExportFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportFile.Name = "btnExportFile";
            this.btnExportFile.Size = new System.Drawing.Size(131, 45);
            this.btnExportFile.TabIndex = 4;
            this.btnExportFile.Text = "Export Drawing";
            this.btnExportFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportFile.UseVisualStyleBackColor = false;
            this.btnExportFile.Click += new System.EventHandler(this.btnExportFile_Click);
            // 
            // ckcWithImage
            // 
            this.ckcWithImage.AutoSize = true;
            this.ckcWithImage.Location = new System.Drawing.Point(16, 138);
            this.ckcWithImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckcWithImage.Name = "ckcWithImage";
            this.ckcWithImage.Size = new System.Drawing.Size(108, 24);
            this.ckcWithImage.TabIndex = 5;
            this.ckcWithImage.Text = "With Image";
            this.ckcWithImage.UseVisualStyleBackColor = true;
            // 
            // groupboxChildImage
            // 
            this.groupboxChildImage.Controls.Add(this.picChild);
            this.groupboxChildImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupboxChildImage.Location = new System.Drawing.Point(404, 0);
            this.groupboxChildImage.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxChildImage.Name = "groupboxChildImage";
            this.groupboxChildImage.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxChildImage.Size = new System.Drawing.Size(148, 201);
            this.groupboxChildImage.TabIndex = 3;
            this.groupboxChildImage.TabStop = false;
            this.groupboxChildImage.Text = "Image Part Con";
            // 
            // picChild
            // 
            this.picChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picChild.Location = new System.Drawing.Point(4, 24);
            this.picChild.Margin = new System.Windows.Forms.Padding(4);
            this.picChild.Name = "picChild";
            this.picChild.Size = new System.Drawing.Size(140, 173);
            this.picChild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChild.TabIndex = 2;
            this.picChild.TabStop = false;
            // 
            // dgvSearch
            // 
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearch.FilterAndSortEnabled = true;
            this.dgvSearch.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvSearch.Location = new System.Drawing.Point(4, 26);
            this.dgvSearch.MaxFilterButtonImageHeight = 23;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvSearch.RowHeadersWidth = 51;
            this.dgvSearch.RowTemplate.Height = 24;
            this.dgvSearch.Size = new System.Drawing.Size(558, 357);
            this.dgvSearch.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvSearch.TabIndex = 0;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            this.dgvSearch.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSearch_CellPainting);
            this.dgvSearch.Click += new System.EventHandler(this.dgvSearch_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(219, 120);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(130, 29);
            this.txtMaterial.TabIndex = 5;
            // 
            // txtStage
            // 
            this.txtStage.Location = new System.Drawing.Point(15, 120);
            this.txtStage.Name = "txtStage";
            this.txtStage.ReadOnly = true;
            this.txtStage.Size = new System.Drawing.Size(130, 29);
            this.txtStage.TabIndex = 5;
            // 
            // frmFindPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1128, 822);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFindPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tra cứu ";
            this.Load += new System.EventHandler(this.frmFindPart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.groupboxImagePart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
            this.Panel_Infor_Parent.ResumeLayout(false);
            this.Panel_Infor_Parent.PerformLayout();
            this.groupboxParentImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).EndInit();
            this.Panel_Child_Infor.ResumeLayout(false);
            this.Panel_Child_Infor.PerformLayout();
            this.groupboxChildImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupboxImagePart;
        private System.Windows.Forms.PictureBox picPart;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.Button btnExportOnly;
        private System.Windows.Forms.Button btnExportFile;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupboxChildImage;
        private System.Windows.Forms.PictureBox picChild;
        private System.Windows.Forms.TextBox txtChildCode;
        private System.Windows.Forms.TextBox txtChildName;
        private System.Windows.Forms.DataGridView dgvParent;
        private System.Windows.Forms.GroupBox groupboxParentImage;
        private System.Windows.Forms.PictureBox picParent;
        private System.Windows.Forms.TextBox txtParentLog;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.TextBox txtParentCode;
        private System.Windows.Forms.DataGridView dgvListFile;
        private System.Windows.Forms.Button btnThemGanDay;
        private System.Windows.Forms.TextBox txtHighLight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ckcWithImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel_Infor_Parent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Panel_Child_Infor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvChild;
        private Zuby.ADGV.AdvancedDataGridView dgvSearch;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtStage;
    }
}