 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.application.model;
using System.Collections;
using System.Collections.Generic;
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
            Establish c = () =>
            {
               the_departments = ObjectFactory.create_a_set_of(100, (() => new Department()));
                main_department = an<Department>();
                request = an<Request>();

                store_catalog = the_dependency<StoreCatalog>();
                response_engine = the_dependency<ResponseEngine>();

                store_catalog.Stub(x => x.get_the_departments_for(main_department))
                    .Return(the_departments);

            };

            Because b = () =>
                sut.run(request);

            private It should_list_departments_in_department = () =>
                response_engine.received(x => x.display(the_departments));



            static IEnumerable<Department> the_departments;
            static Request request;
            private static Department main_department;
            private static StoreCatalog store_catalog;
            private static ResponseEngine response_engine;
        }
    }
}
