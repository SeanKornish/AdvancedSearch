using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AdvancedSearch
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private Button btnSearch;
        private CheckBox chkRecursive;
        private Label label2;
        private TextBox txtSourceDir;
        private Label label4;
        private Button btnTargetDir;
        private Button btnSetSource;
        private Label label3;
        private TextBox txtTargetDir;
        private TextBox txtFilter;
        private Button btnMove;
        private Button btnSearchDir;
        private TextBox txtSearchDir;
        private Label label5;
        private Button btnRenameDir;
        private TextBox txtRenameDir;
        private Label label6;
        private CheckBox chkRenameSub;
        private Button btnRename;
        private TextBox txtRenameFiles;
        private Label label7;
        private Label label8;
        private TextBox txtSearchFilter;
        private Label label1;
        int x;
        private CheckBox chkInverse;
        private ListView lstSearchResults;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;

        enum Mode
        {
            Search,
            Move,
            Rename
        }

        Mode currentMode;
        private ListViewColumnSorter lvwColumnSorter;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.lstSearchResults.ListViewItemSorter = lvwColumnSorter;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkInverse = new System.Windows.Forms.CheckBox();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDir = new System.Windows.Forms.Button();
            this.txtSearchDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMove = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTargetDir = new System.Windows.Forms.Button();
            this.btnSetSource = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRenameFiles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRenameDir = new System.Windows.Forms.Button();
            this.txtRenameDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkRenameSub = new System.Windows.Forms.CheckBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.lstSearchResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 33);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 223);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkInverse);
            this.tabPage1.Controls.Add(this.txtSearchFilter);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnSearchDir);
            this.tabPage1.Controls.Add(this.txtSearchDir);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.chkRecursive);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkInverse
            // 
            this.chkInverse.AutoSize = true;
            this.chkInverse.Location = new System.Drawing.Point(255, 49);
            this.chkInverse.Name = "chkInverse";
            this.chkInverse.Size = new System.Drawing.Size(87, 24);
            this.chkInverse.TabIndex = 9;
            this.chkInverse.Text = "Inverse";
            this.chkInverse.UseVisualStyleBackColor = true;
            // 
            // txtSearchFilter
            // 
            this.txtSearchFilter.Location = new System.Drawing.Point(167, 47);
            this.txtSearchFilter.Name = "txtSearchFilter";
            this.txtSearchFilter.Size = new System.Drawing.Size(76, 26);
            this.txtSearchFilter.TabIndex = 8;
            this.txtSearchFilter.Text = "*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "File Filter";
            // 
            // btnSearchDir
            // 
            this.btnSearchDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDir.Location = new System.Drawing.Point(665, 9);
            this.btnSearchDir.Name = "btnSearchDir";
            this.btnSearchDir.Size = new System.Drawing.Size(52, 29);
            this.btnSearchDir.TabIndex = 6;
            this.btnSearchDir.Text = "...";
            this.btnSearchDir.UseVisualStyleBackColor = true;
            this.btnSearchDir.Click += new System.EventHandler(this.btnSearchDir_Click);
            // 
            // txtSearchDir
            // 
            this.txtSearchDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDir.Location = new System.Drawing.Point(167, 9);
            this.txtSearchDir.Name = "txtSearchDir";
            this.txtSearchDir.ReadOnly = true;
            this.txtSearchDir.Size = new System.Drawing.Size(498, 26);
            this.txtSearchDir.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Search Directory";
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(167, 85);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(192, 24);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Search Subdirectories";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(167, 118);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMove);
            this.tabPage2.Controls.Add(this.txtFilter);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnTargetDir);
            this.tabPage2.Controls.Add(this.btnSetSource);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtTargetDir);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtSourceDir);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(723, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Batch Move";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(160, 123);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(120, 33);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "Move Files";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(160, 85);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(77, 26);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.Text = "*.*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "File Filter";
            // 
            // btnTargetDir
            // 
            this.btnTargetDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTargetDir.Location = new System.Drawing.Point(659, 47);
            this.btnTargetDir.Name = "btnTargetDir";
            this.btnTargetDir.Size = new System.Drawing.Size(52, 29);
            this.btnTargetDir.TabIndex = 2;
            this.btnTargetDir.Text = "...";
            this.btnTargetDir.UseVisualStyleBackColor = true;
            this.btnTargetDir.Click += new System.EventHandler(this.btnTargetDir_Click);
            // 
            // btnSetSource
            // 
            this.btnSetSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetSource.Location = new System.Drawing.Point(659, 9);
            this.btnSetSource.Name = "btnSetSource";
            this.btnSetSource.Size = new System.Drawing.Size(52, 29);
            this.btnSetSource.TabIndex = 2;
            this.btnSetSource.Text = "...";
            this.btnSetSource.UseVisualStyleBackColor = true;
            this.btnSetSource.Click += new System.EventHandler(this.btnSetSource_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Target Directory";
            // 
            // txtTargetDir
            // 
            this.txtTargetDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetDir.Location = new System.Drawing.Point(160, 47);
            this.txtTargetDir.Name = "txtTargetDir";
            this.txtTargetDir.ReadOnly = true;
            this.txtTargetDir.Size = new System.Drawing.Size(499, 26);
            this.txtTargetDir.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Source Directory";
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceDir.Location = new System.Drawing.Point(160, 9);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.ReadOnly = true;
            this.txtSourceDir.Size = new System.Drawing.Size(499, 26);
            this.txtSourceDir.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtRenameFiles);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnRenameDir);
            this.tabPage3.Controls.Add(this.txtRenameDir);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.chkRenameSub);
            this.tabPage3.Controls.Add(this.btnRename);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(723, 190);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Batch Rename";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(704, 43);
            this.label8.TabIndex = 14;
            this.label8.Text = "This will rename all the files found to the name given and append numbers before " +
    "the extension.  The extension will not be replaced.";
            // 
            // txtRenameFiles
            // 
            this.txtRenameFiles.Location = new System.Drawing.Point(160, 16);
            this.txtRenameFiles.Name = "txtRenameFiles";
            this.txtRenameFiles.Size = new System.Drawing.Size(551, 26);
            this.txtRenameFiles.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Rename Files to:";
            // 
            // btnRenameDir
            // 
            this.btnRenameDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameDir.Location = new System.Drawing.Point(659, 108);
            this.btnRenameDir.Name = "btnRenameDir";
            this.btnRenameDir.Size = new System.Drawing.Size(52, 29);
            this.btnRenameDir.TabIndex = 11;
            this.btnRenameDir.Text = "...";
            this.btnRenameDir.UseVisualStyleBackColor = true;
            this.btnRenameDir.Click += new System.EventHandler(this.btnRenameDir_Click);
            // 
            // txtRenameDir
            // 
            this.txtRenameDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRenameDir.Location = new System.Drawing.Point(160, 108);
            this.txtRenameDir.Name = "txtRenameDir";
            this.txtRenameDir.ReadOnly = true;
            this.txtRenameDir.Size = new System.Drawing.Size(499, 26);
            this.txtRenameDir.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Search Directory";
            // 
            // chkRenameSub
            // 
            this.chkRenameSub.AutoSize = true;
            this.chkRenameSub.Location = new System.Drawing.Point(160, 148);
            this.chkRenameSub.Name = "chkRenameSub";
            this.chkRenameSub.Size = new System.Drawing.Size(218, 24);
            this.chkRenameSub.TabIndex = 8;
            this.chkRenameSub.Text = "Rename in Subdirectories";
            this.chkRenameSub.UseVisualStyleBackColor = true;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(17, 142);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(120, 33);
            this.btnRename.TabIndex = 7;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSearchResults.HideSelection = false;
            this.lstSearchResults.Location = new System.Drawing.Point(0, 256);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(733, 216);
            this.lstSearchResults.TabIndex = 16;
            this.lstSearchResults.UseCompatibleStateImageBehavior = false;
            this.lstSearchResults.View = System.Windows.Forms.View.Details;
            this.lstSearchResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSearchResults_ColumnClick);
            this.lstSearchResults.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstSearchResults_KeyUp_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 340;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(733, 472);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(755, 528);
            this.Name = "Form1";
            this.Text = "Advanced Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void Search(string sDir)
        {
            Wait();
            lstSearchResults.Items.Clear();
            SearchOption option = SearchOption.TopDirectoryOnly;
            string filter = "*.*";

            switch (currentMode)
            {
                case Mode.Search:
                    if (chkRecursive.Checked)
                        option = SearchOption.AllDirectories;

                    if (!chkInverse.Checked)
                        filter = txtSearchFilter.Text;

                    break;                
                case Mode.Rename:
                    x = 0;

                    if (chkRenameSub.Checked)
                        option = SearchOption.AllDirectories;
                    break;
                case Mode.Move:
                    filter = txtFilter.Text;
                    break;
                default:
                    break;
            }
            Application.DoEvents();

            if (String.IsNullOrEmpty(sDir))
            {
                MessageBox.Show("Please set the directory(s) first.", "Error");
                Ready();
                return;
            }

            if (option == SearchOption.AllDirectories)
            {
                foreach (string f in GetAllFileNames(sDir, filter))
                {
                    FileHandler(f);
                }
            }
            else
            {
                foreach (string f in Directory.GetFiles(sDir, filter, SearchOption.TopDirectoryOnly))
                {
                    FileHandler(f);
                }
            }

            Ready();
        }

        public List<string> GetAllFileNames(string baseDir, string filter)
        {
            List<string> fl = new List<string>();
            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push(baseDir);

            while (directoryStack.Count > 0)
            {
                string currentDir = directoryStack.Pop();
                try
                {
                    foreach (string fileName in Directory.GetFiles(currentDir, filter))
                    {
                        fl.Add(fileName);
                    }

                    foreach (string directoryName in Directory.GetDirectories(currentDir))
                    {
                        directoryStack.Push(directoryName);
                    }
                }
                catch { }
            }

            fl.Sort();
            return fl;
        }

        private void Ready()
        {
            Text = "Advanced Search";
            Cursor = Cursors.Default;
            foreach (Control var in Controls)
                var.Enabled = true;
        }

        private void Wait()
        {
            Cursor = Cursors.WaitCursor;
            foreach (Control var in Controls)
                var.Enabled = false;
        }

        private void FileHandler(string sFile)
        {
            this.Text = "Advanced Search: " + new FileInfo(sFile).Name;
            Application.DoEvents();

            switch (currentMode)
            {
                case Mode.Search:

                    FileInfo fi = new FileInfo(sFile);
                    if (chkInverse.Checked)
                    {
                        if (("*" + fi.Extension.ToLower()) != txtSearchFilter.Text.ToLower())
                        {
                            ListViewItem lvi = new ListViewItem(fi.Name);
                            lvi.SubItems.Add(GetFileType(fi.Extension));
                            lvi.SubItems.Add(sFile);
                            lstSearchResults.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(fi.Name);
                        lvi.SubItems.Add(GetFileType(fi.Extension));
                        lvi.SubItems.Add(sFile);
                        lstSearchResults.Items.Add(lvi);
                    }

                    break;
                case Mode.Move:
                    MoveIt(sFile, txtTargetDir.Text);
                    break;
                case Mode.Rename:
                    Rename(sFile, txtRenameFiles.Text);
                    break;
                default:
                    break;
            }
        }

        private string GetFileType(string extension)
        {
            if (String.IsNullOrEmpty(extension))
                return "";

            string ext = extension.Remove(0, 1).ToLower();
            switch (ext)
            {
                case "mp3":
                    return "Music - MP3";
                case "jpg":
                    return "Image - JPEG";
                default:
                    return ext;
            }
        }

        private void MoveIt(string file, string targetDir)
        {
            try
            {
                string tg = targetDir + "\\" + new FileInfo(file).Name;
                File.Move(file, tg);
                lstSearchResults.Items.Add(file + " moved to " + tg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving. " + ex.ToString());
            }
        }

        private void Rename(string file, string newName)
        {
            try
            {                
                FileInfo fi = new FileInfo(file);                
                x++;
                string target = fi.DirectoryName + "\\" + newName + x + fi.Extension;
                File.Move(file, target);
                File.Delete(file);
                lstSearchResults.Items.Add(file + " renamed to " + target);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming. " + ex.ToString());
            }
        }    

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //XmlDocument xdoc = new XmlDocument();
            //StreamReader sr = new StreamReader("Filters.xml");
            //string filterText = sr.ReadToEnd();
            //sr.Close();
            //xdoc.LoadXml(filterText);
            //XmlNodeList nodes = xdoc.SelectNodes("Filters/Filter");
            //filters = new  Collection<KeyValuePair<string, string>>();

            //foreach (XmlNode node in nodes)
            //{
            //    string display = node.SelectSingleNode("Display").InnerText;
            //    string filterValue = node.SelectSingleNode("FilterValue").InnerText;

            //    filters.Add(new KeyValuePair<string,string>(display, filterValue));
            //    chkFilters.Items.Add(display);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            currentMode = Mode.Search;
            Search(txtSearchDir.Text);            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSetSource_Click(object sender, EventArgs e)
        {
            SetDirectory(txtSourceDir);
        }

        private void btnTargetDir_Click(object sender, EventArgs e)
        {
            SetDirectory(txtTargetDir);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            currentMode = Mode.Move;
            Search(txtSourceDir.Text); 
        }

        private void btnSearchDir_Click(object sender, EventArgs e)
        {
            SetDirectory(txtSearchDir);
        }

        private void SetDirectory(TextBox txt)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select the working folder.";
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txt.Text = dlg.SelectedPath;
            }

        }

        private void btnRenameDir_Click(object sender, EventArgs e)
        {
            SetDirectory(txtRenameDir);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRenameFiles.Text))
            {
                MessageBox.Show("Please set the new name first.", "Error");
                Ready();
                return;
            }

            currentMode = Mode.Rename;
            Search(txtRenameDir.Text); 
        }

        private void lstSearchResults_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvi in lstSearchResults.SelectedItems)
                {
                    File.Delete(lvi.SubItems[2].Text);
                    lstSearchResults.Items.Remove(lvi);
                }                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            lstSearchResults.Columns[0].Width = -2;
            lstSearchResults.Columns[1].Width = -2;
            lstSearchResults.Columns[2].Width = -2;
        }

        private void lstSearchResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.lstSearchResults.Sort();
        }

    }
}
