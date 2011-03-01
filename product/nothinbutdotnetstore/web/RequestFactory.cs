using System.Web;

namespace nothinbutdotnetstore.web
{
    public interface RequestFactory
    {
        Request create_request_from(HttpContext the_current_context);
    }
}