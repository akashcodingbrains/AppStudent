using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_State")]
    public class Tbl_State
    {
        public int Id { get; set; }
        public string State_Name { get; set; }
        public int Country_Id { get; set; }
    }
}
