using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class EnrollCourseGateway : CommonGateway
    {
        public int Save(EnrollInACourse enrollInACourse)
        {
            string query = "INSERT INTO EnrollCourse VALUES('" + enrollInACourse.StudentId + "','" + enrollInACourse.CourseId + "','" +
                          enrollInACourse.EnrollDate + "')";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
        public List<EnrollInACourse> GetAllEnrollInACourses()
        {
            string query = "SELECT * FROM EnrollCourse";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<EnrollInACourse> enrollInACourses = new List<EnrollInACourse>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EnrollInACourse enrollInACourse = new EnrollInACourse();
                    enrollInACourse.Id = (int)reader["Id"];
                    enrollInACourse.StudentId = (int) reader["StudentId"];
                    enrollInACourse.CourseId = (int)reader["CourseId"];
                    enrollInACourses.Add(enrollInACourse);
                }

            }
            reader.Close();
            Connection.Close();
            return enrollInACourses;
        } 
    }
}