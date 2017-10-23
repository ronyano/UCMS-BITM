using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class AllocateClassroomGateway : CommonGateway
    {
        public int Save(AllocateClassroom allocateClassroom)
        {
            string query = "INSERT INTO AllocateClassroom VALUES('" + allocateClassroom.DepartmentId + "','" + allocateClassroom.CourseId + "','"  + allocateClassroom.RoomId + "','" + allocateClassroom.DayId + "','" + allocateClassroom.FromTime + "','"+ allocateClassroom.ToTime + "',1)";
            // if(Connection.State != ConnectionState.Open)
            Connection.Open();
            Command.CommandText = query;
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
    }
}