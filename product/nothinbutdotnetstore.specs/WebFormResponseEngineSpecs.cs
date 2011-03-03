 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class WebFormResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            WebFormResponseEngine>
        {
        
        }

        [Subject(typeof(WebFormResponseEngine))]
        public class when_observation_name : concern
        {
        
            It first_observation = () =>        
                   
        }
    }
}
