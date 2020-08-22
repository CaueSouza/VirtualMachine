using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualMachine
{

    public partial class ComandosForm : Form
    {
        public ComandosForm()
        {
            InitializeComponent();
            linhas();
        }

        private void ComandosForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linhas()
        {
            //dataGridView1.Rows.Add("", "");
            dataGridView1.Rows.Add("LDC k", "Carrega uma constante k");
            dataGridView1.Rows.Add("LDV n", "Carrega valor n");
            dataGridView1.Rows.Add("ADD", "Soma");
            dataGridView1.Rows.Add("SUB", "Subtração");
            dataGridView1.Rows.Add("MULT", "Multiplicação");
            dataGridView1.Rows.Add("DIVI", "Divisão");
            dataGridView1.Rows.Add("INV", "Inverte sinal");
            dataGridView1.Rows.Add("AND", "Conjunção");
            dataGridView1.Rows.Add("OR", "Disjunção");
            dataGridView1.Rows.Add("NEG", "Negação");
            dataGridView1.Rows.Add("CME", "Compara menor");
            dataGridView1.Rows.Add("CMA", "Compara maior");
            dataGridView1.Rows.Add("CEQ", "Compara igual");
            dataGridView1.Rows.Add("CDIF", "Compara diferente");
            dataGridView1.Rows.Add("CMEQ", "Compara menor ou igual");
            dataGridView1.Rows.Add("CMAQ", "Compara maior ou igual");
            dataGridView1.Rows.Add("START", "Iniciar programa");
            dataGridView1.Rows.Add("HLT", "Encerrar programa");
            dataGridView1.Rows.Add("STR n", "Armazena valor");
            dataGridView1.Rows.Add("JMP t", "Pula para posição t");
            dataGridView1.Rows.Add("JMPF t", "Pula para posição t caso seja falso");
            dataGridView1.Rows.Add("NULL", "Nada");
            dataGridView1.Rows.Add("RD", "Lê entrada de valor");
            dataGridView1.Rows.Add("PRN", "Imprime valor");
            dataGridView1.Rows.Add("ALLOC m,n", "Aloca memória");
            dataGridView1.Rows.Add("DALLOC m,n", "Desaloca memória");
            dataGridView1.Rows.Add("CALL t", "Chama função na posição t");
            dataGridView1.Rows.Add("RETURN", "Retorno do procedimento");
        }
        
    }
}
