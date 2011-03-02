using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<ReportModel>(ReportModel model)
        {
            HttpContext.Current.Items.Add("blah", model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}