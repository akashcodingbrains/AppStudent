using App_Student.Data;
using App_Student.Models;
using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks.Dataflow;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


using Microsoft.AspNetCore.Http;

namespace App_Student.Controllers
{
    public class DashboardController : Controller
    {
        public readonly Student_Context _context;
        public DashboardController(Student_Context context)
        {
            this._context = context;

        }
        //login for roll
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("userid1") != null)
            {
                return RedirectToAction("Admin");
            }
            else if (HttpContext.Session.GetString("userid2") != null)
            {
                return RedirectToAction("Student_insert_data");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Student_viewmodel obj)
       {
            try
            {
                var data = _context.tbl_Students.SingleOrDefault(e => e.Email_Address == obj.Tbl_Student.Email_Address);
                if (data != null)
                {
                    if (data.Password == obj.Tbl_Student.Password)
                    {
                        if (data.Role_Id == 1)
                        {
                            HttpContext.Session.SetString("userid1", Convert.ToString(data.Role_Id));
                            return RedirectToAction("Admin");
                        }
                        else if (data.Role_Id == 2)
                        {
                            HttpContext.Session.SetString("userid2", Convert.ToString(data.Role_Id));
                            return RedirectToAction("Student_update_show_data", new { id = data.Student_Id });
                        }

                    }
                    else
                    {
                        TempData["msd"] = "<script>alert('password wrong')</script>";
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Log_out()
        {
            if (HttpContext.Session.GetString("userid1") != null)
            {
                HttpContext.Session.Remove("userid1");
                return RedirectToAction("Login");
            }
            else if (HttpContext.Session.GetString("userid2") != null)
            {
                HttpContext.Session.Remove("userid2");
                return RedirectToAction("Login");
            }
            return View("");
        }
        [HttpGet]

        //reset password
        [HttpGet]
        public IActionResult Reset_password()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reset_password(Student_view_model model)
        {
            var result = _context.tbl_Students.SingleOrDefault(e => e.Email_Address == model.tbl_Student.Email_Address && e.Contact_Number == model.tbl_Student.Contact_Number);
            if (result != null)
            {
                TempData["id"] = result.Student_Id;
                return RedirectToAction("Change_password");
            }
            else
            {

                TempData["data"] = "Email_Address and Contact Number Not Matched!";
            }
            return View();
        }
        //change password
        [HttpGet]
        public IActionResult Change_password()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Change_password(Student_view_model model)
        {
            if (model.tbl_Student.Password == model.tbl_Student.Conform_password)
            {
                Tbl_Student result = _context.tbl_Students.Find(TempData["id"]);
                if (result != null)
                {
                    result.Password = model.tbl_Student.Password;
                    _context.tbl_Students.Update(result);
                    _context.SaveChanges();
                    TempData["msg"] = "<script>alert('password changed')<script>";
                    return RedirectToAction("Login");
                }
                else
                {
                     RedirectToAction("Change_password");
                    TempData["msg"] = "<script>alert('password not matched')<script>";
                }
                
            }
            return View();
        }

        public IActionResult Student_show_data()
        {
            Student_view_model obj1 = new Student_view_model();
            obj1.list_student = _context.tbl_Students.ToList();

            return View(obj1);

        }

        public IActionResult Student_insert_data()
        {
            Student_view_model obj = new Student_view_model();
            obj.list_hobbes = _context.tbl_Hobbies.ToList();
            //obj.list_tbl_Qualifications = _context.Tbl_Qualifications.ToList(); 
            obj.list_tbl_Roll = _context.Tbl_Rolls.ToList();

            ViewBag.list = obj.list_tbl_Roll;

            return View(obj);
        }
        [HttpPost]
        public IActionResult Student_insert_data(Student_view_model obj)
        {
            Tbl_Student stu = new Tbl_Student();
            stu.Student_Id = obj.tbl_Student.Student_Id;
            stu.Contact_Number = obj.tbl_Student.Contact_Number;
            stu.Email_Address = obj.tbl_Student.Email_Address;
            stu.Registration_Id = obj.tbl_Student.Registration_Id;
            stu.First_Name = obj.tbl_Student.First_Name;
            stu.Last_Name = obj.tbl_Student.Last_Name;
            stu.Gender = obj.tbl_Student.Gender;
            stu.Dob = obj.tbl_Student.Dob;
            stu.Father_Name = obj.tbl_Student.Father_Name;
            stu.Mother_Name = obj.tbl_Student.Mother_Name;
            stu.Password = obj.tbl_Student.Password;
            stu.Address = obj.tbl_Student.Address;
            stu.Zip_Code = obj.tbl_Student.Zip_Code;
            stu.Role_Id = obj.tbl_Student.Role_Id;
            stu.Country = obj.tbl_Student.Country;
            stu.State = obj.tbl_Student.State;  
            stu.City = obj.tbl_Student.City;
            stu.IsActive = obj.tbl_Student.IsActive;
            stu.Role_Id = obj.tbl_Student.Role_Id;
            _context.tbl_Students.Add(stu);
            _context.SaveChanges();


            //Student Table Max Id
            int max = _context.tbl_Students.Max(e => e.Student_Id);


            // add data of Hobby Table in Tbl_Student_Mapped

            foreach (var item in obj.list_hobbes)
            {
                if (item.Ischecked == true)
                {
                    Tbl_Hobby2_Std_Map tb_Map = new Tbl_Hobby2_Std_Map();

                    tb_Map.Hobby_Id = item.Id;
                    tb_Map.Hobby_Name = item.Hobby_Name;
                    tb_Map.Student_Id = max;
                    _context.Tbl_Hobby2_Std_Maps.Add(tb_Map);
                    _context.SaveChanges();
                }

            }

            //add_data of Qualifiaction

            Student_view_model md = new Student_view_model();
            md.list_tbl_Qualifications = obj.list_tbl_Qualifications;
            foreach (Tbl_Qualification item in obj.list_tbl_Qualifications)
            {
                if (item != null)
                {
                    Tbl_Qualification tq = new Tbl_Qualification();
                    tq.Student_Id = max;
                    tq.Qualifiaction_Name = item.Qualifiaction_Name;
                    tq.University = item.University;
                    tq.Term_Year = item.Term_Year;
                    tq.Completation_Year = item.Completation_Year;
                    tq.Percentage = item.Percentage;
                    _context.Tbl_Qualifications.Add(tq);
                }
                _context.SaveChanges();
            }

            return new JsonResult("ohhk");

        }
        [HttpGet]
        public IActionResult Student_update_show_data(int id)
        {
            
            //show data of tbl_student
            Student_view_model obj = new Student_view_model();
            obj.tbl_Student = _context.tbl_Students.SingleOrDefault(e => e.Student_Id == id);
            //show data of Tbl_Qualification
            obj.list_tbl_Qualifications = _context.Tbl_Qualifications.Where(e => e.Student_Id == id).ToList();
           
            //hobby show data
            obj.list_hobbes = _context.tbl_Hobbies.ToList();
            obj.list_tbl_Hobby2_Std_Maps = _context.Tbl_Hobby2_Std_Maps.Where(e => e.Student_Id == id).ToList();
            for (int i = 0; i < obj.list_hobbes.Count; i++)
            {
                for (int j = 0; j < obj.list_tbl_Hobby2_Std_Maps.Count; j++)
                {
                    if (obj.list_hobbes[i].Hobby_Name == obj.list_tbl_Hobby2_Std_Maps[j].Hobby_Name)
                    {
                        obj.list_hobbes[i].Ischecked = true;
                    }
                }
            }

            //tbl roll show data in student form
            obj.list_tbl_Roll = _context.Tbl_Rolls.ToList();
            ViewBag.data = obj.list_tbl_Roll;  
            return View(obj);

        }
        [HttpPost]
        public IActionResult Student_update_insert_data(Student_view_model obj2)
        {
            
            var obj1 = _context.tbl_Students.SingleOrDefault(e => e.Student_Id == obj2.tbl_Student.Student_Id);
            obj1.Student_Id = obj2.tbl_Student.Student_Id;
            obj1.Registration_Id = obj2.tbl_Student.Registration_Id;
            obj1.Contact_Number = obj2.tbl_Student.Contact_Number;
            obj1.Email_Address = obj2.tbl_Student.Email_Address;
            //obj1.Registration_Id = obj2.tbl_Student.Registration_Id;
            obj1.First_Name = obj2.tbl_Student.First_Name;
            obj1.Last_Name = obj2.tbl_Student.Last_Name;
            obj1.Gender = obj2.tbl_Student.Gender;
            obj1.Dob = obj2.tbl_Student.Dob;
            obj1.Father_Name = obj2.tbl_Student.Father_Name;
            obj1.Mother_Name = obj2.tbl_Student.Mother_Name;
            obj1.Password = obj2.tbl_Student.Password;
            obj1.Address = obj2.tbl_Student.Address;
            obj1.Zip_Code = obj2.tbl_Student.Zip_Code;
            obj1.Contact_Number = obj2.tbl_Student.Contact_Number;
            obj1.Role_Id = obj2.tbl_Student.Role_Id;
            obj1.Country = obj2.tbl_Student.Country;
            obj1.State = obj2.tbl_Student.State;    
            obj1.City = obj2.tbl_Student.City;

            obj1.IsActive = obj2.tbl_Student.IsActive;
            obj1.Role_Id = obj2.tbl_Student.Role_Id;
            _context.tbl_Students.Update(obj1);
            _context.SaveChanges();


            //update hobby table data

            foreach (var item in obj2.list_hobbes)
            {
                Tbl_Hobby2_Std_Map tbl_map = _context.Tbl_Hobby2_Std_Maps.SingleOrDefault(e => e.Id == item.Id);
                if (item.Ischecked == true)
                {

                    tbl_map.Student_Id = obj2.tbl_Student.Student_Id;
                    tbl_map.Hobby_Id = item.Id;
                    tbl_map.Hobby_Name = item.Hobby_Name;
                    _context.Tbl_Hobby2_Std_Maps.Update(tbl_map);
                    _context.SaveChanges();

                }
            }

            //update Qualification data

            foreach (Tbl_Qualification item in obj2.list_tbl_Qualifications)
            {
                Tbl_Qualification tq = _context.Tbl_Qualifications.SingleOrDefault(e => e.Std_Qli_Id == item.Std_Qli_Id);
                if (tq != null)
                {
                    tq.Student_Id = item.Student_Id;
                    tq.Qualifiaction_Name = item.Qualifiaction_Name;
                    tq.University = item.University;
                    tq.Term_Year = item.Term_Year;
                    tq.Completation_Year = item.Completation_Year;
                    tq.Percentage = item.Percentage;
                    _context.Tbl_Qualifications.Update(tq);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Student_insert_data");

        }

        public IActionResult Student_delete(int id)
        {
            var result = _context.tbl_Students.SingleOrDefault(e => e.Student_Id == id);
            _context.tbl_Students.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Student_show_data");
        }

        //Add data of Country and State and City 
        [HttpGet]
        public JsonResult Country()
        {
            var obj1 = _context.tbl_Countries.ToList();
            return new JsonResult(obj1);
        }
        [HttpGet]
        public JsonResult State(int id)
        {
            var obj2 = _context.GetTbl_States.Where(e => e.Country_Id == id);
            return new JsonResult(obj2);
        }
        [HttpGet]
        public JsonResult City(int id)
        {
            var obj3 = _context.GetTbl_Cities.Where(e => e.State_Id == id);
            return new JsonResult(obj3);
        }

        //admin pannel
        public IActionResult Admin()
        {
            //add Session
            if (HttpContext.Session.GetString("userid1")!= null)
            {
                ViewBag.msg = HttpContext.Session.GetString("userid1");

            }
            else
            {
                return RedirectToAction("Login");
            }

            //bind data off specification
            Student_view_model vm = new Student_view_model();
            vm.List_tbl_Specifications = _context.Tbl_Specifications.ToList();

            return View(vm);
        }

        public IActionResult Speci_insert()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Speci_insert(Tbl_Specification ts)
        {
            Tbl_Specification obj = new Tbl_Specification();
            obj.Spec_Name = ts.Spec_Name;
            _context.Tbl_Specifications.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }

        // add course
        public IActionResult AddCoursh(int id)
        {
            Student_view_model model = new Student_view_model();
            model.Tbl_Specification = _context.Tbl_Specifications.SingleOrDefault(e => e.Spec_Id == id);
            //show Tble_Course data
            model.list_tnl_Course1 = _context.tbl_Course1s.ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult AddCoursh(Student_view_model tc)
        {

            Tbl_Course1 obj = new Tbl_Course1();
            obj.Course_Name = tc.Tbl_Course1.Course_Name;
            obj.Spec_Id = tc.Tbl_Specification.Spec_Id;
            obj.Specification_Name = tc.Tbl_Specification.Spec_Name;
            obj.Fee = tc.Tbl_Course1.Fee;
            obj.Live_Class = tc.Tbl_Course1.Live_Class;
            obj.Recorded_Class = tc.Tbl_Course1.Recorded_Class;
            obj.Doubt_Solving_Session = tc.Tbl_Course1.Doubt_Solving_Session;
            obj.DPP = tc.Tbl_Course1.DPP;
            obj.Mock_Test = tc.Tbl_Course1.Mock_Test;
            _context.tbl_Course1s.Add(obj);
            _context.SaveChanges();

            return RedirectToAction("AddCoursh");
        }

        //add batches Table
        public IActionResult Add_batch(int id)
        {
            Student_view_model model = new Student_view_model();
            //show data of Tble_batch
            model.list_tbl_batche1s = _context.Tbl_Batch1s.ToList();

            //show id of Course
            model.Tbl_Course1 = _context.tbl_Course1s.SingleOrDefault(e => e.Course_Id == id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Add_batch(Student_view_model tb)
        {
            Tbl_Batch1 obj = new Tbl_Batch1();
            obj.Batch_Name = tb.tbl_Batch1.Batch_Name;
            obj.Batch_Timing = tb.tbl_Batch1.Batch_Timing;
            obj.Course_Id = tb.Tbl_Course1.Course_Id;
            obj.Course_Name = tb.Tbl_Course1.Specification_Name;
            obj.Instructor_Name = tb.tbl_Batch1.Instructor_Name;
            obj.Seats = tb.tbl_Batch1.Seats;
            _context.Tbl_Batch1s.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("AddCoursh");
        }

        //bind data on student update page..

        //specification
        [HttpGet]
        public JsonResult Specification()
        {
            var obj = _context.Tbl_Specifications.ToList();
            return new JsonResult(obj);
        }
        //coursh
        [HttpGet]
        public JsonResult Coursh(int a)
        {
            TempData["id"] = a;
            var obj = _context.tbl_Course1s.Where(e=> e.Spec_Id == a).ToList();
            return new JsonResult(obj);
        }
        //batchz
        [HttpGet]
        public JsonResult Batch(int a)
        {
            TempData["id2"] = a; 
            var obj = _context.Tbl_Batch1s.Where(e => e.Course_Id == a).ToList();
            return new JsonResult(obj);
        }

        //show data of coursh table and batch table in student update view page..
        [HttpGet]
        public JsonResult Update_course(int a)
        {
            Tbl_Course1? tblobj = _context.tbl_Course1s?.FirstOrDefault(m => m.Course_Id == a);
            return new JsonResult(tblobj);
        }

        [HttpGet]
        public JsonResult Update_batch(int a)
        {
            Tbl_Batch1? tbobj = _context.Tbl_Batch1s?.FirstOrDefault(m => m.Course_Id == a);
            return new JsonResult(tbobj);
        }
        [HttpPost]
        public JsonResult Add_payment(int a)
        {
            return new JsonResult(a);
        }

        //add transaction data
        [HttpPost]
        public JsonResult Get_transaction(Tbl_Transaction model)
        { 
        _context.Tbl_Transactions.Add(model);
        _context.SaveChanges();
        return new JsonResult("ohhk");
        }


    }
}
