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
    public class ViewTheProductsIntheDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheProductsIntheDepartment>
        {
        }

        [Subject(typeof(ViewTheProductsIntheDepartment))]
        public class when_observation_name : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                store_catalog = the_dependency<StoreCatalog>();

                products = ObjectFactory.create_a_set_of(100, () => new Product());
                request = an<Request>();
                parent_department = an<Department>();

                request.Stub(x => x.map<Department>()).Return(parent_department);

                store_catalog.Stub(x => x.get_products_for(parent_department))
                    .Return(products);
            };

            Because b = () => 
                sut.run(request);

            It should_display_list_of_products = () => 
                response_engine.display(products);

            static StoreCatalog store_catalog;
            static ResponseEngine response_engine;
            static Request request;
            static IEnumerable<Product> products;

            static Department parent_department
                              ;
        }
    }
}