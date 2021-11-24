using crudoperation.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudoperation.Controllers
{
    public class StudentController : Controller
    {
        // GET: student
        dbtestEntities dbobj = new dbtestEntities();
        public ActionResult Student(studentinfo obj)
        {
                return View(obj);
        }
            
           

        
        [HttpPost]
        public ActionResult AddStudent(studentinfo model)
        {
            studentinfo obj = new studentinfo();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.FName = model.FName;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.ID == 0)
                {
                    dbobj.studentinfoes.Add(obj);
                    dbobj.SaveChanges();
                }
                else 
                {
                    dbobj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbobj.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbobj.studentinfoes.ToList();
            return View(res);

        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.studentinfoes.Where(x => x.ID == id).First();
            dbobj.studentinfoes.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.studentinfoes.ToList();
            return View("StudentList", list);
        }


    }



}