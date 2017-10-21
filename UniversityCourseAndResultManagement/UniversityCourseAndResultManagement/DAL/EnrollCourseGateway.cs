using System;
using System.Collections.Generic;
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
    }
}