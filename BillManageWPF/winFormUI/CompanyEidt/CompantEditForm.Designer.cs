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
            this.label1 = new System.Windows.Forms.Label();
            this.listPost = new System.Windows.Forms.ListBox();
            this.ListDpm = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbEMCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvBillset = new System.Windows.Forms.ListView();
            this.lbChildCount = new System.Windows.Forms.Label();
            this.txtDesription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolDadd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDeleteD = new System.Windows.Forms.ToolStripMenuItem();
            this.contextP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tooladdP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextD.SuspendLayout();
            this.contextP.SuspendLayout();
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
            this.splitContainer2.SplitterDistance = 236;
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
            this.groupBox2.Size = new System.Drawing.Size(236, 436);
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
            this.tvCompanyInfo.Size = new System.Drawing.Size(230, 411);
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
            this.txtCompanyName.Controls.Add(this.label1);
            this.txtCompanyName.Controls.Add(this.listPost);
            this.txtCompanyName.Controls.Add(this.ListDpm);
            this.txtCompanyName.Controls.Add(this.label5);
            this.txtCompanyName.Controls.Add(this.lbEMCount);
            this.txtCompanyName.Controls.Add(this.label7);
            this.txtCompanyName.Controls.Add(this.lsvBillset);
            this.txtCompanyName.Controls.Add(this.lbChildCount);
            this.txtCompanyName.Controls.Add(this.txtDesription);
            this.txtCompanyName.Controls.Add(this.label4);
            this.txtCompanyName.Controls.Add(this.label3);
            this.txtCompanyName.Controls.Add(this.label2);
            this.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompanyName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyName.ForeColor = System.Drawing.Color.Black;
            this.txtCompanyName.Location = new System.Drawing.Point(0, 0);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(356, 436);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.TabStop = false;
            this.txtCompanyName.Text = "公司信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "职位一览：";
            // 
            // listPost
            // 
            this.listPost.ContextMenuStrip = this.contextP;
            this.listPost.FormattingEnabled = true;
            this.listPost.ItemHeight = 16;
            this.listPost.Location = new System.Drawing.Point(217, 238);
            this.listPost.Name = "listPost";
            this.listPost.Size = new System.Drawing.Size(120, 180);
            this.listPost.TabIndex = 13;
            // 
            // ListDpm
            // 
            this.ListDpm.ContextMenuStrip = this.contextD;
            this.ListDpm.FormattingEnabled = true;
            this.ListDpm.ItemHeight = 16;
            this.ListDpm.Location = new System.Drawing.Point(17, 238);
            this.ListDpm.Name = "ListDpm";
            this.ListDpm.Size = new System.Drawing.Size(120, 180);
            this.ListDpm.TabIndex = 12;
            this.ListDpm.Click += new System.EventHandler(this.ListDpm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "部门一览：";
            // 
            // lbEMCount
            // 
            this.lbEMCount.AutoSize = true;
            this.lbEMCount.Location = new System.Drawing.Point(281, 33);
            this.lbEMCount.Name = "lbEMCount";
            this.lbEMCount.Size = new System.Drawing.Size(56, 16);
            this.lbEMCount.TabIndex = 10;
            this.lbEMCount.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "员工个数：";
            // 
            // lsvBillset
            // 
            this.lsvBillset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvBillset.Location = new System.Drawing.Point(106, 106);
            this.lsvBillset.Name = "lsvBillset";
            this.lsvBillset.Size = new System.Drawing.Size(231, 87);
            this.lsvBillset.TabIndex = 8;
            this.lsvBillset.UseCompatibleStateImageBehavior = false;
            // 
            // lbChildCount
            // 
            this.lbChildCount.AutoSize = true;
            this.lbChildCount.Location = new System.Drawing.Point(103, 33);
            this.lbChildCount.Name = "lbChildCount";
            this.lbChildCount.Size = new System.Drawing.Size(56, 16);
            this.lbChildCount.TabIndex = 7;
            this.lbChildCount.Text = "label5";
            // 
            // txtDesription
            // 
            this.txtDesription.Location = new System.Drawing.Point(106, 63);
            this.txtDesription.Multiline = true;
            this.txtDesription.Name = "txtDesription";
            this.txtDesription.Size = new System.Drawing.Size(231, 37);
            this.txtDesription.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "拥有账套:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "公司描述：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "子公司个数：";
            // 
            // contextD
            // 
            this.contextD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDadd,
            this.toolDModify,
            this.toolDeleteD});
            this.contextD.Name = "contextD";
            this.contextD.Size = new System.Drawing.Size(123, 70);
            // 
            // toolDadd
            // 
            this.toolDadd.Name = "toolDadd";
            this.toolDadd.Size = new System.Drawing.Size(122, 22);
            this.toolDadd.Text = "添加部门";
            this.toolDadd.Click += new System.EventHandler(this.toolDadd_Click);
            // 
            // toolDModify
            // 
            this.toolDModify.Name = "toolDModify";
            this.toolDModify.Size = new System.Drawing.Size(122, 22);
            this.toolDModify.Text = "修改部门";
            this.toolDModify.Click += new System.EventHandler(this.toolDModify_Click);
            // 
            // toolDeleteD
            // 
            this.toolDeleteD.Name = "toolDeleteD";
            this.toolDeleteD.Size = new System.Drawing.Size(122, 22);
            this.toolDeleteD.Text = "删除部门";
            this.toolDeleteD.Click += new System.EventHandler(this.toolDeleteD_Click);
            // 
            // contextP
            // 
            this.contextP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooladdP,
            this.toolModify,
            this.toolDelete});
            this.contextP.Name = "contextD";
            this.contextP.Size = new System.Drawing.Size(123, 70);
            // 
            // tooladdP
            // 
            this.tooladdP.Name = "tooladdP";
            this.tooladdP.Size = new System.Drawing.Size(152, 22);
            this.tooladdP.Text = "添加职位";
            this.tooladdP.Click += new System.EventHandler(this.tooladdP_Click);
            // 
            // toolModify
            // 
            this.toolModify.Name = "toolModify";
            this.toolModify.Size = new System.Drawing.Size(152, 22);
            this.toolModify.Text = "修改职位";
            this.toolModify.Click += new System.EventHandler(this.toolModify_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(152, 22);
            this.toolDelete.Text = "删除职位";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
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
            this.contextD.ResumeLayout(false);
            this.contextP.ResumeLayout(false);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbEMCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lsvBillset;
        private System.Windows.Forms.Label lbChildCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加子公司ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listPost;
        private System.Windows.Forms.ListBox ListDpm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextD;
        private System.Windows.Forms.ToolStripMenuItem toolDadd;
        private System.Windows.Forms.ToolStripMenuItem toolDModify;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteD;
        private System.Windows.Forms.ContextMenuStrip contextP;
        private System.Windows.Forms.ToolStripMenuItem tooladdP;
        private System.Windows.Forms.ToolStripMenuItem toolModify;
        private System.Windows.Forms.ToolStripMenuItem toolDelete;
    }
}