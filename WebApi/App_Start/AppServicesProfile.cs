using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using System;
using WebApi.Models;

namespace WebApi
{
    public class AppServicesProfile : Profile
    {
        
        public AppServicesProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<BaseInfo, BaseDto>()
                .Include<CompanyInfo, CompanyDto>();
            CreateMap<CompanyInfo, CompanyDto>()
                .ForMember(company => company.ArSubledgers, c => c.MapFrom(m => m.ArSubledgers))
                .ReverseMap();
            CreateMap<ArSubledgerInfo, ArSubledgerDto>()
                .ReverseMap();
            CreateMap<EmployeeInfo, EmployeeDto>()
                .ForMember(dest => dest.OccupationName, opt => opt.MapFrom(src => src.Occupation))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.LastModifiedDateTime, opt => opt.MapFrom(src => src.LastModified.ToLongDateString()))
                .ReverseMap()
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => DateTime.Parse(src.LastModifiedDateTime)))
                .AfterMap<EmployeeDtoToInfoAction>()
                .ReverseMap()
                .AfterMap<EmployeeInfoToDtoAction>();
                //.ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => _companyService.GetCodeByName(src.CompanyName)))
                //.ReverseMap()
                //.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => _companyService.GetNameByCode(src.CompanyCode)))
                //.ReverseMap()
                //.ForMember(dest => dest.SiteId, opt => opt.MapFrom(src => _companyService.GetSiteIdByName(src.CompanyName)));
        }
    }

    public class EmployeeInfoToDtoAction : IMappingAction<EmployeeInfo, EmployeeDto>
    {
        private readonly ICompanyService _companyService;

        public EmployeeInfoToDtoAction(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public void Process(EmployeeInfo source, EmployeeDto destination)
        {
            destination.CompanyName = _companyService.GetNameByCode(source.CompanyCode);
        }
    }

    public class EmployeeDtoToInfoAction : IMappingAction<EmployeeDto, EmployeeInfo>
    {
        private readonly ICompanyService _companyService;

        public EmployeeDtoToInfoAction(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public void Process(EmployeeDto source, EmployeeInfo destination)
        {
            destination.CompanyCode = _companyService.GetNameByCode(source.CompanyName);
            destination.SiteId = _companyService.GetSiteIdByName(source.CompanyName);
        }
    }
}