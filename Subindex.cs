using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Subindex
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Subind : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.NumericUpDown beginIndex;
		private System.Windows.Forms.Label baseLineLabel;
		private System.Windows.Forms.Label uniteSplitLabel;
		private System.Windows.Forms.Label beginIndexLabel;
		private System.Windows.Forms.ComboBox uniteSplit;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TabPage tabOption;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabBuild;
		private System.Windows.Forms.TabPage tabMerge;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkLog;
		private System.Windows.Forms.CheckBox checkUnite;
		private System.Windows.Forms.CheckBox checkFormat;
		private System.ComponentModel.IContainer components;
		private Subindex.TimeBaseLine timeLine;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.NumericUpDown sourceEnd;
		private System.Windows.Forms.NumericUpDown sourceBegin;
		private System.Windows.Forms.Label baseButton;
		private System.Windows.Forms.NumericUpDown indexEnd;
		private System.Windows.Forms.NumericUpDown indexBegin;
		private System.Windows.Forms.ComboBox adjustType;
		private Subindex.TimeBaseLine timeBaseLine2;
		private System.Windows.Forms.TextBox buildTarget;
		private System.Windows.Forms.TextBox buildSource;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.TextBox mergeTarget;
		private System.Windows.Forms.TextBox mergeSource2;
		private System.Windows.Forms.TextBox mergeSource1;
		private System.Windows.Forms.Label moreButton;
		private Subindex.TimeBaseLine timeBaseLine1;
		private System.Windows.Forms.ComboBox mergeMode;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox capSwitch;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.CheckBox secondFront;
		private Subindex.TimeBaseLine timeIgnore;
		private System.Windows.Forms.CheckBox keepUnit;
		private System.Windows.Forms.CheckBox secondTime;
		private Subindex.DropDownButton buildOpen;
		private System.Windows.Forms.ContextMenu recentMenu;
		private System.Windows.Forms.MenuItem recentItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private Subindex.DropDownButton buildSave;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private Subindex.DropDownButton mergeOpen1;
		private Subindex.DropDownButton mergeOpen2;
		private System.Windows.Forms.MenuItem menuItem7;
		private Subindex.DropDownButton mergeSave;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Label buildRangeLabel;
		private System.Windows.Forms.Label adjustTypeLabel;
		private System.Windows.Forms.Label adjustRangeLabel;
		private System.Windows.Forms.Button adjustReset;
		private System.Windows.Forms.Label merge1Adjustlabel;
		private System.Windows.Forms.Label mergeBoundLabel;
		private System.Windows.Forms.Label merge2Adjustlabel;
		private System.Windows.Forms.Label mergeModeLabel;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textAbout;
		private System.Windows.Forms.LinkLabel webSiteLabel;
		private System.Windows.Forms.TabPage tabAbout;
		private System.Windows.Forms.LinkLabel blogLabel;

		private CaptionMerge capMerge=new CaptionMerge();
		private System.Windows.Forms.CheckBox checkIndex;
		private System.Windows.Forms.CheckBox checkSsa;
		private System.Windows.Forms.CheckBox checkAss;
		private System.Windows.Forms.CheckBox checkSrt;
		private System.Windows.Forms.ComboBox cmbSaveDo;
		private System.Windows.Forms.Label saveDoLabel;
		private System.Windows.Forms.GroupBox grpIndex;
		private System.Windows.Forms.GroupBox grpFileType;
		private System.Windows.Forms.GroupBox grpLog;
		private System.Windows.Forms.GroupBox grpFormat;
		private System.Windows.Forms.GroupBox grpWrap;
		private System.Windows.Forms.GroupBox grpAction;
        private TabPage tabBatch;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label label4;
        private ListBox merges1;
        private Label Batchfinish;

		private Caption capBuild;//=new Caption();

        System.Data.DataTable dt = new System.Data.DataTable();
        DataColumn FileName;
        DataColumn FileDirectory;
        private Label label5;
        ArrayList FileList = new ArrayList();
        private FolderBrowserDialog fbd = new FolderBrowserDialog();
		public Subind(string[] args)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			if (args.Length==0) return;
			mergeOpenFile(mergeOpen1,args[0]);
			merge1ToBuild();


			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subind));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBuild = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.baseButton = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buildTarget = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.buildSource = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkIndex = new System.Windows.Forms.CheckBox();
            this.adjustReset = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adjustRangeLabel = new System.Windows.Forms.Label();
            this.adjustTypeLabel = new System.Windows.Forms.Label();
            this.indexEnd = new System.Windows.Forms.NumericUpDown();
            this.indexBegin = new System.Windows.Forms.NumericUpDown();
            this.adjustType = new System.Windows.Forms.ComboBox();
            this.buildRangeLabel = new System.Windows.Forms.Label();
            this.sourceEnd = new System.Windows.Forms.NumericUpDown();
            this.sourceBegin = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buildSave = new Subindex.DropDownButton();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.recentItem = new System.Windows.Forms.MenuItem();
            this.buildOpen = new Subindex.DropDownButton();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.timeLine = new Subindex.TimeBaseLine();
            this.baseLineLabel = new System.Windows.Forms.Label();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.moreButton = new System.Windows.Forms.Label();
            this.mergeTarget = new System.Windows.Forms.TextBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.mergeSource2 = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.mergeSource1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.secondFront = new System.Windows.Forms.CheckBox();
            this.mergeBoundLabel = new System.Windows.Forms.Label();
            this.timeIgnore = new Subindex.TimeBaseLine();
            this.keepUnit = new System.Windows.Forms.CheckBox();
            this.secondTime = new System.Windows.Forms.CheckBox();
            this.capSwitch = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.timeBaseLine2 = new Subindex.TimeBaseLine();
            this.merge1Adjustlabel = new System.Windows.Forms.Label();
            this.timeBaseLine1 = new Subindex.TimeBaseLine();
            this.merge2Adjustlabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mergeSave = new Subindex.DropDownButton();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mergeOpen2 = new Subindex.DropDownButton();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.mergeOpen1 = new Subindex.DropDownButton();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.mergeMode = new System.Windows.Forms.ComboBox();
            this.mergeModeLabel = new System.Windows.Forms.Label();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.saveDoLabel = new System.Windows.Forms.Label();
            this.cmbSaveDo = new System.Windows.Forms.ComboBox();
            this.grpFileType = new System.Windows.Forms.GroupBox();
            this.checkSsa = new System.Windows.Forms.CheckBox();
            this.checkAss = new System.Windows.Forms.CheckBox();
            this.checkSrt = new System.Windows.Forms.CheckBox();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.checkFormat = new System.Windows.Forms.CheckBox();
            this.grpWrap = new System.Windows.Forms.GroupBox();
            this.uniteSplit = new System.Windows.Forms.ComboBox();
            this.uniteSplitLabel = new System.Windows.Forms.Label();
            this.checkUnite = new System.Windows.Forms.CheckBox();
            this.grpIndex = new System.Windows.Forms.GroupBox();
            this.beginIndexLabel = new System.Windows.Forms.Label();
            this.beginIndex = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBatch = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.Batchfinish = new System.Windows.Forms.Label();
            this.merges1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.webSiteLabel = new System.Windows.Forms.LinkLabel();
            this.blogLabel = new System.Windows.Forms.LinkLabel();
            this.textAbout = new System.Windows.Forms.TextBox();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.recentMenu = new System.Windows.Forms.ContextMenu();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabBuild.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceBegin)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpFileType.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.grpWrap.SuspendLayout();
            this.grpIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beginIndex)).BeginInit();
            this.tabBatch.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBuild);
            this.tabControl1.Controls.Add(this.tabMerge);
            this.tabControl1.Controls.Add(this.tabOption);
            this.tabControl1.Controls.Add(this.tabBatch);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 573);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabBuild
            // 
            this.tabBuild.Controls.Add(this.panel1);
            this.tabBuild.Controls.Add(this.panel3);
            this.tabBuild.Controls.Add(this.panel2);
            this.tabBuild.ImageIndex = 2;
            this.tabBuild.Location = new System.Drawing.Point(4, 24);
            this.tabBuild.Name = "tabBuild";
            this.tabBuild.Size = new System.Drawing.Size(784, 545);
            this.tabBuild.TabIndex = 0;
            this.tabBuild.Text = "Build";
            this.tabBuild.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.baseButton);
            this.panel1.Controls.Add(this.buildTarget);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.buildSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 417);
            this.panel1.TabIndex = 5;
            // 
            // baseButton
            // 
            this.baseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baseButton.ImageIndex = 0;
            this.baseButton.ImageList = this.imageList1;
            this.baseButton.Location = new System.Drawing.Point(766, 398);
            this.baseButton.Name = "baseButton";
            this.baseButton.Size = new System.Drawing.Size(18, 18);
            this.baseButton.TabIndex = 60;
            this.baseButton.Click += new System.EventHandler(this.baseButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "bbb.ico");
            // 
            // buildTarget
            // 
            this.buildTarget.AllowDrop = true;
            this.buildTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildTarget.Location = new System.Drawing.Point(393, 0);
            this.buildTarget.Multiline = true;
            this.buildTarget.Name = "buildTarget";
            this.buildTarget.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.buildTarget.Size = new System.Drawing.Size(391, 417);
            this.buildTarget.TabIndex = 1;
            this.buildTarget.TabStop = false;
            this.buildTarget.WordWrap = false;
            this.buildTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.buildSource_DragDrop);
            this.buildTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.buildSource_DragEnter);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(390, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 417);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // buildSource
            // 
            this.buildSource.AllowDrop = true;
            this.buildSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.buildSource.Location = new System.Drawing.Point(0, 0);
            this.buildSource.Multiline = true;
            this.buildSource.Name = "buildSource";
            this.buildSource.ReadOnly = true;
            this.buildSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.buildSource.Size = new System.Drawing.Size(390, 417);
            this.buildSource.TabIndex = 1;
            this.buildSource.TabStop = false;
            this.buildSource.WordWrap = false;
            this.buildSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.buildSource_DragDrop);
            this.buildSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.buildSource_DragEnter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkIndex);
            this.panel3.Controls.Add(this.adjustReset);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.adjustRangeLabel);
            this.panel3.Controls.Add(this.adjustTypeLabel);
            this.panel3.Controls.Add(this.indexEnd);
            this.panel3.Controls.Add(this.indexBegin);
            this.panel3.Controls.Add(this.adjustType);
            this.panel3.Controls.Add(this.buildRangeLabel);
            this.panel3.Controls.Add(this.sourceEnd);
            this.panel3.Controls.Add(this.sourceBegin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 417);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 96);
            this.panel3.TabIndex = 0;
            this.panel3.Visible = false;
            // 
            // checkIndex
            // 
            this.checkIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkIndex.Enabled = false;
            this.checkIndex.Location = new System.Drawing.Point(496, 24);
            this.checkIndex.Name = "checkIndex";
            this.checkIndex.Size = new System.Drawing.Size(176, 20);
            this.checkIndex.TabIndex = 4;
            this.checkIndex.Text = "Keep index";
            this.checkIndex.CheckedChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            // 
            // adjustReset
            // 
            this.adjustReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adjustReset.Location = new System.Drawing.Point(496, 64);
            this.adjustReset.Name = "adjustReset";
            this.adjustReset.Size = new System.Drawing.Size(75, 23);
            this.adjustReset.TabIndex = 8;
            this.adjustReset.Text = "&Reset";
            this.adjustReset.Click += new System.EventHandler(this.adjustReset_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(72, 88);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(640, 3);
            this.label14.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(72, 47);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(640, 3);
            this.label2.TabIndex = 71;
            // 
            // adjustRangeLabel
            // 
            this.adjustRangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.adjustRangeLabel.AutoSize = true;
            this.adjustRangeLabel.Location = new System.Drawing.Point(288, 67);
            this.adjustRangeLabel.Name = "adjustRangeLabel";
            this.adjustRangeLabel.Size = new System.Drawing.Size(83, 12);
            this.adjustRangeLabel.TabIndex = 59;
            this.adjustRangeLabel.Text = "Adjust range:";
            this.adjustRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adjustTypeLabel
            // 
            this.adjustTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.adjustTypeLabel.AutoSize = true;
            this.adjustTypeLabel.Location = new System.Drawing.Point(80, 67);
            this.adjustTypeLabel.Name = "adjustTypeLabel";
            this.adjustTypeLabel.Size = new System.Drawing.Size(77, 12);
            this.adjustTypeLabel.TabIndex = 58;
            this.adjustTypeLabel.Text = "Adjust type:";
            this.adjustTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // indexEnd
            // 
            this.indexEnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.indexEnd.Location = new System.Drawing.Point(432, 64);
            this.indexEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.indexEnd.Name = "indexEnd";
            this.indexEnd.Size = new System.Drawing.Size(40, 21);
            this.indexEnd.TabIndex = 7;
            this.indexEnd.Tag = "";
            this.indexEnd.ValueChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            this.indexEnd.Enter += new System.EventHandler(this.sourceBegin_Enter);
            // 
            // indexBegin
            // 
            this.indexBegin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.indexBegin.Location = new System.Drawing.Point(376, 64);
            this.indexBegin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.indexBegin.Name = "indexBegin";
            this.indexBegin.Size = new System.Drawing.Size(40, 21);
            this.indexBegin.TabIndex = 6;
            this.indexBegin.Tag = "";
            this.indexBegin.ValueChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            this.indexBegin.Enter += new System.EventHandler(this.sourceBegin_Enter);
            // 
            // adjustType
            // 
            this.adjustType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.adjustType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adjustType.Items.AddRange(new object[] {
            "Both",
            "Start",
            "Finish"});
            this.adjustType.Location = new System.Drawing.Point(168, 64);
            this.adjustType.Name = "adjustType";
            this.adjustType.Size = new System.Drawing.Size(88, 20);
            this.adjustType.TabIndex = 5;
            this.adjustType.SelectedIndexChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            // 
            // buildRangeLabel
            // 
            this.buildRangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buildRangeLabel.Location = new System.Drawing.Point(152, 24);
            this.buildRangeLabel.Name = "buildRangeLabel";
            this.buildRangeLabel.Size = new System.Drawing.Size(200, 23);
            this.buildRangeLabel.TabIndex = 52;
            this.buildRangeLabel.Text = "&Build range from  source file:";
            this.buildRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceEnd
            // 
            this.sourceEnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sourceEnd.Location = new System.Drawing.Point(432, 24);
            this.sourceEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sourceEnd.Name = "sourceEnd";
            this.sourceEnd.Size = new System.Drawing.Size(40, 21);
            this.sourceEnd.TabIndex = 3;
            this.sourceEnd.Tag = "";
            this.sourceEnd.ValueChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            this.sourceEnd.Enter += new System.EventHandler(this.sourceBegin_Enter);
            // 
            // sourceBegin
            // 
            this.sourceBegin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sourceBegin.Location = new System.Drawing.Point(376, 24);
            this.sourceBegin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sourceBegin.Name = "sourceBegin";
            this.sourceBegin.Size = new System.Drawing.Size(40, 21);
            this.sourceBegin.TabIndex = 2;
            this.sourceBegin.Tag = "";
            this.sourceBegin.ValueChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            this.sourceBegin.Enter += new System.EventHandler(this.sourceBegin_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buildSave);
            this.panel2.Controls.Add(this.buildOpen);
            this.panel2.Controls.Add(this.timeLine);
            this.panel2.Controls.Add(this.baseLineLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 32);
            this.panel2.TabIndex = 2;
            // 
            // buildSave
            // 
            this.buildSave.AllowRepeat = false;
            this.buildSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buildSave.Enabled = false;
            this.buildSave.Items.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.buildSave.ItemTrack = true;
            this.buildSave.Location = new System.Drawing.Point(680, 8);
            this.buildSave.Name = "buildSave";
            this.buildSave.Size = new System.Drawing.Size(76, 23);
            this.buildSave.SubItem = this.recentItem;
            this.buildSave.TabIndex = 11;
            this.buildSave.Text = "&Save";
            this.buildSave.Click += new System.EventHandler(this.buildSave_Click);
            this.buildSave.DropDownClick += new Subindex.DropDownButton.DropDownClickEventHandler(this.buildSave_DropDownClick);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MergeOrder = -2;
            this.menuItem1.Text = "MergeCache1";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MergeOrder = -1;
            this.menuItem2.Text = "MergeCache2";
            // 
            // recentItem
            // 
            this.recentItem.Enabled = false;
            this.recentItem.Index = 0;
            this.recentItem.MergeType = System.Windows.Forms.MenuMerge.Replace;
            this.recentItem.Text = "Recent";
            // 
            // buildOpen
            // 
            this.buildOpen.AllowRepeat = false;
            this.buildOpen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buildOpen.Items.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem3,
            this.menuItem4});
            this.buildOpen.ItemTrack = true;
            this.buildOpen.Location = new System.Drawing.Point(280, 8);
            this.buildOpen.Name = "buildOpen";
            this.buildOpen.Size = new System.Drawing.Size(76, 23);
            this.buildOpen.SubItem = this.recentItem;
            this.buildOpen.TabIndex = 9;
            this.buildOpen.Text = "&Open";
            this.buildOpen.Click += new System.EventHandler(this.buildOpen_Click);
            this.buildOpen.DropDownClick += new Subindex.DropDownButton.DropDownClickEventHandler(this.buildOpen_DropDownClick);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.MergeOrder = -3;
            this.menuItem9.Text = "MergeCache1";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MergeOrder = -2;
            this.menuItem3.Text = "MergeCache2";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MergeOrder = -1;
            this.menuItem4.Text = "MergeTarget";
            // 
            // timeLine
            // 
            this.timeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLine.Location = new System.Drawing.Point(496, 8);
            this.timeLine.Name = "timeLine";
            this.timeLine.Size = new System.Drawing.Size(120, 24);
            this.timeLine.TabIndex = 10;
            this.timeLine.Value = System.TimeSpan.Parse("00:00:00");
            this.timeLine.ValueChanged += new System.EventHandler(this.adjustType_SelectedIndexChanged);
            // 
            // baseLineLabel
            // 
            this.baseLineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseLineLabel.Location = new System.Drawing.Point(392, 8);
            this.baseLineLabel.Name = "baseLineLabel";
            this.baseLineLabel.Size = new System.Drawing.Size(104, 23);
            this.baseLineLabel.TabIndex = 23;
            this.baseLineLabel.Text = "&Time adjust:";
            this.baseLineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.panel6);
            this.tabMerge.Controls.Add(this.panel4);
            this.tabMerge.Controls.Add(this.panel5);
            this.tabMerge.ImageIndex = 3;
            this.tabMerge.Location = new System.Drawing.Point(4, 24);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Size = new System.Drawing.Size(784, 545);
            this.tabMerge.TabIndex = 1;
            this.tabMerge.Text = "Merge";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.moreButton);
            this.panel6.Controls.Add(this.mergeTarget);
            this.panel6.Controls.Add(this.splitter3);
            this.panel6.Controls.Add(this.mergeSource2);
            this.panel6.Controls.Add(this.splitter2);
            this.panel6.Controls.Add(this.mergeSource1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(784, 409);
            this.panel6.TabIndex = 4;
            // 
            // moreButton
            // 
            this.moreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moreButton.ImageIndex = 0;
            this.moreButton.ImageList = this.imageList1;
            this.moreButton.Location = new System.Drawing.Point(766, 390);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(18, 18);
            this.moreButton.TabIndex = 61;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // mergeTarget
            // 
            this.mergeTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeTarget.Location = new System.Drawing.Point(522, 0);
            this.mergeTarget.Multiline = true;
            this.mergeTarget.Name = "mergeTarget";
            this.mergeTarget.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mergeTarget.Size = new System.Drawing.Size(262, 409);
            this.mergeTarget.TabIndex = 2;
            this.mergeTarget.TabStop = false;
            this.mergeTarget.WordWrap = false;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(519, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 409);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // mergeSource2
            // 
            this.mergeSource2.AllowDrop = true;
            this.mergeSource2.Dock = System.Windows.Forms.DockStyle.Left;
            this.mergeSource2.Location = new System.Drawing.Point(261, 0);
            this.mergeSource2.Multiline = true;
            this.mergeSource2.Name = "mergeSource2";
            this.mergeSource2.ReadOnly = true;
            this.mergeSource2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mergeSource2.Size = new System.Drawing.Size(258, 409);
            this.mergeSource2.TabIndex = 1;
            this.mergeSource2.TabStop = false;
            this.mergeSource2.WordWrap = false;
            this.mergeSource2.DragDrop += new System.Windows.Forms.DragEventHandler(this.buildSource_DragDrop);
            this.mergeSource2.DragEnter += new System.Windows.Forms.DragEventHandler(this.buildSource_DragEnter);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(258, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 409);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // mergeSource1
            // 
            this.mergeSource1.AllowDrop = true;
            this.mergeSource1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mergeSource1.Location = new System.Drawing.Point(0, 0);
            this.mergeSource1.Multiline = true;
            this.mergeSource1.Name = "mergeSource1";
            this.mergeSource1.ReadOnly = true;
            this.mergeSource1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mergeSource1.Size = new System.Drawing.Size(258, 409);
            this.mergeSource1.TabIndex = 0;
            this.mergeSource1.TabStop = false;
            this.mergeSource1.WordWrap = false;
            this.mergeSource1.DragDrop += new System.Windows.Forms.DragEventHandler(this.buildSource_DragDrop);
            this.mergeSource1.DragEnter += new System.Windows.Forms.DragEventHandler(this.buildSource_DragEnter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.capSwitch);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.timeBaseLine2);
            this.panel4.Controls.Add(this.merge1Adjustlabel);
            this.panel4.Controls.Add(this.timeBaseLine1);
            this.panel4.Controls.Add(this.merge2Adjustlabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 409);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 104);
            this.panel4.TabIndex = 2;
            this.panel4.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.secondFront);
            this.panel7.Controls.Add(this.mergeBoundLabel);
            this.panel7.Controls.Add(this.timeIgnore);
            this.panel7.Controls.Add(this.keepUnit);
            this.panel7.Controls.Add(this.secondTime);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(784, 48);
            this.panel7.TabIndex = 1;
            // 
            // secondFront
            // 
            this.secondFront.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.secondFront.Location = new System.Drawing.Point(392, 24);
            this.secondFront.Name = "secondFront";
            this.secondFront.Size = new System.Drawing.Size(138, 24);
            this.secondFront.TabIndex = 6;
            this.secondFront.Text = "Second in front";
            this.secondFront.CheckedChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // mergeBoundLabel
            // 
            this.mergeBoundLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mergeBoundLabel.Location = new System.Drawing.Point(536, 24);
            this.mergeBoundLabel.Name = "mergeBoundLabel";
            this.mergeBoundLabel.Size = new System.Drawing.Size(90, 23);
            this.mergeBoundLabel.TabIndex = 74;
            this.mergeBoundLabel.Text = "&Time adjust:";
            this.mergeBoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeIgnore
            // 
            this.timeIgnore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.timeIgnore.Location = new System.Drawing.Point(640, 24);
            this.timeIgnore.Name = "timeIgnore";
            this.timeIgnore.Size = new System.Drawing.Size(120, 24);
            this.timeIgnore.TabIndex = 7;
            this.timeIgnore.Value = System.TimeSpan.Parse("00:00:01.5000000");
            this.timeIgnore.ValueChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // keepUnit
            // 
            this.keepUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keepUnit.Location = new System.Drawing.Point(112, 24);
            this.keepUnit.Name = "keepUnit";
            this.keepUnit.Size = new System.Drawing.Size(122, 24);
            this.keepUnit.TabIndex = 4;
            this.keepUnit.Text = "Keep unit";
            this.keepUnit.CheckedChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // secondTime
            // 
            this.secondTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.secondTime.Location = new System.Drawing.Point(240, 24);
            this.secondTime.Name = "secondTime";
            this.secondTime.Size = new System.Drawing.Size(146, 24);
            this.secondTime.TabIndex = 5;
            this.secondTime.Text = "Second time Line";
            this.secondTime.CheckedChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // capSwitch
            // 
            this.capSwitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.capSwitch.Location = new System.Drawing.Point(604, 72);
            this.capSwitch.Name = "capSwitch";
            this.capSwitch.Size = new System.Drawing.Size(120, 24);
            this.capSwitch.TabIndex = 10;
            this.capSwitch.Text = "Switch caption";
            this.capSwitch.CheckedChanged += new System.EventHandler(this.capSwitch_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(80, 96);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(640, 3);
            this.label19.TabIndex = 71;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Location = new System.Drawing.Point(80, 51);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(640, 3);
            this.label20.TabIndex = 70;
            // 
            // timeBaseLine2
            // 
            this.timeBaseLine2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.timeBaseLine2.Location = new System.Drawing.Point(376, 72);
            this.timeBaseLine2.Name = "timeBaseLine2";
            this.timeBaseLine2.Size = new System.Drawing.Size(120, 24);
            this.timeBaseLine2.TabIndex = 9;
            this.timeBaseLine2.Tag = "";
            this.timeBaseLine2.Value = System.TimeSpan.Parse("00:00:00");
            this.timeBaseLine2.ValueChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // merge1Adjustlabel
            // 
            this.merge1Adjustlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.merge1Adjustlabel.Location = new System.Drawing.Point(32, 72);
            this.merge1Adjustlabel.Name = "merge1Adjustlabel";
            this.merge1Adjustlabel.Size = new System.Drawing.Size(90, 23);
            this.merge1Adjustlabel.TabIndex = 65;
            this.merge1Adjustlabel.Text = "&Time adjust:";
            this.merge1Adjustlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeBaseLine1
            // 
            this.timeBaseLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeBaseLine1.Location = new System.Drawing.Point(136, 72);
            this.timeBaseLine1.Name = "timeBaseLine1";
            this.timeBaseLine1.Size = new System.Drawing.Size(120, 24);
            this.timeBaseLine1.TabIndex = 8;
            this.timeBaseLine1.Tag = "";
            this.timeBaseLine1.Value = System.TimeSpan.Parse("00:00:00");
            this.timeBaseLine1.ValueChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // merge2Adjustlabel
            // 
            this.merge2Adjustlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.merge2Adjustlabel.Location = new System.Drawing.Point(288, 72);
            this.merge2Adjustlabel.Name = "merge2Adjustlabel";
            this.merge2Adjustlabel.Size = new System.Drawing.Size(90, 23);
            this.merge2Adjustlabel.TabIndex = 57;
            this.merge2Adjustlabel.Text = "&Time adjust:";
            this.merge2Adjustlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.mergeSave);
            this.panel5.Controls.Add(this.mergeOpen2);
            this.panel5.Controls.Add(this.mergeOpen1);
            this.panel5.Controls.Add(this.mergeMode);
            this.panel5.Controls.Add(this.mergeModeLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 513);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 32);
            this.panel5.TabIndex = 2;
            // 
            // mergeSave
            // 
            this.mergeSave.AllowRepeat = false;
            this.mergeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeSave.Items.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.mergeSave.ItemTrack = true;
            this.mergeSave.Location = new System.Drawing.Point(704, 8);
            this.mergeSave.Name = "mergeSave";
            this.mergeSave.Size = new System.Drawing.Size(76, 23);
            this.mergeSave.SubItem = this.recentItem;
            this.mergeSave.TabIndex = 14;
            this.mergeSave.Text = "Save";
            this.mergeSave.Click += new System.EventHandler(this.mergeSave_Click);
            this.mergeSave.DropDownClick += new Subindex.DropDownButton.DropDownClickEventHandler(this.mergeSave_DropDownClick);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.MergeOrder = -1;
            this.menuItem6.Text = "BuildCache";
            // 
            // mergeOpen2
            // 
            this.mergeOpen2.AllowRepeat = false;
            this.mergeOpen2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mergeOpen2.Items.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8});
            this.mergeOpen2.ItemTrack = true;
            this.mergeOpen2.Location = new System.Drawing.Point(400, 8);
            this.mergeOpen2.Name = "mergeOpen2";
            this.mergeOpen2.Size = new System.Drawing.Size(76, 23);
            this.mergeOpen2.SubItem = this.recentItem;
            this.mergeOpen2.TabIndex = 12;
            this.mergeOpen2.Text = "Open";
            this.mergeOpen2.Click += new System.EventHandler(this.mergeOpen1_Click);
            this.mergeOpen2.DropDownClick += new Subindex.DropDownButton.DropDownClickEventHandler(this.mergeOpen1_DropDownClick);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.MergeOrder = -1;
            this.menuItem8.Text = "BuildCache";
            // 
            // mergeOpen1
            // 
            this.mergeOpen1.AllowRepeat = false;
            this.mergeOpen1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mergeOpen1.Items.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7});
            this.mergeOpen1.ItemTrack = true;
            this.mergeOpen1.Location = new System.Drawing.Point(160, 8);
            this.mergeOpen1.Name = "mergeOpen1";
            this.mergeOpen1.Size = new System.Drawing.Size(76, 23);
            this.mergeOpen1.SubItem = this.recentItem;
            this.mergeOpen1.TabIndex = 11;
            this.mergeOpen1.Text = "Open";
            this.mergeOpen1.Click += new System.EventHandler(this.mergeOpen1_Click);
            this.mergeOpen1.DropDownClick += new Subindex.DropDownButton.DropDownClickEventHandler(this.mergeOpen1_DropDownClick);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.MergeOrder = -1;
            this.menuItem7.Text = "BuildCache";
            // 
            // mergeMode
            // 
            this.mergeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mergeMode.Items.AddRange(new object[] {
            "by Time",
            "by Block",
            "by Serial"});
            this.mergeMode.Location = new System.Drawing.Point(584, 8);
            this.mergeMode.Name = "mergeMode";
            this.mergeMode.Size = new System.Drawing.Size(96, 20);
            this.mergeMode.TabIndex = 13;
            this.mergeMode.SelectedIndexChanged += new System.EventHandler(this.keepUnit_CheckedChanged);
            // 
            // mergeModeLabel
            // 
            this.mergeModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeModeLabel.Location = new System.Drawing.Point(504, 8);
            this.mergeModeLabel.Name = "mergeModeLabel";
            this.mergeModeLabel.Size = new System.Drawing.Size(90, 23);
            this.mergeModeLabel.TabIndex = 66;
            this.mergeModeLabel.Text = "&Merge mode:";
            this.mergeModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.grpLog);
            this.tabOption.Controls.Add(this.grpAction);
            this.tabOption.Controls.Add(this.grpFileType);
            this.tabOption.Controls.Add(this.grpFormat);
            this.tabOption.Controls.Add(this.grpWrap);
            this.tabOption.Controls.Add(this.grpIndex);
            this.tabOption.Controls.Add(this.comboBox1);
            this.tabOption.Controls.Add(this.label1);
            this.tabOption.ImageIndex = 4;
            this.tabOption.Location = new System.Drawing.Point(4, 24);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(10);
            this.tabOption.Size = new System.Drawing.Size(784, 545);
            this.tabOption.TabIndex = 2;
            this.tabOption.Text = "Option";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.checkLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLog.Location = new System.Drawing.Point(10, 435);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(764, 85);
            this.grpLog.TabIndex = 5;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Output Log";
            // 
            // checkLog
            // 
            this.checkLog.Checked = true;
            this.checkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLog.Enabled = false;
            this.checkLog.Location = new System.Drawing.Point(176, 40);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(200, 24);
            this.checkLog.TabIndex = 4;
            this.checkLog.Text = "Keep &build Log";
            this.checkLog.CheckedChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.saveDoLabel);
            this.grpAction.Controls.Add(this.cmbSaveDo);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Location = new System.Drawing.Point(10, 350);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(764, 85);
            this.grpAction.TabIndex = 4;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action define";
            // 
            // saveDoLabel
            // 
            this.saveDoLabel.Location = new System.Drawing.Point(176, 40);
            this.saveDoLabel.Name = "saveDoLabel";
            this.saveDoLabel.Size = new System.Drawing.Size(128, 23);
            this.saveDoLabel.TabIndex = 51;
            this.saveDoLabel.Text = "After file saved do:";
            // 
            // cmbSaveDo
            // 
            this.cmbSaveDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaveDo.Items.AddRange(new object[] {
            "Dialog",
            "View",
            "Nothing"});
            this.cmbSaveDo.Location = new System.Drawing.Point(304, 40);
            this.cmbSaveDo.Name = "cmbSaveDo";
            this.cmbSaveDo.Size = new System.Drawing.Size(104, 20);
            this.cmbSaveDo.TabIndex = 50;
            this.cmbSaveDo.SelectedIndexChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // grpFileType
            // 
            this.grpFileType.Controls.Add(this.checkSsa);
            this.grpFileType.Controls.Add(this.checkAss);
            this.grpFileType.Controls.Add(this.checkSrt);
            this.grpFileType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFileType.Location = new System.Drawing.Point(10, 265);
            this.grpFileType.Name = "grpFileType";
            this.grpFileType.Size = new System.Drawing.Size(764, 85);
            this.grpFileType.TabIndex = 3;
            this.grpFileType.TabStop = false;
            this.grpFileType.Text = "Registry associate";
            // 
            // checkSsa
            // 
            this.checkSsa.Location = new System.Drawing.Point(272, 40);
            this.checkSsa.Name = "checkSsa";
            this.checkSsa.Size = new System.Drawing.Size(104, 24);
            this.checkSsa.TabIndex = 53;
            this.checkSsa.Tag = ".ssa";
            this.checkSsa.Text = ".ssa";
            this.checkSsa.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkAss
            // 
            this.checkAss.Location = new System.Drawing.Point(384, 40);
            this.checkAss.Name = "checkAss";
            this.checkAss.Size = new System.Drawing.Size(104, 24);
            this.checkAss.TabIndex = 54;
            this.checkAss.Tag = ".ass";
            this.checkAss.Text = ".ass";
            this.checkAss.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkSrt
            // 
            this.checkSrt.Location = new System.Drawing.Point(176, 40);
            this.checkSrt.Name = "checkSrt";
            this.checkSrt.Size = new System.Drawing.Size(104, 24);
            this.checkSrt.TabIndex = 52;
            this.checkSrt.Tag = ".srt";
            this.checkSrt.Text = ".srt";
            this.checkSrt.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.checkFormat);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormat.Location = new System.Drawing.Point(10, 180);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(764, 85);
            this.grpFormat.TabIndex = 2;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Display style";
            // 
            // checkFormat
            // 
            this.checkFormat.Location = new System.Drawing.Point(176, 40);
            this.checkFormat.Name = "checkFormat";
            this.checkFormat.Size = new System.Drawing.Size(241, 24);
            this.checkFormat.TabIndex = 3;
            this.checkFormat.Text = "&Keep original format";
            this.checkFormat.CheckedChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // grpWrap
            // 
            this.grpWrap.Controls.Add(this.uniteSplit);
            this.grpWrap.Controls.Add(this.uniteSplitLabel);
            this.grpWrap.Controls.Add(this.checkUnite);
            this.grpWrap.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpWrap.Location = new System.Drawing.Point(10, 95);
            this.grpWrap.Name = "grpWrap";
            this.grpWrap.Size = new System.Drawing.Size(764, 85);
            this.grpWrap.TabIndex = 1;
            this.grpWrap.TabStop = false;
            this.grpWrap.Text = "Multi-line option";
            // 
            // uniteSplit
            // 
            this.uniteSplit.Items.AddRange(new object[] {
            " ",
            "-",
            ",",
            "|",
            "\\",
            "/",
            "\\N"});
            this.uniteSplit.Location = new System.Drawing.Point(632, 40);
            this.uniteSplit.Name = "uniteSplit";
            this.uniteSplit.Size = new System.Drawing.Size(48, 20);
            this.uniteSplit.TabIndex = 2;
            this.uniteSplit.SelectedIndexChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            this.uniteSplit.TextChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // uniteSplitLabel
            // 
            this.uniteSplitLabel.Location = new System.Drawing.Point(480, 40);
            this.uniteSplitLabel.Name = "uniteSplitLabel";
            this.uniteSplitLabel.Size = new System.Drawing.Size(146, 23);
            this.uniteSplitLabel.TabIndex = 21;
            this.uniteSplitLabel.Text = "&Unite separator:";
            // 
            // checkUnite
            // 
            this.checkUnite.Checked = true;
            this.checkUnite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUnite.Location = new System.Drawing.Point(176, 40);
            this.checkUnite.Name = "checkUnite";
            this.checkUnite.Size = new System.Drawing.Size(248, 24);
            this.checkUnite.TabIndex = 1;
            this.checkUnite.Text = "Unite &multi-line words";
            this.checkUnite.CheckedChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // grpIndex
            // 
            this.grpIndex.Controls.Add(this.beginIndexLabel);
            this.grpIndex.Controls.Add(this.beginIndex);
            this.grpIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpIndex.Location = new System.Drawing.Point(10, 10);
            this.grpIndex.Name = "grpIndex";
            this.grpIndex.Size = new System.Drawing.Size(764, 85);
            this.grpIndex.TabIndex = 0;
            this.grpIndex.TabStop = false;
            this.grpIndex.Text = "Index Setting";
            // 
            // beginIndexLabel
            // 
            this.beginIndexLabel.Location = new System.Drawing.Point(176, 40);
            this.beginIndexLabel.Name = "beginIndexLabel";
            this.beginIndexLabel.Size = new System.Drawing.Size(112, 23);
            this.beginIndexLabel.TabIndex = 20;
            this.beginIndexLabel.Text = "&Index begin from:";
            // 
            // beginIndex
            // 
            this.beginIndex.Location = new System.Drawing.Point(328, 40);
            this.beginIndex.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.beginIndex.Name = "beginIndex";
            this.beginIndex.Size = new System.Drawing.Size(40, 21);
            this.beginIndex.TabIndex = 0;
            this.beginIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.beginIndex.ValueChanged += new System.EventHandler(this.beginIndex_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            ",",
            "."});
            this.comboBox1.Location = new System.Drawing.Point(224, 512);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 49;
            this.label1.Text = "毫秒分割符:";
            this.label1.Visible = false;
            // 
            // tabBatch
            // 
            this.tabBatch.Controls.Add(this.label5);
            this.tabBatch.Controls.Add(this.Batchfinish);
            this.tabBatch.Controls.Add(this.merges1);
            this.tabBatch.Controls.Add(this.label4);
            this.tabBatch.Controls.Add(this.button2);
            this.tabBatch.Controls.Add(this.button1);
            this.tabBatch.Controls.Add(this.textBox1);
            this.tabBatch.Controls.Add(this.label3);
            this.tabBatch.ImageIndex = 6;
            this.tabBatch.Location = new System.Drawing.Point(4, 24);
            this.tabBatch.Name = "tabBatch";
            this.tabBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabBatch.Size = new System.Drawing.Size(784, 545);
            this.tabBatch.TabIndex = 4;
            this.tabBatch.Text = "Batch";
            this.tabBatch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "共0个文件";
            // 
            // Batchfinish
            // 
            this.Batchfinish.AutoSize = true;
            this.Batchfinish.Location = new System.Drawing.Point(520, 194);
            this.Batchfinish.Name = "Batchfinish";
            this.Batchfinish.Size = new System.Drawing.Size(59, 12);
            this.Batchfinish.TabIndex = 7;
            this.Batchfinish.Text = "合并完成!";
            this.Batchfinish.Visible = false;
            // 
            // merges1
            // 
            this.merges1.FormattingEnabled = true;
            this.merges1.HorizontalScrollbar = true;
            this.merges1.ItemHeight = 12;
            this.merges1.Location = new System.Drawing.Point(59, 131);
            this.merges1.Name = "merges1";
            this.merges1.Size = new System.Drawing.Size(426, 352);
            this.merges1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "打开";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(625, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "执行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(460, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "请确定目录下需要合并的文件名分别为***.chs.srt和***.eng.srt（***为任意文件名）\r\n合并结果将保存为不带chs或者eng的srt文件";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.webSiteLabel);
            this.tabAbout.Controls.Add(this.blogLabel);
            this.tabAbout.Controls.Add(this.textAbout);
            this.tabAbout.ImageIndex = 5;
            this.tabAbout.Location = new System.Drawing.Point(4, 24);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(30);
            this.tabAbout.Size = new System.Drawing.Size(784, 545);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // webSiteLabel
            // 
            this.webSiteLabel.AutoSize = true;
            this.webSiteLabel.BackColor = System.Drawing.Color.Transparent;
            this.webSiteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webSiteLabel.Location = new System.Drawing.Point(512, 10);
            this.webSiteLabel.Name = "webSiteLabel";
            this.webSiteLabel.Size = new System.Drawing.Size(89, 12);
            this.webSiteLabel.TabIndex = 3;
            this.webSiteLabel.TabStop = true;
            this.webSiteLabel.Tag = "http://blog.csdn.net/redbirdli/category/182219.aspx";
            this.webSiteLabel.Text = "Author WebSite";
            this.webSiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.blogLabel_LinkClicked);
            // 
            // blogLabel
            // 
            this.blogLabel.AutoSize = true;
            this.blogLabel.BackColor = System.Drawing.Color.Transparent;
            this.blogLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blogLabel.Location = new System.Drawing.Point(80, 10);
            this.blogLabel.Name = "blogLabel";
            this.blogLabel.Size = new System.Drawing.Size(71, 12);
            this.blogLabel.TabIndex = 2;
            this.blogLabel.TabStop = true;
            this.blogLabel.Tag = "http://blog.csdn.net/redbirdli";
            this.blogLabel.Text = "Author Blog";
            this.blogLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.blogLabel_LinkClicked);
            // 
            // textAbout
            // 
            this.textAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAbout.Location = new System.Drawing.Point(30, 30);
            this.textAbout.Multiline = true;
            this.textAbout.Name = "textAbout";
            this.textAbout.ReadOnly = true;
            this.textAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAbout.Size = new System.Drawing.Size(724, 485);
            this.textAbout.TabIndex = 1;
            // 
            // menuItem5
            // 
            this.menuItem5.Index = -1;
            this.menuItem5.Text = "menuItem5";
            // 
            // recentMenu
            // 
            this.recentMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.recentItem});
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // Subind
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Subind";
            this.Text = "Subindex";
            this.Load += new System.EventHandler(this.Subind_Load);
            this.Resize += new System.EventHandler(this.Subind_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabBuild.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceBegin)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabMerge.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpFileType.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpWrap.ResumeLayout(false);
            this.grpIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beginIndex)).EndInit();
            this.tabBatch.ResumeLayout(false);
            this.tabBatch.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			Application.Run(new Subind(args));

		}



		private void Subind_Load(object sender, System.EventArgs e)
		{
			Pub.BuildUi(this);
            if (File.Exists(Application.StartupPath + @"\readme.txt"))
            textAbout.Text=Pub.ReadFileString(Application.StartupPath+@"\readme.txt");
			DragDropAgent.DragDropHook(this.grpIndex);
			DragDropAgent.DragDropHook(this.grpWrap);
			DragDropAgent.DragDropHook(this.grpFormat);
			DragDropAgent.DragDropHook(this.grpLog);
			DragDropAgent.DragDropHook(this.grpFileType);
			DragDropAgent.DragDropHook(this.grpAction);
			checkSrt.Checked=Pub.GetRegState(checkSrt.Tag.ToString());
			checkSsa.Checked=Pub.GetRegState(checkSsa.Tag.ToString());
			checkAss.Checked=Pub.GetRegState(checkAss.Tag.ToString());
			try
			{
				beginIndex.Value=decimal.Parse(AppSettings.ReadSetting("BeginIndex"));
				checkUnite.Checked=bool.Parse(AppSettings.ReadSetting("UniteLine"));
				checkFormat.Checked=bool.Parse(AppSettings.ReadSetting("KeepFormat"));
				tabControl1.SelectedIndex=int.Parse(Pub.GetSetting("ShowPage"));
				cmbSaveDo.SelectedIndex=(int) Enum.Parse(typeof(SaveDoType),Pub.GetSetting("SavedDoType"));
				baseButton.ImageIndex=System.Convert.ToInt32(panel3.Visible=bool.Parse(AppSettings.ReadSetting("BuildTab")));
				moreButton.ImageIndex=System.Convert.ToInt32(panel4.Visible=bool.Parse(AppSettings.ReadSetting("MergeTab")));
				uniteSplit.Text=AppSettings.ReadSetting("WrapSplit");

			}
			catch  (Exception ee)
			{
						System.Windows.Forms.MessageBox.Show(ee.Message);
			}

			this.Tag="";
			beginIndex_ValueChanged(null,null);

            FileName = new DataColumn("FileName", typeof(string));
            FileDirectory = new DataColumn("FileDirectory", typeof(string));
            dt.Columns.Add(FileName);
            dt.Columns.Add(FileDirectory);
		}





