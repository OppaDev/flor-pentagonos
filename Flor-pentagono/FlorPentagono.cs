using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flor_pentagono
{
    public class FlorPentagono
    {
        //atributos
        private double lado;
        //objeto de la clase Graphics
        private Graphics graph;
        //objeto de la clase Pen
        private Pen pen;
        //scale factor (Zoom In/Zoom Out)
        private int sF = 10;

        //constructor vacio
        public FlorPentagono()
        {
            lado = 0;
        }
        public FlorPentagono(double lado)
        {
            this.lado = lado;
        }

        //getters y setters
        public double getLado()
        {
            return lado;
        }
        public void setLado(double lado)
        {
            this.lado = lado;
        }
        public double getSF()
        {
            return sF;
        }
        public void setSF(int sF)
        {
            this.sF = sF;
        }

        //Calculos 
        public double radioCircunscrito()
        {
            return lado / (2 * Math.Sin(Math.PI / 5));
        }
        //dibujar circulo circunscrito
        public void dibujarCirculoCircunscrito(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Black);
            //dibuja el circulo circunscrito
            graph.DrawEllipse(pen, (float)(picCanvas.Width / 2 - radioCircunscrito() * sF), (float)(picCanvas.Height / 2 - radioCircunscrito() * sF), (float)(2 * radioCircunscrito() * sF), (float)(2 * radioCircunscrito() * sF));
        }
        //dibujar pentagono circunscrito
        public void dibujarPentagonoCircunscrito(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Black);
            //dibuja el pentagono circunscrito
            for (int i = 0; i < 5; i++)
            {
                graph.DrawLine(pen, (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * i / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * i / 5)), (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * (i + 1) / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * (i + 1) / 5)));
            }
        }
        //dibujar pentagono de la estrella de la flor
        public void dibujarPentagonoEstrella(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Red);
            //dibuja el pentagono de la estrella
            for (int i = 0; i < 5; i++)
            {
                graph.DrawLine(pen, (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * i / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * i / 5)), (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * (i + 2) / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * (i + 2) / 5)));
            }
        }
        //dibujar pentagono central de la flor
        public void dibujarPentagonoCentral(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Blue);
            //dibuja el pentagono central sin puntas de la estrella
            for (int i = 0; i < 5; i++)
            {
                graph.DrawLine(pen, (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * i / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * i / 5)), (float)(picCanvas.Width / 2 + radioCircunscrito() * sF * Math.Cos(2 * Math.PI * (i + 1) / 5)), (float)(picCanvas.Height / 2 + radioCircunscrito() * sF * Math.Sin(2 * Math.PI * (i + 1) / 5)));
            }
        }
    }
}
