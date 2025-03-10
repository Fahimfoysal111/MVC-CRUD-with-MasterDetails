//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvidenceExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.ProjectAssignments = new HashSet<ProjectAssignment>();
        }
    
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase Picturefile { get; set; }
        public bool EmployeeActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectAssignment> ProjectAssignments { get; set; }
    }
}
