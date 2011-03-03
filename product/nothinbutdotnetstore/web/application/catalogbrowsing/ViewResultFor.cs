using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewResultFor<ReportModel> : ApplicationBehaviour
    {
        ResponseEngine response_engine;
        Query<ReportModel> query;

        public ViewResultFor(Query<ReportModel> query) : this(
            Stub.with<StubResponseEngine>(), query
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