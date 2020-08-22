using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualMachine
{
    public partial class EntradaForm : Form
    {
        public string SelectedText { get; set; }
        
        public EntradaForm()
        {
            InitializeComponent();
        }

        private void EntradaForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SelectedText = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
