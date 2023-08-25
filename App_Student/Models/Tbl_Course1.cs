using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Course1")]
    public class Tbl_Course1
    {
        [Key]
        public int Course_Id { get; set; }
        [Display(Name ="Subject")]
        public string? Course_Name { get; set; }
        public int? Spec_Id { get; set; }
        [Display(Name = "Specification Name")]
        public string? Specification_Name { get; set; }
        public decimal? Fee { get; set; }
        [Display(Name = "Live Class")]
        public bool Live_Class { get; set; }
        [Display(Name = "Recorded Class")]
        public bool Recorded_Class { get; set; }
        [Display(Name = "Mock Text")]
        public bool Mock_Test { get; set; }
        [Display(Name = "Doubt Solving Session")]
        public bool Doubt_Solving_Session { get; set; }
        public bool DPP { get; set; }

    }
}
