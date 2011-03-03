 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
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
                                          application_behavior = new ViewTheDepartmentsInADepartment();
                                          
                                      };

            private Because b = () => result =Url.to_run<ApplicationBehaviour>();
                               

            private It should_return_a_string = () =>  result.Equals("ViewTheDepartmentsInADepartment"); 


            private static ApplicationBehaviour application_behavior;
            private static string result;
        }
    }

    
    public static class Url<T>
    {
        public static string to_run<T>()
        {
            return get_url_name(Typeof(T));
        }

        private static string get_url_name(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
