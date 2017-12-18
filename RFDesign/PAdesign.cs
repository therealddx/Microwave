using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Microwave
{
    class PAdesign
    {

        public static Complex gamma_S(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            Complex dd = tpn.det();

            Complex B1 = 1 + Complex.Pow(Complex.Abs(tpn.p[0,0]), 2) - Complex.Pow(Complex.Abs(tpn.p[1,1]), 2) - Complex.Pow(Complex.Abs(dd), 2);
            Complex C1 = tpn.p[0,0] - dd * Complex.Conjugate(tpn.p[1,1]);

            Complex numer1 = B1 + Complex.Sqrt(Complex.Pow(B1, 2) - 4 * Complex.Pow(Complex.Abs(C1), 2));
            Complex denom1 = 2 * C1;
            Complex g1 = numer1 / denom1;

            Complex numer2 = B1 - Complex.Sqrt(Complex.Pow(B1, 2) - 4 * Complex.Pow(Complex.Abs(C1), 2));
            Complex denom2 = 2 * C1;
            Complex g2 = numer2 / denom2;

            return g1.Magnitude < 1 ? g1 : g2;
        }
   
        public static Complex gamma_L(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            Complex dd = tpn.det();

            Complex B2 = 1 + Math.Pow(Complex.Abs(tpn.p[1,1]), 2) - Math.Pow(Complex.Abs(tpn.p[0,0]), 2) - Math.Pow(Complex.Abs(dd), 2);
            Complex C2 = tpn.p[1,1] - dd * Complex.Conjugate(tpn.p[0,0]);

            Complex numer1 = B2 + Complex.Sqrt(Complex.Pow(B2, 2) - 4 * Complex.Pow(Complex.Abs(C2), 2));
            Complex denom1 = 2 * C2;
            Complex g1 = numer1 / denom1;

            Complex numer2 = B2 - Complex.Sqrt(Complex.Pow(B2, 2) - 4 * Complex.Pow(Complex.Abs(C2), 2));
            Complex denom2 = 2 * C2;
            Complex g2 = numer2 / denom2;

            return g1.Magnitude < 1 ? g1 : g2;
        }

        public static double G_S(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            Complex gamma_s = gamma_S(tpn);
            Complex gamma_in = MenialOperations.gamma_IN(tpn.p, gamma_s);
            double numer = 1 - Math.Pow(Complex.Abs(gamma_s), 2);
            double denom = Math.Pow(Complex.Abs(1 - gamma_in * gamma_s), 2);
            return numer / denom;
        }
        public static double G_L(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            Complex gamma_l = gamma_L(tpn);
            double numer = 1 - Math.Pow(Complex.Abs(gamma_l), 2);
            double denom = Math.Pow(Complex.Abs(1 - tpn.p[1,1] * gamma_l), 2);
            return numer / denom;
        }
        public static double G_0(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            return tpn.p[1, 0].Magnitude * tpn.p[1, 0].Magnitude;
        }
        public static double G_total(TwoPortNetworks.TwoPortNetwork tpn)
        {
            if (tpn.state != TwoPortNetworks.STATE.S)
            {
                throw new Exception("Error: Attempt to call s-param function without two-port network in s-params mode");
            }
            return G_S(tpn) * G_0(tpn) * G_L(tpn);
        }
    }
}
