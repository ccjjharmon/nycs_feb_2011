using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;
        private MissingRequestCommandFactory missingcmdfactory;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> list, MissingRequestCommandFactory missingcommandfactory)
        {
            this.missingcmdfactory = missingcommandfactory;
            this.all_commands = all_commands;
        }

        public RequestCommand get_the_command_that_can_handle(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request)) ?? this.missingcmdfactory.Invoke();
        }
    }
}