using System.ComponentModel.DataAnnotations;

namespace DataSource.Employees
{
    public abstract class EmployeeBase
    {
        [Key, StringLength(50)]
        public string SocialSecurityNumber { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{SocialSecurityNumber} ({FirstName} {LastName})";
        }
    }
}