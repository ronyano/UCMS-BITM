using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class CourseAssignGateway: CommonGateway
    {
        public int Save(CourseAssignToTeacher courseAssignToTeacher)
        {
            string query = "INSERT INTO CourseAssignTeacher VALUES('" + courseAssignToTeacher.TeacherId + "','" + courseAssignToTeacher.DepartmentId + "','" +
                           courseAssignToTeacher.CourseId + "')";
           // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int GetTeacherIdByCourseId(int courseId)
        {
            string query = "SELECT * FROM CourseAssignTeacher WHERE CourseId = '" + courseId + "'";

            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            CourseAssignToTeacher assignToTeacher = new CourseAssignToTeacher();
            if (reader.HasRows)
            {
                reader.Read();
                assignToTeacher.TeacherId = (int) (reader["TeacherId"]);
            }
            reader.Close();
            Connection.Close();

            return assignToTeacher.TeacherId;
        }
    
    }
}