using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public class PokemonPanelNames : Panel
    {
        private string _nombrePokemon;

        public string NombrePokemon
        {
            get { return _nombrePokemon; }
            set
            {
                _nombrePokemon = value;
                Invalidate();
            }
        }

        public event EventHandler PokemonSeleccionado;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            
            using (var brush = new SolidBrush(Color.Black))
            {
             
                var x = 5;
                var y = (Height - (int)e.Graphics.MeasureString(_nombrePokemon, Font).Height) / 2; 
                e.Graphics.DrawString(_nombrePokemon, Font, brush, new Point(x, y));
            }
        }

        public PokemonPanelNames()
        {
            
            Size = new Size(112, 41);

            BackgroundImage = Properties.Resources.panel; 
            BackgroundImageLayout = ImageLayout.Stretch;

            
            BackColor = Color.Transparent;

            
            BackColor = Color.White;

            Font = new Font("Rockwell Condensed", 11.25f, FontStyle.Bold);



            Click += PokemonPanelNames_Click;
        }

        private void PokemonPanelNames_Click(object sender, EventArgs e)
        {
           
            PokemonSeleccionado?.Invoke(this, e);
        }
     
    }
}
