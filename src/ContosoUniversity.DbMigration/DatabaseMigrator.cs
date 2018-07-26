using DbUp;
using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.DbMigration
{
    public class DatabaseMigrator
    {
        public DatabaseUpgradeResult Migrate(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();
            return upgrader.PerformUpgrade();

        }
    }
}
