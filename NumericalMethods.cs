using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Microwave
{
    public class LinearSpace
    {
        //An object of type linspace has:
        //low
        //high
        //delta
        //numpoints

        //An object of type linspace can be constructed with:
        //low, high, numpoints, endpoint-exclusive.
        //low, high, delta, endpoint-exclusive.

        public readonly double H;
        public readonly double L;
        public readonly double h;
        public readonly double[] v; //holds N points.
        public readonly int N;
        
        public LinearSpace(double d_L, double d_H, int d_N)
        {
            L = d_L;
            H = d_H;
            h = (H - L) / d_N;
            v = new double[d_N];
            N = v.Length;

            //For n = 0, long's n < N.
                //you'll have N points.
                //What's h. h is (H - L) / N.
            
            for (int n = 0; n < v.Length; n++)
            {
                v[n] = L + h * n;
            }
        }
        public LinearSpace(double d_L, double d_H, double d_h)
        {
            L = d_L;
            H = d_H;
            h = Math.Abs(d_h);
            v = new double[(int)((H - L) / h)]; //THIS CAST is why we will always be right-endpoint-exclusive.1
            N = v.Length;

            for (int n = 0; n < v.Length; n++)
            {
                v[n] = L + h * n;
            }
        }

        #region Deprecated
        //public double YgivenX(double[] f, double x)
        //{
        //    //I want to access a double array without worrying about indexing.
        //    //Sure, just tell me what linspace this double array is referenced against. from that,
        //    //I'll find the index that corresponds most closely to the double value you asked for, and return
        //    //the corresponding value.
        //
        //    //Or hell, while I'm here, just give it a linear interpolation.
        //
        //    //Search along v. When you find v[n] s/t X > v[n], go ahead and return me the linear interpolation.
        //    
        //    //Conditions. Lengths must be equal.
        //    if (f.Length == this.v.Length)
        //    {
        //        //Edge-case for outside of x-axis.
        //        if (x > v[v.Length - 1]) //if you're greater than v[N - 1] then you'll make an exception down below.
        //                                 //if you're only greater than v[N - 2] then you'll still be able to call v[N - 1].
        //        {
        //            return v[v.Length - 1];
        //        }
        //        if (x < v[0])
        //        {
        //            return v[0];
        //        }
        //
        //        //go.
        //        for (int n = 0; n < this.v.Length; n++)
        //        {
        //            if (x > this.v[n]) //Now I've found my x-coordinate in the linspace.
        //            {
        //                return f[n] + ((f[n + 1] - f[n]) / this.h) * (x - v[n]);
        //            }
        //        }
        //    }
        //    return double.NaN;
        //}
        #endregion Deprecated
    }
    public class LogSpace
    {
        public readonly double H_log;
        public readonly double L_log;
        public readonly double h_log;
        public readonly double[] v; //holds N points.
        public readonly int N;
        
        public LogSpace(double d_L, double d_H, int d_N)
        {
            L_log = d_L;
            H_log = d_H;
            h_log = (H_log - L_log) / d_N;
            v = new double[d_N];
            N = v.Length;
            
            for (int n = 0; n < v.Length; n++)
            {
                double curExponent = L_log + n * h_log;
                this.v[n] = Math.Pow(10, curExponent);
            }
        }
        public LogSpace(double d_L, double d_H, double d_h)
        {
            L_log = d_L;
            H_log = d_H;
            h_log = Math.Abs(d_h);
            v = new double[(int)((H_log - L_log) / h_log)];
            N = v.Length;

            for (int n = 0; n < v.Length; n++)
            {
                double curExponent = L_log + n * h_log;
                this.v[n] = Math.Pow(10, curExponent);
            }
        }

    }
    public class ComplexLinearSpace
    {
        public readonly LinearSpace Mag;
        public readonly LinearSpace Phase;

        public ComplexLinearSpace()
        {
            this.Mag = new Microwave.LinearSpace(0, 1.0, (int)100);
            this.Phase = new Microwave.LinearSpace(0, 360.0, (int)100);
        }
        public ComplexLinearSpace(int dimMag, int dimPhase, bool degNOTRAD = true)
        {
            this.Mag = new Microwave.LinearSpace(0, 1.0, dimMag);

            if (degNOTRAD)
            {
                this.Phase = new Microwave.LinearSpace(0, 360.0, dimPhase);
            }
            else
            {
                this.Phase = new Microwave.LinearSpace(0, 2 * Math.PI, dimPhase);
            }
        }
        public ComplexLinearSpace(LinearSpace d_Mag, LinearSpace d_Phase)
        {
            this.Mag = d_Mag;
            this.Phase = d_Phase;
        }
        public Complex Access(int row_mag, int col_phase)
        {
            double mag = this.Mag.v[row_mag];
            double phase = this.Phase.v[col_phase];
            return MenialOperations.complex_magphase(mag, phase, true);
        }
    }

    public class ComplexXY
    {
        //Map one set of complex values (inputs, or "x"-values, to outputs, or "y"-values).
        //row: magtnidue
        //col: phase

        public ComplexLinearSpace inputs;
        public Complex[,] outputs;

        public ComplexXY()
        {
            this.inputs = new Microwave.ComplexLinearSpace(100, 100);
            this.outputs = new Complex[100, 100];
        }
        public ComplexXY(int square)
        {
            this.inputs = new Microwave.ComplexLinearSpace(square, square);
            this.outputs = new Complex[square, square];
        }
        public ComplexXY(int num_rows_mag, int num_cols_phase)
        {
            this.inputs = new Microwave.ComplexLinearSpace(num_rows_mag, num_cols_phase);
            this.outputs = new Complex[num_rows_mag, num_cols_phase];
        }
        public ComplexXY(ComplexLinearSpace inputvals, Complex[,] outputvals)
        {
            this.inputs = inputvals;
            this.outputs = outputvals;
        }
        
        public ComplexXY(ComplexLinearSpace inputvals, Func<Complex, Complex> Func)
        {
            this.inputs = inputvals;
            this.outputs = new Complex[inputvals.Mag.N, inputvals.Phase.N];

            this.Fill(Func);
        }
        public void Fill(Func<Complex, Complex> Func)
        {
            for (int cur_row = 0; cur_row < this.inputs.Mag.N; cur_row++)
            {
                for (int cur_col = 0; cur_col < this.inputs.Phase.N; cur_col++)
                {
                    this.outputs[cur_row, cur_col] = Func(this.inputs.Access(cur_row, cur_col));
                }
            }
        }

        public ComplexXY(ComplexLinearSpace inputvals, Func<ComplexLinearSpace, Complex[,]> Func)
        {
            this.inputs = inputvals;
            this.outputs = Func(inputvals);
        }

    }

    public class XY
    {
        public readonly LinearSpace x;
        public double[] y;
        public readonly int N;

        public XY(LinearSpace d_x, double[] d_y)
        {
            this.x = d_x;
            this.y = d_y;
            this.N = d_x.N;
        }
        public XY(LinearSpace d_x)
        {
            this.x = d_x;
            this.y = new double[d_x.N];
            this.N = d_x.N;
        }
        public XY(double[] d_x, double[] d_y)
        {
            this.x = new Microwave.LinearSpace(d_x[0], d_x[d_x.Length - 1] + (d_x[1] - d_x[0]), d_x.Length);
            this.y = d_y;
            this.N = d_y.Length;
        }

        public override string ToString()
        {
            string XYstring = "";
            for (int n = 0; n < this.N; n++)
            {
                //<index>, <x>, <y>\n
                XYstring += n + ", " + this.x.v[n] + ", " + this.y[n] + "\n";
            }
            return XYstring + "\n";
        }
    }

    public class NumericalMethods
    {
        #region Calc
        public static XY Derivative(XY f)
        {
            //Derivative using difference quotient.

            XY df = new XY(f.x);
            for (int n = 0; n < df.N - 1; n++)
            {
                df.y[n] = (f.y[n + 1] - f.y[n]) / df.x.h;
            }
            df.y[df.N - 1] = df.y[df.N - 2];
            return df;
        }
        public static XY Integral(XY f, double F0)
        {
            //Simple integration with Euler's method.
            //y[n + 1] = y[n] + h*f(t[n], y[n]).

            XY F = new XY(f.x);

            F.y[0] = F0;
            for (int n = 1; n < F.N; n++)
            {
                //for each term.
                F.y[n] = F.y[n - 1] + F.x.h * f.y[n];
            }
            return F;
        }
        #endregion

        #region Stats
        public static double ExpectedValue(double[] x)
        {
            double avg = 0;
            for (int n = 0; n < x.Length; n++)
                avg += x[n];
            return avg / x.Length;
        }
        public static double StandardDeviation(double[] x)
        {
            double u_x = ExpectedValue(x);
            double sumofsquares = 0.0;

            for (int n = 0; n < x.Length; n++)
            {
                sumofsquares += Math.Pow(x[n] - u_x, 2.0);
            }
            return Math.Sqrt(sumofsquares / x.Length);
        }
        public static double Covariance(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                return 0.0;
            
            double[] x_shifted = MenialOperations.copy_vector(x);
            double[] y_shifted = MenialOperations.copy_vector(y);

            x_shifted = MenialOperations.shift_vector(x_shifted, -ExpectedValue(x_shifted));
            y_shifted = MenialOperations.shift_vector(y_shifted, -ExpectedValue(y_shifted));

            return ExpectedValue(MenialOperations.mul_vector(x_shifted, y_shifted));
        }
        public static double CorrelationCoefficient(XY xy)
        {
            double[] x = xy.x.v;
            double[] y = xy.y;
            //Console.WriteLine("From r calc");
            //Console.WriteLine(xy.ToString());

            return Covariance(x, y) / (StandardDeviation(x) * StandardDeviation(y));
        }
        #endregion

        #region Test code for this section.
        //Stats test code
        /* ExpectedValue / StandardDeviation / Covariance
            Random rg = new Random();
            double[] x = new double[10];
            for (int n = 0; n < x.Length; n++)
            {
                x[n] = rg.NextDouble() + 2.0;
                Debug.Write(x[n] + ", ");
            } Debug.WriteLine("");
            double[] y = new double[10];
            for (int n = 0; n < y.Length; n++)
            {
                y[n] = rg.NextDouble() + 1.0;
                Debug.Write(y[n] + ", ");
            }

            Debug.WriteLine("\n\n\nExpected: " + NumericalMethods.ExpectedValue(x));
            Debug.WriteLine("Stand: " + NumericalMethods.StandardDeviation(x));
            Debug.WriteLine("Cov: " + NumericalMethods.Covariance(x, y));

            for (int n = 0; n < x.Length; n++)
            {
                Debug.Write(x[n] + ", ");
            }
            Debug.WriteLine("");
            for (int n = 0; n < x.Length; n++)
            {
                Debug.Write(y[n] + ", ");
            }
            */
        /* CorrelationCoefficient
            XY xy = new Microwave.XY(new LinearSpace(0.0, 2.5, 0.05));
            xy.y = MenialOperations.rg_vector(xy.N);

            Debug.WriteLine(xy.ToString());

            double r = NumericalMethods.CorrelationCoefficient(xy);

            Debug.WriteLine(xy.ToString());

            Debug.WriteLine("corr is " + r);
         */

        //Derivative / Integral test code
        /*
            //Test code for Derivative() / Integral().
            XY testFunc = new XY(new LinearSpace(0.1, 10.0, 0.01));
            for (int n = 0; n < testFunc.N; n++)
                {
                    testFunc.y[n] = 1.0 / testFunc.x.v[n];
                }

            XY testFunc_ddx = NumericalMethods.Derivative(testFunc);
            XY testFunc_S = NumericalMethods.Integral(testFunc, Math.Log(0.1));

            string path = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\out.csv";
            System.IO.File.AppendAllText(path, testFunc.ToString());
            System.IO.File.AppendAllText(path, testFunc_ddx.ToString());
            System.IO.File.AppendAllText(path, testFunc_S.ToString());
            */
        #endregion
    }
    public class ScalarField2D
    {
        Func<double, double, double> fxy;
        LinearSpace x;
        LinearSpace y;
        double[,] field;

        public ScalarField2D(Func<double,double,double> d_fxy, LinearSpace d_x, LinearSpace d_y)
        {
            fxy = d_fxy;
            x = d_x;
            y = d_y;
            field = new double[x.N, y.N];

            this.Fill();
        }
        public void Fill()
        {
            for (int row_ind = 0; row_ind < y.N; row_ind++)
            {
                for (int col_ind = 0; col_ind < x.N; col_ind++)
                {
                    field[col_ind, row_ind] = fxy(x.v[col_ind], y.v[row_ind]);
                }
                Console.Write("row " + row_ind);
            }
        }
        public double findMinimum(out double x_ofMin, out double y_ofMin)
        {
            double min      =  double.MaxValue;
            x_ofMin = double.MaxValue;
            y_ofMin = double.MaxValue;

            for (int row = 0; row < y.N; row++)
            {
                for (int col = 0; col < x.N; col++)
                {
                    if (field[col, row] < min)
                    {
                        min = field[col, row];
                        x_ofMin = this.x.v[col];
                        y_ofMin = this.y.v[row];
                    }
                }
            }
            return min;
        }
        public override string ToString()
        {
            string s = "";

            //Linspace x should appear across the top row, one cell offset.
            //Linspace y should appear down the left column, one cell offset.
            //Scalar field should be filled out as we go.

            //First row. Linspace y, offset by one.
            s += ",";
            for (int n = 0; n < y.N; n++)
            {
                s += y.v[n] + ", ";
            } s += "\n";

            //Rest of rows.
            //For index n = 0; n < y.N; n++:
                //Print y[n] + ", "
                //for index m = 0; m < x.N; m++
                    //Print x[m] + ", "
            for (int n = 0; n < x.N; n++)
            {
                s += x.v[n] + ", ";
                for (int m = 0; m < y.N; m++)
                {
                    s += field[n, m] + ", ";
                } s += "\n";
            }

            return s;
        }
    }
    
}