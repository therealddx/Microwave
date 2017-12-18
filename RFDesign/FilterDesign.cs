using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave
{
    public class FilterDesign
    {
        public static List<double[]> DesignTable = new List<double[]>
        {
            //Ignore load ("g(N + 1)" == 1)
            new double[] {2},
            new double[] {1.4142, 1.4142},
            new double[] {1, 2, 1},
            new double[] {0.7654, 1.8478, 1.8478, 0.7654}
        };

        //N: order
        //w: fractional bandwidth
        //Zo: Load/source impedances.
        //Assumes voltage source with series parasitic Zs.
            //Thus first rxtv element is a shunt cap.
        public static void DesignBPF(int N, double w, double freq, double Zo)
        {
            double[] LPPvalues = FilterDesign.DesignTable[N - 1]; //Order is 1-indexed. List is 0-indexed.
            double[] BPFvalues = new double[LPPvalues.Length << 1]; //2 BPF components for each LPP component.
            
            for (int lpp_ind = 0; lpp_ind < LPPvalues.Length; lpp_ind++)
            {
                int bpf_ind = lpp_ind << 1;
                double reactiveValue = LPPvalues[lpp_ind];

                //Z-scale.
                double L_pair;
                double C_pair;
                if (lpp_ind % 2 == 0) //Shunt cap.
                {
                    L_pair = Zo * w / (2 * Math.PI * freq * reactiveValue);
                    C_pair = reactiveValue / (2 * Math.PI * freq * w * Zo);
                }
                else //Series ind.
                {
                    L_pair = Zo * reactiveValue / (2 * Math.PI * freq * w);
                    C_pair = w / (2 * Math.PI * freq * reactiveValue * Zo);
                }

                //Report.
                Debug.WriteLine("Resonator " + (lpp_ind + 1) + ": ");
                Debug.WriteLine("LPP value: " + reactiveValue + (lpp_ind % 2 == 0 ? "F" : "H"));
                Debug.WriteLine("Resonator L: " + L_pair + "H, Resonator C: " + C_pair + "F\n");
            }

        }
    }
}
