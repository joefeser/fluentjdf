
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
	/// <summary>
	/// Used to build ForceGang
	/// </summary>
	public partial class ForceGangQueryBuilder : QueryBuilder {
		internal const string IdPrefix = "FG_";

		internal ForceGangQueryBuilder(JmfNodeBuilder parent)
			: base(parent, Query.ForceGang, IdPrefix) {
			ParameterCheck.ParameterRequired(parent, "parent");
		}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public ForceGangQueryAttributeBuilder With() {
			return new ForceGangQueryAttributeBuilder(this);
		}
	}
}
