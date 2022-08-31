using AFI.API.Models;
using AFI.Core.DomainModel;
using AutoMapper;

namespace AFI.API.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRegistrationDTO, Customer>()
                .ForPath(d => d.FirstName, opt => opt.MapFrom(s => s.PolicyHolderFirstName))
                .ForPath(d => d.LastName, opt => opt.MapFrom(s => s.PolicyHolderLastName))
                .ForPath(d => d.PolicyReferenceNumber, opt => opt.MapFrom(s => s.PolicyReferenceNumber))
                .ForPath(d => d.DOB, opt => opt.MapFrom(s => s.DOB))
                .ForPath(d => d.Email, opt => opt.MapFrom(s => s.PolicyHolderEmail));
        }
    }
}