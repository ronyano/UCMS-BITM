using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class SemesterGateway : CommonGateway
    {
        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * From Semester";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester semester = new Semester();
                    semester.Id = (int) reader["Id"];
                    semester.SemesterNo = reader["SemesterNo"].ToString();
                    semesters.Add(semester);
                }
            }
            reader.Close();
            Connection.Close();
            return semesters;
        }
    }
}