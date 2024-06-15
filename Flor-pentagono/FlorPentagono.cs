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

        //coordenadas de los vertices del pentagono interno
        private float[] vF = new float[2];
        private float[] vG = new float[2];
        private float[] vH = new float[2];
        private float[] vI = new float[2];
        private float[] vJ = new float[2];

        //coordenadas de los vertices de los petalos
        private float[] vK = new float[2];
        private float[] vM = new float[2];
        private float[] vN = new float[2];
        private float[] vO = new float[2];
        private float[] vR = new float[2];
        private float[] vS = new float[2];
        private float[] vT = new float[2];
        private float[] vU = new float[2];
        private float[] vV = new float[2];
        private float[] vW = new float[2];


        //constructor vacio
        public FlorPentagono()
        {
            lado = 0;
        }
        public FlorPentagono(float lado)
        {
            this.lado = lado;
            calcularVertices();
            calcularVerticesCentro();
            calcularVerticesPetalos();
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
            pen = new Pen(Color.GreenYellow, 2);
            //calcular las coordenadas de los vertices del pentagono
            calcularVertices();
            //dibujar el pentagono
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vB[0] * sF, vB[1] * sF);
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vC[0] * sF, vC[1] * sF);
            graph.DrawLine(pen, vB[0] * sF, vB[1] * sF, vD[0] * sF, vD[1] * sF);
            graph.DrawLine(pen, vC[0] * sF, vC[1] * sF, vE[0] * sF, vE[1] * sF);
            graph.DrawLine(pen, vD[0] * sF, vD[1] * sF, vE[0] * sF, vE[1] * sF);
        }

        //dibujar estrella
        public void dibujarEstrella(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.OrangeRed, 2);
            //calcular las coordenadas de los vertices del pentagono
            calcularVertices();
            //dibujar la estrella
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vD[0] * sF, vD[1] * sF);
            graph.DrawLine(pen, vA[0] * sF, vA[1] * sF, vE[0] * sF, vE[1] * sF);
            graph.DrawLine(pen, vB[0] * sF, vB[1] * sF, vC[0] * sF, vC[1] * sF);
            graph.DrawLine(pen, vC[0] * sF, vC[1] * sF, vD[0] * sF, vD[1] * sF);
            graph.DrawLine(pen, vB[0] * sF, vB[1] * sF, vE[0] * sF, vE[1] * sF);
        }
        //calcular pendientes 
        public float calcPendiente(float[] p1, float[] p2)
        {
            if (p2[0] - p1[0] != 0)
            {
                return (p2[1] - p1[1]) / (p2[0] - p1[0]);
            }
            else
            {
                Console.WriteLine("La pendiente es infinita");
                return 0;
            }
        }

        //Calcular las coordenadas de los vertices del centro de la flor
        public void calcularVerticesCentro()
        {
            
            //calcular pendientes de las rectas
            //recta AD
            float mAD = calcPendiente(vA, vD);
           
            //recta BC
            float mBC = calcPendiente(vB, vC);
            
            //recta AE
            float mAE = calcPendiente(vA, vE);
            
            //recta CD
            float mCD = calcPendiente(vC, vD);
            
            //recta BE
            float mBE = calcPendiente(vB, vE);
            

            //calcular coordenadas del vertice F
            float yf = (vB[1] - (mBC / mAD) * vA[1] + mBC * vA[0]) / (1 - (mBC / mAD));
            float xf = (yf - vA[1] + mAD * vA[0]) / mAD;
            vF[0] = xf;
            vF[1] = yf;

            //calcular coordenadas del vertice G
            float yg = (vC[1] - (mBC / mAE) * vA[1] + mBC * vA[0]) / (1 - (mBC / mAE));
            float xg = (yg - vA[1] + mAE * vA[0]) / mAE;
            vG[0] = xg;
            vG[1] = yg;

            //calcular coordenadas del vertice H
            float yh = (vB[1] - (mBE / mAD) * vA[1] + mBE * vA[0]) / (1 - (mBE / mAD));
            float xh = (yh - vA[1] + mAD * vA[0]) / mAD;
            vH[0] = xh;
            vH[1] = yh;
        
            //calcular coordenadas del vertice I
            float xi = (vA[1] - vC[1] - mAE * vA[0] + mCD * vC[0]) / (mCD - mAE);
            float yi = vA[1] + mAE * (xi - vA[0]);
            vI[0] = xi;
            vI[1] = yi;

            //calcular coordenadas del vertice J
            float yj = (vB[1] - (mBE / mCD) * vC[1] + mBE * vC[0]) / (1 - (mBE / mCD));
            float xj = (yj - vC[1] + mCD * vC[0]) / mCD;
            vJ[0] = xj;
            vJ[1] = yj;

        }

        //dibujar centro de flor
        public void dibujarCentro(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.Black, 2);
            //calcular las coordenadas de los vertices del centro de la flor
            calcularVerticesCentro();
            //dibujar el centro de la flor
            graph.DrawLine(pen, vF[0] * sF, vF[1] * sF, vG[0] * sF, vG[1] * sF);
            graph.DrawLine(pen, vG[0] * sF, vG[1] * sF, vI[0] * sF, vI[1] * sF);
            graph.DrawLine(pen, vI[0] * sF, vI[1] * sF, vJ[0] * sF, vJ[1] * sF);
            graph.DrawLine(pen, vJ[0] * sF, vJ[1] * sF, vH[0] * sF, vH[1] * sF);
            graph.DrawLine(pen, vH[0] * sF, vH[1] * sF, vF[0] * sF, vF[1] * sF);
        }
        //calcular vertices de los petalos
        public void calcularVerticesPetalos()
        {
            //vertice K
            //recta FJ
            float mFJ = calcPendiente(vF, vJ);
            //recta AB
            float mAB = calcPendiente(vA, vB);
            //calcular coordenadas del vertice K
            float xk = (vA[1] - vF[1] - mAB * vA[0] + mFJ * vF[0]) / (mFJ - mAB);
            float yk = vF[1] + mFJ * (xk - vF[0]);
            vK[0] = xk;
            vK[1] = yk;
            
            //vertice M
            //recta GJ
            float mGJ = calcPendiente(vG, vJ);
            //recta AC
            float mAC = calcPendiente(vA, vC);
            //calcular coordenadas del vertice M
            float xm = (vA[1] - vG[1] - mAC * vA[0] + mGJ * vG[0]) / (mGJ - mAC);
            float ym = vG[1] + mGJ * (xm - vG[0]);
            vM[0] = xm;
            vM[1] = ym;


            //vertice N
            //recta GH
            float mGH = calcPendiente(vG, vH);
            //recta AC
            //calcular coordenadas del vertice N
            float xn = (vC[1] - vG[1] - mAC * vC[0] + mGH * vG[0]) / (mGH - mAC);
            float yn = vG[1] + mGH * (xn - vG[0]);
            vN[0] = xn;
            vN[1] = yn;

            //Vertice O
            //recta HI
            float mHI = calcPendiente(vH, vI);
            //recta CE
            float mCE = calcPendiente(vC, vE);
            //calcular coordenadas del vertice O
            float xo = (vC[1] - vH[1] - mCE * vC[0] + mHI * vH[0]) / (mHI - mCE);
            float yo = vH[1] + mHI * (xo - vH[0]);
            vO[0] = xo;
            vO[1] = yo;

            //Vertice R
            //recta FI
            float mFI = calcPendiente(vF, vI);
            //recta CE
            //calcular coordenadas del vertice R
            float xr = (vC[1] - vF[1] - mCE * vC[0] + mFI * vF[0]) / (mFI - mCE);
            float yr = vF[1] + mFI * (xr - vF[0]);
            vR[0] = xr;
            vR[1] = yr;

            //Vertice S
            //recta FJ
            //recta DE
            float mDE = calcPendiente(vD, vE);
            //calcular coordenadas del vertice S
            float xs = (vD[1] - vF[1] - mDE * vD[0] + mFJ * vF[0]) / (mFJ - mDE);
            float ys = vF[1] + mFJ * (xs - vF[0]);
            vS[0] = xs;
            vS[1] = ys;

            //Vertice T
            //recta GJ
            //recta DE
            //calcular coordenadas del vertice T
            float xt = (vD[1] - vG[1] - mDE * vD[0] + mGJ * vG[0]) / (mGJ - mDE);
            float yt = vG[1] + mGJ * (xt - vG[0]);
            vT[0] = xt;
            vT[1] = yt;

            //Vertice U
            //recta GH
            //recta BD
            float mBD = calcPendiente(vB, vD);
            //calcular coordenadas del vertice U
            float xu = (vB[1] - vG[1] - mBD * vB[0] + mGH * vG[0]) / (mGH - mBD);
            float yu = vG[1] + mGH * (xu - vG[0]);
            vU[0] = xu;
            vU[1] = yu;

            //Vertice V
            //recta HI
            //recta BD
            //calcular coordenadas del vertice V
            float xv = (vB[1] - vH[1] - mBD * vB[0] + mHI * vH[0]) / (mHI - mBD);
            float yv = vH[1] + mHI * (xv - vH[0]);
            vV[0] = xv;
            vV[1] = yv;

            //Vertice W
            //recta FI
            //recta AB
            //calcular coordenadas del vertice W
            float xw = (vA[1] - vF[1] - mAB * vA[0] + mFI * vF[0]) / (mFI - mAB);
            float yw = vF[1] + mFI * (xw - vF[0]);
            vW[0] = xw;
            vW[1] = yw;
            
        }
        //dibujar petalos
        public void dibujarPetalos(PictureBox picCanvas)
        {
            //crea un objeto de la clase Graphics
            graph = picCanvas.CreateGraphics();
            //crea un objeto de la clase Pen
            pen = new Pen(Color.DarkCyan, 2);
            //calcular las coordenadas de los vertices de los petalos
            calcularVerticesPetalos();
            //dibujar los petalos
            graph.DrawLine(pen, vF[0] * sF, vF[1] * sF, vK[0] * sF, vK[1] * sF);
            graph.DrawLine(pen, vG[0] * sF, vG[1] * sF, vM[0] * sF, vM[1] * sF);
            graph.DrawLine(pen, vG[0] * sF, vG[1] * sF, vN[0] * sF, vN[1] * sF);
            graph.DrawLine(pen, vI[0] * sF, vI[1] * sF, vO[0] * sF, vO[1] * sF);
            graph.DrawLine(pen, vI[0] * sF, vI[1] * sF, vR[0] * sF, vR[1] * sF);
            graph.DrawLine(pen, vJ[0] * sF, vJ[1] * sF, vS[0] * sF, vS[1] * sF);
            graph.DrawLine(pen, vJ[0] * sF, vJ[1] * sF, vT[0] * sF, vT[1] * sF);
            graph.DrawLine(pen, vH[0] * sF, vH[1] * sF, vU[0] * sF, vU[1] * sF);
            graph.DrawLine(pen, vH[0] * sF, vH[1] * sF, vV[0] * sF, vV[1] * sF);
            graph.DrawLine(pen, vF[0] * sF, vF[1] * sF, vW[0] * sF, vW[1] * sF);
        }

    }
}
