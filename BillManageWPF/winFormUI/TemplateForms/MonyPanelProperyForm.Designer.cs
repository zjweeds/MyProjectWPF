namespace BillManageWPF.Forms
{
    partial class MonyPanelProperyForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbbLow = new System.Windows.Forms.ComboBox();
            this.cbbHeight = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txttab = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDefalutValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtheight = new System.Windows.Forms.TextBox();
            this.txtwidth = new System.Windows.Forms.TextBox();
            this.txtleft = new System.Windows.Forms.TextBox();
            this.txttop = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbBandings = new System.Windows.Forms.ComboBox();
            this.chbIsprInt = new System.Windows.Forms.CheckBox();
            this.chbIsvisible = new System.Windows.Forms.CheckBox();
            this.chbIsmust = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBackgroud = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnSetFont = new System.Windows.Forms.Button();
            this.txtBackColor = new System.Windows.Forms.TextBox();
            this.txtForeColor = new System.Windows.Forms.TextBox();
            this.txtfont = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cd = new System.Windows.Forms.ColorDialog();
            this.fd = new System.Windows.Forms.FontDialog();
            this.chbIsShowUnit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox4.Controls.Add(this.cbbLow);
            this.groupBox4.Controls.Add(this.cbbHeight);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txttab);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtName);
            this.groupBox4.Controls.Add(this.txtDefalutValue);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 160);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "显示";
            // 
            // cbbLow
            // 
            this.cbbLow.BackColor = System.Drawing.Color.MediumPurple;
            this.cbbLow.ForeColor = System.Drawing.Color.White;
            this.cbbLow.FormattingEnabled = true;
            this.cbbLow.Location = new System.Drawing.Point(82, 118);
            this.cbbLow.Name = "cbbLow";
            this.cbbLow.Size = new System.Drawing.Size(103, 25);
            this.cbbLow.TabIndex = 22;
            this.cbbLow.SelectedIndexChanged += new System.EventHandler(this.cbbHeight_SelectedIndexChanged);
            // 
            // cbbHeight
            // 
            this.cbbHeight.BackColor = System.Drawing.Color.MediumPurple;
            this.cbbHeight.ForeColor = System.Drawing.Color.White;
            this.cbbHeight.FormattingEnabled = true;
            this.cbbHeight.Location = new System.Drawing.Point(82, 90);
            this.cbbHeight.MaxDropDownItems = 14;
            this.cbbHeight.Name = "cbbHeight";
            this.cbbHeight.Size = new System.Drawing.Size(103, 25);
            this.cbbHeight.TabIndex = 21;
            this.cbbHeight.SelectedIndexChanged += new System.EventHandler(this.cbbHeight_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.PaleGreen;
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(26, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "最高位:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.PaleGreen;
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(26, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 17);
            this.label20.TabIndex = 10;
            this.label20.Text = "最低位:";
            // 
            // txttab
            // 
            this.txttab.BackColor = System.Drawing.Color.PaleGreen;
            this.txttab.ForeColor = System.Drawing.Color.DimGray;
            this.txttab.Location = new System.Drawing.Point(82, 61);
            this.txttab.Name = "txttab";
            this.txttab.Size = new System.Drawing.Size(103, 23);
            this.txttab.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.PaleGreen;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(28, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tab 键:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "名  称:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.PaleGreen;
            this.txtName.ForeColor = System.Drawing.Color.DimGray;
            this.txtName.Location = new System.Drawing.Point(82, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(103, 23);
            this.txtName.TabIndex = 0;
            // 
            // txtDefalutValue
            // 
            this.txtDefalutValue.BackColor = System.Drawing.Color.PaleGreen;
            this.txtDefalutValue.ForeColor = System.Drawing.Color.DimGray;
            this.txtDefalutValue.Location = new System.Drawing.Point(82, 39);
            this.txtDefalutValue.Name = "txtDefalutValue";
            this.txtDefalutValue.Size = new System.Drawing.Size(103, 23);
            this.txtDefalutValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGreen;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(28, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "默认值:";
            // 
            // txtheight
            // 
            this.txtheight.BackColor = System.Drawing.Color.MediumPurple;
            this.txtheight.ForeColor = System.Drawing.Color.White;
            this.txtheight.Location = new System.Drawing.Point(82, 94);
            this.txtheight.Name = "txtheight";
            this.txtheight.Size = new System.Drawing.Size(103, 23);
            this.txtheight.TabIndex = 19;
            // 
            // txtwidth
            // 
            this.txtwidth.BackColor = System.Drawing.Color.MediumPurple;
            this.txtwidth.ForeColor = System.Drawing.Color.White;
            this.txtwidth.Location = new System.Drawing.Point(82, 71);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(103, 23);
            this.txtwidth.TabIndex = 18;
            // 
            // txtleft
            // 
            this.txtleft.BackColor = System.Drawing.Color.MediumPurple;
            this.txtleft.ForeColor = System.Drawing.Color.White;
            this.txtleft.Location = new System.Drawing.Point(82, 44);
            this.txtleft.Name = "txtleft";
            this.txtleft.Size = new System.Drawing.Size(103, 23);
            this.txtleft.TabIndex = 17;
            // 
            // txttop
            // 
            this.txttop.BackColor = System.Drawing.Color.MediumPurple;
            this.txttop.ForeColor = System.Drawing.Color.White;
            this.txttop.Location = new System.Drawing.Point(82, 17);
            this.txttop.Name = "txttop";
            this.txttop.Size = new System.Drawing.Size(103, 23);
            this.txttop.TabIndex = 11;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox5.Controls.Add(this.chbIsShowUnit);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cbbBandings);
            this.groupBox5.Controls.Add(this.chbIsprInt);
            this.groupBox5.Controls.Add(this.chbIsvisible);
            this.groupBox5.Controls.Add(this.chbIsmust);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(3, 432);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(218, 98);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "其他";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkGray;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "绑定的控件:";
            // 
            // cbbBandings
            // 
            this.cbbBandings.BackColor = System.Drawing.Color.MediumPurple;
            this.cbbBandings.ForeColor = System.Drawing.Color.White;
            this.cbbBandings.FormattingEnabled = true;
            this.cbbBandings.Location = new System.Drawing.Point(90, 67);
            this.cbbBandings.Name = "cbbBandings";
            this.cbbBandings.Size = new System.Drawing.Size(103, 25);
            this.cbbBandings.TabIndex = 38;
            // 
            // chbIsprInt
            // 
            this.chbIsprInt.AutoSize = true;
            this.chbIsprInt.BackColor = System.Drawing.Color.DarkGray;
            this.chbIsprInt.ForeColor = System.Drawing.Color.White;
            this.chbIsprInt.Location = new System.Drawing.Point(151, 16);
            this.chbIsprInt.Name = "chbIsprInt";
            this.chbIsprInt.Size = new System.Drawing.Size(39, 21);
            this.chbIsprInt.TabIndex = 37;
            this.chbIsprInt.Text = "是";
            this.chbIsprInt.UseVisualStyleBackColor = false;
            // 
            // chbIsvisible
            // 
            this.chbIsvisible.AutoSize = true;
            this.chbIsvisible.BackColor = System.Drawing.Color.DarkGray;
            this.chbIsvisible.ForeColor = System.Drawing.Color.White;
            this.chbIsvisible.Location = new System.Drawing.Point(53, 18);
            this.chbIsvisible.Name = "chbIsvisible";
            this.chbIsvisible.Size = new System.Drawing.Size(39, 21);
            this.chbIsvisible.TabIndex = 36;
            this.chbIsvisible.Text = "是";
            this.chbIsvisible.UseVisualStyleBackColor = false;
            // 
            // chbIsmust
            // 
            this.chbIsmust.AutoSize = true;
            this.chbIsmust.BackColor = System.Drawing.Color.DarkGray;
            this.chbIsmust.ForeColor = System.Drawing.Color.White;
            this.chbIsmust.Location = new System.Drawing.Point(45, 45);
            this.chbIsmust.Name = "chbIsmust";
            this.chbIsmust.Size = new System.Drawing.Size(39, 21);
            this.chbIsmust.TabIndex = 35;
            this.chbIsmust.Text = "是";
            this.chbIsmust.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(110, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "打印:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkGray;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "必填:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkGray;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "可见:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chartreuse;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Location = new System.Drawing.Point(3, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "点击设定";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMark
            // 
            this.txtMark.BackColor = System.Drawing.Color.Pink;
            this.txtMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMark.ForeColor = System.Drawing.Color.White;
            this.txtMark.Location = new System.Drawing.Point(0, 0);
            this.txtMark.Multiline = true;
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(224, 42);
            this.txtMark.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 641);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Aquamarine;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer2.ForeColor = System.Drawing.Color.White;
            this.splitContainer2.Location = new System.Drawing.Point(3, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtMark);
            this.splitContainer2.Size = new System.Drawing.Size(224, 613);
            this.splitContainer2.SplitterDistance = 567;
            this.splitContainer2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 567);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 567);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Aquamarine;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.94406F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.05594F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(224, 567);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox2.Controls.Add(this.txtRows);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.btnBackgroud);
            this.groupBox2.Controls.Add(this.btnForeColor);
            this.groupBox2.Controls.Add(this.btnSetFont);
            this.groupBox2.Controls.Add(this.txtBackColor);
            this.groupBox2.Controls.Add(this.txtForeColor);
            this.groupBox2.Controls.Add(this.txtfont);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(3, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "外观";
            // 
            // btnBackgroud
            // 
            this.btnBackgroud.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnBackgroud.ForeColor = System.Drawing.Color.DimGray;
            this.btnBackgroud.Location = new System.Drawing.Point(151, 88);
            this.btnBackgroud.Name = "btnBackgroud";
            this.btnBackgroud.Size = new System.Drawing.Size(34, 23);
            this.btnBackgroud.TabIndex = 25;
            this.btnBackgroud.Text = "...";
            this.btnBackgroud.UseVisualStyleBackColor = false;
            this.btnBackgroud.Click += new System.EventHandler(this.btnBackgroud_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnForeColor.ForeColor = System.Drawing.Color.DimGray;
            this.btnForeColor.Location = new System.Drawing.Point(151, 64);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(34, 23);
            this.btnForeColor.TabIndex = 24;
            this.btnForeColor.Text = "...";
            this.btnForeColor.UseVisualStyleBackColor = false;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // btnSetFont
            // 
            this.btnSetFont.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnSetFont.ForeColor = System.Drawing.Color.DimGray;
            this.btnSetFont.Location = new System.Drawing.Point(151, 39);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new System.Drawing.Size(34, 23);
            this.btnSetFont.TabIndex = 23;
            this.btnSetFont.Text = "...";
            this.btnSetFont.UseVisualStyleBackColor = false;
            this.btnSetFont.Click += new System.EventHandler(this.btnSetFont_Click);
            // 
            // txtBackColor
            // 
            this.txtBackColor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtBackColor.ForeColor = System.Drawing.Color.DimGray;
            this.txtBackColor.Location = new System.Drawing.Point(81, 84);
            this.txtBackColor.Name = "txtBackColor";
            this.txtBackColor.Size = new System.Drawing.Size(64, 23);
            this.txtBackColor.TabIndex = 10;
            // 
            // txtForeColor
            // 
            this.txtForeColor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtForeColor.ForeColor = System.Drawing.Color.DimGray;
            this.txtForeColor.Location = new System.Drawing.Point(81, 62);
            this.txtForeColor.Name = "txtForeColor";
            this.txtForeColor.Size = new System.Drawing.Size(64, 23);
            this.txtForeColor.TabIndex = 9;
            // 
            // txtfont
            // 
            this.txtfont.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtfont.ForeColor = System.Drawing.Color.DimGray;
            this.txtfont.Location = new System.Drawing.Point(81, 41);
            this.txtfont.Name = "txtfont";
            this.txtfont.Size = new System.Drawing.Size(64, 23);
            this.txtfont.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(26, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "背景色:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(26, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "前景色:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(26, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "字  体:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.MediumPurple;
            this.groupBox3.Controls.Add(this.txtheight);
            this.groupBox3.Controls.Add(this.txtwidth);
            this.groupBox3.Controls.Add(this.txtleft);
            this.groupBox3.Controls.Add(this.txttop);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(3, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 126);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.MediumPurple;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(29, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "高  度:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.MediumPurple;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(29, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 17);
            this.label14.TabIndex = 9;
            this.label14.Text = "宽  度:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.MediumPurple;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(29, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "左边距:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.MediumPurple;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(29, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "上边距:";
            // 
            // chbIsShowUnit
            // 
            this.chbIsShowUnit.AutoSize = true;
            this.chbIsShowUnit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.chbIsShowUnit.ForeColor = System.Drawing.Color.DimGray;
            this.chbIsShowUnit.Location = new System.Drawing.Point(151, 44);
            this.chbIsShowUnit.Name = "chbIsShowUnit";
            this.chbIsShowUnit.Size = new System.Drawing.Size(39, 21);
            this.chbIsShowUnit.TabIndex = 41;
            this.chbIsShowUnit.Text = "是";
            this.chbIsShowUnit.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(91, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "显示单位:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(26, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 17);
            this.label16.TabIndex = 26;
            this.label16.Text = "行  数:";
            // 
            // txtRows
            // 
            this.txtRows.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtRows.ForeColor = System.Drawing.Color.DimGray;
            this.txtRows.Location = new System.Drawing.Point(81, 16);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(64, 23);
            this.txtRows.TabIndex = 27;
            this.txtRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // MonyPanelProperyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 641);
            this.Controls.Add(this.groupBox1);
            this.Name = "MonyPanelProperyForm";
            this.Text = "MonyPanelProperyForm";
            this.Load += new System.EventHandler(this.MonyPanelProperyForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txttab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDefalutValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtheight;
        private System.Windows.Forms.TextBox txtwidth;
        private System.Windows.Forms.TextBox txtleft;
        private System.Windows.Forms.TextBox txttop;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chbIsprInt;
        private System.Windows.Forms.CheckBox chbIsvisible;
        private System.Windows.Forms.CheckBox chbIsmust;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBackgroud;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Button btnSetFont;
        private System.Windows.Forms.TextBox txtBackColor;
        private System.Windows.Forms.TextBox txtForeColor;
        private System.Windows.Forms.TextBox txtfont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColorDialog cd;
        private System.Windows.Forms.FontDialog fd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbbLow;
        private System.Windows.Forms.ComboBox cbbHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbBandings;
        private System.Windows.Forms.CheckBox chbIsShowUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label16;
    }
}