using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    //TODO - You should think about how to leverage this from our current design
    //TODO - think open closed once again
    public class StoreCatalogController
    {
        StoreCatalog catalog;

        public StoreCatalogController(StoreCatalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return catalog.get_the_main_departments_in_the_store();
        }

        public IEnumerable<Department> get_sub_departments_for(Department department)
        {
            return catalog.get_sub_departments_for(department);
        }

        public IEnumerable<Product> get_products_for(Department department)
        {
            return catalog.get_products_for(department);
        }
    }
}