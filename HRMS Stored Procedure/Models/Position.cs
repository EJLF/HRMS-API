using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRMS_Stored_Procedure.Models
{
    public class Position
    {
        [Key]
        public int PosId { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("Position Name")]
        public string? PositionName { get; set; }
    }
}
