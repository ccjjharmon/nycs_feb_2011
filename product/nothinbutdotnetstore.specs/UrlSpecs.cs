using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.spikes;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlSpecs
    {
        public abstract class concern : Observes<Url>
        {
        }

        [Subject(typeof (Url))]
        public class when_payload_is_included : concern
        {
            private Establish c = () =>
                                      {
                                          payload = an<Department>();
                                          payload.name = "Dept Name 1";
                                          payload.has_products = true;
                                          commandName = an<Expression>();
                                          commandHasProducts = an<Expression>();
                                          commandName = ExpressionUtil.get_expression<Department>(x => x.name);
                                          commandHasProducts = ExpressionUtil.get_expression<Department>(x => x.has_products);
                                      };

            private Because b = () =>
                                result = sut.to_run<OurBehaviour>().include_in_payload<Department>(payload)
                                    .the_detail(commandName)
                                    .the_detail(commandHasProducts).ToString();

            private It includes_the_payload_in_the_url = () =>
                                    {
                                        result.ShouldContain("name=Dept+Name+1");
                                        result.ShouldContain("has_products=true");
                                    };

            static Department payload;
            static string result;

            static Expression commandName;
            static Expression commandHasProducts;
        }

        [Subject(typeof (Url))]
        public class when_building_a_conditional_url : concern
        {
            private Establish c = () =>
                                      {
                                          the_condition = true;
                                          left = new LeftBehavior();
                                          right = new RightBehavior();
                                      };

            private Because b = () =>
                                result = sut.to_run_iif<LeftBehavior, RightBehavior>(the_condition).ToString();

            private It should_evaluate = () =>
                                         result.ShouldEqual(string.Format("{0}.nyc", typeof (LeftBehavior).Name));

            private static string path;

            private class RightBehavior : ApplicationBehaviour
            {
                public void run(Request request)
                {
                    throw new NotImplementedException();
                }
            }

            private static string result;

            private class LeftBehavior : ApplicationBehaviour
            {
                public void run(Request request)
                {
                    throw new NotImplementedException();
                }
            }

            private static bool the_condition;
            private static LeftBehavior left;
            private static RightBehavior right;
        }

        [Subject(typeof (Url))]
        public class when_building_a_url_to_target_a_behaviour : concern
        {
            private Because b = () =>
                                result = sut.to_run<OurBehaviour>().ToString();

            private It should_return_a_string_containing_the_name_of_the_behaviour = () =>
                                                                                     result.ShouldContain(
                                                                                         typeof (OurBehaviour).Name);

            private It should_end_with_the_handler_suffix = () =>
                                                            result.ShouldEndWith(".nyc");

            private static string result;
        }

        public class when_creating_a_request_match_for_a_behaviour : concern
        {
            private Because b = () =>
                                result = sut.to_match_request_for<OurBehaviour>();

            private It should_return_a_delegate_that_matches_the_expected_command = () =>
                                                                                    result.Method.DeclaringType.
                                                                                        ShouldEqual(
                                                                                            typeof (
                                                                                                RequestContainsCommand
                                                                                                <OurBehaviour>));

            private static RequestMatch result;
        }

        private class OurBehaviour : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}