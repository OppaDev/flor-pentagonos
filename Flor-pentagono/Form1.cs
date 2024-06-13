using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flor_pentagono
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            //valida que el lado sea un numero positivo
            if (Validaciones.ladoPositivo(txtLado.Text))
            {
                //crea un objeto de la clase FlorPentagono
                FlorPentagono flor = new FlorPentagono(Convert.ToDouble(txtLado.Text));
                if (Convert.ToDouble(txtLado.Text) >= 30)
                {
                    flor.setSF(5);
                }                
                //dibuja el circulo circunscrito
                flor.dibujarCirculoCircunscrito(picCanvas);
                //dibuja el pentagono circunscrito
                flor.dibujarPentagonoCircunscrito(picCanvas);
                //dibujar pentagono central de la flor
                flor.dibujarPentagonoEstrella(picCanvas);
                //dibujar pentagono central de la flor
                flor.dibujarPentagonoCentral(picCanvas);
            }
            else
            {
                MessageBox.Show("El lado debe ser un numero positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpia el PictureBox
            picCanvas.Refresh();
            //limpia el TextBox
            txtLado.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //cierra la aplicacion
            Application.Exit();
        }
    }
}
