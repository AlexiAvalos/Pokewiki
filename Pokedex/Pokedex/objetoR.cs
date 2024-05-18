using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class objetoR
    {
        public int idObjectoEvolutivo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
       


        public objetoR() { } 
        public objetoR( int idObjectoEvolutivo, string Nombre, string Descripcion)
        {
            this.idObjectoEvolutivo = idObjectoEvolutivo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
         
        }
    }
}
