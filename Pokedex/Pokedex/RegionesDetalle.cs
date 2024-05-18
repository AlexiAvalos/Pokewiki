using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class RegionesDetalle : Form
    {
        private Regiones region;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public RegionesDetalle(Regiones region)
        {
            InitializeComponent();

            // Movilidad Del Form No Tocar Delicado
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;


            //Background Invisible No Tocar
            this.TransparencyKey = Color.Magenta;
            this.BackColor = Color.Magenta;
            this.StartPosition = FormStartPosition.CenterScreen;
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxImagen.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(region.Nombre);
            pictureBoxImagen.Size = new Size(298, 254);

            this.region = region;
            MostrarDescripcion();
        }

        private void MostrarDescripcion()
        {
            lblNombre.Text = region.Nombre;
            lblDescripcion.Text = region.Descripcion;
        }

        private void B_btn_Click(object sender, EventArgs e)
        {
            VistaRegion menuRgn = new VistaRegion();
            menuRgn.Show();
            this.Close();
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
