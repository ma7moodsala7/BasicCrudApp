using AutoMapper;
using LegalAdvice.Application.Features.Client.Commands.CreateClient;
using LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer;
using LegalAdvice.Application.Features.Request.Commands.CreateRequest;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, RequestDetailsVm>().ReverseMap();
            CreateMap<Request, RequestListDto>().ReverseMap();
            CreateMap<Request, CreateRequestCommand>().ReverseMap();
            
            CreateMap<RequestListClientDto, Client>().ReverseMap();
            CreateMap<RequestListLawyerDto, Lawyer>().ReverseMap();
            CreateMap<RequestCommentDto, Comment>().ReverseMap();





            CreateMap<Client, RequestClientDto>().ReverseMap();
            CreateMap<Client, CreateClientCommand>().ReverseMap();





            CreateMap<Lawyer, RequestLawyerDto>().ReverseMap();
            CreateMap<Lawyer, CreateLawyerCommand>().ReverseMap();


        }
    }
}
