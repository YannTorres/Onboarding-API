using AutoMapper;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Posts;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Post;

namespace Onboarding.Application.UseCases.Posts.Register;
public class RegisterPostUseCase : IRegisterPostUseCase
{
    private readonly IWriteOnlyPostRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterPostUseCase(IWriteOnlyPostRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredPostJson> Execute(RequestPostJson request)
    {
        var entity = _mapper.Map<Post>(request);

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredPostJson>(entity);
    }
}
