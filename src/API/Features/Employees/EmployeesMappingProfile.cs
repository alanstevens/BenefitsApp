using AutoMapper;
using Paylocity.Benefits.Service.Entities;
using Paylocity.Benefits.Service.Shared;

namespace Paylocity.Benefits.Service.Features.Employees
{
    public class EmployeesMappingProfile : Profile
    {
        public EmployeesMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>(MemberList.Source);

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

            CreateMap<CreateDependentRequest, Dependent>(MemberList.Source);

            CreateMap<Dependent, CreateDependentResponse>()
                .ForMember(dest => dest.PersonalBenefitsCost,
                    opts => opts.MapFrom(
                        src => src.PersonalBenefitsCost.ToCurrency()))
                .ForMember(x => x.EmployeeAnnualBenefitsCost, opt => opt.Ignore())
                .ForMember(x => x.EmployeeBenefitsCostPerPaycheck, opt => opt.Ignore());
        }
    }
}
