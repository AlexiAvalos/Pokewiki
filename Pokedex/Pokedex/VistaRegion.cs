using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Pokedex.PokemonPanelRegiones;

namespace Pokedex
{
    public partial class VistaRegion : Form
    {
        private RegionDAO regionDAO;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        

        public VistaRegion()
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
            regionDAO = new RegionDAO(connectionString);
            MostrarRegiones();
        }

        private void MostrarRegiones()
        {
            List<string> nombresRegiones = regionDAO.ObtenerNombresRegiones();

            foreach (string nombreRegion in nombresRegiones)
            {
                PokemonPanelRegiones regionPanel = new PokemonPanelRegiones();
                regionPanel.NombreRegion = nombreRegion;
                regionPanel.Margin = new Padding(10);
                flowLayoutPanel1.Controls.Add(regionPanel);

                regionPanel.Click += (sender, e) =>
                {
                    PokemonPanelRegiones panel = (PokemonPanelRegiones)sender;
                    string nombre = panel.NombreRegion;

                    
                    Regiones regiones = regionDAO.ObtenerRegionPorNombre(nombre);

                    
                    RegionesDetalle regionDetalleForm = new RegionesDetalle(regiones);
                    regionDetalleForm.Show();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void registroReg_btn_Click(object sender, EventArgs e)
        {
            Form registroRegiones = new RegistroRegion();
            registroRegiones.Show();
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
