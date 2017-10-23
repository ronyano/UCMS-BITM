using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway = new TeacherGateway();

        public bool Save(Teacher teacher)
        {
            if (IsEmailAvailable(teacher.Email))
            {
                int rowsAffected = teacherGateway.Save(teacher);
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Teacher GetByEmail(string email)
        {
            return teacherGateway.GetByEmail(email);
        }

        public Teacher GetById(int id)
        {
            return teacherGateway.GetById(id);
        }
        public bool IsEmailAvailable(string email)
        {
            Teacher teacher = GetByEmail(email);
            if (teacher == null)
            {
                return true;
            }
            return false;
        }

        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }

        public bool UpdateCredit(int teacherId, int credit)
        {
            if (teacherGateway.UpdateCredit(teacherId, credit) > 0)
                return true;
            else
                return false;
        }
    }
}