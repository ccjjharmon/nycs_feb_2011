using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            static Request request;
            static ResponseEngine response_engine;
            static Department parent_department;
            static StoreCatalog store_catalog;
            static IEnumerable<Department> sub_departments;

            Because b = () =>
                sut.run(request);

            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();
                parent_department = an<Department>();

                sub_departments = ObjectFactory.create_a_set_of(100, () => new Department());
                request = an<Request>();

                request.Stub(x => x.map<Department>()).Return(parent_department);

                store_catalog.Stub(x => x.get_sub_departments_for(parent_department))
                    .Return(sub_departments);
            };

            It should_display_the_sub_departments = () => 
                response_engine.received(x => x.display(sub_departments));
        }
    }
}