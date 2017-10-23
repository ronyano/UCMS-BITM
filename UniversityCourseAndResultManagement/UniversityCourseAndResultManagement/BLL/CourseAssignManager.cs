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
            if (IsCourseAssignable(course.CourseId))
            {
                int rowsAffected = courseAssignGateway.Save(course);
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetTeacherIdByCourseId(int courseId)
        {
            return courseAssignGateway.GetTeacherIdByCourseId(courseId);
        }
<<<<<<< HEAD
=======

        public CourseAssignToTeacher GetByCourseId(int id)
        {
            return courseAssignGateway.GetByCourseId(id);
        }

        public bool IsCourseAssignable(int id)
        {
            CourseAssignToTeacher courseAssignToTeacher = GetByCourseId(id);
            if (courseAssignToTeacher == null)
            {
                return true;
            }
            return false;
        }

        
>>>>>>> 1c40b288c9de276de222b0f2e9ab34c849ef5e06
    }
}