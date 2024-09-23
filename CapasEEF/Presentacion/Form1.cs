using DatosEEF;
using Modelos;
using NegocioEEF;

namespace PresentacionEEF
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private string? GetId()
        {
            try
            {
                string? id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                return id;
            }
            catch (Exception)
            {

                return null;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Agenda n = new Agenda())
            { 
                Contacto t1 = new Contacto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                n.GuardarContacto(t1);
            }
            MessageBox.Show("Registro insertado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico(); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string? id = GetId();

            if (id != null)
                using (Agenda n = new Agenda())
                {
                    Contacto t1 = new Contacto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    n.ActualizarContacto(t1);
                }

            MessageBox.Show("Registro actualizado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string? id = GetId();

            if (id != null)
                using (Agenda n = new Agenda())
                {
                    n.BorrarContacto(id);
                }

            MessageBox.Show("Registro borrado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            using (Agenda n = new Agenda())
            {
                Contacto t2 = new Contacto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                n.GuardarContacto2(t2);
            }
            MessageBox.Show("Registro insertado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string? id = GetId();
            if (id != null)
                using (Agenda n = new Agenda())
                {
                    Contacto t1 = new Contacto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    n.ActualizarContacto2(t1);
                }
            MessageBox.Show("Registro actualizado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string? id = GetId();

            if (id != null)
                using (Agenda n = new Agenda())
                {
                    Contacto t1 = new Contacto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    n.BorrarContacto2(t1);
                }

            MessageBox.Show("Registro borrado correctamente");
            dataGridView1.DataSource = Agenda.ListadoTelefonico();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
        }

    }
}