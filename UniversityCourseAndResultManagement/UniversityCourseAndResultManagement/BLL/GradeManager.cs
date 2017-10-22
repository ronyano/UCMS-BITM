using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class GradeManager
    {
        GradeGateway gradeGateway = new GradeGateway();

        public List<Grade> GetAllGrades()
        {
            return gradeGateway.GetAllGrades();
        }
    }
}