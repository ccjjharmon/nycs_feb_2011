namespace nothinbutdotnetstore.utility
{
    public class Stub
    {
       public static ItemToUseAsStub with<ItemToUseAsStub>()
           where ItemToUseAsStub : new()
       {
           return new ItemToUseAsStub();
       } 
    }
}