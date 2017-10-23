﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGateway allocateClassroomGateway = new AllocateClassroomGateway();
        public bool Save(AllocateClassroom allocateClassroom)
        {
            if (allocateClassroomGateway.Save(allocateClassroom) > 0)
                return true;
            else
                return false;
        }
    }
}