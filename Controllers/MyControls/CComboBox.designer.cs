namespace Controllers.MyControls
{
    partial class CComboBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuOperate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolDeleteCComboBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSetProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuOperate
            // 
            this.contextMenuOperate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDeleteCComboBox,
            this.toolStripSeparator1,
            this.toolSetProperty});
            this.contextMenuOperate.Name = "contextMenuStrip1";
            this.contextMenuOperate.Size = new System.Drawing.Size(137, 54);
            // 
            // toolDeleteCComboBox
            // 
            this.toolDeleteCComboBox.Name = "toolDeleteCComboBox";
            this.toolDeleteCComboBox.Size = new System.Drawing.Size(136, 22);
            this.toolDeleteCComboBox.Text = "删除输入框";
            this.toolDeleteCComboBox.Click += new System.EventHandler(this.toolDeleteCComboBox_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolSetProperty
            // 
            this.toolSetProperty.Name = "toolSetProperty";
            this.toolSetProperty.Size = new System.Drawing.Size(136, 22);
            this.toolSetProperty.Text = "设置属性";
            this.toolSetProperty.Click += new System.EventHandler(this.toolSetProperty_Click);
            // 
            // CComboBox
            // 
            this.ContextMenuStrip = this.contextMenuOperate;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CComboBox_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CComboBox_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CComboBox_MouseDown);
            this.contextMenuOperate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuOperate;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteCComboBox;
        private System.Windows.Forms.ToolStripMenuItem toolSetProperty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
