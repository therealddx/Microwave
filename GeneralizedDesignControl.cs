using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microwave
{
    public partial class GeneralizedDesignControl : UserControl
    {
        protected SmithChart smithChart;
        protected TwoPortNetworks.FrequencyDependentTwoPortNetwork Device;
        protected double DesignFrequency;
        
        public GeneralizedDesignControl()
        {
            InitializeComponent();

            smithChart = new SmithChart(50.0);

            smithChart_pb.Image = smithChart.graph;
            smithChart_pb.BringToFront();
            smithChart_pb.Show();

            DesignFrequency = 0.0 * MenialOperations.M;
        }
        
        protected virtual void UpdateForNewParams()
        {
            //Change DesignFrequency.
            bool UserInputFrequency = double.TryParse(setDesignFrequency_tb.Text, out DesignFrequency);
            if (!UserInputFrequency)
            {
                MessageBox.Show("Please enter valid frequency");
                return;
            }
            DesignFrequency *= MenialOperations.M;

            //Fill out table.
            TwoPortNetworks.TwoPortNetwork temp_tpn = this.Device.ExtractTwoPortNetwork(DesignFrequency);
            ThreadSafe.SetControlTextThreadSafe_uc(this, sParamsChosen_tlp.GetControlFromPosition(0, 0), temp_tpn.m(1, 1).ToString());
            ThreadSafe.SetControlTextThreadSafe_uc(this, sParamsChosen_tlp.GetControlFromPosition(0, 1), temp_tpn.m(1, 2).ToString());
            ThreadSafe.SetControlTextThreadSafe_uc(this, sParamsChosen_tlp.GetControlFromPosition(1, 0), temp_tpn.m(2, 1).ToString());
            ThreadSafe.SetControlTextThreadSafe_uc(this, sParamsChosen_tlp.GetControlFromPosition(1, 1), temp_tpn.m(2, 2).ToString());
        }
        protected virtual void loadTwoPortNetwork()
        {
            //Open and load file.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            this.Device = TwoPortNetworks.FrequencyDependentTwoPortNetwork.ReadFromFile(ofd.FileName, TwoPortNetworks.STATE.S, 50.0);

            //Update form.
            UpdateForNewParams();
        }
        private void loadTwoPortNetwork_btn_Click(object sender, EventArgs e)
        {
            this.loadTwoPortNetwork();
        }

        protected void PlotGammaFn(Func<ComplexLinearSpace, Complex[,]> gammaMapFn, Color c, int N_magGammaLS = 200, int N_angleGammaLS = 200, bool reset = true)
        {
            //Sweep and calculate.
            ComplexLinearSpace gammaLS_Sweep = new ComplexLinearSpace(
                new LinearSpace(0.0, 1.0, (int)N_magGammaLS),
                new LinearSpace(0.0, 360, (int)N_angleGammaLS)
                );
            ComplexXY gammaXY = new ComplexXY(gammaLS_Sweep, gammaMapFn);

            //Reset chart.
            if (reset)
            {
                this.smithChart.PlotImpedanceChart();
            }

            //Plot.
            this.smithChart.plotGammaSpace(gammaXY, Color.Red, 1.0);

            //Invalidate.
            this.smithChart_pb.Invalidate();
        }
        protected void PlotGammaXY(ComplexXY gammaXY, Color c, bool reset = true)
        {
            //Reset chart.
            if (reset)
            {
                this.smithChart.PlotImpedanceChart();
            }

            //Plot.
            this.smithChart.plotGammaSpace(gammaXY, c, 1.0);

            //Invalidate.
            this.smithChart_pb.Invalidate();
        }
    }
}
