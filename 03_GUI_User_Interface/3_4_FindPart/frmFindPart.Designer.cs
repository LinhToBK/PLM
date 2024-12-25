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
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvListFile = new System.Windows.Forms.DataGridView();
            this.groupboxImagePart = new System.Windows.Forms.GroupBox();
            this.picPart = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHighLight = new System.Windows.Forms.TextBox();
            this.btnThemGanDay = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckcPDF = new System.Windows.Forms.CheckBox();
            this.ckcSTP = new System.Windows.Forms.CheckBox();
            this.ckcDWG = new System.Windows.Forms.CheckBox();
            this.ckcJPG = new System.Windows.Forms.CheckBox();
            this.ckcWithImage = new System.Windows.Forms.CheckBox();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnExportOnly = new System.Windows.Forms.Button();
            this.groupboxChildImage = new System.Windows.Forms.GroupBox();
            this.picChild = new System.Windows.Forms.PictureBox();
            this.txtChildCode = new System.Windows.Forms.TextBox();
            this.txtChildName = new System.Windows.Forms.TextBox();
            this.dgvParent = new System.Windows.Forms.DataGridView();
            this.dgvChild = new System.Windows.Forms.DataGridView();
            this.groupboxParent = new System.Windows.Forms.GroupBox();
            this.groupboxParentImage = new System.Windows.Forms.GroupBox();
            this.picParent = new System.Windows.Forms.PictureBox();
            this.txtParentLog = new System.Windows.Forms.TextBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.txtParentCode = new System.Windows.Forms.TextBox();
            this.ckcPRT = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.groupboxImagePart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupboxChildImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).BeginInit();
            this.groupboxParent.SuspendLayout();
            this.groupboxParentImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 658);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(514, 321);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách chi tiết có thuộc tính";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearch.Location = new System.Drawing.Point(4, 18);
            this.dgvSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowTemplate.Height = 23;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSearch.Size = new System.Drawing.Size(506, 300);
            this.dgvSearch.TabIndex = 0;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            this.dgvSearch.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSearch_CellPainting);
            this.dgvSearch.Click += new System.EventHandler(this.dgvSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvListFile);
            this.groupBox3.Controls.Add(this.groupboxImagePart);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Controls.Add(this.txtDescript);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.txtCode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 423);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(514, 235);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin của part đang click";
            // 
            // dgvListFile
            // 
            this.dgvListFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListFile.GridColor = System.Drawing.Color.White;
            this.dgvListFile.Location = new System.Drawing.Point(4, 161);
            this.dgvListFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.Size = new System.Drawing.Size(506, 71);
            this.dgvListFile.TabIndex = 4;
            // 
            // groupboxImagePart
            // 
            this.groupboxImagePart.Controls.Add(this.picPart);
            this.groupboxImagePart.Location = new System.Drawing.Point(360, 19);
            this.groupboxImagePart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxImagePart.Name = "groupboxImagePart";
            this.groupboxImagePart.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxImagePart.Size = new System.Drawing.Size(152, 131);
            this.groupboxImagePart.TabIndex = 3;
            this.groupboxImagePart.TabStop = false;
            this.groupboxImagePart.Text = "Image";
            // 
            // picPart
            // 
            this.picPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPart.Location = new System.Drawing.Point(4, 18);
            this.picPart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picPart.Name = "picPart";
            this.picPart.Size = new System.Drawing.Size(144, 110);
            this.picPart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPart.TabIndex = 2;
            this.picPart.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 99);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(338, 49);
            this.txtLog.TabIndex = 1;
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(15, 46);
            this.txtDescript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.ReadOnly = true;
            this.txtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescript.Size = new System.Drawing.Size(341, 47);
            this.txtDescript.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(263, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(15, 20);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(70, 22);
            this.txtCode.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHighLight);
            this.groupBox1.Controls.Add(this.btnThemGanDay);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtKeySearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(514, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập dữ liệu tìm kiếm";
            // 
            // btnFilter
            // 
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(364, 46);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 21);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Filter Search";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(254, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Highlight View";
            // 
            // txtHighLight
            // 
            this.txtHighLight.Location = new System.Drawing.Point(364, 73);
            this.txtHighLight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHighLight.Name = "txtHighLight";
            this.txtHighLight.Size = new System.Drawing.Size(122, 22);
            this.txtHighLight.TabIndex = 5;
            this.txtHighLight.TextChanged += new System.EventHandler(this.txtHighLight_TextChanged);
            // 
            // btnThemGanDay
            // 
            this.btnThemGanDay.Location = new System.Drawing.Point(8, 54);
            this.btnThemGanDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnThemGanDay.Name = "btnThemGanDay";
            this.btnThemGanDay.Size = new System.Drawing.Size(111, 40);
            this.btnThemGanDay.TabIndex = 3;
            this.btnThemGanDay.Text = "Danh sách \r\nthêm gần đây";
            this.btnThemGanDay.UseVisualStyleBackColor = true;
            this.btnThemGanDay.Click += new System.EventHandler(this.btnThemGanDay_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(222, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(8, 28);
            this.txtKeySearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.Size = new System.Drawing.Size(206, 22);
            this.txtKeySearch.TabIndex = 1;
            this.txtKeySearch.TextChanged += new System.EventHandler(this.txtKeySearch_TextChanged);
            this.txtKeySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvParent, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvChild, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupboxParent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 658);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckcPRT);
            this.groupBox6.Controls.Add(this.ckcPDF);
            this.groupBox6.Controls.Add(this.ckcSTP);
            this.groupBox6.Controls.Add(this.ckcDWG);
            this.groupBox6.Controls.Add(this.ckcJPG);
            this.groupBox6.Controls.Add(this.ckcWithImage);
            this.groupBox6.Controls.Add(this.btnExportAll);
            this.groupBox6.Controls.Add(this.btnExportOnly);
            this.groupBox6.Controls.Add(this.groupboxChildImage);
            this.groupBox6.Controls.Add(this.txtChildCode);
            this.groupBox6.Controls.Add(this.txtChildName);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(4, 480);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(497, 153);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách Part Con";
            // 
            // ckcPDF
            // 
            this.ckcPDF.AutoSize = true;
            this.ckcPDF.Location = new System.Drawing.Point(305, 70);
            this.ckcPDF.Name = "ckcPDF";
            this.ckcPDF.Size = new System.Drawing.Size(47, 19);
            this.ckcPDF.TabIndex = 6;
            this.ckcPDF.Text = ".pdf";
            this.ckcPDF.UseVisualStyleBackColor = true;
            // 
            // ckcSTP
            // 
            this.ckcSTP.AutoSize = true;
            this.ckcSTP.Location = new System.Drawing.Point(227, 95);
            this.ckcSTP.Name = "ckcSTP";
            this.ckcSTP.Size = new System.Drawing.Size(76, 19);
            this.ckcSTP.TabIndex = 6;
            this.ckcSTP.Text = ".stp/.step";
            this.ckcSTP.UseVisualStyleBackColor = true;
            // 
            // ckcDWG
            // 
            this.ckcDWG.AutoSize = true;
            this.ckcDWG.Location = new System.Drawing.Point(227, 70);
            this.ckcDWG.Name = "ckcDWG";
            this.ckcDWG.Size = new System.Drawing.Size(72, 19);
            this.ckcDWG.TabIndex = 6;
            this.ckcDWG.Text = ".dwg/dxf";
            this.ckcDWG.UseVisualStyleBackColor = true;
            // 
            // ckcJPG
            // 
            this.ckcJPG.AutoSize = true;
            this.ckcJPG.Location = new System.Drawing.Point(305, 95);
            this.ckcJPG.Name = "ckcJPG";
            this.ckcJPG.Size = new System.Drawing.Size(46, 19);
            this.ckcJPG.TabIndex = 6;
            this.ckcJPG.Text = ".jpg";
            this.ckcJPG.UseVisualStyleBackColor = true;
            // 
            // ckcWithImage
            // 
            this.ckcWithImage.AutoSize = true;
            this.ckcWithImage.Location = new System.Drawing.Point(15, 118);
            this.ckcWithImage.Name = "ckcWithImage";
            this.ckcWithImage.Size = new System.Drawing.Size(87, 19);
            this.ckcWithImage.TabIndex = 5;
            this.ckcWithImage.Text = "With Image";
            this.ckcWithImage.UseVisualStyleBackColor = true;
            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExportAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExportAll.Image")));
            this.btnExportAll.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportAll.Location = new System.Drawing.Point(154, 70);
            this.btnExportAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(66, 77);
            this.btnExportAll.TabIndex = 4;
            this.btnExportAll.Text = "Export Drawing";
            this.btnExportAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportOnly
            // 
            this.btnExportOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExportOnly.Image = ((System.Drawing.Image)(resources.GetObject("btnExportOnly.Image")));
            this.btnExportOnly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportOnly.Location = new System.Drawing.Point(15, 70);
            this.btnExportOnly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportOnly.Name = "btnExportOnly";
            this.btnExportOnly.Size = new System.Drawing.Size(122, 36);
            this.btnExportOnly.TabIndex = 4;
            this.btnExportOnly.Text = "Export Excel File";
            this.btnExportOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportOnly.UseVisualStyleBackColor = false;
            this.btnExportOnly.Click += new System.EventHandler(this.btnExportOnly_Click);
            // 
            // groupboxChildImage
            // 
            this.groupboxChildImage.Controls.Add(this.picChild);
            this.groupboxChildImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupboxChildImage.Location = new System.Drawing.Point(374, 18);
            this.groupboxChildImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxChildImage.Name = "groupboxChildImage";
            this.groupboxChildImage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxChildImage.Size = new System.Drawing.Size(119, 132);
            this.groupboxChildImage.TabIndex = 3;
            this.groupboxChildImage.TabStop = false;
            this.groupboxChildImage.Text = "Image Part Con";
            // 
            // picChild
            // 
            this.picChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picChild.Location = new System.Drawing.Point(4, 18);
            this.picChild.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picChild.Name = "picChild";
            this.picChild.Size = new System.Drawing.Size(111, 111);
            this.picChild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChild.TabIndex = 2;
            this.picChild.TabStop = false;
            // 
            // txtChildCode
            // 
            this.txtChildCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtChildCode.Location = new System.Drawing.Point(15, 33);
            this.txtChildCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtChildCode.Name = "txtChildCode";
            this.txtChildCode.ReadOnly = true;
            this.txtChildCode.Size = new System.Drawing.Size(74, 22);
            this.txtChildCode.TabIndex = 1;
            // 
            // txtChildName
            // 
            this.txtChildName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtChildName.Location = new System.Drawing.Point(97, 33);
            this.txtChildName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtChildName.Name = "txtChildName";
            this.txtChildName.ReadOnly = true;
            this.txtChildName.Size = new System.Drawing.Size(269, 22);
            this.txtChildName.TabIndex = 1;
            // 
            // dgvParent
            // 
            this.dgvParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParent.Location = new System.Drawing.Point(4, 3);
            this.dgvParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvParent.Name = "dgvParent";
            this.dgvParent.RowTemplate.Height = 23;
            this.dgvParent.Size = new System.Drawing.Size(497, 153);
            this.dgvParent.TabIndex = 0;
            this.dgvParent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellDoubleClick);
            this.dgvParent.Click += new System.EventHandler(this.dgvParent_Click);
            // 
            // dgvChild
            // 
            this.dgvChild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChild.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChild.Location = new System.Drawing.Point(4, 321);
            this.dgvChild.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvChild.Name = "dgvChild";
            this.dgvChild.RowTemplate.Height = 23;
            this.dgvChild.Size = new System.Drawing.Size(497, 153);
            this.dgvChild.TabIndex = 0;
            this.dgvChild.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChild_CellDoubleClick);
            this.dgvChild.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChild_CellFormatting);
            this.dgvChild.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvChild_CellPainting);
            this.dgvChild.Click += new System.EventHandler(this.dgvChild_Click);
            // 
            // groupboxParent
            // 
            this.groupboxParent.Controls.Add(this.groupboxParentImage);
            this.groupboxParent.Controls.Add(this.txtParentLog);
            this.groupboxParent.Controls.Add(this.txtParentName);
            this.groupboxParent.Controls.Add(this.txtParentCode);
            this.groupboxParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupboxParent.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxParent.Location = new System.Drawing.Point(4, 162);
            this.groupboxParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxParent.Name = "groupboxParent";
            this.groupboxParent.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxParent.Size = new System.Drawing.Size(497, 153);
            this.groupboxParent.TabIndex = 0;
            this.groupboxParent.TabStop = false;
            this.groupboxParent.Text = "Danh sách Part Cha Mẹ";
            // 
            // groupboxParentImage
            // 
            this.groupboxParentImage.Controls.Add(this.picParent);
            this.groupboxParentImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupboxParentImage.Location = new System.Drawing.Point(374, 18);
            this.groupboxParentImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxParentImage.Name = "groupboxParentImage";
            this.groupboxParentImage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupboxParentImage.Size = new System.Drawing.Size(119, 132);
            this.groupboxParentImage.TabIndex = 2;
            this.groupboxParentImage.TabStop = false;
            this.groupboxParentImage.Text = "Image Part Cha Mẹ";
            // 
            // picParent
            // 
            this.picParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picParent.Location = new System.Drawing.Point(4, 18);
            this.picParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picParent.Name = "picParent";
            this.picParent.Size = new System.Drawing.Size(111, 111);
            this.picParent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picParent.TabIndex = 0;
            this.picParent.TabStop = false;
            // 
            // txtParentLog
            // 
            this.txtParentLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentLog.Location = new System.Drawing.Point(0, 53);
            this.txtParentLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtParentLog.Multiline = true;
            this.txtParentLog.Name = "txtParentLog";
            this.txtParentLog.ReadOnly = true;
            this.txtParentLog.Size = new System.Drawing.Size(324, 94);
            this.txtParentLog.TabIndex = 1;
            // 
            // txtParentName
            // 
            this.txtParentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentName.Location = new System.Drawing.Point(105, 19);
            this.txtParentName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.ReadOnly = true;
            this.txtParentName.Size = new System.Drawing.Size(219, 22);
            this.txtParentName.TabIndex = 1;
            // 
            // txtParentCode
            // 
            this.txtParentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtParentCode.Location = new System.Drawing.Point(7, 19);
            this.txtParentCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtParentCode.Name = "txtParentCode";
            this.txtParentCode.ReadOnly = true;
            this.txtParentCode.Size = new System.Drawing.Size(78, 22);
            this.txtParentCode.TabIndex = 1;
            // 
            // ckcPRT
            // 
            this.ckcPRT.AutoSize = true;
            this.ckcPRT.Location = new System.Drawing.Point(227, 121);
            this.ckcPRT.Name = "ckcPRT";
            this.ckcPRT.Size = new System.Drawing.Size(44, 19);
            this.ckcPRT.TabIndex = 7;
            this.ckcPRT.Text = ".prt";
            this.ckcPRT.UseVisualStyleBackColor = true;
            // 
            // frmFindPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 658);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmFindPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tra cứu ";
            this.Load += new System.EventHandler(this.frmFindPart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.groupboxImagePart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupboxChildImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).EndInit();
            this.groupboxParent.ResumeLayout(false);
            this.groupboxParent.PerformLayout();
            this.groupboxParentImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupboxParent;
        private System.Windows.Forms.Button btnExportOnly;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvChild;
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
        public System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.TextBox txtHighLight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ckcPDF;
        private System.Windows.Forms.CheckBox ckcSTP;
        private System.Windows.Forms.CheckBox ckcDWG;
        private System.Windows.Forms.CheckBox ckcJPG;
        private System.Windows.Forms.CheckBox ckcWithImage;
        private System.Windows.Forms.CheckBox ckcPRT;
    }
}