using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_to_view_that_can_render<ReportModel>()
        {
            if (typeof(ReportModel).Equals(typeof(IEnumerable<Department>))) return create_view_to("DepartmentBrowser");
            return create_view_to("ProductBrowser");
        }

        string create_view_to(string page_name)
        {
            return string.Format("~/views/{0}.aspx",page_name);
        }
    }
}