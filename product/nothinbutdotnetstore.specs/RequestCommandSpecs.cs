 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.specs
{   
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determining_if_it_can_handle_a_request : concern
        {

            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestMatch>(x => true);
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();


            static bool result;
            static Request request;
        }
    }
}
