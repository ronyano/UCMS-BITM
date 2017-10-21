using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class DepartmentGateway : CommonGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES('" + department.DepartmentName + "','" + department.Code +
                           "')";
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Department";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.Id = (int) reader["Id"];
                    department.DepartmentName = reader["DepartmentName"].ToString();
                    department.Code = reader["Code"].ToString();
                    departments.Add(department);
                }

            }
            reader.Close();
            Connection.Close();
            return departments;
        }

        public string GetDepartmentCode(int departmentId)
        {
            string query = "SELECT Code FROM Department WHERE Id = " + departmentId + "";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            string code = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
            }
            reader.Close();
            Connection.Close();
            return code;
        }

        public Department GetByCodeAndName(string code, string name)
        {
            string query = "SELECT * FROM Department WHERE DepartmentName = '" + name + "' OR Code = '" + code + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Department department = null;
            if (reader.HasRows)
            {
                reader.Read();
                department = new Department();
                department.Id = (int) reader["Id"];
                department.DepartmentName = reader["DepartmentName"].ToString();
                department.Code = reader["Code"].ToString();

            }
            reader.Close();
            Connection.Close();
            return department;
        }
    }
}