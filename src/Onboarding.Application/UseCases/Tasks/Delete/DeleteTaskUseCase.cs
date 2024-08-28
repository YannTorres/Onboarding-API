
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Tasks;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Tasks.Delete;
public class DeleteTaskUseCase : IDeleteTaskUseCase
{
    private readonly IWriteOnlyTaskRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTaskUseCase(IWriteOnlyTaskRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
            throw new NotFoundException("Task not found.");
        
        await _unitOfWork.Commit();
    }
}
