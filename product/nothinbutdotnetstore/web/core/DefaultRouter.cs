using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRouter:Router
    {
        private readonly RequestCommand _command;

        public DefaultRouter(RequestCommand command)
        {
            _command = command;
        }

        public bool RequestMatch(Request request)
        {
            return _command.can_handle(request);
        }
    }
}