using AutoMapper;
using Onboarding.Communication.Response.Tasks;
using Onboarding.Domain.Repositories.Tasks;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Tasks.GetById;
public class GetByIdTaskUseCase : IGetByIdTaskUseCase
{
    private readonly IReadOnlyTaskRepository _repository;
    private readonly IMapper _mapper;
    public GetByIdTaskUseCase(IReadOnlyTaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseShortTaskJson> Execute(long id)
    {
        var task = await _repository.GetById(id);

        if (task == null)
        {
            throw new NotFoundException("Task not found.");
        }

        return _mapper.Map<ResponseShortTaskJson>(task);
    }
}
