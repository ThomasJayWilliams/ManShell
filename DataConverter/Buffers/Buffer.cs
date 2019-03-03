﻿using ManShell.BusinessObjects;
using DataConverter.Converters;

namespace DataConverter
{
	internal interface IBuffer
	{
		string Data { get; }
		string TypeName { get; }
		IConverter Converter { get; set; }

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

		private bool ValidateFile(string extension)
		{
			foreach (var item in Globals.SupportedExtensions)
				if (string.CompareOrdinal(item, extension) == 0)
					return true;
			return false;
		}

		private IBuffer GetBuffer(string extension)
		{
			switch (extension)
			{
				case ".json":
					return new JSONBuffer();
				case ".xml":
					return new XMLBuffer();
				default:
					return null;
			}
		}

		internal void ConvertToJSON()
		{
			if (this.buffer is XMLBuffer)
				this.buffer.Converter = new XMLToJSONConverter(this.buffer.Data);
			this.buffer.Convert();
		}

		internal void ConvertToXML()
		{
			if (this.buffer is JSONBuffer)
				this.buffer.Converter = new JSONToXMLConverter(this.buffer.Data);
			this.buffer.Convert();
		}

		internal void CreateBuffer(System.IO.FileInfo info)
		{
			if (this.CheckBuffer() && this.ValidateFile(info.Extension))
			{
				this.buffer = GetBuffer(info.Extension);
				if (this.buffer != null)
					this.buffer.LoadFromFile(info);
			}
		}

		internal void ClearBuffer()
		{
			this.buffer = null;
		}

		private BufferManager() { }
	}
}
