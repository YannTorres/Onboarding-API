
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Meets;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Meets.Delete;
public class DeleteMeetUseCase : IDeleteMeetUseCase
{
    private readonly IWriteOnlyMeetRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteMeetUseCase(IWriteOnlyMeetRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id)
    {
        var entity = await _repository.Delete(id);

        if (entity == false)
            throw new NotFoundException("Reunião não encontrada.");

        await _unitOfWork.Commit();
    }
}
