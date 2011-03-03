using System.Collections.Generic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class GetTheProducts
    {
        public IEnumerable<Product> query(Request request)
        {
            return Stub.with<StubStoreCatalog>().get_products_for(request.map<Department>());
        }
    }
}