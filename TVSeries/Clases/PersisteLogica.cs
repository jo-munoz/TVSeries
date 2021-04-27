using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeries.Clases
{
    class PersisteLogica    //simula la capa de persistencia
    {
        public List<ActorActriz> Actores = new List<ActorActriz>();
        public List<Serie> Series = new List<Serie>();
        public List<ActorSerie> Relacion = new List<ActorSerie>();
        public List<Pais> Paises = new List<Pais>();
        public List<SeriePais> RelacionSeriePais = new List<SeriePais>();

        //constructor. carga datos de ejemplo
        public PersisteLogica()
        {
            //Un listado de paises
            Paises.Add(new Pais(45, "Colombia"));
            Paises.Add(new Pais(46, "Rusia"));
            Paises.Add(new Pais(47, "Canadá"));
            Paises.Add(new Pais(48, "Inglaterra"));
            Paises.Add(new Pais(49, "España"));
            Paises.Add(new Pais(50, "Estados Unidos"));

            //Un listado de actores y actrices
            Actores.Add(new ActorActriz(521, "Paulina Andreeva", "https://www.imdb.com/name/nm5475514/", 46));
            Actores.Add(new ActorActriz(522, "Kirill Käro", "https://www.imdb.com/name/nm1874211/", 46));
            Actores.Add(new ActorActriz(523, "Aleksandr Ustyugov", "https://www.imdb.com/name/nm1784957/", 46));
            Actores.Add(new ActorActriz(524, "Emily Berrington", "https://www.imdb.com/name/nm4970834/", 46));
            Actores.Add(new ActorActriz(525, "Gemma Chan", "https://www.imdb.com/name/nm2110418/", 46));
            Actores.Add(new ActorActriz(526, "Lucy Carless", "https://www.imdb.com/name/nm6845331/", 46));
            Actores.Add(new ActorActriz(527, "Olga Lomonosova", "https://www.imdb.com/name/nm2403341/", 46));
            Actores.Add(new ActorActriz(528, "Evan Rachel Wood", "https://www.imdb.com/name/nm0939697/", 50));
            Actores.Add(new ActorActriz(529, "Thandie Newton", "https://www.imdb.com/name/nm0628601/", 50));
            Actores.Add(new ActorActriz(530, "Angela Sarafyan", "https://www.imdb.com/name/nm1494168/", 50));

            //Un listado de series
            Series.Add(new Serie(171, "Better Than Us", "https://www.imdb.com/title/tt8285216/", "Acción"));
            Series.Add(new Serie(172, "Humans", "https://www.imdb.com/title/tt4122068/", "Aventura"));
            Series.Add(new Serie(173, "Westworld", "https://www.imdb.com/title/tt0475784/", "Ficción"));
            Series.Add(new Serie(174, "Real Humans", "https://www.imdb.com/title/tt2180271/", "Drama"));
            Series.Add(new Serie(175, "Almost Human", "https://www.imdb.com/title/tt2654580/", "Suspenso"));
            Series.Add(new Serie(176, "Battlestar Galactica", "https://www.imdb.com/title/tt0407362/", "Acción"));
            Series.Add(new Serie(177, "Metod", "https://www.imdb.com/title/tt5135336/", "Romantico"));

            //Añado actores y actrices a la serie "Better Than US"
            Relacion.Add(new ActorSerie(521, 172));
            Relacion.Add(new ActorSerie(522, 172));
            Relacion.Add(new ActorSerie(523, 172));
            Relacion.Add(new ActorSerie(527, 172));

            //Añado actores y actrices a la serie "Metod"
            Relacion.Add(new ActorSerie(521, 177));

            //Añado actores y actrices a la serie "WestWorld"
            Relacion.Add(new ActorSerie(528, 173));
            Relacion.Add(new ActorSerie(529, 173));
            Relacion.Add(new ActorSerie(530, 173));
        }

        #region Actor
        //Retorna el IdActor del actor/actriz dado el nombre
        public int IdActor(string BuscandoNombre)
        {
            for (int pos = 0; pos < Actores.Count; pos++)
                if (Actores[pos].Nombre.Equals(BuscandoNombre))
                    return Actores[pos].IdActor;
            return -1;
        }

        //Retorna la posición del actor/actriz en la lista dado el IdActor
        public int PosActor(int IdActor)
        {
            for (int pos = 0; pos < Actores.Count; pos++)
                if (Actores[pos].IdActor == IdActor)
                    return pos;
            return -1;

        }

        //Adiciona actor a la lista de actores. Error si el IdActor ya existía.
        public bool ActorAdiciona(int IdActor, string Nombre, string URL, int Nacionalidad)
        {
            if (PosActor(IdActor) != -1) return false;
            Actores.Add(new ActorActriz(IdActor, Nombre, URL, Nacionalidad));
            return true;
        }

        //Edita actor de la lista de actores. Error si el IdActor no existe.
        public bool ActorEdita(int IdActor, string Nombre, string URL, int Nacionalidad)
        {
            int pos = PosActor(IdActor);
            if (pos == -1) return false;
            Actores[pos].Nombre = Nombre;
            Actores[pos].UrlIMDB = URL;
            Actores[pos].Nacionalidad = Nacionalidad;
            return true;
        }

        //Borra actor de la lista de actores, si existe y no está trabajando en una serie
        public bool ActorBorra(int IdActor)
        {
            //Verifica que existe
            int existe = PosActor(IdActor);
            if (existe == -1) return false;

            //Verifica si trabaja para una serie
            for (int pos = 0; pos < Relacion.Count; pos++)
            {
                if (Relacion[pos].CodigoActor == IdActor)
                    return false;
            }

            //Borra el actor
            Actores.RemoveAt(existe);
            return true;
        }

        //Retorna el nombre del actor dado el IdActor
        public string NombreActor(int IdActor)
        {
            for (int pos = 0; pos < Series.Count; pos++)
                if (Actores[pos].IdActor == IdActor)
                    return Actores[pos].Nombre;
            return "NULL";
        }
        #endregion

        #region Serie
        //Retorna el IdSerie de la serie dado el nombre
        public int IdSerie(string BuscandoNombre)
        {
            for (int pos = 0; pos < Series.Count; pos++)
                if (Series[pos].Nombre.Equals(BuscandoNombre))
                    return Series[pos].IdSerie;
            return -1;
        }

        //Retorna la posición de la serie en la lista dado el IdSerie
        public int PosSerie(int IdSerie)
        {
            for (int pos = 0; pos < Series.Count; pos++)
                if (Series[pos].IdSerie == IdSerie)
                    return pos;
            return -1;
        }

        //Adiciona serie a la lista de series. Error si el IdSerie ya existía.
        public bool SerieAdiciona(int IdSerie, string Nombre, string URL, string Genero)
        {
            if (PosSerie(IdSerie) != -1) return false;
            Series.Add(new Serie(IdSerie, Nombre, URL, Genero));
            return true;
        }

        //Edita serie de la lista de series. Error si el IdSerie no existe.
        public bool SerieEdita(int IdSerie, string Nombre, string URL, string Genero)
        {
            int pos = PosSerie(IdSerie);
            if (pos == -1) return false;
            Series[pos].Nombre = Nombre;
            Series[pos].UrlIMDB = URL;
            Series[pos].Genero = Genero;
            return true;
        }

        //Borra serie de la lista de series, si existe
        public bool SerieBorra(int IdSerie)
        {
            //Verifica si existe
            int existe = PosSerie(IdSerie);
            if (existe == -1) return false;

            //Verifica si la serie tiene actores
            for (int pos = 0; pos < Relacion.Count; pos++)
            {
                if (Relacion[pos].CodigoSerie == IdSerie)
                    return false;
            }

            //Borra la serie
            Series.RemoveAt(existe);
            return true;
        }

        //Retorna el nombre de la serie dado el IdSerie
        public string NombreSerie(int IdSerie)
        {
            for (int pos = 0; pos < Series.Count; pos++)
                if (Series[pos].IdSerie == IdSerie)
                    return Series[pos].Nombre;
            return "NULL";
        }

        //Retorna un List de las series en las que ha actuado el actor
        public List<string> ActorTrabaja(int IdActor)
        {
            List<string> ListaSeries = new List<string>();
            for (int pos = 0; pos < Relacion.Count; pos++)
                if (Relacion[pos].CodigoActor == IdActor)
                    ListaSeries.Add(NombreSerie(Relacion[pos].CodigoSerie));
            return ListaSeries;
        }

        //Retorna una lista con los nombres de los actores que trabajan en determinada serie
        public List<string> SerieActores(int IdSerie)
        {
            List<string> ListaActores = new List<string>();
            for (int pos = 0; pos < Relacion.Count; pos++)
                if (Relacion[pos].CodigoSerie == IdSerie)
                    ListaActores.Add(NombreActor(Relacion[pos].CodigoActor));
            return ListaActores;
        }

        //Relaciona un actor con una serie.
        //Retorna false si la relación ya existía o no existen los códigos de serie o actor
        public bool SerieAsocia(int IdSerie, int IdActor)
        {

            //Valida existencia de actor y serie
            bool ActorExiste = false;
            bool SerieExiste = false;
            for (int pos = 0; pos < Actores.Count; pos++) if (Actores[pos].IdActor == IdActor) ActorExiste = true;
            for (int pos = 0; pos < Series.Count; pos++) if (Series[pos].IdSerie == IdSerie) SerieExiste = true;
            if (ActorExiste == false || SerieExiste == false) return false;

            for (int pos = 0; pos < Relacion.Count; pos++)
            {
                if (Relacion[pos].CodigoSerie == IdSerie && Relacion[pos].CodigoActor == IdActor)
                    return false;
            }
            Relacion.Add(new ActorSerie(IdActor, IdSerie));
            return true;
        }

        //Retira la relación de un actor con una serie
        public bool SerieDisocia(int IdSerie, int IdActor)
        {

            //Valida existencia de actor y serie
            bool ActorExiste = false;
            bool SerieExiste = false;
            for (int pos = 0; pos < Actores.Count; pos++) if (Actores[pos].IdActor == IdActor) ActorExiste = true;
            for (int pos = 0; pos < Series.Count; pos++) if (Series[pos].IdSerie == IdSerie) SerieExiste = true;
            if (ActorExiste == false || SerieExiste == false) return false;

            for (int pos = 0; pos < Relacion.Count; pos++)
            {
                if (Relacion[pos].CodigoSerie == IdSerie && Relacion[pos].CodigoActor == IdActor)
                {
                    Relacion.RemoveAt(pos);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Pais
        //Retorna el IdPais del pais dado el nombre
        public int IdPais(string BuscandoNombre)
        {
            for (int pos = 0; pos < Paises.Count; pos++)
                if (Paises[pos].Nombre.Equals(BuscandoNombre))
                    return Paises[pos].IdPais;
            return -1;
        }

        //Retorna la posición del pais en la lista dado el IdPais
        public int PosPais(int IdPais)
        {
            for (int pos = 0; pos < Paises.Count; pos++)
                if (Paises[pos].IdPais == IdPais)
                    return pos;
            return -1;
        }

        //Adiciona pais a la lista de Paises. Error si el IdPais ya existía.
        public bool PaisAdiciona(int IdPais, string Nombre)
        {
            if (PosSerie(IdPais) != -1) return false;
            Paises.Add(new Pais(IdPais, Nombre));
            return true;
        }

        //Edita pais de la lista de Paises. Error si el IdPais no existe.
        public bool PaisEdita(int IdPais, string Nombre)
        {
            int pos = PosPais(IdPais);
            if (pos == -1) return false;
            Paises[pos].Nombre = Nombre;
            return true;
        }

        //Borra pais de la lista de paises, si existe
        public bool PaisBorra(int IdPais)
        {
            //Verifica si existe
            int existe = PosPais(IdPais);
            if (existe == -1) return false;

            //Verifica si el pais tiene series
            for (int pos = 0; pos < RelacionSeriePais.Count; pos++)
            {
                if (RelacionSeriePais[pos].CodigoPais == IdPais)
                    return false;
            }

            //Borra la serie
            Paises.RemoveAt(existe);
            return true;
        }

        //Retorna el nombre del país dado el código
        public string NombrePais(int IdPais)
        {
            for (int pos = 0; pos < Paises.Count; pos++)
                if (Paises[pos].IdPais == IdPais)
                    return Paises[pos].Nombre;
            return "NULL";
        }

        //Retorna una lista con los nombres de las series que tienen ese pais
        public List<string> PaisSerie(int IdPais)
        {
            List<string> Lista = new List<string>();
            for (int pos = 0; pos < RelacionSeriePais.Count; pos++)
                if (RelacionSeriePais[pos].CodigoPais == IdPais)
                    Lista.Add(NombreSerie(RelacionSeriePais[pos].CodigoSerie));
            return Lista;
        }

        public bool ValidaExistencia(int IdPais) {
            //Verifica si existe
            int existe = PosPais(IdPais);
            if (existe == -1)            
                return false;
            else
                return true;
        }

        //Relaciona una serie con un pais.
        //Retorna false si la relación ya existía o no existen los códigos de serie o pais
        public bool PaisAsocia(int IdPais, int IdSerie)
        {

            //Valida existencia de serie y pais            
            bool SerieExiste = false;
            bool PaisExiste = false;
            for (int pos = 0; pos < Series.Count; pos++) if (Series[pos].IdSerie == IdSerie) SerieExiste = true;
            for (int pos = 0; pos < Paises.Count; pos++) if (Paises[pos].IdPais == IdPais) PaisExiste = true;
            if (SerieExiste == false || PaisExiste == false) return false;

            for (int pos = 0; pos < RelacionSeriePais.Count; pos++)
            {
                if (RelacionSeriePais[pos].CodigoSerie == IdSerie && RelacionSeriePais[pos].CodigoPais == IdPais)
                    return false;
            }
            RelacionSeriePais.Add(new SeriePais(IdSerie, IdPais));
            return true;
        }

        //Retira la relación de una serie con un pai
        public bool PaisDisocia(int IdSerie, int IdPais)
        {

            //Valida existencia de serie y pais     
            bool SerieExiste = false;
            bool PaisExiste = false;            
            for (int pos = 0; pos < Series.Count; pos++) if (Series[pos].IdSerie == IdSerie) SerieExiste = true;
            for (int pos = 0; pos < Paises.Count; pos++) if (Paises[pos].IdPais == IdPais) PaisExiste = true;
            if (SerieExiste == false || PaisExiste == false) return false;

            for (int pos = 0; pos < Relacion.Count; pos++)
            {
                if (RelacionSeriePais[pos].CodigoSerie == IdSerie && RelacionSeriePais[pos].CodigoPais == IdPais)
                {
                    RelacionSeriePais.RemoveAt(pos);
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}