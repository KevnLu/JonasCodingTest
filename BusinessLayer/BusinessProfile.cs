using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model;
using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessLayer
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<DataEntity, BaseInfo>()
                .Include<Company, CompanyInfo>();
            CreateMap<Company, CompanyInfo>()
                .ForMember(company=>company.ArSubledgers, c=>c.MapFrom(m=>m.ArSubledgers))
                .ReverseMap();
            CreateMap<ArSubledger, ArSubledgerInfo>()
                .ReverseMap();
            CreateMap<Employee, EmployeeInfo>()
                .ReverseMap();
        }
    }

}