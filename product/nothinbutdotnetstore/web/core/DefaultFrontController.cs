namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController():this(new DefaultCommandRegistry())
        {
        }

        public DefaultFrontController(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void handle(Request request)
        {
            command_registry.get_the_command_that_can_handle(request).run(request);
        }
    }
}