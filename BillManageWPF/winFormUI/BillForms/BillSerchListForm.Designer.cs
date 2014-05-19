namespace BillManageWPF.winFormUI.BillForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillSerchListForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrInt32 = new System.Windows.Forms.ToolStripButton();
            this.toolPrInt32View = new System.Windows.Forms.ToolStripButton();
            this.toolPrInt32More = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLeading = new System.Windows.Forms.ToolStripButton();
            this.toolExport = new System.Windows.Forms.ToolStripButton();
            this.toolline = new System.Windows.Forms.ToolStripSeparator();
            this.toolSerch = new System.Windows.Forms.ToolStripButton();
            this.toolOrder = new System.Windows.Forms.ToolStripButton();
            this.toolCoumlnsPropery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.dgBillInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillInfo)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.dgBillInfo);
            this.splitContainer1.Size = new System.Drawing.Size(884, 461);
            this.splitContainer1.SplitterDistance = 44;
            this.splitContainer1.TabIndex = 0;
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
            this.toolPrInt32,
            this.toolPrInt32View,
            this.toolPrInt32More,
            this.toolStripSeparator2,
            this.toolLeading,
            this.toolExport,
            this.toolline,
            this.toolSerch,
            this.toolOrder,
            this.toolCoumlnsPropery,
            this.toolStripSeparator3,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 44);
            this.toolStrip1.TabIndex = 1;
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
            this.toolSave.Size = new System.Drawing.Size(49, 41);
            this.toolSave.Text = "保  存";
            this.toolSave.ToolTipText = "点击保存";
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
            this.toolCancel.Size = new System.Drawing.Size(49, 41);
            this.toolCancel.Text = "取  消";
            this.toolCancel.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolCancel.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // toolPrInt32
            // 
            this.toolPrInt32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrInt32.ForeColor = System.Drawing.Color.White;
            this.toolPrInt32.Image = ((System.Drawing.Image)(resources.GetObject("toolPrInt32.Image")));
            this.toolPrInt32.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrInt32.Name = "toolPrInt32";
            this.toolPrInt32.Size = new System.Drawing.Size(49, 41);
            this.toolPrInt32.Text = "打  印";
            this.toolPrInt32.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolPrInt32.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolPrInt32View
            // 
            this.toolPrInt32View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrInt32View.ForeColor = System.Drawing.Color.White;
            this.toolPrInt32View.Image = ((System.Drawing.Image)(resources.GetObject("toolPrInt32View.Image")));
            this.toolPrInt32View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrInt32View.Name = "toolPrInt32View";
            this.toolPrInt32View.Size = new System.Drawing.Size(49, 41);
            this.toolPrInt32View.Text = "预  览";
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
            this.toolPrInt32More.Size = new System.Drawing.Size(69, 41);
            this.toolPrInt32More.Text = "批量套打";
            this.toolPrInt32More.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolPrInt32More.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // toolLeading
            // 
            this.toolLeading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLeading.ForeColor = System.Drawing.Color.White;
            this.toolLeading.Image = ((System.Drawing.Image)(resources.GetObject("toolLeading.Image")));
            this.toolLeading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLeading.Name = "toolLeading";
            this.toolLeading.Size = new System.Drawing.Size(49, 41);
            this.toolLeading.Text = "导  入";
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
            this.toolExport.Size = new System.Drawing.Size(49, 41);
            this.toolExport.Text = "导  出";
            this.toolExport.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolExport.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolline
            // 
            this.toolline.Name = "toolline";
            this.toolline.Size = new System.Drawing.Size(6, 44);
            // 
            // toolSerch
            // 
            this.toolSerch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSerch.ForeColor = System.Drawing.Color.White;
            this.toolSerch.Image = ((System.Drawing.Image)(resources.GetObject("toolSerch.Image")));
            this.toolSerch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSerch.Name = "toolSerch";
            this.toolSerch.Size = new System.Drawing.Size(49, 41);
            this.toolSerch.Text = "过  滤";
            this.toolSerch.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolSerch.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolOrder
            // 
            this.toolOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolOrder.ForeColor = System.Drawing.Color.White;
            this.toolOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolOrder.Image")));
            this.toolOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOrder.Name = "toolOrder";
            this.toolOrder.Size = new System.Drawing.Size(49, 41);
            this.toolOrder.Text = "排  序";
            this.toolOrder.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolOrder.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolCoumlnsPropery
            // 
            this.toolCoumlnsPropery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCoumlnsPropery.ForeColor = System.Drawing.Color.White;
            this.toolCoumlnsPropery.Image = ((System.Drawing.Image)(resources.GetObject("toolCoumlnsPropery.Image")));
            this.toolCoumlnsPropery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCoumlnsPropery.Name = "toolCoumlnsPropery";
            this.toolCoumlnsPropery.Size = new System.Drawing.Size(55, 41);
            this.toolCoumlnsPropery.Text = "列属性";
            this.toolCoumlnsPropery.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolCoumlnsPropery.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 44);
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
            this.toolExit.Size = new System.Drawing.Size(61, 41);
            this.toolExit.Text = " 退  出  ";
            this.toolExit.ToolTipText = "点击退出";
            this.toolExit.MouseEnter += new System.EventHandler(this.toolSave_MouseEnter);
            this.toolExit.MouseLeave += new System.EventHandler(this.toolSave_MouseLeave);
            // 
            // dgBillInfo
            // 
            this.dgBillInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgBillInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBillInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBillInfo.Location = new System.Drawing.Point(0, 0);
            this.dgBillInfo.Name = "dgBillInfo";
            this.dgBillInfo.RowTemplate.Height = 23;
            this.dgBillInfo.Size = new System.Drawing.Size(884, 413);
            this.dgBillInfo.TabIndex = 0;
            // 
            // BillSerchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BillSerchListForm";
            this.Text = "票据查询";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgBillInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPrInt32;
        private System.Windows.Forms.ToolStripButton toolPrInt32View;
        private System.Windows.Forms.ToolStripButton toolPrInt32More;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolLeading;
        private System.Windows.Forms.ToolStripButton toolExport;
        private System.Windows.Forms.ToolStripSeparator toolline;
        private System.Windows.Forms.ToolStripButton toolSerch;
        private System.Windows.Forms.ToolStripButton toolOrder;
        private System.Windows.Forms.ToolStripButton toolCoumlnsPropery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolExit;
    }
}