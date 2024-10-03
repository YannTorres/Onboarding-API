
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Post;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Posts.Delete;
public class DeletePostUseCase : IDeletePostUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWriteOnlyPostRepository _repository;
    public DeletePostUseCase(IWriteOnlyPostRepository repository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;        
        _repository = repository;        
    }
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
            throw new NotFoundException("Post não encontrado");

        await _unitOfWork.Commit();
    }
}
