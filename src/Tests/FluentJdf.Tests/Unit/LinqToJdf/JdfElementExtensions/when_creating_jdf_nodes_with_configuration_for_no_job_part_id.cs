using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfElementExtensions {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfElementExtensions))]
    public class when_creating_jdf_nodes_with_configuration_for_no_job_part_id
    {
        static FluentJdf.LinqToJdf.Ticket ticket;

        Establish context = () => FluentJdf.Configuration.FluentJdfLibrary.Settings.WithJdfAuthoringSettings().GenerateJobPartId(false);

        Because of = () => ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().AddIntent().Ticket;

        It should_have_job_id_in_root = () => ticket.Root.GetJobId().ShouldNotBeNull();

        It should_not_have_job_part_id_in_root = () => ticket.Root.GetJobPartId().ShouldBeNull();

        It should_not_have_job_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobId().ShouldBeNull();

        It should_not_have_job_part_id_in_second_level = () => ticket.Root.Element(Element.JDF).GetJobPartId().ShouldBeNull();
    }
}