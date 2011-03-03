using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class Url
    {
        public UrlBuilder<object> to_run<BehaviourToRun>()
            where BehaviourToRun : ApplicationBehaviour
        {
            return get_url_name<BehaviourToRun>();
        }

        UrlBuilder<object> get_url_name<BehaviourToRun>()
        {
            return new UrlBuilder<BehaviourToRun>(string.Format("{0}.nyc", typeof(BehaviourToRun).Name));
        }

        public RequestMatch to_match_request_for<BehaviourToMatch>() where BehaviourToMatch
                                                                                : ApplicationBehaviour
        {
            return new RequestContainsCommand<BehaviourToMatch>().matches;
        }

        public UrlBuilder<object> to_run_iif<Left, Right>(bool condition)
        {
            return (condition ? get_url_name<Left>() : get_url_name<Right>());
        }

    }
}