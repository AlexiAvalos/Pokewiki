using AForge.Imaging;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class PokemonDetalle : Form
    {
        private Pokemon pokemon;
        private Label lblNombrePokemon;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public PokemonDetalle(Pokemon pokemon)
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
            this.pokemon = pokemon;
            MostrarDescripcion(); 
        }

        private void MostrarDescripcion()
        {
            OcultarTodosLosPaneles();
            panelDescripcion2.Visible = true;
            lblDescripcion.Text = pokemon.Descripcion;

            
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImagen.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(pokemon.Nombre);
            pictureBoxImagen.Size = new Size(298, 254);

            
            lblNombrePokemon.Text = $"{pokemon.Nombre}";
        }

        private void MostrarAtributos()
        {
            OcultarTodosLosPaneles();
            panelAtributos.Visible = true;
            lblSalud.Text = $"Salud: {pokemon.Salud}";
            lblAltura.Text = $"Altura: {pokemon.Altura}";
            lblAtaque.Text = $"Ataque: {pokemon.Ataque}";
            lblDefensa.Text = $"Defensa: {pokemon.Defensa}";
        }

        private void MostrarTipoYCategoria()
        {
            OcultarTodosLosPaneles();
            panelTipoCategoria.Visible = true;
            lblTipo.Text = $"Tipo: {pokemon.Tipo}";
        }

        private void MostrarGeneracion()
        {
            OcultarTodosLosPaneles();
            panelGeneracion.Visible = true;
            lblGeneracion.Text = $"Generación: {pokemon.Generacion}";
            lblHabitat.Text = $"Habitat: {pokemon.Habitat}";
        }

        private void OcultarTodosLosPaneles()
        {
            panelDescripcion2.Visible = false;
            panelAtributos.Visible = false;
            panelTipoCategoria.Visible = false;
            panelGeneracion.Visible = false;
        }

        private void n1_btn_Click(object sender, EventArgs e)
        {
            MostrarDescripcion();
        }

        private void n2_btn_Click(object sender, EventArgs e)
        {
            MostrarAtributos();
        }

        private void n3_btn_Click(object sender, EventArgs e)
        {
            MostrarTipoYCategoria();
        }

        private void n4_btn_Click(object sender, EventArgs e)
        {
            MostrarGeneracion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelGeneracion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void B_btn_Click(object sender, EventArgs e)
        {
            VistaPokemon menuPkmn = new VistaPokemon();
            menuPkmn.Show();
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
