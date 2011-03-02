using System;
using System.Web;
using nothinbutdotnetstore.web.application.model;

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
            public InputModel get_a<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;

            }
        }
    }
}