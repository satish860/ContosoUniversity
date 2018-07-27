using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbUp;

namespace ContosoUniversity.DbMigration
{
    class Program
    {
        static int Main(string[] args)
        {

            var connectionString =
        args.FirstOrDefault()
        ?? "Data Source=PRO-LP116;Initial Catalog=ContosoUniversity;Integrated Security=True";
            DatabaseMigrator databaseMigrator = new DatabaseMigrator();

            var result = databaseMigrator.Migrate(connectionString);

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Console.ReadLine();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            
            return 0;
        }
    }
}
