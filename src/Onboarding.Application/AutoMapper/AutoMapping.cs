using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;

namespace Onboarding.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestTaskJson, Domain.Entities.Task>();
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Task, ResponseRegisteredTaskJson>();
        CreateMap<Domain.Entities.Task, ResponseShortTaskJson>();
    }
}
