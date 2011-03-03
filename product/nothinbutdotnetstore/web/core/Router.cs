namespace nothinbutdotnetstore.web.core
{
    public interface Router
    {
        bool RequestMatch(Request request);
    }
}