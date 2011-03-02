using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;
        private MissingRequestCommandFactory specialCase;

      
        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands, MissingRequestCommandFactory specialcase)
        {
            this.all_commands = all_commands;
            this.specialCase = specialcase;
        }

        public RequestCommand get_the_command_that_can_handle(Request request)
        {
            RequestCommand result = all_commands.FirstOrDefault(x => x.can_handle(request));
            return result == null ? specialCase.Invoke() : result;
        }
    }
}