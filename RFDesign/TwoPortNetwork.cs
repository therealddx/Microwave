using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microwave;

namespace TwoPortNetworks
{
    public enum STATE
    {
        S,
        Z,
    }

    public interface ITwoPortNetwork
    {
        void toZ();
        void toS();
    }
    public class TwoPortNetwork : ITwoPortNetwork
    {
        public Complex[,] p;
        double Zo;
        public STATE state;
        List<Image> Layers;

        private TwoPortNetwork()
        {

        }
        #region Constructors.
        public TwoPortNetwork(Complex v11, Complex v12, Complex v21, Complex v22, STATE d_state, double d_Zo)
        {
            this.p = new Complex[2, 2];
                 
            this.p[0, 0] = v11;
            this.p[0, 1] = v12;
            this.p[1, 0] = v21;
            this.p[1, 1] = v22;

            this.state = d_state;
            this.Zo = d_Zo;
        }
        public TwoPortNetwork(Complex[,] d_parameters, STATE d_state, double d_Zo = 50.0)
        {
            this. p= new Complex[2, 2];
            this.p[0, 0] = d_parameters[0, 0];
            this.p[1, 0] = d_parameters[1, 0];
            this.p[0, 1] = d_parameters[0, 1];
            this.p[1, 1] = d_parameters[1, 1];

            this.state = d_state;
            this.Zo = d_Zo;
        }
        #endregion

        #region Conversions.
        public void toZ()
        {
            if (this.state == STATE.S) //S to Z Param.
            {
                Complex s11 = this.m(1, 1);
                Complex s12 = this.m(1, 2);
                Complex s21 = this.m(2, 1);
                Complex s22 = this.m(2, 2);
                Complex det = (1 - s11) * (1 - s22) - s12 * s21;

                Complex z11 = ((1 + s11) * (1 - s22) + s12 * s21) / det * this.Zo;
                Complex z12 = 2 * s12 / det * this.Zo;
                Complex z21 = 2 * s21 / det * this.Zo;
                Complex z22 = ((1 - s11) * (1 + s22) + s12 * s21) / det * this.Zo;
                
                this.p[0, 0] = z11; //11
                this.p[0, 1] = z12; //12
                this.p[1, 0] = z21; //21
                this.p[1, 1] = z22; //22
            }
            this.state = STATE.Z;
        }
        public void toS()
        {
            if (this.state == STATE.Z) //Z to S Param.
            {
                Complex z11 = this.m(1, 1);
                Complex z12 = this.m(1, 2);
                Complex z21 = this.m(2, 1);
                Complex z22 = this.m(2, 2);
                Complex det = (z11 + this.Zo) * (z22 + this.Zo) - z12 * z21;

                Complex s11 = ((z11 - this.Zo) * (z22 + this.Zo) - z12 * z21) / det;
                Complex s12 = 2 * this.Zo * z12 / det;
                Complex s21 = 2 * this.Zo * z21 / det;
                Complex s22 = ((z11 + this.Zo) * (z22 - this.Zo) - z12 * z21) / det;

                this.p[0, 0] = s11; //11
                this.p[0, 1] = s12; //12
                this.p[1, 0] = s21; //21
                this.p[1, 1] = s22; //22
            }
            this.state = STATE.S;
        }
        #endregion

