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
            this.mnuMakeNewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindPO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagePrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tstripUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEngineer,
            this.mnuSystem,
            this.mnuPurchase,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuEngineer
            // 
            this.mnuEngineer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindPart});
            this.mnuEngineer.Name = "mnuEngineer";
            this.mnuEngineer.Size = new System.Drawing.Size(65, 20);
            this.mnuEngineer.Text = "Engineer";
            // 
            // mnuFindPart
            // 
            this.mnuFindPart.Name = "mnuFindPart";
            this.mnuFindPart.Size = new System.Drawing.Size(121, 22);
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
            this.mnuRelationPart});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(57, 20);
            this.mnuSystem.Text = "System";
            // 
            // mnuMakeNewPart
            // 
            this.mnuMakeNewPart.Name = "mnuMakeNewPart";
            this.mnuMakeNewPart.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuMakeNewPart.Size = new System.Drawing.Size(260, 22);
            this.mnuMakeNewPart.Text = "Make New Part";
            this.mnuMakeNewPart.Click += new System.EventHandler(this.mnuMakeNewPart_Click);
            // 
            // mnuECO
            // 
            this.mnuECO.Name = "mnuECO";
            this.mnuECO.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.mnuECO.Size = new System.Drawing.Size(260, 22);
            this.mnuECO.Text = "ECO";
            this.mnuECO.Click += new System.EventHandler(this.mnuECO_Click);
            // 
            // mnuManagerUser
            // 
            this.mnuManagerUser.Name = "mnuManagerUser";
            this.mnuManagerUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuManagerUser.Size = new System.Drawing.Size(260, 22);
            this.mnuManagerUser.Text = "Manage User";
            this.mnuManagerUser.Click += new System.EventHandler(this.mnuManagerUser_Click);
            // 
            // mnuManageFamily
            // 
            this.mnuManageFamily.Name = "mnuManageFamily";
            this.mnuManageFamily.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.mnuManageFamily.Size = new System.Drawing.Size(260, 22);
            this.mnuManageFamily.Text = "Manage Family";
            this.mnuManageFamily.Click += new System.EventHandler(this.mnuManageFamily_Click);
            // 
            // mnuRelationPart
            // 
            this.mnuRelationPart.Name = "mnuRelationPart";
            this.mnuRelationPart.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuRelationPart.Size = new System.Drawing.Size(260, 22);
            this.mnuRelationPart.Text = "Manage Relation Part";
            this.mnuRelationPart.Click += new System.EventHandler(this.mnuRelationPart_Click);
            // 
            // mnuPurchase
            // 
            this.mnuPurchase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManagePrice,
            this.mnuMakeNewPO,
            this.mnuFindPO});
            this.mnuPurchase.Name = "mnuPurchase";
            this.mnuPurchase.Size = new System.Drawing.Size(67, 20);
            this.mnuPurchase.Text = "Purchase";
            // 
            // mnuMakeNewPO
            // 
            this.mnuMakeNewPO.Name = "mnuMakeNewPO";
            this.mnuMakeNewPO.Size = new System.Drawing.Size(219, 22);
            this.mnuMakeNewPO.Text = "Make New PO";
            // 
            // mnuFindPO
            // 
            this.mnuFindPO.Name = "mnuFindPO";
            this.mnuFindPO.Size = new System.Drawing.Size(219, 22);
            this.mnuFindPO.Text = "Find PO ";
            // 
            // mnuManagePrice
            // 
            this.mnuManagePrice.Name = "mnuManagePrice";
            this.mnuManagePrice.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuManagePrice.Size = new System.Drawing.Size(219, 22);
            this.mnuManagePrice.Text = "Manage Price";
            this.mnuManagePrice.Click += new System.EventHandler(this.mnuManagePrice_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAboutMe,
            this.mnuUserGuide});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAboutMe
            // 
            this.mnuAboutMe.Name = "mnuAboutMe";
            this.mnuAboutMe.Size = new System.Drawing.Size(131, 22);
            this.mnuAboutMe.Text = "About me";
            // 
            // mnuUserGuide
            // 
            this.mnuUserGuide.Name = "mnuUserGuide";
            this.mnuUserGuide.Size = new System.Drawing.Size(131, 22);
            this.mnuUserGuide.Text = "User Guide";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1273, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tstripUser
            // 
            this.tstripUser.Name = "tstripUser";
            this.tstripUser.Size = new System.Drawing.Size(30, 17);
            this.tstripUser.Text = "User";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 610);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
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
    }
}

