using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("tbl_Course2StudentMapp")]
    public class tbl_Course2StudentMapp
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal tax { get; set; }
        public decimal TotalPaid { get; set; }
        public string UPIID { get; set; }
    }
}
