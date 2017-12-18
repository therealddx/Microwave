using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Microwave
{
    public class OnePortNetwork
    {
        #region Basic Conversions
        public static Complex ZtoGamma(Complex Z, double Zo)
        {
            return (Z - Zo) / (Z + Zo);
        }
        public static Complex GammaToZ(Complex gamma, double Zo)
        {
            return Zo * (1 + gamma) / (1 - gamma);
        }
        #endregion

        #region Properties: G, Z, Y, Zo
        public Complex G
        {
            get { return G; }
            set
            {
                G = value;
                Z = GammaToZ(value, Zo);
                Y = 1 / Z;
            }
        }
        public Complex Z
        {
            get { return Z; }
            set
            {
                Z = value;
                Y = 1 / Z;
                G = ZtoGamma(Z, Zo);
            }
        }
        public Complex Y
        {
            get { return Y; }
            set
            {
                Y = value;
                Z = 1 / Y;
                G = ZtoGamma(Z, Zo);
            }
        }
        public double Zo
        {
            get { return Zo; }
            set
            {
                Zo = value;
                G = ZtoGamma(Z, Zo);
            }
        }
        #endregion

        #region LC L-match.
        public static bool Lmatch(Complex ZA, Complex ZB, bool isLP, double freq, double Zo, out double L, out double C)
        {
            //Returns true if series is next to load.
            //False if shunt is next to load.

            //Make ZA look like ZB.

            //Xs followed by Bp.
            if (ZB.Real > ZA.Real)
            {
                Lmatch_Z(ZA, ZB, isLP, freq, out L, out C);
                return true;
            }
            //Bp followed by Xs.
            else
            {
                Lmatch_Y(1 / ZA, 1 / ZB, isLP, freq, out L, out C);
                return false;
            }
        }
        public static void Lmatch_Z(Complex ZA, Complex ZB, bool isLP, double freq, out double L, out double C)
        {
            //Calculate Xs s/t GA,new = GB.
            //Add shunt susceptance s/t ZA = ZB.

            Complex YA = 1 / ZA;
            Complex YB = 1 / ZB;

            double a = YB.Real;
            double b = YB.Real * 2 * ZA.Imaginary;
            double c = YB.Real * ZA.Imaginary * ZA.Imaginary + YB.Real * ZA.Real * ZA.Real - ZA.Real;

            double Xs_Add;
            double Xs_Sub;
            MenialOperations.Quadratic(a, b, c, out Xs_Add, out Xs_Sub);

            double Xs = 0;
            //If this is a lowpass match, Xs needs > 0.
            if (isLP)
            {
                Xs = Xs_Add > 0 ? Xs_Add : Xs_Sub;
                Conversions.XtoComponent(Xs, freq, out L);

                Complex YA_Prime = 1 / (ZA + new Complex(0, Xs));
                double Bp = YB.Imaginary - YA_Prime.Imaginary;

                Conversions.BtoComponent(Bp, freq, out C);
            }
            //If this is a highpass match, Xs needs < 0.
            else
            {
                Xs = Xs_Add < 0 ? Xs_Add : Xs_Sub;
                Conversions.XtoComponent(Xs, freq, out C);

                Complex YA_Prime = 1 / (ZA + new Complex(0, Xs));
                double Bp = YB.Imaginary - YA_Prime.Imaginary;

                Conversions.BtoComponent(Bp, freq, out L);
            }
        }
        public static void Lmatch_Y(Complex YA, Complex YB, bool isLP, double freq, out double L, out double C)
        {
            Complex ZA = 1 / YA;
            Complex ZB = 1 / YB;

            double a = ZB.Real;
            double b = ZB.Real * 2 * YA.Imaginary;
            double c = ZB.Real * YA.Imaginary * YA.Imaginary + ZB.Real * YA.Real * YA.Real - YA.Real;

            double Bp_Add;
            double Bp_Sub;
            MenialOperations.Quadratic(a, b, c, out Bp_Add, out Bp_Sub);

            double Bp = 0;
            //If this is a lowpass match, Bp needs > 0.
            if (isLP)
            {
                Bp = Bp_Add > 0 ? Bp_Add : Bp_Sub;
                Conversions.BtoComponent(Bp, freq, out C);

                Complex ZA_Prime = 1 / (YA + new Complex(0, Bp));
                double Xs = ZB.Imaginary - ZA_Prime.Imaginary;

                Conversions.XtoComponent(Xs, freq, out L);
            }
            //If this is a highpass match, Bp needs < 0.
            else
            {
                Bp = Bp_Add < 0 ? Bp_Add : Bp_Sub;
                Conversions.BtoComponent(Bp, freq, out L);

                Complex ZA_Prime = 1 / (YA + new Complex(0, Bp));
                double Xs = ZB.Imaginary - ZA_Prime.Imaginary;

                Conversions.XtoComponent(Xs, freq, out C);
            }
        }
        public void Lmatch(OnePortNetwork otherOnePortNetwork, bool isLP, double freq, out double L, out double C)
        {
            OnePortNetwork.Lmatch(this.Z, otherOnePortNetwork.Z, isLP, freq, this.Zo, out L, out C);
        }
        #endregion
    }
}
