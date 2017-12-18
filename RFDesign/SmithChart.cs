using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Microwave
{
    public class SmithChart
    {
        public class SmithWindow
        {
            public double gamma_real_min = -1.0;
            public double gamma_real_max = 1.0;
            public double gamma_imag_min = -1.0;
            public double gamma_imag_max = 1.0;

            public int image_width = 800;
            public int image_height = 800;
        }
        
        public static Bitmap ImpedanceChart_CONST;
        public Bitmap graph;
        
        public double Zo; //Required.
        SmithWindow Window;

        private SmithChart()
        {

        }
        public SmithChart(double Zo)
        {
            //View.
            this.Window = new SmithWindow();
            this.graph = new Bitmap(this.Window.image_width, this.Window.image_height);

            //Calculate.
            this.PlotImpedanceChart();
        }
        public void Blackout()
        {
            for (int row = 0; row < this.Window.image_height; row++)
            {
                for (int col = 0; col < this.Window.image_width; col++)
                {
                    this.graph.SetPixel(row, col, Color.Black);
                }
            }
        }
        public void PlotImpedanceChart()
        {
            this.Blackout();

            //Calculate + plot + store grid.
            LogSpace R = new Microwave.LogSpace(0, 3, (int)100);
            LogSpace indX = new Microwave.LogSpace(0, 3, (int)100);
            LogSpace capX = new Microwave.LogSpace(0, 3, (int)100);

            foreach (double r in R.v)
            {
                int v = 100;
                Color gray = Color.FromArgb(150, v, v, v);

                Complex realLine = new Complex(r, 0);
                Complex grealLine = Conversions.ZtoGamma(realLine, 50);
                this.plotGamma(grealLine, gray);

                foreach (double x in capX.v)
                {
                    Complex z = new Complex(r, -x);
                    Complex g = Conversions.ZtoGamma(z, 50);
                    this.plotGamma(g, gray);
                }
                foreach (double x in indX.v)
                {
                    Complex z = new Complex(r, x);
                    Complex g = Conversions.ZtoGamma(z, 50);
                    this.plotGamma(g, gray);
                }
            }
        }

        //Plot gamma.
        public void plotGamma(Complex gamma, Color c)
        {
            int x_coord = this.gammacoord_to_imagecoord(gamma.Real, true);
            int y_coord = this.gammacoord_to_imagecoord(gamma.Imaginary, false);
            //this.MarkPoint(x_coord, y_coord, Color.White, 1);

            if ((x_coord > 0 && x_coord < this.Window.image_width) && (y_coord > 0 && y_coord < this.Window.image_height))
            {
                this.graph.SetPixel(x_coord, y_coord, c);
            }
        }
        
        public void plotZ(Complex Z, Color c)
        {
            Complex g = Conversions.ZtoGamma(Z, this.Zo);
            this.plotGamma(g, c);
        }
        public void plotGammaSpace(ComplexXY gammaXY, Color cc, double minMagnitudeShown)
        {
            //this.MarkPoint(0,0 , Color.White, 100);
            
            for (int row = 0; row < gammaXY.inputs.Mag.N; row++)
            {
                for (int col = 0; col < gammaXY.inputs.Phase.N; col++)
                {
                    if (gammaXY.outputs[row, col].Magnitude > minMagnitudeShown)
                    {
                        this.plotGamma(gammaXY.inputs.Access(row, col), cc);
                    }
                }
            }
        }
        
        private void MarkPoint(int x, int y, Color c, int delta = 2)
        {
            Graphics g;
            g = Graphics.FromImage(this.graph);
            
            g.DrawLine(new Pen(c), new Point(x - delta, y - delta), new Point(x + delta, y + delta));
            g.DrawLine(new Pen(c), new Point(x + delta, y - delta), new Point(x - delta, y + delta));
            g.Dispose();
        }
        public int gammacoord_to_imagecoord(double gammacoord, bool isHorizontal)
        {
            if (isHorizontal)
            {
                int toReturn = (int)((gammacoord - this.Window.gamma_real_min) / (this.Window.gamma_real_max - this.Window.gamma_real_min) * this.Window.image_width);
                if (toReturn < 0)
                    return 0;
                if (toReturn > this.Window.image_width)
                    return this.Window.image_width - 1;
                else
                    return toReturn;
            }
            else
            {
                int toReturn = this.Window.image_height - (int)((gammacoord - this.Window.gamma_imag_min) / (this.Window.gamma_imag_max - this.Window.gamma_imag_min) * this.Window.image_height);
                if (toReturn < 0)
                    return 0;
                if (toReturn > this.Window.image_height)
                    return this.Window.image_height- 1;
                else
                    return toReturn;
            }
        }
        public Complex imagecoord_to_gammacoord(int imagecoord_x, int imagecoord_y)
        {
            double real = ((double)imagecoord_x - 0) / (this.Window.image_width - 0) * (this.Window.gamma_real_max - this.Window.gamma_real_min) + this.Window.gamma_real_min;
            double imag = (this.Window.image_height - (double)imagecoord_y) / (this.Window.image_height - 0) * (this.Window.gamma_imag_max - this.Window.gamma_imag_min) + this.Window.gamma_imag_min;

            return new Complex(real, imag);
        }
    }
    
}
