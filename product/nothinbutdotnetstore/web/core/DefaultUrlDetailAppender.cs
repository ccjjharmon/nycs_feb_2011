using System.Linq.Expressions;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlDetailAppender<ItemWithDetails> : UrlDetailAppender<ItemWithDetails>
    {
        PropertyNameExpressionMapper property_name_expression_mapper;
        TokenStore tokens;
        ItemWithDetails item;

        public DefaultUrlDetailAppender(PropertyNameExpressionMapper property_name_expression_mapper,
                                        TokenStore tokens, ItemWithDetails item)
        {
            this.property_name_expression_mapper = property_name_expression_mapper;
            this.item = item;
            this.tokens = tokens;
        }

        public UrlDetailAppender<ItemWithDetails> the_detail(
            Expression<PropertyAccessor<ItemWithDetails, object>> property_accessor)
        {
            tokens.register_token_pair(property_name_expression_mapper.map_from(property_accessor),
                                  property_accessor.Compile()(item));

            return new DefaultUrlDetailAppender<ItemWithDetails>(property_name_expression_mapper, tokens, item);
        }
    }
}