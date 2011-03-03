namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface ViewPathRegistry
    {
        string get_path_to_view_that_can_render<ReportModel>();
    }
}