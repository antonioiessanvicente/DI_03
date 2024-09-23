using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace Presentacion
{
    public partial class Form2 : Form
    {
        Agenda Listin;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // No se validan los controles, eso queda para otro tema.
            ContactoEntidad contacto;
            int resultado = 0;
      

            contacto = new ContactoEntidad();
            contacto.Nombre = textBox1.Text;
            contacto.Telefono = textBox2.Text;
            contacto.Direccion = textBox3.Text;
            contacto.Observaciones = textBox4.Text;
            try
            { 
              resultado = Listin.GuardarContacto(contacto);
                if (resultado == 1)
                    MessageBox.Show("Regitro insertado correctamente.","Información",MessageBoxButtons.OK);
                else
                    MessageBox.Show("El resgitro no se ha insertado correctamente:"+resultado+" filas.", "Información", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error desconocido:" +ex.Message, "Error",MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listin = new Agenda();
        }
    }
}
