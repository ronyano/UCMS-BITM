using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class CourseGateway : CommonGateway
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO Course VALUES('" + course.CourseCode + "','" + course.CourseName + "','" +
                           course.Description + "'," + course.SemesterId + "," + course.DepartmentId + "," + course.Credit + ")";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM Course";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();
                    course.Id = (int)reader["Id"];
                    course.CourseCode = reader["CourseCode"].ToString();
                    course.CourseName = reader["CourseName"].ToString();
                    course.Credit = (int)reader["Credit"];
                    course.Description = reader["Description"].ToString();
                    course.DepartmentId = (int)reader["DepartmentId"];
                    course.SemesterId = (int)reader["SemesterId"];
                    courses.Add(course);
                }

            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public Course GetCourseByNameAndCode(string name, string code)
        {
            string query = "SELECT * FROM Course WHERE CourseName = '" + name + "' OR CourseCode = '" + code + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Course course = new Course();
            course = null;
            if (reader.HasRows)
            {
                reader.Read();
                course = new Course();
                course.Id = (int)reader["Id"];
            }
            reader.Close();
            Connection.Close();
            return course;
        }

        public int GetCreditById(int id)
        {
            string query = "SELECT * FROM Course WHERE Id = '" + id + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();

            Course course = new Course();
            if (reader.HasRows)
            {
                reader.Read();
                course.Credit = (int)reader["Credit"];
            }
            reader.Close();
            Connection.Close();
            return course.Credit;
        }
    }
}