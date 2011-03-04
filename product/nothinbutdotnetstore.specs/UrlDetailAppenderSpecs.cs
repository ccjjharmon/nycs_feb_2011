 using System;
 using System.Collections.Generic;
 using System.Linq.Expressions;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;
 using Rhino.Mocks.Constraints;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs
{   
    public class UrlDetailAppenderSpecs
    {
        public abstract class concern : Observes<UrlDetailAppender<TheItemWithDetails>,
                                            DefaultUrlDetailAppender<TheItemWithDetails>>
        {
        
        }

        [Subject(typeof(DefaultUrlDetailAppender<TheItemWithDetails>))]
        public class when_specifying_a_property_to_include_on_a_item : concern
        {
            Establish c = () =>
            {
                property_name = "blah";
                property_name_expression_mapper = the_dependency<PropertyNameExpressionMapper>();
                the_item = new TheItemWithDetails {name = "sdfsfsfdsfs"};
                tokens = new List<KeyValuePair<string, object>>();
                provide_a_basic_sut_constructor_argument(tokens);
                provide_a_basic_sut_constructor_argument(the_item);

                property_name_expression_mapper.Stub(
                    x => x.map_from(Arg<Expression<PropertyAccessor<TheItemWithDetails, object>>>.Is.NotNull)
                    ).Return(property_name);

                
            };

            Because b = () =>
               result =  sut.the_detail(x => x.name);

            It should_store_the_property_name_and_value_correctly = () =>
            {
                tokens[0].Key.ShouldEqual(property_name);
                tokens[0].Value.ShouldEqual(the_item.name);
            };

            It should_return_a_detail_appender_that_can_continue_the_detail_building = () =>
                result.ShouldBeAn<UrlDetailAppender<TheItemWithDetails>>().ShouldNotEqual(sut);
  

            static IList<KeyValuePair<string,object>> tokens;
            static string property_name;
            static TheItemWithDetails the_item;
            static PropertyNameExpressionMapper property_name_expression_mapper;
            static UrlDetailAppender<TheItemWithDetails> result;
        }
    }

    public class TheItemWithDetails
    {
        public string name { get; set; }
    }
}