//		private void BindCaption(Caption cp)
//		{
////			timeLine.DataBindings.Add("Value",cp,"TimeBaseLine");
////			sourceBegin.DataBindings.Add("Value",cp,"BuildFirstIndex");
//			//textBox8.DataBindings.Add("Text",cp,"Test");
//
//
//		}

		private void Subind_Resize(object sender, System.EventArgs e)
		{
			buildSource.Width=this.Width/2-20;
			mergeSource1.Width=mergeSource2.Width=this.Width/3-20;
		}




		private void baseButton_Click(object sender, System.EventArgs e)
		{
			//panel3.Visible=!panel3.Visible;
			baseButton.ImageIndex=System.Convert.ToInt32(panel3.Visible=!panel3.Visible);
			AppSettings.WriteSetting("BuildTab",panel3.Visible.ToString());

		}

//		private void sourceBegin_ValueChanged(object sender, System.EventArgs e)
//		{
//			if (capBuild==null) return;
//			int Value=(int)(sender as NumericUpDown).Value;
//			switch ((sender as Control).Name)
//			{
//				case "sourceBegin":
//					capBuild.BuildFirstIndex=Value;
//					checkIndex.Enabled=Value>Pub.BeginIndex;
//					break;
//				case "sourceEnd":
//					capBuild.BuildLastIndex=Value;
//					break;
//				case "indexBegin":
//					capBuild.AdjustFirstIndex=Value;
//					break;
//				case "indexEnd":
//					capBuild.AdjustLastIndex=Value;
//					break;
//			}
//			buildTarget.Text=capBuild.ToString();
//		}

		private void sourceBegin_Enter(object sender, System.EventArgs e)
		{
			switch ((sender as Control).Name)
			{
				case "sourceBegin":
					sourceBegin.Maximum=sourceEnd.Value;
					break;
				case "sourceEnd":
					sourceEnd.Minimum=sourceBegin.Value;
					break;
				case "indexBegin":
					indexBegin.Maximum=indexEnd.Value;
					//indexBegin.Minimum=capBuild.BuildFirstIndex;
					break;
				case "indexEnd":
					indexEnd.Minimum=indexBegin.Value;
					//indexEnd.Maximum=capBuild.BuildLastIndex;
					break;
			}
		}


		private void moreButton_Click(object sender, System.EventArgs e)
		{
			moreButton.ImageIndex=System.Convert.ToInt32(panel4.Visible=!panel4.Visible);
			AppSettings.WriteSetting("MergeTab",panel4.Visible.ToString());
		}




		private void capSwitch_Click(object sender, System.EventArgs e)
		{
			capMerge.Switch();
			mergeTarget.Text=capMerge.ToString();
			string temp=mergeSource1.Text;
			mergeSource1.Text=mergeSource2.Text;
			mergeSource2.Text=temp;
			TimeSpan ts=timeBaseLine2.Value;
			timeBaseLine2.Value=timeBaseLine1.Value;
			timeBaseLine1.Value=ts;
		}

		



		private void buildSave_Click(object sender, System.EventArgs e)
		{
			buildSave.AddMenu(Pub.SaveFile(capBuild.ToString()));
		}
		
		private void buildSave_DropDownClick(object sender,  DropDownButton.DropDownClickEventArgs e)
		{
			switch  (e.ClickItem.MergeOrder)
			{
				case -2:
//					mergeSource1.Text=buildTarget.Text;
//					capMerge.Caption1=capBuild;
//					timeBaseLine1.Value=capBuild.TimeBaseLine;
					buildToMerge1();
					break;
				case -1:
//					mergeSource2.Text=buildTarget.Text;
//					capMerge.Caption2=capBuild;
//					timeBaseLine2.Value=capBuild.TimeBaseLine;
					buildToMerge2();
					break;
				default:
					buildSave.AddMenu(Pub.SaveFile(capBuild.ToString(),e.ClickItem.Text,false));
					break;
			}

		}


		private bool captionNull(object obj,string objName)
		{
			bool isNull=obj==null;
			if (isNull) MessageBox.Show(objName+Pub.GetSetting("ObjectNullText"),Pub.GetSetting("ObjectNullTitle"),MessageBoxButtons.OK,MessageBoxIcon.Warning);
			return isNull;
		}


		private void buildOpenFile(string FileName)
		{	
			capBuild=Pub.LoadFile(FileName,buildSource);
			if (capBuild!=null)
			{
				//timeLine.Value=capBuild.TimeBaseLine;//new TimeSpan(0);
				buildOpen.AddMenu(FileName);
				capBuildUpdate();
				//beginIndex_ValueChanged(null,null);
			}
		
		}

		private void buildOpen_Click(object sender, System.EventArgs e)
		{
			buildOpenFile(Pub.OpenFile());
		}

		private void buildOpen_DropDownClick(object sender,  DropDownButton.DropDownClickEventArgs  e)
		{
			switch  (e.ClickItem.MergeOrder)
			{
				case -3:
					merge1ToBuild();
					break;
				case -2:
					merge2ToBuild();
					break;
				case -1:
					mergeToBuild();
					break;
				default:
					//					OpenFile(buildOpen,capBuild,buildSource,(sender as MenuItem).Text);
					buildOpenFile(e.ClickItem.Text);

					break;
			}
		}

		private void capBuildUpdate()
		{
			if (capBuild==null) return;

			this.Tag="0";
			
			sourceBegin.Minimum=Pub.BeginIndex;
			sourceEnd.Maximum=Pub.BeginIndex+capBuild.Count-1;

			sourceBegin.Value=capBuild.BuildFirstIndex;
			sourceEnd.Value=capBuild.BuildLastIndex>sourceEnd.Maximum?sourceEnd.Maximum:capBuild.BuildLastIndex;

			indexBegin.Minimum=Pub.BeginIndex;
			indexEnd.Maximum=Pub.BeginIndex+capBuild.Count-1;

			indexBegin.Value=capBuild.AdjustFirstIndex;
			indexEnd.Value=capBuild.AdjustLastIndex;

			timeLine.Value=capBuild.TimeBaseLine;
			buildTarget.Text=capBuild.ToString();
			buildSave.Enabled=buildTarget.Text!="";
			checkIndex.Enabled=sourceBegin.Value>Pub.BeginIndex;
			this.Tag="1";
		}


		private void beginIndex_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.Tag==null) return;
			Pub.WrapSplit=uniteSplit.Text;
			Pub.AutoWrap=checkUnite.Checked;
			Pub.KeepFormat=checkFormat.Checked;
			Pub.KeepLog=checkLog.Checked;
			Pub.BeginIndex=(int)beginIndex.Value;
			Pub.SaveDoType=(SaveDoType)cmbSaveDo.SelectedIndex;
			uniteSplit.Enabled=checkUnite.Checked;

			if (sender==null) return;

			if (capBuild!=null) capBuild.AutoWrap=Pub.AutoWrap;
			capBuildUpdate();
			//timeLine_ValueChanged(sender,e);
			keepUnit_CheckedChanged(sender,e);
			//if (capMerge.Caption1!=null) mergeSource1.Text=capMerge.Caption1.ToString();
			//if (capMerge.Caption2!=null) mergeSource2.Text=capMerge.Caption2.ToString();
			AppSettings.WriteSetting("BeginIndex",beginIndex.Value.ToString());
			AppSettings.WriteSetting("UniteLine",checkUnite.Checked.ToString());
			AppSettings.WriteSetting("WrapSplit",uniteSplit.Text);
			AppSettings.WriteSetting("KeepFormat",checkFormat.Checked.ToString());
			AppSettings.WriteSetting("SavedDoType",((SaveDoType)cmbSaveDo.SelectedIndex).ToString());
		}


		private void adjustType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (capBuild==null||this.Tag.ToString()=="0") return;
			capBuild.AdjustArea=adjustType.SelectedIndex;
			capBuild.BuildFirstIndex=(int)sourceBegin.Value;
			checkIndex.Enabled=sourceBegin.Value>Pub.BeginIndex;
			capBuild.KeepIndex=checkIndex.Checked;
			capBuild.BuildLastIndex=(int)sourceEnd.Value;
			capBuild.AdjustFirstIndex=(int)indexBegin.Value;
			capBuild.AdjustLastIndex=(int)indexEnd.Value;
			capBuild.TimeBaseLine=timeLine.Value;
			buildTarget.Text=capBuild.ToString();
		}
