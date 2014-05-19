namespace BillManageWPF.winFormUI.BillForms
{
    partial class FilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbLie1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cbbVaule1 = new System.Windows.Forms.ComboBox();
            this.cbbVaule2 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.cbbLie2 = new System.Windows.Forms.ComboBox();
            this.cbbVaule3 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.cbbLie3 = new System.Windows.Forms.ComboBox();
            this.cbbVaule4 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.cbbLie4 = new System.Windows.Forms.ComboBox();
            this.cbbVaule5 = new System.Windows.Forms.ComboBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.cbbLie5 = new System.Windows.Forms.ComboBox();
            this.cbbVaule6 = new System.Windows.Forms.ComboBox();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.cbbLie6 = new System.Windows.Forms.ComboBox();
            this.comboBox19 = new System.Windows.Forms.ComboBox();
            this.comboBox20 = new System.Windows.Forms.ComboBox();
            this.comboBox21 = new System.Windows.Forms.ComboBox();
            this.comboBox22 = new System.Windows.Forms.ComboBox();
            this.comboBox23 = new System.Windows.Forms.ComboBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox23);
            this.groupBox1.Controls.Add(this.comboBox22);
            this.groupBox1.Controls.Add(this.comboBox21);
            this.groupBox1.Controls.Add(this.comboBox20);
            this.groupBox1.Controls.Add(this.comboBox19);
            this.groupBox1.Controls.Add(this.cbbVaule6);
            this.groupBox1.Controls.Add(this.comboBox17);
            this.groupBox1.Controls.Add(this.cbbLie6);
            this.groupBox1.Controls.Add(this.cbbVaule5);
            this.groupBox1.Controls.Add(this.comboBox14);
            this.groupBox1.Controls.Add(this.cbbLie5);
            this.groupBox1.Controls.Add(this.cbbVaule4);
            this.groupBox1.Controls.Add(this.comboBox11);
            this.groupBox1.Controls.Add(this.cbbLie4);
            this.groupBox1.Controls.Add(this.cbbVaule3);
            this.groupBox1.Controls.Add(this.comboBox8);
            this.groupBox1.Controls.Add(this.cbbLie3);
            this.groupBox1.Controls.Add(this.cbbVaule2);
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.cbbLie2);
            this.groupBox1.Controls.Add(this.cbbVaule1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.cbbLie1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤方案";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "内容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "比较关系：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "值：";
            // 
            // cbbLie1
            // 
            this.cbbLie1.FormattingEnabled = true;
            this.cbbLie1.Location = new System.Drawing.Point(80, 55);
            this.cbbLie1.Name = "cbbLie1";
            this.cbbLie1.Size = new System.Drawing.Size(137, 20);
            this.cbbLie1.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox2.Location = new System.Drawing.Point(229, 55);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(61, 20);
            this.comboBox2.TabIndex = 4;
            // 
            // cbbVaule1
            // 
            this.cbbVaule1.Enabled = false;
            this.cbbVaule1.FormattingEnabled = true;
            this.cbbVaule1.Location = new System.Drawing.Point(302, 55);
            this.cbbVaule1.Name = "cbbVaule1";
            this.cbbVaule1.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule1.TabIndex = 5;
            // 
            // cbbVaule2
            // 
            this.cbbVaule2.Enabled = false;
            this.cbbVaule2.FormattingEnabled = true;
            this.cbbVaule2.Location = new System.Drawing.Point(302, 81);
            this.cbbVaule2.Name = "cbbVaule2";
            this.cbbVaule2.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule2.TabIndex = 8;
            // 
            // comboBox5
            // 
            this.comboBox5.Enabled = false;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox5.Location = new System.Drawing.Point(229, 81);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(61, 20);
            this.comboBox5.TabIndex = 7;
            // 
            // cbbLie2
            // 
            this.cbbLie2.Enabled = false;
            this.cbbLie2.FormattingEnabled = true;
            this.cbbLie2.Location = new System.Drawing.Point(80, 81);
            this.cbbLie2.Name = "cbbLie2";
            this.cbbLie2.Size = new System.Drawing.Size(137, 20);
            this.cbbLie2.TabIndex = 6;
            // 
            // cbbVaule3
            // 
            this.cbbVaule3.Enabled = false;
            this.cbbVaule3.FormattingEnabled = true;
            this.cbbVaule3.Location = new System.Drawing.Point(302, 107);
            this.cbbVaule3.Name = "cbbVaule3";
            this.cbbVaule3.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule3.TabIndex = 11;
            // 
            // comboBox8
            // 
            this.comboBox8.Enabled = false;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox8.Location = new System.Drawing.Point(229, 107);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(61, 20);
            this.comboBox8.TabIndex = 10;
            // 
            // cbbLie3
            // 
            this.cbbLie3.Enabled = false;
            this.cbbLie3.FormattingEnabled = true;
            this.cbbLie3.Location = new System.Drawing.Point(80, 107);
            this.cbbLie3.Name = "cbbLie3";
            this.cbbLie3.Size = new System.Drawing.Size(137, 20);
            this.cbbLie3.TabIndex = 9;
            // 
            // cbbVaule4
            // 
            this.cbbVaule4.Enabled = false;
            this.cbbVaule4.FormattingEnabled = true;
            this.cbbVaule4.Location = new System.Drawing.Point(302, 133);
            this.cbbVaule4.Name = "cbbVaule4";
            this.cbbVaule4.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule4.TabIndex = 14;
            // 
            // comboBox11
            // 
            this.comboBox11.Enabled = false;
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox11.Location = new System.Drawing.Point(229, 133);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(61, 20);
            this.comboBox11.TabIndex = 13;
            // 
            // cbbLie4
            // 
            this.cbbLie4.Enabled = false;
            this.cbbLie4.FormattingEnabled = true;
            this.cbbLie4.Location = new System.Drawing.Point(80, 133);
            this.cbbLie4.Name = "cbbLie4";
            this.cbbLie4.Size = new System.Drawing.Size(137, 20);
            this.cbbLie4.TabIndex = 12;
            // 
            // cbbVaule5
            // 
            this.cbbVaule5.Enabled = false;
            this.cbbVaule5.FormattingEnabled = true;
            this.cbbVaule5.Location = new System.Drawing.Point(302, 159);
            this.cbbVaule5.Name = "cbbVaule5";
            this.cbbVaule5.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule5.TabIndex = 17;
            // 
            // comboBox14
            // 
            this.comboBox14.Enabled = false;
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox14.Location = new System.Drawing.Point(229, 159);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(61, 20);
            this.comboBox14.TabIndex = 16;
            // 
            // cbbLie5
            // 
            this.cbbLie5.Enabled = false;
            this.cbbLie5.FormattingEnabled = true;
            this.cbbLie5.Location = new System.Drawing.Point(80, 159);
            this.cbbLie5.Name = "cbbLie5";
            this.cbbLie5.Size = new System.Drawing.Size(137, 20);
            this.cbbLie5.TabIndex = 15;
            // 
            // cbbVaule6
            // 
            this.cbbVaule6.Enabled = false;
            this.cbbVaule6.FormattingEnabled = true;
            this.cbbVaule6.Location = new System.Drawing.Point(302, 185);
            this.cbbVaule6.Name = "cbbVaule6";
            this.cbbVaule6.Size = new System.Drawing.Size(213, 20);
            this.cbbVaule6.TabIndex = 20;
            // 
            // comboBox17
            // 
            this.comboBox17.Enabled = false;
            this.comboBox17.FormattingEnabled = true;
            this.comboBox17.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "不等于",
            "包含"});
            this.comboBox17.Location = new System.Drawing.Point(229, 185);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(61, 20);
            this.comboBox17.TabIndex = 19;
            // 
            // cbbLie6
            // 
            this.cbbLie6.Enabled = false;
            this.cbbLie6.FormattingEnabled = true;
            this.cbbLie6.Location = new System.Drawing.Point(80, 185);
            this.cbbLie6.Name = "cbbLie6";
            this.cbbLie6.Size = new System.Drawing.Size(137, 20);
            this.cbbLie6.TabIndex = 18;
            // 
            // comboBox19
            // 
            this.comboBox19.Enabled = false;
            this.comboBox19.FormattingEnabled = true;
            this.comboBox19.Items.AddRange(new object[] {
            "或",
            "且"});
            this.comboBox19.Location = new System.Drawing.Point(6, 81);
            this.comboBox19.Name = "comboBox19";
            this.comboBox19.Size = new System.Drawing.Size(61, 20);
            this.comboBox19.TabIndex = 21;
            // 
            // comboBox20
            // 
            this.comboBox20.Enabled = false;
            this.comboBox20.FormattingEnabled = true;
            this.comboBox20.Items.AddRange(new object[] {
            "或",
            "且"});
            this.comboBox20.Location = new System.Drawing.Point(6, 107);
            this.comboBox20.Name = "comboBox20";
            this.comboBox20.Size = new System.Drawing.Size(61, 20);
            this.comboBox20.TabIndex = 22;
            // 
            // comboBox21
            // 
            this.comboBox21.Enabled = false;
            this.comboBox21.FormattingEnabled = true;
            this.comboBox21.Items.AddRange(new object[] {
            "或",
            "且"});
            this.comboBox21.Location = new System.Drawing.Point(8, 133);
            this.comboBox21.Name = "comboBox21";
            this.comboBox21.Size = new System.Drawing.Size(61, 20);
            this.comboBox21.TabIndex = 23;
            // 
            // comboBox22
            // 
            this.comboBox22.Enabled = false;
            this.comboBox22.FormattingEnabled = true;
            this.comboBox22.Items.AddRange(new object[] {
            "或",
            "且"});
            this.comboBox22.Location = new System.Drawing.Point(8, 159);
            this.comboBox22.Name = "comboBox22";
            this.comboBox22.Size = new System.Drawing.Size(61, 20);
            this.comboBox22.TabIndex = 24;
            // 
            // comboBox23
            // 
            this.comboBox23.Enabled = false;
            this.comboBox23.FormattingEnabled = true;
            this.comboBox23.Items.AddRange(new object[] {
            "或",
            "且"});
            this.comboBox23.Location = new System.Drawing.Point(8, 185);
            this.comboBox23.Name = "comboBox23";
            this.comboBox23.Size = new System.Drawing.Size(61, 20);
            this.comboBox23.TabIndex = 25;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(241, 245);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "全部清除";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(452, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 280);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.groupBox1);
            this.Name = "FilterForm";
            this.Text = "过滤方案";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox23;
        private System.Windows.Forms.ComboBox comboBox22;
        private System.Windows.Forms.ComboBox comboBox21;
        private System.Windows.Forms.ComboBox comboBox20;
        private System.Windows.Forms.ComboBox comboBox19;
        private System.Windows.Forms.ComboBox cbbVaule6;
        private System.Windows.Forms.ComboBox comboBox17;
        private System.Windows.Forms.ComboBox cbbLie6;
        private System.Windows.Forms.ComboBox cbbVaule5;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox cbbLie5;
        private System.Windows.Forms.ComboBox cbbVaule4;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.ComboBox cbbLie4;
        private System.Windows.Forms.ComboBox cbbVaule3;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox cbbLie3;
        private System.Windows.Forms.ComboBox cbbVaule2;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox cbbLie2;
        private System.Windows.Forms.ComboBox cbbVaule1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cbbLie1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}