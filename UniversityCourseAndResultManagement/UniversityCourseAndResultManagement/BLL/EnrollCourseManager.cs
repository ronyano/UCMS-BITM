using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();

        public bool Save(EnrollInACourse enrollInACourse)
        {
            if (IsCourseEnrollable(enrollInACourse))
            {
                if (enrollCourseGateway.Save(enrollInACourse) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCourseEnrollable(EnrollInACourse enrollInACourse)
        {
            int countRow = enrollCourseGateway.IsCourrseEnrollable(enrollInACourse);
            if (countRow > 0)
            {
                return false;
            }
            return true;
        }

        public List<EnrollInACourse> GetAllEnrollInACourses()
        {
            return enrollCourseGateway.GetAllEnrollInACourses();
        }
    }
}