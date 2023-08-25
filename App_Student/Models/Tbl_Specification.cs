using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Specification")]
    public class Tbl_Specification
    {
        [Key]
        public int Spec_Id { get; set; }

        public string Spec_Name { get; set; } 
    }
}
