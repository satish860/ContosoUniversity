using ContosoUniversity.DbMigration;
using Respawn;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.IntegerationTests
{
    public class SliceFixture
    {
        private static readonly Checkpoint checkpoint;

        static SliceFixture()
        {
            DatabaseMigrator databaseMigrator = new DatabaseMigrator();
            databaseMigrator.Migrate(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            checkpoint = new Checkpoint();
        }

        public static Task ResetCheckpoint() => checkpoint.Reset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}
