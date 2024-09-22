using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILog log)
        {
            _companyService = companyService;
            _mapper = mapper;
            _log = log;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            _log.Info("This is a test");
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async void Post([FromBody] CompanyDto companyDto)
        {
            var company = _mapper.Map<CompanyInfo>(companyDto); 
            await _companyService.AddCompany(company);
        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody] CompanyDto companyDto)
        {
            var company = _mapper.Map<CompanyInfo>(companyDto);
            await _companyService.AddCompany(company);
        }

        // DELETE api/<controller>/5
        public async void Delete(string companyCode)
        {
            await _companyService.DeleteCompany(companyCode);
        }
    }
}