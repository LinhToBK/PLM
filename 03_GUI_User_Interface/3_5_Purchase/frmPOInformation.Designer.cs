namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmPOInformation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOInformation));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPODateCreate = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtPOStatus = new System.Windows.Forms.TextBox();
            this.txtPOCurrency = new System.Windows.Forms.TextBox();
            this.txtPOUser = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.btnStock = new System.Windows.Forms.Button();
            this.dgvListStatus = new Zuby.ADGV.AdvancedDataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabInfor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvListItems = new Zuby.ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSupplierNote = new System.Windows.Forms.TextBox();
            this.txtSupplierLocation = new System.Windows.Forms.TextBox();
            this.txtSupplierTax = new System.Windows.Forms.TextBox();
            this.txtSupplierTelephone = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierRepresentative = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStatus)).BeginInit();
            this.tabInfor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabInfor, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1094, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtPODateCreate);
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.txtPOStatus);
            this.panel1.Controls.Add(this.txtPOCurrency);
            this.panel1.Controls.Add(this.txtPOUser);
            this.panel1.Controls.Add(this.txtPONumber);
            this.panel1.Controls.Add(this.btnStock);
            this.panel1.Controls.Add(this.dgvListStatus);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 175);
            this.panel1.TabIndex = 0;
            // 
            // txtPODateCreate
            // 
            this.txtPODateCreate.Location = new System.Drawing.Point(506, 16);
            this.txtPODateCreate.Name = "txtPODateCreate";
            this.txtPODateCreate.ReadOnly = true;
            this.txtPODateCreate.Size = new System.Drawing.Size(185, 30);
            this.txtPODateCreate.TabIndex = 3;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(129, 118);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(185, 30);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // txtPOStatus
            // 
            this.txtPOStatus.Location = new System.Drawing.Point(506, 67);
            this.txtPOStatus.Name = "txtPOStatus";
            this.txtPOStatus.ReadOnly = true;
            this.txtPOStatus.Size = new System.Drawing.Size(185, 30);
            this.txtPOStatus.TabIndex = 3;
            // 
            // txtPOCurrency
            // 
            this.txtPOCurrency.Location = new System.Drawing.Point(506, 122);
            this.txtPOCurrency.Name = "txtPOCurrency";
            this.txtPOCurrency.ReadOnly = true;
            this.txtPOCurrency.Size = new System.Drawing.Size(152, 30);
            this.txtPOCurrency.TabIndex = 3;
            // 
            // txtPOUser
            // 
            this.txtPOUser.Location = new System.Drawing.Point(129, 67);
            this.txtPOUser.Name = "txtPOUser";
            this.txtPOUser.ReadOnly = true;
            this.txtPOUser.Size = new System.Drawing.Size(185, 30);
            this.txtPOUser.TabIndex = 3;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(129, 16);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.ReadOnly = true;
            this.txtPONumber.Size = new System.Drawing.Size(185, 30);
            this.txtPONumber.TabIndex = 3;
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(726, 16);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(87, 81);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Goods receipt PO";
            this.btnStock.UseVisualStyleBackColor = true;
            // 
            // dgvListStatus
            // 
            this.dgvListStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvListStatus.FilterAndSortEnabled = true;
            this.dgvListStatus.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListStatus.Location = new System.Drawing.Point(828, 0);
            this.dgvListStatus.MaxFilterButtonImageHeight = 23;
            this.dgvListStatus.Name = "dgvListStatus";
            this.dgvListStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListStatus.RowHeadersWidth = 51;
            this.dgvListStatus.RowTemplate.Height = 24;
            this.dgvListStatus.Size = new System.Drawing.Size(260, 175);
            this.dgvListStatus.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListStatus.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "Total Amount";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "PO Date Created";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Status";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Currency";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "User";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "PO Number";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabInfor
            // 
            this.tabInfor.Controls.Add(this.tabPage1);
            this.tabInfor.Controls.Add(this.tabPage2);
            this.tabInfor.Controls.Add(this.tabPage3);
            this.tabInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfor.ImageList = this.imageList1;
            this.tabInfor.Location = new System.Drawing.Point(3, 184);
            this.tabInfor.Name = "tabInfor";
            this.tabInfor.SelectedIndex = 0;
            this.tabInfor.Size = new System.Drawing.Size(1088, 419);
            this.tabInfor.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvListItems);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1080, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PO List Items";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvListItems
            // 
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListItems.FilterAndSortEnabled = true;
            this.dgvListItems.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListItems.Location = new System.Drawing.Point(3, 3);
            this.dgvListItems.MaxFilterButtonImageHeight = 23;
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListItems.RowHeadersWidth = 51;
            this.dgvListItems.RowTemplate.Height = 24;
            this.dgvListItems.Size = new System.Drawing.Size(1074, 377);
            this.dgvListItems.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListItems.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.txtSupplierNote);
            this.tabPage2.Controls.Add(this.txtSupplierLocation);
            this.tabPage2.Controls.Add(this.txtSupplierTax);
            this.tabPage2.Controls.Add(this.txtSupplierTelephone);
            this.tabPage2.Controls.Add(this.txtSupplierID);
            this.tabPage2.Controls.Add(this.txtSupplierRepresentative);
            this.tabPage2.Controls.Add(this.txtSupplierName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1080, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Supplier Information";
            // 
            // txtSupplierNote
            // 
            this.txtSupplierNote.Location = new System.Drawing.Point(217, 293);
            this.txtSupplierNote.Multiline = true;
            this.txtSupplierNote.Name = "txtSupplierNote";
            this.txtSupplierNote.Size = new System.Drawing.Size(660, 67);
            this.txtSupplierNote.TabIndex = 1;
            // 
            // txtSupplierLocation
            // 
            this.txtSupplierLocation.Location = new System.Drawing.Point(217, 196);
            this.txtSupplierLocation.Multiline = true;
            this.txtSupplierLocation.Name = "txtSupplierLocation";
            this.txtSupplierLocation.Size = new System.Drawing.Size(660, 67);
            this.txtSupplierLocation.TabIndex = 1;
            // 
            // txtSupplierTax
            // 
            this.txtSupplierTax.Location = new System.Drawing.Point(775, 76);
            this.txtSupplierTax.Name = "txtSupplierTax";
            this.txtSupplierTax.Size = new System.Drawing.Size(220, 30);
            this.txtSupplierTax.TabIndex = 1;
            // 
            // txtSupplierTelephone
            // 
            this.txtSupplierTelephone.Location = new System.Drawing.Point(217, 136);
            this.txtSupplierTelephone.Name = "txtSupplierTelephone";
            this.txtSupplierTelephone.Size = new System.Drawing.Size(344, 30);
            this.txtSupplierTelephone.TabIndex = 1;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(775, 23);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(220, 30);
            this.txtSupplierID.TabIndex = 1;
            // 
            // txtSupplierRepresentative
            // 
            this.txtSupplierRepresentative.Location = new System.Drawing.Point(217, 76);
            this.txtSupplierRepresentative.Name = "txtSupplierRepresentative";
            this.txtSupplierRepresentative.Size = new System.Drawing.Size(344, 30);
            this.txtSupplierRepresentative.TabIndex = 1;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(217, 16);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(344, 30);
            this.txtSupplierName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Supplier Tax";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "Supplier Note";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Supplier Telephone";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Supplier Location";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(189, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Supplier Representative";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.txtRemark);
            this.tabPage3.Controls.Add(this.txtPayment);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1080, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remark and Payment Term";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(167, 204);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(545, 115);
            this.txtRemark.TabIndex = 1;
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(167, 38);
            this.txtPayment.Multiline = true;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(545, 115);
            this.txtPayment.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Remark";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Payment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-check-book-25.png");
            this.imageList1.Images.SetKeyName(1, "icons8-supplier-25.png");
            this.imageList1.Images.SetKeyName(2, "icons8-term-25.png");
            // 
            // frmPOInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPOInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPOInformation";
            this.Load += new System.EventHandler(this.frmPOInformation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListStatus)).EndInit();
            this.tabInfor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabInfor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Zuby.ADGV.AdvancedDataGridView dgvListItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierLocation;
        private System.Windows.Forms.TextBox txtSupplierTax;
        private System.Windows.Forms.TextBox txtSupplierTelephone;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private Zuby.ADGV.AdvancedDataGridView dgvListStatus;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.TextBox txtPODateCreate;
        private System.Windows.Forms.TextBox txtPOStatus;
        private System.Windows.Forms.TextBox txtPOCurrency;
        private System.Windows.Forms.TextBox txtPOUser;
        private System.Windows.Forms.TextBox txtSupplierRepresentative;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSupplierNote;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ImageList imageList1;
    }
}