//
//		private void timeLine_ValueChanged(object sender, EventArgs e)
//		{
//			if (capBuild==null) return;
//			//capBuild.AutoWrap=Pub.AutoWrap;
//			capBuild.TimeBaseLine=timeLine.Value;
//			buildTarget.Text=capBuild.ToString();
//		}


		private void merge1ToBuild()
		{
			if (captionNull(capMerge.Caption1,Pub.GetSetting("buildOpen0"))) return;
			capBuild=capMerge.Caption1;
			buildSource.Text=mergeSource1.Text;
			capBuildUpdate();
		}

		private void merge2ToBuild()
		{
			if (captionNull(capMerge.Caption2,Pub.GetSetting("buildOpen1"))) return;
			capBuild=capMerge.Caption2;
			buildSource.Text=mergeSource2.Text;
			capBuildUpdate();
		}

		private void mergeToBuild()
		{
			if (captionNull(mergeTarget.Lines.Length==0?null:"",Pub.GetSetting("buildOpen2"))) return;
			capBuild=CaptionParser.ParseSrt(mergeTarget.Lines);
			buildSource.Text=mergeTarget.Text;
			capBuild.AutoWrap=false;
			capBuildUpdate();
		}

		private void buildToMerge1()
		{
			if (captionNull(capBuild,Pub.GetSetting("mergeOpen10"))) return;
			capMerge.Caption1=capBuild.Clone(true);
			mergeSource1.Text=capMerge.Caption1.ToString();
			timeBaseLine1.Value=capBuild.TimeBaseLine;
		}
		private void buildToMerge2()
		{
			if (captionNull(capBuild,Pub.GetSetting("mergeOpen10"))) return;
			capMerge.Caption2=capBuild.Clone(true);
			mergeSource2.Text=capMerge.Caption2.ToString();
			timeBaseLine2.Value=capBuild.TimeBaseLine;
		}
 
		private void mergeOpenFile(DropDownButton sender ,string FileName)
		{
			Caption ct=null;
			if (sender.Name=="mergeOpen1")
			{
				ct=capMerge.Caption1=Pub.LoadFile(FileName,mergeSource1);
				if (ct==null) return;
				timeBaseLine1.Value=ct.TimeBaseLine;//new TimeSpan(0);
			}
			else
			{
				ct=capMerge.Caption2=Pub.LoadFile(FileName,mergeSource2);
				if (ct==null) return;
				timeBaseLine2.Value=ct.TimeBaseLine;//new TimeSpan(0);
			}
			if (ct!=null) sender.AddMenu(FileName);
			//keepUnit_CheckedChanged(null,null);
		}

		private void mergeOpen1_Click(object sender, System.EventArgs e)
		{
			mergeOpenFile(sender as DropDownButton,Pub.OpenFile());

		}


		private void mergeOpen1_DropDownClick(object sender,  DropDownButton.DropDownClickEventArgs  e)
		{
			DropDownButton obj=sender as DropDownButton;
			switch  (e.ClickItem.MergeOrder)
			{
				case -1:
					if (obj.Name=="mergeOpen1")
						buildToMerge1();
					else
						buildToMerge2();
					//keepUnit_CheckedChanged(null,null);
					break;
				default:
					mergeOpenFile(obj,e.ClickItem.Text);
					break;
			}

		}

		private void keepUnit_CheckedChanged(object sender, System.EventArgs e)
		{	
			capMerge.MergeMode=(MergeType)mergeMode.SelectedIndex;
			capMerge.isRepeatHead=keepUnit.Checked;
			secondFront.Enabled=secondTime.Enabled=!keepUnit.Checked;
			capMerge.isSecondFront=secondFront.Checked;
			capMerge.isSecondTime=secondTime.Checked;
			capMerge.TimeIgnore=timeIgnore.Value;
			if (capMerge.Caption1!=null)  capMerge.Caption1.TimeBaseLine=timeBaseLine1.Value;
			if (capMerge.Caption2!=null)  capMerge.Caption2.TimeBaseLine=timeBaseLine2.Value;
			panel7.Enabled=mergeMode.SelectedIndex!=2;
			timeIgnore.Enabled=mergeMode.SelectedIndex!=1&&!keepUnit.Checked;
			mergeTarget.Text=capMerge.ToString();
			mergeSave.Enabled=mergeTarget.Text!="";
		}

		private void mergeSave_Click(object sender, System.EventArgs e)
		{
			mergeSave.AddMenu(Pub.SaveFile(capMerge.ToString()));

		}

		private void mergeSave_DropDownClick(object sender, Subindex.DropDownButton.DropDownClickEventArgs e)
		{
			switch  (e.ClickItem.MergeOrder)
			{
				case -1:
					mergeToBuild();
					break;
				default:
					mergeSave.AddMenu(Pub.SaveFile(capMerge.ToString(),e.ClickItem.Text,false));
					break;
			}

		}



