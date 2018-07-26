using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain.Courses
{
    public class CreateStudentCommand : StudentEntity,IRequest<int>
    {
        
    }
}
