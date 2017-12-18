using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Microwave
{
    class Program
    {
        #region Deprecated
            /*
        static void calc_PA_082717()
        {
            double freq = 52 * Math.Pow(10, 6);
            double Zo = 50;

            //my trans s-params at 52MHz
            //Complex s11 = MenialOperations.complex_magphase(0.72, -116, true);
            //Complex s12 = MenialOperations.complex_magphase(0.03, 57  , true);
            //Complex s21 = MenialOperations.complex_magphase(2.60, 76  , true);
            //Complex s22 = MenialOperations.complex_magphase(0.73, -54 , true);
            Complex s11 = MenialOperations.complex_magphase(0.72, -116, true);
            Complex s12 = MenialOperations.complex_magphase(0.03, 57  , true);
            Complex s21 = MenialOperations.complex_magphase(2.60, 76  , true);
            Complex s22 = MenialOperations.complex_magphase(0.73, -54 , true);
            TwoPortNetworks.TwoPortNetwork tpn = new TwoPortNetworks.TwoPortNetwork(s11, s12, s21, s22, TwoPortNetworks.STATE.S, 50.0);
            //Complex s11 MenialOperations.= new Complex(0.93569, -0.048077);
            //Complex s12 = new Complex(0, 0);
            //Complex s21 = new Complex(-3, 0.125);
            //Complex s22 = new Complex(0.95, -0.1037);

            //Solve amplifier for max gain.
            Complex gamma_s = PAdesign.gamma_S(tpn);
            Complex gamma_l = PAdesign.gamma_L(tpn);
            Complex Z_s = Conversions.GammaToZ(gamma_s, Zo);
            Complex Z_l = Conversions.GammaToZ(gamma_l, Zo);
            Complex Z_ANT = new Complex(36.5, 21.25); //Zin for 1/4-wave monopole
            double C_ANT = Conversions.XtoC(Z_ANT.Imaginary, freq);
            Complex gamma_ANT = Conversions.ZtoGamma(Z_ANT, Zo);
            double Zg = Zo;

            //Compute said gain and gammas.
            double GS = PAdesign.G_S(tpn);
            double G0 = PAdesign.G_0(tpn);
            double GL = PAdesign.G_L(tpn);
            double GTotal = PAdesign.G_total(tpn);
            Console.WriteLine("mu is: " + tpn.mu());
            Console.WriteLine("gamma_s is: " + gamma_s.Magnitude + " " + MenialOperations.radtodeg(gamma_s.Phase) + "[" + Z_s + " ohm]");
            Console.WriteLine("gamma_l is: " + gamma_l.Magnitude + " " + MenialOperations.radtodeg(gamma_l.Phase) + "[" + Z_l + " ohm]");
            Console.WriteLine("GS is: " + GS + " (" + 10 * Math.Log10(GS) + ")");
            Console.WriteLine("G0 is: " + G0 + " (" + 10 * Math.Log10(G0) + ")");
            Console.WriteLine("GL is: " + GL + " (" + 10 * Math.Log10(GL) + ")");
            Console.WriteLine("GTotal is: " + GTotal + " (" + 10 * Math.Log10(GTotal) + ")");

            Console.WriteLine("\nSOURCE MATCH CALCULATION:");
            //Compute L-match for source.
            double Xp_s = 0; double Xs_s = 0;
            MenialOperations.Lmatch(Zg, Z_s.Real, out Xp_s, out Xs_s);
            double Cm_s = Conversions.XtoC(Xs_s, freq);
            double Lm_s = Conversions.XtoL(Xp_s, freq);
            //Console.WriteLine("Xp_s is: " + Xp_s);//L-match for source
            Console.WriteLine("Lm_s is: " + Lm_s);//L-match for source
            //Console.WriteLine("Xs_s is: " + Xs_s);//L-match for source
            Console.WriteLine("Cm_s is: " + Cm_s);//L-match for source

            Console.WriteLine("\nSOURCE SLC CALCULATION:");
            //Compute SLC for source.
            double Cs_s = Math.Pow(10, -9);
            double Ls_s = Conversions.XtoL(Z_s.Imaginary - Conversions.CtoX(Cs_s, freq), freq);
            Console.WriteLine("Cs_s is: " + Cs_s);
            Console.WriteLine("Ls_s is: " + Ls_s);

            Console.WriteLine("\nLOAD MATCH CALCULATION:");
            //Compute L-match for load.
            double Xp_l = 0; double Xs_l = 0;
            MenialOperations.Lmatch(Z_ANT.Real, Z_l.Real, out Xp_l, out Xs_l);
            double Cm_l = Conversions.XtoC(Xs_l, freq);
            double Lm_l = Conversions.XtoL(Xp_l, freq);
            //Console.WriteLine("Xp_l is: " + Xp_l);//L-match for load
            Console.WriteLine("Lm_l is: " + Lm_l);//L-match for load
            //Console.WriteLine("Xs_l is: " + Xs_l);//L-match for load
            Console.WriteLine("Cm_l is: " + Cm_l + "<-----------COMBINED");//L-match for load
            Console.WriteLine("C_ANT is: " + C_ANT + "<-----------COMBINED");//Resonate out antenna
            Console.WriteLine("C_ANT // Cm_l is: " + Cm_l * C_ANT / (Cm_l + C_ANT));

            Console.WriteLine("\nLOAD SLC CALCULATION:");
            //Compute SLC for load.
            double Cs_l = Math.Pow(10, -9);
            double Ls_l = Conversions.XtoL(Z_l.Imaginary - Conversions.CtoX(Cs_l, freq), freq);
            Console.WriteLine("Cs_l is: " + Cs_l);
            Console.WriteLine("Ls_l is: " + Ls_l);

            Console.ReadKey();

            #region Other Params
            
            //y11 = 0.000652 + j0.000513
            //y12 = 0
            //y21 = 0.0317 + j0.00115
            //y22 = 0.000455 + j0.00109

            //my trans s-params at 3GHz - stable, yup
            //Complex s11 = new Complex(0.3271, -0.3271);
            //Complex s12 = new Complex(5.7/13.5, 7/13.5);
            //Complex s21 = new Complex(2.2/15.6, 2.2/10.5);
            //Complex s22 = new Complex(6.8/17.5, -6/13.8);

            //example trans params at 4GHz
            //Complex s11 = complex_magphase(0.72, -116);
            //Complex s12 = complex_magphase(0.03, 57);
            //Complex s21 = complex_magphase(2.60, 76);
            //Complex s22 = complex_magphase(0.73, -54);
            #endregion

        }
        static void calc_culpitts_082717(double freq)
        {
            //Calculate C1 and C2 given frequency and L for Colpitts oscillator
            const double beta = 80;
            double omega_0 = 2 * Math.PI * freq;

            double L3 = 750 * Math.Pow(10, -9);
            double C1 = ((1 / beta) + 1) / (Math.Pow(omega_0, 2) * L3);
            double C2 = beta * C1;

            Console.WriteLine("C1 is: " + C1);
            Console.WriteLine("C2 is: " + C2);
            Console.WriteLine("L3 is: " + L3);
        }
        static void calc_LPF_090717(double wc, double Zo)
        {
            //Gives three-pole butterworth at wc and Zo.

            double C1 = 2.0 / (Zo * wc);
            double L2 = (1.0 * Zo) / (wc);
            double C3 = (1.0) / (50 * wc);

            Console.WriteLine("C1 is: " + C1);
            Console.WriteLine("L2 is: " + L2);
            Console.WriteLine("C3 is: " + C3);
        }
        static void pareto_VCO_092017()
        {
            double C3_A_MIN = 1.0 * MenialOperations.p;
            double C3_A_MAX = 1001.0 * MenialOperations.p;
            double dC3_A = (C3_A_MAX - C3_A_MIN) / 1000;
            double C3_B_MIN = 1.0 * MenialOperations.p;
            double C3_B_MAX = 1001.0 * MenialOperations.p;
            double dC3_B = (C3_B_MAX - C3_B_MIN) / 1000;

            //First code block: Print scalar field over ranges.
            
            //ScalarField2D sf = new ScalarField2D(
            //    PutThisInScalarField2D,
            //
            //    new LinearSpace(
            //        C3_A_MIN,
            //        C3_A_MAX,
            //        dC3_A
            //        ),
            //    
            //    new LinearSpace(
            //        C3_B_MIN,
            //        C3_B_MAX,
            //        dC3_B
            //        ));
            //Debug.WriteLine(sf.ToString());
            //using (StreamWriter sw = new StreamWriter("C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\ParetoOutput.csv"))
            //{
            //    sw.WriteLine(sf.ToString());
            //}
            //
            //double C3A_opt = double.MinValue;
            //double C3B_opt = double.MinValue;
            //double f_opt = sf.findMinimum(out C3A_opt, out C3B_opt);
            //XY freq_opt = CalcHartleyVoltageResponse(C3A_opt, C3B_opt);
            //ExportData.AppendXYtoCSV("C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\ParetoOptimal.csv", freq_opt);
            //ExportData.AppendXYtoCSV("C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\dParetoOptimal.csv", 
            //    NumericalMethods.Derivative(NumericalMethods.Derivative(freq_opt)));
            //
            //Debug.WriteLine("f_opt == (C3A_OPT, C3B_OPT) " + f_opt + " == (" + C3A_opt + ", " + C3B_opt + ")");
            

            //Second code block: Demonstrate that Pareto converges to lowest gradient from any random point.
            
            //ParetoVariable PV_C_3A = new ParetoVariable(Math.Pow(10,-20), C3_A_MIN, C3_A_MAX, dC3_A);
            //ParetoVariable PV_C_3B = new ParetoVariable(Math.Pow(10,-22), C3_B_MIN, C3_B_MAX, dC3_B);
            //Debug.WriteLine("Starting ParetoSolve at (PV_C_3A, PV_C_3B) == " + "(" + PV_C_3A.val + ", " + PV_C_3B.val + ")");
            //ParetoResultAnalyzer PRA_Lin = new ParetoResultAnalyzer(f_Lin, 1.0);
            //ParetoResultAnalyzer PRA_BW = new ParetoResultAnalyzer(f_BW,   1.0);
            //string outPath = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\ParetoOutput.csv";
            //Pareto.FindSolution2D(CalcHartleyVoltageResponse, PRA_Lin, PRA_BW, PV_C_3A, PV_C_3B, 1000, outPath);
            
            //Victory lap: Calculate L1 and L2 officially.
            //Given: C3A_OPT = 4.5E-11 and C3B_OPT = 6.2E-11

            double C3A_OPT = 4.5 * Math.Pow(10, -11);
            double C3B_OPT = 6.2 * Math.Pow(10, -11);
            XY Cj = ImportData.ReadCSVtoXY(ImportData.OutputDataPath);
            double C3 = C3B_OPT + MenialOperations.Parallel(0.5 * C3A_OPT, Cj.y[0]);
            double omega0 = 2 * Math.PI * 49.5 * Math.Pow(10, 6); //Frequency I want for voltage == 0.0.
            double beta = 80.0;

            double L1;
            double L2;
            Hartley_CwBtoL(C3, omega0, beta, out L1, out L2);

            Debug.WriteLine("Finally, (L1, L2) == " + L1 + ", " + L2);

            Console.WriteLine("done");
            Console.ReadKey();
        }
    */
        #endregion

        #region Hartley VCO Optimization
        static void Hartley_CwBtoL(double C3, double omega, double beta, out double L1, out double L2)
        {
            L2 = (1.0 / (omega * omega * C3)) / (beta + 1);
            L1 = beta * L2;
        }
        static double PutThisInScalarField2D(double x, double y)
        {
            XY omega = CalcHartleyVoltageResponse(x, y);
            return 1.0 * f_BW(omega) + 1.0 * f_Lin(omega);
        }

        /// <summary>
        /// Calculates response of Hartley oscillator with respect to change in varactor reverse bias voltage.
        /// </summary>
        /// <param name="C_3A">Capacitance that sits ON EITHER SIDE of varactor Cj.</param>
        /// <param name="C_3B">Capacitance that sits in parallel with C_3A - Cj - C_3A series combination.</param>
        /// <returns></returns>
        static XY CalcHartleyVoltageResponse(double C_3A, double C_3B)
        {
            XY Cj = ImportData.ReadCSVtoXY(ImportData.OutputDataPath);

            XY freq = new XY(Cj.x);
            XY C3 = new XY(Cj.x);

            //This block of variables is necessary for initializing inductance.
            //Inductance is initialized to resonate with first-calculated C3 value at 49.5 MHz.
            double L1;
            double L2;
            double omega0 = 2 * Math.PI * 49.5 * Math.Pow(10, 6); //Frequency I want for voltage == 0.0.
            double beta = 80.0;
            for (int n = 0; n < freq.N; n++)
            {
                C3.y[n] = C_3B + MenialOperations.Parallel(0.5 * C_3A, Cj.y[n]);
                Hartley_CwBtoL(C3.y[0], omega0, beta, out L1, out L2);
                freq.y[n] = Math.Pow(C3.y[n] * (L1 + L2), -0.50) / (2.0 * Math.PI);

                //Debug.WriteLine("Run " + n + ": " + C3.y[n] + " " + L1 + " " + L2 + " " + freq.y[n]);
            }

            ExportData.WriteXYtoCSV("C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\Microwave\\Data\\hartley.csv", freq);
            return freq;
        }
        static double f_BW(XY vec)
        {
            double f = 54.5 * Math.Pow(10, 6);
            return Math.Pow(vec.y[vec.N - 1] / f - 1.0, 2);

            //return (MenialOperations.last_minus_first(vec) - 5.0 * Math.Pow(10, 6)) * (MenialOperations.last_minus_first(vec) - 5.0 * Math.Pow(10, 6));
        }
        static double f_Lin(XY vec)
        {
            return Math.Pow((NumericalMethods.CorrelationCoefficient(vec) - 1.0), 2);
            //return 1.0 / NumericalMethods.CorrelationCoefficient(vec);
        }
        #endregion
        
        //One-off fn for v-div calculation using AP5100.
        static double calcR2(double desiredVout, double R1)
        {
            double divBy = (desiredVout / 0.81 - 1);
            return R1 / divBy;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            //FilterDesign.DesignBPF(4, 0.05, 52 * MenialOperations.M, 50.0);

            General_LC glc = new General_LC();

            glc.ShowDialog();

            //SmithChartForm scf = new SmithChartForm();
            //scf.ShowDialog();

            #region Ad-hoc execution code for AP5100
            //double[] desVOut = { 5.0, 1.0, 1.0, 3.3, 5.0, 9.0 };
            //double[] desR1 = { 50000, 2000, 2000, 50000, 50000, 20000 };
            //for (int n = 0; n < desVOut.Length; n++)
            //{
            //    Debug.WriteLine("R1," + desR1[n] + ", " + "R2, " + calcR2(desVOut[n], desR1[n]));
            //}
            #endregion
        }
    }
}
