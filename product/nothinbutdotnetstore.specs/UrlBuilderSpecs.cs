 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlBuilderSpecs
    {
        public abstract class concern : Observes<UrlBuilder<PayloadType>>
        {
        
        }

        [Subject(typeof(UrlBuilder<PayloadType>))]
        public class when_building_a_url : concern
        {
            private Establish c = () =>
                                      {
                                          baseurl = "base url";
                                          
                                          the_dependency<string>(baseurl);
                                      };

            private Because b = () =>
                                return = sut.ToString();

            private It should_return_a_url = () =>
                                result.ShouldEqual(baseurl);

            private static string result;
            private static string baseurl;
        }

        public class PayloadType
        {
            
        }
    }
}
