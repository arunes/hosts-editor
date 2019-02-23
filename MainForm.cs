using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace HostsEditor
{
    public partial class MainForm : Form
    {
        private string HostsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
        private string HostsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\");
        private bool HostsChanged = false;
        private const string AppTitle = "Hosts Editor by arunes";

        public MainForm()
        {
            if (!HaveRightToWrite())
                MessageBox.Show("You dont have permission for editing hosts file!", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadHosts();
        }

        private void LoadHosts()
        {
            string[] hostsLines = File.ReadAllLines(HostsFilePath);
            for (int i = 0; i < hostsLines.Length; i++)
            {
                string hostLine = hostsLines[i].Trim();
                hostLine = Regex.Replace(hostLine, "\t+", " ");
                hostLine = Regex.Replace(hostLine, @"\s+", " ");
                if (!hostLine.StartsWith("#") && !string.IsNullOrEmpty(hostLine))
                { // we can add to grid -- 127.0.0.1 	adobe-dns-3.adobe.com
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    string[] splittedLine = hostLine.Split(' ');
                    string ip = splittedLine[0].Trim();
                    string domain = splittedLine[1].Trim();
                    dgvHosts.Rows.Add(ip, domain);
                }
            }
        }

        private bool HaveRightToWrite()
        {
            try
            {
                using (FileStream fs = File.Open(HostsFilePath, FileMode.Open, FileAccess.ReadWrite)) { }
                return true;
            }
            catch
            { return false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!HostsChanged)
                MessageBox.Show("Nothing changed!", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                SaveHostsFile(true);
        }

        private void llHostsFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(HostsFolderPath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private bool SaveHostsFile(bool showOk)
        {
            string[] hostsLines = File.ReadAllLines(HostsFilePath);
            StringBuilder newHostsFile = new StringBuilder();

            for (int i = 0; i < hostsLines.Length; i++)
            {
                string hostLine = hostsLines[i].Trim();
                if (hostLine.StartsWith("#")) // add comments to new file
                    newHostsFile.AppendLine(hostLine);
            }

            newHostsFile.AppendLine("# hosts file edited " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " - Hosts Editor by arunes");
            foreach (DataGridViewRow dgvRow in dgvHosts.Rows)
            { // add new rows
                if (dgvRow.Cells[0].Value != null && dgvRow.Cells[1].Value != null)
                    if (!string.IsNullOrEmpty(dgvRow.Cells[0].Value.ToString().Trim()) &&
                        !string.IsNullOrEmpty(dgvRow.Cells[1].Value.ToString().Trim()))
                        newHostsFile.AppendLine(dgvRow.Cells[0].Value + "\t" + dgvRow.Cells[1].Value);
            }

            try
            {
                File.WriteAllText(HostsFilePath, newHostsFile.ToString());
                if (cbBackup.Checked) File.WriteAllLines(Path.Combine(HostsFolderPath, "hosts" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak"), hostsLines);
                if (showOk) MessageBox.Show("Hosts file saved successfully!", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                HostsChanged = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to save hosts file!\n---------------------\nError: " + ex.Message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        string cellBeforeEdit = null;
        private void dgvHosts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex + 1 < dgvHosts.Rows.Count)
            {
                if (dgvHosts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    ((DataGridViewTextBoxCell)dgvHosts.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value = cellBeforeEdit;
                }
                else
                {
                    string cellAfterEdit = dgvHosts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (cellBeforeEdit != cellAfterEdit) HostsChanged = true;
                    cellBeforeEdit = null;
                }
            }
        }

        private void dgvHosts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex + 1 < dgvHosts.Rows.Count)
                if (dgvHosts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    cellBeforeEdit = dgvHosts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HostsChanged)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes to Hosts file?", AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        if (!SaveHostsFile(false)) e.Cancel = true;
                        break;

                    case System.Windows.Forms.DialogResult.No:

                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog(this);
        }

        private void dgvHosts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HostsChanged = true;
        }
    }
}
