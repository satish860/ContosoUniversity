using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain.Courses
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
