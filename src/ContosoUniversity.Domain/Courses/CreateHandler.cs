using MediatR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace ContosoUniversity.Domain.Courses
{
    public class CreateHandler : IRequestHandler<CreateStudentCommand, int>
    {
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection
                    .InsertAsync<StudentEntity>(request);
                return result.Value;
            }
        }
    }
}
