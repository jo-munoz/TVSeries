using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class ActorActriz   //Datos de los atores
    {
        public int IdActor { get; set; }
        public string Nombre { get; set; }
        public string UrlIMDB { get; set; }
        public int Nacionalidad { get; set; }

        //constructor
        public ActorActriz(int IdActor, string Nombre, string UrlIMDB, int Nacionalidad)
        {
            this.IdActor = IdActor;
            this.Nombre = Nombre;
            this.UrlIMDB = UrlIMDB;
            this.Nacionalidad = Nacionalidad;
        }
    }
}