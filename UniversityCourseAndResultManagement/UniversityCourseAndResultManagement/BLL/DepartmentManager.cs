using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;
using UniversityCourseAndResultManagement.DAL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public bool Save(Department department)
        {
            if (IsNameOrCodeAvailable(department.Code,department.DepartmentName))
            {
                int rowsAffected = departmentGateway.Save(department);
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }

        public string GetDepartmentCode(int departmentId)
        {
            return departmentGateway.GetDepartmentCode(departmentId);
        }

        public Department GetByCodeAndName(string code, string name)
        {
            return departmentGateway.GetByCodeAndName(code, name);
        }

        public bool IsNameOrCodeAvailable(string code, string name)
        {
            Department department = GetByCodeAndName(code, name);
            if (department == null)
            {
                return true;
            }
            return false;
        }
    }
}