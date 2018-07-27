using ContosoUniversity.Domain.Students;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class StudentController : Controller
    {

        public StudentController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public async Task<ActionResult> Index()
        {
            var studentList = await Mediator.Send(new QueryInputModel());
            return View(studentList);
        }

        public async Task<ActionResult> Details(int? id)
        {
            var student = await Mediator.Send(new DetailsModel { Id=id.Value});
            return View(student);
        }
    }
}