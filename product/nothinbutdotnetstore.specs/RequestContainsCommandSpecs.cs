using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class RequestContainsCommandSpecs
    {
        public abstract class concern : Observes<RequestContainsCommand<OurBehaviour>>
        {
        }

        [Subject(typeof(RequestContainsCommand<>))]
        public class when_matching_a_request_for_a_behaviour : concern
        {
            Establish c = () =>
            {
                request = an<Request>();

                request.Stub(x => x.raw_command).Return(
                    "http://localhost/concern/{0}.nyc?3434".format_using(typeof(OurBehaviour).Name));
            };

            Because b = () =>
                result = sut.matches(request);

            It should_match_if_the_request_path_contains_the_name_of_the_behaviour = () =>
                result.ShouldBeTrue();

            static Request request;
            static bool result;
        }

        public class OurBehaviour : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}