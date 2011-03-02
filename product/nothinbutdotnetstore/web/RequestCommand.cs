namespace nothinbutdotnetstore.web
{
    public interface RequestCommand
    {
        void run(Request request);
        bool can_handle(Request request);
    }
}