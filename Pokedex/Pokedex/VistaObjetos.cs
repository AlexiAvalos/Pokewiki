using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Pokedex.PokemonPanelObjetos;

namespace Pokedex
{
    public partial class VistaObjetos : Form
    {
        private ObjetoEvolutivoDAO objetoEvolutivoDAO;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
     

        public VistaObjetos()
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
            objetoEvolutivoDAO = new ObjetoEvolutivoDAO(connectionString);
            MostrarObjetosEvolutivos();
        }

        private void MostrarObjetosEvolutivos()
        {
            List<string> nombresObjetosEvolutivos = objetoEvolutivoDAO.ObtenerNombresObjetosEvolutivos();

            foreach (string nombreObjetoEvolutivo in nombresObjetosEvolutivos)
            {
                PokemonPanelObjetos objetoPanel = new PokemonPanelObjetos();
                objetoPanel.NombreObjetoEvolutivo = nombreObjetoEvolutivo;
                objetoPanel.Margin = new Padding(10);
                flowLayoutPanel1.Controls.Add(objetoPanel);

                // Suscribirse al evento de clic de cada panel
                objetoPanel.Click += (sender, e) =>
                {
                    PokemonPanelObjetos panel = (PokemonPanelObjetos)sender;
                    string nombre = panel.NombreObjetoEvolutivo;

                    // Obtener el objeto ObjetoEvolutivo correspondiente al nombre
                    ObjetoEvolutivo objetoEvolutivo = objetoEvolutivoDAO.ObtenerObjetoEvolutivoPorNombre(nombre);

                    // Mostrar los detalles del ObjetoEvolutivo seleccionado
                    ObjetosDetalle objetoDetalleForm = new ObjetosDetalle(objetoEvolutivo);
                    objetoDetalleForm.Show();
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

        private void registroObj_btn_Click(object sender, EventArgs e)
        {
            Form registroObj = new Registro_Objeto();
            registroObj.Show();
            this.Close();
        }

        private void VistaObjetos_FormClosed(object sender, FormClosedEventArgs e)
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

