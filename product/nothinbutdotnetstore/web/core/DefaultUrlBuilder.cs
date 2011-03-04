using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlBuilder : UrlBuilder, UrlDecorator
    {
        IList<KeyValuePair<string, object>> tokens;
        public object payload;
        public const string command_key = "command_to_run";
        UrlDetailAppenderFactory url_detail_appender_factory;

        public DefaultUrlBuilder(IList<KeyValuePair<string, object>> tokens,
                                 UrlDetailAppenderFactory url_detail_appender_factory)
        {
            this.tokens = tokens;
            this.url_detail_appender_factory = url_detail_appender_factory;
        }

        public UrlDecorator target<BehaviourToTarget>() where BehaviourToTarget : ApplicationBehaviour
        {
            tokens.Add(new KeyValuePair<string, object>(command_key,
                                                        typeof(BehaviourToTarget).Name));

            return new DefaultUrlBuilder(tokens, url_detail_appender_factory);
        }

        public UrlDetailAppender<PayloadItem> include_payload<PayloadItem>(PayloadItem item)
        {
            return url_detail_appender_factory.create_detail_appender_for(item, tokens);
        }
    }
}