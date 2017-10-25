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
            if (IsStudentResultAssignable(result))
            {
                if (resultGateway.Save(result) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsStudentResultAssignable(Result result)
        {
            int countRow = resultGateway.IsStudentResultAssignable(result);
            if (countRow > 0)
            {
                return false;
            }
            return true;
        }

        public List<Result> GetAllResults()
        {
            return resultGateway.GetAllResults();
        }
    }
}