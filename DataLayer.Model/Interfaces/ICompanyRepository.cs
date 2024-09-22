using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetByCode(string companyCode);
        string GetNameByCode(string companyCode);
        string GetCodeByName(string companyName);
        string GetSiteIdByName(string companyName);
        Task<bool> SaveCompany(Company company);
        Task<bool> DeleteCompany(string companyCode);
    }
}
