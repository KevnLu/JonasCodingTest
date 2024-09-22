using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
	    private readonly IDbWrapper<Company> _companyDbWrapper;

	    public CompanyRepository(IDbWrapper<Company> companyDbWrapper)
	    {
		    _companyDbWrapper = companyDbWrapper;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyDbWrapper.FindAllAsync();
        }

        public async Task<Company> GetByCode(string companyCode)
        {
            return (await _companyDbWrapper.FindAsync(t => t.CompanyCode.Equals(companyCode)))?.FirstOrDefault();
        }

        public string GetNameByCode(string companyCode)
        {
            return (_companyDbWrapper.Find(t => t.CompanyCode.Equals(companyCode)))?.FirstOrDefault().CompanyName;
        }

        //Suppose the company name is unique, otherwise the requirement that the Dto only has company name has problem.
        public string GetCodeByName(string companyName)
        {
            return (_companyDbWrapper.Find(t => t.CompanyName.Equals(companyName)))?.FirstOrDefault().CompanyCode;
        }

        public string GetSiteIdByName(string companyName)
        {
            return (_companyDbWrapper.Find(t => t.CompanyName.Equals(companyName)))?.FirstOrDefault().SiteId;
        }

        public async Task<bool> SaveCompany(Company company)
        {
            var itemRepo = (await _companyDbWrapper.FindAsync(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode)))?.FirstOrDefault();
            if (itemRepo !=null)
            {
                itemRepo.CompanyName = company.CompanyName;
                itemRepo.AddressLine1 = company.AddressLine1;
                itemRepo.AddressLine2 = company.AddressLine2;
                itemRepo.AddressLine3 = company.AddressLine3;
                itemRepo.Country = company.Country;
                itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                itemRepo.FaxNumber = company.FaxNumber;
                itemRepo.PhoneNumber = company.PhoneNumber;
                itemRepo.PostalZipCode = company.PostalZipCode;
                itemRepo.LastModified = company.LastModified;
                return await _companyDbWrapper.UpdateAsync(itemRepo);
            }

            return await _companyDbWrapper.InsertAsync(company);
        }

        public async Task<bool> DeleteCompany(string companyCode)
        {
            var itemRepo = await GetByCode(companyCode);
            if (itemRepo != null)
            {
                return await _companyDbWrapper.DeleteAsync(t => t.CompanyCode.Equals(companyCode));
            }
            return false;
        }
    }
}
