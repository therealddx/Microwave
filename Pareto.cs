using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Microwave
{
    class Pareto
    {
        public static double StaticEvaluation2D(
            Func<double, double, XY> BaseFn,
            ParetoResultAnalyzer pra1, ParetoResultAnalyzer pra2, 
            ParetoVariable pv1, ParetoVariable pv2
            )
        {
            XY BaseResult = BaseFn(pv1.val, pv2.val);
            return pra1.fn(BaseResult) * pra1.weight + pra2.fn(BaseResult) * pra2.weight;
        }
        public static double Gradient2D(
            Func<double,double,XY> BaseFn,
            ParetoResultAnalyzer pra1, ParetoResultAnalyzer pra2, 
            ParetoVariable pv1, ParetoVariable pv2, 
            out double df_dpv1, out double df_dpv2
            )
        {
            double f = StaticEvaluation2D(BaseFn, pra1, pra2, pv1, pv2);
            df_dpv1 = (StaticEvaluation2D(BaseFn, pra1, pra2, pv1.get_increment(), pv2                ) - f) / pv1.dx;
            df_dpv2 = (StaticEvaluation2D(BaseFn, pra1, pra2, pv1,                 pv2.get_increment()) - f) / pv2.dx;
            return f;
            //Debug.WriteLine("Coming from Gradient2D() to say that: (df_dpv1, df_dpv2) == " + "(" + df_dpv1 + ", " + df_dpv2 + ")");
        }
        public static void FindSolution2D(
            Func<double, double, XY> BaseFn, 
            ParetoResultAnalyzer pra1, ParetoResultAnalyzer pra2,
            ParetoVariable pv1, ParetoVariable pv2, 
            int numTrials, string outPath = ""
            )
        {
            //Find 2-dimensional pareto solution using gradient descent, given two input biasing functions.

            File.Delete(outPath);

            double f = 0;
            double df_dpv1 = 0;
            double df_dpv2 = 0;
            
            for (int trialsElapsed = 0; trialsElapsed < numTrials; trialsElapsed++)
            {
                f = Gradient2D(BaseFn, pra1, pra2, pv1, pv2, out df_dpv1, out df_dpv2);

                if (trialsElapsed % 100 == 0)
                {
                    Debug.WriteLine("Iteration: " + trialsElapsed + ".");
                    Debug.WriteLine("Static evaluation at f == (pv1, pv2): " + f + " == (" + pv1.val + ", " + pv2.val + ")");
                    Debug.WriteLine("(dpv1, dpv2) == " + "(" + df_dpv1 + ", " + df_dpv2 + ")");
                }
                
                pv1.adjust(df_dpv1);
                pv2.adjust(df_dpv2);
                
                if (trialsElapsed % 100 == 0)
                {
                    Console.WriteLine(trialsElapsed);
                    ExportData.AppendXYtoCSV(outPath, BaseFn(pv1.val, pv2.val));
                }
            }
            
        }
    }
    
    class ParetoVariable
    {
        private double af; //Adjustment Factor: How much this.val should be changed in order to approach lower ground.
        private double min_bound;
        private double max_bound;
        public double dx; //Gradient Jump: Increment used when measuring gradient.
        public double val;

        /// <summary>
        /// Construct a ParetoVariable.
        /// </summary>
        /// <param name="d_af">Adjustment factor: How much this.val will be changed in accordance with instantaneous slope at this.val.</param>
        /// <param name="d_min_bound">Minimum value accessible.</param>
        /// <param name="d_max_bound">Maximum value accessible.</param>
        /// <param name="d_dx">h-value used to calculate instantaneous slope at this val.</param>
        public ParetoVariable(double d_af, double d_min_bound, double d_max_bound, double d_dx, bool randVal = false)
        {
            af = d_af;

            min_bound = d_min_bound;
            max_bound = d_max_bound;

            dx = d_dx;
            
            if (!randVal)
            {
                val = min_bound;
            }
            else
            {
                Random rg = new Random();
                val = rg.NextDouble() * (max_bound - min_bound) + min_bound; //[0->1) to [0->max_bound - min_bound) to [min_bound->max_bound).
            }
        }
        public ParetoVariable()
        {
            this.val = 0;
            this.af = 0;
            this.dx = 0;
            this.min_bound = 0;
            this.max_bound = 0;
        }

        public void adjust(double dpvdx)
        {
            double d = this.val - this.af * dpvdx;
            //Debug.WriteLine("this.val - this.af * dpvdx == " + this.val + " - " + this.af + " * " + dpvdx + " == " + d);

            if (d < this.min_bound)
                this.val = this.min_bound;
            else if (d > this.max_bound)
                this.val = this.max_bound;
            else
                this.val = d;
        }
        public ParetoVariable get_increment()
        {
            ParetoVariable dpv = new ParetoVariable();

            dpv.val = this.val + this.dx;
            dpv.af = this.af;
            dpv.dx = this.dx;
            dpv.min_bound = this.min_bound;
            dpv.max_bound = this.max_bound;

            return dpv;
        }
    }

    class ParetoResultAnalyzer
    {
        //Object for Fn that analyzes the result and outputs some evaluation score on some criteria.

        public Func<XY, double> fn;
        public double weight;
        public ParetoResultAnalyzer(Func<XY, double> d_fn, double d_weight)
        {
            fn = d_fn;
            weight = d_weight;
        }
    }

}
