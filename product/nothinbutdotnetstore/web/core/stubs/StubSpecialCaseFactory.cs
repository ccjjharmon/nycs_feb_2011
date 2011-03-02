namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSpecialCaseFactory
    {
        public RequestCommand create()
        {
            return new StubCommand();
        }

        class StubCommand : RequestCommand
        {
            public bool can_handle(Request request)
            {
                return false;
            }

            public void run(Request request)
            {
            }
        }
    }
}