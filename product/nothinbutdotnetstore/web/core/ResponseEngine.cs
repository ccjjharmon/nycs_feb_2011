namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void display<ReportModel>(ReportModel model);
    }
}