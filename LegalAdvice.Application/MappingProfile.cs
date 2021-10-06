using AutoMapper;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, RequestListVm>().ReverseMap();
            CreateMap<Request, RequestDetailsVm>().ReverseMap();
            CreateMap<Client, ClientDto>();
        }
    }
}
