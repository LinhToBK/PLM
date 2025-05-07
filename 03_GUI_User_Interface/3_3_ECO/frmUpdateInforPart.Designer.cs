namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    partial class frmUpdateInforPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateInforPart));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboMaterialLib = new System.Windows.Forms.ComboBox();
            this.txtNewMaterial = new System.Windows.Forms.TextBox();
            this.txtPartMaterial = new System.Windows.Forms.TextBox();
            this.txtNoteMore = new System.Windows.Forms.TextBox();
            this.txtListFileStatus = new System.Windows.Forms.TextBox();
            this.cboNewStage = new System.Windows.Forms.ComboBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.txtPartDescript = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.dgvListFile = new System.Windows.Forms.DataGridView();
            this.labelPartCode = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPartNewStage = new System.Windows.Forms.Label();
            this.labelPartListFile = new System.Windows.Forms.Label();
            this.labelPartNote = new System.Windows.Forms.Label();
            this.labelPartNewMaterial = new System.Windows.Forms.Label();
            this.labelPartMaterial = new System.Windows.Forms.Label();
            this.labelPartStage = new System.Windows.Forms.Label();
            this.labelPartDescript = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.dgvECO = new Zuby.ADGV.AdvancedDataGridView();
            this.labelNote1 = new System.Windows.Forms.Label();
            this.labelPartNewListFile = new System.Windows.Forms.Label();
            this.btnAddNewFile = new System.Windows.Forms.Button();
            this.dgvListUpload = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUpload)).BeginInit();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.cboMaterialLib);
            this.splitContainer1.Panel1.Controls.Add(this.txtNewMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.txtNoteMore);
            this.splitContainer1.Panel1.Controls.Add(this.txtListFileStatus);
            this.splitContainer1.Panel1.Controls.Add(this.cboNewStage);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartStage);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartDescript);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartName);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartCode);
            this.splitContainer1.Panel1.Controls.Add(this.dgvListFile);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartCode);
            this.splitContainer1.Panel1.Controls.Add(this.labelTitle);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartNewStage);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartListFile);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartNote);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartNewMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartStage);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartDescript);
            this.splitContainer1.Panel1.Controls.Add(this.labelPartName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1049, 524);
            this.splitContainer1.SplitterDistance = 536;
            this.splitContainer1.TabIndex = 0;
            // 
            // cboMaterialLib
            // 
            this.cboMaterialLib.FormattingEnabled = true;
            this.cboMaterialLib.Location = new System.Drawing.Point(298, 174);
            this.cboMaterialLib.Name = "cboMaterialLib";
            this.cboMaterialLib.Size = new System.Drawing.Size(117, 29);
            this.cboMaterialLib.TabIndex = 7;
            this.cboMaterialLib.SelectedIndexChanged += new System.EventHandler(this.cboMaterialLib_SelectedIndexChanged);
            // 
            // txtNewMaterial
            // 
            this.txtNewMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNewMaterial.Location = new System.Drawing.Point(254, 205);
            this.txtNewMaterial.Name = "txtNewMaterial";
            this.txtNewMaterial.Size = new System.Drawing.Size(161, 29);
            this.txtNewMaterial.TabIndex = 6;
            // 
            // txtPartMaterial
            // 
            this.txtPartMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPartMaterial.Location = new System.Drawing.Point(120, 174);
            this.txtPartMaterial.Name = "txtPartMaterial";
            this.txtPartMaterial.ReadOnly = true;
            this.txtPartMaterial.Size = new System.Drawing.Size(161, 29);
            this.txtPartMaterial.TabIndex = 6;
            // 
            // txtNoteMore
            // 
            this.txtNoteMore.Location = new System.Drawing.Point(171, 240);
            this.txtNoteMore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNoteMore.Multiline = true;
            this.txtNoteMore.Name = "txtNoteMore";
            this.txtNoteMore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNoteMore.Size = new System.Drawing.Size(317, 47);
            this.txtNoteMore.TabIndex = 5;
            // 
            // txtListFileStatus
            // 
            this.txtListFileStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtListFileStatus.Location = new System.Drawing.Point(280, 299);
            this.txtListFileStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtListFileStatus.Name = "txtListFileStatus";
            this.txtListFileStatus.ReadOnly = true;
            this.txtListFileStatus.Size = new System.Drawing.Size(208, 22);
            this.txtListFileStatus.TabIndex = 4;
            // 
            // cboNewStage
            // 
            this.cboNewStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboNewStage.FormattingEnabled = true;
            this.cboNewStage.Location = new System.Drawing.Point(408, 140);
            this.cboNewStage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNewStage.Name = "cboNewStage";
            this.cboNewStage.Size = new System.Drawing.Size(80, 29);
            this.cboNewStage.TabIndex = 3;
            // 
            // txtPartStage
            // 
            this.txtPartStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPartStage.Location = new System.Drawing.Point(120, 140);
            this.txtPartStage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(87, 29);
            this.txtPartStage.TabIndex = 2;
            // 
            // txtPartDescript
            // 
            this.txtPartDescript.BackColor = System.Drawing.SystemColors.Info;
            this.txtPartDescript.Location = new System.Drawing.Point(120, 86);
            this.txtPartDescript.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartDescript.Multiline = true;
            this.txtPartDescript.Name = "txtPartDescript";
            this.txtPartDescript.Size = new System.Drawing.Size(368, 45);
            this.txtPartDescript.TabIndex = 2;
            // 
            // txtPartName
            // 
            this.txtPartName.BackColor = System.Drawing.SystemColors.Info;
            this.txtPartName.Location = new System.Drawing.Point(120, 48);
            this.txtPartName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(368, 29);
            this.txtPartName.TabIndex = 1;
            // 
            // txtPartCode
            // 
            this.txtPartCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartCode.Location = new System.Drawing.Point(120, 10);
            this.txtPartCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(100, 29);
            this.txtPartCode.TabIndex = 2;
            // 
            // dgvListFile
            // 
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListFile.Location = new System.Drawing.Point(0, 327);
            this.dgvListFile.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.RowHeadersWidth = 51;
            this.dgvListFile.Size = new System.Drawing.Size(536, 197);
            this.dgvListFile.TabIndex = 1;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // labelPartCode
            // 
            this.labelPartCode.AutoSize = true;
            this.labelPartCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartCode.Location = new System.Drawing.Point(13, 13);
            this.labelPartCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartCode.Name = "labelPartCode";
            this.labelPartCode.Size = new System.Drawing.Size(85, 23);
            this.labelPartCode.TabIndex = 0;
            this.labelPartCode.Text = "Part Code";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(243, 9);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(271, 28);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Update information of part";
            // 
            // labelPartNewStage
            // 
            this.labelPartNewStage.AutoSize = true;
            this.labelPartNewStage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartNewStage.Location = new System.Drawing.Point(217, 144);
            this.labelPartNewStage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartNewStage.Name = "labelPartNewStage";
            this.labelPartNewStage.Size = new System.Drawing.Size(176, 23);
            this.labelPartNewStage.TabIndex = 0;
            this.labelPartNewStage.Text = "=>Update New Stage";
            // 
            // labelPartListFile
            // 
            this.labelPartListFile.AutoSize = true;
            this.labelPartListFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartListFile.Location = new System.Drawing.Point(13, 298);
            this.labelPartListFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartListFile.Name = "labelPartListFile";
            this.labelPartListFile.Size = new System.Drawing.Size(206, 23);
            this.labelPartListFile.TabIndex = 0;
            this.labelPartListFile.Text = "Danh sách file trong code";
            // 
            // labelPartNote
            // 
            this.labelPartNote.AutoSize = true;
            this.labelPartNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartNote.Location = new System.Drawing.Point(8, 254);
            this.labelPartNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartNote.Name = "labelPartNote";
            this.labelPartNote.Size = new System.Drawing.Size(93, 23);
            this.labelPartNote.TabIndex = 0;
            this.labelPartNote.Text = "Note More";
            // 
            // labelPartNewMaterial
            // 
            this.labelPartNewMaterial.AutoSize = true;
            this.labelPartNewMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartNewMaterial.Location = new System.Drawing.Point(13, 209);
            this.labelPartNewMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartNewMaterial.Name = "labelPartNewMaterial";
            this.labelPartNewMaterial.Size = new System.Drawing.Size(196, 23);
            this.labelPartNewMaterial.TabIndex = 0;
            this.labelPartNewMaterial.Text = "=>Update New Material";
            // 
            // labelPartMaterial
            // 
            this.labelPartMaterial.AutoSize = true;
            this.labelPartMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartMaterial.Location = new System.Drawing.Point(13, 178);
            this.labelPartMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartMaterial.Name = "labelPartMaterial";
            this.labelPartMaterial.Size = new System.Drawing.Size(107, 23);
            this.labelPartMaterial.TabIndex = 0;
            this.labelPartMaterial.Text = "Part Material";
            // 
            // labelPartStage
            // 
            this.labelPartStage.AutoSize = true;
            this.labelPartStage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartStage.Location = new System.Drawing.Point(11, 144);
            this.labelPartStage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartStage.Name = "labelPartStage";
            this.labelPartStage.Size = new System.Drawing.Size(87, 23);
            this.labelPartStage.TabIndex = 0;
            this.labelPartStage.Text = "Part Stage";
            // 
            // labelPartDescript
            // 
            this.labelPartDescript.AutoSize = true;
            this.labelPartDescript.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartDescript.Location = new System.Drawing.Point(9, 96);
            this.labelPartDescript.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartDescript.Name = "labelPartDescript";
            this.labelPartDescript.Size = new System.Drawing.Size(107, 23);
            this.labelPartDescript.TabIndex = 0;
            this.labelPartDescript.Text = "Part Descript";
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPartName.Location = new System.Drawing.Point(11, 51);
            this.labelPartName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(91, 23);
            this.labelPartName.TabIndex = 0;
            this.labelPartName.Text = "Part Name";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteFile);
            this.splitContainer2.Panel1.Controls.Add(this.dgvECO);
            this.splitContainer2.Panel1.Controls.Add(this.labelNote1);
            this.splitContainer2.Panel1.Controls.Add(this.labelPartNewListFile);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddNewFile);
            this.splitContainer2.Panel1.Controls.Add(this.dgvListUpload);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExit);
            this.splitContainer2.Panel2.Controls.Add(this.btnUpload);
            this.splitContainer2.Size = new System.Drawing.Size(509, 524);
            this.splitContainer2.SplitterDistance = 441;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFile.Location = new System.Drawing.Point(382, 186);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(112, 30);
            this.btnDeleteFile.TabIndex = 1;
            this.btnDeleteFile.Text = "&Delete File";
            this.btnDeleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // dgvECO
            // 
            this.dgvECO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECO.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvECO.FilterAndSortEnabled = true;
            this.dgvECO.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECO.Location = new System.Drawing.Point(0, 0);
            this.dgvECO.MaxFilterButtonImageHeight = 23;
            this.dgvECO.Name = "dgvECO";
            this.dgvECO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvECO.RowHeadersWidth = 51;
            this.dgvECO.RowTemplate.Height = 24;
            this.dgvECO.Size = new System.Drawing.Size(509, 167);
            this.dgvECO.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvECO.TabIndex = 3;
            this.dgvECO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvECO_CellDoubleClick);
            // 
            // labelNote1
            // 
            this.labelNote1.AutoSize = true;
            this.labelNote1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote1.ForeColor = System.Drawing.Color.Blue;
            this.labelNote1.Location = new System.Drawing.Point(13, 178);
            this.labelNote1.Name = "labelNote1";
            this.labelNote1.Size = new System.Drawing.Size(372, 46);
            this.labelNote1.TabIndex = 2;
            this.labelNote1.Text = "1. Có thể kéo thả vào vùng upload file\r\n2. Chọn 1 dòng thì mới nhấn được \"Delete " +
    "File\"";
            // 
            // labelPartNewListFile
            // 
            this.labelPartNewListFile.AutoSize = true;
            this.labelPartNewListFile.Location = new System.Drawing.Point(13, 231);
            this.labelPartNewListFile.Name = "labelPartNewListFile";
            this.labelPartNewListFile.Size = new System.Drawing.Size(298, 23);
            this.labelPartNewListFile.TabIndex = 2;
            this.labelPartNewListFile.Text = "Danh sách file updaload lên DataBase";
            // 
            // btnAddNewFile
            // 
            this.btnAddNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewFile.Image")));
            this.btnAddNewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewFile.Location = new System.Drawing.Point(382, 227);
            this.btnAddNewFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewFile.Name = "btnAddNewFile";
            this.btnAddNewFile.Size = new System.Drawing.Size(112, 30);
            this.btnAddNewFile.TabIndex = 1;
            this.btnAddNewFile.Text = "&Add File";
            this.btnAddNewFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewFile.UseVisualStyleBackColor = true;
            this.btnAddNewFile.Click += new System.EventHandler(this.btnAddNewFile_Click);
            // 
            // dgvListUpload
            // 
            this.dgvListUpload.AllowDrop = true;
            this.dgvListUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListUpload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListUpload.Location = new System.Drawing.Point(0, 265);
            this.dgvListUpload.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListUpload.Name = "dgvListUpload";
            this.dgvListUpload.RowHeadersWidth = 51;
            this.dgvListUpload.Size = new System.Drawing.Size(509, 176);
            this.dgvListUpload.TabIndex = 0;
            this.dgvListUpload.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvListUpload_DragDrop);
            this.dgvListUpload.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvListUpload_DragEnter);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(290, 12);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(27, 12);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(198, 40);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Make a ECO request";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // frmUpdateInforPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1049, 524);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUpdateInforPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Infor Part";
            this.Load += new System.EventHandler(this.frmUpdateInforPart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvECO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUpload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvListFile;
        private System.Windows.Forms.Label labelPartCode;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPartNewStage;
        private System.Windows.Forms.Label labelPartStage;
        private System.Windows.Forms.Label labelPartDescript;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.ComboBox cboNewStage;
        private System.Windows.Forms.TextBox txtPartStage;
        private System.Windows.Forms.TextBox txtPartDescript;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddNewFile;
        private System.Windows.Forms.DataGridView dgvListUpload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label labelPartListFile;
        private System.Windows.Forms.Label labelNote1;
        private System.Windows.Forms.TextBox txtListFileStatus;
        private System.Windows.Forms.TextBox txtNoteMore;
        private System.Windows.Forms.Label labelPartNote;
        private System.Windows.Forms.Label labelPartNewMaterial;
        private System.Windows.Forms.Label labelPartMaterial;
        private System.Windows.Forms.TextBox txtNewMaterial;
        private System.Windows.Forms.TextBox txtPartMaterial;
        private System.Windows.Forms.ComboBox cboMaterialLib;
        private Zuby.ADGV.AdvancedDataGridView dgvECO;
        private System.Windows.Forms.Label labelPartNewListFile;
    }
}