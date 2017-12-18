using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microwave
{
    public partial class SmithChartForm : Form
    {
        SmithChart smithChart;

        TwoPortNetworks.FrequencyDependentTwoPortNetwork BiasedBJT;
        TwoPortNetworks.TwoPortNetwork BiasedBJTAtDesignFrequency;
        Complex maximizing_gammaL;
        double DesignFrequency;

        public SmithChartForm()
        {
            InitializeComponent();

            smithChart = new SmithChart(50.0);

            smithChart_pb.Image = smithChart.graph;
            smithChart_pb.BringToFront();
            smithChart_pb.Show();

            DesignFrequency = 0.0 * MenialOperations.M;
        }

        private void SmithChartForm_Load(object sender, EventArgs e)
        {
        }
        
        private void loadTwoPortNetwork_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            BiasedBJT = TwoPortNetworks.FrequencyDependentTwoPortNetwork.ReadFromFile(ofd.FileName, TwoPortNetworks.STATE.S, 50.0);

            UpdateForDesignFrequencyChange();
        }
        private void saveSmithChart_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.ShowDialog();
        }

        private void UpdateForDesignFrequencyChange()
        {
            //Change DesignFrequency variable.
            bool UserInputFrequency = double.TryParse(setDesignFrequency_tb.Text, out DesignFrequency);
            if (!UserInputFrequency)
            {
                MessageBox.Show("Please enter valid frequency");
                return;
            }
            DesignFrequency *= MenialOperations.M;

            //Fill out table.
            BiasedBJTAtDesignFrequency = BiasedBJT.ExtractTwoPortNetwork(DesignFrequency);
            ThreadSafe.SetControlTextThreadSafe_f(this, sParamsChosen_tlp.GetControlFromPosition(0, 0), BiasedBJTAtDesignFrequency.m(1,1).ToString());
            ThreadSafe.SetControlTextThreadSafe_f(this, sParamsChosen_tlp.GetControlFromPosition(0, 1), BiasedBJTAtDesignFrequency.m(1,2).ToString());
            ThreadSafe.SetControlTextThreadSafe_f(this, sParamsChosen_tlp.GetControlFromPosition(1, 0), BiasedBJTAtDesignFrequency.m(2,1).ToString());
            ThreadSafe.SetControlTextThreadSafe_f(this, sParamsChosen_tlp.GetControlFromPosition(1, 1), BiasedBJTAtDesignFrequency.m(2,2).ToString());

            //So now we have the right two-port network. It's the one at our design-freq of course.
            //But we're interested in mag gammaIN wrt gammaL.

            //You can make this be a scalarField2D that takes in gammaL.real and gammaL.imag, then outputs gammaIN.magnitude.
            //Then you can do the Func<> and Fill() that way and get the whole .csv.
            //Alternatively you can go with the contour plot, which this is not.
            //But luckily it's not much of a change to go.

            //Sweep and calculate.
            double maxMagnitude = 0;
            double minMagnitude = double.MaxValue;
            ComplexLinearSpace gammaL_Sweep = new ComplexLinearSpace(
                new LinearSpace(0.0, 1.0, (int)200),
                new LinearSpace(0.0, 2*Math.PI, (int)200)
                );
            Complex[,] gammaIN_Sweep = new Complex[gammaL_Sweep.Mag.N, gammaL_Sweep.Phase.N];
            for (int mag_ind = 0; mag_ind < gammaL_Sweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaL_Sweep.Phase.N; phase_ind++)
                {
                    Complex gammaL_Current = MenialOperations.complex_magphase(gammaL_Sweep.Mag.v[mag_ind], gammaL_Sweep.Phase.v[phase_ind], false);
                    
                    gammaIN_Sweep[mag_ind, phase_ind] = MenialOperations.gamma_IN(BiasedBJTAtDesignFrequency.p, gammaL_Current);
                    if (gammaIN_Sweep[mag_ind,phase_ind].Magnitude > maxMagnitude)
                    {
                        maxMagnitude = gammaIN_Sweep[mag_ind, phase_ind].Magnitude;
                        maximizing_gammaL = gammaL_Current;
                        Debug.WriteLine("Max magnitude of " + maxMagnitude + " at " + gammaL_Current);
                    }
                    if (gammaIN_Sweep[mag_ind, phase_ind].Magnitude < minMagnitude)
                    {
                        minMagnitude = gammaIN_Sweep[mag_ind, phase_ind].Magnitude;
                        Debug.WriteLine("Min magnitude of " + minMagnitude + " at " + gammaL_Current);
                    }
                }
            }

            maxMagnitude = Math.Log10(maxMagnitude);
            minMagnitude = Math.Log10(minMagnitude);

            //Plot.
            for (int mag_ind = 0; mag_ind < gammaL_Sweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaL_Sweep.Phase.N; phase_ind++)
                {
                    Complex gammaL_Current = MenialOperations.complex_magphase(gammaL_Sweep.Mag.v[mag_ind], gammaL_Sweep.Phase.v[phase_ind], false);

                    if (gammaIN_Sweep[mag_ind, phase_ind].Magnitude > 1)
                    {
                        int colorFactor = (int)((Math.Log10(gammaIN_Sweep[mag_ind, phase_ind].Magnitude) - minMagnitude) / (maxMagnitude - minMagnitude) * 255);
                        smithChart.plotGamma(gammaL_Current, Color.FromArgb(255, colorFactor, 255 - colorFactor, 0));
                    }
                }
            }

            smithChart_pb.Invalidate();
        }
        
        private void smithChart_pb_MouseClick(object sender, MouseEventArgs e)
        {
            Complex gammaL = smithChart.imagecoord_to_gammacoord(e.X, e.Y);
            CalculateOscillatorInForm(gammaL);
        }
        private void pickGreatestGammaIN_btn_Click(object sender, EventArgs e)
        {
            CalculateOscillatorInForm(maximizing_gammaL);
        }
        private void CalculateOscillatorInForm(Complex gammaL)
        {
            //int gx = smithChart.gammacoord_to_imagecoord(g.Real, true);
            //int gy = smithChart.gammacoord_to_imagecoord(g.Imaginary, false);
            //MessageBox.Show("You clicked at " + e.X + ", " + e.Y + ", which is " + g.Real + ", " + g.Imaginary + ", which converts back to " + gx + ", " + gy);

            //So clicking should give you the whole rundown on the rest of the circuit.
            Complex Z_L = Conversions.GammaToZ(gammaL, BiasedBJT.Zo);
            Complex gammaIN = MenialOperations.gamma_IN(BiasedBJTAtDesignFrequency.p, gammaL);
            Complex Zin = Conversions.GammaToZ(gammaIN, BiasedBJT.Zo);
            Complex Z_s = new Complex(Zin.Real / -3, -Zin.Imaginary);
            Complex gammaS = Conversions.ZtoGamma(Z_s, BiasedBJT.Zo);
            ThreadSafe.SetControlTextThreadSafe_f(this,
                completeCircuitDesign_tb,
                "Desired Gamma In /// Zin: " + MenialOperations.ComplexToStringMagPhase(gammaIN) + " /// " + Zin + Environment.NewLine + Environment.NewLine +
                "Source Z: " + Z_s + " (" + Conversions.XtoComponent(Z_s.Imaginary, DesignFrequency) + ")" + Environment.NewLine + Environment.NewLine +
                "Load Z: " + Z_L + " (" + Conversions.XtoComponent(Z_L.Imaginary, DesignFrequency) + ")"
                );

            //For every other frequency, calculate the gammaIN and gammaOUT with this network.
            //For every other frequency.
            ThreadSafe.SetControlTextThreadSafe_f(this,
                otherOscillationModes_tb, "");
            for (int n = 0; n < BiasedBJT.freq.Count; n++)
            {
                //Calculate gammaIN and gammaOUT.
                Complex gammaIN_otherFrequency = MenialOperations.gamma_IN(BiasedBJT.p[n], gammaL);
                Complex gammaOUT_otherFrequency = MenialOperations.gamma_OUT(BiasedBJT.p[n], gammaS);

                //If any magnitudes are greater than one.
                if (gammaIN_otherFrequency.Magnitude > 1 || gammaOUT_otherFrequency.Magnitude > 1)
                {
                    //Print them.
                    ThreadSafe.AppendControlTextThreadSafe_f(this,
                        otherOscillationModes_tb,
                        BiasedBJT.freq[n] + ", " +
                        gammaIN_otherFrequency.Magnitude + ", " +
                        gammaOUT_otherFrequency.Magnitude + Environment.NewLine
                        );
                }
            }
        }
    }

}
