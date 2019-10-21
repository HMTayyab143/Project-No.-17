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
                Add(command);
        }

        public Command Add(string command)
        {
            var cmd = Command.CreateCommand(command);
            Add(cmd);
            return cmd;
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
