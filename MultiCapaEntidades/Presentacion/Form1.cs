using CapaNegocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        Agenda Listin;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listin = new Agenda();
            dataGridView1.DataSource = Listin.ListadoTelefonico();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.ShowDialog();
            dataGridView1.DataSource = Listin.ListadoTelefonico();
        }
    }
}
