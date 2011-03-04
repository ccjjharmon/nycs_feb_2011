using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlDetailAppenderFactory
    {
        UrlDetailAppender<Item> create_detail_appender_for<Item>(Item item, IList<KeyValuePair<string, object>> tokens);
    }
}