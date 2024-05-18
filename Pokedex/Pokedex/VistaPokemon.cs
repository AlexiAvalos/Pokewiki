using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class VistaPokemon : Form
    {
        private PokemonDAO pokemonDAO;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        

        public VistaPokemon()
        {
            InitializeComponent();
            //Background Invisible No Tocar
            this.TransparencyKey = Color.Magenta;
            this.BackColor = Color.Magenta;

            // Movilidad Del Form No Tocar Delicado
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;

            this.StartPosition = FormStartPosition.CenterScreen;
            string connectionString = "Data Source=DESKTOP-UBBP1OB\\NICO;Initial Catalog=PokeWiki;Integrated Security=True";
            pokemonDAO = new PokemonDAO(connectionString);
            MostrarPokemones();
        }

        private void MostrarPokemones()
        {
            List<string> nombresPokemon = pokemonDAO.ObtenerNombresPokemon();

            foreach (string nombrePokemon in nombresPokemon)
            {
                PokemonPanelNames pokemonPanel = new PokemonPanelNames();
                pokemonPanel.NombrePokemon = nombrePokemon;
                pokemonPanel.Margin = new Padding(10);
                flowLayoutPanel1.Controls.Add(pokemonPanel);

               
                pokemonPanel.Click += (sender, e) =>
                {
                    PokemonPanelNames panel = (PokemonPanelNames)sender;
                    string nombre = panel.NombrePokemon;

                   
                    Pokemon pokemon = pokemonDAO.ObtenerPokemonPorNombre(nombre);

                   
                    PokemonDetalle pokemonDetalleForm = new PokemonDetalle(pokemon);
                    pokemonDetalleForm.Show();
                    this.Hide();
                };
            }
        }

        //no moverle que se rompe
        private void rjButton8_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void B_btn_Click(object sender, EventArgs e)
        {
            Main1 main = new Main1();
            main.Show();
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