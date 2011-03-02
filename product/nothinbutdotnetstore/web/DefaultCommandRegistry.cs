using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;
        MissingRequestCommandFactory special_case;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands, MissingRequestCommandFactory specialcase)
        {
            this.all_commands = all_commands;
            this.special_case = specialcase;
        }

        public RequestCommand get_the_command_that_can_handle(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request))
                ?? special_case();
        }
    }
}