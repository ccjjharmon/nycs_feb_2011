using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.specs
{   
    public class PropertyNameExpressionMapperSpecs
    {
        public abstract class concern : Observes<PropertyNameExpressionMapper,
                                            DefaultPropertyNameExpressionMapper>
        {
        
        }

        [Subject(typeof(DefaultPropertyNameExpressionMapper))]
        public class when_mapping_a_property_name_expression : concern
        {
            private Establish c = () =>
                {
                    accessor = (x => x.name);
                };

            private Because b = () =>
                    result = sut.map_from<ItemToTest>(accessor);
                                

            private It should_return_a_string = () =>
                    result.ShouldEqual(accessor.Body.downcast_to<MemberExpression>().Member.Name);

            private static string result;
            private static Expression<PropertyAccessor<ItemToTest, object>> accessor;
        }
    }

    public class ItemToTest
    {
        public string name { get; set; }
    }
}
