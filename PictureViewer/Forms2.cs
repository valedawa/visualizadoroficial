using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Forms2 : Form
    {
        Image imgOriginal;
        
        public Forms2()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the Stretch check box, 

            // SizeMode nos sirve como propiedad para ajustarla al tamaño de la ventana dependiendo de como se utilice
            if (checkBox1.Checked)//si esta es checked ajustara la imagen
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;// cambia el formato de la imagen subida en picture box
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;// si la casilla no esta checked esta permanecera segun como este ajustada

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // este bton tiene las funcion de cerrar el formulario usado
            this.Close();// close == cierra o cerrar
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;// el termino null hacer referencia a que hace nulo algun objeto 
            // y limpia las cajas de imagenes 
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Este muestra el color deseado por el usuario 
            // Dentro de la caja de imagenes 
            if (colorDialog1.ShowDialog() == DialogResult.OK) //si ok despues de seleccionar el color se presionan
                pictureBox1.BackColor = colorDialog1.Color;// se hara un cambio de color
        }

        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void showButton_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//este tiene una propiedad que se llama filter 
                                                                // la cuál nos ayuda a mostrar las imagenes atravez de la caja de imagenes
            {
                pictureBox1.Load(openFileDialog1.FileName);
                // una vez que esta opcion se complete poder visualizar las imagenes
                imgOriginal = pictureBox1.Image;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                pictureBox1.Image = Zoom(imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
            }
        }
    }
}
