using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewResultFor<ReportModel> : ApplicationBehaviour
    {
        ResponseEngine response_engine;
        Query<ReportModel> query;

        public ViewResultFor(Query<ReportModel> query) : this(
            new WebFormResponseEngine(), query
            )
        {
        }

        public ViewResultFor(ResponseEngine response_engine,
                             Query<ReportModel> query)
        {
            this.response_engine = response_engine;
            this.query = query;
        }

        public void run(Request request)
        {
            response_engine.display(this.query(request));
        }
    }
}