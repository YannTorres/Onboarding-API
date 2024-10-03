using AutoMapper;
using Onboarding.Communication.Response.Tasks;
using Onboarding.Domain.Repositories.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Onboarding.Application.UseCases.Tasks.GetAll;
public class GetAllTasksUseCase : IGetAllTasksUseCase
{
    private readonly IReadOnlyTaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetAllTasksUseCase(IReadOnlyTaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public async Task<ResponseTasksJson> Execute()
    {
        var tasks = await _taskRepository.GetAll();

        return new ResponseTasksJson
        {
            Tasks = _mapper.Map<List<ResponseShortTaskJson>>(tasks),
        };
    }
}
