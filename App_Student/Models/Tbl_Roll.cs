using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Roll")]
    public class Tbl_Roll
    {
        [Key]
        public int Role_Id { get; set; }    
        public string Roll_Name { get; set; } 
    }
}
