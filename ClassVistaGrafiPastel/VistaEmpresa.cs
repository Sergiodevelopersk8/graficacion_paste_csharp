using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace ClassVistaGrafiPastel
{
    public class VistaEmpresa
    {

        public void MiLetrero(string frase)
        {
            MessageBox.Show(frase, "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public void MostrarEmpresas(string[] cadenas, ListBox lista)
        {
            int y = 0;
            lista.Items.Clear();
            for (y = 0; y <= cadenas.Length - 1; y++)
            {
                lista.Items.Add(cadenas[y]);
            }
        }

        public void MonstrarCadenas(string[] cadenas, ListBox lista)
        {
            lista.Items.Clear();
            foreach (string j in cadenas)
            {
                lista.Items.Add(j);
            }
        }

        // devolver los datos de las empresas seleccionadas
        public void MostrarCadenas3(Single[] cadenas, ListBox lista, int numElementos)
        {
            int y = 0;
            lista.Items.Clear();
            for (y = 0; y <= numElementos; y++)
            {
                lista.Items.Add(cadenas[y]);

            }

        }


        public void MonstrarCadenas2(Single[] cadenas, ListBox lista)
        {
            int y = 0;
            lista.Items.Clear();
            for (y = 0; y <= cadenas.Length - 1; y++)
            {
                lista.Items.Add(cadenas[y]);
            }
        }


        public void MonstrarCadenaselpro(Single[] cadenas, ListBox lista,ComboBox listita)
        {
            int y = 0;
            lista.Items.Clear();
            for (y = 0; y <= listita.Items.Count - 1; y++)
            {
                lista.Items.Add(cadenas[y]);
            }
        }

        public void cambiartext(string dato, TextBox caja)
        {
            caja.Text = dato;
        }

        public void cambiartext2(string[] dato, TextBox caja, int empreSelec)
        {
            if (empreSelec != -1)
            {
                for (int h = 0; h <= empreSelec - 2; h++)
                {
                    caja.Text = dato[empreSelec];
                }
            }
        }

        public void MostrarImagen(PictureBox pic, Image fotito)
        {
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = fotito;
        }


    }
}
