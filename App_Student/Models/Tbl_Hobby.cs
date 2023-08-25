using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace App_Student.Models
{
    [Table("Tbl_Hobby")]
    public class Tbl_Hobby
    {
        public int Id { get; set; }
        [Display(Name = "Hobby Name")]
        public string? Hobby_Name { get; set; }
        [NotMapped]
        public bool Ischecked { get; set; }
    }
}
