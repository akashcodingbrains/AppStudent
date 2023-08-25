using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Student.Models
{
    [Table("Tbl_Transaction")]
    public class Tbl_Transaction
    {
        public int? Id { get; set; }
        public int? Trans_Id { get; set; }
        public int? Candidate_Id { get; set; }
        public int? Upi_Id { get; set; }

        [Display(Name = "Bank Account No")]
        public int? NETB_Bank_Account_No { get; set; }

        [Display(Name = "IFC Code")]
        public int? NETB_IFC_Cod { get; set; }
        public int? Cheqe_Account_No { get; set; }
        public int? Checqe_No { get; set; }
        public int? Total_Cash { get; set; }
    }
}
