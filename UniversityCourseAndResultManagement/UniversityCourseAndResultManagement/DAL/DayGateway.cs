﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.DAL
{
    public class DayGateway : CommonGateway
    {
        public List<Day> GetAllDays()
        {
            string query = "SELECT * FROM Day";
            Connection.Open();
            Command.CommandText = query;
            SqlDataReader reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Day day = new Day();
                    day.Id = (int) reader["Id"];
                    day.DayName = reader["DayName"].ToString();
                    days.Add(day);
                }
            }
            reader.Close();
            Connection.Close();
            return days;
        }
    }
}