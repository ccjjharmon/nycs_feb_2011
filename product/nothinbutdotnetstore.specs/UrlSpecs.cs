using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs
{
    public class UrlSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Url))]
        public class when_building_a_url_to_target_a_behaviour : concern
        {

            Because b = () => 
                result = Url.to_run<MyBehaviourItem>();

            It should_return_a_string_containing_the_name_of_the_behaviour = () => 
                result.ShouldStartWith(typeof(MyBehaviourItem).Name);

            It should_add_the_handler_suffix_to_the_url = () =>
            {
                result.ShouldEndWith(".nyc");
            };
  

            static ApplicationBehaviour application_behavior;
            static string result;
        }

        private class MyBehaviourItem : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }

    }
}