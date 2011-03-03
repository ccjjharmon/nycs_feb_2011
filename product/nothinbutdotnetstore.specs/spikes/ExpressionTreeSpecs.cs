using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using System.Linq;

namespace nothinbutdotnetstore.specs.spikes
{
    public class ExpressionTreeSpecs
    {
        public abstract class concern : Observes
        {
        }

        
        public class when_playing_around_with_expression_trees : concern
        {
            It should_be_able_to_get_the_name_of_a_property_that_is_being_pointed_at = () =>
            {
                ExpressionUtility.get_name_of_property<Person>(x => x.name)
                    .ShouldEqual("name");
            };

            It should_be_able_to_dynamically_create_an_expression_tree = () =>
            {
                Func<int, bool> is_even = x => x%2 == 0;
                is_even(2).ShouldBeTrue();

                ParameterExpression parameter_expression = Expression.Parameter(typeof(int),"x");
                ConstantExpression the_number_2 = Expression.Constant(2);
                BinaryExpression modulus = Expression.Modulo(parameter_expression,the_number_2);
                BinaryExpression is_equal_to_0 = Expression.Equal(modulus,Expression.Constant(0));
                Expression<Func<int, bool>> is_even_dynamic = Expression.Lambda<Func<int,bool>>(is_equal_to_0,parameter_expression);

                is_even_dynamic.Compile()(2).ShouldBeTrue();
            };

        }

        public class Person
        {
            public string name { get; set; }
        }
    }
}