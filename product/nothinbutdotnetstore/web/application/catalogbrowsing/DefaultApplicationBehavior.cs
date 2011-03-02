using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class DefaultApplicationBehaviour : ApplicationBehaviour
    {
        StoreCatalog store_catalog;
        ResponseEngine response_engine;
        StoreCatalogQuery query;

        public DefaultApplicationBehaviour(StoreCatalogQuery query) : this(Stub.with<StubStoreCatalog>(),
                                                        Stub.with<StubResponseEngine>(), query)
        {
        }

        public DefaultApplicationBehaviour(StoreCatalog store_catalog, ResponseEngine response_engine, StoreCatalogQuery _query)
        {
            this.store_catalog = store_catalog;
            this.response_engine = response_engine;
            this.query = _query;
        }

        public void run(Request request)
        {
            response_engine.display(this.query.Invoke());
        }
    }
}