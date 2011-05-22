using System.Xml.Linq;
using Jdp.Jdf.LinqToJdf;
using Machine.Specifications;

namespace Jdp.Jdf.Tests.Unit.LinqToJdf.ResourceExtensions {
    [Subject(typeof(Jdf.LinqToJdf.ResourceExtensions))]
    public class when_using_is_resource_link_pool {
        static XElement jdf;

        Establish content = () => jdf = Ticket.Create().AddItentNode()
                                            .AddInput(ElementNames.BindingIntent);
                           

        It should_have_is_resource_link_pool_true_in_root_resource_link_pool = () => jdf.Element(ElementNames.ResourceLinkPool).IsResourceLinkPool().ShouldBeTrue();

        It should_have_is_resource_link_pool_false_on_root = () => jdf.IsResourceLinkPool().ShouldBeFalse();

        It should_have_is_resource_link_pool_false_on_root_resource_pool = () => jdf.Element(ElementNames.ResourcePool).IsResourceLinkPool().ShouldBeFalse();
    }
}