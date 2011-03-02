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
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheMainDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                the_main_departments = ObjectFactory.create_a_set_of(100, () => new Department());
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();

                store_catalog.Stub(x => x.get_the_main_departments_in_the_store())
                    .Return(the_main_departments);

            };

            Because b = () =>
                sut.run(request);

            It should_display_the_list_of_the_main_departments = () =>
                response_engine.received(x => x.display(the_main_departments));

            static ResponseEngine response_engine;
            static IEnumerable<Department> the_main_departments;
            static Request request;
            static StoreCatalog store_catalog;
        }
    }
}