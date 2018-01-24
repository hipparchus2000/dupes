using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dupes
{
    

    public partial class dupesForm : Form
    {
        public class myEntry
        {
            public myEntry(string t, string Sha, long size)
            {
                text = t;
                visible = false;
                Size = size;
                sha = Sha;
            }
            public string text { get; set; }
            public bool visible { get; set; }
            public long Size { get; set; }
            public string sha { get; set; }
        }

        public class dupe
        {
            public string sha { get; set; }
            public List<string> locations { get; set; }
            public long Size { get; internal set; }
        }

        List<myEntry> list;
        
        long myCount = 0;
        private bool enableDisplay;
        private List<dupe> dupeList;
        private bool includeDllsInResults;

        public dupesForm()
        {
            InitializeComponent();
            enableDisplay = false;
            myCount = 0;
            list = new List<myEntry>();
        }

        private void choosePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = new Environment.SpecialFolder();
            folderBrowserDialog1.ShowDialog();
            var path = folderBrowserDialog1.SelectedPath;
            baseDirectory.Text = path;

        }

        private static string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        private static string GetChecksumBuffered(Stream stream)
        {
            using (var bufferedStream = new BufferedStream(stream, 1024 * 32))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(bufferedStream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        private void findDupes_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            var di = new DirectoryInfo(baseDirectory.Text);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                myCount = 0;
                list = new List<myEntry>();
                includeDllsInResults = includeDlls.Checked;

                WalkDirectoryTree(di, countFile);
                WalkDirectoryTree(di, shaFile);
                //group the files by sha into dupeList
                dupeList = new List<dupe>();
                foreach (var fileEntry in list.OrderBy(x => x.sha))
                {
                    var existingDupe = dupeList.SingleOrDefault(x => x.sha == fileEntry.sha);
                    if (existingDupe == null)
                    {
                        dupeList.Add(new dupe
                        {
                            locations = new List<string> { fileEntry.text },
                            sha = fileEntry.sha,
                            Size = fileEntry.Size
                        });

                    } else
                    {
                        existingDupe.locations.Add(fileEntry.text);
                    }
                }
                //prune entries with 1 file
                foreach (var dupeEntry in dupeList.ToArray())
                {
                    if (dupeEntry.locations.Count == 1)
                    {
                        dupeList.Remove(dupeEntry);
                    }
                }

                //display them
                enableDisplay = true;
                

            }).Start();

        }

        public delegate void MyFunction(FileInfo fi);

        public void WalkDirectoryTree(System.IO.DirectoryInfo root, MyFunction func)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            files = root.GetFiles("*.*");

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    func(fi);
                }

                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo, func);
                }
            }
        }

        private void countFile(FileInfo fi)
        {
            myCount++;
        }

        private void shaFile(FileInfo fi)
        {
            var filePath = fi.FullName;
            if (includeDllsInResults == false && ( 
                    filePath.Contains(".dll") 
                    || filePath.Contains(".nupkg")
                    || filePath.Contains(".pdb")
                    || filePath.Contains(".xml")
                    || filePath.Contains(".mdf")
                    || filePath.Contains(".ldf")
                    || filePath.Contains(".js")
                    || filePath.Contains(".ts_")
                    ))
                return;
            var sha = GetChecksum(filePath);
            var size = fi.Length;
            list.Add(new myEntry( filePath , sha, size ));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enableDisplay == true)
            {
                foreach (var dupeEntry in dupeList.OrderByDescending(x=>x.Size).ToArray())
                {
                    TreeNode node = treeView1.Nodes.Add(dupeEntry.Size+"  "+dupeEntry.sha);
                    foreach (var location in dupeEntry.locations)
                    {
                        node.Nodes.Add(location);
                    }
                    dupeList.Remove(dupeEntry);
                }
                enableDisplay = false;
            }
            else
            {
                label3.Text = myCount.ToString() + " files found  " + list.Count().ToString() + " files hashed";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //not currently used - would need to be added to the Node
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hitTest = treeView1.HitTest(treeView1.PointToClient(new Point(contextMenuStrip1.Left, contextMenuStrip1.Top)));
            if (hitTest.Node != null)
            {
                DialogResult dialogResult = MessageBox.Show("Delete", hitTest.Node.Text, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(hitTest.Node.Text);
                    hitTest.Node.Remove();
                }
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        
        private void delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
                return;
            DialogResult dialogResult = MessageBox.Show("Delete", treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(treeView1.SelectedNode.Text);
                var parent = treeView1.SelectedNode.Parent;
                treeView1.SelectedNode.Remove();
                if (parent.Nodes.Count < 2)
                    parent.Remove();

            }

            
        }

        private void deleteDupesFromThisFolder_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
                return;
            var folderName = Path.GetDirectoryName(treeView1.SelectedNode.Text)+"\\";

            DialogResult dialogResult = MessageBox.Show("Delete all dupes from this folder name?", folderName, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                foreach (TreeNode shaNode in treeView1.Nodes)
                {
                    var fileNodesToRemove = new List<TreeNode>();
                    foreach (TreeNode fileNode in shaNode.Nodes)
                    {
                        if (fileNode.Text.Contains(folderName))
                        {
                            File.Delete(fileNode.Text);
                            fileNodesToRemove.Add(fileNode);
                        }
                    }
                    foreach (TreeNode fileNodeToRemove in fileNodesToRemove)
                    {
                        shaNode.Nodes.Remove(fileNodeToRemove);
                    }
                }
                var shaNodesToRemove = new List<TreeNode>();
                foreach (TreeNode shaNode in treeView1.Nodes)
                {
                       if (shaNode.Nodes.Count < 2)
                            shaNodesToRemove.Add(shaNode);                   
                }
                foreach(TreeNode shaNode in shaNodesToRemove)
                {
                    treeView1.Nodes.Remove(shaNode);
                }

            }
        }
    }



}
