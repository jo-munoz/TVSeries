using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class Visual    //Lo que ve el usuario final
    {
        public PersisteLogica Datos;
        public Visual(PersisteLogica objDatos)
        {
            Datos = objDatos;
        }

        public void Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n=========== Software TV Show 1.4 (Marzo de 2021) ===========");
                Console.WriteLine("1. CRUD de actores y actrices");
                Console.WriteLine("2. CRUD de series");
                Console.WriteLine("3. CRUD de paises");
                Console.WriteLine("4. Salir");
                Console.Write("¿Opción? ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: CRUDactores(); break;
                    case 2: CRUDseries(); break;
                    case 3: CRUDpaises(); break;
                }
            } while (opcion != 4);
        }

        public void CRUDactores()
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n=========== Software TV Show. Actores/Actrices ===========");
                for (int pos = 0; pos < Datos.Actores.Count; pos++)
                {
                    Console.Write("[" + Datos.Actores[pos].IdActor + "] ");
                    Console.Write(Datos.Actores[pos].Nombre);
                    Console.Write(" URL: " + Datos.Actores[pos].UrlIMDB);
                    Console.WriteLine(" País: " + Datos.NombrePais(Datos.Actores[pos].Nacionalidad));
                }
                Console.WriteLine(" \n1. Adicionar");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. ¿En cuáles series trabaja?");
                Console.WriteLine("5. Volver a menú principal");
                Console.Write("¿Opción? ");
                Opcion = Convert.ToInt32(Console.ReadLine());
                switch (Opcion)
                {
                    case 1: ActorAdiciona(); break;
                    case 2: ActorEdita(); break;
                    case 3: ActorBorra(); break;
                    case 4: ActorTrabaja(); break;
                }
            } while (Opcion != 5);
        }

        public void CRUDseries()
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n=========== Software TV Show. Series ===========");
                for (int pos = 0; pos < Datos.Series.Count; pos++)
                {
                    Console.Write("[" + Datos.Series[pos].IdSerie + "] ");
                    Console.Write(Datos.Series[pos].Nombre);
                    Console.WriteLine(" URL: " + Datos.Series[pos].UrlIMDB + " Género: " + Datos.Series[pos].Genero);                    
                }
                Console.WriteLine("\n1. Adicionar");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. Detalles de la serie");
                Console.WriteLine("5. Asociar actor/actriz a serie");
                Console.WriteLine("6. Disociar actor/actriz a serie");
                Console.WriteLine("7. Volver a menú principal");
                Console.Write("¿Opción? ");
                Opcion = Convert.ToInt32(Console.ReadLine());
                switch (Opcion)
                {
                    case 1: SerieAdiciona(); break;
                    case 2: SerieEdita(); break;
                    case 3: SerieBorra(); break;
                    case 4: SerieDetalle(); break;
                    case 5: SerieAsocia(); break;
                    case 6: SerieDisocia(); break;
                }
            } while (Opcion != 7);
        }

        public void CRUDpaises()
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n=========== Software TV Show. Paises ===========");
                for (int pos = 0; pos < Datos.Paises.Count; pos++)
                {
                    Console.Write("[" + Datos.Paises[pos].IdPais + "] ");
                    Console.Write(Datos.Paises[pos].Nombre);
                    Console.WriteLine("  ");
                }
                Console.WriteLine("\n1. Adicionar");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Borrar");
                Console.WriteLine("4. Detalles del pais");
                Console.WriteLine("5. Asociar serie a pais");
                Console.WriteLine("6. Disociar serie a pais");
                Console.WriteLine("7. Volver a menú principal");
                Console.Write("¿Opción? ");
                Opcion = Convert.ToInt32(Console.ReadLine());
                switch (Opcion)
                {
                    case 1: PaisAdiciona(); break;
                    case 2: PaisEdita(); break;
                    case 3: PaisBorra(); break;
                    case 4: PaisDetalle(); break;
                    case 5: PaisAsocia(); break;
                    case 6: PaisDisocia(); break;
                }
            } while (Opcion != 7);
        }

        //Muestra los países
        public void MostrarPaises()
        {
            for (int pos = 0; pos < Datos.Paises.Count; pos++)
            {
                Console.Write("[" + Datos.Paises[pos].IdPais + "] ");
                Console.WriteLine(Datos.Paises[pos].Nombre);
            }
        }

        #region CRUD Actor
        //Pantalla para adicionar actores
        public void ActorAdiciona()
        {
            Console.WriteLine("\tAdicionar actor o actriz al listado");
            Console.Write("¿Código? "); int IdActor = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            Console.Write("¿URL de IMDB? "); string URL = Console.ReadLine();
            MostrarPaises();
            Console.Write("¿Pais de origen? "); int Nacionalidad = Convert.ToInt32(Console.ReadLine());
            if (Datos.ActorAdiciona(IdActor, Nombre, URL, Nacionalidad))
                Console.WriteLine("\nActor/actriz adicionado. Presione ENTER para continuar");
            else
                Console.WriteLine("\nCódigo repetido, no se pudo adicionar. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para editar actores
        public void ActorEdita()
        {
            Console.WriteLine("\tEditar actor o actriz");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdActor = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            Console.Write("¿URL de IMDB? "); string URL = Console.ReadLine();
            MostrarPaises();
            Console.Write("¿Pais de origen? "); int Nacionalidad = Convert.ToInt32(Console.ReadLine());
            if (Datos.ActorEdita(IdActor, Nombre, URL, Nacionalidad))
                Console.WriteLine("\nActor/actriz editado. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError. Código de actor/actriz inexistente. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para borrar actores
        public void ActorBorra()
        {
            Console.WriteLine("\tBorrar actor o actriz");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdActor = Convert.ToInt32(Console.ReadLine());
            if (Datos.ActorBorra(IdActor))
                Console.WriteLine("\nActor/actriz borrado. Presione ENTER para continuar");
            else
                Console.WriteLine("\nNo se puede borra actor/actriz porque no existe o trabaja en una serie y debe disociarse primero. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para mostrar en que series trabaja el actor
        public void ActorTrabaja()
        {
            Console.WriteLine("\tListar las series donde trabaja el actor/actriz");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdActor = Convert.ToInt32(Console.ReadLine());
            List<string> ListaSeries = Datos.ActorTrabaja(IdActor);
            for (int cont = 0; cont < ListaSeries.Count; cont++)
                Console.WriteLine(ListaSeries[cont]);
            Console.WriteLine("\nPresione ENTER para continuar");
            Console.ReadKey();
        }
        #endregion

        #region CRUD Serie
        //Pantalla para adicionar series
        public void SerieAdiciona()
        {
            Console.WriteLine("\tAdicionar serie al listado");
            Console.Write("¿Código? "); int IdSerie = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            Console.Write("¿URL en IMDB? "); string URL = Console.ReadLine();
            Console.Write("¿Género? "); string Genero = Console.ReadLine();
            if (Datos.SerieAdiciona(IdSerie, Nombre, URL, Genero))
                Console.WriteLine("\nSerie adicionada. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError, código de serie ya existe. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para editar series
        public void SerieEdita()
        {
            Console.WriteLine("\tEditar serie");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            Console.Write("¿URL en IMDB? "); string URL = Console.ReadLine();
            Console.Write("¿Género? "); string Genero = Console.ReadLine();
            if (Datos.SerieEdita(IdSerie, Nombre, URL, Genero))
                Console.WriteLine("\nSerie editada. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError, código de serie inexistente. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para borrar series
        public void SerieBorra()
        {
            Console.WriteLine("\tBorrar serie");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());
            if (Datos.SerieBorra(IdSerie))
                Console.WriteLine("\nSerie borrada. Presione ENTER para continuar");
            else
                Console.WriteLine("\nNo se puede borrar la serie porque no existe o porque tiene actores trabajando en esta (debe disociar primero). Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para ver el detalle de la serie
        public void SerieDetalle()
        {
            Console.WriteLine("\t === Detalle de una serie ===");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Datos.NombreSerie(IdSerie));
            Console.WriteLine("Actores/Actrices que trabajan allí:");
            List<string> ListaActores = Datos.SerieActores(IdSerie);
            for (int cont = 0; cont < ListaActores.Count; cont++)
                Console.WriteLine(ListaActores[cont]);

            Console.WriteLine("\nPresione ENTER para continuar");
            Console.ReadKey();
        }

        //Asociar actor o actriz a una serie
        public void SerieAsocia()
        {
            Console.WriteLine("\tAsocia un actor o actriz a una serie");
            Console.Write("¿Cuál serie? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());
            for (int pos = 0; pos < Datos.Actores.Count; pos++)
            {
                Console.Write("[" + Datos.Actores[pos].IdActor + "] ");
                Console.WriteLine(Datos.Actores[pos].Nombre);
            }
            Console.Write("¿Cuál actor/actriz? Escriba el número que está entre [ ]: ");
            int IdActor = Convert.ToInt32(Console.ReadLine());
            if (Datos.SerieAsocia(IdSerie, IdActor))
                Console.WriteLine("\nActor/actriz asociado a la serie. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError: Actor/actriz/serie inexistente o esa asociación ya existía. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para disociar actor de la serie
        public void SerieDisocia()
        {
            Console.WriteLine("\t === Disociar actor de la serie ===");
            Console.Write("¿Cuál serie? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());

            for (int pos = 0; pos < Datos.Relacion.Count; pos++)
            {
                if (Datos.Relacion[pos].CodigoSerie == IdSerie)
                {
                    Console.Write("[" + Datos.Relacion[pos].CodigoActor + "] ");
                    Console.WriteLine(Datos.NombreActor(Datos.Relacion[pos].CodigoActor));
                }
            }

            Console.Write("¿Cuál actor/actriz quiere quitar? Escriba el número que está entre [ ]: ");
            int IdActor = Convert.ToInt32(Console.ReadLine());

            if (Datos.SerieDisocia(IdSerie, IdActor))
                Console.WriteLine("\nActor/actriz retirado de la serie. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError: Actor/actriz/serie inexistente o esa asociación no existía. Presione ENTER para continuar");

            Console.ReadKey();
        }
        #endregion

        #region CRUD Pais
        //Pantalla para adicionar pais
        public void PaisAdiciona()
        {
            Console.WriteLine("\tAdicionar pais al listado");
            Console.Write("¿Código? "); int IdPais = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            if (Datos.PaisAdiciona(IdPais, Nombre))
                Console.WriteLine("\npais adicionada. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError, código de pais ya existe. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para editar pais
        public void PaisEdita()
        {
            Console.WriteLine("\tEditar pais");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdPais = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Nombre? "); string Nombre = Console.ReadLine();
            if (Datos.PaisEdita(IdPais, Nombre))
                Console.WriteLine("\nPais editada. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError, código de pais inexistente. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para borrar pais
        public void PaisBorra()
        {
            Console.WriteLine("\tPais serie");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdPais = Convert.ToInt32(Console.ReadLine());
            if (Datos.PaisBorra(IdPais))
                Console.WriteLine("\nPais borrado. Presione ENTER para continuar");
            else
                Console.WriteLine("\nNo se puede borrar el pais porque no existe o porque tiene series asociados (debe disociar primero). Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para ver el detalle del pais
        public void PaisDetalle()
        {
            Console.WriteLine("\t === Detalle del pais ===");
            Console.Write("¿Cuál? Escriba el número que está entre [ ]: ");
            int IdPais = Convert.ToInt32(Console.ReadLine());

            //Verifica si existe
            if (Datos.ValidaExistencia(IdPais))
            {
                Console.WriteLine(Datos.NombrePais(IdPais));
                Console.WriteLine("Series asociadas al pais:");
                List<string> ListaSerie = Datos.PaisSerie(IdPais);
                for (int cont = 0; cont < ListaSerie.Count; cont++)
                    Console.WriteLine(ListaSerie[cont]);

                Console.WriteLine("\nPresione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nEl Id del pais no existe. Presione ENTER para continuar");
                Console.ReadKey();
            }
        }

        //Asociar serie a un pais
        public void PaisAsocia()
        {
            Console.WriteLine("\tAsocia una serie a un pais");
            Console.Write("¿Cuál pais? Escriba el número que está entre [ ]: ");
            int IdPais = Convert.ToInt32(Console.ReadLine());
            for (int pos = 0; pos < Datos.Series.Count; pos++)
            {
                Console.Write("[" + Datos.Series[pos].IdSerie + "] ");
                Console.WriteLine(Datos.Series[pos].Nombre);
            }
            Console.Write("¿Cuál serie? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());
            if (Datos.PaisAsocia(IdPais, IdSerie))
                Console.WriteLine("\nSerie asociado al pais. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError: serie inexistente o esa asociación ya existía. Presione ENTER para continuar");
            Console.ReadKey();
        }

        //Pantalla para disociar serie de una pais
        public void PaisDisocia()
        {
            Console.WriteLine("\t === Disociar serie de una pais ===");
            Console.Write("¿Cuál pais? Escriba el número que está entre [ ]: ");
            int IdPais = Convert.ToInt32(Console.ReadLine());

            for (int pos = 0; pos < Datos.RelacionSeriePais.Count; pos++)
            {
                if (Datos.RelacionSeriePais[pos].CodigoPais == IdPais)
                {
                    Console.Write("[" + Datos.RelacionSeriePais[pos].CodigoSerie + "] ");
                    Console.WriteLine(Datos.NombreSerie(Datos.RelacionSeriePais[pos].CodigoSerie));
                }
            }

            Console.Write("¿Cuál serie quiere quitar? Escriba el número que está entre [ ]: ");
            int IdSerie = Convert.ToInt32(Console.ReadLine());

            if (Datos.PaisDisocia(IdSerie, IdPais))
                Console.WriteLine("\nSerie retirado del pais. Presione ENTER para continuar");
            else
                Console.WriteLine("\nError: Serie/pais inexistente o esa asociación no existía. Presione ENTER para continuar");

            Console.ReadKey();
        }
        #endregion
    }
}