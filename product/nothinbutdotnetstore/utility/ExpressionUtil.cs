using System;
using System.Linq.Expressions;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.utility
{
    public class ExpressionUtil
    {
        public static string get_name_of_property<ItemToInspect>(Expression<Func<ItemToInspect, object>> property_accessor)
        {
            return property_accessor.Body.downcast_to<MemberExpression>()
                .Member.Name;
        }

        public static Expression get_expression<ItemToInspect>(Expression<Func<ItemToInspect, object>> property_accessor)
        {
            return property_accessor;
        }
    }
}