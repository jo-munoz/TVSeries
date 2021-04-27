using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class Serie //Datos de los atores
    {
        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string UrlIMDB { get; set; }

        //constructor
        public Serie(int IdSerie, string Nombre, string UrlIMDB)
        {
            this.IdSerie = IdSerie;
            this.Nombre = Nombre;
            this.UrlIMDB = UrlIMDB;
        }
    }
}