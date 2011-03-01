namespace nothinbutdotnetstore.web
{
    public interface RequestCommand
    {
        void run(Request request);
    }
}