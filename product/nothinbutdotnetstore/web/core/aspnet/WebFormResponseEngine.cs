using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormResponseEngine : ResponseEngine
    {
        ViewFactory view_factory;
        GetTheCurrentContext current_context_resolution;

        public WebFormResponseEngine() : this(
            new HandlerViewFactory(),
            () => HttpContext.Current)
        {
        }

        public WebFormResponseEngine(ViewFactory view_factory, GetTheCurrentContext current_context_resolution)
        {
            this.view_factory = view_factory;
            this.current_context_resolution = current_context_resolution;
        }

        public void display<ReportModel>(ReportModel model)
        {
            view_factory.create_view_to_render(model).ProcessRequest(current_context_resolution());
        }
    }
}