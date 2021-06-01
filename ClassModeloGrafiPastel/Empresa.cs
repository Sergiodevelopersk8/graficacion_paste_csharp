using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassModeloGrafiPastel
{
    public class Empresa
    {
        public string NombreEmp { get; set; }
        public string Giro { get; set; }
        public Image Logotipo { get; set; }
        //public Single promedio { get; set; }
        public Single[] ingresos = new Single[4];
        private int posicion = 0;
        public string cad = "";

        public Empresa() { }


        // asigna el nombre de la empresa, su giro y el logotipo por ruta
        public Empresa(string nom, string gir, string ruta)
        {
            NombreEmp = nom;
            Giro = gir;
            Logotipo = Image.FromFile(ruta);
        }

        // asigna datos a la empresa y la imagen con formato (jpg, png, etc)
        public Empresa(string nom, string gir, Image foto)
        {
            NombreEmp = nom;
            Giro = gir;
            Logotipo = foto;
        }

        public string agregarIngresos(Single valor)
        {
            if (posicion <= ingresos.Length - 1)
            {
                ingresos[posicion] = valor;
                posicion++;
                cad = "Ingreso agregado";
            }
            else
            {
                cad = "Ya se han insertado todos los ingresos indicados";
            }
            return cad;
        }

        // muestra los ingresos que se le registren a UNA SOLA empresa
        public string[] DevuelveIngresos()
        {
            string[] temporal = new string[posicion];
            for (int f = 0; f <= posicion - 1; f++)
            {
                temporal[f] = "Mes " + (f + 1) + " :$" + ingresos[f];
            }
            return temporal;
        }

        // devuelve el promedio de UNA SOLA empresa
        public Single promIngresoXEmpre()
        {
            Single prom = 0;
            for (int f = 0; f <= posicion - 1; f++)
            {
                prom = prom + ingresos[f];
            }
            
            if (posicion != 0)
            {
                prom = prom / posicion;
            }
            return prom;
        }

        // devuelve los datos de todas las empresas registradas
        public string TodosDatosEmpresa()
        {
            return cad = "Empresa: " + NombreEmp + " - Giro: " + Giro;
        }
    }
}
