namespace HostsEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHosts = new System.Windows.Forms.DataGridView();
            this.chIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbBackup = new System.Windows.Forms.CheckBox();
            this.llHostsFolder = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(305, 377);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-20, 364);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 3);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dgvHosts
            // 
            this.dgvHosts.ColumnHeadersHeight = 25;
            this.dgvHosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chIpAddress,
            this.chDomain});
            this.dgvHosts.Location = new System.Drawing.Point(12, 27);
            this.dgvHosts.Name = "dgvHosts";
            this.dgvHosts.Size = new System.Drawing.Size(368, 331);
            this.dgvHosts.TabIndex = 2;
            this.dgvHosts.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvHosts_CellBeginEdit);
            this.dgvHosts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHosts_CellEndEdit);
            this.dgvHosts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvHosts_RowsRemoved);
            // 
            // chIpAddress
            // 
            this.chIpAddress.HeaderText = "IP Address";
            this.chIpAddress.Name = "chIpAddress";
            // 
            // chDomain
            // 
            this.chDomain.HeaderText = "Domain";
            this.chDomain.Name = "chDomain";
            this.chDomain.Width = 205;
            // 
            // cbBackup
            // 
            this.cbBackup.AutoSize = true;
            this.cbBackup.Location = new System.Drawing.Point(12, 373);
            this.cbBackup.Name = "cbBackup";
            this.cbBackup.Size = new System.Drawing.Size(100, 17);
            this.cbBackup.TabIndex = 3;
            this.cbBackup.Text = "Create Back-up";
            this.cbBackup.UseVisualStyleBackColor = true;
            // 
            // llHostsFolder
            // 
            this.llHostsFolder.AutoSize = true;
            this.llHostsFolder.Location = new System.Drawing.Point(9, 393);
            this.llHostsFolder.Name = "llHostsFolder";
            this.llHostsFolder.Size = new System.Drawing.Size(95, 13);
            this.llHostsFolder.TabIndex = 4;
            this.llHostsFolder.TabStop = true;
            this.llHostsFolder.Text = "Open Hosts Folder";
            this.llHostsFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHostsFolder_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(392, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "msMain";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 412);
            this.Controls.Add(this.llHostsFolder);
            this.Controls.Add(this.cbBackup);
            this.Controls.Add(this.dgvHosts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts Editor by arunes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDomain;
        private System.Windows.Forms.CheckBox cbBackup;
        private System.Windows.Forms.LinkLabel llHostsFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

