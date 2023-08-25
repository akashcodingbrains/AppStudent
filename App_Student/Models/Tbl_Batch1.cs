using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Batch1")]
    public class Tbl_Batch1
    {
        [Key]
        public int Batch_Id { get; set; }
        public string? Batch_Name { get; set; }
        public int? Course_Id { get; set; }
        public string? Course_Name { get; set; }
        public string? Batch_Timing { get; set; }
        public string? Instructor_Name { get; set; }
        public int? Seats { get; set; }

    }
}
