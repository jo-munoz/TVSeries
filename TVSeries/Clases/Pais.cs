using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class Pais  //Datos de los atores
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }

        //constructor
        public Pais(int IdPais, string Nombre)
        {
            this.IdPais = IdPais;
            this.Nombre = Nombre;
        }
    }
}