using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain.Students
{
    [Table("Person")]
    public class StudentEntity
    {
        [Key]
        [Column("ID")]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
