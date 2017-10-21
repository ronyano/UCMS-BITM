using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.BLL;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class Student
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
         ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string RegNo { get; set; }




        public string GenerateRegNo()
        {
            int departmentId = DepartmentId;
            string departmentCode = departmentManager.GetDepartmentCode(departmentId);
            String currentYear = RegDate.Year.ToString();
            string countStudent = studentManager.CountStudent(departmentId, currentYear);
            string regNo = departmentCode + "-" + currentYear + "-" + countStudent;
            return regNo;
        }
    }

}