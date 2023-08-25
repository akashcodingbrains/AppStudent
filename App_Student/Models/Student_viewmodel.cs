using System.ComponentModel.DataAnnotations;

namespace App_Student.Models
{
    public class Student_viewmodel
    {
        public int Student_Id { get; set; }

        public long Contact_Number { get; set; }

        public string Email_Address { get; set; }

        public string Registration_Id { get; set; }

        public string First_Name { get; set; } 

        public string Last_Name { get; set; }

        public string Gender { get; set; } 

        public DateTime Dob { get; set; }

        public string Father_Name { get; set; }

        public string Mother_Name { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Zip_Code { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool IsActive { get; set; }

        public int Role_Id { get; set; }
        public Tbl_Student Tbl_Student { get; set; }
    }
}
