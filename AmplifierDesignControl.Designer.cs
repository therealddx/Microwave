namespace Microwave
{
    partial class AmplifierDesignControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AmplifierSpecific_gb = new System.Windows.Forms.GroupBox();
            this.ConditionalStabilityListing_lb = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompleteCircuitDesign_tb = new System.Windows.Forms.TextBox();
            this.AmplifierDesignOptions_gb = new System.Windows.Forms.GroupBox();
            this.ConjugateMatch_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stabilityVsFrequency_tb = new System.Windows.Forms.TextBox();
            this.calculations_prb = new System.Windows.Forms.ProgressBar();
            this.calculationsProgress_lbl = new System.Windows.Forms.Label();
            this.AmplifierSpecific_gb.SuspendLayout();
            this.AmplifierDesignOptions_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // AmplifierSpecific_gb
            // 
            this.AmplifierSpecific_gb.Controls.Add(this.ConditionalStabilityListing_lb);
            this.AmplifierSpecific_gb.Controls.Add(this.label3);
            this.AmplifierSpecific_gb.Controls.Add(this.label2);
            this.AmplifierSpecific_gb.Controls.Add(this.CompleteCircuitDesign_tb);
            this.AmplifierSpecific_gb.Controls.Add(this.AmplifierDesignOptions_gb);
            this.AmplifierSpecific_gb.Controls.Add(this.label1);
            this.AmplifierSpecific_gb.Controls.Add(this.stabilityVsFrequency_tb);
            this.AmplifierSpecific_gb.Location = new System.Drawing.Point(839, 238);
            this.AmplifierSpecific_gb.Name = "AmplifierSpecific_gb";
            this.AmplifierSpecific_gb.Size = new System.Drawing.Size(314, 574);
            this.AmplifierSpecific_gb.TabIndex = 18;
            this.AmplifierSpecific_gb.TabStop = false;
            this.AmplifierSpecific_gb.Text = "Amplifier-Specific";
            // 
            // ConditionalStabilityListing_lb
            // 
            this.ConditionalStabilityListing_lb.FormattingEnabled = true;
            this.ConditionalStabilityListing_lb.Location = new System.Drawing.Point(6, 150);
            this.ConditionalStabilityListing_lb.Name = "ConditionalStabilityListing_lb";
            this.ConditionalStabilityListing_lb.Size = new System.Drawing.Size(302, 238);
            this.ConditionalStabilityListing_lb.TabIndex = 8;
            this.ConditionalStabilityListing_lb.SelectedIndexChanged += new System.EventHandler(this.ConditionalStability_lb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Conditional Stability (Gamma IN)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Complete Circuit Design";
            // 
            // CompleteCircuitDesign_tb
            // 
            this.CompleteCircuitDesign_tb.Location = new System.Drawing.Point(6, 473);
            this.CompleteCircuitDesign_tb.Multiline = true;
            this.CompleteCircuitDesign_tb.Name = "CompleteCircuitDesign_tb";
            this.CompleteCircuitDesign_tb.ReadOnly = true;
            this.CompleteCircuitDesign_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CompleteCircuitDesign_tb.Size = new System.Drawing.Size(302, 95);
            this.CompleteCircuitDesign_tb.TabIndex = 4;
            // 
            // AmplifierDesignOptions_gb
            // 
            this.AmplifierDesignOptions_gb.Controls.Add(this.ConjugateMatch_btn);
            this.AmplifierDesignOptions_gb.Location = new System.Drawing.Point(6, 402);
            this.AmplifierDesignOptions_gb.Name = "AmplifierDesignOptions_gb";
            this.AmplifierDesignOptions_gb.Size = new System.Drawing.Size(302, 52);
            this.AmplifierDesignOptions_gb.TabIndex = 3;
            this.AmplifierDesignOptions_gb.TabStop = false;
            this.AmplifierDesignOptions_gb.Text = "Amplifier Design Options";
            // 
            // ConjugateMatch_btn
            // 
            this.ConjugateMatch_btn.Location = new System.Drawing.Point(6, 19);
            this.ConjugateMatch_btn.Name = "ConjugateMatch_btn";
            this.ConjugateMatch_btn.Size = new System.Drawing.Size(290, 23);
            this.ConjugateMatch_btn.TabIndex = 2;
            this.ConjugateMatch_btn.Text = "Conjugate-Match, Max Gain";
            this.ConjugateMatch_btn.UseVisualStyleBackColor = true;
            this.ConjugateMatch_btn.Click += new System.EventHandler(this.ConjugateMatch_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stability vs. Frequency (mu-test)";
            // 
            // stabilityVsFrequency_tb
            // 
            this.stabilityVsFrequency_tb.Location = new System.Drawing.Point(6, 36);
            this.stabilityVsFrequency_tb.Multiline = true;
            this.stabilityVsFrequency_tb.Name = "stabilityVsFrequency_tb";
            this.stabilityVsFrequency_tb.ReadOnly = true;
            this.stabilityVsFrequency_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stabilityVsFrequency_tb.Size = new System.Drawing.Size(302, 86);
            this.stabilityVsFrequency_tb.TabIndex = 0;
            // 
            // calculations_prb
            // 
            this.calculations_prb.Location = new System.Drawing.Point(920, 203);
            this.calculations_prb.Name = "calculations_prb";
            this.calculations_prb.Size = new System.Drawing.Size(233, 23);
            this.calculations_prb.TabIndex = 20;
            // 
            // calculationsProgress_lbl
            // 
            this.calculationsProgress_lbl.AutoSize = true;
            this.calculationsProgress_lbl.Location = new System.Drawing.Point(842, 213);
            this.calculationsProgress_lbl.Name = "calculationsProgress_lbl";
            this.calculationsProgress_lbl.Size = new System.Drawing.Size(38, 13);
            this.calculationsProgress_lbl.TabIndex = 21;
            this.calculationsProgress_lbl.Text = "prg_lbl";
            // 
            // AmplifierDesignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculationsProgress_lbl);
            this.Controls.Add(this.calculations_prb);
            this.Controls.Add(this.AmplifierSpecific_gb);
            this.Name = "AmplifierDesignControl";
            this.Controls.SetChildIndex(this.AmplifierSpecific_gb, 0);
            this.Controls.SetChildIndex(this.calculations_prb, 0);
            this.Controls.SetChildIndex(this.calculationsProgress_lbl, 0);
            this.AmplifierSpecific_gb.ResumeLayout(false);
            this.AmplifierSpecific_gb.PerformLayout();
            this.AmplifierDesignOptions_gb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AmplifierSpecific_gb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stabilityVsFrequency_tb;
        private System.Windows.Forms.Button ConjugateMatch_btn;
        private System.Windows.Forms.GroupBox AmplifierDesignOptions_gb;
        private System.Windows.Forms.TextBox CompleteCircuitDesign_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ConditionalStabilityListing_lb;
        private System.Windows.Forms.ProgressBar calculations_prb;
        private System.Windows.Forms.Label calculationsProgress_lbl;
    }
}
