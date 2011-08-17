using System.Collections.Generic;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.Schema.Validator {
    [Subject(typeof(FluentJdf.Schema.Validator))]
    public class when_validating_a_message_without_working_around_ms_bug {
        static FluentJdf.LinqToJdf.Message message;
        static IList<FluentJdf.Schema.ValidationMessage> validationMessages;
        static IList<FluentJdf.Schema.ValidationMessage> secondPassValidationMessages;

        Establish context = () => message = FluentJdf.LinqToJdf.Message.Create().With().SenderId("test").AddCommand().SubmitQueueEntry().With().Id("123").Message;

        Because of = () => {
            validationMessages = message.ValidateJdf(true, false).ValidationMessages;
            message = FluentJdf.LinqToJdf.Message.Parse(message.ToString());
            secondPassValidationMessages = message.ValidateJdf(true, false).ValidationMessages;
        };

        It should_have_one_error_after_initial_validation = () => validationMessages.Count.ShouldEqual(1);

        It should_not_have_error_about_id_attribute_after_initial_validation = () => validationMessages[0].Message.ShouldNotContain("The 'ID' attribute is invalid - The value '123' is invalid according to its datatype");

        It should_have_error_about_xsi_type_after_initial_validate = () => validationMessages[0].Message.ShouldContain("xsi:type");

        It should_have_one_error_after_reload_validation = () => secondPassValidationMessages.Count.ShouldEqual(1);

        It should_have_error_about_id_attribute_after_reload_validation = () => secondPassValidationMessages[0].Message.ShouldContain("The 'ID' attribute is invalid - The value '123' is invalid according to its datatype");
    }
}