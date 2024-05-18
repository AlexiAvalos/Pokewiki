using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public class PokemonPanelTipos : Panel
    {
        private string _nombreTipo;

        public string NombreTipo
        {
            get { return _nombreTipo; }
            set
            {
                _nombreTipo = value;
                Invalidate(); 
            }
        }

        public event EventHandler TipoSeleccionado;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           
            using (var brush = new SolidBrush(Color.Black))
            {
                var x = 5;
                var y = (Height - (int)e.Graphics.MeasureString(_nombreTipo, Font).Height) / 2;
                e.Graphics.DrawString(_nombreTipo, Font, brush, new Point(x, y));
            }
        }

        public PokemonPanelTipos()
        {
          
            Size = new Size(112, 41);

           
            BackgroundImage = Properties.Resources.panel; 
            BackgroundImageLayout = ImageLayout.Stretch;

            
            BackColor = Color.Transparent;

            
            BackColor = Color.White;

            Font = new Font("Rockwell Condensed", 11.25f, FontStyle.Bold);



            Click += PokemonPanelTipos_Click;
        }

        private void PokemonPanelTipos_Click(object sender, EventArgs e)
        {
            
            TipoSeleccionado?.Invoke(this, e);
        }
    }
}
