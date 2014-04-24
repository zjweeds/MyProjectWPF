namespace BillManageMain.Forms
{
    partial class FormSetTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetTemplate));
            this.contextMenuSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.文本框 = new System.Windows.Forms.ToolStripButton();
            this.日历 = new System.Windows.Forms.ToolStripButton();
            this.下拉框 = new System.Windows.Forms.ToolStripButton();
            this.多选框 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.金额明细 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuSetting.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuSetting
            // 
            this.contextMenuSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolStripMenuItem2,
            this.toolExit});
            this.contextMenuSetting.Name = "contextMenuStrip1";
            this.contextMenuSetting.Size = new System.Drawing.Size(125, 54);
            this.contextMenuSetting.Text = "添加输入文本框";
            // 
            // toolSave
            // 
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(124, 22);
            this.toolSave.Text = "保存模板";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(124, 22);
            this.toolExit.Text = "退出窗口";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文本框,
            this.日历,
            this.下拉框,
            this.多选框,
            this.金额明细});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(908, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 文本框
            // 
            this.文本框.Image = ((System.Drawing.Image)(resources.GetObject("文本框.Image")));
            this.文本框.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.文本框.Name = "文本框";
            this.文本框.Size = new System.Drawing.Size(64, 22);
            this.文本框.Text = "文本框";
            this.文本框.Click += new System.EventHandler(this.文本框_Click);
            this.文本框.MouseHover += new System.EventHandler(this.文本框_MouseHover);
            // 
            // 日历
            // 
            this.日历.Image = ((System.Drawing.Image)(resources.GetObject("日历.Image")));
            this.日历.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.日历.Name = "日历";
            this.日历.Size = new System.Drawing.Size(52, 22);
            this.日历.Text = "日历";
            this.日历.Click += new System.EventHandler(this.日历_Click);
            // 
            // 下拉框
            // 
            this.下拉框.Image = ((System.Drawing.Image)(resources.GetObject("下拉框.Image")));
            this.下拉框.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.下拉框.Name = "下拉框";
            this.下拉框.Size = new System.Drawing.Size(64, 22);
            this.下拉框.Text = "下拉框";
            this.下拉框.Click += new System.EventHandler(this.下拉框_Click);
            // 
            // 多选框
            // 
            this.多选框.Image = ((System.Drawing.Image)(resources.GetObject("多选框.Image")));
            this.多选框.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.多选框.Name = "多选框";
            this.多选框.Size = new System.Drawing.Size(64, 22);
            this.多选框.Text = "多选框";
            this.多选框.Click += new System.EventHandler(this.多选框_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // 金额明细
            // 
            this.金额明细.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.金额明细.Image = ((System.Drawing.Image)(resources.GetObject("金额明细.Image")));
            this.金额明细.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.金额明细.Name = "金额明细";
            this.金额明细.Size = new System.Drawing.Size(60, 22);
            this.金额明细.Text = "金额明细";
            this.金额明细.Click += new System.EventHandler(this.金额明细_Click);
            // 
            // FormSetTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(908, 516);
            this.ContextMenuStrip = this.contextMenuSetting;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetTemplate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "设计模板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetTemplate_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSetTemplate_FormClosed);
            this.Load += new System.EventHandler(this.FormSetTemplate_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSetTemplate_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormSetTemplate_MouseMove);
            this.contextMenuSetting.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 文本框;
        private System.Windows.Forms.ToolStripButton 日历;
        private System.Windows.Forms.ToolStripButton 下拉框;
        private System.Windows.Forms.ToolStripButton 多选框;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton 金额明细;
    }
}