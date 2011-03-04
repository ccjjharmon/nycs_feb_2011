using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public class DefaultTokenStore : TokenStore
    {
        IList<KeyValuePair<string, object>> all_tokens;

        public DefaultTokenStore(IList<KeyValuePair<string, object>> all_tokens)
        {
            this.all_tokens = all_tokens;
        }

        public void register_token_pair(string key, object value)
        {
            all_tokens.Add(new KeyValuePair<string, object>(key, value));
        }
    }
}