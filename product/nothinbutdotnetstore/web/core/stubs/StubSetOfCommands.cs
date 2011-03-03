using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return create_command<ViewTheDepartmentsInADepartment>();
            yield return create_command<ViewTheMainDepartmentsInTheStore>();
            yield return create_command<ViewTheProductsIntheDepartment>();
        }

        RequestCommand create_command<Behaviour>() where Behaviour : ApplicationBehaviour, new()
        {
            return new DefaultRequestCommand(Url.to_match_request_for<Behaviour>(),
                                                   new Behaviour());
        }
    }
}