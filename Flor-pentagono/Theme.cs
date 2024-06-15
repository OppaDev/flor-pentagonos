using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flor_pentagono
{
    internal class Theme
    {
        private Form _form;

        public Theme(Form form)
        {
            _form = form;
        }
        public void dark()
        {
            Color colorDominante = Color.Black;
            Color colorSecundario = System.Drawing.SystemColors.MenuHighlight;

            _form.BackColor = colorDominante;
            _form.ForeColor = colorSecundario;

            foreach (Control control in _form.Controls)
            {
                ApplyThemeToControl(control, colorDominante, colorSecundario);
            }
        }

        public void light()
        {
            Color colorDominante = Color.White;
            Color colorSecundario = System.Drawing.SystemColors.Highlight;

            _form.BackColor = colorDominante;
            _form.ForeColor = colorSecundario;

            foreach (Control control in _form.Controls)
            {
                ApplyThemeToControl(control, colorDominante, colorSecundario);
            }
        }

        private void ApplyThemeToControl(Control control, Color colorDominante, Color colorSecundario)
        {
            if (control is Panel || control is GroupBox)
            {
                // Recursivamente aplicar modo oscuro a los controles hijos
                foreach (Control childControl in control.Controls)
                {
                    ApplyThemeToControl(childControl, colorDominante, colorSecundario);
                }
            }

            control.BackColor = colorDominante;
            control.ForeColor = colorSecundario;
        }
    }
}