//
//		private void mergeOpenFile(string sourceFile)
//		{
//			if (!File.Exists(sourceFile)) return;
//			string[] buffer=Pub.ReadFile(sourceFile);
////			if  (((sender as Control).Name)=="sourceFile1")
////			{
////				mergeSource1.Lines=buffer;
////				capMerge.Caption1=CaptionParser.Parse(buffer);
////			}
////			else
////			{
////				mergeSource2.Lines=buffer;
////				capMerge.Caption2=CaptionParser.Parse(buffer);
////			}
////
////			keepUnit_CheckedChanged(sender,e);
//
//			//mergeSource1.Text=capMerge.Caption1.ToString();
//
//		}








		private void adjustReset_Click(object sender, System.EventArgs e)
		{
			if (capBuild==null) return;
			capBuild.AdjustReset();
			capBuildUpdate();
//			buildTarget.Text=capBuild.ToString();
//			timeLine.Value=capBuild.TimeBaseLine;
//			indexBegin.Value=capBuild.AdjustFirstIndex;
//			indexEnd.Value=capBuild.AdjustLastIndex;

		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox cb=sender as CheckBox;
			if (cb.Checked)
			{
				Pub.RegFileType(cb.Tag.ToString());
				//Pub.RegFileType(cb.Tag.ToString());
			}
			else
			{
				Pub.UnRegFileType(cb.Tag.ToString());
				//Pub.UnRegFileType(cb.Tag.ToString());
			}

			Pub.SetAppReg();
		}





		private void buildSource_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
				e.Effect = DragDropEffects.Move ;
			else
				e.Effect = DragDropEffects.None;
		}

		private void buildSource_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string[] Files=(string[])e.Data.GetData(DataFormats.FileDrop,true);


			switch ((sender as TextBox).Name)
			{
				case "buildSource":
					buildOpenFile(Files[0]);
					break;
				case "buildTarget":
					buildOpenFile(Files[0]);
					break;
				case "mergeSource1":
					mergeOpenFile(mergeOpen1,Files[0]);
					break;
				case "mergeSource2":
					mergeOpenFile(mergeOpen2,Files[0]);
					break;
			}

		}

		private void blogLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start((sender as Label).Tag.ToString());
		}


		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.Tag!=null) 
			AppSettings.WriteSetting("ShowPage",tabControl1.SelectedIndex.ToString());
		
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            fbd.ShowDialog();
            System.Data.DataTable ddt1 = GetFileList(fbd.SelectedPath,FileList);
            merges1.DataSource = ddt1; //merges1.DisplayMember = "FileName";
            merges1.DisplayMember = "FileName";
            label5.Text = "共" + FileList.Count + "个文件";
            textBox1.Text = fbd.SelectedPath;
            if (textBox1.Text!= "") button1.Enabled = true;
        }



