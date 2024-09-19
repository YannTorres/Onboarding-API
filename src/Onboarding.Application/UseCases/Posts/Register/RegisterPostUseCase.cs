using Onboarding.Communication.Requests;
using Onboarding.Communication.Response;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Post;

namespace Onboarding.Application.UseCases.Posts.Register;
public class RegisterPostUseCase : IRegisterPostUseCase
{
    private readonly IWriteOnlyPostRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterPostUseCase(IWriteOnlyPostRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public Task<ResponseRegisteredPostJson> Execute(RequestPostJson request)
    {
        throw new NotImplementedException();
    }
}
