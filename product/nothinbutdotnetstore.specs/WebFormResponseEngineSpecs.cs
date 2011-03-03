using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class WebFormResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            WebFormResponseEngine>
        {
        }

        [Subject(typeof(WebFormResponseEngine))]
        public class when_displaying_a_report_model : concern
        {
            Establish c = () =>
            {
                view_factory = the_dependency<ViewFactory>();
                the_current_context = ObjectFactory.web.create_http_context();
                logical_view = an<IHttpHandler>();
                the_model = new CustomModel();

                view_factory.Stub(x => x.create_view_to_render(the_model))
                    .Return(logical_view);

                provide_a_basic_sut_constructor_argument(the_current_context);
                provide_a_basic_sut_constructor_argument<GetTheCurrentContext>(() => the_current_context);
            };

            Because b = () =>
                sut.display(the_model);

            It should_get_the_view_that_can_render_the_model = () =>
            {

            };

  
            It should_tell_the_view_to_render = () =>
                logical_view.received(x => x.ProcessRequest(the_current_context));
  


            static CustomModel the_model;
            static ViewFactory view_factory;
            static IHttpHandler logical_view;
            static HttpContext the_current_context;
        }

        public class CustomModel
        {
        }
    }
}