using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Pokedex.PokemonPanelTipos;

namespace Pokedex
{
    public partial class VistaTipos : Form
    {
        private TipoDAO tipoDAO;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        

        public VistaTipos()
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
            string connectionString = "Data Source=DESKTOP-UBBP1OB\\NICO;Initial Catalog=PokeWiki;Integrated Security=True";
            tipoDAO = new TipoDAO(connectionString);
            MostrarTipos();
        }

        private void MostrarTipos()
        {
            List<string> nombresTipos = tipoDAO.ObtenerNombresTipos();

            foreach (string nombreTipo in nombresTipos)
            {
                PokemonPanelTipos tipoPanel = new PokemonPanelTipos();
                tipoPanel.NombreTipo = nombreTipo;
                tipoPanel.Margin = new Padding(10);
                flowLayoutPanel1.Controls.Add(tipoPanel);

                
                tipoPanel.Click += (sender, e) =>
                {
                    PokemonPanelTipos panel = (PokemonPanelTipos)sender;
                    string nombre = panel.NombreTipo;

                   
                    Tipo tipo = tipoDAO.ObtenerTipoPorNombre(nombre);

                    
                    TiposDetalle tipoDetalleForm = new TiposDetalle(tipo);
                    tipoDetalleForm.Show();
                    this.Hide();
                };
            }
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
