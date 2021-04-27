using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class SeriePais
    {        
        public int CodigoSerie { get; set; }
        public int CodigoPais { get; set; }

        public SeriePais(int CodigoSerie, int CodigoPais)
        {
            this.CodigoSerie = CodigoSerie;
            this.CodigoPais = CodigoPais;            
        }
    }
}