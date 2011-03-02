 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web;
 using System.Linq;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                the_command_that_can_process = an<RequestCommand>();
                all_commands = ObjectFactory.create_a_set_of(100, an<RequestCommand>).ToList();

                all_commands.Add(the_command_that_can_process);

                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);

                the_command_that_can_process.Stub(x => x.can_handle(request))
                    .Return(true);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_handle(request);


            It should_return_the_command_that_can_process = () =>
                result.ShouldEqual(the_command_that_can_process);

            static RequestCommand result;
            static RequestCommand the_command_that_can_process;
            static Request request;
            static IList<RequestCommand> all_commands;
        }
    }
}
