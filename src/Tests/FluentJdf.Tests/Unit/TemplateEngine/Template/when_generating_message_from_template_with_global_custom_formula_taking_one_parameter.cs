using System.Linq;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.TemplateEngine.Template {
    [Subject(typeof(FluentJdf.TemplateEngine.Template))]
    public class when_generating_message_from_template_with_global_custom_formula_taking_one_parameter {
        static FluentJdf.LinqToJdf.Message messageTemplate;
        static FluentJdf.LinqToJdf.Message messageInstance;

        Establish context = () => {
            messageTemplate = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With()
                .Attribute("test", "[:test=customTestFunction(testParm1):]").Message;

            FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTemplateEngineSettings()
                .CustomFormula("customTestFunction", parm1 => string.Format("this is a test {0}", parm1));
        };

        Because of =
            () => messageInstance = FluentJdf.LinqToJdf.Message.CreateFromTemplate(messageTemplate)
                                        .With()
                                        .NameValue("testParm1", "replacement1")
                                        .Generate();

        It should_have_result_of_function_variable_location = () => messageInstance.Descendants(Element.Command).First().GetAttributeValueOrNull("test")
            .ShouldEqual("this is a test replacement1");
    }
}