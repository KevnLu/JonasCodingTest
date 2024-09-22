using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var items = await _employeeService.GetAllCompanies();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            var item = await _employeeService.GetEmployeeByCode(employeeCode);
            return _mapper.Map<EmployeeDto>(item);
        }

        // POST api/<controller>
        public async void Post([FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<EmployeeInfo>(employeeDto);
            await _employeeService.AddEmployee(employee);
        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<EmployeeInfo>(employeeDto);
            await _employeeService.AddEmployee(employee);
        }

        // DELETE api/<controller>/5
        public async void Delete(string employeeCode)
        {
            await _employeeService.DeleteEmployee(employeeCode);
        }
    }
}
