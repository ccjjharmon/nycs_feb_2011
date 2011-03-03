namespace nothinbutdotnetstore.web.core
{
    public class RequestContainsCommand<CommandToLookForInIncomingRequest>
        where CommandToLookForInIncomingRequest : ApplicationBehaviour
    {
        public bool matches(Request request)
        {
            return request.raw_command.Contains(typeof(CommandToLookForInIncomingRequest).Name);
        }
    }
}