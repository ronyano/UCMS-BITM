using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class RoomGateway : CommonGateway
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Room";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Room room = new Room();
                    room.Id = (int) reader["Id"];
                    room.RoomNo = (int) reader["RoomNo"];
                    rooms.Add(room);
                }
            }
            reader.Close();
            Connection.Close();
            return rooms;
        }
    }
}