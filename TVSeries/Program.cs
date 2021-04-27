using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeries.Clases;

namespace TVSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            PersisteLogica objDatos = new PersisteLogica();
            Visual objVisual = new Visual(objDatos);
            objVisual.Menu();
        }
    }
}