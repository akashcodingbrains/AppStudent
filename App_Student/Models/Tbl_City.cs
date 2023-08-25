using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_City")]
    public class Tbl_City
    {
        public int Id { get; set; }
        public string City_Name { get; set; }
        public int State_Id { get; set; }
    }
}
