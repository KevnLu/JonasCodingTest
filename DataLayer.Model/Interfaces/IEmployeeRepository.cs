﻿using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetByCode(string employeeCode);
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> DeleteEmployee(string employeeCode);
    }
}
