using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace VirtualMachine
{
    public partial class MainForm : Form
    {
        private OpenFileDialog openFileDialog;
        private ArrayList arrayListCommands = new ArrayList();
        private Stack dataStack = new Stack();
        private int operationMode = 0;
        //operationMode 0 = normal // 1 = passo a passo

        private bool hasStringEnded = false;

        public MainForm()
        {
            openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            InitializeComponent();
        }

        private void parseFileCommands(String filePath)
        {
            string[] commands = System.IO.File.ReadAllLines(filePath);

            foreach (string command in commands)
            {
                string mainCommand = "";
                string firstAttribute = "";
                string secondAttribute = "";
                hasStringEnded = false;
                int position = 0;

                while (!hasStringEnded && ((command[position] <= 90 && command[position] >= 65) || (command[position] <= 57 && command[position] >= 48)))
                {
                    mainCommand += command[position];
                    position++;
                    hasStringEnded = verifyEndofString(command, position);
                }

                if (!hasStringEnded)
                {
                    position = findNextValidStringPosition(command, position);
                }

                while (!hasStringEnded && ((command[position] <= 90 && command[position] >= 65) || (command[position] <= 57 && command[position] >= 48)))
                {
                    firstAttribute += command[position];
                    position++;
                    hasStringEnded = verifyEndofString(command, position);
                }

                if (!hasStringEnded)
                {
                    position = findNextValidStringPosition(command, position);
                }

                while (!hasStringEnded && ((command[position] <= 90 && command[position] >= 65) || (command[position] <= 57 && command[position] >= 48)))
                {
                    secondAttribute += command[position];
                    position++;
                    hasStringEnded = verifyEndofString(command, position);
                }

                Command newCommand;

                if (firstAttribute.Equals(""))
                {
                    newCommand = new Command(mainCommand);
                }
                else if (secondAttribute.Equals(""))
                {
                    newCommand = new Command(mainCommand, firstAttribute);
                }
                else
                {
                    newCommand = new Command(mainCommand, firstAttribute, secondAttribute);
                }

                arrayListCommands.Add(newCommand);
            }
        }

        private bool verifyEndofString(string stringValue, int index)
        {
            return stringValue.Length == index;
        }

        private int findNextValidStringPosition(string command, int position)
        {
            while (!hasStringEnded && (command[position] > 90 || command[position] < 65) && (command[position] > 57 || command[position] < 48))
            {
                position++;
                hasStringEnded = verifyEndofString(command, position);
            }

            return position;
        }

        public string getComment(string command)
        {
            switch (command)
            {
                case "LDC":
                    return "Carregar constante";
                case "LDV":
                    return "Carregar valor";
                case "ADD":
                    return "Somar";
                case "SUB":
                    return "Subtrair";
                case "MULT":
                    return "Multiplicar";
                case "DIVI":
                    return "Dividir";
                case "INV":
                    return "Inverter sinal";
                case "AND":
                    return "Conjunção";
                case "OR":
                    return "Disjunção";
                case "NEG":
                    return "Negação";
                case "CME":
                    return "Comparar menor";
                case "CMA":
                    return "Comparar maior";
                case "CEQ":
                    return "Comparar igual";
                case "CDIF":
                    return "Comparar desigual";
                case "CMEQ":
                    return "Comparar menor ou igual";
                case "CMAQ":
                    return "Comparar maior ou igual";
                case "START":
                    return "Iniciar programa principal";
                case "HLT":
                    return "Parar";
                case "STR":
                    return "Armazenar valor";
                case "JMP":
                    return "Desviar sempre";
                case "JMPF":
                    return "Desviar se falso";
                case "NULL":
                    return "Nada";
                case "RD":
                    return "Leitura";
                case "PRN":
                    return "Impressão";
                case "ALLOC":
                    return "Alocar memória";
                case "DALLOC":
                    return "Desalocar memória";
                case "CALL":
                    return "Chamar procedimento ou função";
                case "RETURN":
                    return "Retornar de procedimento";
                default:
                    return "";
            }
        }

        private void toolStripMenuItem3_Click(Object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;
                    using (Stream str = openFileDialog.OpenFile())
                    {
                        arrayListCommands = new ArrayList();
                        parseFileCommands(filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            int i = 0;
            foreach (Object obj in arrayListCommands)
            {
                Command actualCommand = (Command)obj;

                dataGridView1.Rows.Add(
                    false,
                    i.ToString(),
                    actualCommand.mainCommand,
                    actualCommand.firstAttribute,
                    actualCommand.secondAttribute,
                    getComment(actualCommand.mainCommand));

                i++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) //entrada
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e) //saída
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //normal
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //passo a passo
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //executar
        {

        }
    }
}
