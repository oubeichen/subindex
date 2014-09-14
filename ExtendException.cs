using System;

namespace Subindex
{
	/// <summary>
	/// 
	/// </summary>
	public class ExtendException : System.ApplicationException
	{
		public readonly int ExceptionID;

		public ExtendException(int ExceptionID)	:base(Pub.GetSetting("ExtendException"+ExceptionID))
		{
			this.ExceptionID=ExceptionID;
		}

	}
}
