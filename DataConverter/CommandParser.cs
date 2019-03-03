using System;

using ManShell.BusinessObjects;

namespace DataConverter
{
	internal class CommandParser
	{
		private static CommandParser instance = new CommandParser();
		private string argument;
		private CommandBase command;

		internal event CommandInvokeHandler OnInvoke;

		private CommandParser() { }

		internal static CommandParser Current
		{
			get
			{
				if (instance == null)
					instance = new CommandParser();
				return instance;
			}
		}

		internal void RunCommand(string command)
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
				case "jsontoxml":
					this.command = new JSONToXMLCommand();
					break;
				case "xmltojson":
					this.command = new XMLToJSONCommand();
					break;
				case "loadxml":
					this.command = new LoadXMLCommand(this.argument);
					break;
				case "loadjson":
					this.command = new LoadJSONCommand(this.argument);
					break;
				case "show":
					this.command = new ShowContentCommand();
					break;
				case "clear":
					this.command = new ClearCommand();
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
