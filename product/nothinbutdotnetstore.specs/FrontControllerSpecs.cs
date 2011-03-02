 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_handling_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = the_dependency<CommandRegistry>();
                request =an<Request>();
                command_that_can_process_the_request = an<RequestCommand>();

                command_registry.Stub(x => x.get_the_command_that_can_handle(request))
                    .Return(command_that_can_process_the_request);

            };

            Because b = () =>
                sut.handle(request);

            It should_delegate_the_processing_to_the_command_that_can_run_the_request = () =>
                command_that_can_process_the_request.received(x => x.run(request));

            static RequestCommand command_that_can_process_the_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}
