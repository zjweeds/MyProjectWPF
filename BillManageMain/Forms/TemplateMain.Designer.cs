namespace BillManageMain.Forms
{
    partial class TemplateMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PropertyPanel = new System.Windows.Forms.Panel();
            this.cbbControls = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(897, 377);
            this.splitContainer1.SplitterDistance = 704;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.PropertyPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbControls, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.95756F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.04244F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(189, 377);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PropertyPanel
            // 
            this.PropertyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyPanel.Location = new System.Drawing.Point(3, 32);
            this.PropertyPanel.Name = "PropertyPanel";
            this.PropertyPanel.Size = new System.Drawing.Size(183, 342);
            this.PropertyPanel.TabIndex = 0;
            // 
            // cbbControls
            // 
            this.cbbControls.FormattingEnabled = true;
            this.cbbControls.Location = new System.Drawing.Point(3, 3);
            this.cbbControls.Name = "cbbControls";
            this.cbbControls.Size = new System.Drawing.Size(183, 20);
            this.cbbControls.TabIndex = 1;
            this.cbbControls.SelectedIndexChanged += new System.EventHandler(this.cbbControls_SelectedIndexChanged);
            // 
            // TemplateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 377);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TemplateMain";
            this.Text = "模板设计";
            this.Load += new System.EventHandler(this.Template_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox cbbControls;
        public System.Windows.Forms.Panel PropertyPanel;


    }
}