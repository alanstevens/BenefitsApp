using AutoMapper;
using BenefitsApp.API.Shared;
using BenefitsApp.API.Shared.Entities;

namespace BenefitsApp.API.Features.Employees
{
    public class EmployeesMappingProfile : Profile
    {
        public EmployeesMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>(MemberList.Source);

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(dest => dest.PersonalBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.PersonalBenefitsCost.ToCurrencyString()))
                .ForMember(dest => dest.AnnualBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.AnnualBenefitsCost.ToCurrencyString()))
                .ForMember(dest => dest.BenefitsCostPerPaycheck,
                    opts => opts.MapFrom(
                        src => src.BenefitsCostPerPaycheck.ToCurrencyString()));

            CreateMap<CreateDependentRequest, Dependent>(MemberList.Source);

            CreateMap<Dependent, DependentResponse>()
                .ForMember(dest => dest.PersonalBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.PersonalBenefitsCost.ToCurrencyString()));
            //.ForMember(x => x.EmployeeAnnualBenefitsCost, opt => opt.Ignore())
            //.ForMember(x => x.EmployeeBenefitsCostPerPaycheck, opt => opt.Ignore());
        }
    }
}
