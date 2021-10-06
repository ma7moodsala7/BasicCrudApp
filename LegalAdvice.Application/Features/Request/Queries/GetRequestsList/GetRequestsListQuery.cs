using MediatR;
using System.Collections.Generic;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    // Make this class a message by letting it implement the IRequest interface.
    // The type parameter, that is for IRequest is going to be the type of data that this query is going to be getting back

    // this is inter-object communication, so that will be a message.

    public class GetRequestsListQuery : IRequest<List<RequestListVm>>
    {
    }
}
