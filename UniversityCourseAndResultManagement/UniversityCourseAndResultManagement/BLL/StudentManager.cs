using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public string CountStudent(int departmentId, string currentYear)
        {
            int countStudent = studentGateway.CountStudent(departmentId, currentYear);
            countStudent++;
            return countStudent.ToString("000");
        }

        public bool RegisterStudent(Student student)
        {
            if (IsEmailAvailable(student.Email))
            {

                student.RegNo = student.GenerateRegNo();
                int rowsAffected = studentGateway.Register(student);
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Student GetByEmail(string email)
        {
            return studentGateway.GetByEmail(email);
        }

        public Student GetByRegno(string regno)
        {
            return studentGateway.GetByRegno(regno);
        }

        public bool IsEmailAvailable(string email)
        {
            Student student = GetByEmail(email);
            if (student == null)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }
    }
}