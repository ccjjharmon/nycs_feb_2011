 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.application.model;
 using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.tasks;
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
            private Establish c = () =>
                                      {
                                          products = ObjectFactory.create_a_set_of(100, () => new Product());
                                          request = an<Request>();
                                          response_engine = the_dependency<ResponseEngine>();
                                          store_catalog = the_dependency<StoreCatalog>();
                                          parent_department = an<Department>();

                                          request.Stub(x => x.get_a<Department>()).Return(parent_department);

                                          store_catalog.Stub(x => x.get_products_for(parent_department))
                                              .Return(products);
                                      };

            private Because b = () => sut.run(request)
                            ;


            private It should_display_list_of_products = () =>
                                                             {
                                                                 response_engine.display(products);
                                                             };

            private static StoreCatalog store_catalog;
            private static ResponseEngine response_engine;
            private static Request request;
            private static IEnumerable<Product> products;
            private static Department parent_department
                ;
        }
    }
}
