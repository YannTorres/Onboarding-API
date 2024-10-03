using Microsoft.Extensions.DependencyInjection;
using Onboarding.Application.AutoMapper;
using Onboarding.Application.UseCases.Feedback.Register;
using Onboarding.Application.UseCases.Meets.Delete;
using Onboarding.Application.UseCases.Meets.GetAll;
using Onboarding.Application.UseCases.Meets.GetById;
using Onboarding.Application.UseCases.Meets.Register;
using Onboarding.Application.UseCases.Posts.Delete;
using Onboarding.Application.UseCases.Posts.GetAll;
using Onboarding.Application.UseCases.Posts.GetById;
using Onboarding.Application.UseCases.Posts.Register;
using Onboarding.Application.UseCases.Tasks.Delete;
using Onboarding.Application.UseCases.Tasks.GetAll;
using Onboarding.Application.UseCases.Tasks.GetById;
using Onboarding.Application.UseCases.Tasks.Register;

namespace Onboarding.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection servies) 
    {
        servies.AddScoped<IRegisterTaskUseCase, RegisterTaskUseCase>();
        servies.AddScoped<IGetAllTasksUseCase, GetAllTasksUseCase>();
        servies.AddScoped<IGetByIdTaskUseCase, GetByIdTaskUseCase>();
        servies.AddScoped<IDeleteTaskUseCase, DeleteTaskUseCase>();

        servies.AddScoped<IRegisterFeedbackUseCase, RegisterFeedbackUseCase>();

        servies.AddScoped<IRegisterPostUseCase, RegisterPostUseCase>();
        servies.AddScoped<IGetByIdPostUseCase, GetByIdPostUseCase>();
        servies.AddScoped<IGetAllPostsUseCase, GetAllPostsUseCase>();
        servies.AddScoped<IDeletePostUseCase, DeletePostUseCase>();

        servies.AddScoped<IDeleteMeetUseCase, DeleteMeetUseCase>();
        servies.AddScoped<IRegisterMeetUseCase, RegisterMeetUseCase>();
        servies.AddScoped<IGetAllMeetsUseCase, GetAllMeetsUseCase>();
        servies.AddScoped<IGetByIdMeetUseCase, GetByIdMeetUseCase>();
    }

}
