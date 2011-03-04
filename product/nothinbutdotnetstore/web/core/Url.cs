using System;

namespace nothinbutdotnetstore.web.core
{
    public static class Url
    {
        public static UrlDecorator to_run<BehaviourToRun>()
            where BehaviourToRun : ApplicationBehaviour
        {
            throw new NotImplementedException();
        }


        public static RequestMatch to_match_request_for<BehaviourToMatch>() where BehaviourToMatch
                                                                                : ApplicationBehaviour
        {
            return new RequestContainsCommand<BehaviourToMatch>().matches;
        }

        public static string to_run_iif<Left, Right>(bool condition)
        {
            throw new NotImplementedException();
        }
    }
}