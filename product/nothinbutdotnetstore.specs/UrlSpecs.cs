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
        public class when_building_a_conditional_url : concern
        {
            Establish c = () =>
            {
                the_condition = true;
                left = new LeftBehavior();
                right = new RightBehavior();
            };

            Because b = () =>
                result = Url.to_run_iif<LeftBehavior, RightBehavior>(the_condition);

            It should_evaluate = () => 
                result.ShouldEqual(string.Format("{0}.nyc", typeof(LeftBehavior).Name));

            static string path;

            class RightBehavior : ApplicationBehaviour
            {
                public void run(Request request)
                {
                    throw new NotImplementedException();
                }
            }

            static string result;

            class LeftBehavior : ApplicationBehaviour
            {
                public void run(Request request)
                {
                    throw new NotImplementedException();
                }
            }

            static bool the_condition;
            static LeftBehavior left;
            static RightBehavior right;
        }

        [Subject(typeof(Url))]
        public class when_building_a_url_to_target_a_behaviour : concern
        {
            Because b = () =>
                result = Url.to_run<OurBehaviour>();

            It should_return_a_string_containing_the_name_of_the_behaviour = () =>
                result.ShouldContain(typeof(OurBehaviour).Name);

            It should_end_with_the_handler_suffix = () =>
                result.ShouldEndWith(".nyc");

            static string result;
        }

        public class when_creating_a_request_match_for_a_behaviour : concern
        {
            Because b = () =>
                result = Url.to_match_request_for<OurBehaviour>();

            It should_return_a_delegate_that_matches_the_expected_command = () =>
                result.Method.DeclaringType.ShouldEqual(typeof(RequestContainsCommand<OurBehaviour>));

            static RequestMatch result;
        }

        class OurBehaviour : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}