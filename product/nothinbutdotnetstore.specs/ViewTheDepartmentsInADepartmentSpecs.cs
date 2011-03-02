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
        #region Nested type: concern

        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        #endregion

        #region Nested type: when_run

        [Subject(typeof (ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            private static Request request;
            private static ResponseEngine response_engine;
            private static Department department;
            private static StoreCatalog store_catalog;
            private static IEnumerable<Department> sub_departments;

            private Because b = () =>
                                sut.run(request);

            private Establish c = () =>
                                      {
                                          sub_departments = ObjectFactory.create_a_set_of(100, () => new Department());
                                          request = an<Request>();
                                          response_engine = the_dependency<ResponseEngine>();
                                          department = an<Department>();

                                          store_catalog = the_dependency<StoreCatalog>();

                                          store_catalog.Stub(x => x.get_sub_departments_for(department))
                                              .Return(sub_departments);
                                      };

            private It should_display_the_sub_departments =
                () => response_engine.received(x => x.display(sub_departments));
        }

        #endregion
    }
}