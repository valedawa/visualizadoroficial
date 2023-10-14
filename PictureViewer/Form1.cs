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
    public partial class Form1 : Form
    {
        Image imgOriginal;
        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)// nombre de show button es el que tien el control de poder
            // mostrar las imagenes de cualquier tipo de formato
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//este tiene una propiedad que se llama filter 
                // la cuál nos ayuda a mostrar las imagenes atravez de la caja de imagenes
            {
                pictureBox1.Load(openFileDialog1.FileName);
                // una vez que esta opcion se complete poder visualizar las imagenes
                imgOriginal = pictureBox1.Image;
            }
            
        }

        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void clearButton_Click(object sender, EventArgs e)// este botn tiene la función de que una vez agregadas las imagenes
            //poder eliminarlas para poder seguir visualisando más
        {
            pictureBox1.Image = null;// el termino null hacer referencia a que hace nulo algun objeto 
            // y limpia las cajas de imagenes 
        }

        private void backgroundButton_Click(object sender, EventArgs e) // este boton tiene como funcion
            //ayudar a establecer algun color de fondo atras de las imagenes 
        {
            // Este muestra el color deseado por el usuario 
            // Dentro de la caja de imagenes 
            if (colorDialog1.ShowDialog() == DialogResult.OK) //si ok despues de seleccionar el color se presionan
                pictureBox1.BackColor = colorDialog1.Color;// se hara un cambio de color
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // este bton tiene las funcion de cerrar el formulario usado
            this.Close();// close == cierra o cerrar
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            // If the user selects the Stretch check box, 

            // SizeMode nos sirve como propiedad para ajustarla al tamaño de la ventana dependiendo de como se utilice
            if (checkBox1.Checked)//si esta es checked ajustara la imagen
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;// cambia el formato de la imagen subida en picture box
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;// si la casilla no esta checked esta permanecera segun como este ajustada
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menosbutton_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(trackBar1.Value > 0)
            {
                pictureBox1.Image = Zoom (imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms2 f2 = new Forms2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formmenu menu = new Formmenu();
            menu.Show();
        }
    }
}
