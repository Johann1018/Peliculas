using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otroParcial
{
    public class Director
    {
        public int DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public int Telefono { get; set; }

        public List<Pelicula> Pelicula { get; set; } = new List<Pelicula>();
    }
}

