using Onpoint.Commons.Core.CodeContracts;

namespace Jdp.Jdf.LinqToJdf {
    /// <summary>
    /// Set attributes on a JDF node.
    /// </summary>
    public class ResourceNodeAttributeBuilder : NodeAttributeBuilderBase {
        internal ResourceNodeAttributeBuilder(ResourceNodeBuilder nodeBuilder) : base(nodeBuilder) {
        }

        /// <summary>
        /// Gets the resource node builder for this attribute builder.
        /// </summary>
        /// <returns></returns>
        public ResourceNodeBuilder Node() {
            return (NodeBuilderBase as ResourceNodeBuilder);
        }

        /// <summary>
        /// Sets the ID of the resource and optionally does not update references.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateReferences"></param>
        /// <returns></returns>
        /// <remarks>By default, references are updated.</remarks>
        public ResourceNodeAttributeBuilder Id(string id, bool updateReferences = true) {
            Element.SetId(id, updateReferences);
            return this;
        }

        /// <summary>
        /// Create an input
        /// </summary>
        public ResourceNodeNameBuilder WithInput() { return new ResourceNodeNameBuilder((NodeBuilderBase as ResourceNodeBuilder).ParentJdfNode, ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return new ResourceNodeNameBuilder((NodeBuilderBase as ResourceNodeBuilder).ParentJdfNode, ResourceUsage.Output); }
    }
}