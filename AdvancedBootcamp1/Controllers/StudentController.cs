using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedBootcamp1.Models;
using AdvancedBootcamp1.Models.Dtos;
using AdvancedBootcamp1.MyDatabase;

namespace AdvancedBootcamp1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student without the projects
        [HttpGet]
        public ActionResult GetStudents()
        {
            var students = db.Students.Select(stu => new {stu.StudentId, stu.Name, stu.Score }).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        // GET: Student With the Projects
        [HttpGet]
        public ActionResult GetStudentsWithProjects()
        {
            var students = db.Students
                            .Select(stu => new
                            {
                                stu.StudentId,
                                stu.Name,
                                stu.Score,
                                Projects = stu.Projects.Select(pro => new
                                {
                                    pro.Id,
                                    pro.Title
                                })
                            }).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }



        [HttpPost] // Create Student Without Projects
        public ActionResult CreateStudentWithoutProjects( StudentDto studentDto)
        {
            Student s = new Student();

            s.Name = studentDto.Name;
            s.Score = studentDto.Score;

            db.Entry(s).State = EntityState.Added;
            db.SaveChanges();

            return Json(new { message = "Student successfully created!" }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]   // Create Student With Project
        public ActionResult CreateStudentWithProjects(Student student)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(student).State = EntityState.Added;
                db.SaveChanges(); 
                return Json(new { message = "Student successfully created!" }, JsonRequestBehavior.AllowGet);
            }

            return View(student);
        }





        [HttpDelete]  // Delete 1 Student without projects
        public ActionResult DeleteOneStudentWithoutProjects(int? id)
        {
            var student = db.Students.Where(s => s.StudentId == id).Include(s => s.Projects).FirstOrDefault();

            if(student == null)
            {
                return HttpNotFound();
            }           

            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(new { message = "Student successfully deleted!" }, JsonRequestBehavior.AllowGet);
        }



        [HttpDelete]  // Delete 1 Student with projects
        public ActionResult DeleteOneStudentWithProjects(int? id)
        {
            var student = db.Students.Where(s => s.StudentId == id).Include(x=>x.Projects).FirstOrDefault();

            if (student == null)
            {
                return HttpNotFound();
            }

            var ids = student.Projects.Select(x => x.Id).ToList();


            foreach (var dd in ids)  // Delete projects of the student
            {
                var pro = db.Projects.Find(dd);    
                db.Entry(pro).State = EntityState.Deleted;
            }
            db.SaveChanges();

            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(new { message = "Student and his projects successfully deleted!" }, JsonRequestBehavior.AllowGet);
        }




        [HttpDelete]  // Delete All Students without projects
        public ActionResult DeleteAllStudentsWithoutProjects()
        {
            var students = db.Students.Include(s => s.Projects).ToList();

            foreach (var student in students)
            {
                student.Projects.Clear();
                db.Entry(student).State = EntityState.Deleted;
            }


            db.SaveChanges();

            return Json(new { message = "All Student without Projects successfully deleted!" }, JsonRequestBehavior.AllowGet);
        }



        [HttpDelete]  // Delete All Students with projects
        public ActionResult DeleteAllStudentsWithProjects()
        {
            var students = db.Students.Include(s => s.Projects);
            var projects = db.Projects.ToList();
            foreach (var project in projects)
            {
                if(project.StudentId != null)
                    db.Entry(project).State = EntityState.Deleted;
            }           


            db.SaveChanges();

            return Json(new { message = "All Student with Projects successfully deleted!" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPut]
        public ActionResult AssignProjectsToStudent(AssignProjectDto assignProjectDto) 
        {
            //var student = db.Students.Where(s=>s.StudentId == assignProjectDto.StudentId).Include(s=>s.Projects).FirstOrDefault();
            //var ids = assignProjectDto.projectIds.ToList();
            //foreach (var id in ids)
            //{
            //    var pro = db.Projects.Find(id);
            //    student.Projects.Add(pro);
            //}
            //db.SaveChanges();

            foreach (var id in assignProjectDto.projectIds)
            {
                var pro = db.Projects.Find(id);
                pro.StudentId = assignProjectDto.StudentId;
                db.Entry(pro).State = EntityState.Modified;
            }
            db.SaveChanges();


            return Json(new { message = "projects assigned to Student Successfully" }, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
