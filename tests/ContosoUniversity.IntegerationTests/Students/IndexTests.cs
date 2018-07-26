using AutoBogus;
using Bogus;
using ContosoUniversity.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContosoUniversity.IntegerationTests.SliceFixture;
using FluentAssertions;
using Xunit;

namespace ContosoUniversity.IntegerationTests.Students
{
    public class IndexTests : IntegerationTestBase
    {
        [Fact]
        public async Task ShouldGetPagedListFromServer()
        {
            var studentgenerator = new AutoFaker<StudentEntity>()
                 .RuleFor(p => p.StudentId, 0);
            var students = studentgenerator.Generate(2);
            students.ForEach(p => InsertAsync(p));
            var query = new QueryInputModel();
            var viewmodel = await SendAsync(query);
            viewmodel.StudentList.Count().Should().BeGreaterOrEqualTo(2);
        }
    }
}
