using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Feedback;
using Onboarding.Communication.Response.Meets;
using Onboarding.Communication.Response.Posts;
using Onboarding.Communication.Response.Tasks;

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
        CreateMap<RequestPostJson, Domain.Entities.Post>();
        CreateMap<RequestFeedbackJson, Domain.Entities.Feedback>();
        CreateMap<RequestMeetJson, Domain.Entities.Meet>();
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Task, ResponseRegisteredTaskJson>();
        CreateMap<Domain.Entities.Task, ResponseShortTaskJson>();

        CreateMap<Domain.Entities.Feedback, ResponseRegisteredFeedbackJson>();

        CreateMap<Domain.Entities.Post, ResponseRegisteredPostJson>();
        CreateMap<Domain.Entities.Post, ResponsePostJson>();
        CreateMap<Domain.Entities.Post, ResponsePostsJson>();


        CreateMap<Domain.Entities.Meet, ResponseRegisteredMeetJson>();
        CreateMap<Domain.Entities.Meet, ResponseMeetJson>();
    }
}
