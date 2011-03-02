 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
            };

            Because b = () =>
                sut.run(request);

            It first_observation = () =>


            static Request request;


        }
    }
}
