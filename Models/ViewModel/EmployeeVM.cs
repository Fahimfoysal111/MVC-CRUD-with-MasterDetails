using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidenceExam.Models.ViewModel
{
    public class EmployeeVM
    {
        public EmployeeVM() 
        {
        this.EmployeeList=new List<ProjectAssignment>();
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public  DateTime DateOfJoining { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase Picturefile { get; set; }
        public bool EmployeeActive { get; set; }
        public List<ProjectAssignment> EmployeeList { get; set; }
    }
}