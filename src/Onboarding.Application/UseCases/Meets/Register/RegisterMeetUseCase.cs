using AutoMapper;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Meets;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Meets;

namespace Onboarding.Application.UseCases.Meets.Register;
public class RegisterMeetUseCase : IRegisterMeetUseCase
{
    private readonly IMapper _mapper;
    private readonly IWriteOnlyMeetRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterMeetUseCase(IMapper mapper, IWriteOnlyMeetRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task<ResponseRegisteredMeetJson> Execute(RequestMeetJson request)
    {
        var entity = _mapper.Map<Meet>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredMeetJson>(entity); 
    }
}
