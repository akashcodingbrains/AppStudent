using App_Student.Models;
using App_Student.Models.other;
using Microsoft.EntityFrameworkCore;

namespace App_Student.Data
{
    public class Student_Context : DbContext
    {
        public Student_Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tbl_Student> tbl_Students { get; set; }
        public DbSet<Tbl_Country> tbl_Countries { get; set; }
        public DbSet<Tbl_State> GetTbl_States { get; set; }
        public DbSet<Tbl_City> GetTbl_Cities { get; set; }
        public DbSet<Tbl_Hobby> tbl_Hobbies { get; set; }
        public DbSet<Tbl_Hobby2_Std_Map> Tbl_Hobby2_Std_Maps { get; set; }
        public DbSet<Tbl_Qualification> Tbl_Qualifications { get; set; }
        public List<Tbl_Batch1> list_tbl_Batch1s { get; set; }
        public DbSet<Tbl_Batch1> Tbl_Batch1s { get; set; }
        public DbSet<Tbl_Course1> tbl_Course1s { get; set; }
        public DbSet<tbl_Course2StudentMapp> Tbl_Course2StudentMapps { get; set; }
        public DbSet<Tbl_Specification> Tbl_Specifications { get; set; }
        public DbSet<Tbl_Roll> Tbl_Rolls { get; set; }
        public DbSet<Tbl_Payment> Tbl_Payments { get; set; }
        public DbSet<Tbl_Transaction> Tbl_Transactions { get; set; }
        public DbSet<Tbl_file> Tbl_Files { get; set; }  
    }
}
