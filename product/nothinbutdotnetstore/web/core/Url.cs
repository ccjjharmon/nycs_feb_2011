using System;

namespace nothinbutdotnetstore.web.core
{
    public static class Url
    {
        public static string to_run<BehaviourToRun>()
            where BehaviourToRun : ApplicationBehaviour
        {
            return get_url_name<BehaviourToRun>();
        }

        static string get_url_name<BehaviourToRun>()
        {
            return string.Format("{0}.nyc", typeof(BehaviourToRun).Name);
        }

        public static RequestMatch to_match_request_for<BehaviourToMatch>() where BehaviourToMatch
            : ApplicationBehaviour
        {
            return new RequestContainsCommand<BehaviourToMatch>().matches;
        }

        public static string to_run_iif<Left, Right>(bool has_products)
        {
            if (has_products)
                return get_url_name<Left>();

            return get_url_name<Right>();
        }
    }
}