using ManShell.BusinessObjects;
using DataConverter.Converters;

namespace DataConverter
{
	internal interface IBuffer
	{
		string Data { get; }
		string TypeName { get; }
		IConverter Converter { get; }

		void Convert();
		void LoadFromFile(System.IO.FileInfo file);
	}

	internal class BufferManager
	{
		private static BufferManager instance = new BufferManager();
		private static object lockToken = new object();
		private IBuffer buffer;

		public IBuffer Buffer
		{
			get { return this.buffer; }
		}

		internal static BufferManager Current
		{
			get
			{
				lock (lockToken)
				{
					if (instance == null)
						instance = new BufferManager();
					return instance;
				}
			}
		}

		private bool CheckBuffer()
		{
			if (this.buffer != null)
				return Application.Current.RequestConfirmation(string.Format(
					"Buffer is not empty! Currently buffer contains {0} data! Current data will be replaced. Continue?",
					buffer.TypeName));
			return true;
		}

		internal void CreateJSONBuffer(System.IO.FileInfo info)
		{
			if (this.CheckBuffer())
				this.buffer = new JSONBuffer();
			this.buffer.LoadFromFile(info);
		}
		internal void CreateXMLBuffer(System.IO.FileInfo info)
		{
			if (this.CheckBuffer())
				this.buffer = new XMLBuffer();
			this.buffer.LoadFromFile(info);
		}

		internal void ClearBuffer()
		{
			this.buffer = null;
		}

		private BufferManager() { }
	}
}