        #region 0-dimensional calculations
        public Complex det()
        {
            return this.p[0, 0] * this.p[1, 1] - this.p[0, 1] * this.p[1, 0];
        }
        public double mu()
        {
            double numer = 1.0 - Math.Pow(Complex.Abs(this.p[0,0]), 2);
            double denom = Complex.Abs(this.p[1,1] - this.det() * Complex.Conjugate(this.p[0,0])) + Complex.Abs(this.p[0,1] * this.p[1,0]);
            
            return numer / denom;
        }
        public Complex gamma_IN(Complex gamma_l)
        {
            return this.p[0,0] + (this.p[0,1] * this.p[1,0] * gamma_l) / (1 - this.p[1,1] * gamma_l);
        }
        public Complex gamma_OUT(Complex gamma_s)
        {
            return this.p[1,1] + (this.p[0,1] * this.p[1,0] * gamma_s) / (1 - this.p[0,0] * gamma_s);
        }
        public bool CalcStablityCircle(out Complex C, out double R)
        {
            //1) Calculate (C,R).
            Complex d = this.det();

            Complex c_numer = Complex.Conjugate((this.p[1,1] - d * Complex.Conjugate(this.p[0,0])));
            Complex c_denom = this.p[1,1].Magnitude * this.p[1,1].Magnitude - d.Magnitude * d.Magnitude;
            C = c_numer / c_denom;

            Complex r_numer = Complex.Abs(this.p[0,1] * this.p[1,0]);
            Complex r_denom = Complex.Abs(this.p[1,1].Magnitude * this.p[1,1].Magnitude - d.Magnitude * d.Magnitude);
            R = r_numer.Real / r_denom.Real;

            //2) Determine where the stability is.
            //Set Gamma_L = (0,0) and calculate gammaIn.
            Complex gammaL_Test = new Complex(0, 0);
            Complex gammaIn_Test = this.gamma_IN(gammaL_Test);

            //four options.
            //gammaL is inside stability circle and gammaIn.Magnitude > 1.
            //gammaL is inside stability circle and gammaIn.Magnitude < 1. 

            //gammaL is outside stability circle and gammaIn.Magnitude < 1. 
            //gammaL is outside stability circle and gammaIn.Magnitude < 1. 

            //gammaL is inside the stability circle if (abs(gammaL - center)) < radius.

            bool gammaLInsideStabilityCircle = Complex.Abs(gammaL_Test - C) < R;
            bool isStableInsideCircle;
            if (gammaLInsideStabilityCircle)
            {
                if (gammaIn_Test.Magnitude > 1)
                {
                    isStableInsideCircle = false;
                    //unstable inside circle.
                }
                else
                {
                    isStableInsideCircle = true;
                    //stable inside circle
                }
            }
            else
            {
                if (gammaIn_Test.Magnitude > 1)
                {
                    isStableInsideCircle = true;
                    //stbale inside circle.
                }
                else
                {
                    isStableInsideCircle = false;
                    //unstable inside circle
                }
            }
            return isStableInsideCircle;
        }
        #endregion

