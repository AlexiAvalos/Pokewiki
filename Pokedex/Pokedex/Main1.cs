using System;
using System.Windows.Forms;
using System.Drawing;

namespace Pokedex
{
    public partial class Main1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Main1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TransparencyKey = Color.Magenta;
            // Suscribir al evento MouseDown del PictureBox para iniciar el arrastre
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;

            this.BackColor = Color.Magenta;

        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        //no moverle que se rompe
        private void rjButton8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            VistaPokemon vistaPokemon = new VistaPokemon();
            vistaPokemon.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VistaRegion vistaRegion = new VistaRegion();
            vistaRegion.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            VistaObjetos vistaObjetos = new VistaObjetos();
            vistaObjetos.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            VistaTipos vistaTipo = new VistaTipos();
            vistaTipo.Show();
            this.Hide();
        }

        private void Main1_Load(object sender, EventArgs e)
        {

        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

