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
    public class DefaultApplicationBehaviourSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            DefaultApplicationBehaviour>
        {
        
        }

        [Subject(typeof(DefaultApplicationBehaviour))]
        public class when_running_viewing_products_for_a_department : concern
        {
            static Request request;
            static ResponseEngine response_engine;
            static Department parent_department;
            static StoreCatalog store_catalog;
            static IEnumerable<Department> sub_departments;
            static StoreCatalogQuery query;

            Because b = () =>
                sut.run(request);

            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();
                parent_department = an<Department>();
                query = an<StoreCatalogQuery>();
                query = () => store_catalog.get_sub_departments_for(parent_department);
                provide_a_basic_sut_constructor_argument(query);

                sub_departments = ObjectFactory.create_a_set_of(100, () => new Department());
                request = an<Request>();

                request.Stub(x => x.map<Department>()).Return(parent_department);

                store_catalog.Stub(x => x.get_sub_departments_for(parent_department))
                    .Return(sub_departments);
            };

            It should_display_the_sub_departments = () =>
                response_engine.received(x => x.display(sub_departments));
        }

        [Subject(typeof(DefaultApplicationBehaviour))]
        public class when_running_get_main_departments : concern
        {
            Establish c = () =>
            {
                the_main_departments = ObjectFactory.create_a_set_of(100, () => new Department());
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();

                query = an<StoreCatalogQuery>();
                query = () => store_catalog.get_the_main_departments_in_the_store();
                provide_a_basic_sut_constructor_argument(query);

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
            static StoreCatalogQuery query;
        }

        [Subject(typeof(DefaultApplicationBehaviour))]
        public class when_running_view_the_departments_in_a_dept : concern
        {
            static Request request;
            static ResponseEngine response_engine;
            static Department parent_department;
            static StoreCatalog store_catalog;
            static IEnumerable<Department> sub_departments;
            static StoreCatalogQuery query;

            Because b = () =>
                sut.run(request);

            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();
                parent_department = an<Department>();

                query = an<StoreCatalogQuery>();
                query = () => store_catalog.get_sub_departments_for(parent_department);
                provide_a_basic_sut_constructor_argument<StoreCatalogQuery>(query);


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
