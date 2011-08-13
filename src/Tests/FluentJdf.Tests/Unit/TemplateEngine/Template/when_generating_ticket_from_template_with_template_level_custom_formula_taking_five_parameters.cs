using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_ticket_from_template_with_template_level_custom_formula_taking_five_parameters {
        static FluentJdf.LinqToJdf.Ticket ticketTemplate;
        static FluentJdf.LinqToJdf.Ticket ticketInstance;

        Establish context = () => {
            ticketTemplate = FluentJdf.LinqToJdf.Ticket.CreateIntent().WithInput().BindingIntent().With()
                .Attribute("test", "[:test=customTestFunction(testParm1, testParm2, testParm3, testParm4, testParm5):]").Ticket;
        };

        Because of =
            () => ticketInstance = FluentJdf.LinqToJdf.Ticket.CreateFromTemplate(ticketTemplate)
                                       .With()
                                       .NameValue("testParm1", "replacement1")
                                       .NameValue("testParm2", "replacement2")
                                       .NameValue("testParm3", "replacement3")
                                       .NameValue("testParm4", "replacement4")
                                       .NameValue("testParm5", "replacement5")
                                       .CustomFormula("customTestFunction", 
                                                      (parm1, parm2, parm3, parm4, parm5) => string.Format("this is a test {0}, {1}, {2}, {3}, {4}", parm1, parm2, parm3, parm4, parm5))
                                       .Generate();

        It should_have_result_of_function_variable_location = () => ticketInstance.Descendants(Resource.BindingIntent).First().GetAttributeValueOrNull("test")
                                                                        .ShouldEqual("this is a test replacement1, replacement2, replacement3, replacement4, replacement5");
    }
}