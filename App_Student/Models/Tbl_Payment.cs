using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Payment")]
    public class Tbl_Payment
    {
        public int Id { get; set; }

        public string? Payment_Name { get; set; }    

    }
}
