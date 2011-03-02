using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubStoreCatalog : StoreCatalog
    {
        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Main Department 0")});
        }

        public IEnumerable<Department> get_sub_departments_for(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Sub Department 0")});
        }

        public IEnumerable<Product> get_products_for(Department parentDepartment)
        {
            return Enumerable.Range(1, 100).Select(x => new Product() { name = x.ToString("Product 0") });
        }
    }
}