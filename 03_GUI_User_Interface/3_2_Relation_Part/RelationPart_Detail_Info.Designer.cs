namespace PLM_Lynx._03_GUI_User_Interface
{
    partial class frmRelationPart_Detail_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelationPart_Detail_Info));
            this.labelPartCode = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.labelPartDescription = new System.Windows.Forms.Label();
            this.labelPartStage = new System.Windows.Forms.Label();
            this.PicPart = new System.Windows.Forms.PictureBox();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartDescription = new System.Windows.Forms.TextBox();
            this.txtPartStage = new System.Windows.Forms.TextBox();
            this.txtPicStatus = new System.Windows.Forms.TextBox();
            this.labelNote1 = new System.Windows.Forms.Label();
            this.btnDownLoadFile = new System.Windows.Forms.Button();
            this.labelNote2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_PartInfor = new System.Windows.Forms.Panel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.txtPartMaterial = new System.Windows.Forms.TextBox();
            this.labelPartMaterial = new System.Windows.Forms.Label();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelPartPrice = new System.Windows.Forms.Label();
            this.Panel_Download = new System.Windows.Forms.Panel();
            this.dgvListFile = new Zuby.ADGV.AdvancedDataGridView();
            this.PanelDataGridView = new System.Windows.Forms.Panel();
            this.dgvListECO = new Zuby.ADGV.AdvancedDataGridView();
            this.dgvChild = new Zuby.ADGV.AdvancedDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel_PartInfor.SuspendLayout();
            this.Panel_Download.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).BeginInit();
            this.PanelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListECO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPartCode
            // 
            this.labelPartCode.AutoSize = true;
            this.labelPartCode.Location = new System.Drawing.Point(9, 39);
            this.labelPartCode.Name = "labelPartCode";
            this.labelPartCode.Size = new System.Drawing.Size(85, 23);
            this.labelPartCode.TabIndex = 0;
            this.labelPartCode.Text = "Part Code";
            this.labelPartCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(9, 83);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(91, 23);
            this.labelPartName.TabIndex = 0;
            this.labelPartName.Text = "Part Name";
            this.labelPartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPartDescription
            // 
            this.labelPartDescription.AutoSize = true;
            this.labelPartDescription.Location = new System.Drawing.Point(9, 179);
            this.labelPartDescription.Name = "labelPartDescription";
            this.labelPartDescription.Size = new System.Drawing.Size(96, 23);
            this.labelPartDescription.TabIndex = 0;
            this.labelPartDescription.Text = "Description";
            this.labelPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPartDescription.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelPartStage
            // 
            this.labelPartStage.AutoSize = true;
            this.labelPartStage.Location = new System.Drawing.Point(250, 39);
            this.labelPartStage.Name = "labelPartStage";
            this.labelPartStage.Size = new System.Drawing.Size(115, 23);
            this.labelPartStage.TabIndex = 0;
            this.labelPartStage.Text = "Current Stage";
            this.labelPartStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicPart
            // 
            this.PicPart.Location = new System.Drawing.Point(523, 9);
            this.PicPart.Name = "PicPart";
            this.PicPart.Size = new System.Drawing.Size(142, 107);
            this.PicPart.TabIndex = 1;
            this.PicPart.TabStop = false;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(106, 36);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.ReadOnly = true;
            this.txtPartCode.Size = new System.Drawing.Size(126, 29);
            this.txtPartCode.TabIndex = 3;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(106, 80);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.ReadOnly = true;
            this.txtPartName.Size = new System.Drawing.Size(393, 29);
            this.txtPartName.TabIndex = 3;
            // 
            // txtPartDescription
            // 
            this.txtPartDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPartDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPartDescription.Location = new System.Drawing.Point(106, 176);
            this.txtPartDescription.Name = "txtPartDescription";
            this.txtPartDescription.ReadOnly = true;
            this.txtPartDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPartDescription.Size = new System.Drawing.Size(559, 29);
            this.txtPartDescription.TabIndex = 3;
            // 
            // txtPartStage
            // 
            this.txtPartStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartStage.Location = new System.Drawing.Point(371, 36);
            this.txtPartStage.Name = "txtPartStage";
            this.txtPartStage.ReadOnly = true;
            this.txtPartStage.Size = new System.Drawing.Size(128, 29);
            this.txtPartStage.TabIndex = 3;
            // 
            // txtPicStatus
            // 
            this.txtPicStatus.Location = new System.Drawing.Point(574, 124);
            this.txtPicStatus.Name = "txtPicStatus";
            this.txtPicStatus.ReadOnly = true;
            this.txtPicStatus.Size = new System.Drawing.Size(91, 29);
            this.txtPicStatus.TabIndex = 3;
            this.txtPicStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNote1
            // 
            this.labelNote1.AutoSize = true;
            this.labelNote1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelNote1.Location = new System.Drawing.Point(9, 10);
            this.labelNote1.Name = "labelNote1";
            this.labelNote1.Size = new System.Drawing.Size(284, 20);
            this.labelNote1.TabIndex = 5;
            this.labelNote1.Text = "Có thể nhấn \"Esc\" để thoát khỏi form này ";
            this.labelNote1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownLoadFile
            // 
            this.btnDownLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDownLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDownLoadFile.Image")));
            this.btnDownLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownLoadFile.Location = new System.Drawing.Point(13, 213);
            this.btnDownLoadFile.Name = "btnDownLoadFile";
            this.btnDownLoadFile.Size = new System.Drawing.Size(154, 35);
            this.btnDownLoadFile.TabIndex = 0;
            this.btnDownLoadFile.Text = "DownLoad File";
            this.btnDownLoadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownLoadFile.UseVisualStyleBackColor = false;
            this.btnDownLoadFile.Click += new System.EventHandler(this.btnDownLoadFile_Click);
            // 
            // labelNote2
            // 
            this.labelNote2.AutoSize = true;
            this.labelNote2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote2.ForeColor = System.Drawing.Color.Blue;
            this.labelNote2.Location = new System.Drawing.Point(191, 219);
            this.labelNote2.Name = "labelNote2";
            this.labelNote2.Size = new System.Drawing.Size(360, 20);
            this.labelNote2.TabIndex = 7;
            this.labelNote2.Text = "Chọn hàng cần download. Giữ Ctrl để chọn nhiều hàng";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Panel_PartInfor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Download, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PanelDataGridView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 669);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Panel_PartInfor
            // 
            this.Panel_PartInfor.AutoScroll = true;
            this.Panel_PartInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panel_PartInfor.Controls.Add(this.btnExpand);
            this.Panel_PartInfor.Controls.Add(this.btnCollapse);
            this.Panel_PartInfor.Controls.Add(this.labelNote2);
            this.Panel_PartInfor.Controls.Add(this.btnDownLoadFile);
            this.Panel_PartInfor.Controls.Add(this.txtPartMaterial);
            this.Panel_PartInfor.Controls.Add(this.labelPartMaterial);
            this.Panel_PartInfor.Controls.Add(this.txtPartName);
            this.Panel_PartInfor.Controls.Add(this.txtPartPrice);
            this.Panel_PartInfor.Controls.Add(this.txtPartStage);
            this.Panel_PartInfor.Controls.Add(this.label9);
            this.Panel_PartInfor.Controls.Add(this.labelPartPrice);
            this.Panel_PartInfor.Controls.Add(this.labelPartStage);
            this.Panel_PartInfor.Controls.Add(this.labelNote1);
            this.Panel_PartInfor.Controls.Add(this.txtPartDescription);
            this.Panel_PartInfor.Controls.Add(this.txtPicStatus);
            this.Panel_PartInfor.Controls.Add(this.PicPart);
            this.Panel_PartInfor.Controls.Add(this.labelPartCode);
            this.Panel_PartInfor.Controls.Add(this.txtPartCode);
            this.Panel_PartInfor.Controls.Add(this.labelPartDescription);
            this.Panel_PartInfor.Controls.Add(this.labelPartName);
            this.Panel_PartInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_PartInfor.Location = new System.Drawing.Point(3, 3);
            this.Panel_PartInfor.Name = "Panel_PartInfor";
            this.Panel_PartInfor.Size = new System.Drawing.Size(684, 261);
            this.Panel_PartInfor.TabIndex = 0;
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(617, 213);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(38, 35);
            this.btnExpand.TabIndex = 8;
            this.btnExpand.Text = ">";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Enabled = false;
            this.btnCollapse.Location = new System.Drawing.Point(557, 213);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(38, 35);
            this.btnCollapse.TabIndex = 8;
            this.btnCollapse.Text = "<";
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // txtPartMaterial
            // 
            this.txtPartMaterial.Location = new System.Drawing.Point(106, 124);
            this.txtPartMaterial.Name = "txtPartMaterial";
            this.txtPartMaterial.ReadOnly = true;
            this.txtPartMaterial.Size = new System.Drawing.Size(204, 29);
            this.txtPartMaterial.TabIndex = 7;
            // 
            // labelPartMaterial
            // 
            this.labelPartMaterial.AutoSize = true;
            this.labelPartMaterial.Location = new System.Drawing.Point(9, 127);
            this.labelPartMaterial.Name = "labelPartMaterial";
            this.labelPartMaterial.Size = new System.Drawing.Size(72, 23);
            this.labelPartMaterial.TabIndex = 6;
            this.labelPartMaterial.Text = "Material";
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPartPrice.Location = new System.Drawing.Point(369, 124);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.ReadOnly = true;
            this.txtPartPrice.Size = new System.Drawing.Size(130, 29);
            this.txtPartPrice.TabIndex = 3;
            this.txtPartPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(503, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "(VND)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPartPrice
            // 
            this.labelPartPrice.AutoSize = true;
            this.labelPartPrice.Location = new System.Drawing.Point(316, 127);
            this.labelPartPrice.Name = "labelPartPrice";
            this.labelPartPrice.Size = new System.Drawing.Size(47, 23);
            this.labelPartPrice.TabIndex = 0;
            this.labelPartPrice.Text = "Price";
            this.labelPartPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_Download
            // 
            this.Panel_Download.AutoScroll = true;
            this.Panel_Download.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Panel_Download.Controls.Add(this.dgvListFile);
            this.Panel_Download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Download.Location = new System.Drawing.Point(3, 270);
            this.Panel_Download.Name = "Panel_Download";
            this.Panel_Download.Size = new System.Drawing.Size(684, 194);
            this.Panel_Download.TabIndex = 0;
            // 
            // dgvListFile
            // 
            this.dgvListFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvListFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListFile.FilterAndSortEnabled = true;
            this.dgvListFile.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListFile.Location = new System.Drawing.Point(0, 0);
            this.dgvListFile.MaxFilterButtonImageHeight = 23;
            this.dgvListFile.MultiSelect = false;
            this.dgvListFile.Name = "dgvListFile";
            this.dgvListFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListFile.RowHeadersWidth = 51;
            this.dgvListFile.RowTemplate.Height = 24;
            this.dgvListFile.Size = new System.Drawing.Size(684, 194);
            this.dgvListFile.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListFile.TabIndex = 5;
            this.dgvListFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFile_CellDoubleClick);
            // 
            // PanelDataGridView
            // 
            this.PanelDataGridView.AutoScroll = true;
            this.PanelDataGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelDataGridView.Controls.Add(this.dgvListECO);
            this.PanelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDataGridView.Location = new System.Drawing.Point(3, 470);
            this.PanelDataGridView.Name = "PanelDataGridView";
            this.PanelDataGridView.Size = new System.Drawing.Size(684, 196);
            this.PanelDataGridView.TabIndex = 0;
            // 
            // dgvListECO
            // 
            this.dgvListECO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListECO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListECO.FilterAndSortEnabled = true;
            this.dgvListECO.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListECO.Location = new System.Drawing.Point(0, 0);
            this.dgvListECO.MaxFilterButtonImageHeight = 23;
            this.dgvListECO.Name = "dgvListECO";
            this.dgvListECO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListECO.RowHeadersWidth = 51;
            this.dgvListECO.RowTemplate.Height = 24;
            this.dgvListECO.Size = new System.Drawing.Size(684, 196);
            this.dgvListECO.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListECO.TabIndex = 8;
            this.dgvListECO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListECO_CellDoubleClick);
            // 
            // dgvChild
            // 
            this.dgvChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChild.FilterAndSortEnabled = true;
            this.dgvChild.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvChild.Location = new System.Drawing.Point(0, 0);
            this.dgvChild.MaxFilterButtonImageHeight = 23;
            this.dgvChild.Name = "dgvChild";
            this.dgvChild.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvChild.RowHeadersWidth = 51;
            this.dgvChild.RowTemplate.Height = 24;
            this.dgvChild.Size = new System.Drawing.Size(96, 100);
            this.dgvChild.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvChild.TabIndex = 9;
            this.dgvChild.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChild_CellFormatting);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvChild);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(690, 669);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 10;
            // 
            // frmRelationPart_Detail_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(690, 669);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmRelationPart_Detail_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Component Detail";
            this.Load += new System.EventHandler(this.frmRelationPart_Detail_Info_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelationPart_Detail_Info_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicPart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Panel_PartInfor.ResumeLayout(false);
            this.Panel_PartInfor.PerformLayout();
            this.Panel_Download.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFile)).EndInit();
            this.PanelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListECO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPartCode;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.Label labelPartDescription;
        private System.Windows.Forms.Label labelPartStage;
        private System.Windows.Forms.PictureBox PicPart;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.TextBox txtPartDescription;
        private System.Windows.Forms.TextBox txtPartStage;
        private System.Windows.Forms.TextBox txtPicStatus;
        private System.Windows.Forms.Label labelNote1;
        private System.Windows.Forms.Button btnDownLoadFile;
        private System.Windows.Forms.Label labelNote2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel_PartInfor;
        private System.Windows.Forms.Panel Panel_Download;
        private System.Windows.Forms.Panel PanelDataGridView;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelPartPrice;
        private System.Windows.Forms.TextBox txtPartMaterial;
        private System.Windows.Forms.Label labelPartMaterial;
        private Zuby.ADGV.AdvancedDataGridView dgvListECO;
        private Zuby.ADGV.AdvancedDataGridView dgvListFile;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private Zuby.ADGV.AdvancedDataGridView dgvChild;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}