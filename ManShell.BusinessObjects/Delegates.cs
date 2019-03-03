namespace ManShell.BusinessObjects
{
	public delegate void CommandInvokeHandler(object sender, CommandInvokeEventArgs e);
	public delegate void FileLoadingHandler(FileLoadingEventArgs e);
	public delegate bool ConfirmationRequest(string text);
}
