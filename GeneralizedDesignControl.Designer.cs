namespace Microwave
{
    partial class GeneralizedDesignControl
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
            this.setDesignFrequency_tb = new System.Windows.Forms.TextBox();
            this.loadTwoPortNetwork_btn = new System.Windows.Forms.Button();
            this.designFrequency_lbl = new System.Windows.Forms.Label();
            this.sParamsChosen_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.s22_lbl = new System.Windows.Forms.Label();
            this.s21_lbl = new System.Windows.Forms.Label();
            this.s11_lbl = new System.Windows.Forms.Label();
            this.s12_lbl = new System.Windows.Forms.Label();
            this.smithChart_pb = new System.Windows.Forms.PictureBox();
            this.sParamsChosen_tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smithChart_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // setDesignFrequency_tb
            // 
            this.setDesignFrequency_tb.Location = new System.Drawing.Point(1007, 22);
            this.setDesignFrequency_tb.Name = "setDesignFrequency_tb";
            this.setDesignFrequency_tb.Size = new System.Drawing.Size(145, 20);
            this.setDesignFrequency_tb.TabIndex = 13;
            // 
            // loadTwoPortNetwork_btn
            // 
            this.loadTwoPortNetwork_btn.Location = new System.Drawing.Point(839, 45);
            this.loadTwoPortNetwork_btn.Name = "loadTwoPortNetwork_btn";
            this.loadTwoPortNetwork_btn.Size = new System.Drawing.Size(313, 23);
            this.loadTwoPortNetwork_btn.TabIndex = 12;
            this.loadTwoPortNetwork_btn.Text = "Load Two-Port Network";
            this.loadTwoPortNetwork_btn.UseVisualStyleBackColor = true;
            this.loadTwoPortNetwork_btn.Click += new System.EventHandler(this.loadTwoPortNetwork_btn_Click);
            // 
            // designFrequency_lbl
            // 
            this.designFrequency_lbl.AutoSize = true;
            this.designFrequency_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.designFrequency_lbl.Location = new System.Drawing.Point(836, 22);
            this.designFrequency_lbl.Name = "designFrequency_lbl";
            this.designFrequency_lbl.Size = new System.Drawing.Size(165, 17);
            this.designFrequency_lbl.TabIndex = 14;
            this.designFrequency_lbl.Text = "Design Frequency (MHz)";
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
            this.sParamsChosen_tlp.Location = new System.Drawing.Point(839, 97);
            this.sParamsChosen_tlp.Name = "sParamsChosen_tlp";
            this.sParamsChosen_tlp.RowCount = 2;
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sParamsChosen_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.sParamsChosen_tlp.Size = new System.Drawing.Size(314, 100);
            this.sParamsChosen_tlp.TabIndex = 15;
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
            // smithChart_pb
            // 
            this.smithChart_pb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.smithChart_pb.Location = new System.Drawing.Point(0, 0);
            this.smithChart_pb.Name = "smithChart_pb";
            this.smithChart_pb.Size = new System.Drawing.Size(800, 800);
            this.smithChart_pb.TabIndex = 0;
            this.smithChart_pb.TabStop = false;
            // 
            // GeneralizedDesignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.smithChart_pb);
            this.Controls.Add(this.sParamsChosen_tlp);
            this.Controls.Add(this.designFrequency_lbl);
            this.Controls.Add(this.loadTwoPortNetwork_btn);
            this.Controls.Add(this.setDesignFrequency_tb);
            this.Name = "GeneralizedDesignControl";
            this.Size = new System.Drawing.Size(1181, 811);
            this.sParamsChosen_tlp.ResumeLayout(false);
            this.sParamsChosen_tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smithChart_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox setDesignFrequency_tb;
        private System.Windows.Forms.Button loadTwoPortNetwork_btn;
        private System.Windows.Forms.Label designFrequency_lbl;
        private System.Windows.Forms.TableLayoutPanel sParamsChosen_tlp;
        private System.Windows.Forms.Label s22_lbl;
        private System.Windows.Forms.Label s21_lbl;
        private System.Windows.Forms.Label s11_lbl;
        private System.Windows.Forms.Label s12_lbl;
        private System.Windows.Forms.PictureBox smithChart_pb;
    }
}
