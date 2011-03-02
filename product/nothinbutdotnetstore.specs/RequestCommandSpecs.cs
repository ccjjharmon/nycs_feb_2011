 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determining_if_it_can_handle_a_request : concern
        {

            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument<RequestMatch>(x => true);
                request = an<Request>();
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();


            static bool result;
            static Request request;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_behaviour = the_dependency<ApplicationBehaviour>();
                provide_a_basic_sut_constructor_argument<RequestMatch>(x => true);
            };

            Because b = () =>
                sut.run(request);


            It should_trigger_the_application_specific_behaviour_to_do_the_work = () =>
                application_behaviour.received(x => x.run(request));

            static ApplicationBehaviour application_behaviour;
            static Request request;
        }
    }
}
