using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface ViewFactory
    {
        IHttpHandler create_view_to_render<ReportModel>(ReportModel the_model);
    }
}