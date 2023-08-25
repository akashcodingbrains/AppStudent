using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Hobby2_Std_Map")]
    public class Tbl_Hobby2_Std_Map
    {
        public int Id { get; set; }
        public string? Hobby_Name { get; set; }
        public int Hobby_Id { get; set; }
        public int Student_Id { get; set; }
    }
}
