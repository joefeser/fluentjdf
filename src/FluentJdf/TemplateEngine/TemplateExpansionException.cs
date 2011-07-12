// This file was generated by C# Refactory.
// To modify this template, go to Tools/Options/C# Refactory/Code

using System;
using System.Runtime.Serialization;
using System.Text;
using FluentJdf.Resources;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// An exception occured during template processing.
	/// </summary>
	[Serializable]
	public class TemplateExpansionException : TemplateApiException {
	    int lineNumber = 0;
        int positionInLine = 0;

		/// <summary>
		/// Constructor with message and inner.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner exception.</param>
		public TemplateExpansionException(string message, Exception inner) : base(message, inner)
		{
			lineNumber = -1;
		}

		/// <summary>
		/// Constructor with no message.
		/// </summary>
		/// <param name="lineNumber">The line number in the xml template file where the exception occured.</param>
		/// <param name="positionInLine">The column number in the xml template file where the exception occured.</param>
		public TemplateExpansionException(int lineNumber, int positionInLine)
		{
			this.lineNumber = lineNumber;
			this.positionInLine = positionInLine;
		}

		/// <summary>
		/// Constructor with message
		/// </summary>
		/// <param name="lineNumber">The line number in the xml template file where the exception occured.</param>
		/// <param name="positionInLine">The column number in the xml template file where the exception occured.</param>
		/// <param name="Message">The error message</param>
		public TemplateExpansionException(int lineNumber, int positionInLine, string Message) : base(Message)
		{
			this.lineNumber = lineNumber;
			this.positionInLine = positionInLine;
		}

		/// <summary>
		/// Constructor with message and inner exception.
		/// </summary>
		/// <param name="lineNumber">The line number in the xml template file where the exception occured.</param>
		/// <param name="positionInLine">The column number in the xml template file where the exception occured.</param>
		/// <param name="Message">The error message</param>
		/// <param name="Inner">The inner exception.</param>
		public TemplateExpansionException(int lineNumber, int positionInLine, string Message, Exception Inner) : base(Message, Inner)
		{
			this.lineNumber = lineNumber;
			this.positionInLine = positionInLine;
		}
		
		/// <summary>
		/// For serialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TemplateExpansionException(SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			lineNumber = info.GetInt32("lineNumber");
			positionInLine = info.GetInt32("positionInLine");
		}

		/// <summary>
		/// Gets the error message.
		/// </summary>
		/// <value>The error message.</value>
		public override string Message
		{
			get
			{
				if (lineNumber != -1)
				{
					StringBuilder sb = new StringBuilder(Messages.TemplateExpansionException_MessageText);
					sb.Append(lineNumber);
					sb.Append(Messages.TemplateExpansionException_MessagePositionText);
					sb.Append(positionInLine);
					sb.Append(" -- ");
					sb.Append(base.Message);
					return sb.ToString();
				} 
				else 
				{
					return base.Message;
				}
			}
		}

		#region ISerializable Members

		/// <summary>
		/// Serialization writer.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("lineNumber", lineNumber);
			info.AddValue("positionInLine", positionInLine);
		}

		#endregion
	}

}