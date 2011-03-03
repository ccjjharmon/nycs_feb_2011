using System;

namespace nothinbutdotnetstore.web.core
{
    public delegate bool Command();

    public static class Url
    {
        public static string to_run<BehaviourToRun>()
            where BehaviourToRun : ApplicationBehaviour
        {
            return get_url_name<BehaviourToRun>();
        }

        public static string to_run_iif<BehaviourToRunIfTrue, BehaviourToRunIfFalse>(Command command)
            where BehaviourToRunIfTrue : ApplicationBehaviour
            where BehaviourToRunIfFalse : ApplicationBehaviour
        {
            if(typeof(BehaviourToRunIfTrue).Name.Equals(typeof(BehaviourToRunIfFalse).name)) throw new Exception("types the same");
            if(command())
            {
                return to_run<BehaviourToRunIfTrue>();
            }else
            {
             return to_run<BehaviourToRunIfFalse>();   
            }
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
    }
}