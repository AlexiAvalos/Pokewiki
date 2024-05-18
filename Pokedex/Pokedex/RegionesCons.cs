using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class RegionesCons
    {
        public int idRegion { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public RegionesCons() { }


































        public RegionesCons(int idRegion, string Nombre, string Descripcion)
        {
            this.idRegion = idRegion;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }   
    }
}
