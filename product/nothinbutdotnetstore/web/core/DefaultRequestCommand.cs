namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestMatch match;
        ApplicationBehaviour application_behaviour;

        public DefaultRequestCommand(RequestMatch match, ApplicationBehaviour application_behaviour)
        {
            this.match = match;
            this.application_behaviour = application_behaviour;
        }

        public void run(Request request)
        {
            application_behaviour.run(request);
        }

        public bool can_handle(Request request)
        {
            return match(request);
        }
    }
}