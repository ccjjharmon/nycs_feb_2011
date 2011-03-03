using System;
using System.Linq.Expressions;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.utility
{
    public class ExpressionUtility
    {
        public static string get_name_of_property<ItemToInspect>(Expression<Func<ItemToInspect, object>> property_accessor)
        {
            return property_accessor.Body.downcast_to<MemberExpression>()
                .Member.Name;
        }
    }
}