using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models.other
{
    [Table("Tbl_file")]
    public class Tbl_file
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string File_Name { get; set; }
        [NotMapped]
        public IFormFile File_Path { get; set; }

    }
}
