using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otroParcial
{
    public class Controladora
    {
        public static List<Pelicula> peliculas = new List<Pelicula>();
        public static List<Director> directores = new List<Director>();

        public static List<Pelicula> Vehiculos
        {
            get { return peliculas; }
        }

        public static void RegistrarPelicula(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
        }
        public static void RegistrarDirector(Director director)
        {
            directores.Add(director);
        }
    }
}
