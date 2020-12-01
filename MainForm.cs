using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualMachine
{
    public partial class MainForm : Form
    {
        private OpenFileDialog openFileDialog;
        private ArrayList arrayListCommands = new ArrayList();
        private Stack dataStack = new Stack();
        private readonly ManualResetEvent mre = new ManualResetEvent(false);
        private bool hasStringEnded = false;
        private bool isStepByStep;

        public MainForm()
        {
            openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
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
                        dataGridView1.Rows.Clear();
                        dataStack.cleanStack();
                        parseFileCommands(filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            showCodeDataInGrid();
        }

        private void toolStripMenuItem8_Click(Object sender, EventArgs e)
        {
            ComandosForm comandosForm = new ComandosForm();
            comandosForm.ShowDialog();
        }

        private void toolStripMenuItem9_Click(Object sender, EventArgs e)
        {
            ComoUsarForm form = new ComoUsarForm();
            form.ShowDialog();
        }

        private void toolStripMenuItem4_Click(Object sender, EventArgs e)
        {
            arrayListCommands = new ArrayList();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataStack.cleanStack();
            showCodeDataInGrid();
        }

        private int findCommandPosition(string command)
        {
            int count = 0;

            foreach (Object obj in arrayListCommands)
            {
                Command actualCommand = (Command)obj;

                if (actualCommand.mainCommand.Equals(command))
                {
                    return count;
                }

                count++;
            }

            return -1;
        }

        private void updateDataStackGrid()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            for (int i = 0; i <= dataStack.getLength(); i++)
            {
                dataGridView2.Rows.Add(
                    i.ToString(),
                    dataStack.getPosition(i).ToString()
                    );
            }
        }

        private void showCodeDataInGrid()
        {
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

        private void button1_Click(object sender, EventArgs e) //executar
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";

            runningCodeAsync();
        }

        private bool hasBreakPoint(int position)
        {
            return Boolean.Parse(dataGridView1.Rows[position].Cells[0].Value.ToString());
        }

        private void selectRightRow(int selectedPosition)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
            }

            dataGridView1.Rows[selectedPosition].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[selectedPosition].Cells[0];
        }

        private async Task runningCodeAsync()
        {
            if (arrayListCommands.Count != 0)
            {
                int i = 0;
                Command actualCommand;

                do
                {
                    actualCommand = (Command)arrayListCommands[i];

                    if (isStepByStep || hasBreakPoint(i))
                    {
                        selectRightRow(i);

                        await Task.Run(() => {
                            mre.WaitOne();
                            mre.Reset();
                        });
                    }

                    string string1;
                    string string2;
                    string result;
                    int int1;

                    switch (actualCommand.mainCommand)
                    {
                        case "LDC":
                            dataStack.push(actualCommand.firstAttribute);
                            break;

                        case "LDV":
                            int1 = int.Parse(actualCommand.firstAttribute);
                            result = (string)dataStack.getPosition(int1);
                            dataStack.push(result);
                            break;

                        case "ADD":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();
                            result = (int.Parse(string2) + int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "SUB":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();
                            result = (int.Parse(string2) - int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "MULT":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();
                            result = (int.Parse(string2) * int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "DIVI":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();
                            result = (int.Parse(string2) / int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "INV":
                            string1 = (string)dataStack.pop();
                            result = (-int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "AND":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (string1.Equals("1") && string2.Equals("1"))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "OR":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (string1.Equals("1") || string2.Equals("1"))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "NEG":
                            string1 = (string)dataStack.pop();
                            result = (1 - int.Parse(string1)).ToString();
                            dataStack.push(result);
                            break;

                        case "CME":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (int.Parse(string2) < int.Parse(string1))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "CMA":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (int.Parse(string2) > int.Parse(string1))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "CEQ":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (string1.Equals(string2))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "CDIF":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (string1.Equals(string2))
                            {
                                result = "0";
                            }
                            else
                            {
                                result = "1";
                            }

                            dataStack.push(result);
                            break;

                        case "CMEQ":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (int.Parse(string2) <= int.Parse(string1))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "CMAQ":
                            string1 = (string)dataStack.pop();
                            string2 = (string)dataStack.pop();

                            if (int.Parse(string2) >= int.Parse(string1))
                            {
                                result = "1";
                            }
                            else
                            {
                                result = "0";
                            }

                            dataStack.push(result);
                            break;

                        case "STR":
                            string1 = (string)dataStack.pop();
                            dataStack.setPosition(int.Parse(actualCommand.firstAttribute), string1);
                            break;

                        case "JMP":
                            i = findCommandPosition(actualCommand.firstAttribute) - 1;
                            break;

                        case "JMPF":
                            string1 = (string)dataStack.pop();

                            if (string1.Equals("0"))
                            {
                                i = findCommandPosition(actualCommand.firstAttribute) - 1;
                            }
                            break;

                        case "RD":
                            using (EntradaForm entradaForm = new EntradaForm())
                            {
                                if (entradaForm.ShowDialog() == DialogResult.OK)
                                {
                                    result = entradaForm.SelectedText;

                                    richTextBox1.Text += result + "\n";
                                    dataStack.push(result);
                                }
                            }

                            break;

                        case "PRN":
                            string1 = (string)dataStack.pop();
                            richTextBox2.Text += string1 + "\n";
                            break;

                        case "ALLOC":
                            for (int k = 0; k <= int.Parse(actualCommand.secondAttribute)-1; k++)
                            {
                                string1 = (string)dataStack.getPosition(k + int.Parse(actualCommand.firstAttribute));

                                if (string1 == null) string1 = "";

                                dataStack.push(string1);
                            }
                            break;

                        case "DALLOC":
                            for (int k = int.Parse(actualCommand.secondAttribute)-1; k >= 0; k--)
                            {
                                string1 = (string)dataStack.pop();
                                dataStack.setPosition((k + int.Parse(actualCommand.firstAttribute)), string1);
                            }
                            break;

                        case "CALL":
                            result = (i + 1).ToString();
                            dataStack.push(result);
                            i = findCommandPosition(actualCommand.firstAttribute)-1;
                            break;

                        case "RETURN":
                            string1 = (string)dataStack.pop();
                            i = int.Parse(string1)-1;
                            break;

                        case "START":
                        case "NULL":
                        case "HLT":
                            break;
                        default:
                            break;
                    }

                    updateDataStackGrid();
                    i++;
                } while (actualCommand.mainCommand != "HLT");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Selected = false;
                }
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
            isStepByStep = false;

            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //passo a passo
        {
            isStepByStep = true;

            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mre.Set();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
