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
                //limpia el PictureBox
                picCanvas.Refresh();
                //crea un objeto de la clase FlorPentagono
                FlorPentagono flor = new FlorPentagono(Convert.ToSingle(txtLado.Text));
                //dibuja el pentagono
                flor.dibujarPentagono(picCanvas);

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
