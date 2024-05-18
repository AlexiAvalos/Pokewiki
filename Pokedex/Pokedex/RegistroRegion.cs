using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class RegistroRegion : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        

        public RegistroRegion()
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

            
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void Registro_Objeto_Load(object sender, EventArgs e)
        {
            recargarData();
        }

        public void recargarData()
        {
            //pasarle datos al datagrid
            dataGridViewReg.DataSource = RegionesDAL.mostrarRegistroRegiones();
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_btn_Click(object sender, EventArgs e)
        {
            VistaRegion main = new VistaRegion();
            main.Show();
            this.Close();
        }

        private void guardarReg_btn_Click(object sender, EventArgs e)
        {
            RegionesCons region = new RegionesCons
            {
                Nombre = nombreReg_txt.Text,
                Descripcion = descReg_txt.Text
            };

            // Verificar si hay una celda seleccionada
            if (dataGridViewReg.SelectedCells.Count > 0)
            {
                // Intentar obtener el idRegion desde la celda seleccionada
                if (dataGridViewReg.CurrentRow.Cells["idRegion"].Value != null)
                {
                    int idReg = Convert.ToInt32(dataGridViewReg.CurrentRow.Cells["idRegion"].Value);
                    region.idRegion = idReg;

                    int result = RegionesDAL.ModificarRegion(region);

                    if (result > 0)
                    {
                        MessageBox.Show("Región modificada exitosamente :D");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al modificar la región D:");
                    }
                }
                else
                {
                    // No hay un idRegion seleccionado, por lo tanto, es una nueva región
                    int result = RegionesDAL.AgregarRegion(region);

                    if (result > 0)
                    {
                        MessageBox.Show("Región guardada exitosamente :D");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar la región D:");
                    }
                }

                recargarData();
            }
            else
            {
                // No hay celdas seleccionadas, por lo tanto, es una nueva región
                int result = RegionesDAL.AgregarRegion(region);

                if (result > 0)
                {
                    MessageBox.Show("Región guardada exitosamente :D");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar la región D:");
                }

                recargarData();
            }


        }

        private void dataGridViewReg_SelectionChanged(object sender, EventArgs e)
        {
            idReg_txt.Text = Convert.ToString(dataGridViewReg.CurrentRow.Cells[0].Value);
            nombreReg_txt.Text = Convert.ToString(dataGridViewReg.CurrentRow.Cells[1].Value);
            descReg_txt.Text = Convert.ToString(dataGridViewReg.CurrentRow.Cells[2].Value);
        }

        private void eliminarReg_btn_Click(object sender, EventArgs e)
        {
            if (dataGridViewReg.SelectedCells.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewReg.CurrentRow.Cells["idRegion"].Value);
                int resultado = RegionesDAL.EliminarRegion(id);

                if (resultado > 0)
                {
                    MessageBox.Show("Region eliminada correctamente :D");
                    recargarData();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar la region D:");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una región para eliminar.");
            }
        }

        private void limpiarObj_btn_Click(object sender, EventArgs e)
        {
            idReg_txt.Clear();
            nombreReg_txt.Clear();
            descReg_txt.Clear();
            dataGridViewReg.CurrentCell = null;
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

        private void RegistroRegion_Load_1(object sender, EventArgs e)
        {
            recargarData();
            idReg_txt.Enabled = false;
        }
    }

}
