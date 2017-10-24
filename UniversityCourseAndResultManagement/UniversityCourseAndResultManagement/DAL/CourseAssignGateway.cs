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
            bool bit = true;
            string query = "INSERT INTO CourseAssignTeacher VALUES('" + courseAssignToTeacher.TeacherId + "','" + courseAssignToTeacher.DepartmentId + "','" +
                           courseAssignToTeacher.CourseId + "','" + bit + "')";
           // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int UnAssign()
        {
            bool t = true;
            bool f = false;

            string query = "UPDATE CourseAssignTeacher SET Bit = " + 0 + " WHERE Bit = " + 1 + " ";
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int GetTeacherIdByCourseId(int courseId)
        {
            string query = "SELECT * FROM CourseAssignTeacher WHERE CourseId = '" + courseId + "' AND Bit = '" + 1 + "' ";

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

        public CourseAssignToTeacher GetByCourseId(int id)
        {
            string query = "SELECT * FROM CourseAssignTeacher WHERE CourseId = " + id + "";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            CourseAssignToTeacher courseAssignToTeacher = null;
            if (reader.HasRows)
            {
                reader.Read();
                courseAssignToTeacher = new CourseAssignToTeacher();
                courseAssignToTeacher.CourseId = (int) reader["CourseId"];
                courseAssignToTeacher.DepartmentId = (int) reader["DepartmentId"];
                courseAssignToTeacher.TeacherId = (int) reader["TeacherId"];
            }
            reader.Close();
            Connection.Close();
            return courseAssignToTeacher;
        }

    }
}