using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Country")]
    public class Tbl_Country
    {
        public int Id { get; set; }
        public string Country_Name { get; set; }
    }
}