//		private void checkFixed_CheckedChanged(object sender, System.EventArgs e)
//		{
//			if (capBuild==null) return;
//			capBuild.KeepIndex=checkIndex.Checked;
//			buildTarget.Text=capBuild.ToString();
//		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDir">指定路径</param>
        /// <param name="strFilePattern">要与strDir 中的文件名匹配的搜索字符串</param>
        /// <param name="arrDirs">查询得到的所有目录ArrayList</param>
        /// <param name="arrFiles">查询得到的所有文件名称ArrayList</param>
        /// <param name="bIsRecursive">是否递归查询</param>
        private System.Data.DataTable GetFileList(string strDir,ArrayList arrFiles)
        {
            
            if (string.IsNullOrEmpty(strDir)||(!Directory.Exists(strDir)))
            {　 // 参数正确性检查
                return dt;
            }

            dt.Clear();
            arrFiles.Clear();
            //清理工作完毕
            try
            {
                // 取得指定路径下所有符合条件的文件
                string[] strFiles = Directory.GetFiles(strDir, "*.chs.srt");

                foreach (string name in strFiles)
                {　 // 将所有文件名称加入结果ArrayList中
                    string engname = name.Substring(0,name.Length-7)+"eng.srt";
                    if (File.Exists(engname))
                    {
                        DataRow dr = dt.NewRow();
                        arrFiles.Add(name);
                        string strFileName = GetFileName(name);
                        dr[FileName] = strFileName;//添加到文件名称：列
                        dr[FileDirectory] = GetDirectory(name);//添加到文件目录：列
                        dt.Rows.Add(dr);
                    }
                }

                
            }
            catch (Exception e)
            {
                MessageBox.Show("报错" + e.Message);
            }
            return dt;
        }
        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileName(String path)
        {
            if (path.Contains("\\"))
            {
                string[] arr = path.Split('\\');
                return arr[arr.Length - 1];
            }
            else
            {
                string[] arr = path.Split('/');
                return arr[arr.Length - 1];
            }
        }

        /// <summary>
        /// 获取文件目录
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static String GetDirectory(string filename)
        {
            return filename.Substring(0, filename.LastIndexOf("\\"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Batchfinish.Visible = false;
            int cnt = 0,total=FileList.Count;
            foreach (string name in FileList)
            {   
                    cnt++;
                    label5.Text = "共" + FileList.Count + "个文件" + "   正在处理第" + cnt + "个";
                    string engname=name.Substring(0,name.Length-7)+"eng.srt";
                    string outname=name.Substring(0,name.Length-7)+"srt";
                    Caption ct = null;
                    ct = capMerge.Caption1 = Pub.LoadFile(name, mergeSource1);
                    if (ct == null) return;
                    timeBaseLine1.Value = ct.TimeBaseLine;//new TimeSpan(0);

                    ct = capMerge.Caption2 = Pub.LoadFile(engname, mergeSource2);
                    if (ct == null) return;
                    timeBaseLine2.Value = ct.TimeBaseLine;//new TimeSpan(0);

                    Pub.SaveFile(capMerge.ToString(),outname,true);
                    
            }
            label5.Text = "共" + FileList.Count + "个文件";
            Batchfinish.Visible = true;
        }


	}
}
