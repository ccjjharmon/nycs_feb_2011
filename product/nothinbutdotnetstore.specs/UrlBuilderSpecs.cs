using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class UrlBuilderSpecs
    {
        public abstract class concern<ContractToObserve, Class> : Observes<ContractToObserve,
                                                                      Class> where Class : ContractToObserve
        {
            Establish c = () => { token_store = the_dependency<TokenStore>(); };

            protected static TokenStore token_store;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_targeting_a_behaviour_to_run : concern<UrlBuilder, DefaultUrlBuilder>
        {
            Because b = () =>
                result = sut.target<OurBehaviour>();

            It should_store_the_behaviour_to_run_with_the_correct_details = () =>
            {
                token_store.received(x => x.register_token_pair(DefaultUrlBuilder.command_key,
                                                                typeof(OurBehaviour).Name));
            };

            It should_return_a_url_decorator_to_continue_the_url_building_process =
                () => { result.ShouldBeAn<UrlDecorator>().Equals(sut).ShouldBeFalse(); };

            static UrlDecorator result;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_including_a_payload : concern<UrlDecorator, DefaultUrlBuilder>
        {
            Establish c = () =>
            {
                our_item = new TheItem();
                detail_appender = an<UrlDetailAppender<TheItem>>();
                url_detail_appender_factory = the_dependency<UrlDetailAppenderFactory>();

                url_detail_appender_factory.Stub(x => x.create_detail_appender_for(our_item, token_store))
                    .Return(detail_appender);
            };

            Because b = () =>
                result = sut.include_payload(our_item);

            It should_return_the_detail_appender_to_add_the_details_of_the_item = () =>
                result.ShouldEqual(detail_appender);

            static TheItem our_item;
            static UrlDetailAppender<TheItem> result;
            static UrlDetailAppender<TheItem> detail_appender;
            static UrlDetailAppenderFactory url_detail_appender_factory;
        }

        public class TheItem
        {
            public string name { get; set; }
        }

        class OurBehaviour : ApplicationBehaviour
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}