using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsInADepartment : ApplicationBehaviour
    {
        StoreCatalog store_catalog;
        ResponseEngine response_engine;

        public ViewTheDepartmentsInADepartment() : this(Stub.with<StubStoreCatalog>(),
                                                        new WebFormResponseEngine())
        {
        }

        public ViewTheDepartmentsInADepartment(StoreCatalog store_catalog, ResponseEngine response_engine)
        {
            this.store_catalog = store_catalog;
            this.response_engine = response_engine;
        }

        public void run(Request request)
        {
            response_engine.display(store_catalog.get_sub_departments_for(request.map<Department>()));
        }
    }
}