using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();

        public bool Save(Course course)
        {
            if (IsNameOrCodeAvailable(course.CourseName, course.CourseCode))
            {
                int rowsAffected = courseGateway.Save(course);
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

        public Course GetCourseByNameAndCode(string name, string code)
        {
            return courseGateway.GetCourseByNameAndCode(name, code);
        }
        public bool IsNameOrCodeAvailable(string name, string code)
        {
            Course course = GetCourseByNameAndCode(name, code);
            if (course == null)
            {
                return true;
            }
            return false;
        }

        public int GetGetCreditById(int id)
        {
            return courseGateway.GetCreditById(id);
        }
    }
}