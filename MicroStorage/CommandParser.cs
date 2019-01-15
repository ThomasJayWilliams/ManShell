﻿using System;

namespace MicroStorage
{
    public class CommandParser
    {
        private static CommandParser _instance = new CommandParser();
        private string _argument;
        private CommandBase _command;

        public event CommandInvokeHandler OnInvoke;

        private CommandParser() { }

        public static CommandParser Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CommandParser();
                return _instance;
            }
        }

        public void RunCommand(string command)
        {
            this._command = null;
            this._argument = null;

            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException("command");

            ParseCommand(command);

            if (this._command == null)
                throw new NoCommandException("No commands have been parsed to run!");
            if (this._argument == null)
                throw new NoCommandArgumentException("Command argument cannot be null!");

            this._command.Invoke();

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

            this._argument = arg;
            string _loweredArg = arg.ToLower();

            switch (parsedCommand)
            {
                case "add":
                    this._command = new AddCommand(this._argument);
                    break;
                case "show":
                    this._command = new ShowContentCommand();
                    break;
                case "scopein":
                    this._command = new ScopeInCommand(_loweredArg);
                    break;
                case "unscope":
                    this._command = new UnscopeCommand();
                    break;
                case "delete":
                    this._command = new DeleteCommand(_loweredArg);
                    break;
                case "quit":
                case "exit":
                    this._command = new AppCloseCommand();
                    break;
                default:
                    throw new InvalidCommandException("Invalid command!");
            }
        }
    }
}
