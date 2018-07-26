using ContosoUniversity.DbMigration;
using ContosoUniversity.Domain;
using MediatR;
using Respawn;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ContosoUniversity.IntegerationTests
{
    public class SliceFixture
    {
        private static readonly Checkpoint checkpoint;
        private static IContainer container;
        private static string connectionString;

        static SliceFixture()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DatabaseMigrator databaseMigrator = new DatabaseMigrator();
            databaseMigrator.Migrate(connectionString);
            checkpoint = new Checkpoint();
            container = new Container();
            container.Configure(cfg =>
            {
                cfg.AddRegistry<DomainRegistry>();
            });

        }

        public static Task ResetCheckpoint() => checkpoint.Reset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public static Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var mediator = container.GetInstance<IMediator>();
            return mediator.Send(request);
        }

        public static T FindAsync<T>(int id)
            where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public static void InsertAsync<T>(T entity)
            where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert<T>(entity);
            }
        }
    }
}
