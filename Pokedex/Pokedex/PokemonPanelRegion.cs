using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
{
    public class PokemonPanelRegiones : Panel
    {
        private string _nombreRegion;

        public string NombreRegion
        {
            get { return _nombreRegion; }
            set
            {
                _nombreRegion = value;
                Invalidate();
            }
        }

        public event EventHandler RegionSeleccionada;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           
            using (var brush = new SolidBrush(Color.Black))
            {
                var x = 5;
                var y = (Height - (int)e.Graphics.MeasureString(_nombreRegion, Font).Height) / 2; 
                e.Graphics.DrawString(_nombreRegion, Font, brush, new Point(x, y));
            }
        }

        public PokemonPanelRegiones()
        {
            
            Size = new Size(112, 41);

           
            BackgroundImage = Properties.Resources.panel;
            BackgroundImageLayout = ImageLayout.Stretch;

            
            BackColor = Color.Transparent;

           
            BackColor = Color.White;


            Font = new Font("Rockwell Condensed", 11.25f, FontStyle.Bold);


            Click += PokemonPanelRegiones_Click;
        }

        private void PokemonPanelRegiones_Click(object sender, EventArgs e)
        {
            
            RegionSeleccionada?.Invoke(this, e);
        }
    }
}
