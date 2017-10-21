using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class DesignationGateway : CommonGateway
    {
        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designation";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Designation designation = new Designation();
                    designation.Id = (int) reader["Id"];
                    designation.DesignationName = reader["DesignationName"].ToString();
                    designations.Add(designation);
                }
            }
            reader.Close();
            Connection.Close();
            return designations;
        }
    }
}