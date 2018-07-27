using ContosoUniversity.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static ContosoUniversity.IntegerationTests.SliceFixture;
using FluentAssertions;

namespace ContosoUniversity.IntegerationTests.Students
{
    public class DetailsTests : IntegerationTestBase
    {
        [Fact]
        public async Task ShouldBeAbleToGetDetails()
        {
            var createStudentCommand = new CreateStudentCommand
            {
                FirstName = "satish",
                LastName = "Venkatakrishnan",
                EnrollmentDate = DateTime.Now
            };
            var id = await SendAsync(createStudentCommand);
            var details = await SendAsync(new DetailsModel { Id = id });
            details.FirstName.Should().Be("satish");

        }
    }
}
