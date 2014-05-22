namespace BillManageWPF.winFormUI
{
    partial class BillSerchListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillSerchListForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bdnInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lbCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLastPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrInt32View = new System.Windows.Forms.ToolStripButton();
            this.toolPrInt32More = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLeading = new System.Windows.Forms.ToolStripButton();
            this.toolExport = new System.Windows.Forms.ToolStripButton();
            this.toolline = new System.Windows.Forms.ToolStripSeparator();
            this.toolSerch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBillInfo = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.bdsInfo = new System.Windows.Forms.BindingSource(this.components);
            this.saveExcelDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).BeginInit();
            this.bdnInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 516);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.bdnInfo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1004, 76);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // bdnInfo
            // 
            this.bdnInfo.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bdnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bdnInfo.CountItem = this.bindingNavigatorCountItem;
            this.bdnInfo.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome,
            this.btnPrevious,
            this.toolStripSeparator6,
            this.lbCurrentPage,
            this.toolStripLabel1,
            this.lblPageCount,
            this.toolStripSeparator5,
            this.btnNext,
            this.btnLastPage,
            this.toolStripSeparator4,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.btnSelectAll,
            this.btnClearAll});
            this.bdnInfo.Location = new System.Drawing.Point(0, 51);
            this.bdnInfo.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnInfo.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnInfo.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnInfo.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnInfo.Name = "bdnInfo";
            this.bdnInfo.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnInfo.Size = new System.Drawing.Size(1004, 25);
            this.bdnInfo.TabIndex = 10;
            this.bdnInfo.Text = "bindingNavigator1";
            this.bdnInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bdnInfo_ItemClicked);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // btnHome
            // 
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(36, 22);
            this.btnHome.Text = "首页";
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(48, 22);
            this.btnPrevious.Text = "上一页";
            this.btnPrevious.ToolTipText = "上一页";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // lbCurrentPage
            // 
            this.lbCurrentPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbCurrentPage.ForeColor = System.Drawing.Color.White;
            this.lbCurrentPage.Name = "lbCurrentPage";
            this.lbCurrentPage.Size = new System.Drawing.Size(15, 22);
            this.lbCurrentPage.Text = "0";
            this.lbCurrentPage.ToolTipText = "当前页";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "-";
            // 
            // lblPageCount
            // 
            this.lblPageCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblPageCount.ForeColor = System.Drawing.Color.White;
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(15, 22);
            this.lblPageCount.Text = "0";
            this.lblPageCount.ToolTipText = "总页数";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 22);
            this.btnNext.Text = "下一页";
            // 
            // btnLastPage
            // 
            this.btnLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLastPage.ForeColor = System.Drawing.Color.White;
            this.btnLastPage.Image = ((System.Drawing.Image)(resources.GetObject("btnLastPage.Image")));
            this.btnLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(36, 22);
            this.btnLastPage.Text = "尾页";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(36, 22);
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.toolSelectAll_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(36, 22);
            this.btnClearAll.Text = "取消";
            this.btnClearAll.Click += new System.EventHandler(this.toolClearAll_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolStripSeparator1,
            this.toolPrInt32View,
            this.toolPrInt32More,
            this.toolStripSeparator2,
            this.toolLeading,
            this.toolExport,
            this.toolline,
            this.toolSerch,
            this.toolStripSeparator3,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1004, 51);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.BackColor = System.Drawing.Color.SkyBlue;
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSave.ForeColor = System.Drawing.Color.White;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(49, 48);
            this.toolSave.Text = "保  存";
            this.toolSave.ToolTipText = "点击保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            this.toolSave.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolSave.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolCancel
            // 
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolCancel.ForeColor = System.Drawing.Color.White;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(49, 48);
            this.toolCancel.Text = "取  消";
            this.toolCancel.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolCancel.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // toolPrInt32View
            // 
            this.toolPrInt32View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrInt32View.ForeColor = System.Drawing.Color.White;
            this.toolPrInt32View.Image = ((System.Drawing.Image)(resources.GetObject("toolPrInt32View.Image")));
            this.toolPrInt32View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrInt32View.Name = "toolPrInt32View";
            this.toolPrInt32View.Size = new System.Drawing.Size(49, 48);
            this.toolPrInt32View.Text = "预  览";
            this.toolPrInt32View.Click += new System.EventHandler(this.toolPrInt32View_Click);
            this.toolPrInt32View.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolPrInt32View.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolPrInt32More
            // 
            this.toolPrInt32More.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrInt32More.ForeColor = System.Drawing.Color.White;
            this.toolPrInt32More.Image = ((System.Drawing.Image)(resources.GetObject("toolPrInt32More.Image")));
            this.toolPrInt32More.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrInt32More.Name = "toolPrInt32More";
            this.toolPrInt32More.Size = new System.Drawing.Size(69, 48);
            this.toolPrInt32More.Text = "批量套打";
            this.toolPrInt32More.Click += new System.EventHandler(this.toolPrInt32More_Click);
            this.toolPrInt32More.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolPrInt32More.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // toolLeading
            // 
            this.toolLeading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLeading.ForeColor = System.Drawing.Color.White;
            this.toolLeading.Image = ((System.Drawing.Image)(resources.GetObject("toolLeading.Image")));
            this.toolLeading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLeading.Name = "toolLeading";
            this.toolLeading.Size = new System.Drawing.Size(49, 48);
            this.toolLeading.Text = "导  入";
            this.toolLeading.Click += new System.EventHandler(this.toolLeading_Click);
            this.toolLeading.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolLeading.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolExport
            // 
            this.toolExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolExport.ForeColor = System.Drawing.Color.White;
            this.toolExport.Image = ((System.Drawing.Image)(resources.GetObject("toolExport.Image")));
            this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExport.Name = "toolExport";
            this.toolExport.Size = new System.Drawing.Size(49, 48);
            this.toolExport.Text = "导  出";
            this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
            this.toolExport.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolExport.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolline
            // 
            this.toolline.Name = "toolline";
            this.toolline.Size = new System.Drawing.Size(6, 51);
            // 
            // toolSerch
            // 
            this.toolSerch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSerch.ForeColor = System.Drawing.Color.White;
            this.toolSerch.Image = ((System.Drawing.Image)(resources.GetObject("toolSerch.Image")));
            this.toolSerch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSerch.Name = "toolSerch";
            this.toolSerch.Size = new System.Drawing.Size(49, 48);
            this.toolSerch.Text = "过  滤";
            this.toolSerch.Click += new System.EventHandler(this.toolSerch_Click);
            this.toolSerch.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolSerch.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 51);
            // 
            // toolExit
            // 
            this.toolExit.BackColor = System.Drawing.Color.SkyBlue;
            this.toolExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolExit.ForeColor = System.Drawing.Color.White;
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(61, 48);
            this.toolExit.Text = " 退  出  ";
            this.toolExit.ToolTipText = "点击退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            this.toolExit.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolExit.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgvBillInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 436);
            this.panel1.TabIndex = 0;
            // 
            // dgvBillInfo
            // 
            this.dgvBillInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBillInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected});
            this.dgvBillInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvBillInfo.Name = "dgvBillInfo";
            this.dgvBillInfo.RowTemplate.Height = 23;
            this.dgvBillInfo.Size = new System.Drawing.Size(1004, 436);
            this.dgvBillInfo.TabIndex = 3;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Width = 40;
            // 
            // pd
            // 
            this.pd.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pd_BeginPrint);
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // BillSerchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 516);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BillSerchListForm";
            this.Text = "票据查询";
            this.Load += new System.EventHandler(this.BillSerchListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnInfo)).EndInit();
            this.bdnInfo.ResumeLayout(false);
            this.bdnInfo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Drawing.Printing.PrintDocument pd;
        private System.Windows.Forms.BindingSource bdsInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPrInt32View;
        private System.Windows.Forms.ToolStripButton toolPrInt32More;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolLeading;
        private System.Windows.Forms.ToolStripButton toolExport;
        private System.Windows.Forms.ToolStripSeparator toolline;
        private System.Windows.Forms.ToolStripButton toolSerch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBillInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.SaveFileDialog saveExcelDialog;
        private System.Windows.Forms.BindingNavigator bdnInfo;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLastPage;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel lbCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.ToolStripButton btnClearAll;
    }
}