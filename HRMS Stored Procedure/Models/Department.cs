using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRMS_Stored_Procedure.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("Department Name")]
        public string? DeptName { get; set; }

        public Department() { }

        public Department(int deptId, string deptName)
        {
            DeptId = deptId;
            DeptName = deptName;
        }
    }
}
