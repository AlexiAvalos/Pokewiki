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
    public partial class Registro_Objeto : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Registro_Objeto()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardarObj_btn_Click(object sender, EventArgs e)
        {
            // Se crea un nuevo objeto con los inputs del usuario
            objetoR objeto = new objetoR
            {
                Nombre = nombreObj_txt.Text,
                Descripcion = descObj_txt.Text
            };

            // Verificar si hay una celda seleccionada
            if (dataGridViewObj.SelectedCells.Count > 0)
            {
                // Intentar obtener el idObjectoEvolutivo desde la celda seleccionada
                int idObj = dataGridViewObj.CurrentRow.Cells["idObjectoEvolutivo"].Value != null
                    ? Convert.ToInt32(dataGridViewObj.CurrentRow.Cells["idObjectoEvolutivo"].Value)
                    : 0;

               
                if (idObj > 0)
                {
                    objeto.idObjectoEvolutivo = idObj;
                    int result = ObjetoDAL.ModificarObjeto(objeto);

                    if (result > 0)
                    {
                        MessageBox.Show("Objeto modificado exitosamente :D");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al modificar el registro D:");
                    }
                }
                else
                {
                    int result = ObjetoDAL.AgregarObjeto(objeto);

                    if (result > 0)
                    {
                        MessageBox.Show("Objeto guardado exitosamente :D");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar el registro D:");
                    }
                }

                // Recargar los datos en el DataGridView
                recargarData();
            }
            else
            {
                // No hay celdas seleccionadas, por lo tanto, es una nueva inserción
                int result = ObjetoDAL.AgregarObjeto(objeto);

                if (result > 0)
                {
                    MessageBox.Show("Objeto guardado exitosamente :D");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar el registro D:");
                }

                // Recargar los datos en el DataGridView
                recargarData();
            }



        }

        private void Registro_Objeto_Load(object sender, EventArgs e)
        {
            recargarData();
            idObj_txt.Enabled = false;
        }

        public void recargarData()
        {
            dataGridViewObj.DataSource = ObjetoDAL.mostrarRegistroObjetos();
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_btn_Click(object sender, EventArgs e)
        {
            VistaObjetos main = new VistaObjetos();
            main.Show();
            this.Close();
        }

        //cambiar los values de los inputs dependiendo de la seleccion que se haga en el datagrid
        private void dataGridViewObj_SelectionChanged(object sender, EventArgs e)
        {
            idObj_txt.Text = Convert.ToString(dataGridViewObj.CurrentRow.Cells[0].Value);
            nombreObj_txt.Text = Convert.ToString(dataGridViewObj.CurrentRow.Cells[1].Value);
            descObj_txt.Text = Convert.ToString(dataGridViewObj.CurrentRow.Cells[2].Value);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        //para limpiar los inputs que hay en el registro de objetos 
        private void limpiarObj_btn_Click(object sender, EventArgs e)
        {
            idObj_txt.Clear();
            nombreObj_txt.Clear();
            descObj_txt.Clear();
            dataGridViewObj.CurrentCell= null;
        }

        private void eliminarObj_btn_Click(object sender, EventArgs e)
        {
            if (dataGridViewObj.SelectedCells.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewObj.CurrentRow.Cells["idObjectoEvolutivo"].Value);
                int resultado = ObjetoDAL.EliminarObjeto(id);

                if (resultado > 0)
                {
                    MessageBox.Show("Objeto eliminado correctamente :D");
                    recargarData();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar el objeto D:");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un objeto para eliminar.");
            }
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
