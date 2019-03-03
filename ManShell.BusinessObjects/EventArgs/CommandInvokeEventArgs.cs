using System;

namespace ManShell.BusinessObjects
{
    public class CommandInvokeEventArgs
    {
        private string message;
        private string commandName;

        public string Message
        {
            get { return this.message; }
        }

        public string CommandName
        {
            get { return this.commandName; }
        }

        public CommandInvokeEventArgs(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", "Argument cannot be null or empty!");
            this.message = message;
        }

        public CommandInvokeEventArgs(string message, string commandName)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(commandName))
                throw new ArgumentNullException("Argument cannot be null or empty!");
            this.message = message;
            this.commandName = commandName;
        }
    }
}
