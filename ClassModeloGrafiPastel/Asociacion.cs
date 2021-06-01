using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassModeloGrafiPastel
{
    public class Asociacion
    {
        public string NombreAsocia { get; set; }
        private string[] arregloGiros = new string[11];
        private Empresa[] lasEmpresas;
        private int posicionGiros = 0;
        private int posicion = 0;
        private string cad = "";

        // cargamos los giros
        public void LlenarGiros(ComboBox combo, string[] arregloGiros)
        {
            combo.Items.Clear();
            foreach (string j in arregloGiros)
            {
                combo.Items.Add(j);
            }
        }

        public string agregarNuevoGiro(string gironuevo)
        {
            if (posicionGiros <= arregloGiros.Length - 1)
            {
                arregloGiros[posicionGiros] = gironuevo;
                posicionGiros++;
                cad = "Se creo un nuevo giro";
            }
            else
            {
                cad = "Se han insertado todos los giros indicados";
            }
            return cad;
        }

        public void girosPrincipales()
        {
            arregloGiros[0] = "Agricola";
            arregloGiros[1] = "Textil";
            arregloGiros[2] = "Avicola";
            arregloGiros[3] = "Tecnologia";
            arregloGiros[4] = "Servicios";

            posicionGiros = 5;
        }

        public string[] devuelveGiros()
        {
            string[] temporal = new string[posicionGiros];

            int t = 0;
            for (t = 0; t <= posicionGiros - 1; t++)
            {
                temporal[t] = arregloGiros[t];
            }
            return temporal;
        }


        //constructores
        public Asociacion() { }

        // asigna cuantas empresas va a tener la asociacion
        public Asociacion(int numEmpre)
        {
            lasEmpresas = new Empresa[numEmpre];
        }

        // nombre y numero de empresas de la asociacion
        public Asociacion(string nombAsocia, int numEmpre)
        {
            NombreAsocia = nombAsocia;
            lasEmpresas = new Empresa[numEmpre];
        }

        //public String AgregarEmpresa(string nombEmpre, string giro, string ruta_logo)
        //{
        //    if (posicion <= lasEmpresas.Length - 1)
        //    {
        //        lasEmpresas[posicion] = new Empresa(nombEmpre, giro, ruta_logo);
        //        posicion++;
        //        cad= "Empresa insertada";
        //    }
        //    else
        //    {
        //        cad = "Ya no caben mas empresas";
        //    }
        //    return cad;
        //}

        // registra la empresa a la asociacion
        public String agregarEmpresaconImagen(string nombEmpre, string giro, Image log)
        {
            if (posicion <= lasEmpresas.Length - 1)
            {
                lasEmpresas[posicion] = new Empresa(nombEmpre, giro, log);
                posicion++;
                cad = "Empresa agregada";
            }
            else
            {
                cad = "Ya se insertaron las empresas indicadas";
            }
            return cad;
        }

        public string[] devuelveEmpresas()
        {
            string[] temporal = new string[posicion];

            int t = 0;
            for (t = 0; t <= posicion - 1; t++)
            {
                temporal[t] = lasEmpresas[t].TodosDatosEmpresa();
            }
            return temporal;
        }

        // asigna ingresos a su respectiva empresa
        public string InsertarIngresoaEmpresa(int empreSelec, Single ingreso)
        {
            if (empreSelec < posicion)
            {
                cad = lasEmpresas[empreSelec].agregarIngresos(ingreso);
            }
            return cad;
        }

        // muestra los ingresos de cada empresa seleccionada en el listBox
        public string[] devuelveIngresos(int empreSelec)
        {
            return lasEmpresas[empreSelec].DevuelveIngresos();
        }
        

        // elimina la empresa seleccionada en listBox
        public string EliminarPorPosicion(int empreSelec)
        {
            if (empreSelec != -1)
            {
                for (int h = empreSelec; h <= posicion - 2; h++)
                {
                    lasEmpresas[h] = lasEmpresas[h + 1];
                }
                posicion--;
                cad = "Se elimino a la empresa";
            }
            else
            {
                cad = "Debe seleccionar una empresa para eliminar";
            }
            return cad;
        }

        // modifica la empresa seleccionada en listBox
        public string Modificar(string nombEmpre, string giro, Image logo, int empreSelecc)
        {
            int posiEmpre = empreSelecc;

            if (posiEmpre == -1)
            {
                cad = "Debe seleccionar un empresa para modificar";
            }
            else
            {
                lasEmpresas[posiEmpre].NombreEmp = nombEmpre;
                lasEmpresas[posiEmpre].Giro = giro;
                lasEmpresas[posiEmpre].Logotipo = logo;

                cad = "Se modificaron los datos de la empresa";
            }
            return cad;
        }


        // devuelve el promedio de ingresos de la empresa seleccionada
        public string promIndividual(int empreSelec)
        {
            if (empreSelec < posicion)
            {
                cad = "$: " + lasEmpresas[empreSelec].promIngresoXEmpre();
            }
            return cad;
        }


        public Image devuelveImagenEmpre(int empreSelec)
        {
            Image logop = null;
            if (empreSelec<posicion)
            {
                return lasEmpresas[empreSelec].Logotipo;
            }
            return logop;
        }

        public string devuelveEmpreXSelec(int empreSelec)
        {
            if (empreSelec < posicion)
            {
                cad = lasEmpresas[empreSelec].TodosDatosEmpresa();
            }
            return cad;
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Single[] promediosPorGiro()
        {
            Single[] promedios = new Single[31];
            Single promFinal = 0;

            for (int i = 0; i < posicionGiros; i++)
            {
                Single promedioDeGiro = 0;

                for (int c = 0; c < posicion; c++)
                {
                    if (lasEmpresas[c].Giro== arregloGiros[i].ToString())
                    {
                        promedioDeGiro += lasEmpresas[c].promIngresoXEmpre();
                        promedios[i] = promedioDeGiro;
                    }
                }
            }

            for (int i = 0; i < 30; i++)
            {
                promFinal = promFinal + promedios[i];
            }

            promedios[30] = promFinal;

            return promedios;
        }
    }
}
