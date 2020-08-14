using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMachine
{
    class Command
    {
        public string mainCommand;
        public string firstAttribute;
        public string secondAttribute;

        public Command(string mainCommand)
        {
            this.mainCommand = mainCommand;
            this.firstAttribute = "";
            this.secondAttribute = "";
        }

        public Command(string mainCommand, string firstAttribute)
        {
            this.mainCommand = mainCommand;
            this.firstAttribute = firstAttribute;
            this.secondAttribute = "";
        }

        public Command(string mainCommand, string firstAttribute, string secondAttribute)
        {
            this.mainCommand = mainCommand;
            this.firstAttribute = firstAttribute;
            this.secondAttribute = secondAttribute;
        }
    }
}
