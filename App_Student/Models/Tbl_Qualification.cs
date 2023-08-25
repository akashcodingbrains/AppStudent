using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Qualification")]
    public class Tbl_Qualification
    {
        [Key]
        public int Std_Qli_Id { get; set; }
        public int? Student_Id { get; set; }
        [Display(Name = "Qualification Name")]
        public string? Qualifiaction_Name { get; set; }
        public string? University { get; set; }
        [Display(Name = "Term Yaer")]
        public int? Term_Year { get; set; }
        [Display(Name = "Compleation Year")]
        public int? Completation_Year { get; set; }
        public decimal? Percentage { get; set; }
    }
}
