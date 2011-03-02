using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {

        private IEnumerable<RequestCommand> requestCommands;
        public RequestCommand DefaultCommand { get; set; }
        public DefaultCommandRegistry(IEnumerable<RequestCommand> requestCommands)
        {
            this.requestCommands = requestCommands;
        }

        public RequestCommand get_the_command_that_can_handle(Request request)
        {
            foreach (var requestCommand in requestCommands)
            {
                if (requestCommand.can_handle(request))
                {
                    return requestCommand;
                }
            }

            return DefaultCommand;
        }
    }
}