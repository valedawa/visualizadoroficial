using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class Formmenu : Form
    {
        public Formmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter Escribe = new StreamWriter("Test.txt"); 
            Escribe.WriteLine("Hola a todos de parte de TB"); 
            Escribe.Close();

            StreamWriter agregar = File.AppendText("Test.txt"); 
            agregar.WriteLine("Nueva Linea agregada!"); 
            agregar.Close();

            MessageBox.Show("Listo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextReader leer = new StreamReader("Test.txt");
            MessageBox.Show(leer.ReadLine());
            MessageBox.Show(leer.ReadToEnd());

            leer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            creditos cre = new creditos();
            cre.Show();
        }
    }
}
