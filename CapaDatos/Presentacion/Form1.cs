﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

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
    }
}
