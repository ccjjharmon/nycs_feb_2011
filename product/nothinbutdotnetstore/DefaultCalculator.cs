using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class DefaultCalculator : Calculator
    {
        IDbConnection connection;

        public DefaultCalculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return first + second;
        }

        public void shut_off()
        {
            ensure_is_in_correct_role();
        }

        void ensure_is_in_correct_role()
        {
            if (! Thread.CurrentPrincipal.IsInRole("blasf"))
                throw new SecurityException();
        }
    }
}