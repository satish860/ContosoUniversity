using ContosoUniversity.Domain.Students;
using System;
using System.Threading.Tasks;
using Xunit;
using static ContosoUniversity.IntegerationTests.SliceFixture;
using FluentAssertions;

namespace ContosoUniversity.IntegerationTests.Students
{
    public class CreateStudentTests : IntegerationTestBase
    {
        [Fact]
        public async Task ShouldBeAbleToCreateStudents()
        {

           var createStudentCommand =new CreateStudentCommand
           {
               FirstName = "satish",
               LastName = "Venkatakrishnan",
               EnrollmentDate = DateTime.Now
           };
            var id = await SendAsync(createStudentCommand);
            StudentEntity studentEntity = FindAsync<StudentEntity>(id);
            studentEntity.FirstName.Should().Be("satish");
        }
    }
}
