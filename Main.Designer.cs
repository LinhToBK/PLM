namespace PLM_Lynx
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuEngineer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindPart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMakeNewPart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuECO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagerUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageFamily = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelationPart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagePrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMakeNewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindPO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tstripUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewListUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEngineer,
            this.mnuSystem,
            this.mnuPurchase,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1455, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuEngineer
            // 
            this.mnuEngineer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindPart});
            this.mnuEngineer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuEngineer.Image = ((System.Drawing.Image)(resources.GetObject("mnuEngineer.Image")));
            this.mnuEngineer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuEngineer.Name = "mnuEngineer";
            this.mnuEngineer.Size = new System.Drawing.Size(122, 32);
            this.mnuEngineer.Text = "Engineer";
            // 
            // mnuFindPart
            // 
            this.mnuFindPart.Image = ((System.Drawing.Image)(resources.GetObject("mnuFindPart.Image")));
            this.mnuFindPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuFindPart.Name = "mnuFindPart";
            this.mnuFindPart.Size = new System.Drawing.Size(224, 32);
            this.mnuFindPart.Text = "Find Part";
            this.mnuFindPart.Click += new System.EventHandler(this.mnuFindPart_Click);
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMakeNewPart,
            this.mnuECO,
            this.mnuManagerUser,
            this.mnuManageFamily,
            this.mnuRelationPart,
            this.viewListUpdateToolStripMenuItem});
            this.mnuSystem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSystem.Image = ((System.Drawing.Image)(resources.GetObject("mnuSystem.Image")));
            this.mnuSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(108, 32);
            this.mnuSystem.Text = "System";
            // 
            // mnuMakeNewPart
            // 
            this.mnuMakeNewPart.Image = ((System.Drawing.Image)(resources.GetObject("mnuMakeNewPart.Image")));
            this.mnuMakeNewPart.Name = "mnuMakeNewPart";
            this.mnuMakeNewPart.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuMakeNewPart.Size = new System.Drawing.Size(446, 32);
            this.mnuMakeNewPart.Text = "Make New Part";
            this.mnuMakeNewPart.Click += new System.EventHandler(this.mnuMakeNewPart_Click);
            // 
            // mnuECO
            // 
            this.mnuECO.Image = ((System.Drawing.Image)(resources.GetObject("mnuECO.Image")));
            this.mnuECO.Name = "mnuECO";
            this.mnuECO.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.mnuECO.Size = new System.Drawing.Size(446, 32);
            this.mnuECO.Text = "ECO - Update Information";
            this.mnuECO.Click += new System.EventHandler(this.mnuECO_Click);
            // 
            // mnuManagerUser
            // 
            this.mnuManagerUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuManagerUser.Image")));
            this.mnuManagerUser.Name = "mnuManagerUser";
            this.mnuManagerUser.Size = new System.Drawing.Size(446, 32);
            this.mnuManagerUser.Text = "Manage User";
            this.mnuManagerUser.Click += new System.EventHandler(this.mnuManagerUser_Click);
            // 
            // mnuManageFamily
            // 
            this.mnuManageFamily.Image = ((System.Drawing.Image)(resources.GetObject("mnuManageFamily.Image")));
            this.mnuManageFamily.Name = "mnuManageFamily";
            this.mnuManageFamily.Size = new System.Drawing.Size(446, 32);
            this.mnuManageFamily.Text = "Manage Family";
            this.mnuManageFamily.Click += new System.EventHandler(this.mnuManageFamily_Click);
            // 
            // mnuRelationPart
            // 
            this.mnuRelationPart.Image = ((System.Drawing.Image)(resources.GetObject("mnuRelationPart.Image")));
            this.mnuRelationPart.Name = "mnuRelationPart";
            this.mnuRelationPart.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuRelationPart.Size = new System.Drawing.Size(446, 32);
            this.mnuRelationPart.Text = "Manage Relation Part";
            this.mnuRelationPart.Click += new System.EventHandler(this.mnuRelationPart_Click);
            // 
            // mnuPurchase
            // 
            this.mnuPurchase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManagePrice,
            this.mnuMakeNewPO,
            this.mnuFindPO,
            this.mnuManageSupplier});
            this.mnuPurchase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuPurchase.Image")));
            this.mnuPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuPurchase.Name = "mnuPurchase";
            this.mnuPurchase.Size = new System.Drawing.Size(123, 32);
            this.mnuPurchase.Text = "Purchase";
            // 
            // mnuManagePrice
            // 
            this.mnuManagePrice.Image = ((System.Drawing.Image)(resources.GetObject("mnuManagePrice.Image")));
            this.mnuManagePrice.Name = "mnuManagePrice";
            this.mnuManagePrice.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.mnuManagePrice.Size = new System.Drawing.Size(350, 32);
            this.mnuManagePrice.Text = "Manage Price";
            this.mnuManagePrice.Click += new System.EventHandler(this.mnuManagePrice_Click);
            // 
            // mnuMakeNewPO
            // 
            this.mnuMakeNewPO.Image = ((System.Drawing.Image)(resources.GetObject("mnuMakeNewPO.Image")));
            this.mnuMakeNewPO.Name = "mnuMakeNewPO";
            this.mnuMakeNewPO.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.mnuMakeNewPO.Size = new System.Drawing.Size(350, 32);
            this.mnuMakeNewPO.Text = "Make New PO";
            this.mnuMakeNewPO.Click += new System.EventHandler(this.mnuMakeNewPO_Click);
            // 
            // mnuFindPO
            // 
            this.mnuFindPO.Image = ((System.Drawing.Image)(resources.GetObject("mnuFindPO.Image")));
            this.mnuFindPO.Name = "mnuFindPO";
            this.mnuFindPO.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuFindPO.Size = new System.Drawing.Size(350, 32);
            this.mnuFindPO.Text = "Find PO ";
            this.mnuFindPO.Click += new System.EventHandler(this.mnuFindPO_Click);
            // 
            // mnuManageSupplier
            // 
            this.mnuManageSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuManageSupplier.Image")));
            this.mnuManageSupplier.Name = "mnuManageSupplier";
            this.mnuManageSupplier.Size = new System.Drawing.Size(350, 32);
            this.mnuManageSupplier.Text = "Manage Supplier";
            this.mnuManageSupplier.Click += new System.EventHandler(this.mnuManageSupplier_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAboutMe,
            this.mnuUserGuide});
            this.mnuHelp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHelp.Image = ((System.Drawing.Image)(resources.GetObject("mnuHelp.Image")));
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(87, 32);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAboutMe
            // 
            this.mnuAboutMe.Image = ((System.Drawing.Image)(resources.GetObject("mnuAboutMe.Image")));
            this.mnuAboutMe.Name = "mnuAboutMe";
            this.mnuAboutMe.Size = new System.Drawing.Size(194, 32);
            this.mnuAboutMe.Text = "About me";
            this.mnuAboutMe.Click += new System.EventHandler(this.mnuAboutMe_Click);
            // 
            // mnuUserGuide
            // 
            this.mnuUserGuide.Image = ((System.Drawing.Image)(resources.GetObject("mnuUserGuide.Image")));
            this.mnuUserGuide.Name = "mnuUserGuide";
            this.mnuUserGuide.Size = new System.Drawing.Size(194, 32);
            this.mnuUserGuide.Text = "User Guide";
            this.mnuUserGuide.Click += new System.EventHandler(this.mnuUserGuide_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 788);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1455, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tstripUser
            // 
            this.tstripUser.Name = "tstripUser";
            this.tstripUser.Size = new System.Drawing.Size(38, 20);
            this.tstripUser.Text = "User";
            // 
            // viewListUpdateToolStripMenuItem
            // 
            this.viewListUpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewListUpdateToolStripMenuItem.Image")));
            this.viewListUpdateToolStripMenuItem.Name = "viewListUpdateToolStripMenuItem";
            this.viewListUpdateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.viewListUpdateToolStripMenuItem.Size = new System.Drawing.Size(446, 32);
            this.viewListUpdateToolStripMenuItem.Text = "View List Update";
            this.viewListUpdateToolStripMenuItem.Click += new System.EventHandler(this.viewListUpdateToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 814);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PLM Lynx";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuEngineer;
        private System.Windows.Forms.ToolStripMenuItem mnuFindPart;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuMakeNewPart;
        private System.Windows.Forms.ToolStripMenuItem mnuECO;
        private System.Windows.Forms.ToolStripMenuItem mnuManagerUser;
        private System.Windows.Forms.ToolStripMenuItem mnuPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuMakeNewPO;
        private System.Windows.Forms.ToolStripMenuItem mnuFindPO;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutMe;
        private System.Windows.Forms.ToolStripMenuItem mnuUserGuide;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tstripUser;
        private System.Windows.Forms.ToolStripMenuItem mnuManageFamily;
        private System.Windows.Forms.ToolStripMenuItem mnuRelationPart;
        private System.Windows.Forms.ToolStripMenuItem mnuManagePrice;
        private System.Windows.Forms.ToolStripMenuItem mnuManageSupplier;
        private System.Windows.Forms.ToolStripMenuItem viewListUpdateToolStripMenuItem;
    }
}

