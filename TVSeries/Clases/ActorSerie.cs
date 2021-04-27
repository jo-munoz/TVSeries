using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//relaciona un actor a una serie de televisìón
namespace TVSeries.Clases
{
    class ActorSerie
    {
        public int CodigoActor { get; set; }
        public int CodigoSerie { get; set; }

        public ActorSerie(int CodigoActor, int CodigoSerie)
        {
            this.CodigoActor = CodigoActor;
            this.CodigoSerie = CodigoSerie;
        }
    }
}