        #region GammaOUT(GammaS) or GammaIN(GammaL)
        public Complex[,] CalculateGammaIN(ComplexLinearSpace gammaL_ToSweep, out double MaxMagnitude, out double MinMagnitude)
        {
            MaxMagnitude = double.MinValue;
            MinMagnitude = double.MaxValue;

            Complex[,] gammaIN_Sweep = new Complex[gammaL_ToSweep.Mag.N, gammaL_ToSweep.Phase.N];
            for (int mag_ind = 0; mag_ind  < gammaL_ToSweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaL_ToSweep.Phase.N; phase_ind++)
                {
                    Complex currentGammaL = MenialOperations.ComplexFromMagPhase(gammaL_ToSweep.Mag.v[mag_ind], gammaL_ToSweep.Phase.v[phase_ind], true);
                    gammaIN_Sweep[mag_ind, phase_ind] = this.gamma_IN(currentGammaL);

                    if (gammaIN_Sweep[mag_ind, phase_ind].Magnitude > MaxMagnitude)
                    {
                        MaxMagnitude = gammaIN_Sweep[mag_ind,phase_ind].Magnitude;
                    }
                    else if (gammaIN_Sweep[mag_ind, phase_ind].Magnitude < MinMagnitude)
                    {
                       MinMagnitude = gammaIN_Sweep[mag_ind, phase_ind].Magnitude;
                    }
                }
            }
            return gammaIN_Sweep;
        }
        public Complex[,] CalculateGammaIN(ComplexLinearSpace gammaL_Sweep)
        {
            Complex[,] gammaIN_Sweep = new Complex[gammaL_Sweep.Mag.N, gammaL_Sweep.Phase.N];
            for (int mag_ind = 0; mag_ind < gammaL_Sweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaL_Sweep.Phase.N; phase_ind++)
                {
                    Complex currentGammaL = MenialOperations.ComplexFromMagPhase(gammaL_Sweep.Mag.v[mag_ind], gammaL_Sweep.Phase.v[phase_ind], true);
                    gammaIN_Sweep[mag_ind, phase_ind] = this.gamma_IN(currentGammaL);
                }
            }
            return gammaIN_Sweep;
        }

        public Complex[,] CalculateGammaOUT(ComplexLinearSpace gammaS_Sweep, out double MaxMagnitude, out double MinMagnitude)
        {
            MaxMagnitude = double.MinValue;
            MinMagnitude = double.MaxValue;
            
            Complex[,] gammaOUT_Sweep = new Complex[gammaS_Sweep.Mag.N, gammaS_Sweep.Phase.N];
            for (int mag_ind = 0; mag_ind < gammaS_Sweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaS_Sweep.Phase.N; phase_ind++)
                {
                    Complex currentGammaS = MenialOperations.ComplexFromMagPhase(gammaS_Sweep.Mag.v[mag_ind], gammaS_Sweep.Phase.v[phase_ind], true);
                    gammaOUT_Sweep[mag_ind, phase_ind] = this.gamma_OUT(currentGammaS);

                    if (gammaOUT_Sweep[mag_ind, phase_ind].Magnitude > MaxMagnitude)
                    {
                        MaxMagnitude = gammaOUT_Sweep[mag_ind, phase_ind].Magnitude;
                    }
                    else if (gammaOUT_Sweep[mag_ind, phase_ind].Magnitude < MinMagnitude)
                    {
                        MinMagnitude = gammaOUT_Sweep[mag_ind, phase_ind].Magnitude;
                    }
                }
            }
            return gammaOUT_Sweep;
        }
        public Complex[,] CalculateGammaOUT(ComplexLinearSpace gammaS_Sweep)
        {
            Complex[,] gammaOUT_Sweep = new Complex[gammaS_Sweep.Mag.N, gammaS_Sweep.Phase.N];
            for (int mag_ind = 0; mag_ind < gammaS_Sweep.Mag.N; mag_ind++)
            {
                for (int phase_ind = 0; phase_ind < gammaS_Sweep.Phase.N; phase_ind++)
                {
                    Complex currentGammaS = MenialOperations.ComplexFromMagPhase(gammaS_Sweep.Mag.v[mag_ind], gammaS_Sweep.Phase.v[phase_ind], true);
                    gammaOUT_Sweep[mag_ind, phase_ind] = this.gamma_OUT(currentGammaS);
                }
            }
            return gammaOUT_Sweep;
        }
        #endregion

        //Menials.
        public Complex m(int rowOneIndexed, int colOneIndexed)
        {
            return this.p[rowOneIndexed - 1, colOneIndexed - 1];
        }
        public override string ToString()
        {
            string s = "";
            s = "[";
            for (int row = 0; row < this.p.GetLength(0); row++)
            {
                for (int col = 0; col < this.p.GetLength(1); col++)
                {
                    s += this.p[row,col] + ", ";
                }
                s += "\n";
            }
            s += "]\n";
            return s;
        }
        public ITwoPortNetwork Copy()
        {
            TwoPortNetwork copy = new TwoPortNetwork();

            copy.p = new Complex[2, 2];
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    copy.p[row, col] = this.p[row, col];
                }
            }
            
            copy.state = this.state;
            copy.Zo = this.Zo;
            return copy;
        }
    }
    public class FrequencyDependentTwoPortNetwork : ITwoPortNetwork
    {
        public List<Complex[,]> p;
        public List<double> freq;
        public double Zo;
        STATE state;

        private FrequencyDependentTwoPortNetwork()
        {

        }
        public FrequencyDependentTwoPortNetwork(List<Complex[,]> d_parameters, List<double> d_freq, double d_Zo)
        {
            if (d_parameters.Count == d_freq.Count)
            {
                this.p = d_parameters;
                this.freq = d_freq;
                this.Zo = d_Zo;
            }
            else
            {
                throw new Exception("Failure to initialize Frequency-Dependent Two-Port Network");
            }
        }

        public void toZ()
        {
            if (this.state == STATE.S) //Conversion from S to Z Param.
            {
                //For each frequency to mind.
                for (int freq_ind = 0; freq_ind < this.freq.Count; freq_ind++)
                {
                    //Copy those parameters.
                    Complex[,] temp_params = MenialOperations.CopyMatrix<Complex>(this.p[freq_ind]);

                    //Make a new temp object w/those parmeters.
                    TwoPortNetwork temp_tpn = new TwoPortNetwork(temp_params, this.state, this.Zo);

                    //Convert that new temp object (TwoPortNetwork at this frequency) to new parameters.
                    temp_tpn.toZ();

                    //Reassign into this object.
                    this.p[freq_ind] = MenialOperations.CopyMatrix<Complex>(temp_tpn.p);
                }
            }
            this.state = STATE.Z;
        }
        public void toS()
        {
            if (this.state == STATE.Z) //Conversion from Z to S Param.
            {
                for (int freq_ind = 0; freq_ind < this.freq.Count; freq_ind++)
                {
                    //Copy those parameters.
                    Complex[,] temp_params = MenialOperations.CopyMatrix<Complex>(this.p[freq_ind]);

                    //Make a new temp object w/those parmeters.
                    TwoPortNetwork temp_tpn = new TwoPortNetwork(temp_params, this.state, this.Zo);

                    //Convert that new temp object (TwoPortNetwork at this frequency) to new parameters.
                    temp_tpn.toS();

                    //Reassign into this object.
                    this.p[freq_ind] = MenialOperations.CopyMatrix<Complex>(temp_tpn.p);
                }
            }
            this.state = STATE.S;
        }

        public double ExtractTwoPortNetwork(double d_freq, out TwoPortNetwork tpn)
        {
            //Search for frequency that this.p holds which is closest to desired frequency being queried.
            //Return closest frequency found.

            double min_error = double.MaxValue;
            int min_error_ind = -1;

            //For each in this.freq.
            for (int n = 0; n < this.freq.Count; n++)
            {
                //If this freq is the closest we've seen to the desired frequency, move on.
                if (Math.Abs(this.freq[n] - d_freq) < min_error)
                {
                    min_error = Math.Abs(this.freq[n] - d_freq);
                    min_error_ind = n;
                }
            }
            tpn = new TwoPortNetwork(this.p[min_error_ind], this.state, this.Zo);

            return this.freq[min_error_ind];
        }
        public TwoPortNetwork ExtractTwoPortNetwork(int freq_ind)
        {
            return new TwoPortNetwork(this.p[freq_ind], this.state, this.Zo);
        }

        public static FrequencyDependentTwoPortNetwork ReadFromFile_LTSpice(string filePath, TwoPortNetworks.STATE state, double Zo)
        {
            Regex singleValueRegex = new Regex(@"-?\d\.\d+e(-|\+)\d+");
            Match singleValueMatch;

            List<double> rowvals = new List<double>();
            List<double> freq = new List<double>();
            List<Complex[,]> parameters = new List<Complex[,]>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string header = sr.ReadLine();
                header = Regex.Replace(header, @"\s", "");
                if (!Regex.IsMatch(header, @"Freq\.S11\(v\d\)S12\(v\d\)S21\(v\d\)S22\(v\d\)"))
                {
                    MessageBox.Show(header + " does not match as it should.");
                    throw new Exception(
                        "Error in loading TwoPortNetwork from file. " + Environment.NewLine + "" +
                        "Please ensure that only S11, S12, S21, and S22 are selected for one source-load combination have been exported to this file."
                        );
                }

                //Read.
                while (!sr.EndOfStream)
                {
                    string curLine = sr.ReadLine();
                    singleValueMatch = singleValueRegex.Match(curLine);

                    //Collect double values.
                    while (singleValueMatch.Success)
                    {
                        string num = singleValueMatch.Value.Substring(0, singleValueMatch.Value.IndexOf('e'));
                        string exp = singleValueMatch.Value.Substring(singleValueMatch.Value.IndexOf('e') + 1);
                        double num_d; double exp_d;
                        double.TryParse(num, out num_d);
                        double.TryParse(exp, out exp_d);

                        rowvals.Add(num_d * Math.Pow(10, exp_d));

                        singleValueMatch = singleValueMatch.NextMatch();
                    }

                    //Assign double values. //S11 S12 S21 S22. MANDATORY ORDER.
                    Complex s11 = new Complex(rowvals[1], rowvals[2]);
                    Complex s12 = new Complex(rowvals[3], rowvals[4]);
                    Complex s21 = new Complex(rowvals[5], rowvals[6]);
                    Complex s22 = new Complex(rowvals[7], rowvals[8]);

                    freq.Add(rowvals[0]);
                    parameters.Add(new Complex[,] {
                        {s11, s12 },
                        {s21, s22 }
                    });
                    
                    rowvals.Clear();
                }
            }

            return new FrequencyDependentTwoPortNetwork(parameters, freq, Zo);
        }
    }
}
