namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    partial class frmListmaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListmaterial));
            this.btnOpenFileMaterial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFileMaterial
            // 
            this.btnOpenFileMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFileMaterial.Image")));
            this.btnOpenFileMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFileMaterial.Location = new System.Drawing.Point(36, 34);
            this.btnOpenFileMaterial.Name = "btnOpenFileMaterial";
            this.btnOpenFileMaterial.Size = new System.Drawing.Size(193, 39);
            this.btnOpenFileMaterial.TabIndex = 0;
            this.btnOpenFileMaterial.Text = "Open File Material";
            this.btnOpenFileMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFileMaterial.UseVisualStyleBackColor = true;
            this.btnOpenFileMaterial.Click += new System.EventHandler(this.btnOpenFileMaterial_Click);
            // 
            // frmListmaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 182);
            this.Controls.Add(this.btnOpenFileMaterial);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListmaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFileMaterial;
    }
}