using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public class PokemonPanelObjetos : Panel
    {
        private string _nombreObjetoEvolutivo;

        public string NombreObjetoEvolutivo
        {
            get { return _nombreObjetoEvolutivo; }
            set
            {
                _nombreObjetoEvolutivo = value;
                Invalidate(); 
            }
        }

        public event EventHandler ObjetoEvolutivoSeleccionado;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           
            using (var brush = new SolidBrush(Color.Black))
            {
                var x = 5;
                var y = (Height - (int)e.Graphics.MeasureString(_nombreObjetoEvolutivo, Font).Height) / 2; 
                e.Graphics.DrawString(_nombreObjetoEvolutivo, Font, brush, new Point(x, y));
            }
        }

        public PokemonPanelObjetos()
        {
            
            Size = new Size(112, 41);

           
            BackgroundImage = Properties.Resources.panel; 
            BackgroundImageLayout = ImageLayout.Stretch;

           
            BackColor = Color.Transparent;

            
            BackColor = Color.White;


            Font = new Font("Rockwell Condensed", 11.25f, FontStyle.Bold);



            Click += PokemonPanelObjetos_Click;
        }

        private void PokemonPanelObjetos_Click(object sender, EventArgs e)
        {
            
            ObjetoEvolutivoSeleccionado?.Invoke(this, e);
        }
    }
}
