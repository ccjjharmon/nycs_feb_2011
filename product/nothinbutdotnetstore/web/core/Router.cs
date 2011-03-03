namespace nothinbutdotnetstore.web.core
{
    public interface Router
    {
        bool matches(Request request);
    }
}