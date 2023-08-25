using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Student")]
    public class Tbl_Student
    {
        [Key]
        public int Student_Id { get; set; }

        
        [Display(Name = "Contact Number")]
        public long? Contact_Number { get; set; }

        
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Email Should be like ****@****.com")]
        public string? Email_Address { get; set; } = null!;

        
        [Display(Name = "Registration ID")]
        public string? Registration_Id { get; set; } = null!;

        
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
        [Display(Name = "First Name")]
        public string? First_Name { get; set; } = null!;

        [Display(Name = "Last Name")]
        
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
        public string? Last_Name { get; set; } = null!;

        
        public string? Gender { get; set; } = null!;

       
        [Display(Name = "Date Of Birth")]
        public DateTime? Dob { get; set; }

       
        [Display(Name = "Father Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
        public string? Father_Name { get; set; } = null!;

       
        [Display(Name = "Mother Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters")]
        public string? Mother_Name { get; set; } = null!;

        
        public string? Password { get; set; } = null!;

        [NotMapped]
        public string? Conform_password { get; set; }

        [Required]
        public string? Address { get; set; } = null!;

        
        [Display(Name = "Zip Code")]
        public int? Zip_Code { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public bool? IsActive { get; set; }
        [Display(Name = "Role")]
        public int? Role_Id { get; set; }
    }
}

