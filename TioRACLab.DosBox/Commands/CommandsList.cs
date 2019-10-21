using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace TioRACLab.DosBox.Commands
{
    public class CommandsList : ObservableCollection<Command>
    {
        public CommandsList()
        {

        }

        public CommandsList(string commands)
            : this()
        {
            var commandsList = commands.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            foreach (var command in commandsList)
                this.Add(new CustomCommand(command));
        }

        public override string ToString()
        {
            var commands = new StringBuilder();

            foreach (var command in this)
                commands.AppendLine(command.ToString());

            return commands.ToString();
        }
    }
}
