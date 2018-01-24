using System.Windows.Forms;

namespace dupes
{
    partial class dupesForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root");
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.baseDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.changePathButton = new System.Windows.Forms.Button();
            this.findDupes = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteDupesInFolder = new System.Windows.Forms.Button();
            this.includeDlls = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStrip1.Text = "File";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "File";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // baseDirectory
            // 
            this.baseDirectory.Location = new System.Drawing.Point(25, 39);
            this.baseDirectory.Name = "baseDirectory";
            this.baseDirectory.Size = new System.Drawing.Size(672, 20);
            this.baseDirectory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(50, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "files";
            // 
            // changePathButton
            // 
            this.changePathButton.Location = new System.Drawing.Point(703, 37);
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.Size = new System.Drawing.Size(75, 23);
            this.changePathButton.TabIndex = 2;
            this.changePathButton.Text = "Change";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.choosePath_Click);
            // 
            // findDupes
            // 
            this.findDupes.Location = new System.Drawing.Point(25, 76);
            this.findDupes.Name = "findDupes";
            this.findDupes.Size = new System.Drawing.Size(75, 23);
            this.findDupes.TabIndex = 3;
            this.findDupes.Text = "find dupes";
            this.findDupes.UseVisualStyleBackColor = true;
            this.findDupes.Click += new System.EventHandler(this.findDupes_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(25, 105);
            this.treeView1.Name = "treeView1";
            treeNode1.ContextMenuStrip = this.contextMenuStrip1;
            treeNode1.Name = "Root";
            treeNode1.Tag = "root";
            treeNode1.Text = "Root";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(897, 262);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "status";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(678, 78);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(73, 20);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.delete_Click);
            // 
            // deleteDupesInFolder
            // 
            this.deleteDupesInFolder.Location = new System.Drawing.Point(757, 79);
            this.deleteDupesInFolder.Name = "deleteDupesInFolder";
            this.deleteDupesInFolder.Size = new System.Drawing.Size(128, 20);
            this.deleteDupesInFolder.TabIndex = 8;
            this.deleteDupesInFolder.Text = "delete dupes in folder";
            this.deleteDupesInFolder.UseVisualStyleBackColor = true;
            this.deleteDupesInFolder.Click += new System.EventHandler(this.deleteDupesFromThisFolder_Click);
            // 
            // includeDlls
            // 
            this.includeDlls.AutoSize = true;
            this.includeDlls.Location = new System.Drawing.Point(738, 12);
            this.includeDlls.Name = "includeDlls";
            this.includeDlls.Size = new System.Drawing.Size(132, 17);
            this.includeDlls.TabIndex = 9;
            this.includeDlls.Text = "include dlls and nupkg";
            this.includeDlls.UseVisualStyleBackColor = true;
            // 
            // dupesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 393);
            this.Controls.Add(this.includeDlls);
            this.Controls.Add(this.deleteDupesInFolder);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.findDupes);
            this.Controls.Add(this.changePathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseDirectory);
            this.Name = "dupesForm";
            this.Text = "Dupes";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox baseDirectory;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private System.Windows.Forms.Button changePathButton;
        private System.Windows.Forms.Button findDupes;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Timer timer1;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button deleteButton;
        private Button deleteDupesInFolder;
        private CheckBox includeDlls;
    }
}

