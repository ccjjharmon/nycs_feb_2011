using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultFrontController : FrontController
    {
        readonly CommandRegistry registry;

        public DefaultFrontController()
        {
            registry = new DefaultCommandRegistry();
        }

        public void handle(Request request)
        {
            registry.get_the_command_that_can_handle(request);
        }
    }
}