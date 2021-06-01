using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassVistaGrafiPastel
{
    public class VistaGrafica
    {
        private Graphics lienzo;
        private int xc = 0, yc = 0;
      

        public VistaGrafica(PictureBox cuadro)
        {
            cuadro.BorderStyle = BorderStyle.FixedSingle;
            lienzo = cuadro.CreateGraphics();

            //punto centrico del panel
            xc = cuadro.Width / 2;
            yc = cuadro.Height / 2;
           
        }

        //public void GenerarLaGrafica(int longitud)
        //{
        //    SolidBrush b1 = new SolidBrush(Color.Orange);
        //    int radio = longitud / 2;

        //    lienzo.FillEllipse(b1, new Rectangle(xc - radio, yc - radio, radio * 2, radio * 2));
        //}

        public void generarGrafica(Single[] datos, int longitud)
        {

            int x1 = 0, y1 = 0;
            Random aleatorio = new Random();
          //  int color = aleatorio.Next(1, 10);

            Color[] colores ={ Color.AliceBlue, Color.Orange, Color.Aquamarine, Color.LightPink, Color.Green, Color.LightGray, Color.MediumPurple, Color.Red, Color.Black, Color.YellowGreen,
                Color.BlueViolet, Color.BlanchedAlmond, Color.Brown, Color.Coral, Color.Crimson, Color.DarkGreen, Color.Cyan, Color.Lavender, Color.Ivory, Color.Chartreuse,
            Color.Khaki, Color.Indigo, Color.SeaShell, Color.SkyBlue, Color.Turquoise, Color.Tomato, Color.Bisque, Color.Azure, Color.DarkSalmon, Color.SeaGreen, Color.Silver};

            Single inicial = 0, final = 0;
            int radio = longitud / 2;

            for (int i = 0; i < 30 ; i++)
            {
                final = (datos[i] * 360) / datos[30];
                SolidBrush brocha = new SolidBrush(colores[i]);

                lienzo.FillPie(brocha, new Rectangle(xc - radio, yc - radio, longitud, longitud),inicial, final);

                inicial += final;
                SolidBrush b2 = new SolidBrush(colores[i]);

                lienzo.FillEllipse(b2, new Rectangle(x1, y1,10, 10));

                y1 +=12;
            }
            
        }

    }
}