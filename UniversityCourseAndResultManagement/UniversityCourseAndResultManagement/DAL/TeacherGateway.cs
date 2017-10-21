using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class TeacherGateway : CommonGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES('" + teacher.TeacherName + "','" + teacher.Address + "','" +
                           teacher.Email + "','" + teacher.ContactNo + "'," + teacher.DesignationId + "," +
                           teacher.DepartmentId + "," + teacher.CreditToBeTaken + "," + teacher.CreditToBeTaken + ")";
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int UpdateCredit(int teacherId, int credit)
        {
            Teacher teacher = GetById(teacherId);
            int remainingCredit = teacher.CreditRemaining - credit;
            string query = "UPDATE Teacher SET CreditRemaining = ' " + remainingCredit + "'  WHERE Id = '" + teacherId + " '";
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM Teacher";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = (int)reader["Id"];
                    teacher.TeacherName = reader["TeacherName"].ToString();
                    teacher.Address = reader["Address"].ToString();
                    teacher.Email = reader["Email"].ToString();
                    teacher.ContactNo = reader["ContactNo"].ToString();
                    teacher.DesignationId = (int)reader["DesignationId"];
                    teacher.DepartmentId = (int)reader["DepartmentId"];
                    teacher.CreditToBeTaken = Convert.ToDouble(reader["CreditToBeTaken"]);
                    teacher.CreditRemaining = (int)(reader["CreditRemaining"]);
                    teachers.Add(teacher);
                }

            }
            reader.Close();
            Connection.Close();
            return teachers;
        }

        public Teacher GetByEmail(string email)
        {
            string query = "SELECT * FROM Teacher WHERE Email = '" + email + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Teacher teacher = null;
            if (reader.HasRows)
            {
                reader.Read();
                teacher = new Teacher();
                teacher.Id = (int)reader["Id"];
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.ContactNo = reader["ContactNo"].ToString();
                teacher.DepartmentId = (int)reader["DepartmentId"];
                teacher.DesignationId = (int)reader["DesignationId"];
                teacher.CreditToBeTaken = Convert.ToDouble(reader["CreditToBeTaken"]);
            }
            reader.Close();
            Connection.Close();
            return teacher;
        }

        public Teacher GetById(int id)
        {
            string query = "SELECT * FROM Teacher WHERE Id = '" + id + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Teacher teacher = null;
            if (reader.HasRows)
            {
                reader.Read();
                teacher = new Teacher();
                teacher.Id = (int)reader["Id"];
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.ContactNo = reader["ContactNo"].ToString();
                teacher.DepartmentId = (int)reader["DepartmentId"];
                teacher.DesignationId = (int)reader["DesignationId"];
                teacher.CreditToBeTaken = Convert.ToDouble(reader["CreditToBeTaken"]);
                teacher.CreditRemaining = (int)(reader["CreditRemaining"]);
            }
            reader.Close();
            Connection.Close();
            return teacher;
        }
    }
}