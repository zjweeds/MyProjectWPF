namespace BillManageWPF.winFormUI.CompanyEidt
{
    partial class CompantEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompantEditForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvCompanyInfo = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加子公司ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCompanyName = new System.Windows.Forms.GroupBox();
            this.lbEMCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvBillset = new System.Windows.Forms.ListView();
            this.lbChildCount = new System.Windows.Forms.Label();
            this.txtDesription = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.txtCompanyName.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(596, 477);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(596, 37);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnExit
            // 
            this.toolbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtnExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnExit.ForeColor = System.Drawing.Color.White;
            this.toolbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExit.Image")));
            this.toolbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExit.Name = "toolbtnExit";
            this.toolbtnExit.Size = new System.Drawing.Size(41, 34);
            this.toolbtnExit.Text = "退出";
            this.toolbtnExit.Click += new System.EventHandler(this.toolbtnExit_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtCompanyName);
            this.splitContainer2.Size = new System.Drawing.Size(596, 436);
            this.splitContainer2.SplitterDistance = 270;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.tvCompanyInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 436);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "公司列表";
            // 
            // tvCompanyInfo
            // 
            this.tvCompanyInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.tvCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCompanyInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tvCompanyInfo.Location = new System.Drawing.Point(3, 22);
            this.tvCompanyInfo.Name = "tvCompanyInfo";
            this.tvCompanyInfo.Size = new System.Drawing.Size(264, 411);
            this.tvCompanyInfo.TabIndex = 1;
            this.tvCompanyInfo.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCompanyInfo_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加子公司ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // 添加子公司ToolStripMenuItem
            // 
            this.添加子公司ToolStripMenuItem.Name = "添加子公司ToolStripMenuItem";
            this.添加子公司ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.添加子公司ToolStripMenuItem.Text = "添加子公司";
            this.添加子公司ToolStripMenuItem.Click += new System.EventHandler(this.添加子公司ToolStripMenuItem_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCompanyName.Controls.Add(this.lbEMCount);
            this.txtCompanyName.Controls.Add(this.label7);
            this.txtCompanyName.Controls.Add(this.lsvBillset);
            this.txtCompanyName.Controls.Add(this.lbChildCount);
            this.txtCompanyName.Controls.Add(this.txtDesription);
            this.txtCompanyName.Controls.Add(this.textBox1);
            this.txtCompanyName.Controls.Add(this.label4);
            this.txtCompanyName.Controls.Add(this.label3);
            this.txtCompanyName.Controls.Add(this.label2);
            this.txtCompanyName.Controls.Add(this.label1);
            this.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompanyName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyName.ForeColor = System.Drawing.Color.Black;
            this.txtCompanyName.Location = new System.Drawing.Point(0, 0);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(322, 436);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.TabStop = false;
            this.txtCompanyName.Text = "公司信息";
            // 
            // lbEMCount
            // 
            this.lbEMCount.AutoSize = true;
            this.lbEMCount.Location = new System.Drawing.Point(128, 126);
            this.lbEMCount.Name = "lbEMCount";
            this.lbEMCount.Size = new System.Drawing.Size(56, 16);
            this.lbEMCount.TabIndex = 10;
            this.lbEMCount.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "员工个数：";
            // 
            // lsvBillset
            // 
            this.lsvBillset.Location = new System.Drawing.Point(128, 262);
            this.lsvBillset.Name = "lsvBillset";
            this.lsvBillset.Size = new System.Drawing.Size(182, 162);
            this.lsvBillset.TabIndex = 8;
            this.lsvBillset.UseCompatibleStateImageBehavior = false;
            // 
            // lbChildCount
            // 
            this.lbChildCount.AutoSize = true;
            this.lbChildCount.Location = new System.Drawing.Point(128, 81);
            this.lbChildCount.Name = "lbChildCount";
            this.lbChildCount.Size = new System.Drawing.Size(56, 16);
            this.lbChildCount.TabIndex = 7;
            this.lbChildCount.Text = "label5";
            // 
            // txtDesription
            // 
            this.txtDesription.Location = new System.Drawing.Point(128, 160);
            this.txtDesription.Multiline = true;
            this.txtDesription.Name = "txtDesription";
            this.txtDesription.Size = new System.Drawing.Size(179, 74);
            this.txtDesription.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 26);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "拥有账套:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "公司描述：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "子公司个数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司名称：";
            // 
            // CompantEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(596, 477);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CompantEditForm";
            this.Text = "公司管理";
            this.Load += new System.EventHandler(this.CompantEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.txtCompanyName.ResumeLayout(false);
            this.txtCompanyName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox txtCompanyName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tvCompanyInfo;
        private System.Windows.Forms.ToolStripButton toolbtnExit;
        private System.Windows.Forms.TextBox txtDesription;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbEMCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lsvBillset;
        private System.Windows.Forms.Label lbChildCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加子公司ToolStripMenuItem;
    }
}