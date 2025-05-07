namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    partial class frmSiemenNX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSiemenNX));
            this.btnImage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDWG = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnSTEP = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNX10 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPartlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImage
            // 
            this.btnImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnImage.Image = ((System.Drawing.Image)(resources.GetObject("btnImage.Image")));
            this.btnImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImage.Location = new System.Drawing.Point(326, 25);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(137, 34);
            this.btnImage.TabIndex = 0;
            this.btnImage.Text = ".JPG + BOM";
            this.btnImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(28, 399);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 66);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDWG
            // 
            this.btnDWG.Image = ((System.Drawing.Image)(resources.GetObject("btnDWG.Image")));
            this.btnDWG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDWG.Location = new System.Drawing.Point(326, 86);
            this.btnDWG.Name = "btnDWG";
            this.btnDWG.Size = new System.Drawing.Size(88, 34);
            this.btnDWG.TabIndex = 0;
            this.btnDWG.Text = ".DWG";
            this.btnDWG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDWG.UseVisualStyleBackColor = true;
            this.btnDWG.Click += new System.EventHandler(this.btnDWG_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(326, 147);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(88, 34);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.Text = ".PDF  ";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnSTEP
            // 
            this.btnSTEP.Image = ((System.Drawing.Image)(resources.GetObject("btnSTEP.Image")));
            this.btnSTEP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSTEP.Location = new System.Drawing.Point(326, 208);
            this.btnSTEP.Name = "btnSTEP";
            this.btnSTEP.Size = new System.Drawing.Size(88, 34);
            this.btnSTEP.TabIndex = 0;
            this.btnSTEP.Text = ".STP  ";
            this.btnSTEP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSTEP.UseVisualStyleBackColor = true;
            this.btnSTEP.Click += new System.EventHandler(this.btnSTEP_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(326, 269);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(88, 34);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Excel ";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code for download Image and BOM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code for download .dwg file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Code for download .PDF file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Code for download .step file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Code for handle BOM in Excel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 69);
            this.label6.TabIndex = 1;
            this.label6.Text = "Lưu ý : \r\nCác code này tương thích với bản NX 12 trở lên.\r\nNếu là NX10, NX11 thì " +
    "vui lòng chọn tương ứng";
            // 
            // btnNX10
            // 
            this.btnNX10.Location = new System.Drawing.Point(448, 86);
            this.btnNX10.Name = "btnNX10";
            this.btnNX10.Size = new System.Drawing.Size(116, 34);
            this.btnNX10.TabIndex = 2;
            this.btnNX10.Text = "NX10, NX11";
            this.btnNX10.UseVisualStyleBackColor = true;
            this.btnNX10.Click += new System.EventHandler(this.btnNX10_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Convert BOM to Partlist";
            // 
            // btnPartlist
            // 
            this.btnPartlist.Location = new System.Drawing.Point(326, 325);
            this.btnPartlist.Name = "btnPartlist";
            this.btnPartlist.Size = new System.Drawing.Size(88, 34);
            this.btnPartlist.TabIndex = 3;
            this.btnPartlist.Text = "Partlist";
            this.btnPartlist.UseVisualStyleBackColor = true;
            this.btnPartlist.Click += new System.EventHandler(this.btnPartlist_Click);
            // 
            // frmSiemenNX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 477);
            this.Controls.Add(this.btnPartlist);
            this.Controls.Add(this.btnNX10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSTEP);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnDWG);
            this.Controls.Add(this.btnImage);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSiemenNX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Siemen NX";
            this.Load += new System.EventHandler(this.frmSiemenNX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDWG;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnSTEP;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNX10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPartlist;
    }
}