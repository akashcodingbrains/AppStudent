namespace App_Student.Models
{
    public class Student_view_model
    {
        public Tbl_Student? tbl_Student { get; set; }
        public List<Tbl_Student>? list_student { get; set; }
        public Tbl_Hobby? tbl_Hobby { get; set; }
        public List<Tbl_Hobby>? list_hobbes { get; set; }
        public Tbl_Hobby2_Std_Map Tbl_Hobby2_Std_Map { get; set; }
        public List<Tbl_Hobby2_Std_Map> list_tbl_Hobby2_Std_Maps { get; set; }
        public List<Tbl_Qualification> list_tbl_Qualifications { get; set; }
        public Tbl_Qualification tbl_Qualification { get; set; }
        public List<Tbl_Specification> List_tbl_Specifications { get; set; }
        public Tbl_Specification Tbl_Specification { get; set; }
        public List<Tbl_Course1> list_tnl_Course1 { get; set; }
        public Tbl_Course1 Tbl_Course1 { get; set; }
        public List<Tbl_Batch1> list_tbl_batche1s { get; set; }
        public Tbl_Batch1 tbl_Batch1 { get; set; } 
        public List<Tbl_Roll> list_tbl_Roll { get; set; }
        public Tbl_Roll Tbl_Roll { get; set; }
        public Tbl_Transaction Tbl_Transaction { get; set; }
        public List<Tbl_Transaction> list_Tbl_transaction { get; set; }
       
    }
}
