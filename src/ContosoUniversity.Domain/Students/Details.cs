using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain.Students
{
    public class DetailsModel : IRequest<StudentEntity>
    {
        public int Id { get; set; }
    }

    public class DetailsViewHandler : IRequestHandler<DetailsModel, StudentEntity>
    {
        public async Task<StudentEntity> Handle(DetailsModel request, CancellationToken cancellationToken)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection
                    .GetAsync<StudentEntity>(request.Id);
                return result;
            }
        }
    }
}
