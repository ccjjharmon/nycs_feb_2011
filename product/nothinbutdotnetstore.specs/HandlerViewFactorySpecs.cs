 using System;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core.aspnet;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class HandlerViewFactorySpecs
    {
        public abstract class concern : Observes<ViewFactory,
                                            HandlerViewFactory>
        {
        
        }

        [Subject(typeof(HandlerViewFactory))]
        public class when_creating_a_view    : concern
        {
            Establish c = () =>
            {
                the_page = "blah.aspx";
                the_model = 23;
                the_view = an<ViewFor<int>>();
                view_path_registry = the_dependency<ViewPathRegistry>();


                view_path_registry.Stub(x => x.get_path_to_view_that_can_render<int>())
                    .Return(the_page);

                provide_a_basic_sut_constructor_argument<PageFactory>((page_requested,page_type_requested) =>
                {
                    requested_page = page_requested;
                    requested_type = page_type_requested;
                    return the_view;
                });
            };

            Because b = () =>
                result = sut.create_view_to_render(the_model);

            It should_dispatch_page_creation_using_the_correct_details = () =>
            {
                //TODO - Show cooler technique later
                requested_page.ShouldEqual(the_page);
                requested_type.ShouldEqual(typeof(ViewFor<int>));
            };
  
            It should_add_the_model_to_the_view = () =>
            {
                result.ShouldEqual(the_view);
                the_view.report_model.ShouldEqual(the_model);
            };


            static IHttpHandler result;
            static int the_model;
            static ViewFor<int> the_view;
            static ViewPathRegistry view_path_registry;
            static string the_page;
            static string requested_page;
            static Type requested_type;
        }
    }
}
