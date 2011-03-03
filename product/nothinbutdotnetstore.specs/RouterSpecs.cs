using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class RouterSpecs
    {
        public abstract class concern : Observes<Router,
                                            DefaultRouter>
        {
        
        }

        [Subject(typeof(DefaultRouter))]
        public class when_routing : concern
        {
            private It should_tell_if_requests_url_matches = () => result.ShouldBeTrue();
            private static bool result;


            private Because b = () =>
                                result = sut.RequestMatch(request);

            private Establish c = () =>
                                      {
                                          request = an<Request>();

                                          request.Stub(x => x.map<Department>());
                                      };

            private static Request request;
        }
    }
}
