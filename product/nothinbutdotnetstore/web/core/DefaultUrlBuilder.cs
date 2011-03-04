using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlBuilder : UrlBuilder, UrlDecorator
    {
        public object payload;
        public const string command_key = "command_to_run";
        TokenStore tokens;
        UrlDetailAppenderFactory url_detail_appender_factory;

        public DefaultUrlBuilder(TokenStore tokens,
                                 UrlDetailAppenderFactory url_detail_appender_factory)
        {
            this.tokens = tokens;
            this.url_detail_appender_factory = url_detail_appender_factory;
        }

        public UrlDecorator target<BehaviourToTarget>() where BehaviourToTarget : ApplicationBehaviour
        {
            tokens.register_token_pair(command_key, typeof(BehaviourToTarget).Name);

            return new DefaultUrlBuilder(tokens, url_detail_appender_factory);
        }

        public UrlDetailAppender<PayloadItem> include_payload<PayloadItem>(PayloadItem item)
        {
            return url_detail_appender_factory.create_detail_appender_for(item, tokens);
        }
    }
}