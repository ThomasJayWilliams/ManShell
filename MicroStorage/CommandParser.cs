using System;

namespace MicroStorage
{
    public class CommandParser
    {
        private static CommandParser instance = new CommandParser();
        private string argument;
        private CommandBase command;

        public event CommandInvokeHandler OnInvoke;

        private CommandParser() { }

        public static CommandParser Current
        {
            get
            {
                if (instance == null)
                    instance = new CommandParser();
                return instance;
            }
        }

        public void RunCommand(string command)
        {
            this.command = null;
            this.argument = null;

            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException("command");

            ParseCommand(command);

            if (this.command == null)
                throw new NoCommandException("No commands have been parsed to run!");
            if (this.argument == null)
                throw new NoCommandArgumentException("Command argument cannot be null!");

            this.command.Invoke();

            if (this.OnInvoke != null)
                this.OnInvoke.Invoke(this, new CommandInvokeEventArgs("Command has been invoked!"));
        }

        private void ParseCommand(string command)
        {
            string arg = string.Empty,
                parsedCommand = string.Empty;
            int splitterIndex = command.IndexOf(" ", 0);

            if (splitterIndex > 0)
            {
                parsedCommand = command.Substring(0, splitterIndex).ToLower();
                arg = command.Substring(splitterIndex + 1);
            }
            else
                parsedCommand = command.Substring(0);

            if (string.IsNullOrEmpty(parsedCommand))
                throw new InvalidCommandException("Command is invalid and cannot be casted!");

            this.argument = arg;
            string _loweredArg = arg.ToLower();

            switch (parsedCommand)
            {
                case "add":
                    this.command = new AddCommand(this.argument);
                    break;
                case "show":
                    this.command = new ShowContentCommand();
                    break;
                case "scopein":
                    this.command = new ScopeInCommand(_loweredArg);
                    break;
                case "unscope":
                    this.command = new UnscopeCommand();
                    break;
                case "delete":
                    this.command = new DeleteCommand(_loweredArg);
                    break;
                case "quit":
                case "exit":
                    this.command = new AppCloseCommand();
                    break;
                default:
                    throw new InvalidCommandException("Invalid command!");
            }
        }
    }
}
