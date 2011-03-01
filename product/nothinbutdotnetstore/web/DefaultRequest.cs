namespace nothinbutdotnetstore.web
{
    public class DefaultRequest : Request
    {
        RequestType type;

        public RequestType rtype()
        {
            return this.type;
        }
        public DefaultRequest()
        {
            this.type = RequestType.listall;
        }
    }
}