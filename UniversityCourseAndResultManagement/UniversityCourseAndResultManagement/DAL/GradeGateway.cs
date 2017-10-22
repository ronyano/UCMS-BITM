using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class GradeGateway : CommonGateway
    {
        public List<Grade> GetAllGrades()
        {
            string query = "SELECT * FROM Grade";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grade grade = new Grade();
                    grade.Id = (int) reader["Id"];
                    grade.GradeLetter = reader["GradeLetter"].ToString();
                    grades.Add(grade);
                }
            }
            reader.Close();
            Connection.Close();
            return grades;
        }
    }
}