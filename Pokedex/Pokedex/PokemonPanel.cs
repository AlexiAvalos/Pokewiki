using System.Drawing;
using System.Windows.Forms;

namespace Pokedex
    //NoMoverNada
{
    public class PokemonPanel : Panel
    {
        public PokemonPanel()
        {
            this.Size = new Size(300, 200);

            
            this.BackgroundImage = Properties.Resources.panel; 

            
            this.BackgroundImageLayout = ImageLayout.Stretch;

           
            this.Location = new Point(50, 50);

            
            this.BackColor = Color.Transparent;
        }
    }
}
