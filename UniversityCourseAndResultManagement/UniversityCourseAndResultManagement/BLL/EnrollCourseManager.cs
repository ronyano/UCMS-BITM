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
            if (enrollCourseGateway.Save(enrollInACourse) > 0)
                return true;
            else
            {
                return false;
            }
        }
    }
}