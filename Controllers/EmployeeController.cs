using EvidenceExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EvidenceExam.Models.ViewModel;
using System.IO;
using System.Net;
using System.Data.Entity.Infrastructure;
namespace EvidenceExam.Controllers
{
    public class EmployeeController : Controller
    {
        Employee11Entities db = new Employee11Entities();
        // GET: Employee
        public ActionResult Index()
        {
            var student = db.Employees.Include(x => x.ProjectAssignments.Select(v => v.Project)).OrderByDescending(n => n.EmployeeId).ToList();
            return View(student);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeVM vmodel, int[] projectid)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    EmployeeName = vmodel.EmployeeName,
                    Age = vmodel.Age,
                    DateOfJoining = vmodel.DateOfJoining,
                    EmployeeActive = vmodel.EmployeeActive,
                };

                HttpPostedFileBase file = vmodel.Picturefile;
                if (file != null)
                {
                    string fileName = Path.Combine("/Images/" + DateTime.Now.Ticks.ToString() +
                   Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(fileName));
                    employee.Picture = fileName;
                }
                foreach (var p in projectid)
                {
                    var project = db.Projects.FirstOrDefault(f => f.ProjectId == p);
                    ProjectAssignment detail = new ProjectAssignment()
                    {
                        Employee = employee,
                        EmployeeId = employee.EmployeeId,
                        ProjectId = project.ProjectId,

                    };
                    db.ProjectAssignments.Add(detail);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vmodel);
        }
        public ActionResult AddNewProject(int? id)
        {
            ViewBag.project = new SelectList(db.Projects, "ProjectId", "ProjectName", (id != null)
           ? id.ToString() : "");
            return PartialView("_addnewproject");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Employee employe = db.Employees.Find(id);
            EmployeeVM vmodel = new EmployeeVM()
            {
                EmployeeId = employe.EmployeeId,
                EmployeeName = employe.EmployeeName,
                Age = employe.Age,
                DateOfJoining = employe.DateOfJoining,
                EmployeeActive = employe.EmployeeActive,
                Picture = employe.Picture,
            };
            return View(vmodel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeVM vmodel, int[] projectId)
        {
            if (ModelState.IsValid)
            {
                var employee = db.Employees.Find(vmodel.EmployeeId);
                employee.EmployeeName = vmodel.EmployeeName;
                employee.Age = vmodel.Age;
                employee.DateOfJoining = vmodel.DateOfJoining;
                employee.EmployeeActive = vmodel.EmployeeActive;
                HttpPostedFileBase file = vmodel.Picturefile;
                if (file != null)
                {
                    string fileName = Path.Combine("/Images/" + DateTime.Now.Ticks.ToString() +
                   Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(fileName));
                    employee.Picture = fileName;
                }
                else
                {
                    employee.Picture = employee.Picture;
                }
                var dp = db.ProjectAssignments.Where(u => u.EmployeeId == employee.EmployeeId).ToList();
                foreach (var d in dp)
                {
                    db.ProjectAssignments.Remove(d);
                }
                foreach (var p in projectId)
                {
                    var project = db.Projects.FirstOrDefault(f => f.ProjectId == p);
                    ProjectAssignment detail = new ProjectAssignment()
                    {
                        Employee = employee,
                        EmployeeId = employee.EmployeeId,
                        ProjectId = project.ProjectId,
                        
                    };
                    db.ProjectAssignments.Add(detail);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vmodel);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var user = db.Employees.FirstOrDefault(u => u.EmployeeId == id);
                var detail = db.ProjectAssignments.Where(u => u.EmployeeId == id).ToList();
                foreach (var d in detail)
                {
                    db.ProjectAssignments.Remove(d);
                }
                db.Employees.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }


    }
}