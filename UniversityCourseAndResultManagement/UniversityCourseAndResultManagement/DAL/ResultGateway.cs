using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                           result.Grade + "','" + bit + "')";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int IsStudentResultAssignable(Result result)
        {
            string query = "SELECT COUNT(*) FROM Result WHERE CourseId = " + result.CourseId + "AND StudentId = " +
                           result.StudentId + "";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            int count = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    count += Convert.ToInt32(reader[0]);
                }
            }
            Connection.Close();
            reader.Close();
            return count;
        }


        public List<Result> GetAllResults()
        {
            string query = "SELECT * FROM Result";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Result> results = new List<Result>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Result result = new Result();
                    result.Id = (int)reader["Id"];
                    result.StudentId = (int)reader["StudentId"];
                    result.CourseId = (int)reader["CourseId"];
                    result.Grade = reader["Grade"].ToString();
                    results.Add(result);
                }
            }
            reader.Close();
            Connection.Close();
            return results;
        }
    }
}