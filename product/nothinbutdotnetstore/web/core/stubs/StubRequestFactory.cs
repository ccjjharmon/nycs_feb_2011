using System.Web;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext the_current_context)
        {
            return new StubRequest(the_current_context);
        }

        class StubRequest : Request
        {
            HttpContext the_current_context;

            public StubRequest(HttpContext the_current_context)
            {
                this.the_current_context = the_current_context;
            }

            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;
            }

            public string raw_command
            {
                get { return the_current_context.Request.RawUrl; }
            }
        }
    }
}