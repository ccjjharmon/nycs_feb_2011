using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator, DefaultCalculator>
        {
        }

        public class when_shutting_off_and_they_are_not_in_the_correct_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything))
                    .Return(false);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());

            It should_throw_a_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            static IPrincipal principal;
        }

        public class when_shutting_off_and_they_are_in_the_correct_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything))
                    .Return(true);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                sut.shut_off();

            It should_do_nothing = () => { };

            static IPrincipal principal;
        }

        public class when_adding_two_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();

                connection.Stub(x => x.CreateCommand()).Return(
                    command);
            };

            Because b = () =>
                result = sut.add(1, 3);

            It should_connect_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_query = () =>
                command.received(x => x.ExecuteNonQuery());

            It should_dispose_items_that_need_to_be_released = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };
  
            It should_return_the_sum = () =>
                result.ShouldEqual(4);

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }
}