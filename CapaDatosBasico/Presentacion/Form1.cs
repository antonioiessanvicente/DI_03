using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        // Atributo que meneja la agenda de contactos.
        private Agenda agenda;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            agenda = new Agenda();         
            dataGridView1.DataSource = agenda.ListadoTelefonico();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                agenda.InsertarAgenda(textBox1.Text, textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Inserción realizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            agenda = new Agenda();
            dataGridView1.DataSource = agenda.ListadoTelefonico();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
