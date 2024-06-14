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
        private float lado;
        //objeto de la clase Graphics
        private Graphics graph;
        //objeto de la clase Pen
        private Pen pen;
        //scale factor (Zoom In/Zoom Out)
        private static int sF = 10;

        //coordenadas de los vertices del pentagono        
        private float[] vA = new float[2];
        private float[] vB = new float[2];
        private float[] vC = new float[2];
        private float[] vD = new float[2];
        private float[] vE = new float[2];


        //constructor vacio
        public FlorPentagono()
        {
            lado = 0;
        }
        public FlorPentagono(float lado)
        {
            this.lado = lado;
        }

        //getters y setters
        public float getLado()
        {
            return lado;
        }
        public void setLado(float lado)
        {
            this.lado = lado;
        }
        //calcular las coordenadas de los vertices del pentagono
        public void calcularVertices()
        {
            //vertice A
            vA[0] = lado * (float) Math.Cos(Math.PI / 5);
            vA[1] = 0;
            //vertice B
            vB[0] = 0;
            vB[1] = lado * (float) Math.Sin(Math.PI / 5);
            //vertice C
            vC[0] = 2 * lado * (float) Math.Cos(Math.PI / 5);
            vC[1] = lado * (float) Math.Sin(Math.PI / 5);
            //vertice D
            vD[0] = lado * (float)Math.Sin(Math.PI / 10);
            vD[1] = lado * (float)(Math.Sin(Math.PI / 5) + Math.Cos(Math.PI / 10));
            //vertice E
            vE[0] = lado * (float) (Math.Sin(Math.PI / 10) + 1);
            vE[1] = lado * (float)(Math.Sin(Math.PI / 5) + Math.Cos(Math.PI / 10));
        }

        //dibujar el pentagono
        public void dibujarPentagono(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Black, 2);
            //calcular las coordenadas de los vertices del pentagono
            calcularVertices();
            //dibujar el pentagono
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vB[0] * sF, vB[1] * sF);
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vC[0] * sF, vC[1] * sF);
            graph.DrawLine(pen, vB[0] * sF, vB[1] * sF, vD[0] * sF, vD[1] * sF);
            graph.DrawLine(pen, vC[0] * sF, vC[1] * sF, vE[0] * sF, vE[1] * sF);
            graph.DrawLine(pen, vD[0] * sF, vD[1] * sF, vE[0] * sF, vE[1] * sF);
        }


    }
}
