namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    partial class frmManageUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvListUser = new Zuby.ADGV.AdvancedDataGridView();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtUserRoles = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserPosition = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.labelUserLevel = new System.Windows.Forms.Label();
            this.labelUserDept = new System.Windows.Forms.Label();
            this.labelUserRoles = new System.Windows.Forms.Label();
            this.labelUserPosition = new System.Windows.Forms.Label();
            this.labelUserPass = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSaveDept = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteDept = new System.Windows.Forms.Button();
            this.btnModifyDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.groupBoxDept = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdDept = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDeptName = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.dgvListDepartment = new Zuby.ADGV.AdvancedDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUser)).BeginInit();
            this.groupBoxUser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBoxDept.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDepartment)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(932, 499);
            this.splitContainer1.SplitterDistance = 589;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListUser, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(589, 499);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvListUser
            // 
            this.dgvListUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListUser.FilterAndSortEnabled = true;
            this.dgvListUser.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListUser.Location = new System.Drawing.Point(3, 202);
            this.dgvListUser.MaxFilterButtonImageHeight = 23;
            this.dgvListUser.Name = "dgvListUser";
            this.dgvListUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListUser.RowHeadersWidth = 51;
            this.dgvListUser.RowTemplate.Height = 24;
            this.dgvListUser.Size = new System.Drawing.Size(583, 243);
            this.dgvListUser.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListUser.TabIndex = 2;
            this.dgvListUser.Click += new System.EventHandler(this.dgvListUser_Click);
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.panel1);
            this.groupBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUser.Location = new System.Drawing.Point(3, 4);
            this.groupBoxUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUser.Size = new System.Drawing.Size(583, 191);
            this.groupBoxUser.TabIndex = 0;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Manage List Users";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cboLevel);
            this.panel1.Controls.Add(this.cboDepartment);
            this.panel1.Controls.Add(this.txtUserRoles);
            this.panel1.Controls.Add(this.txtUserPassword);
            this.panel1.Controls.Add(this.txtUserPosition);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.labelUserLevel);
            this.panel1.Controls.Add(this.labelUserDept);
            this.panel1.Controls.Add(this.labelUserRoles);
            this.panel1.Controls.Add(this.labelUserPosition);
            this.panel1.Controls.Add(this.labelUserPass);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 161);
            this.panel1.TabIndex = 0;
            // 
            // cboLevel
            // 
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cboLevel.Location = new System.Drawing.Point(352, 100);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(44, 29);
            this.cboLevel.TabIndex = 7;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(352, 55);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(148, 29);
            this.cboDepartment.TabIndex = 6;
            // 
            // txtUserRoles
            // 
            this.txtUserRoles.Location = new System.Drawing.Point(98, 96);
            this.txtUserRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserRoles.Name = "txtUserRoles";
            this.txtUserRoles.Size = new System.Drawing.Size(136, 29);
            this.txtUserRoles.TabIndex = 3;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(98, 55);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(136, 29);
            this.txtUserPassword.TabIndex = 2;
            // 
            // txtUserPosition
            // 
            this.txtUserPosition.Location = new System.Drawing.Point(352, 13);
            this.txtUserPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserPosition.Name = "txtUserPosition";
            this.txtUserPosition.Size = new System.Drawing.Size(148, 29);
            this.txtUserPosition.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 13);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(136, 29);
            this.txtUserName.TabIndex = 1;
            // 
            // labelUserLevel
            // 
            this.labelUserLevel.AutoSize = true;
            this.labelUserLevel.Location = new System.Drawing.Point(244, 102);
            this.labelUserLevel.Name = "labelUserLevel";
            this.labelUserLevel.Size = new System.Drawing.Size(49, 23);
            this.labelUserLevel.TabIndex = 0;
            this.labelUserLevel.Text = "Level";
            // 
            // labelUserDept
            // 
            this.labelUserDept.AutoSize = true;
            this.labelUserDept.Location = new System.Drawing.Point(244, 58);
            this.labelUserDept.Name = "labelUserDept";
            this.labelUserDept.Size = new System.Drawing.Size(102, 23);
            this.labelUserDept.TabIndex = 0;
            this.labelUserDept.Text = "Department";
            // 
            // labelUserRoles
            // 
            this.labelUserRoles.AutoSize = true;
            this.labelUserRoles.Location = new System.Drawing.Point(10, 100);
            this.labelUserRoles.Name = "labelUserRoles";
            this.labelUserRoles.Size = new System.Drawing.Size(51, 23);
            this.labelUserRoles.TabIndex = 0;
            this.labelUserRoles.Text = "Roles";
            // 
            // labelUserPosition
            // 
            this.labelUserPosition.AutoSize = true;
            this.labelUserPosition.Location = new System.Drawing.Point(244, 17);
            this.labelUserPosition.Name = "labelUserPosition";
            this.labelUserPosition.Size = new System.Drawing.Size(70, 23);
            this.labelUserPosition.TabIndex = 0;
            this.labelUserPosition.Text = "Position";
            // 
            // labelUserPass
            // 
            this.labelUserPass.AutoSize = true;
            this.labelUserPass.Location = new System.Drawing.Point(10, 58);
            this.labelUserPass.Name = "labelUserPass";
            this.labelUserPass.Size = new System.Drawing.Size(82, 23);
            this.labelUserPass.TabIndex = 0;
            this.labelUserPass.Text = "Password";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(10, 16);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(56, 23);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.btnSaveUser);
            this.panel5.Controls.Add(this.btnAddUser);
            this.panel5.Controls.Add(this.btnDeleteUser);
            this.panel5.Controls.Add(this.btnModifyUser);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 451);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(583, 45);
            this.panel5.TabIndex = 3;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveUser.Image")));
            this.btnSaveUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveUser.Location = new System.Drawing.Point(386, 4);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(105, 38);
            this.btnSaveUser.TabIndex = 4;
            this.btnSaveUser.Text = "SaveUser";
            this.btnSaveUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.Location = new System.Drawing.Point(17, 4);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(105, 38);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Image")));
            this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.Location = new System.Drawing.Point(263, 4);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(105, 38);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyUser.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyUser.Image")));
            this.btnModifyUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyUser.Location = new System.Drawing.Point(140, 4);
            this.btnModifyUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(105, 38);
            this.btnModifyUser.TabIndex = 2;
            this.btnModifyUser.Text = "Modify User";
            this.btnModifyUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxDept, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvListDepartment, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(338, 499);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 376);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(332, 119);
            this.panel4.TabIndex = 1;
            // 
            // btnSaveDept
            // 
            this.btnSaveDept.Location = new System.Drawing.Point(197, 4);
            this.btnSaveDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveDept.Name = "btnSaveDept";
            this.btnSaveDept.Size = new System.Drawing.Size(85, 40);
            this.btnSaveDept.TabIndex = 3;
            this.btnSaveDept.Text = "Save";
            this.btnSaveDept.UseVisualStyleBackColor = true;
            this.btnSaveDept.Click += new System.EventHandler(this.btnSaveDept_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(94, 52);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteDept
            // 
            this.btnDeleteDept.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDeleteDept.Location = new System.Drawing.Point(106, 4);
            this.btnDeleteDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteDept.Name = "btnDeleteDept";
            this.btnDeleteDept.Size = new System.Drawing.Size(85, 40);
            this.btnDeleteDept.TabIndex = 1;
            this.btnDeleteDept.Text = "Delete";
            this.btnDeleteDept.UseVisualStyleBackColor = false;
            this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
            // 
            // btnModifyDept
            // 
            this.btnModifyDept.BackColor = System.Drawing.SystemColors.Info;
            this.btnModifyDept.Location = new System.Drawing.Point(3, 52);
            this.btnModifyDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyDept.Name = "btnModifyDept";
            this.btnModifyDept.Size = new System.Drawing.Size(85, 40);
            this.btnModifyDept.TabIndex = 2;
            this.btnModifyDept.Text = "Modify";
            this.btnModifyDept.UseVisualStyleBackColor = false;
            this.btnModifyDept.Click += new System.EventHandler(this.btnModifyDept_Click);
            // 
            // btnAddDept
            // 
            this.btnAddDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAddDept.Location = new System.Drawing.Point(3, 4);
            this.btnAddDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(97, 40);
            this.btnAddDept.TabIndex = 1;
            this.btnAddDept.Text = "Add Dept";
            this.btnAddDept.UseVisualStyleBackColor = false;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // groupBoxDept
            // 
            this.groupBoxDept.Controls.Add(this.panel3);
            this.groupBoxDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDept.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDept.Location = new System.Drawing.Point(3, 4);
            this.groupBoxDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDept.Name = "groupBoxDept";
            this.groupBoxDept.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDept.Size = new System.Drawing.Size(332, 116);
            this.groupBoxDept.TabIndex = 0;
            this.groupBoxDept.TabStop = false;
            this.groupBoxDept.Text = "Manage List Department";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.txtIdDept);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.labelDeptName);
            this.panel3.Controls.Add(this.txtDepartmentName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 26);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 86);
            this.panel3.TabIndex = 2;
            // 
            // txtIdDept
            // 
            this.txtIdDept.Location = new System.Drawing.Point(62, 8);
            this.txtIdDept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdDept.Name = "txtIdDept";
            this.txtIdDept.Size = new System.Drawing.Size(35, 29);
            this.txtIdDept.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeptName
            // 
            this.labelDeptName.AutoSize = true;
            this.labelDeptName.Location = new System.Drawing.Point(19, 49);
            this.labelDeptName.Name = "labelDeptName";
            this.labelDeptName.Size = new System.Drawing.Size(98, 23);
            this.labelDeptName.TabIndex = 1;
            this.labelDeptName.Text = "Dept Name";
            this.labelDeptName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(123, 45);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(172, 29);
            this.txtDepartmentName.TabIndex = 0;
            // 
            // dgvListDepartment
            // 
            this.dgvListDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListDepartment.FilterAndSortEnabled = true;
            this.dgvListDepartment.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListDepartment.Location = new System.Drawing.Point(3, 127);
            this.dgvListDepartment.MaxFilterButtonImageHeight = 23;
            this.dgvListDepartment.Name = "dgvListDepartment";
            this.dgvListDepartment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListDepartment.RowHeadersWidth = 51;
            this.dgvListDepartment.RowTemplate.Height = 24;
            this.dgvListDepartment.Size = new System.Drawing.Size(332, 143);
            this.dgvListDepartment.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvListDepartment.TabIndex = 2;
            this.dgvListDepartment.Click += new System.EventHandler(this.dgvListDepartment_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.btnAddDept);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteDept);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveDept);
            this.flowLayoutPanel1.Controls.Add(this.btnModifyDept);
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 276);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 93);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Level 1 : Admin, Manager.",
            "Level 2 : Design Enginer, R&D Team.",
            "Level 3 : Purchase Team",
            "Level 4 : QC Team, NPI Team, Product Team, ..."});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(326, 91);
            this.checkedListBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note";
            // 
            // frmManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 499);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manager User";
            this.Load += new System.EventHandler(this.frmManageUser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUser)).EndInit();
            this.groupBoxUser.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBoxDept.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDepartment)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.GroupBox groupBoxDept;
        private System.Windows.Forms.Label labelUserPass;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox txtUserRoles;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserPosition;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label labelUserDept;
        private System.Windows.Forms.Label labelUserRoles;
        private System.Windows.Forms.Label labelUserPosition;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddDept;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeleteDept;
        private System.Windows.Forms.Button btnModifyDept;
        private System.Windows.Forms.Label labelDeptName;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnSaveDept;
        private System.Windows.Forms.TextBox txtIdDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label labelUserLevel;
        private Zuby.ADGV.AdvancedDataGridView dgvListUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Zuby.ADGV.AdvancedDataGridView dgvListDepartment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}