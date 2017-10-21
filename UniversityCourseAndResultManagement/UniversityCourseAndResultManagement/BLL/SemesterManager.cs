using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemesters()
        {
            return semesterGateway.GetAllSemesters();
        }
    }
}