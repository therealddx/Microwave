using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Microwave
{
    public partial class AmplifierDesignControl : GeneralizedDesignControl
    {
        public AmplifierDesignControl() : base()
        {
            InitializeComponent();
        }

        //Gamma plots, pre-calculated.
        private double[] stabilityPlots_FREQ;
        private ComplexXY[] stabilityPlots_IN_XY;
        private ComplexXY[] stabilityPlots_OUT_XY;

        //BackgroundWorker.
        private BackgroundWorker Bgw_Update;
        
        protected override void UpdateForNewParams()
        {
            //Init.
            Bgw_Update = new BackgroundWorker();
            Bgw_Update.WorkerReportsProgress = true;

            Bgw_Update.DoWork += Bgw_Update_DoWork;
            Bgw_Update.ProgressChanged += Bgw_Update_ReportProgress;
            Bgw_Update.RunWorkerCompleted += Bgw_Update_WorkerCompleted;

            Bgw_Update.RunWorkerAsync();
        }

        private void Bgw_Update_DoWork(object sender, DoWorkEventArgs e)
        {
            //Update S-parameter table.
            base.UpdateForNewParams();

            //Replace everything under here with a BGW.

            //Update mu.
            //Report progress, starting calculating mu.
            //string appendTo_stabilityVsFrequency_tb = ""; //For full mu function.
            //List<string> appendTo_conditionalStability_lb = new List<string>(); //For listing of conditional stabilities.
            double prg = 0;
            for (int freq_ind = 0; freq_ind < this.Device.freq.Count; freq_ind++)
            {
                //Assign.
                double f = this.Device.freq[freq_ind];

                //New temp tpn for this freq.
                TwoPortNetworks.TwoPortNetwork tpn = this.Device.ExtractTwoPortNetwork(f);

                //Calculate mu at this freq.
                double mu = tpn.mu();

                //Full fn. versus frequency.
                //appendTo_stabilityVsFrequency_tb += Convert.ToString(f) + ", " + Convert.ToString(mu) + Environment.NewLine; //ok.

                prg = (double)freq_ind / (double)(this.Device.freq.Count) * 50;
                Bgw_Update.ReportProgress((int)prg, new object[] { 1, stabilityVsFrequency_tb, Convert.ToString(f) + ", " + Convert.ToString(mu) + Environment.NewLine });

                if (mu < 1)
                {
                    //ReportProgress in here.
                    Bgw_Update.ReportProgress(0, new object[] { 0, ConditionalStabilityListing_lb, Convert.ToString(freq_ind) + ", " + Convert.ToString(f) + ", " + Convert.ToString(mu) });
                    //appendTo_conditionalStability_lb.Add(Convert.ToString(freq_ind) + ", " + Convert.ToString(f) + ", " + Convert.ToString(mu));
                }
            }
            //ThreadSafe.ListAddRemoveListboxThreadSafe_uc(this, ConditionalStabilityListing_lb, appendTo_conditionalStability_lb);
            //ThreadSafe.SetControlTextThreadSafe_uc(this, stabilityVsFrequency_tb, appendTo_stabilityVsFrequency_tb);

            //Pre-calculate all gammaIN(gammaL) and gammaOUT(gammaS) for all frequencies, store.
            ComplexLinearSpace gammaLS_Sweep = new ComplexLinearSpace(
                new LinearSpace(0.0, 1.0, (int)100),
                new LinearSpace(0.0, 360, (int)100)
                );
            stabilityPlots_FREQ = new double[this.Device.freq.Count];
            stabilityPlots_IN_XY = new ComplexXY[this.Device.freq.Count];
            stabilityPlots_OUT_XY = new ComplexXY[this.Device.freq.Count];
            
            for (int freq_ind = 0; freq_ind < this.Device.freq.Count; freq_ind++)
            {
                //Get the current tpn.
                TwoPortNetworks.TwoPortNetwork tpn = this.Device.ExtractTwoPortNetwork((int)freq_ind);

                //Calculate.
                stabilityPlots_FREQ[freq_ind] = this.Device.freq[freq_ind];
                stabilityPlots_IN_XY[freq_ind] = new Microwave.ComplexXY(gammaLS_Sweep, tpn.CalculateGammaIN);
                stabilityPlots_OUT_XY[freq_ind] = new Microwave.ComplexXY(gammaLS_Sweep, tpn.CalculateGammaOUT);

                //Show GUI.
                prg = 50 + 50 * ((double)freq_ind / (double)this.Device.freq.Count);
                Bgw_Update.ReportProgress((int)prg, new object[] { 2, calculationsProgress_lbl, freq_ind + " / " + this.Device.freq.Count });
            }
        }
        
        private void Bgw_Update_ReportProgress(object sender, ProgressChangedEventArgs e)
        {
            
            //Recover args.
            object[] args = e.UserState as object[];
            int selector = (int)args[0];
            if (selector == 0)
            {
                //Bgw_Update.ReportProgress(0, new object[] { 0, ConditionalStabilityListing_lb, Convert.ToString(freq_ind) + ", " + Convert.ToString(f) + ", " + Convert.ToString(mu) });
                ListBox lb = args[1] as ListBox;
                string addIn = args[2] as string;

                lb.Items.Add(addIn);
            }
            else if (selector == 1)
            {
                //Bgw_Update.ReportProgress(1, new object[] { 1, stabilityVsFrequency_tb, Convert.ToString(f) + ", " + Convert.ToString(mu) + Environment.NewLine });
                TextBox tb = args[1] as TextBox;
                string addIn = args[2] as string;

                tb.Text += addIn;

                calculations_prb.Value = e.ProgressPercentage;
            }
            else if (selector == 2)
            {
                //Bgw_Update.ReportProgress((int)prg, new object[] { 2, calculationsProgress_lbl, freq_ind + " / " + this.Device.freq.Count });
                Label lbl = args[1] as Label;
                string setIn = args[2] as string;

                lbl.Text = setIn;

                calculations_prb.Value = e.ProgressPercentage;
            }


        }

        private void Bgw_Update_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            calculations_prb.Value = 0;
            MessageBox.Show("Calculations complete");
        }
        
        //NOT RELATED TO UPDATING.
        private void ConjugateMatch_btn_Click(object sender, EventArgs e)
        {
            //Dummy validation script.
            //Take s-parameters.
            //TwoPortNetworks.TwoPortNetwork tpn = new TwoPortNetworks.TwoPortNetwork(
            //    MenialOperations.complex_magphase(0.869, -159, true),
            //    MenialOperations.complex_magphase(0.031, -9, true),
            //    MenialOperations.complex_magphase(4.250, 61, true),
            //    MenialOperations.complex_magphase(0.507, -117, true),
            //    TwoPortNetworks.STATE.S,
            //    50.0
            //    );
            //
            //ComplexXY gammaIN_TEST_XY = new ComplexXY(new ComplexLinearSpace(100, 100), tpn.CalculateGammaIN);
            //ComplexXY gammaOUT_TEST_XY = new ComplexXY(new ComplexLinearSpace(100, 100), tpn.CalculateGammaOUT);
            //
            //this.PlotGammaXY(gammaIN_TEST_XY, Color.Red);
            //this.PlotGammaXY(gammaOUT_TEST_XY, Color.Blue, false);
            
            TwoPortNetworks.TwoPortNetwork tpn = this.Device.ExtractTwoPortNetwork(DesignFrequency);
            
            //Calculate gamma_s and gamma_L.
            Complex gamma_s = PAdesign.gamma_S(tpn);
            Complex gamma_l = PAdesign.gamma_L(tpn);
            Complex Z_s = Conversions.GammaToZ(gamma_s, this.Device.Zo);
            Complex Z_l = Conversions.GammaToZ(gamma_l, this.Device.Zo);
            
            //Compute gain.
            double GS = PAdesign.G_S(tpn);
            double GL = PAdesign.G_L(tpn);
            double GTotal = PAdesign.G_total(tpn);
            
            //Report.
            string CompleteCircuitDesign = "";
            
            CompleteCircuitDesign += "Gamma S: " + Environment.NewLine +
                gamma_s.Magnitude + " " + MenialOperations.radtodeg(gamma_s.Phase) + Environment.NewLine +
                Z_s + Environment.NewLine +
                Z_s.Real + ", " + Conversions.XtoComponent(Z_s.Imaginary, DesignFrequency) + Environment.NewLine + Environment.NewLine;
            
            CompleteCircuitDesign += "Gamma L: " + Environment.NewLine +
                gamma_l.Magnitude + " " + MenialOperations.radtodeg(gamma_l.Phase) + Environment.NewLine +
                Z_l + Environment.NewLine +
                Z_l.Real + ", " + Conversions.XtoComponent(Z_l.Imaginary, DesignFrequency) + Environment.NewLine + Environment.NewLine;
            
            ////These.... might not be correct.....
            //CompleteCircuitDesign += "GS is: " + GS + " (" + 10 * Math.Log10(GS) + "dB)" + Environment.NewLine;
            //CompleteCircuitDesign += "GL is: " + GL + " (" + 10 * Math.Log10(GL) + "dB)" + Environment.NewLine;
            //CompleteCircuitDesign += "GTotal is: " + GTotal + " (" + 10 * Math.Log10(GTotal) + "dB)" + Environment.NewLine;
            //CompleteCircuitDesign += "Mu is: " + tpn.mu();
            //
            ThreadSafe.SetControlTextThreadSafe_uc(this, CompleteCircuitDesign_tb, CompleteCircuitDesign);
        }
        
        private void ConditionalStability_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get freq.
            int SelectedFrequencyIndex = Convert.ToInt32(ConditionalStabilityListing_lb.SelectedItem.ToString().Split(',')[0].Trim());
            
            //Plot.
            this.PlotGammaXY(stabilityPlots_IN_XY[SelectedFrequencyIndex], Color.Red);
            this.PlotGammaXY(stabilityPlots_OUT_XY[SelectedFrequencyIndex], Color.Blue, false);
        }
    }
}