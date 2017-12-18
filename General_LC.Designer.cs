namespace Microwave
{
    partial class General_LC
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
            this.calculateZs_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localSettings_gb = new System.Windows.Forms.GroupBox();
            this.rad_rb = new System.Windows.Forms.RadioButton();
            this.deg_rb = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VsAmpl_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ZsC_lbl = new System.Windows.Forms.Label();
            this.ZsConjComponent_tb = new System.Windows.Forms.TextBox();
            this.Zs_tb = new System.Windows.Forms.TextBox();
            this.ZsConj_tb = new System.Windows.Forms.TextBox();
            this.ZsComponent_tb = new System.Windows.Forms.TextBox();
            this.Zs_lbl = new System.Windows.Forms.Label();
            this.Vs_lbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.frequency_tb = new System.Windows.Forms.TextBox();
            this.Rl2_tb = new System.Windows.Forms.TextBox();
            this.Rl1_tb = new System.Windows.Forms.TextBox();
            this.Va1_tb = new System.Windows.Forms.TextBox();
            this.Va2_tb = new System.Windows.Forms.TextBox();
            this.Rl2_lbl = new System.Windows.Forms.Label();
            this.Va1_lbl = new System.Windows.Forms.Label();
            this.Va2_lbl = new System.Windows.Forms.Label();
            this.Rl1_lbl = new System.Windows.Forms.Label();
            this.frequency_lbl = new System.Windows.Forms.Label();
            this.CalculateLmatch_gb = new System.Windows.Forms.GroupBox();
            this.calculateLmatch_btn = new System.Windows.Forms.Button();
            this.CalculateLmatch_Output_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.CalculateLmatch_Output_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CalculateLmatch_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.CalculateLMatch_Zo_tb = new System.Windows.Forms.TextBox();
            this.CalculateLmatch_frequency_tb = new System.Windows.Forms.TextBox();
            this.CalculateLMatch_ZB_tb = new System.Windows.Forms.TextBox();
            this.CalculateLMatch_ZA_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CalculateLmatch_FilterType_gb = new System.Windows.Forms.GroupBox();
            this.lowpass_rb = new System.Windows.Forms.RadioButton();
            this.highpass_rb = new System.Windows.Forms.RadioButton();
            this.CalculateLmatch_Circuit_pb = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.localSettings_gb.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.CalculateLmatch_gb.SuspendLayout();
            this.CalculateLmatch_Output_tlp.SuspendLayout();
            this.CalculateLmatch_tlp.SuspendLayout();
            this.CalculateLmatch_FilterType_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculateLmatch_Circuit_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // calculateZs_btn
            // 
            this.calculateZs_btn.Location = new System.Drawing.Point(6, 147);
            this.calculateZs_btn.Name = "calculateZs_btn";
            this.calculateZs_btn.Size = new System.Drawing.Size(236, 23);
            this.calculateZs_btn.TabIndex = 0;
            this.calculateZs_btn.Text = "Calculate Z_S";
            this.calculateZs_btn.UseVisualStyleBackColor = true;
            this.calculateZs_btn.Click += new System.EventHandler(this.calculateZs_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localSettings_gb);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.calculateZs_btn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 314);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculate Zs";
            // 
            // localSettings_gb
            // 
            this.localSettings_gb.Controls.Add(this.rad_rb);
            this.localSettings_gb.Controls.Add(this.deg_rb);
            this.localSettings_gb.Location = new System.Drawing.Point(248, 22);
            this.localSettings_gb.Name = "localSettings_gb";
            this.localSettings_gb.Size = new System.Drawing.Size(102, 64);
            this.localSettings_gb.TabIndex = 12;
            this.localSettings_gb.TabStop = false;
            this.localSettings_gb.Text = "Local Settings";
            // 
            // rad_rb
            // 
            this.rad_rb.AutoSize = true;
            this.rad_rb.Location = new System.Drawing.Point(6, 19);
            this.rad_rb.Name = "rad_rb";
            this.rad_rb.Size = new System.Drawing.Size(64, 17);
            this.rad_rb.TabIndex = 10;
            this.rad_rb.TabStop = true;
            this.rad_rb.Text = "Radians";
            this.rad_rb.UseVisualStyleBackColor = true;
            // 
            // deg_rb
            // 
            this.deg_rb.AutoSize = true;
            this.deg_rb.Location = new System.Drawing.Point(6, 42);
            this.deg_rb.Name = "deg_rb";
            this.deg_rb.Size = new System.Drawing.Size(65, 17);
            this.deg_rb.TabIndex = 11;
            this.deg_rb.TabStop = true;
            this.deg_rb.Text = "Degrees";
            this.deg_rb.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.Controls.Add(this.VsAmpl_tb, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ZsC_lbl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ZsConjComponent_tb, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.Zs_tb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ZsConj_tb, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ZsComponent_tb, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Zs_lbl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Vs_lbl, 0, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 176);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(236, 128);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // VsAmpl_tb
            // 
            this.VsAmpl_tb.Location = new System.Drawing.Point(62, 103);
            this.VsAmpl_tb.Name = "VsAmpl_tb";
            this.VsAmpl_tb.ReadOnly = true;
            this.VsAmpl_tb.Size = new System.Drawing.Size(171, 20);
            this.VsAmpl_tb.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Z_S*c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Z_S*";
            // 
            // ZsC_lbl
            // 
            this.ZsC_lbl.AutoSize = true;
            this.ZsC_lbl.Location = new System.Drawing.Point(3, 25);
            this.ZsC_lbl.Name = "ZsC_lbl";
            this.ZsC_lbl.Size = new System.Drawing.Size(33, 13);
            this.ZsC_lbl.TabIndex = 10;
            this.ZsC_lbl.Text = "Z_Sc";
            // 
            // ZsConjComponent_tb
            // 
            this.ZsConjComponent_tb.Location = new System.Drawing.Point(62, 78);
            this.ZsConjComponent_tb.Name = "ZsConjComponent_tb";
            this.ZsConjComponent_tb.ReadOnly = true;
            this.ZsConjComponent_tb.Size = new System.Drawing.Size(171, 20);
            this.ZsConjComponent_tb.TabIndex = 8;
            // 
            // Zs_tb
            // 
            this.Zs_tb.Location = new System.Drawing.Point(62, 3);
            this.Zs_tb.Name = "Zs_tb";
            this.Zs_tb.ReadOnly = true;
            this.Zs_tb.Size = new System.Drawing.Size(171, 20);
            this.Zs_tb.TabIndex = 5;
            // 
            // ZsConj_tb
            // 
            this.ZsConj_tb.Location = new System.Drawing.Point(62, 53);
            this.ZsConj_tb.Name = "ZsConj_tb";
            this.ZsConj_tb.ReadOnly = true;
            this.ZsConj_tb.Size = new System.Drawing.Size(171, 20);
            this.ZsConj_tb.TabIndex = 6;
            // 
            // ZsComponent_tb
            // 
            this.ZsComponent_tb.Location = new System.Drawing.Point(62, 28);
            this.ZsComponent_tb.Name = "ZsComponent_tb";
            this.ZsComponent_tb.ReadOnly = true;
            this.ZsComponent_tb.Size = new System.Drawing.Size(171, 20);
            this.ZsComponent_tb.TabIndex = 7;
            // 
            // Zs_lbl
            // 
            this.Zs_lbl.AutoSize = true;
            this.Zs_lbl.Location = new System.Drawing.Point(3, 0);
            this.Zs_lbl.Name = "Zs_lbl";
            this.Zs_lbl.Size = new System.Drawing.Size(27, 13);
            this.Zs_lbl.TabIndex = 9;
            this.Zs_lbl.Text = "Z_S";
            // 
            // Vs_lbl
            // 
            this.Vs_lbl.AutoSize = true;
            this.Vs_lbl.Location = new System.Drawing.Point(3, 100);
            this.Vs_lbl.Name = "Vs_lbl";
            this.Vs_lbl.Size = new System.Drawing.Size(50, 13);
            this.Vs_lbl.TabIndex = 13;
            this.Vs_lbl.Text = "Vs (ampl)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.frequency_tb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Rl2_tb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Rl1_tb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Va1_tb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Va2_tb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Rl2_lbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Va1_lbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Va2_lbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Rl1_lbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.frequency_lbl, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 119);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frequency_tb
            // 
            this.frequency_tb.Location = new System.Drawing.Point(62, 95);
            this.frequency_tb.Name = "frequency_tb";
            this.frequency_tb.Size = new System.Drawing.Size(171, 20);
            this.frequency_tb.TabIndex = 10;
            // 
            // Rl2_tb
            // 
            this.Rl2_tb.Location = new System.Drawing.Point(62, 72);
            this.Rl2_tb.Name = "Rl2_tb";
            this.Rl2_tb.Size = new System.Drawing.Size(171, 20);
            this.Rl2_tb.TabIndex = 8;
            // 
            // Rl1_tb
            // 
            this.Rl1_tb.Location = new System.Drawing.Point(62, 26);
            this.Rl1_tb.Name = "Rl1_tb";
            this.Rl1_tb.Size = new System.Drawing.Size(171, 20);
            this.Rl1_tb.TabIndex = 7;
            // 
            // Va1_tb
            // 
            this.Va1_tb.Location = new System.Drawing.Point(62, 3);
            this.Va1_tb.Name = "Va1_tb";
            this.Va1_tb.Size = new System.Drawing.Size(171, 20);
            this.Va1_tb.TabIndex = 1;
            // 
            // Va2_tb
            // 
            this.Va2_tb.Location = new System.Drawing.Point(62, 49);
            this.Va2_tb.Name = "Va2_tb";
            this.Va2_tb.Size = new System.Drawing.Size(171, 20);
            this.Va2_tb.TabIndex = 2;
            // 
            // Rl2_lbl
            // 
            this.Rl2_lbl.AutoSize = true;
            this.Rl2_lbl.Location = new System.Drawing.Point(3, 69);
            this.Rl2_lbl.Name = "Rl2_lbl";
            this.Rl2_lbl.Size = new System.Drawing.Size(32, 13);
            this.Rl2_lbl.TabIndex = 6;
            this.Rl2_lbl.Text = "Z_L2";
            // 
            // Va1_lbl
            // 
            this.Va1_lbl.AutoSize = true;
            this.Va1_lbl.Location = new System.Drawing.Point(3, 0);
            this.Va1_lbl.Name = "Va1_lbl";
            this.Va1_lbl.Size = new System.Drawing.Size(33, 13);
            this.Va1_lbl.TabIndex = 3;
            this.Va1_lbl.Text = "V_A1";
            // 
            // Va2_lbl
            // 
            this.Va2_lbl.AutoSize = true;
            this.Va2_lbl.Location = new System.Drawing.Point(3, 46);
            this.Va2_lbl.Name = "Va2_lbl";
            this.Va2_lbl.Size = new System.Drawing.Size(33, 13);
            this.Va2_lbl.TabIndex = 0;
            this.Va2_lbl.Text = "V_A2";
            // 
            // Rl1_lbl
            // 
            this.Rl1_lbl.AutoSize = true;
            this.Rl1_lbl.Location = new System.Drawing.Point(3, 23);
            this.Rl1_lbl.Name = "Rl1_lbl";
            this.Rl1_lbl.Size = new System.Drawing.Size(32, 13);
            this.Rl1_lbl.TabIndex = 4;
            this.Rl1_lbl.Text = "Z_L1";
            // 
            // frequency_lbl
            // 
            this.frequency_lbl.AutoSize = true;
            this.frequency_lbl.Location = new System.Drawing.Point(3, 92);
            this.frequency_lbl.Name = "frequency_lbl";
            this.frequency_lbl.Size = new System.Drawing.Size(50, 13);
            this.frequency_lbl.TabIndex = 9;
            this.frequency_lbl.Text = "Freq (Hz)";
            // 
            // CalculateLmatch_gb
            // 
            this.CalculateLmatch_gb.Controls.Add(this.calculateLmatch_btn);
            this.CalculateLmatch_gb.Controls.Add(this.CalculateLmatch_Output_tlp);
            this.CalculateLmatch_gb.Controls.Add(this.CalculateLmatch_tlp);
            this.CalculateLmatch_gb.Controls.Add(this.CalculateLmatch_FilterType_gb);
            this.CalculateLmatch_gb.Location = new System.Drawing.Point(375, 12);
            this.CalculateLmatch_gb.Name = "CalculateLmatch_gb";
            this.CalculateLmatch_gb.Size = new System.Drawing.Size(279, 463);
            this.CalculateLmatch_gb.TabIndex = 2;
            this.CalculateLmatch_gb.TabStop = false;
            this.CalculateLmatch_gb.Text = "Calculate L-match";
            // 
            // calculateLmatch_btn
            // 
            this.calculateLmatch_btn.Location = new System.Drawing.Point(6, 185);
            this.calculateLmatch_btn.Name = "calculateLmatch_btn";
            this.calculateLmatch_btn.Size = new System.Drawing.Size(264, 23);
            this.calculateLmatch_btn.TabIndex = 0;
            this.calculateLmatch_btn.Text = "Calculate L-match";
            this.calculateLmatch_btn.UseVisualStyleBackColor = true;
            this.calculateLmatch_btn.Click += new System.EventHandler(this.calculateLmatch_btn_Click);
            // 
            // CalculateLmatch_Output_tlp
            // 
            this.CalculateLmatch_Output_tlp.ColumnCount = 2;
            this.CalculateLmatch_Output_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.83146F));
            this.CalculateLmatch_Output_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.16854F));
            this.CalculateLmatch_Output_tlp.Controls.Add(this.CalculateLmatch_Output_tb, 1, 0);
            this.CalculateLmatch_Output_tlp.Controls.Add(this.label6, 0, 0);
            this.CalculateLmatch_Output_tlp.Controls.Add(this.label7, 0, 1);
            this.CalculateLmatch_Output_tlp.Controls.Add(this.CalculateLmatch_Circuit_pb, 1, 1);
            this.CalculateLmatch_Output_tlp.Location = new System.Drawing.Point(6, 214);
            this.CalculateLmatch_Output_tlp.Name = "CalculateLmatch_Output_tlp";
            this.CalculateLmatch_Output_tlp.RowCount = 2;
            this.CalculateLmatch_Output_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CalculateLmatch_Output_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CalculateLmatch_Output_tlp.Size = new System.Drawing.Size(267, 243);
            this.CalculateLmatch_Output_tlp.TabIndex = 3;
            // 
            // CalculateLmatch_Output_tb
            // 
            this.CalculateLmatch_Output_tb.Location = new System.Drawing.Point(95, 3);
            this.CalculateLmatch_Output_tb.Multiline = true;
            this.CalculateLmatch_Output_tb.Name = "CalculateLmatch_Output_tb";
            this.CalculateLmatch_Output_tb.ReadOnly = true;
            this.CalculateLmatch_Output_tb.Size = new System.Drawing.Size(169, 115);
            this.CalculateLmatch_Output_tb.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Output (Text)";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Output (Circuit)";
            // 
            // CalculateLmatch_tlp
            // 
            this.CalculateLmatch_tlp.ColumnCount = 2;
            this.CalculateLmatch_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.CalculateLmatch_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.CalculateLmatch_tlp.Controls.Add(this.CalculateLMatch_Zo_tb, 1, 3);
            this.CalculateLmatch_tlp.Controls.Add(this.CalculateLmatch_frequency_tb, 1, 2);
            this.CalculateLmatch_tlp.Controls.Add(this.CalculateLMatch_ZB_tb, 1, 1);
            this.CalculateLmatch_tlp.Controls.Add(this.CalculateLMatch_ZA_tb, 1, 0);
            this.CalculateLmatch_tlp.Controls.Add(this.label1, 0, 0);
            this.CalculateLmatch_tlp.Controls.Add(this.label2, 0, 1);
            this.CalculateLmatch_tlp.Controls.Add(this.label5, 0, 2);
            this.CalculateLmatch_tlp.Controls.Add(this.label8, 0, 3);
            this.CalculateLmatch_tlp.Location = new System.Drawing.Point(6, 74);
            this.CalculateLmatch_tlp.Name = "CalculateLmatch_tlp";
            this.CalculateLmatch_tlp.RowCount = 4;
            this.CalculateLmatch_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CalculateLmatch_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CalculateLmatch_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CalculateLmatch_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CalculateLmatch_tlp.Size = new System.Drawing.Size(267, 96);
            this.CalculateLmatch_tlp.TabIndex = 2;
            // 
            // CalculateLMatch_Zo_tb
            // 
            this.CalculateLMatch_Zo_tb.Location = new System.Drawing.Point(101, 75);
            this.CalculateLMatch_Zo_tb.Name = "CalculateLMatch_Zo_tb";
            this.CalculateLMatch_Zo_tb.Size = new System.Drawing.Size(163, 20);
            this.CalculateLMatch_Zo_tb.TabIndex = 8;
            // 
            // CalculateLmatch_frequency_tb
            // 
            this.CalculateLmatch_frequency_tb.Location = new System.Drawing.Point(101, 51);
            this.CalculateLmatch_frequency_tb.Name = "CalculateLmatch_frequency_tb";
            this.CalculateLmatch_frequency_tb.Size = new System.Drawing.Size(163, 20);
            this.CalculateLmatch_frequency_tb.TabIndex = 6;
            // 
            // CalculateLMatch_ZB_tb
            // 
            this.CalculateLMatch_ZB_tb.Location = new System.Drawing.Point(101, 27);
            this.CalculateLMatch_ZB_tb.Name = "CalculateLMatch_ZB_tb";
            this.CalculateLMatch_ZB_tb.Size = new System.Drawing.Size(163, 20);
            this.CalculateLMatch_ZB_tb.TabIndex = 4;
            // 
            // CalculateLMatch_ZA_tb
            // 
            this.CalculateLMatch_ZA_tb.Location = new System.Drawing.Point(101, 3);
            this.CalculateLMatch_ZA_tb.Name = "CalculateLMatch_ZA_tb";
            this.CalculateLMatch_ZA_tb.Size = new System.Drawing.Size(163, 20);
            this.CalculateLMatch_ZA_tb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make this Z: (ZA)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Look like: (ZB)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Freq (Hz)";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Zo (Ω)";
            // 
            // CalculateLmatch_FilterType_gb
            // 
            this.CalculateLmatch_FilterType_gb.Controls.Add(this.lowpass_rb);
            this.CalculateLmatch_FilterType_gb.Controls.Add(this.highpass_rb);
            this.CalculateLmatch_FilterType_gb.Location = new System.Drawing.Point(6, 16);
            this.CalculateLmatch_FilterType_gb.Name = "CalculateLmatch_FilterType_gb";
            this.CalculateLmatch_FilterType_gb.Size = new System.Drawing.Size(200, 48);
            this.CalculateLmatch_FilterType_gb.TabIndex = 1;
            this.CalculateLmatch_FilterType_gb.TabStop = false;
            this.CalculateLmatch_FilterType_gb.Text = "Filter Type";
            // 
            // lowpass_rb
            // 
            this.lowpass_rb.AutoSize = true;
            this.lowpass_rb.Location = new System.Drawing.Point(110, 21);
            this.lowpass_rb.Name = "lowpass_rb";
            this.lowpass_rb.Size = new System.Drawing.Size(67, 17);
            this.lowpass_rb.TabIndex = 1;
            this.lowpass_rb.TabStop = true;
            this.lowpass_rb.Text = "Lowpass";
            this.lowpass_rb.UseVisualStyleBackColor = true;
            // 
            // highpass_rb
            // 
            this.highpass_rb.AutoSize = true;
            this.highpass_rb.Location = new System.Drawing.Point(19, 19);
            this.highpass_rb.Name = "highpass_rb";
            this.highpass_rb.Size = new System.Drawing.Size(69, 17);
            this.highpass_rb.TabIndex = 0;
            this.highpass_rb.TabStop = true;
            this.highpass_rb.Text = "Highpass";
            this.highpass_rb.UseVisualStyleBackColor = true;
            // 
            // CalculateLmatch_Circuit_pb
            // 
            this.CalculateLmatch_Circuit_pb.Location = new System.Drawing.Point(95, 124);
            this.CalculateLmatch_Circuit_pb.Name = "CalculateLmatch_Circuit_pb";
            this.CalculateLmatch_Circuit_pb.Size = new System.Drawing.Size(169, 116);
            this.CalculateLmatch_Circuit_pb.TabIndex = 8;
            this.CalculateLmatch_Circuit_pb.TabStop = false;
            // 
            // General_LC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 531);
            this.Controls.Add(this.CalculateLmatch_gb);
            this.Controls.Add(this.groupBox1);
            this.Name = "General_LC";
            this.Text = "General_LC";
            this.groupBox1.ResumeLayout(false);
            this.localSettings_gb.ResumeLayout(false);
            this.localSettings_gb.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.CalculateLmatch_gb.ResumeLayout(false);
            this.CalculateLmatch_Output_tlp.ResumeLayout(false);
            this.CalculateLmatch_Output_tlp.PerformLayout();
            this.CalculateLmatch_tlp.ResumeLayout(false);
            this.CalculateLmatch_tlp.PerformLayout();
            this.CalculateLmatch_FilterType_gb.ResumeLayout(false);
            this.CalculateLmatch_FilterType_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculateLmatch_Circuit_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calculateZs_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox Rl2_tb;
        private System.Windows.Forms.TextBox Rl1_tb;
        private System.Windows.Forms.Label Rl2_lbl;
        private System.Windows.Forms.TextBox Va1_tb;
        private System.Windows.Forms.Label Va1_lbl;
        private System.Windows.Forms.TextBox Va2_tb;
        private System.Windows.Forms.Label Va2_lbl;
        private System.Windows.Forms.Label Rl1_lbl;
        private System.Windows.Forms.TextBox Zs_tb;
        private System.Windows.Forms.TextBox ZsConjComponent_tb;
        private System.Windows.Forms.TextBox ZsComponent_tb;
        private System.Windows.Forms.TextBox ZsConj_tb;
        private System.Windows.Forms.TextBox frequency_tb;
        private System.Windows.Forms.Label frequency_lbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ZsC_lbl;
        private System.Windows.Forms.Label Zs_lbl;
        private System.Windows.Forms.RadioButton rad_rb;
        private System.Windows.Forms.RadioButton deg_rb;
        private System.Windows.Forms.GroupBox localSettings_gb;
        private System.Windows.Forms.TextBox VsAmpl_tb;
        private System.Windows.Forms.Label Vs_lbl;
        private System.Windows.Forms.GroupBox CalculateLmatch_gb;
        private System.Windows.Forms.GroupBox CalculateLmatch_FilterType_gb;
        private System.Windows.Forms.RadioButton lowpass_rb;
        private System.Windows.Forms.RadioButton highpass_rb;
        private System.Windows.Forms.TableLayoutPanel CalculateLmatch_tlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CalculateLMatch_ZB_tb;
        private System.Windows.Forms.TextBox CalculateLMatch_ZA_tb;
        private System.Windows.Forms.TableLayoutPanel CalculateLmatch_Output_tlp;
        private System.Windows.Forms.Button calculateLmatch_btn;
        private System.Windows.Forms.TextBox CalculateLmatch_frequency_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CalculateLmatch_Output_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CalculateLMatch_Zo_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox CalculateLmatch_Circuit_pb;
    }
}