using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Microwave
{
    class MenialOperations
    {
        #region Numerical Prefixes
        public readonly static double f = Math.Pow(10, -15);
        public readonly static double p = Math.Pow(10, -12);
        public readonly static double n = Math.Pow(10, -9);
        public readonly static double u = Math.Pow(10, -6);
        public readonly static double m = Math.Pow(10, -3);
        public readonly static double K = Math.Pow(10, 3);
        public readonly static double M = Math.Pow(10, 6);
        public readonly static double G = Math.Pow(10, 9);
        #endregion

        #region Angle
        public static double DegToRad(double deg_in)
        {
            return deg_in * Math.PI / 180;
        }
        public static double RadToDeg(double rad_in)
        {
            return rad_in * 180 / Math.PI;
        }
        #endregion

        #region Complex
        public static Complex ComplexFromMagPhase(double mag, double phase, bool degNOTRAD)
        {
            if (degNOTRAD)
            {
                phase = degtorad(phase);
            }
            return new Complex(mag * Math.Cos(phase), mag * Math.Sin(phase));
        }
        public static string ComplexToStringMagPhase(Complex X)
        {
            return X.Magnitude + "/" + radtodeg(X.Phase) + "°";
        }
        public static Complex ComplexFromString(string s, bool degNOTRAD = true)
        {
            //a + jb
            if (s.Contains("j") || (s.Contains("i")))
            {
                s = Regex.Replace(s, @"\s", "");
                Regex RealRegex = new Regex(@"^(-)?(\d+)?(\.)?\d+");
                Regex ImagRegex = new Regex(@"(\+|-)(j|i)(\d+\.)?\d+");

                double real = double.MinValue;
                double.TryParse(RealRegex.Match(s).Value, out real);

                double imag = double.MinValue;
                double.TryParse(ImagRegex.Match(s).Value.Replace("i", "").Replace("j", ""), out imag);

                Complex toReturn = new Complex(real, imag);
                return toReturn;
            }
            
            //m<phase. Defaults to this branch if no imaginary is entered. Returns solely re + j0 if no "<" with corresponding phase is entered.
            else
            {
                s = Regex.Replace(s, @"\s", "");
                Regex MagRegex = new Regex(@"^(\d+)?(\.)?\d+");
                Regex PhaseRegex = new Regex(@"<(-)?(\d+\d.)?\d+");

                double mag = double.MinValue;
                double.TryParse(MagRegex.Match(s).Value, out mag);

                double phase = double.MinValue;
                double.TryParse(PhaseRegex.Match(s).Value.Substring(PhaseRegex.Match(s).Value.IndexOf('<') + 1), out phase);

                Complex toReturn = MenialOperations.complex_magphase(mag, phase, degNOTRAD);
                return toReturn;
            }
        }
        #endregion

        #region Basic Math
        public static void Quadratic(double A, double B, double C, out double ResultAdd, out double ResultSubtract)
        {
            ResultAdd = (-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A);
            ResultSubtract = (-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A);
        }
        public static void Quadratic(Complex A, Complex B, Complex C, out Complex ResultAdd, out Complex ResultSubtract)
        {
            ResultAdd = (-B + Complex.Sqrt(B * B - 4 * A * C)) / (2 * A);
            ResultSubtract = (-B - Complex.Sqrt(B * B - 4 * A * C)) / (2 * A);
        }
        public static double Parallel(double x1, double x2)
        {
            return (x1 * x2) / (x1 + x2);
        }
        #endregion

        #region Vectors
        public static double[] CopyVector(double[] x)
        {
            double[] x_copy = new double[x.Length];
            for (int n = 0; n < x.Length; n++)
            {
                x_copy[n] = x[n];
            }
            return x_copy;
        }
        public static double[] RandomVector(int N)
        {
            Random rg = new Random();
            double[] x = new double[N];
            for (int n = 0; n < x.Length; n++)
            {
                x[n] = rg.NextDouble();
            }
            return x;
        }
        public static double[] AddConstantToVector(double[] x, double constant)
        {
            double[] x_copy = MenialOperations.CopyVector(x);
            for (int n = 0; n < x.Length; n++)
            {
                x_copy[n] += constant;
            }
            return x_copy;
        }
        public static double[] TermByTermMultiply(double[] x, double[] y)
        {
            double[] z = new double[x.Length];
            for (int n = 0; n < z.Length; n++)
            {
                z[n] = x[n] * y[n];
            }
            return z;
        }
        #endregion
        
        #region Matrices
        public static T[,] CopyMatrix<T>(T[,] ToCopy)
        {
            T[,] ToReturn = new T[ToCopy.GetLength(0), ToCopy.GetLength(1)];
            for (int row_ind = 0; row_ind < ToCopy.GetLength(0); row_ind++)
            {
                for (int col_ind = 0; col_ind < ToCopy.GetLength(1); col_ind++)
                {
                    ToReturn[row_ind, col_ind] = ToCopy[row_ind, col_ind];
                }
            }
            return ToReturn;
        }
        public static void PrintMatrix<T>(T[,] ToPrint)
        {
            for (int row = 0; row < ToPrint.GetLength(0); row++)
            {
                for (int col = 0; col < ToPrint.GetLength(1); col++)
                {
                    Debug.Write(ToPrint[row, col].ToString() + ", ");
                }
                Debug.WriteLine("");
            }
        }
        #endregion Matrices

        #region Conversions
        public static Complex ZtoGamma(Complex Z, double Zo)
        {
            return (Z - Zo) / (Z + Zo);
        }
        public static Complex GammaToZ(Complex gamma, double Zo)
        {
            return Zo * (1 + gamma) / (1 - gamma);
        }
        
        public static double XtoL(double X, double freq)
        {
            return Math.Abs(X / (2 * Math.PI * freq));
        }
        public static double XtoC(double X, double freq)
        {
            return Math.Abs(1.0 / (X * 2 * Math.PI * freq));
        }
        public static double CtoX(double C, double freq)
        {
            return -1 / (2 * Math.PI * freq * C);
        }
        public static double LtoX(double L, double freq)
        {
            return 2 * Math.PI * freq * L;
        }

        public static bool XtoComponent(double X, double freq, out double componentValue)
        {
            //true if cap, false if ind
            if (X < 0)
            {
                componentValue = XtoC(X, freq);
                return true;
            }
            else
            {
                componentValue = XtoL(X, freq);
                return false;
            }
        }
        public static void BtoComponent(double B, double freq, out double componentValue)
        {
            if (B > 0)
            {
                componentValue = B / (2 * Math.PI * freq);
            }
            else
            {
                componentValue = -1.0 / (B * 2 * Math.PI * freq);
            }
        }
        public static string XtoComponent(double X, double freq)
        {
            if (X == 0)
            {
                return "";
            }
            if (X < 0)
            {
                return XtoC(X, freq) + " F";
            }
            else
            {
                return XtoL(X, freq) + " H";
            }
        }
        #endregion

        #region Strings
        public static string SubstringProperly(string x, int fromEndpointInclusive, int toEndpointExclusive)
        {
            //Take s[low, high).
            return x.Substring(fromEndpointInclusive, toEndpointExclusive - fromEndpointInclusive);
        }
        #endregion
    }
}