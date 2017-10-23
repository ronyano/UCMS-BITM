using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class CourseAssignManager
    {
        CourseAssignGateway courseAssignGateway = new CourseAssignGateway(); 
        public bool Save(CourseAssignToTeacher course)
        {
            if (courseAssignGateway.Save(course) > 0)
                return true;
            else
                return false;
        }

        public int GetTeacherIdByCourseId(int courseId)
        {
            return courseAssignGateway.GetTeacherIdByCourseId(courseId);
        }

        
    }
}