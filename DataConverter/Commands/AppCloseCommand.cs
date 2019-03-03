using System;

namespace DataConverter
{
	internal class AppCloseCommand : CommandBase
	{
		internal override void Invoke()
		{
			Environment.Exit(0);

			this.isSuccessfull = true;
		}
	}
}
