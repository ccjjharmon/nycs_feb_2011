using System.Web;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class BasicHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public BasicHandler():this(new DefaultFrontController(),
            Stub.with<StubRequestFactory>())
        {
        }

        public BasicHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.handle(request_factory.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}