using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassVistaGrafiPastel;
using ClassModeloGrafiPastel;


namespace WindControladorGrafiPastel
{
    public partial class Form1 : Form
    {
        VistaGrafica miGrafica;
        VistaEmpresa mivista;
        Asociacion miAsociacion;
        string mensj = "";
        string[] losDatos;


        public Form1()
        {
            InitializeComponent();
            mivista = new VistaEmpresa();
            miGrafica = new VistaGrafica(pictureBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    mivista.cambiartext(openFileDialog1.FileName, txtRuta);
                }
            }
            catch
            {
                mivista.MiLetrero("Asegurese de haber elegido una imagen");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //mivista = new VistaEmpresa();
            miGrafica = new VistaGrafica(pictureBox2);
            txtRuta.ReadOnly = true;
            txtDatos.ReadOnly = true;
            txtPromedio.ReadOnly = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // para crear la empresa
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Image tem;
                if (txtRuta.Text != "")
                {
                    tem = Image.FromFile(txtRuta.Text);
                    mensj = miAsociacion.agregarEmpresaconImagen(txtEmpresa.Text, comboBox1.SelectedItem .ToString(), tem);
                    mivista.MiLetrero(mensj);
                    txtEmpresa.Text = "";
                    txtRuta.Text = "";
                    txtEmpresa.Focus();
                }
                else
                {
                    mivista.MiLetrero("Asegurese de haber insertado una imagen");
                }
            }
            catch
            {
                mivista.MiLetrero("Asegurese de haber insertado una imagen");
            }
            
        }

        private void btnAgregarIngresos_Click(object sender, EventArgs e)
        {
            try
            {
                mensj = miAsociacion.InsertarIngresoaEmpresa(listBox2.SelectedIndex, Convert.ToSingle(txtAgregarIngreso.Text));
                mivista.MiLetrero(mensj);
                txtAgregarIngreso.Text = "" ;
                txtAgregarIngreso.Focus();
            }
            catch
            {
                mivista.MiLetrero("Asegurese de insertar los datos correctamente");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MuestraIngresos_Click(object sender, EventArgs e)
        {
            losDatos = miAsociacion.devuelveIngresos(listBox2.SelectedIndex);
            mivista.MonstrarCadenas(losDatos, listBox1);
        }

        private void buttonProm_Click(object sender, EventArgs e)
        {
            mensj = miAsociacion.promIndividual(listBox2.SelectedIndex);
            mivista.cambiartext(mensj, txtPromedio);
        }

        private void buttonGraficaPastel_Click(object sender, EventArgs e)
        {
            //try
            //{
                Single[] lospromedios;
                lospromedios = miAsociacion.promediosPorGiro();
                miGrafica.generarGrafica(lospromedios,650);
            //}
            //catch
            //{
            //    mivista.MiLetrero("Asegurese haber llenado correctamente la informacion.");
            //}
        }

        private void buttonCreaAsocia_Click(object sender, EventArgs e)
        {
            try
            {
                miAsociacion = new Asociacion(txtEmpresa.Text, int.Parse(txtNumEmpre.Text));
                mivista.MiLetrero("Se ha creado la asociacion");
                miAsociacion.girosPrincipales();
                txtNomAsocia.Text = "";
                txtNumEmpre.Text = "";
                txtNomAsocia.Focus();
            }
            catch
            {
                mivista.MiLetrero("Asegurese de insertar los datos correctamente");
            }
        }

        private void muestraTodasEmpresas_Click(object sender, EventArgs e)
        {
            losDatos = miAsociacion.devuelveEmpresas();
            mivista.MonstrarCadenas(losDatos, listBox2);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mivista.MostrarImagen(pictureBox1, miAsociacion.devuelveImagenEmpre(listBox2.SelectedIndex));
            mensj = miAsociacion.devuelveEmpreXSelec(listBox2.SelectedIndex);
            mivista.cambiartext(mensj,txtDatos);

            txtPromedio.Text = "";
            listBox1.Items.Clear();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void buttonCreaGiro_Click(object sender, EventArgs e)
        {
            try
            {
                mensj = miAsociacion.agregarNuevoGiro(txtGiro.Text);
                mivista.MiLetrero(mensj);
                txtGiro.Text = "";
                txtGiro.Focus();
            }
            catch
            {
                mivista.MiLetrero("Asegurese de insertar los datos correctamente");
            }
        }

        private void buttonMostrarGiros_Click(object sender, EventArgs e)
        {
            losDatos = miAsociacion.devuelveGiros();
            miAsociacion.LlenarGiros(comboBox1, losDatos);
            mivista.MiLetrero("Giros actualizados");
        }

        private void txtAgregarIngreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEliminaEmpre_Click(object sender, EventArgs e)
        {
            mensj = miAsociacion.EliminarPorPosicion(listBox2.SelectedIndex);
            mivista.MiLetrero(mensj);
        }

        private void buttonModificaEmpre_Click(object sender, EventArgs e)
        {
            Image tem;
            if (txtRuta.Text != "")
            {
                tem = Image.FromFile(txtRuta.Text);
                mensj = miAsociacion.Modificar(txtEmpresa.Text, comboBox1.SelectedIndex.ToString(), tem, listBox2.SelectedIndex);
                mivista.MiLetrero(mensj);
                txtEmpresa.Text = "";
                txtRuta.Text = "";
            }
            else
            {
                mivista.MiLetrero("Asegurese de haber insertado una imagen o insertado los datos correctamente");
            }
        }

        // promedio por giro
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Single[] atrapa4;
                atrapa4 = miAsociacion.promediosPorGiro();
                mivista.MonstrarCadenaselpro(atrapa4, listBox4, comboBox1);


                string[] losPromedios;
                losPromedios = miAsociacion.devuelveGiros();
                mivista.MonstrarCadenas(losPromedios, listBox3);
            }

            catch
            {
                mivista.MiLetrero("Asegurese de tener datos ingresados.");
            }
        }

      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void buttonGrafi_Click(object sender, EventArgs e)
        {
            Single[] lospromedios;
            lospromedios = miAsociacion.promediosPorGiro();
            miGrafica.generarGrafica(lospromedios, 550);
            losDatos = miAsociacion.devuelveGiros();
            mivista.MonstrarCadenas(losDatos, listBox5);
        }
    }
}
