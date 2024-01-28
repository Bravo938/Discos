using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discos
{
    public partial class Form1 : Form
    {
        //declaro esta lista para utilizar 
        private List<Discos> listaDisco;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            listaDisco= negocio.listasDiscos();
            dataGridViewDiscos.DataSource = listaDisco;//MUESTRO los datos

            dataGridViewDiscos.Columns["UrlImagenTapa"].Visible = false;//oculto la columna UrlImagenTapa

            cargarimagen(listaDisco[0].UrlImagenTapa);


        }
        //el metodo cargarimagen lo creo para controlar los errores por si la imagen no se encuentra o no carga 
        private void cargarimagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex) 
            {
                pictureBox1.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void dataGridViewDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dataGridViewDiscos.CurrentRow.DataBoundItem;

            //cargo la imagen
            cargarimagen(seleccionado.UrlImagenTapa);
        }

    }
}
