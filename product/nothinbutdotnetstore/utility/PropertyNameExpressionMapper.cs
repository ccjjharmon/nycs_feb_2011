using System.Linq.Expressions;

namespace nothinbutdotnetstore.utility
{
    public interface PropertyNameExpressionMapper
    {
        string map_from<Item>(Expression<PropertyAccessor<Item, object>> property_accessor);

    }
}