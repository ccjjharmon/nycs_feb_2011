 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.specs
{   
    public class TokenStoreSpecs
    {
        public abstract class concern : Observes<TokenStore,
                                            DefaultTokenStore>
        {
        
        }

        [Subject(typeof(DefaultTokenStore))]
        public class when_registering_a_key_value_pair : concern
        {
            Establish c = () =>
            {
                key = "basl";
                value = new object();
                tokens = new List<KeyValuePair<string, object>>();
                provide_a_basic_sut_constructor_argument(tokens);

            };
            Because b = () =>
                sut.register_token_pair(key, value);


            It should_store_the_pair_of_values_correctly = () =>
            {
                tokens[0].Key.ShouldEqual(key);
                tokens[0].Value.ShouldEqual(value);
            };



            static IList<KeyValuePair<string,object>> tokens;
            static string key;
            static object value;
        }
    }
}
