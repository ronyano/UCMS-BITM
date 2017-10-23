using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class ResultManager
    {
        ResultGateway resultGateway = new ResultGateway();
        public bool Save(Result result)
        {
            if (resultGateway.Save(result) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}