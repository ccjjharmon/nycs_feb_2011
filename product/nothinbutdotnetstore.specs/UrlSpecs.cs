 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlSpecs
    {
        public abstract class concern : Observes
        {
        
        }

        [Subject(typeof(Url))]
        public class when_observation_name : concern
        {
            private Establish c = () =>
                                      {
                                          
                                          application_behavior = an<ApplicationBehaviour>();                                          
                                      };

            private Because b = () => result =Url.to_run<ApplicationBehaviour>();
                               

            private It should_return_a_string = () =>  { }


            private static ApplicationBehaviour application_behavior;
            private static string result;
        }
    }

    
    public static class Url
    {
        public static string to_run<T>()
        {
            throw new Exception();
        }
    }
}
