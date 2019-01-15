using System;

namespace MicroStorage
{
    public class CommandInvokeEventArgs
    {
        private string _message;
        private string _commandName;

        public string Message
        {
            get { return this._message; }
        }

        public string CommandName
        {
            get { return this._commandName; }
        }

        public CommandInvokeEventArgs(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", "Argument cannot be null or empty!");
            this._message = message;
        }

        public CommandInvokeEventArgs(string message, string commandName)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(commandName))
                throw new ArgumentNullException("message", "Argument cannot be null or empty!");
            this._message = message;
            this._commandName = commandName;
        }
    }
}
