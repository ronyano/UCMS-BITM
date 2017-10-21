using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();

        public List<Designation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }
    }
}