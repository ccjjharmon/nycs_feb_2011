using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultFrontController : FrontController
    {
        private readonly CommandRegistry _command_registry;

        public DefaultFrontController(CommandRegistry command_registry)
        {
            _command_registry = command_registry;
        }

        public void handle(Request request)
        {
            var command = _command_registry.get_the_command_that_can_handle(request);
            command.run(request);
        }
    }
}