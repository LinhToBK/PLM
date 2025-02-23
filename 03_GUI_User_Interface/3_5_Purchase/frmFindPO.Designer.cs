namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    partial class frmFindPO
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
            this.btnExit = new System.Windows.Forms.Button();
            this.BtnKeySearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(172, 187);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BtnKeySearch
            // 
            this.BtnKeySearch.Location = new System.Drawing.Point(154, 65);
            this.BtnKeySearch.Name = "BtnKeySearch";
            this.BtnKeySearch.Size = new System.Drawing.Size(75, 23);
            this.BtnKeySearch.TabIndex = 1;
            this.BtnKeySearch.Text = "Search";
            this.BtnKeySearch.UseVisualStyleBackColor = true;
            this.BtnKeySearch.Click += new System.EventHandler(this.BtnKeySearch_Click);
            // 
            // frmFindPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 308);
            this.Controls.Add(this.BtnKeySearch);
            this.Controls.Add(this.btnExit);
            this.Name = "frmFindPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFindPO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button BtnKeySearch;
    }
}