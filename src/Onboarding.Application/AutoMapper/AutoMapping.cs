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
        CreateMap<RequestFeedbackJson, Domain.Entities.Feedback>();
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Task, ResponseRegisteredTaskJson>();
        CreateMap<Domain.Entities.Feedback, ResponseRegisteredFeedbackJson>();
        CreateMap<Domain.Entities.Task, ResponseShortTaskJson>();
    }
}
