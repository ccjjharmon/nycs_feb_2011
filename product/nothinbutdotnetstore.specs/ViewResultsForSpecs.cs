using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewResultsForSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewResultFor<OurReportModel>>
        {
        }

        [Subject(typeof(ViewResultFor<>))]
        public class when_running_to_view_the_results_of_a_query : concern
        {
            static Request request;
            static ResponseEngine response_engine;
            static Query<OurReportModel> query;

            Because b = () =>
                sut.run(request);

            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                the_model = new OurReportModel();
                query = x => the_model;
                provide_a_basic_sut_constructor_argument(query);

                request = an<Request>();
            };

            It should_display_the_sub_departments = () =>
                response_engine.received(x => x.display(the_model));

            static OurReportModel the_model;
        }

        public class OurReportModel
        {
        }
    }
}