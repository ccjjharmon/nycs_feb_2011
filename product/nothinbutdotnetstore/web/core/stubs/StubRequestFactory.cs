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
            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;

            }

            public string raw_command
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}