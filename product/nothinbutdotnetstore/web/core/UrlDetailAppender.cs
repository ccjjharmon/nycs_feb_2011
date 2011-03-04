using System.Linq.Expressions;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlDetailAppender<PayloadItem>
    {
        UrlDetailAppender<PayloadItem> the_detail(Expression<PropertyAccessor<PayloadItem, object>> property_accessor);
    }
}