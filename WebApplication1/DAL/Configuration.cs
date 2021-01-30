using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace WebApplication1.DAL
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}