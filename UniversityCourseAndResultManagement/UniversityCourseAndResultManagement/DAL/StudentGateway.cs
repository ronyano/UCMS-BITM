using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class StudentGateway : CommonGateway
    {
        public int CountStudent(int departmentId, string currentYear)
        {
            string query = "SELECT COUNT(Id) FROM Student WHERE DepartmentId = " + departmentId + "AND RegDate LIKE '%" +
                           currentYear + "%'";
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

        public int Register(Student student)
        {
            string query = "Insert Into Student Values('" + student.StudentName + "','" + student.Email + "','" +
                           student.ContactNo + "','" + student.RegDate + "','" + student.Address + "'," +
                           student.DepartmentId + ",'" + student.RegNo + "')";
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public Student GetByEmail(string email)
        {
            string query = "SELECT * FROM Student WHERE Email = '" + email + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Student student = null;
            if (reader.HasRows)
            {
                reader.Read();
                student = new Student();
                student.Id = (int) reader["Id"];
                student.StudentName = reader["StudentName"].ToString();
                student.Email = reader["Email"].ToString();
                student.Address = reader["Address"].ToString();
                student.ContactNo = reader["ContactNo"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.DepartmentId = (int) reader["DepartmentId"];
                student.RegDate = Convert.ToDateTime(reader["RegDate"]);
            }
            reader.Close();
            Connection.Close();
            return student;
        }

        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM Student";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = (int) reader["Id"];
                    student.StudentName = reader["StudentName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.ContactNo = reader["ContactNo"].ToString();
                    student.RegDate = Convert.ToDateTime(reader["RegDate"]);
                    student.Address = reader["Address"].ToString();
                    student.DepartmentId = (int) reader["DepartmentId"];
                    student.RegNo = reader["RegNo"].ToString();
                    students.Add(student);
                }
            }
            reader.Close();
            Connection.Close();
            return students;
        }

        public Student GetByRegno(string regno)
        {

            string query = "SELECT * FROM Student WHERE Email = '" + regno + "'";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            Student student = null;
            if (reader.HasRows)
            {
                reader.Read();
                student = new Student();
                student.Id = (int)reader["Id"];
                student.StudentName = reader["StudentName"].ToString();
                student.Email = reader["Email"].ToString();
                student.Address = reader["Address"].ToString();
                student.ContactNo = reader["ContactNo"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.DepartmentId = (int)reader["DepartmentId"];
                student.RegDate = Convert.ToDateTime(reader["RegDate"]);
            }
            reader.Close();
            Connection.Close();
            return student;
            
        }
    }
}