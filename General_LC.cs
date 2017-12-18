using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Microwave
{
    public partial class General_LC : Form
    {
        public General_LC()
        {
            InitializeComponent();
        }
        
        private void calculateZs_btn_Click(object sender, EventArgs e)
        {
            //Parse inputs.
            Complex V_A1 = MenialOperations.ComplexFromString(Va1_tb.Text);
            Complex Z_L1 = MenialOperations.ComplexFromString(Rl1_tb.Text);
            Complex V_A2 = MenialOperations.ComplexFromString(Va2_tb.Text);
            Complex Z_L2 = MenialOperations.ComplexFromString(Rl2_tb.Text);
            
            MessageBox.Show(V_A1.ToString());
            MessageBox.Show(Z_L1.ToString());
            MessageBox.Show(V_A2.ToString());
            MessageBox.Show(Z_L2.ToString());
            
            Double freq;
            Double.TryParse(frequency_tb.Text, out freq);

            //Pass to calculation.
            Complex Z_S = (V_A2 - V_A1) / ((V_A1 / Z_L1) - (V_A2 / Z_L2));
            MessageBox.Show(Z_S.ToString());
            Complex Z_S_Conj = new Complex(Z_S.Real, -Z_S.Imaginary);
            Complex V_S_Ampl = (V_A2 / Z_L2) * Z_S + V_A2;
            
            //Populate textboxes.
            SetControlTextThreadSafe(Zs_tb,              Z_S.ToString());
            SetControlTextThreadSafe(ZsComponent_tb,     Z_S.Real + ", " + Conversions.XtoComponent(Z_S.Imaginary, freq));
            SetControlTextThreadSafe(ZsConj_tb,          Z_S_Conj.ToString());
            SetControlTextThreadSafe(ZsConjComponent_tb, Z_S_Conj.Real + ", " + Conversions.XtoComponent(Z_S_Conj.Imaginary, freq));
            SetControlTextThreadSafe(VsAmpl_tb,          V_S_Ampl.Magnitude + "<" + V_S_Ampl.Phase);
        }

        #region Thread-safe calls.
        private delegate void SetControlTextCallback(Control c, string s);
        private void SetControlTextThreadSafe(Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new SetControlTextCallback(SetControlTextThreadSafe);
                this.Invoke(d, new object[] { c, s });
            }
            else
            {
                c.Text = s;
            }
        }
        private delegate void AppendControlTextCallback(Control c, string s);
        private void AppendControlTextThreadSafe(Control c, string s)
        {
            if (c.InvokeRequired)
            {
                var d = new AppendControlTextCallback(AppendControlTextThreadSafe);
                this.Invoke(d, new object[] { c, s });
            }
            else
            {
                c.Text += s;
            }
        }

        #endregion

        private void calculateLmatch_btn_Click(object sender, EventArgs e)
        {
            //.
            Complex ZA = MenialOperations.ComplexFromString(CalculateLMatch_ZA_tb.Text);
            Complex ZB = MenialOperations.ComplexFromString(CalculateLMatch_ZB_tb.Text);
            bool isLP = lowpass_rb.Checked;
            double freq = Convert.ToDouble(CalculateLmatch_frequency_tb.Text);
            double Zo = Convert.ToDouble(CalculateLMatch_Zo_tb.Text);

            //Calculate.
            double L;
            double C;
            bool seriesNextToLoad = OnePortNetwork.Lmatch(ZA, ZB, isLP, freq, Zo, out L, out C);

            //Show.
            ThreadSafe.SetControlTextThreadSafe_f(this, CalculateLmatch_Output_tb,
                L.ToString() + " H, " + Environment.NewLine +
                ((seriesNextToLoad == isLP) ? "Next to ZA, " : "Next to ZB, ") + Environment.NewLine + //Series next to load XOR isLP.
                (isLP ? "Series, " : "Shunt, ") + Environment.NewLine
                );
            ThreadSafe.SetControlTextThreadSafe_f(this, CalculateLmatch_Output_tb,
                C.ToString() + " F," + Environment.NewLine +
                ((seriesNextToLoad != isLP) ? "Next to ZA, " : "Next to ZB, ") + Environment.NewLine + //Series next to load XNOR isLP.
                (!isLP ? "Series, " : "Shunt, ")
                );

            //Draw ind and cap connected on screen.
        }
    }
}
