using ContosoUniversity.Domain.Courses;
using MediatR;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ContosoUniversity.Domain
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<CreateCourseCommand>();
                 // Our assembly with requests & handlers
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            });
            For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
            For<IMediator>().Use<Mediator>();
        }
    }
}
