using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class ResultGateway : CommonGateway
    {
        public int Save(Result result)
        {
            bool bit = true;
            string query = "INSERT INTO Result VALUES('" + result.StudentId + "','" + result.CourseId + "','" +
                           result.GradeId + "','" + bit + "')";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
    }
}