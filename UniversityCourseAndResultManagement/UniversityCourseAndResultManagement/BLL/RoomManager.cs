using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class RoomManager
    {
        RoomGateway roomGateway = new RoomGateway();

        public List<Room> GetAllRooms()
        {
            return roomGateway.GetAllRooms();
        }
    }
}