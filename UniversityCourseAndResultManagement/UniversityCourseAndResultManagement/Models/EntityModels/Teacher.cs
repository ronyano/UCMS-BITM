using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public double CreditToBeTaken { get; set; }

        public int CreditRemaining { get; set; }
    }
}