namespace BillManageWPF.Forms
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PrintView = new System.Windows.Forms.ToolStripButton();
            this.Print = new System.Windows.Forms.ToolStripButton();
            this.NewBill = new System.Windows.Forms.ToolStripButton();
            this.SerchBill = new System.Windows.Forms.ToolStripButton();
            this.OpenDataSource = new System.Windows.Forms.ToolStripButton();
            this.SaveToDataSource = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.DesignContext = new MyExtendControls.MyControls.RulePanel.Document();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DesignContext);
            this.splitContainer1.Size = new System.Drawing.Size(944, 359);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.PrintView,
            this.Print,
            this.NewBill,
            this.SerchBill,
            this.OpenDataSource,
            this.SaveToDataSource,
            this.Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PrintView
            // 
            this.PrintView.BackColor = System.Drawing.Color.SkyBlue;
            this.PrintView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PrintView.ForeColor = System.Drawing.Color.White;
            this.PrintView.Image = ((System.Drawing.Image)(resources.GetObject("PrintView.Image")));
            this.PrintView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintView.Name = "PrintView";
            this.PrintView.Size = new System.Drawing.Size(66, 51);
            this.PrintView.Text = "  预 览 ";
            this.PrintView.ToolTipText = "点击进入打印预览";
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.SkyBlue;
            this.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Print.ForeColor = System.Drawing.Color.White;
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(76, 51);
            this.Print.Text = "   打 印  ";
            this.Print.ToolTipText = "点击打印";
            // 
            // NewBill
            // 
            this.NewBill.BackColor = System.Drawing.Color.SkyBlue;
            this.NewBill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NewBill.ForeColor = System.Drawing.Color.White;
            this.NewBill.Image = ((System.Drawing.Image)(resources.GetObject("NewBill.Image")));
            this.NewBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewBill.Name = "NewBill";
            this.NewBill.Size = new System.Drawing.Size(72, 51);
            this.NewBill.Text = " 新开票 ";
            this.NewBill.ToolTipText = "点击开一个新的账单";
            // 
            // SerchBill
            // 
            this.SerchBill.BackColor = System.Drawing.Color.SkyBlue;
            this.SerchBill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SerchBill.ForeColor = System.Drawing.Color.White;
            this.SerchBill.Image = ((System.Drawing.Image)(resources.GetObject("SerchBill.Image")));
            this.SerchBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SerchBill.Name = "SerchBill";
            this.SerchBill.Size = new System.Drawing.Size(78, 51);
            this.SerchBill.Text = "票据查询";
            this.SerchBill.ToolTipText = "点击查询本模板下的票据";
            // 
            // OpenDataSource
            // 
            this.OpenDataSource.BackColor = System.Drawing.Color.SkyBlue;
            this.OpenDataSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenDataSource.ForeColor = System.Drawing.Color.White;
            this.OpenDataSource.Image = ((System.Drawing.Image)(resources.GetObject("OpenDataSource.Image")));
            this.OpenDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenDataSource.Name = "OpenDataSource";
            this.OpenDataSource.Size = new System.Drawing.Size(72, 51);
            this.OpenDataSource.Text = " 资料表 ";
            this.OpenDataSource.ToolTipText = "点击打开资料表（数据源）";
            // 
            // SaveToDataSource
            // 
            this.SaveToDataSource.BackColor = System.Drawing.Color.SkyBlue;
            this.SaveToDataSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveToDataSource.ForeColor = System.Drawing.Color.White;
            this.SaveToDataSource.Image = ((System.Drawing.Image)(resources.GetObject("SaveToDataSource.Image")));
            this.SaveToDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToDataSource.Name = "SaveToDataSource";
            this.SaveToDataSource.Size = new System.Drawing.Size(78, 51);
            this.SaveToDataSource.Text = "保存资料";
            this.SaveToDataSource.ToolTipText = "点击将保存张票据到资料表（对应的绑定控件）";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.SkyBlue;
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(71, 51);
            this.Save.Text = "  保 存  ";
            this.Save.ToolTipText = "点击保存";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.SkyBlue;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(71, 51);
            this.Exit.Text = "  退 出  ";
            this.Exit.ToolTipText = "点击退出";
            // 
            // DesignContext
            // 
            this.DesignContext.BackColor = System.Drawing.Color.SkyBlue;
            this.DesignContext.BackGroundHeight = 456;
            this.DesignContext.BackGroundWidth = 456;
            this.DesignContext.ColumnGap = 0D;
            this.DesignContext.ColumnRepeats = 1;
            this.DesignContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesignContext.LabelDisplayHeight = 40D;
            this.DesignContext.LabelDisplayWidth = 40D;
            this.DesignContext.LabelOriginHeight = 40D;
            this.DesignContext.LabelOriginWidth = 40D;
            this.DesignContext.Location = new System.Drawing.Point(0, 0);
            this.DesignContext.MarginLeft = 0D;
            this.DesignContext.MarginTop = 0D;
            this.DesignContext.Name = "DesignContext";
            this.DesignContext.RowGap = 0D;
            this.DesignContext.RowRepeats = 1;
            this.DesignContext.Scaling = 1F;
            this.DesignContext.Size = new System.Drawing.Size(944, 301);
            this.DesignContext.TabIndex = 1;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 359);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripButton PrintView;
        private System.Windows.Forms.ToolStripButton Print;
        private System.Windows.Forms.ToolStripButton NewBill;
        private System.Windows.Forms.ToolStripButton SerchBill;
        private System.Windows.Forms.ToolStripButton OpenDataSource;
        private System.Windows.Forms.ToolStripButton SaveToDataSource;
        private System.Windows.Forms.ToolStripButton Exit;
        public MyExtendControls.MyControls.RulePanel.Document DesignContext;
    }
}