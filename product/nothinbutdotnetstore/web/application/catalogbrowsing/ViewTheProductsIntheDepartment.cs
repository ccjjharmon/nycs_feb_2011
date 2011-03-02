using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsIntheDepartment : ApplicationBehaviour
    {
        ResponseEngine response_engine;
        StoreCatalog store_catalog;

        public ViewTheProductsIntheDepartment():this(Stub.with<StubResponseEngine>(),
            Stub.with<StubStoreCatalog>())
        {
        }

        public ViewTheProductsIntheDepartment(ResponseEngine response_engine, StoreCatalog store_catalog)
        {
            this.response_engine = response_engine;
            this.store_catalog = store_catalog;
        }

        public void run(Request request)
        {
            response_engine.display(store_catalog.get_products_for(request.map<Department>()));
        }
    }
}