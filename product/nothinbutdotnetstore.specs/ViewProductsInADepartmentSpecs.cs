using System.Collections.Generic;
using System.Collections;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewProductsInADepartment>
        {
        
        }

        [Subject(typeof(ViewProductsInADepartment))]
        public class when_run : concern
        {
            static Request request;
            static ResponseEngine response_engine;
            static Department department;
            static StoreCatalog store_catalog;
            static IEnumerable<Product> products;

            Because b = () =>
                sut.run(request);

            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();
                department = an<Department>();

                products = ObjectFactory.create_a_set_of(100, () => new Product());
                request = an<Request>();

                request.Stub(x => x.get_a<Department>()).Return(department);

                store_catalog.Stub(x => x.get_products_for(department))
                    .Return(products);
            };

            It should_display_the_sub_departments = () =>
                response_engine.received(x => x.display(products));
        }
    }
}
