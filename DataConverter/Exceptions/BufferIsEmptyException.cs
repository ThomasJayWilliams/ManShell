using System;

namespace DataConverter
{
	public class BufferIsEmptyException : Exception
	{
		private const string defaultMessage = "Buffer is empty!";

		public BufferIsEmptyException() : base(defaultMessage) { }
		public BufferIsEmptyException(string message) : base(message) { }
	}
}
