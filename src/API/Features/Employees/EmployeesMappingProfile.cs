using AutoMapper;
using Paylocity.Benefits.Service.Entities;
using Paylocity.Benefits.Service.Shared;

namespace Paylocity.Benefits.Service.Features.Employees
{
    public class EmployeesMappingProfile : Profile
    {
        public EmployeesMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>()
                .ForMember(x => x.AnnualBenefitsCost, opt => opt.Ignore())
                .ForMember(x => x.BenefitsCostPerPaycheck, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PersonalBenefitsCost, opt => opt.Ignore())
                .ForMember(x => x.Dependents, opt => opt.Ignore());

            CreateMap<Employee, CreateEmployeeResponse>()
                .ForMember(dest => dest.PersonalBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.PersonalBenefitsCost.ToCurrency()))
                .ForMember(dest => dest.AnnualBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.AnnualBenefitsCost.ToCurrency()))
                .ForMember(dest => dest.BenefitsCostPerPaycheck,
                    opts => opts.MapFrom(
                        src => src.BenefitsCostPerPaycheck.ToCurrency()));

            CreateMap<CreateDependentRequest, Dependent>()
                .ForMember(x => x.Employee, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PersonalBenefitsCost, opt => opt.Ignore());

            CreateMap<Dependent, CreateDependentResponse>()
                .ForMember(dest => dest.PersonalBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.PersonalBenefitsCost.ToCurrency()))
                .ForMember(x => x.EmployeeAnnualBenefitsCost, opt => opt.Ignore())
                .ForMember(x => x.EmployeeBenefitsCostPerPaycheck, opt => opt.Ignore());
        }
    }
}
