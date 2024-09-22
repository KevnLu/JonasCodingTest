using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        string GetNameByCode(string companyCode);
        string GetCodeByName(string companyName);
        string GetSiteIdByName(string companyName);
        Task<bool> AddCompany(CompanyInfo company);
        Task<bool> ModifyCompany(CompanyInfo company);
        Task<bool> DeleteCompany(string companyCode);
    }
}
