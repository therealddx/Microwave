namespace Microwave
{
    partial class SmithChartForm
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
            this.smithChart_pb = new System.Windows.Forms.PictureBox();
            this.saveSmithChart_btn = new System.Windows.Forms.Button();
            this.loadTwoPortNetwork_btn = new System.Windows.Forms.Button();
            this.setDesignFrequency_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sParamsChosen_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.s22_lbl = new System.Windows.Forms.Label();
            this.s21_lbl = new System.Windows.Forms.Label();
            this.s11_lbl = new System.Windows.Forms.Label();
            this.s12_lbl = new System.Windows.Forms.Label();
            this.completeCircuitDesign_tb = new System.Windows.Forms.TextBox();
            this.completeCircuitDesign_lbl = new System.Windows.Forms.Label();
            this.otherOscillationModes_tb = new System.Windows.Forms.TextBox();
            this.otherOscillationModes_lbl = new System.Windows.Forms.Label();
            this.pickGreatestGammaIN_btn = new System.Windows.Forms.Button();
            this.SmithChartForm_tc = new System.Windows.Forms.TabControl();
            this.OscillatorDesign_tp = new System.Windows.Forms.TabPage();
            this.AmplifierDesign_tp = new System.Windows.Forms.TabPage();
            this.amplifierDesignControl1 = new Microwave.AmplifierDesignControl();
            ((System.ComponentModel.ISupportInitialize)(this.smithChart_pb)).BeginInit();
            this.sParamsChosen_tlp.SuspendLayout();
            this.SmithChartForm_tc.SuspendLayout();
            this.OscillatorDesign_tp.SuspendLayout();
            this.AmplifierDesign_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // smithChart_pb
            // 
            this.smithChart_pb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.smithChart_pb.Location = new System.Drawing.Point(6, 3);
            this.smithChart_pb.Name = "smithChart_pb";
            this.smithChart_pb.Size = new System.Drawing.Size(800, 800);
            this.smithChart_pb.TabIndex = 0;
            this.smithChart_pb.TabStop = false;
            this.smithChart_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.smithChart_pb_MouseClick);
            // 
            // saveSmithChart_btn
            // 
            this.saveSmithChart_btn.Location = new System.Drawing.Point(849, 558);
            this.saveSmithChart_btn.Name = "saveSmithChart_btn";
            this.saveSmithChart_btn.Size = new System.Drawing.Size(313, 23);
            this.saveSmithChart_btn.TabIndex = 1;
            this.saveSmithChart_btn.Text = "Save Smith Chart (.bmp)";
            this.saveSmithChart_btn.UseVisualStyleBackColor = true;
            this.saveSmithChart_btn.Click += new System.EventHandler(this.saveSmithChart_btn_Click);
            // 
            // loadTwoPortNetwork_btn
            // 
            this.loadTwoPortNetwork_btn.Location = new System.Drawing.Point(849, 41);
            this.loadTwoPortNetwork_btn.Name = "loadTwoPortNetwork_btn";
            this.loadTwoPortNetwork_btn.Size = new System.Drawing.Size(313, 23);
            this.loadTwoPortNetwork_btn.TabIndex = 3;
            this.loadTwoPortNetwork_btn.Text = "Load Two-Port Network";
            this.loadTwoPortNetwork_btn.UseVisualStyleBackColor = true;
            this.loadTwoPortNetwork_btn.Click += new System.EventHandler(this.loadTwoPortNetwork_btn_Click);
            // 
            // setDesignFrequency_tb
            // 
            this.setDesignFrequency_tb.Location = new System.Drawing.Point(1017, 18);
            this.setDesignFrequency_tb.Name = "setDesignFrequency_tb";
            this.setDesignFrequency_tb.Size = new System.Drawing.Size(145, 20);
            this.setDesignFrequency_tb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(846, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Design Frequency (MHz)";
            // 
            // sParamsChosen_tlp
            // 
            this.sParamsChosen_tlp.ColumnCount = 2;
            this.sParamsChosen_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.Controls.Add(this.s22_lbl, 1, 1);
            this.sParamsChosen_tlp.Controls.Add(this.s21_lbl, 0, 1);
            this.sParamsChosen_tlp.Controls.Add(this.s11_lbl, 0, 0);
            this.sParamsChosen_tlp.Controls.Add(this.s12_lbl, 1, 0);
            this.sParamsChosen_tlp.Location = new System.Drawing.Point(849, 70);
            this.sParamsChosen_tlp.Name = "sParamsChosen_tlp";
            this.sParamsChosen_tlp.RowCount = 2;
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sParamsChosen_tlp.Size = new System.Drawing.Size(314, 100);
            this.sParamsChosen_tlp.TabIndex = 11;
            // 
            // s22_lbl
            // 
            this.s22_lbl.AutoSize = true;
            this.s22_lbl.Location = new System.Drawing.Point(160, 50);
            this.s22_lbl.Name = "s22_lbl";
            this.s22_lbl.Size = new System.Drawing.Size(35, 13);
            this.s22_lbl.TabIndex = 3;
            this.s22_lbl.Text = "label5";
            // 
            // s21_lbl
            // 
            this.s21_lbl.AutoSize = true;
            this.s21_lbl.Location = new System.Drawing.Point(3, 50);
            this.s21_lbl.Name = "s21_lbl";
            this.s21_lbl.Size = new System.Drawing.Size(35, 13);
            this.s21_lbl.TabIndex = 2;
            this.s21_lbl.Text = "label4";
            // 
            // s11_lbl
            // 
            this.s11_lbl.AutoSize = true;
            this.s11_lbl.Location = new System.Drawing.Point(3, 0);
            this.s11_lbl.Name = "s11_lbl";
            this.s11_lbl.Size = new System.Drawing.Size(35, 13);
            this.s11_lbl.TabIndex = 0;
            this.s11_lbl.Text = "label2";
            // 
            // s12_lbl
            // 
            this.s12_lbl.AutoSize = true;
            this.s12_lbl.Location = new System.Drawing.Point(160, 0);
            this.s12_lbl.Name = "s12_lbl";
            this.s12_lbl.Size = new System.Drawing.Size(35, 13);
            this.s12_lbl.TabIndex = 1;
            this.s12_lbl.Text = "label3";
            // 
            // completeCircuitDesign_tb
            // 
            this.completeCircuitDesign_tb.Location = new System.Drawing.Point(849, 257);
            this.completeCircuitDesign_tb.Multiline = true;
            this.completeCircuitDesign_tb.Name = "completeCircuitDesign_tb";
            this.completeCircuitDesign_tb.ReadOnly = true;
            this.completeCircuitDesign_tb.Size = new System.Drawing.Size(313, 138);
            this.completeCircuitDesign_tb.TabIndex = 12;
            this.completeCircuitDesign_tb.WordWrap = false;
            // 
            // completeCircuitDesign_lbl
            // 
            this.completeCircuitDesign_lbl.AutoSize = true;
            this.completeCircuitDesign_lbl.Location = new System.Drawing.Point(846, 242);
            this.completeCircuitDesign_lbl.Name = "completeCircuitDesign_lbl";
            this.completeCircuitDesign_lbl.Size = new System.Drawing.Size(119, 13);
            this.completeCircuitDesign_lbl.TabIndex = 13;
            this.completeCircuitDesign_lbl.Text = "Complete Circuit Design";
            // 
            // otherOscillationModes_tb
            // 
            this.otherOscillationModes_tb.Location = new System.Drawing.Point(849, 414);
            this.otherOscillationModes_tb.Multiline = true;
            this.otherOscillationModes_tb.Name = "otherOscillationModes_tb";
            this.otherOscillationModes_tb.ReadOnly = true;
            this.otherOscillationModes_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.otherOscillationModes_tb.Size = new System.Drawing.Size(313, 138);
            this.otherOscillationModes_tb.TabIndex = 14;
            this.otherOscillationModes_tb.WordWrap = false;
            // 
            // otherOscillationModes_lbl
            // 
            this.otherOscillationModes_lbl.AutoSize = true;
            this.otherOscillationModes_lbl.Location = new System.Drawing.Point(846, 398);
            this.otherOscillationModes_lbl.Name = "otherOscillationModes_lbl";
            this.otherOscillationModes_lbl.Size = new System.Drawing.Size(119, 13);
            this.otherOscillationModes_lbl.TabIndex = 15;
            this.otherOscillationModes_lbl.Text = "Other Oscillation Modes";
            // 
            // pickGreatestGammaIN_btn
            // 
            this.pickGreatestGammaIN_btn.Location = new System.Drawing.Point(849, 176);
            this.pickGreatestGammaIN_btn.Name = "pickGreatestGammaIN_btn";
            this.pickGreatestGammaIN_btn.Size = new System.Drawing.Size(75, 63);
            this.pickGreatestGammaIN_btn.TabIndex = 16;
            this.pickGreatestGammaIN_btn.Text = "Pick greatest gammaIN";
            this.pickGreatestGammaIN_btn.UseVisualStyleBackColor = true;
            this.pickGreatestGammaIN_btn.Click += new System.EventHandler(this.pickGreatestGammaIN_btn_Click);
            // 
            // SmithChartForm_tc
            // 
            this.SmithChartForm_tc.Controls.Add(this.OscillatorDesign_tp);
            this.SmithChartForm_tc.Controls.Add(this.AmplifierDesign_tp);
            this.SmithChartForm_tc.Location = new System.Drawing.Point(12, 12);
            this.SmithChartForm_tc.Name = "SmithChartForm_tc";
            this.SmithChartForm_tc.SelectedIndex = 0;
            this.SmithChartForm_tc.Size = new System.Drawing.Size(1189, 837);
            this.SmithChartForm_tc.TabIndex = 17;
            // 
            // OscillatorDesign_tp
            // 
            this.OscillatorDesign_tp.Controls.Add(this.completeCircuitDesign_tb);
            this.OscillatorDesign_tp.Controls.Add(this.label1);
            this.OscillatorDesign_tp.Controls.Add(this.sParamsChosen_tlp);
            this.OscillatorDesign_tp.Controls.Add(this.setDesignFrequency_tb);
            this.OscillatorDesign_tp.Controls.Add(this.pickGreatestGammaIN_btn);
            this.OscillatorDesign_tp.Controls.Add(this.loadTwoPortNetwork_btn);
            this.OscillatorDesign_tp.Controls.Add(this.completeCircuitDesign_lbl);
            this.OscillatorDesign_tp.Controls.Add(this.otherOscillationModes_lbl);
            this.OscillatorDesign_tp.Controls.Add(this.otherOscillationModes_tb);
            this.OscillatorDesign_tp.Controls.Add(this.smithChart_pb);
            this.OscillatorDesign_tp.Controls.Add(this.saveSmithChart_btn);
            this.OscillatorDesign_tp.Location = new System.Drawing.Point(4, 22);
            this.OscillatorDesign_tp.Name = "OscillatorDesign_tp";
            this.OscillatorDesign_tp.Padding = new System.Windows.Forms.Padding(3);
            this.OscillatorDesign_tp.Size = new System.Drawing.Size(1181, 811);
            this.OscillatorDesign_tp.TabIndex = 0;
            this.OscillatorDesign_tp.Text = "Oscillator Design";
            this.OscillatorDesign_tp.UseVisualStyleBackColor = true;
            // 
            // AmplifierDesign_tp
            // 
            this.AmplifierDesign_tp.Controls.Add(this.amplifierDesignControl1);
            this.AmplifierDesign_tp.Location = new System.Drawing.Point(4, 22);
            this.AmplifierDesign_tp.Name = "AmplifierDesign_tp";
            this.AmplifierDesign_tp.Padding = new System.Windows.Forms.Padding(3);
            this.AmplifierDesign_tp.Size = new System.Drawing.Size(1181, 811);
            this.AmplifierDesign_tp.TabIndex = 1;
            this.AmplifierDesign_tp.Text = "Amplifier Design";
            this.AmplifierDesign_tp.UseVisualStyleBackColor = true;
            // 
            // amplifierDesignControl1
            // 
            this.amplifierDesignControl1.Location = new System.Drawing.Point(0, 0);
            this.amplifierDesignControl1.Name = "amplifierDesignControl1";
            this.amplifierDesignControl1.Size = new System.Drawing.Size(1181, 811);
            this.amplifierDesignControl1.TabIndex = 0;
            // 
            // SmithChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 857);
            this.Controls.Add(this.SmithChartForm_tc);
            this.Name = "SmithChartForm";
            this.Text = "Smith Chart Design";
            this.Load += new System.EventHandler(this.SmithChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smithChart_pb)).EndInit();
            this.sParamsChosen_tlp.ResumeLayout(false);
            this.sParamsChosen_tlp.PerformLayout();
            this.SmithChartForm_tc.ResumeLayout(false);
            this.OscillatorDesign_tp.ResumeLayout(false);
            this.OscillatorDesign_tp.PerformLayout();
            this.AmplifierDesign_tp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox smithChart_pb;
        private System.Windows.Forms.Button saveSmithChart_btn;
        private System.Windows.Forms.Button loadTwoPortNetwork_btn;
        private System.Windows.Forms.TextBox setDesignFrequency_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel sParamsChosen_tlp;
        private System.Windows.Forms.Label s22_lbl;
        private System.Windows.Forms.Label s21_lbl;
        private System.Windows.Forms.Label s11_lbl;
        private System.Windows.Forms.Label s12_lbl;
        private System.Windows.Forms.TextBox completeCircuitDesign_tb;
        private System.Windows.Forms.Label completeCircuitDesign_lbl;
        private System.Windows.Forms.TextBox otherOscillationModes_tb;
        private System.Windows.Forms.Label otherOscillationModes_lbl;
        private System.Windows.Forms.Button pickGreatestGammaIN_btn;
        private System.Windows.Forms.TabControl SmithChartForm_tc;
        private System.Windows.Forms.TabPage OscillatorDesign_tp;
        private System.Windows.Forms.TabPage AmplifierDesign_tp;
        private AmplifierDesignControl amplifierDesignControl1;
    }
}