using System;
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
        private Stack codeStack = new Stack();
        private Stack dataStack = new Stack();

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

                codeStack.push(newCommand);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;
                    using (Stream str = openFileDialog.OpenFile())
                    {
                        codeStack.cleanStack();
                        parseFileCommands(filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
