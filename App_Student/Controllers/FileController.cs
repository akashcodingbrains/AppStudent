using App_Student.Data;
using App_Student.Models.other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace App_Student.Controllers
{
    public class FileController : Controller
    {
        private readonly Student_Context _Context;
        private readonly IWebHostEnvironment environment;
        public FileController(Student_Context context, IWebHostEnvironment environment)
        {
            this._Context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var obj = _Context.Tbl_Files.ToList();
            return View(obj);
        }

        public IActionResult Add_file()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_file(Tbl_file model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniquefilename = File_upload(model);

                    var obj = new Tbl_file()
                    {
                        Name = model.Name,
                        File_Name = uniquefilename
                    };
                    _Context.Tbl_Files.Add(obj);
                    _Context.SaveChanges();
                    TempData["succses"] = "success full!";
                    return RedirectToAction("Index");
                        
                }
                ModelState.AddModelError(string.Empty, "model is not valid");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private string File_upload(Tbl_file model)
        { 
        string Uniquefilename = string.Empty;
            if (model.File_Path != null)
            {
                string uploadfolder = Path.Combine(environment.WebRootPath,"content/file/");
                Uniquefilename = Guid.NewGuid().ToString() + "_" + model.File_Path.FileName;
                string filepath = Path.Combine(uploadfolder ,Uniquefilename);
                using (var fileStream = new FileStream(filepath , FileMode.Create))
                {
                    model.File_Path.CopyTo(fileStream);
                }
            
            }
            return Uniquefilename;
        } 
    }
}
