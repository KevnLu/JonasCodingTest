using BusinessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllCompanies();
        Task<EmployeeInfo> GetEmployeeByCode(string employeeCode);
        Task<bool> AddEmployee(EmployeeInfo employee);
        Task<bool> ModifyEmployee(EmployeeInfo employee);
        Task<bool> DeleteEmployee(string employeeCode);
    }
}
