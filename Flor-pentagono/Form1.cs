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
        public Color selectedColor;
        public bool darkModeEnable = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            //valida que el lado sea un numero positivo
            if (Validaciones.ladoPositivo(txtLado.Text))
            {
                if (Validaciones.mayorAlVisible(txtLado.Text))
                {
                    MessageBox.Show("La flor no será completamente visible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //limpia el PictureBox
                picCanvas.Refresh();
                //crea un objeto de la clase FlorPentagono
                FlorPentagono flor = new FlorPentagono(Convert.ToSingle(txtLado.Text));
                //dibuja el pentagono
                //flor.dibujarPentagono(picCanvas);
                //dibujar estrella
                //flor.dibujarEstrella(picCanvas);
                //flor.dibujarCentro(picCanvas);
                //flor.dibujarPetalos(picCanvas);
                flor.dibujarFlor(picCanvas, selectedColor, darkModeEnable);

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

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                pnlColorSelected.BackColor = selectedColor;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(darkModeEnable)
            {
                darkModeEnable = false;
                Theme theme = new Theme(this);
                theme.light();
                darkMode.Text = "🌙";
                pnlColorSelected.BackColor = selectedColor;
            }
            else
            {
                darkModeEnable = true;
                Theme theme = new Theme(this);
                theme.dark();
                darkMode.Text = "☀️";
                pnlColorSelected.BackColor = selectedColor;
            }

        }
    }
}
