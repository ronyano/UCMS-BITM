using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class AllocateClassroomGateway : CommonGateway
    {
        public int Save(AllocateClassroom allocateClassroom)
        {
            bool bit = true;
            var fTime = allocateClassroom.FromTime.ToString("HH:mm");
            var tTime = allocateClassroom.ToTime.ToString("HH:mm");
            
            //fTime.Hour;
            string query = "INSERT INTO AllocateClassroom VALUES('" + allocateClassroom.DepartmentId + "','" + allocateClassroom.CourseId + "','"  + allocateClassroom.RoomId + "','" + allocateClassroom.DayId + "','" + fTime + "','"+ tTime + "','"+bit+" ')";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }


        public List<AllocateClassroom> GetAllRoomSchedule()
        {
            string query = "SELECT * FROM AllocateClassroom";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<AllocateClassroom> rooms = new List<AllocateClassroom>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //DepartmentId CourseId RoomId DayId FromTime ToTime
                    AllocateClassroom room = new AllocateClassroom();
                    room.Id = (int)reader["Id"];
                    room.DepartmentId = (int)reader["DepartmentId"];
                    room.CourseId = (int)reader["CourseId"];
                    room.RoomId = (int)reader["RoomId"];
                    room.DayId = (int)reader["DayId"];
                    room.FromStringTime = (reader["FromTime"]).ToString();
                    //room.FromTime = room.FromTime.ToString("HH:mm");
                    room.ToStringTime = (reader["ToTime"]).ToString();

                    
                    rooms.Add(room);
                }

            }
            reader.Close();
            Connection.Close();
            return rooms;
        }
    }
}