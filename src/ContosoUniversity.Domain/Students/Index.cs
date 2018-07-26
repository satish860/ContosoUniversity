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

    public class StudentListViewModel
    {
        public IEnumerable<StudentEntity> StudentList { get; set; }
    }

    public class QueryInputModel : IRequest<StudentListViewModel>
    {

    }

    public class IndexHadler : IRequestHandler<QueryInputModel, StudentListViewModel>
    {
        public async Task<StudentListViewModel> Handle(QueryInputModel request, CancellationToken cancellationToken)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection
                    .GetListPagedAsync<StudentEntity>(1,10,string.Empty,string.Empty);
                return new StudentListViewModel
                {
                    StudentList = result
                };
            }
        }
    }


}
