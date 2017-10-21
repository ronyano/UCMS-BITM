using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class CourseAssignToTeacher
    {
        public int TeacherId { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }

    }
}