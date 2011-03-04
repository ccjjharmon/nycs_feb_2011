namespace nothinbutdotnetstore.web.core
{
    public interface UrlBuilder
    {
        UrlDecorator target<BehaviourToTarget>() where BehaviourToTarget
                                             : ApplicationBehaviour;

    }
}