using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}