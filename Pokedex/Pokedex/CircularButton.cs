using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public class CircularButton : Button
    {
        public CircularButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = Properties.Resources.OIP;
            this.Size = new Size(40, 40); // Tamaño predeterminado
            this.Cursor = Cursors.Hand;
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            this.Region = new Region(path);

            if (Image != null)
            {
                int x = (this.Width - Image.Width) / 2;
                int y = (this.Height - Image.Height) / 2;
                e.Graphics.DrawImage(Image, x, y);
            }
        }

        public void SetImageFromResource(string resourceName)
        {
            Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
        }
    }
}
