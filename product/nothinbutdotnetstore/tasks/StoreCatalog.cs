using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks
{
    public interface StoreCatalog
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_sub_departments_for(Department department);
    }
}