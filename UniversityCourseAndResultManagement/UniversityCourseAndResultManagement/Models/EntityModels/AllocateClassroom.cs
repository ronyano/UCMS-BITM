using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models.EntityModels
{
    public class AllocateClassroom
    {
       // DepartmentIdCourseIdRoomIdDayIdFromTimeToTime
        public int  Id { get; set; }
        public int  DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int  RoomId { get; set; }
        public int DayId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public string FromStringTime { get; set; }
        public string ToStringTime { get; set; }


    }
}