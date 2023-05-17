﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_Stored_Procedure.Models
{
    public class EmployeePerformance
    {
        public EmployeePerformance()
        {
            About = "About / Title"; 
            PerformanceReview = "Performance Review"; 
            Status = false;
            DateReview = DateTime.Now.ToString("d"); 
            DeleteStatus = false; 
        }
        [Key]
        public int No { get; set; }
        [DisplayName("User ID")]
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser? EmployeeName { get; set; }
        public string ReviewBy { get; set; }
        [ForeignKey("ReviewBy")]
        public ApplicationUser? ReviewerName { get; set; }
        [Required]
        [MinLength(3)]
        [DisplayName("About")]
        public string About { get; set; }
        [Required]
        [MinLength(5)]
        [DisplayName("Performance Review")]
        public string PerformanceReview { get; set; }
        public bool Status { get; set; }
        [Required]
        [DisplayName("Date Review")]
        public string DateReview { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
