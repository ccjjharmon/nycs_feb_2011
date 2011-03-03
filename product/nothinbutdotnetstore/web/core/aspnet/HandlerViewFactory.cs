using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class HandlerViewFactory : ViewFactory
    {
        PageFactory page_factory;
        ViewPathRegistry view_path_registry;

        public HandlerViewFactory():this(Stub.with<StubViewPathRegistry>(),
            BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public HandlerViewFactory(ViewPathRegistry view_path_registry, PageFactory page_factory)
        {
            this.page_factory = page_factory;
            this.view_path_registry = view_path_registry;
        }

        public IHttpHandler create_view_to_render<ReportModel>(ReportModel the_model)
        {
            var view =
                (ViewFor<ReportModel>) page_factory(view_path_registry.get_path_to_view_that_can_render<ReportModel>(),typeof(ViewFor<ReportModel>));

            view.report_model = the_model;
            return view;
        }
    }
}