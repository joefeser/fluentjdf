
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Build attributes for FlushResourcesCommandBuilder.
	/// </summary>
	public class FlushResourcesCommandAttributeBuilder : JmfAttributeBuilderBase {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="builder"></param>
		internal FlushResourcesCommandAttributeBuilder(FlushResourcesCommandBuilder builder)
			: base(builder) {
		}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public FlushResourcesCommandAttributeBuilder Attribute(XName name, string value) {
			ParameterCheck.ParameterRequired(name, "name");

			Element.SetAttributeValue(name, value);
			return this;
		}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public FlushResourcesCommandAttributeBuilder Id(string id) {

			Element.SetAttributeValue("ID", id);
			return this;
		}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public FlushResourcesCommandAttributeBuilder UniqueId() {
			return Id(Globals.CreateUniqueId(FlushResourcesCommandBuilder.IdPrefix));
		}
		
		/// <summary>
		/// Add a JDF that will be sent with this submit queue entry.
		/// </summary>
		/// <param name="ticket"></param>
		/// <returns></returns>
		public FlushResourcesCommandAttributeBuilder Ticket(Ticket ticket) {
			ParameterCheck.ParameterRequired(ticket, "ticket");
		
			ParentJmfNode.Message.AssociatedTicket = ticket;
			return this;
		}
	}
}

