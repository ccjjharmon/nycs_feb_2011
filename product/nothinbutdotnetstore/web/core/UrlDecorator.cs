namespace nothinbutdotnetstore.web.core
{
    public interface UrlDecorator
    {
        UrlDetailAppender<PayloadItem> include_payload<PayloadItem>(PayloadItem item);
    }
}