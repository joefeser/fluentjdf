using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using FluentJdf.LinqToJdf;
using FluentJdf.Resources;
using Infrastructure.Core.Logging;

namespace FluentJdf.TemplateEngine
{
	/// <summary>
	/// A template item that replaces text based on a name/value pair or the data from a table.
	/// </summary>
	public class VariableTemplateItem : TemplateItem {
	    readonly ILog logger = LogManager.GetLogger(typeof (VariableTemplateItem));
		private readonly string defaultValue;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parent">The parent item that contains this item.</param>
		/// <param name="name">The name of this item.</param>
		/// <param name="lineNumber">This item's line number within the xml template file.</param>
		/// <param name="positionInLine">This item's column number within the xml template file.</param>
		/// <param name="defaultValue">The default value used if a replacement value is not provided.  If this is null, the replacement data is 
		/// required.</param>
		/// <remarks>
		/// By default, variable names that contain a dot are assumed to come from a containing table.  That is, names in the form tableName.fieldName
		/// are assumed when there is a dot.  By default, fields can contain zero or one dot.  You can override this behavior by adding the DottedTemplateVarsAlwaysTables
		/// configuration item to your JdpSettings with value="false".  In this case, if the variable name contains more than one dot or a table with the correct
		/// name is not found in the template, the system will attempt to find a replacement variable in the StringDictionary with the dotted name.
		/// </remarks>
		protected internal VariableTemplateItem(TemplateItem parent, string name, int lineNumber, int positionInLine, string defaultValue) :
			base(parent, name, lineNumber, positionInLine)
		{
			this.defaultValue = defaultValue;
		}

		/// <summary>
		/// Gets the default value associated with this item.
		/// </summary>
		/// <value>The default value or null.</value>
		public string DefaultValue
		{
			get
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Writes data to the instance document based on replacement values.
		/// </summary>
		/// <param name="writer">The writer that will receive the text.</param>
		/// <param name="vars">Simple replacement variables.</param>
		/// <returns>True if the replacement took place.</returns>
		protected internal override bool Generate(TextWriter writer, Dictionary<string, object> vars)
		{
			string val = null;

			if (parentTableItem != null)
			{
				val = parentTableItem.GetVariableValue(name);
			} 
			else 
			{
                //todo: what if it is not a string.  Can we use dots to go get properties?
                if (vars.ContainsKey(name)) {
                    object v = vars[name];
                    if (v is DateTime) {
                        val = ((DateTime)v).ToJdfDateTimeString();
                    }
                    else {
                        val = v.ToString();
                    }

                }
			}
			if (val != null)
			{
				EscapeSpecialCharacters(ref val);
				writer.Write(val);
			} 
			else 
			{
                if (defaultValue != null)
                {
                    writer.Write(defaultValue);
                }
                else {
                    if (parentTableItem != null) {
                        var mess = string.Format("Required table replacement variable {0}.{1} does not exist in the supplied data set.",
                                                 parentTableItem.TableName, name);
                        logger.Error(string.Format(Messages.ErrorAtLineAndColumn, mess, lineNumber, positionInLine));
                        throw new TemplateExpansionException(lineNumber, positionInLine, mess);
                    }
                    var message = string.Format("Required replacement variable {0} does not exist in the supplied data set.", name);
                    logger.Error(string.Format(Messages.ErrorAtLineAndColumn, message, lineNumber, positionInLine));
                    throw new TemplateExpansionException(lineNumber, positionInLine, message);

                }
			}

			return true;
		}

		private void EscapeSpecialCharacters(ref string val)
		{
			val = val.Replace("&", "&amp;");
			val = val.Replace("<", "&lt;");
			val = val.Replace(">", "&gt;");
			val = val.Replace("'", "&apos;");
			val = val.Replace("\"", "&quot;");	
		}

		/// <summary>
		/// Returns a string representation of this item.
		/// </summary>
		/// <returns>A string representation of this item.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(" = ");
			if (defaultValue != null)
			{
				sb.Append(defaultValue);
			} 
			else 
			{
				sb.Append("NO DEFAULT");
			}

			if (parentTableItem != null)
			{
				sb.Append(" Table: ");
				sb.Append(parentTableItem.TableName);
			}
			return sb.ToString();
		}
	}
}
