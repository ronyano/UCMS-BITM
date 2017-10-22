using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class DayManager
    {
        DayGateway dayGateway = new DayGateway();

        public List<Day> GetAllDays()
        {
            return dayGateway.GetAllDays();
        }
    }
}