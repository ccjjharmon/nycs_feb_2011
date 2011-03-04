namespace nothinbutdotnetstore.utility
{
    public interface TokenStore
    {
        void register_token_pair(string key,object value);
    }
}