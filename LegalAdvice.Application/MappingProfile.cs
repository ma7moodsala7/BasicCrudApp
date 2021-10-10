using AutoMapper;
using LegalAdvice.Application.Features.Client.Commands.CreateClient;
using LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer;
using LegalAdvice.Application.Features.Request.Commands.CreateRequest;
using LegalAdvice.Application.Features.Request.Queries.GetPageRequests;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, RequestListVm>().ReverseMap();
            CreateMap<Request, RequestDetailsVm>().ReverseMap();
            CreateMap<Request, RequestsForPageDto>().ReverseMap();
            CreateMap<Request, RequestWithCommentsVm>().ReverseMap();
            CreateMap<Request, CreateRequestCommand>().ReverseMap();
            
            CreateMap<RequestClientDto, Client>().ReverseMap();
            CreateMap<RequestLawyerDto, Lawyer>().ReverseMap();


            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, CreateClientCommand>().ReverseMap();


            CreateMap<Comment, CommentDetailsDto>().ReverseMap();
            CreateMap<Comment, RequestCommentDto>().ReverseMap();



            CreateMap<Lawyer, LawyerDto>().ReverseMap();
            CreateMap<Lawyer, CreateLawyerCommand>().ReverseMap();


        }
    }
}
