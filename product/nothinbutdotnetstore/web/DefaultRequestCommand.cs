using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultRequestCommand : RequestCommand
    {
        private RequestMatch match;

        public DefaultRequestCommand(RequestMatch match)
        {
            this.match = match;
        }

        public void run(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(Request request)
        {
            return this.match(request);
        }
    }
}